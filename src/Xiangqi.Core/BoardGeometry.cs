using System.Collections.Generic;

namespace Xiangqi.Core
{
    /// <summary>A precomputed step: a destination plus the intermediate point that must be empty (eye or leg).</summary>
    internal readonly struct Step
    {
        public readonly byte To;
        public readonly byte Via;

        public Step(int to, int via)
        {
            To = (byte)to;
            Via = (byte)via;
        }
    }

    /// <summary>
    /// Static board geometry for all piece types, computed once. Move generation and attack detection
    /// read these tables instead of recomputing coordinates.
    /// </summary>
    internal static class BoardGeometry
    {
        /// <summary>Ray directions: north (towards Black), south, east, west.</summary>
        public static readonly int[] RayFileDelta = { 0, 0, 1, -1 };
        public static readonly int[] RayRankDelta = { 1, -1, 0, 0 };

        /// <summary>Rays[square][direction] = squares in order moving away from the square.</summary>
        public static readonly byte[][][] Rays = new byte[Square.Count][][];

        /// <summary>GeneralMoves[side][square] = palace-confined orthogonal targets.</summary>
        public static readonly byte[][][] GeneralMoves = { new byte[Square.Count][], new byte[Square.Count][] };

        /// <summary>AdvisorMoves[side][square] = palace-confined diagonal targets.</summary>
        public static readonly byte[][][] AdvisorMoves = { new byte[Square.Count][], new byte[Square.Count][] };

        /// <summary>ElephantMoves[side][square] = own-half two-point diagonal steps with eye point.</summary>
        public static readonly Step[][][] ElephantMoves = { new Step[Square.Count][], new Step[Square.Count][] };

        /// <summary>HorseMoves[square] = horse steps with leg point.</summary>
        public static readonly Step[][] HorseMoves = new Step[Square.Count][];

        /// <summary>HorseAttackers[square] = (horse square, leg point) pairs from which a horse reaches the square.</summary>
        public static readonly Step[][] HorseAttackers = new Step[Square.Count][];

        /// <summary>SoldierMoves[side][square] = soldier targets.</summary>
        public static readonly byte[][][] SoldierMoves = { new byte[Square.Count][], new byte[Square.Count][] };

        /// <summary>SoldierAttackers[side][square] = squares from which a soldier of that side reaches the square.</summary>
        public static readonly byte[][][] SoldierAttackers = { new byte[Square.Count][], new byte[Square.Count][] };

