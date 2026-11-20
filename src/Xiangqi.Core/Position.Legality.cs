using System;

namespace Xiangqi.Core
{
    public sealed partial class Position
    {
        /// <summary>
        /// Checks whether a move is legal for the side to move and, if not, explains why.
        /// The result agrees exactly with <see cref="LegalMoves"/>: a move is legal here if and only if it
        /// appears there.
        /// </summary>
        public MoveCheck Check(Move move)
        {
            int from = move.From.Index;
            int to = move.To.Index;
            byte code = _cells[from];

            if (code == 0)
            {
                return MoveCheck.Illegal(IllegalReason.NoPieceAtSource, move.From);
            }

            Side side = Piece.CodeSide(code);
            if (side != _sideToMove)
            {
                return MoveCheck.Illegal(IllegalReason.NotYourPiece, move.From);
            }

            if (from == to)
            {
                return MoveCheck.Illegal(IllegalReason.InvalidMovePattern);
            }

            byte target = _cells[to];
            if (target != 0 && Piece.CodeSide(target) == side)
            {
                return MoveCheck.Illegal(IllegalReason.OwnPieceAtTarget, move.To);
            }

            var geometry = CheckGeometry(Piece.CodeType(code), side, move.From, move.To, target != 0);
            if (!geometry.IsLegal)
            {
                return geometry;
            }

            // The move is pseudo-legal: now verify the mover's General is safe afterwards.
            var undo = MakeUnchecked(move);
            try
            {
                if (GeneralsFacing())
                {
                    return MoveCheck.Illegal(IllegalReason.FlyingGeneral, new Square(_generalSquare[(int)side.Opponent()]));
                }

                int attacker = FindAttackerOfGeneral(side);
                if (attacker >= 0)
                {
                    return MoveCheck.Illegal(IllegalReason.LeavesGeneralInCheck, new Square(attacker));
                }
            }
            finally
            {
                Unmake(undo);
            }

            return MoveCheck.Legal;
        }

        private MoveCheck CheckGeometry(PieceType type, Side side, Square from, Square to, bool isCapture)
        {
            int df = to.File - from.File;
            int dr = to.Rank - from.Rank;
            int adf = Math.Abs(df);
            int adr = Math.Abs(dr);

            switch (type)
            {
                case PieceType.General:
                    if (adf + adr != 1)
                    {
                        return MoveCheck.Illegal(IllegalReason.InvalidMovePattern);
                    }

                    return BoardGeometry.InPalace(side, to.Index)
                        ? MoveCheck.Legal
                        : MoveCheck.Illegal(IllegalReason.PalaceRestriction);

                case PieceType.Advisor:
                    if (adf != 1 || adr != 1)
                    {
                        return MoveCheck.Illegal(IllegalReason.InvalidMovePattern);
                    }

                    return BoardGeometry.InPalace(side, to.Index)
                        ? MoveCheck.Legal
                        : MoveCheck.Illegal(IllegalReason.PalaceRestriction);

                case PieceType.Elephant:
                {
                    if (adf != 2 || adr != 2)
                    {
                        return MoveCheck.Illegal(IllegalReason.InvalidMovePattern);
                    }

                    if (!BoardGeometry.OnOwnHalf(side, to.Rank))
                    {
                        return MoveCheck.Illegal(IllegalReason.RiverRestriction);
                    }

                    var eye = new Square(from.File + df / 2, from.Rank + dr / 2);
                    return _cells[eye.Index] == 0
                        ? MoveCheck.Legal
                        : MoveCheck.Illegal(IllegalReason.ElephantEyeBlocked, eye);
                }

                case PieceType.Horse:
                {
                    if (!((adf == 1 && adr == 2) || (adf == 2 && adr == 1)))
                    {
                        return MoveCheck.Illegal(IllegalReason.InvalidMovePattern);
                    }

                    // The leg is the adjacent orthogonal point in the direction of the long leg of the move.
                    var leg = adr == 2
                        ? new Square(from.File, from.Rank + dr / 2)
                        : new Square(from.File + df / 2, from.Rank);
                    return _cells[leg.Index] == 0
                        ? MoveCheck.Legal
                        : MoveCheck.Illegal(IllegalReason.HorseLegBlocked, leg);
                }

                case PieceType.Chariot:
                {
                    if (df != 0 && dr != 0)
                    {
                        return MoveCheck.Illegal(IllegalReason.InvalidMovePattern);
                    }

                    int blocker = FirstPieceBetween(from, to, out _);
                    return blocker < 0
                        ? MoveCheck.Legal
                        : MoveCheck.Illegal(IllegalReason.PathObstructed, new Square(blocker));
                }

                case PieceType.Cannon:
                {
                    if (df != 0 && dr != 0)
                    {
                        return MoveCheck.Illegal(IllegalReason.InvalidMovePattern);
                    }

                    int first = FirstPieceBetween(from, to, out int count, out int second);
                    if (!isCapture)
                    {
                        return count == 0
                            ? MoveCheck.Legal
                            : MoveCheck.Illegal(IllegalReason.PathObstructed, new Square(first));
                    }

                    if (count == 1)
                    {
                        return MoveCheck.Legal;
                    }

                    return count == 0
                        ? MoveCheck.Illegal(IllegalReason.CannonNeedsOneScreen)
                        : MoveCheck.Illegal(IllegalReason.CannonNeedsOneScreen, new Square(second));
                }

                case PieceType.Soldier:
                {
                    int forward = side == Side.Red ? 1 : -1;
                    if (df == 0 && dr == forward)
                    {
                        return MoveCheck.Legal;
                    }

                    if (dr == 0 && adf == 1)
                    {
                        return BoardGeometry.HasCrossedRiver(side, from.Rank)
                            ? MoveCheck.Legal
                            : MoveCheck.Illegal(IllegalReason.SoldierSidewaysBeforeRiver);
                    }

                    return MoveCheck.Illegal(IllegalReason.SoldierCannotMoveThatWay);
                }

                default:
                    throw new InvalidOperationException($"Unknown piece type {type}.");
            }
        }

        /// <summary>Square index of the first piece strictly between two squares on a line, or -1.</summary>
        private int FirstPieceBetween(Square from, Square to, out int count) =>
            FirstPieceBetween(from, to, out count, out _);

        /// <summary>
        /// Scans the points strictly between two squares on the same file or rank. Returns the first
        /// occupied point (or -1), the number of occupied points, and the second occupied point (or -1).
        /// </summary>
        private int FirstPieceBetween(Square from, Square to, out int count, out int second)
        {
            int stepFile = Math.Sign(to.File - from.File);
            int stepRank = Math.Sign(to.Rank - from.Rank);
            int step = stepRank * Square.Files + stepFile;
            int first = -1;
            second = -1;
            count = 0;

            for (int sq = from.Index + step; sq != to.Index; sq += step)
            {
                if (_cells[sq] == 0)
                {
                    continue;
                }

                count++;
                if (first < 0)
                {
                    first = sq;
                }
                else if (second < 0)
                {
                    second = sq;
                }
            }

            return first;
        }
    }
}
