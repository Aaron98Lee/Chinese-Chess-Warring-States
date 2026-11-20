namespace Xiangqi.Core
{
    /// <summary>
    /// Why a move is illegal. The presentation layer uses these to explain rule violations to the
    /// player without reimplementing any rules.
    /// </summary>
    public enum IllegalReason : byte
    {
        /// <summary>The move is legal.</summary>
        None = 0,

        /// <summary>There is no piece on the origin square.</summary>
        NoPieceAtSource,

        /// <summary>The piece on the origin square belongs to the side not to move.</summary>
        NotYourPiece,

        /// <summary>The destination holds a piece of the moving side.</summary>
        OwnPieceAtTarget,

        /// <summary>The move does not match the piece's movement pattern at all.</summary>
        InvalidMovePattern,

        /// <summary>A General or Advisor would leave its palace.</summary>
        PalaceRestriction,

        /// <summary>An Elephant would cross the river.</summary>
        RiverRestriction,

        /// <summary>The Elephant's eye point (the intermediate diagonal point) is occupied.</summary>
        ElephantEyeBlocked,

        /// <summary>The Horse's leg point (the adjacent orthogonal point) is occupied.</summary>
        HorseLegBlocked,

        /// <summary>A Chariot, or a non-capturing Cannon, would pass through a piece.</summary>
        PathObstructed,

        /// <summary>A Cannon capture needs exactly one screen piece between it and the target.</summary>
        CannonNeedsOneScreen,

        /// <summary>A Soldier tried to move sideways before crossing the river.</summary>
        SoldierSidewaysBeforeRiver,

        /// <summary>A Soldier tried to move backward, diagonally or more than one point.</summary>
        SoldierCannotMoveThatWay,

        /// <summary>After the move, the moving side's General would be attacked.</summary>
        LeavesGeneralInCheck,

        /// <summary>After the move, the two Generals would face each other on an open file.</summary>
        FlyingGeneral,
    }

    /// <summary>The result of checking a move for legality.</summary>
    public readonly struct MoveCheck
    {
        private MoveCheck(IllegalReason reason, Square? relatedSquare)
        {
            Reason = reason;
            RelatedSquare = relatedSquare;
        }

        /// <summary>A legal result.</summary>
        public static MoveCheck Legal => new MoveCheck(IllegalReason.None, null);

        /// <summary>True if the move is legal.</summary>
        public bool IsLegal => Reason == IllegalReason.None;

        /// <summary>Why the move is illegal, or <see cref="IllegalReason.None"/>.</summary>
        public IllegalReason Reason { get; }

        /// <summary>
        /// The square most relevant to the violation, if any: the blocking piece (eye, leg, path,
        /// extra screen), the attacking piece (self-check), the enemy General (flying General), or
        /// the occupied destination (own piece at target).
        /// </summary>
        public Square? RelatedSquare { get; }

        /// <summary>Creates an illegal result.</summary>
        public static MoveCheck Illegal(IllegalReason reason, Square? relatedSquare = null) =>
            new MoveCheck(reason, relatedSquare);

        /// <inheritdoc />
        public override string ToString() =>
            IsLegal ? "Legal" : RelatedSquare.HasValue ? $"{Reason} ({RelatedSquare.Value})" : Reason.ToString();
    }

    /// <summary>The terminal status of a position from the rules engine's point of view.</summary>
    /// <remarks>
    /// Repetition, perpetual check, move limits and agreed draws are adjudicated by the session layer,
    /// which owns the game history. The rules engine reports only what a single position determines.
    /// </remarks>
    public enum PositionStatus : byte
    {
        /// <summary>The side to move has at least one legal move.</summary>
        Ongoing = 0,

        /// <summary>The side to move is in check and has no legal move: it loses.</summary>
        Checkmate,

        /// <summary>
        /// The side to move is not in check but has no legal move: in Xiangqi it <b>loses</b>
        /// (困斃). Unlike international chess, this is not a draw.
        /// </summary>
        Stalemate,
    }

    /// <summary>Everything needed to undo one move exactly.</summary>
    public readonly struct UndoRecord
    {
        internal UndoRecord(Move move, byte movedCode, byte capturedCode, sbyte capturedId,
            ulong previousHash, int previousHalfmoveClock, int previousFullmoveNumber)
        {
            Move = move;
            MovedCode = movedCode;
            CapturedCode = capturedCode;
            CapturedId = capturedId;
            PreviousHash = previousHash;
            PreviousHalfmoveClock = previousHalfmoveClock;
            PreviousFullmoveNumber = previousFullmoveNumber;
        }

        /// <summary>The move that was made.</summary>
        public Move Move { get; }

        internal byte MovedCode { get; }

        internal byte CapturedCode { get; }

        internal sbyte CapturedId { get; }

        internal ulong PreviousHash { get; }

        internal int PreviousHalfmoveClock { get; }

        internal int PreviousFullmoveNumber { get; }

        /// <summary>The piece that moved.</summary>
        public Piece MovedPiece => new Piece(MovedCode);

        /// <summary>The captured piece, if the move was a capture.</summary>
        public Piece? CapturedPiece => CapturedCode == 0 ? (Piece?)null : new Piece(CapturedCode);

        /// <summary>The stable identity of the captured piece, if the move was a capture.</summary>
        public int? CapturedPieceId => CapturedCode == 0 ? (int?)null : CapturedId;
    }
}