        static BoardGeometry()
        {
            for (int sq = 0; sq < Square.Count; sq++)
            {
                int f = sq % Square.Files;
                int r = sq / Square.Files;

                Rays[sq] = new byte[4][];
                for (int d = 0; d < 4; d++)
                {
                    var ray = new List<byte>();
                    int nf = f + RayFileDelta[d];
                    int nr = r + RayRankDelta[d];
                    while (OnBoard(nf, nr))
                    {
                        ray.Add((byte)Index(nf, nr));
                        nf += RayFileDelta[d];
                        nr += RayRankDelta[d];
                    }

                    Rays[sq][d] = ray.ToArray();
                }

                var horse = new List<Step>();
                // (leg file delta, leg rank delta) followed by the two diagonal continuations.
                int[,] orth = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
                for (int i = 0; i < 4; i++)
                {
                    int lf = f + orth[i, 0];
                    int lr = r + orth[i, 1];
                    if (!OnBoard(lf, lr))
                    {
                        continue;
                    }

                    for (int side = -1; side <= 1; side += 2)
                    {
                        // Continue one more point in the same orthogonal direction, offset sideways by one.
                        int tf = lf + orth[i, 0] + (orth[i, 0] == 0 ? side : 0);
                        int tr = lr + orth[i, 1] + (orth[i, 1] == 0 ? side : 0);
                        if (OnBoard(tf, tr))
                        {
                            horse.Add(new Step(Index(tf, tr), Index(lf, lr)));
                        }
                    }
                }

                HorseMoves[sq] = horse.ToArray();

                for (int s = 0; s < 2; s++)
                {
                    var side = (Side)s;
                    var general = new List<byte>();
                    var advisor = new List<byte>();
                    var elephant = new List<Step>();
                    var soldier = new List<byte>();

                    for (int i = 0; i < 4; i++)
                    {
                        int tf = f + orth[i, 0];
                        int tr = r + orth[i, 1];
                        if (OnBoard(tf, tr) && InPalace(side, tf, tr) && InPalace(side, f, r))
                        {
                            general.Add((byte)Index(tf, tr));
                        }
                    }

                    for (int df = -1; df <= 1; df += 2)
                    {
                        for (int dr = -1; dr <= 1; dr += 2)
                        {
                            int af = f + df;
                            int ar = r + dr;
                            if (OnBoard(af, ar) && InPalace(side, af, ar) && InPalace(side, f, r))
                            {
                                advisor.Add((byte)Index(af, ar));
                            }

                            int ef = f + 2 * df;
                            int er = r + 2 * dr;
                            if (OnBoard(ef, er) && OnOwnHalf(side, er) && OnOwnHalf(side, r))
                            {
                                elephant.Add(new Step(Index(ef, er), Index(f + df, r + dr)));
                            }
                        }
                    }

                    int forward = side == Side.Red ? 1 : -1;
                    if (OnBoard(f, r + forward))
                    {
                        soldier.Add((byte)Index(f, r + forward));
                    }

                    if (HasCrossedRiver(side, r))
                    {
                        if (OnBoard(f - 1, r))
                        {
                            soldier.Add((byte)Index(f - 1, r));
                        }

                        if (OnBoard(f + 1, r))
                        {
                            soldier.Add((byte)Index(f + 1, r));
                        }
                    }

                    GeneralMoves[s][sq] = general.ToArray();
                    AdvisorMoves[s][sq] = advisor.ToArray();
                    ElephantMoves[s][sq] = elephant.ToArray();
                    SoldierMoves[s][sq] = soldier.ToArray();
                }
            }

            // Reverse tables for attack detection.
            var horseAttackers = new List<Step>[Square.Count];
            var soldierAttackers = new[] { new List<byte>[Square.Count], new List<byte>[Square.Count] };
            for (int sq = 0; sq < Square.Count; sq++)
            {
                horseAttackers[sq] = new List<Step>();
                soldierAttackers[0][sq] = new List<byte>();
                soldierAttackers[1][sq] = new List<byte>();
            }

            for (int from = 0; from < Square.Count; from++)
            {
                foreach (var step in HorseMoves[from])
                {
                    horseAttackers[step.To].Add(new Step(from, step.Via));
                }

                for (int s = 0; s < 2; s++)
                {
                    foreach (byte to in SoldierMoves[s][from])
                    {
                        soldierAttackers[s][to].Add((byte)from);
                    }
                }
            }

            for (int sq = 0; sq < Square.Count; sq++)
            {
                HorseAttackers[sq] = horseAttackers[sq].ToArray();
                SoldierAttackers[0][sq] = soldierAttackers[0][sq].ToArray();
                SoldierAttackers[1][sq] = soldierAttackers[1][sq].ToArray();
            }
        }

        public static int Index(int file, int rank) => rank * Square.Files + file;

        public static bool OnBoard(int file, int rank) =>
            (uint)file < Square.Files && (uint)rank < Square.Ranks;

        /// <summary>Palace: files d–f (3–5); ranks 0–2 for Red, 7–9 for Black.</summary>
        public static bool InPalace(Side side, int file, int rank) =>
            file >= 3 && file <= 5 && (side == Side.Red ? rank <= 2 : rank >= 7);

        public static bool InPalace(Side side, int square) =>
            InPalace(side, square % Square.Files, square / Square.Files);

        /// <summary>Own half: ranks 0–4 for Red, 5–9 for Black.</summary>
        public static bool OnOwnHalf(Side side, int rank) => side == Side.Red ? rank <= 4 : rank >= 5;

        /// <summary>A soldier has crossed the river once on the opponent's half.</summary>
        public static bool HasCrossedRiver(Side side, int rank) => !OnOwnHalf(side, rank);
    }
}
