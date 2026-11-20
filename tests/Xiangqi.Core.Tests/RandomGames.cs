using System;
using System.Collections.Generic;
using Xiangqi.Core;

namespace Xiangqi.Core.Tests
{
    /// <summary>
    /// Seeded random playouts for property tests. Uses System.Random with an explicit seed so every run
    /// explores the same positions; a failure can be reproduced from the seed alone.
    /// </summary>
    internal static class RandomGames
    {
        /// <summary>Plays random legal moves and yields a copy of every <paramref name="every"/>-th position.</summary>
        public static IEnumerable<Position> SamplePositions(int seed, int games, int maxPlies, int every)
        {
            var rng = new Random(seed);
            var moves = new List<Move>(64);
            for (int g = 0; g < games; g++)
            {
                var p = Position.Initial();
                for (int ply = 0; ply < maxPlies; ply++)
                {
                    if (ply % every == 0)
                    {
                        yield return p.Clone();
                    }

                    p.GenerateLegalMoves(moves);
                    if (moves.Count == 0)
                    {
                        yield return p.Clone();
                        break;
                    }

                    p.MakeUnchecked(PickMove(p, moves, rng));
                }
            }
        }

        /// <summary>
        /// Prefers captures 60% of the time so playouts also reach sparse endgames, where checkmate,
        /// stalemate and long-range piece interactions are common.
        /// </summary>
        public static Move PickMove(Position p, List<Move> legal, Random rng)
        {
            if (rng.NextDouble() < 0.6)
            {
                int start = rng.Next(legal.Count);
                for (int i = 0; i < legal.Count; i++)
                {
                    var m = legal[(start + i) % legal.Count];
                    if (p.GetPiece(m.To).HasValue)
                    {
                        return m;
                    }
                }
            }

            return legal[rng.Next(legal.Count)];
        }
    }
}
