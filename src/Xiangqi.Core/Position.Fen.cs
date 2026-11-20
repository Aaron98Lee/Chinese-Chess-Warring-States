using System;
using System.Globalization;
using System.Text;

namespace Xiangqi.Core
{
    /// <summary>Thrown when a FEN string is malformed or describes an impossible position.</summary>
    public sealed class FenException : FormatException
    {
        /// <summary>Creates the exception.</summary>
        public FenException(string message)
            : base(message)
        {
        }
    }

    public sealed partial class Position
    {
        private static readonly int[] MaxCount = { 1, 2, 2, 2, 2, 2, 5 }; // by PieceType

        /// <summary>
        /// Parses a Xiangqi FEN string. Ranks are listed from Black's back rank (rank 9) to Red's
        /// (rank 0). Upper case is Red. Accepted letters: K, A, B or E (Elephant), N or H (Horse), R,
        /// C, P. The side to move is "w" or "r" for Red and "b" for Black. The castling and en passant
        /// fields are ignored; halfmove and fullmove counters are optional.
        /// </summary>
        /// <remarks>
        /// The position is validated: exactly one General per side, no more pieces of a type than the
        /// starting set, every piece on a point it could legally occupy, Generals not facing, and the
        /// side not to move not in check. Stable piece identities are assigned Red first, then Black,
        /// each in square order (rank 0 to 9, file a to i).
        /// </remarks>
        /// <exception cref="FenException">The FEN is malformed or the position is impossible.</exception>
        public static Position FromFen(string fen)
        {
            if (string.IsNullOrWhiteSpace(fen))
            {
                throw new FenException("FEN is empty.");
            }

            string[] fields = fen.Trim().Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            var p = new Position();
            ParsePlacement(fields[0], p);

            if (fields.Length > 1)
            {
                p._sideToMove = fields[1] switch
                {
                    "w" or "r" or "W" or "R" => Side.Red,
                    "b" or "B" => Side.Black,
                    _ => throw new FenException($"Unknown side to move '{fields[1]}' (expected w, r or b)."),
                };
            }

            if (fields.Length > 4)
            {
                if (!int.TryParse(fields[4], NumberStyles.None, CultureInfo.InvariantCulture, out p._halfmoveClock))
                {
                    throw new FenException($"Invalid halfmove clock '{fields[4]}'.");
                }
            }

            if (fields.Length > 5)
            {
                if (!int.TryParse(fields[5], NumberStyles.None, CultureInfo.InvariantCulture, out p._fullmoveNumber)
                    || p._fullmoveNumber < 1)
                {
                    throw new FenException($"Invalid fullmove number '{fields[5]}'.");
                }
            }

            p.AssignPieceIds();
            p.Validate();
            p._hash = p.ComputeHash();
            return p;
        }

        /// <summary>Serialises the position as FEN using WXF letters, for example the initial position as <see cref="InitialFen"/>.</summary>
        public string ToFen()
        {
            var sb = new StringBuilder(96);
            for (int rank = Square.Ranks - 1; rank >= 0; rank--)
            {
                int empty = 0;
                for (int file = 0; file < Square.Files; file++)
                {
                    byte code = _cells[BoardGeometry.Index(file, rank)];
                    if (code == 0)
                    {
                        empty++;
                        continue;
                    }

                    if (empty > 0)
                    {
                        sb.Append((char)('0' + empty));
                        empty = 0;
                    }

                    sb.Append(new Piece(code).ToFenChar());
                }

                if (empty > 0)
                {
                    sb.Append((char)('0' + empty));
                }

                if (rank > 0)
                {
                    sb.Append('/');
                }
            }

            sb.Append(_sideToMove == Side.Red ? " w" : " b");
            sb.Append(" - - ");
            sb.Append(_halfmoveClock.ToString(CultureInfo.InvariantCulture));
            sb.Append(' ');
            sb.Append(_fullmoveNumber.ToString(CultureInfo.InvariantCulture));
            return sb.ToString();
        }

