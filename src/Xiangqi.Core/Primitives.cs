using System;

namespace Xiangqi.Core
{
    /// <summary>
    /// The two sides of a Xiangqi game. In the rules and in notation, <see cref="Red"/> is the
    /// first player (先手) and <see cref="Black"/> the second player (後手), whichever states the
    /// players chose in the presentation layer.
    /// </summary>
    public enum Side : byte
    {
        /// <summary>The first player; moves first in the standard opening position.</summary>
        Red = 0,

        /// <summary>The second player.</summary>
        Black = 1,
    }

    /// <summary>Helpers for <see cref="Side"/>.</summary>
    public static class SideExtensions
    {
        /// <summary>Returns the other side.</summary>
        public static Side Opponent(this Side side) => side == Side.Red ? Side.Black : Side.Red;
    }

    /// <summary>
    /// The seven Xiangqi piece types, using their traditional rule names. The presentation layer
    /// may depict them differently (for example the Elephant as a strategist formation and the
    /// Cannon as a crossbow unit) without any change to their rules.
    /// </summary>
    public enum PieceType : byte
    {
        /// <summary>General (帥/將): one point orthogonally, confined to the palace.</summary>
        General = 0,

        /// <summary>Advisor (仕/士): one point diagonally, confined to the palace.</summary>
        Advisor = 1,

        /// <summary>Elephant (相/象): exactly two points diagonally, cannot cross the river, blocked by the eye point.</summary>
        Elephant = 2,

        /// <summary>Horse (傌/馬): one point orthogonally then one diagonally, blocked by the leg point.</summary>
        Horse = 3,

        /// <summary>Chariot (俥/車): any distance orthogonally, cannot pass pieces.</summary>
        Chariot = 4,

        /// <summary>Cannon (炮/砲): moves like a chariot; captures by jumping exactly one screen.</summary>
        Cannon = 5,

        /// <summary>Soldier (兵/卒): forward one point; also sideways after crossing the river; never backward.</summary>
        Soldier = 6,
    }

    /// <summary>
    /// A piece: a side and a type. Encoded internally as a byte: bits 0–2 hold type + 1, bit 3 is set
    /// for Black. Zero is reserved for an empty point.
    /// </summary>
    public readonly struct Piece : IEquatable<Piece>
    {
        internal readonly byte Code;

        internal Piece(byte code)
        {
            Code = code;
        }

        /// <summary>Creates a piece of the given side and type.</summary>
        public Piece(Side side, PieceType type)
        {
            Code = Encode(side, type);
        }

        /// <summary>The side that owns the piece.</summary>
        public Side Side => CodeSide(Code);

        /// <summary>The piece type.</summary>
        public PieceType Type => CodeType(Code);

        internal static byte Encode(Side side, PieceType type) => (byte)(((int)side << 3) | ((int)type + 1));

        internal static Side CodeSide(byte code) => (code & 8) != 0 ? Side.Black : Side.Red;

        internal static PieceType CodeType(byte code) => (PieceType)((code & 7) - 1);

        /// <summary>The FEN letter for this piece (WXF convention: K A B N R C P; upper case for Red).</summary>
        public char ToFenChar()
        {
            char c = Type switch
            {
                PieceType.General => 'k',
                PieceType.Advisor => 'a',
                PieceType.Elephant => 'b',
                PieceType.Horse => 'n',
                PieceType.Chariot => 'r',
                PieceType.Cannon => 'c',
                _ => 'p',
            };
            return Side == Side.Red ? char.ToUpperInvariant(c) : c;
        }

        /// <inheritdoc />
        public bool Equals(Piece other) => Code == other.Code;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is Piece other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Code;

        /// <summary>Equality operator.</summary>
        public static bool operator ==(Piece left, Piece right) => left.Equals(right);

        /// <summary>Inequality operator.</summary>
        public static bool operator !=(Piece left, Piece right) => !left.Equals(right);

        /// <inheritdoc />
        public override string ToString() => $"{Side} {Type}";
    }

