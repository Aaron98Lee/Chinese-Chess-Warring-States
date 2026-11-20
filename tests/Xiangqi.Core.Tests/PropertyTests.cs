using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xiangqi.Core;

namespace Xiangqi.Core.Tests
{
    /// <summary>
    /// Invariants checked over many seeded random games: exact undo (QG-05), incremental hash
    /// consistency, agreement between <see cref="Position.Check"/> and <see cref="Position.LegalMoves"/>
    /// (QG-03), FEN round-trips (QG-10), stable piece identities (QG-06) and determinism (QG-04).
    /// </summary>
    [TestFixture]
    public class PropertyTests
    {
        /// <summary>Number of random moves verified by the undo/hash property test (QG-05 requires ≥ 1,000,000).</summary>
        private const int UndoPropertyMoves = 1_000_000;

        [Test]
        public void MakeUnmake_RestoresExactPosition_AndHashStaysConsistent()
        {
            var rng = new Random(20261120);
            var moves = new List<Move>(64);
            long verified = 0;
            int games = 0;

            while (verified < UndoPropertyMoves)
            {
                games++;
                var p = Position.Initial();
                for (int ply = 0; ply < 300 && verified < UndoPropertyMoves; ply++)
                {
                    p.GenerateLegalMoves(moves);
                    if (moves.Count == 0)
                    {
                        break;
                    }

                    var move = RandomGames.PickMove(p, moves, rng);
                    var before = p.Clone();
                    var undo = p.MakeUnchecked(move);

                    if (p.Hash != p.ComputeHash())
                    {
                        Assert.Fail($"Incremental hash differs from recomputed hash after {move} (game {games}, ply {ply}).");
                    }

                    p.Unmake(undo);
                    if (!p.IsIdenticalTo(before))
                    {
                        Assert.Fail($"Unmake of {move} did not restore the position (game {games}, ply {ply}): {before.ToFen()}");
                    }

                    p.MakeUnchecked(move);
                    verified++;
                }
            }

            Assert.That(verified, Is.GreaterThanOrEqualTo(UndoPropertyMoves));
            TestContext.WriteLine($"Verified {verified:N0} make/unmake round trips over {games:N0} games.");
        }

        [Test]
        public void Check_AgreesWithLegalMoves_ForEveryFromToPair()
        {
            int positions = 0;
            foreach (var p in RandomGames.SamplePositions(seed: 11, games: 60, maxPlies: 200, every: 4))
            {
                positions++;
                var legal = new HashSet<Move>(p.LegalMoves());
                for (int from = 0; from < Square.Count; from++)
                {
                    for (int to = 0; to < Square.Count; to++)
                    {
                        var move = new Move(new Square(from), new Square(to));
                        bool accepted = p.Check(move).IsLegal;
                        if (accepted != legal.Contains(move))
                        {
                            Assert.Fail($"Check({move}) = {p.Check(move)} disagrees with LegalMoves in {p.ToFen()}");
                        }
                    }
                }

                // Per-square generation agrees with whole-board generation.
                var union = new HashSet<Move>();
                for (int sq = 0; sq < Square.Count; sq++)
                {
                    union.UnionWith(p.LegalMovesFrom(new Square(sq)));
                }

                Assert.That(union.SetEquals(legal), Is.True, $"LegalMovesFrom union differs in {p.ToFen()}");
            }

            Assert.That(positions, Is.GreaterThanOrEqualTo(1000), "Too few positions sampled.");
            TestContext.WriteLine($"Cross-checked {positions} positions × 8,100 from/to pairs.");
        }

        [Test]
        public void Fen_RoundTripsForRandomPositions()
        {
            foreach (var p in RandomGames.SamplePositions(seed: 3, games: 50, maxPlies: 200, every: 5))
            {
                string fen = p.ToFen();
                var reparsed = Position.FromFen(fen);
                Assert.That(reparsed.ToFen(), Is.EqualTo(fen));
                Assert.That(reparsed.Hash, Is.EqualTo(p.Hash));
            }
        }

