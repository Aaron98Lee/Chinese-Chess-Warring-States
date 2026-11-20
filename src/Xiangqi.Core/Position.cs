using System;
using System.Collections.Generic;

namespace Xiangqi.Core
{
    /// <summary>
    /// A Xiangqi position: piece placement with stable piece identities, side to move, move counters
    /// and Zobrist hash. This is the authoritative rules implementation; it has no dependency on any
    /// game engine, does no I/O and uses no randomness.
    /// </summary>
    /// <remarks>
    /// Implements the traditional rules: palace and river restrictions, Elephant eye and Horse leg
    /// blocking, Chariot obstruction, Cannon screen captures, Soldier movement before and after the
    /// river, the flying-General rule, and the prohibition on leaving one's own General in check.
    /// A side with no legal move loses, whether in check (checkmate) or not (stalemate).
    /// History-dependent rules (repetition, perpetual check, move limits) belong to the session layer.
    /// </remarks>
    public sealed partial class Position
    {
        /// <summary>FEN of the standard opening position.</summary>
        public const string InitialFen = "rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w - - 0 1";

        private readonly byte[] _cells = new byte[Square.Count];
        private readonly sbyte[] _ids = new sbyte[Square.Count];
        private readonly int[] _generalSquare = new int[2];
        private Side _sideToMove;
        private ulong _hash;
        private int _halfmoveClock;
        private int _fullmoveNumber = 1;

        // Scratch buffer for pseudo-legal moves in GenerateLegalMoves. Safe to reuse because legality
        // filtering only makes and unmakes moves; it never re-enters move generation.
        private readonly List<Move> _pseudoScratch = new List<Move>(128);

        private Position()
        {
            for (int i = 0; i < Square.Count; i++)
            {
                _ids[i] = -1;
            }
        }

        /// <summary>Creates the standard opening position.</summary>
        public static Position Initial() => FromFen(InitialFen);

        /// <summary>The side to move.</summary>
        public Side SideToMove => _sideToMove;

        /// <summary>Zobrist hash of placement and side to move (identical across platforms and runs).</summary>
        public ulong Hash => _hash;

        /// <summary>Plies since the last capture (FEN halfmove field). Used by the session's move-limit rule.</summary>
        public int HalfmoveClock => _halfmoveClock;

        /// <summary>Full-move number, incremented after each Black move (FEN fullmove field).</summary>
        public int FullmoveNumber => _fullmoveNumber;

        /// <summary>Returns the piece on a square, or null if the square is empty.</summary>
        public PieceInfo? GetPiece(Square square)
        {
            byte code = _cells[square.Index];
            return code == 0 ? (PieceInfo?)null : new PieceInfo(new Piece(code), _ids[square.Index], square);
        }

        /// <summary>All pieces on the board, in square order.</summary>
        public IEnumerable<PieceInfo> Pieces()
        {
            for (int sq = 0; sq < Square.Count; sq++)
            {
                if (_cells[sq] != 0)
                {
                    yield return new PieceInfo(new Piece(_cells[sq]), _ids[sq], new Square(sq));
                }
            }
        }

        /// <summary>The square of the given side's General.</summary>
        public Square GeneralSquare(Side side) => new Square(_generalSquare[(int)side]);

        /// <summary>Creates an independent copy of this position.</summary>
        public Position Clone()
        {
            var copy = new Position();
            Array.Copy(_cells, copy._cells, Square.Count);
            Array.Copy(_ids, copy._ids, Square.Count);
            copy._generalSquare[0] = _generalSquare[0];
            copy._generalSquare[1] = _generalSquare[1];
            copy._sideToMove = _sideToMove;
            copy._hash = _hash;
            copy._halfmoveClock = _halfmoveClock;
            copy._fullmoveNumber = _fullmoveNumber;
            return copy;
        }