    /// <summary>
    /// One of the 90 board intersections. Files are 0–8 (a–i, left to right from Red's view) and
    /// ranks are 0–9 (0 is Red's back rank), matching ICCS notation. Index = rank × 9 + file.
    /// </summary>
    public readonly struct Square : IEquatable<Square>
    {
        /// <summary>Number of files on the board.</summary>
        public const int Files = 9;

        /// <summary>Number of ranks on the board.</summary>
        public const int Ranks = 10;

        /// <summary>Number of intersections on the board.</summary>
        public const int Count = Files * Ranks;

        /// <summary>The square index, 0–89.</summary>
        public readonly byte Index;

        /// <summary>Creates a square from its index (0–89).</summary>
        /// <exception cref="ArgumentOutOfRangeException">The index is outside the board.</exception>
        public Square(int index)
        {
            if ((uint)index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Square index must be 0–89.");
            }

            Index = (byte)index;
        }

        /// <summary>Creates a square from a file (0–8) and a rank (0–9).</summary>
        /// <exception cref="ArgumentOutOfRangeException">The file or rank is outside the board.</exception>
        public Square(int file, int rank)
        {
            if ((uint)file >= Files)
            {
                throw new ArgumentOutOfRangeException(nameof(file), file, "File must be 0–8.");
            }

            if ((uint)rank >= Ranks)
            {
                throw new ArgumentOutOfRangeException(nameof(rank), rank, "Rank must be 0–9.");
            }

            Index = (byte)(rank * Files + file);
        }

        /// <summary>File, 0–8 (a–i).</summary>
        public int File => Index % Files;

        /// <summary>Rank, 0–9 (0 is Red's back rank).</summary>
        public int Rank => Index / Files;

        /// <summary>Parses an ICCS square such as "e0" or "h9".</summary>
        public static bool TryParse(string? text, out Square square)
        {
            square = default;
            if (text == null || text.Length != 2)
            {
                return false;
            }

            int file = char.ToLowerInvariant(text[0]) - 'a';
            int rank = text[1] - '0';
            if ((uint)file >= Files || (uint)rank >= Ranks)
            {
                return false;
            }

            square = new Square(file, rank);
            return true;
        }

        /// <summary>Parses an ICCS square such as "e0".</summary>
        /// <exception cref="FormatException">The text is not a valid square.</exception>
        public static Square Parse(string text)
        {
            if (!TryParse(text, out var square))
            {
                throw new FormatException($"'{text}' is not a valid ICCS square (expected a–i followed by 0–9).");
            }

            return square;
        }

        /// <inheritdoc />
        public bool Equals(Square other) => Index == other.Index;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is Square other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Index;

        /// <summary>Equality operator.</summary>
        public static bool operator ==(Square left, Square right) => left.Equals(right);

        /// <summary>Inequality operator.</summary>
        public static bool operator !=(Square left, Square right) => !left.Equals(right);

        /// <summary>The ICCS name of the square, for example "e0".</summary>
        public override string ToString() => $"{(char)('a' + File)}{Rank}";
    }

    /// <summary>A move from one square to another, written in ICCS notation as for example "h2e2".</summary>
    public readonly struct Move : IEquatable<Move>
    {
        /// <summary>Creates a move.</summary>
        public Move(Square from, Square to)
        {
            From = from;
            To = to;
        }

        /// <summary>The origin square.</summary>
        public Square From { get; }

        /// <summary>The destination square.</summary>
        public Square To { get; }

        /// <summary>Parses an ICCS move such as "h2e2" (a hyphen form "h2-e2" is also accepted).</summary>
        public static bool TryParse(string? text, out Move move)
        {
            move = default;
            if (text == null)
            {
                return false;
            }

            string t = text.Trim();
            if (t.Length == 5 && t[2] == '-')
            {
                t = t.Remove(2, 1);
            }

            if (t.Length != 4
                || !Square.TryParse(t.Substring(0, 2), out var from)
                || !Square.TryParse(t.Substring(2, 2), out var to))
            {
                return false;
            }

            move = new Move(from, to);
            return true;
        }

        /// <summary>Parses an ICCS move such as "h2e2".</summary>
        /// <exception cref="FormatException">The text is not a valid ICCS move.</exception>
        public static Move Parse(string text)
        {
            if (!TryParse(text, out var move))
            {
                throw new FormatException($"'{text}' is not a valid ICCS move (expected for example 'h2e2').");
            }

            return move;
        }

        /// <inheritdoc />
        public bool Equals(Move other) => From == other.From && To == other.To;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is Move other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => (From.Index << 8) | To.Index;

        /// <summary>Equality operator.</summary>
        public static bool operator ==(Move left, Move right) => left.Equals(right);

        /// <summary>Inequality operator.</summary>
        public static bool operator !=(Move left, Move right) => !left.Equals(right);

        /// <summary>The move in ICCS notation, for example "h2e2".</summary>
        public override string ToString() => $"{From}{To}";
    }

    /// <summary>A piece on the board together with its stable identity and location.</summary>
    public readonly struct PieceInfo
    {
        /// <summary>Creates a piece record.</summary>
        public PieceInfo(Piece piece, int pieceId, Square square)
        {
            Piece = piece;
            PieceId = pieceId;
            Square = square;
        }

        /// <summary>The piece.</summary>
        public Piece Piece { get; }

        /// <summary>
        /// Stable identity (0–31) assigned when the position is created. It never changes as the
        /// piece moves, is captured or is restored by undo, so the presentation layer can map each
        /// logical piece to exactly one formation.
        /// </summary>
        public int PieceId { get; }

        /// <summary>The square the piece stands on.</summary>
        public Square Square { get; }

        /// <inheritdoc />
        public override string ToString() => $"{Piece} #{PieceId} at {Square}";
    }
}