        [Test]
        public void Status_IsConsistentWithLegalMovesAndCheck()
        {
            int terminal = 0;
            foreach (var p in RandomGames.SamplePositions(seed: 5, games: 400, maxPlies: 400, every: 25))
            {
                var status = p.Status();
                bool noMoves = p.LegalMoves().Count == 0;
                Assert.That(status == PositionStatus.Ongoing, Is.EqualTo(!noMoves));
                if (noMoves)
                {
                    terminal++;
                    Assert.That(status, Is.EqualTo(p.IsInCheck() ? PositionStatus.Checkmate : PositionStatus.Stalemate));
                    Assert.That(p.Winner(), Is.EqualTo(p.SideToMove.Opponent()));
                }
            }

            Assert.That(terminal, Is.GreaterThan(0), "Sampling should reach some finished games.");
            TestContext.WriteLine($"Terminal positions reached: {terminal}");
        }

        [Test]
        public void Capture_AndUndo_PreservePieceIdentities()
        {
            var p = Position.Initial();
            int cannonId = p.GetPiece(Square.Parse("h2"))!.Value.PieceId;
            int horseId = p.GetPiece(Square.Parse("h9"))!.Value.PieceId;

            var undo = p.Make(Move.Parse("h2h9")); // Cannon captures the Horse over the h7 Cannon screen.
            Assert.That(undo.CapturedPieceId, Is.EqualTo(horseId));
            Assert.That(undo.CapturedPiece, Is.EqualTo(new Piece(Side.Black, PieceType.Horse)));
            Assert.That(p.GetPiece(Square.Parse("h9"))!.Value.PieceId, Is.EqualTo(cannonId));
            Assert.That(p.Pieces().Count(), Is.EqualTo(31));
            Assert.That(p.HalfmoveClock, Is.EqualTo(0));

            p.Unmake(undo);
            Assert.That(p.IsIdenticalTo(Position.Initial()), Is.True);
            Assert.That(p.GetPiece(Square.Parse("h9"))!.Value.PieceId, Is.EqualTo(horseId));
        }

        [Test]
        public void Transpositions_ProduceIdenticalPositionsAndHashes()
        {
            var a = Position.Initial();
            foreach (var m in new[] { "h2e2", "h9g7", "b0c2" })
            {
                a.Make(Move.Parse(m));
            }

            var b = Position.Initial();
            foreach (var m in new[] { "b0c2", "h9g7", "h2e2" })
            {
                b.Make(Move.Parse(m));
            }

            Assert.That(a.Hash, Is.EqualTo(b.Hash));
            Assert.That(a.IsIdenticalTo(b), Is.True);
        }

        [Test]
        public void Counters_FollowFenSemantics()
        {
            var p = Position.Initial();
            p.Make(Move.Parse("h2e2"));
            Assert.That(p.HalfmoveClock, Is.EqualTo(1));
            Assert.That(p.FullmoveNumber, Is.EqualTo(1));
            p.Make(Move.Parse("h9g7"));
            Assert.That(p.HalfmoveClock, Is.EqualTo(2));
            Assert.That(p.FullmoveNumber, Is.EqualTo(2));
        }

        [Test]
        public void SameMoveSequence_IsDeterministic()
        {
            ulong Play()
            {
                var rng = new Random(99);
                var p = Position.Initial();
                var moves = new List<Move>();
                for (int i = 0; i < 150; i++)
                {
                    p.GenerateLegalMoves(moves);
                    if (moves.Count == 0)
                    {
                        break;
                    }

                    p.MakeUnchecked(RandomGames.PickMove(p, moves, rng));
                }

                return p.Hash;
            }

            Assert.That(Play(), Is.EqualTo(Play()));
        }

        [Test]
        public void Make_RejectsIllegalMoveWithReason()
        {
            var p = Position.Initial();
            // b1 is empty, but a Horse cannot move one point straight ahead.
            var ex = Assert.Throws<InvalidOperationException>(() => p.Make(Move.Parse("b0b1")));
            Assert.That(ex!.Message, Does.Contain("InvalidMovePattern"));
            Assert.That(p.IsIdenticalTo(Position.Initial()), Is.True, "A rejected move must not change the position.");
        }
    }
}