        /// <summary>
        /// True if both positions are identical in every respect: placement, piece identities, side to
        /// move, counters and hash.
        /// </summary>
        public bool IsIdenticalTo(Position other)
        {
            if (other == null)
            {
                return false;
            }

            for (int i = 0; i < Square.Count; i++)
            {
                if (_cells[i] != other._cells[i] || _ids[i] != other._ids[i])
                {
                    return false;
                }
            }

            return _sideToMove == other._sideToMove
                && _hash == other._hash
                && _halfmoveClock == other._halfmoveClock
                && _fullmoveNumber == other._fullmoveNumber
                && _generalSquare[0] == other._generalSquare[0]
                && _generalSquare[1] == other._generalSquare[1];
        }

        /// <summary>Recomputes the Zobrist hash from scratch (used to verify incremental updates).</summary>
        public ulong ComputeHash()
        {
            ulong h = 0;
            for (int sq = 0; sq < Square.Count; sq++)
            {
                if (_cells[sq] != 0)
                {
                    h ^= Zobrist.PieceSquare[_cells[sq], sq];
                }
            }

            if (_sideToMove == Side.Black)
            {
                h ^= Zobrist.BlackToMove;
            }

            return h;
        }

        // ------------------------------------------------------------------ make / unmake

        /// <summary>
        /// Makes a move after verifying it is legal.
        /// </summary>
        /// <exception cref="InvalidOperationException">The move is illegal; the message gives the reason.</exception>
        public UndoRecord Make(Move move)
        {
            var check = Check(move);
            if (!check.IsLegal)
            {
                throw new InvalidOperationException($"Illegal move {move}: {check}.");
            }

            return MakeUnchecked(move);
        }

        /// <summary>
        /// Makes a move without legality checks. The caller must guarantee the move is legal, for
        /// example because it came from <see cref="GenerateLegalMoves"/>. Intended for search and perft.
        /// </summary>
        public UndoRecord MakeUnchecked(Move move)
        {
            int from = move.From.Index;
            int to = move.To.Index;
            byte moving = _cells[from];
            byte captured = _cells[to];
            var undo = new UndoRecord(move, moving, captured, _ids[to], _hash, _halfmoveClock, _fullmoveNumber);

            _hash ^= Zobrist.PieceSquare[moving, from] ^ Zobrist.PieceSquare[moving, to];
            if (captured != 0)
            {
                _hash ^= Zobrist.PieceSquare[captured, to];
            }

            _cells[to] = moving;
            _cells[from] = 0;
            _ids[to] = _ids[from];
            _ids[from] = -1;

            if (Piece.CodeType(moving) == PieceType.General)
            {
                _generalSquare[(int)Piece.CodeSide(moving)] = to;
            }

            _halfmoveClock = captured != 0 ? 0 : _halfmoveClock + 1;
            if (_sideToMove == Side.Black)
            {
                _fullmoveNumber++;
            }

            _sideToMove = _sideToMove.Opponent();
            _hash ^= Zobrist.BlackToMove;
            return undo;
        }

        /// <summary>Undoes a move, restoring the exact previous position (including hash and counters).</summary>
        public void Unmake(in UndoRecord undo)
        {
            int from = undo.Move.From.Index;
            int to = undo.Move.To.Index;

            _sideToMove = _sideToMove.Opponent();
            _ids[from] = _ids[to];
            _cells[from] = undo.MovedCode;
            _cells[to] = undo.CapturedCode;
            _ids[to] = undo.CapturedCode == 0 ? (sbyte)-1 : undo.CapturedId;

            if (Piece.CodeType(undo.MovedCode) == PieceType.General)
            {
                _generalSquare[(int)Piece.CodeSide(undo.MovedCode)] = from;
            }

            _hash = undo.PreviousHash;
            _halfmoveClock = undo.PreviousHalfmoveClock;
            _fullmoveNumber = undo.PreviousFullmoveNumber;
        }

        // ------------------------------------------------------------------ check detection

        /// <summary>True if the side to move is in check.</summary>
        public bool IsInCheck() => IsInCheck(_sideToMove);

        /// <summary>True if the given side's General is attacked (including by a facing General).</summary>
        public bool IsInCheck(Side side) => FindAttackerOfGeneral(side) >= 0;