        private static void ParsePlacement(string placement, Position p)
        {
            string[] ranks = placement.Split('/');
            if (ranks.Length != Square.Ranks)
            {
                throw new FenException($"Expected 10 ranks separated by '/', found {ranks.Length}.");
            }

            for (int i = 0; i < Square.Ranks; i++)
            {
                int rank = Square.Ranks - 1 - i;
                int file = 0;
                foreach (char ch in ranks[i])
                {
                    if (ch >= '1' && ch <= '9')
                    {
                        file += ch - '0';
                        continue;
                    }

                    if (file >= Square.Files)
                    {
                        throw new FenException($"Rank {rank} has more than 9 files.");
                    }

                    if (!TryParsePieceLetter(ch, out var piece))
                    {
                        throw new FenException($"Unknown piece letter '{ch}'.");
                    }

                    p._cells[BoardGeometry.Index(file, rank)] = piece.Code;
                    file++;
                }

                if (file != Square.Files)
                {
                    throw new FenException($"Rank {rank} has {file} files; expected 9.");
                }
            }
        }

        private static bool TryParsePieceLetter(char ch, out Piece piece)
        {
            Side side = char.IsUpper(ch) ? Side.Red : Side.Black;
            PieceType? type = char.ToLowerInvariant(ch) switch
            {
                'k' => PieceType.General,
                'a' => PieceType.Advisor,
                'b' or 'e' => PieceType.Elephant,
                'n' or 'h' => PieceType.Horse,
                'r' => PieceType.Chariot,
                'c' => PieceType.Cannon,
                'p' => PieceType.Soldier,
                _ => null,
            };
            piece = type.HasValue ? new Piece(side, type.Value) : default;
            return type.HasValue;
        }

        private void AssignPieceIds()
        {
            sbyte next = 0;
            for (int s = 0; s < 2; s++)
            {
                for (int sq = 0; sq < Square.Count; sq++)
                {
                    byte code = _cells[sq];
                    if (code != 0 && (int)Piece.CodeSide(code) == s)
                    {
                        _ids[sq] = next++;
                    }
                }
            }
        }

        private void Validate()
        {
            var counts = new int[2, 7];
            for (int sq = 0; sq < Square.Count; sq++)
            {
                byte code = _cells[sq];
                if (code == 0)
                {
                    continue;
                }

                Side side = Piece.CodeSide(code);
                PieceType type = Piece.CodeType(code);
                counts[(int)side, (int)type]++;

                if (!CanOccupy(side, type, sq))
                {
                    throw new FenException(
                        $"{side} {type} on {new Square(sq)} is on a point it can never legally reach.");
                }

                if (type == PieceType.General)
                {
                    _generalSquare[(int)side] = sq;
                }
            }

            for (int s = 0; s < 2; s++)
            {
                if (counts[s, (int)PieceType.General] != 1)
                {
                    throw new FenException($"{(Side)s} must have exactly one General; found {counts[s, (int)PieceType.General]}.");
                }

                for (int t = 0; t < 7; t++)
                {
                    if (counts[s, t] > MaxCount[t])
                    {
                        throw new FenException($"{(Side)s} has {counts[s, t]} {(PieceType)t} pieces; the maximum is {MaxCount[t]}.");
                    }
                }
            }

            if (GeneralsFacing())
            {
                throw new FenException("The Generals face each other on an open file, which is illegal.");
            }

            if (IsInCheck(_sideToMove.Opponent()))
            {
                throw new FenException(
                    $"{_sideToMove.Opponent()} is in check but it is {_sideToMove}'s move, so the previous move was illegal.");
            }
        }

        /// <summary>True if a piece of this side and type can ever stand on the square under the rules.</summary>
        private static bool CanOccupy(Side side, PieceType type, int sq)
        {
            int file = sq % Square.Files;
            int rank = sq / Square.Files;
            int relRank = side == Side.Red ? rank : Square.Ranks - 1 - rank; // 0 = own back rank

            switch (type)
            {
                case PieceType.General:
                    return BoardGeometry.InPalace(side, file, rank);

                case PieceType.Advisor:
                    // Palace corners and centre: (d|f, 0), (e, 1), (d|f, 2) relative to the own back rank.
                    return BoardGeometry.InPalace(side, file, rank) && ((file + relRank) % 2 == 1);

                case PieceType.Elephant:
                    // Seven elephant points per side: (c|g, 0), (a|e|i, 2), (c|g, 4).
                    return relRank <= 4 && relRank % 2 == 0 && file % 2 == 0 && ((file / 2 + relRank / 2) % 2 == 1);

                case PieceType.Soldier:
                    // Never behind its starting rank; before the river only on the starting files a, c, e, g, i.
                    if (relRank < 3)
                    {
                        return false;
                    }

                    return relRank >= 5 || file % 2 == 0;

                default:
                    return true;
            }
        }
    }
}