        /// <summary>
        /// Returns the square of a piece giving check to the given side's General, or null if none.
        /// A facing enemy General on an open file counts as giving check (flying-General rule).
        /// </summary>
        public Square? FindCheckingPiece(Side side)
        {
            int sq = FindAttackerOfGeneral(side);
            return sq >= 0 ? new Square(sq) : (Square?)null;
        }

        private int FindAttackerOfGeneral(Side defender)
        {
            int king = _generalSquare[(int)defender];
            Side attacker = defender.Opponent();
            byte chariot = Piece.Encode(attacker, PieceType.Chariot);
            byte cannon = Piece.Encode(attacker, PieceType.Cannon);
            byte general = Piece.Encode(attacker, PieceType.General);
            byte horse = Piece.Encode(attacker, PieceType.Horse);
            byte soldier = Piece.Encode(attacker, PieceType.Soldier);

            var rays = BoardGeometry.Rays[king];
            for (int d = 0; d < 4; d++)
            {
                var ray = rays[d];
                int i = 0;
                for (; i < ray.Length; i++)
                {
                    byte c = _cells[ray[i]];
                    if (c == 0)
                    {
                        continue;
                    }

                    if (c == chariot || (c == general && d < 2))
                    {
                        return ray[i];
                    }

                    break;
                }

                for (i++; i < ray.Length; i++)
                {
                    byte c = _cells[ray[i]];
                    if (c == 0)
                    {
                        continue;
                    }

                    if (c == cannon)
                    {
                        return ray[i];
                    }

                    break;
                }
            }

            foreach (var step in BoardGeometry.HorseAttackers[king])
            {
                if (_cells[step.To] == horse && _cells[step.Via] == 0)
                {
                    return step.To;
                }
            }

            foreach (byte s in BoardGeometry.SoldierAttackers[(int)attacker][king])
            {
                if (_cells[s] == soldier)
                {
                    return s;
                }
            }

            return -1;
        }

        private bool GeneralsFacing()
        {
            int red = _generalSquare[0];
            int black = _generalSquare[1];
            if (red % Square.Files != black % Square.Files)
            {
                return false;
            }

            for (int sq = red + Square.Files; sq < black; sq += Square.Files)
            {
                if (_cells[sq] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        // ------------------------------------------------------------------ move generation

        /// <summary>All legal moves for the side to move.</summary>
        public IReadOnlyList<Move> LegalMoves()
        {
            var moves = new List<Move>(64);
            GenerateLegalMoves(moves);
            return moves;
        }

        /// <summary>All legal moves of the piece on the given square (empty if it is not the side to move's piece).</summary>
        public IReadOnlyList<Move> LegalMovesFrom(Square square)
        {
            var moves = new List<Move>(17);
            byte code = _cells[square.Index];
            if (code != 0 && Piece.CodeSide(code) == _sideToMove)
            {
                var pseudo = new List<Move>(17);
                GeneratePseudoLegalFrom(square.Index, pseudo);
                FilterLegal(pseudo, moves);
            }

            return moves;
        }

        /// <summary>
        /// Writes all legal moves for the side to move into <paramref name="buffer"/> (which is cleared first).
        /// Does not allocate once the buffers have grown; intended for search and perft.
        /// A position instance is not thread-safe: use <see cref="Clone"/> per thread.
        /// </summary>
        public void GenerateLegalMoves(List<Move> buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            buffer.Clear();
            var pseudo = _pseudoScratch;
            pseudo.Clear();
            for (int sq = 0; sq < Square.Count; sq++)
            {
                byte code = _cells[sq];
                if (code != 0 && Piece.CodeSide(code) == _sideToMove)
                {
                    GeneratePseudoLegalFrom(sq, pseudo);
                }
            }

            FilterLegal(pseudo, buffer);
        }

        /// <summary>True if the side to move has at least one legal move.</summary>
        public bool HasLegalMove()
        {
            var pseudo = new List<Move>(17);
            for (int sq = 0; sq < Square.Count; sq++)
            {
                byte code = _cells[sq];
                if (code == 0 || Piece.CodeSide(code) != _sideToMove)
                {
                    continue;
                }

                pseudo.Clear();
                GeneratePseudoLegalFrom(sq, pseudo);
                foreach (var m in pseudo)
                {
                    if (IsSafeAfter(m))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>The status of this position: ongoing, checkmate or stalemate (both of which lose).</summary>
        public PositionStatus Status()
        {
            if (HasLegalMove())
            {
                return PositionStatus.Ongoing;
            }

            return IsInCheck() ? PositionStatus.Checkmate : PositionStatus.Stalemate;
        }

        /// <summary>The winner if the game has ended in this position (the side to move has no legal move), otherwise null.</summary>
        public Side? Winner() => Status() == PositionStatus.Ongoing ? (Side?)null : _sideToMove.Opponent();

        private void FilterLegal(List<Move> pseudo, List<Move> legal)
        {
            foreach (var m in pseudo)
            {
                if (IsSafeAfter(m))
                {
                    legal.Add(m);
                }
            }
        }

        /// <summary>True if making the (pseudo-legal) move leaves the mover's General safe.</summary>
        private bool IsSafeAfter(Move m)
        {
            Side mover = _sideToMove;
            var undo = MakeUnchecked(m);
            bool safe = FindAttackerOfGeneral(mover) < 0;
            Unmake(undo);
            return safe;
        }

        private void GeneratePseudoLegalFrom(int from, List<Move> moves)
        {
            byte code = _cells[from];
            Side side = Piece.CodeSide(code);
            int s = (int)side;
            var origin = new Square(from);

            switch (Piece.CodeType(code))
            {
                case PieceType.General:
                    foreach (byte to in BoardGeometry.GeneralMoves[s][from])
                    {
                        AddIfNotOwn(origin, to, side, moves);
                    }

                    break;

                case PieceType.Advisor:
                    foreach (byte to in BoardGeometry.AdvisorMoves[s][from])
                    {
                        AddIfNotOwn(origin, to, side, moves);
                    }

                    break;

                case PieceType.Elephant:
                    foreach (var step in BoardGeometry.ElephantMoves[s][from])
                    {
                        if (_cells[step.Via] == 0)
                        {
                            AddIfNotOwn(origin, step.To, side, moves);
                        }
                    }

                    break;

                case PieceType.Horse:
                    foreach (var step in BoardGeometry.HorseMoves[from])
                    {
                        if (_cells[step.Via] == 0)
                        {
                            AddIfNotOwn(origin, step.To, side, moves);
                        }
                    }

                    break;

                case PieceType.Chariot:
                    foreach (var ray in BoardGeometry.Rays[from])
                    {
                        foreach (byte to in ray)
                        {
                            byte target = _cells[to];
                            if (target == 0)
                            {
                                moves.Add(new Move(origin, new Square(to)));
                                continue;
                            }

                            if (Piece.CodeSide(target) != side)
                            {
                                moves.Add(new Move(origin, new Square(to)));
                            }

                            break;
                        }
                    }

                    break;

                case PieceType.Cannon:
                    foreach (var ray in BoardGeometry.Rays[from])
                    {
                        bool screened = false;
                        foreach (byte to in ray)
                        {
                            byte target = _cells[to];
                            if (!screened)
                            {
                                if (target == 0)
                                {
                                    moves.Add(new Move(origin, new Square(to)));
                                }
                                else
                                {
                                    screened = true;
                                }

                                continue;
                            }

                            if (target != 0)
                            {
                                if (Piece.CodeSide(target) != side)
                                {
                                    moves.Add(new Move(origin, new Square(to)));
                                }

                                break;
                            }
                        }
                    }

                    break;

                case PieceType.Soldier:
                    foreach (byte to in BoardGeometry.SoldierMoves[s][from])
                    {
                        AddIfNotOwn(origin, to, side, moves);
                    }

                    break;
            }
        }

        private void AddIfNotOwn(Square origin, int to, Side side, List<Move> moves)
        {
            byte target = _cells[to];
            if (target == 0 || Piece.CodeSide(target) != side)
            {
                moves.Add(new Move(origin, new Square(to)));
            }
        }
    }
}
