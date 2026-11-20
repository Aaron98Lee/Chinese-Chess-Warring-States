using System;
using NUnit.Framework;
using Xiangqi.Core;

namespace Xiangqi.Core.Tests
{
    /// <summary>FEN parsing, validation and serialisation, and ICCS notation (QG-09 partial, QG-10).</summary>
    [TestFixture]
    public class FenAndNotationTests
    {
        [Test]
        public void InitialPosition_RoundTripsThroughFen()
        {
            Assert.That(Position.Initial().ToFen(), Is.EqualTo(Position.InitialFen));
        }

        [Test]
        public void HorseAndElephantLetterVariants_AreAccepted()
        {
            // Letter convention used by some references (H = Horse, E = Elephant).
            var variant = Position.FromFen("rheakaehr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RHEAKAEHR w - - 0 1");
            Assert.That(variant.IsIdenticalTo(Position.Initial()), Is.True);
        }

        [Test]
        public void OptionalFields_DefaultSensibly()
        {
            var p = Position.FromFen("rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR");
            Assert.That(p.SideToMove, Is.EqualTo(Side.Red));
            Assert.That(p.HalfmoveClock, Is.EqualTo(0));
            Assert.That(p.FullmoveNumber, Is.EqualTo(1));
            Assert.That(Position.FromFen("rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR r").SideToMove, Is.EqualTo(Side.Red));
        }

        [Test]
        public void Counters_RoundTrip()
        {
            const string fen = "3k5/9/9/9/9/9/4P4/9/9/4K4 b - - 17 42";
            Assert.That(Position.FromFen(fen).ToFen(), Is.EqualTo(fen));
        }

        [TestCase("rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/RNBAKABNR w", TestName = "Rejects 9 ranks")]
        [TestCase("rnbakabnr1/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w", TestName = "Rejects 10 files")]
        [TestCase("rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNX w", TestName = "Rejects unknown letter")]
        [TestCase("rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR x", TestName = "Rejects unknown side")]
        [TestCase("3k5/9/9/9/9/9/9/9/4K4/4K4 w", TestName = "Rejects two Red Generals")]
        [TestCase("9/9/9/9/9/9/9/9/9/4K4 w", TestName = "Rejects missing Black General")]
        [TestCase("3k5/9/9/9/9/9/9/9/9/2K6 w", TestName = "Rejects General outside palace")]
        [TestCase("3k5/9/9/9/9/9/9/9/9/3KA4 w", TestName = "Rejects Advisor off its points")]
        [TestCase("3k5/9/9/9/2B6/9/9/9/9/4K4 w", TestName = "Rejects Elephant across the river")]
        [TestCase("3k5/9/9/9/9/9/9/4P4/9/3K5 w", TestName = "Rejects Soldier behind its starting rank")]
        [TestCase("3k5/9/9/9/9/9/1P7/9/9/4K4 w", TestName = "Rejects Soldier on an unreachable file before the river")]
        [TestCase("3k5/9/9/9/9/9/9/9/RRR6/4K4 w", TestName = "Rejects three Chariots")]
        [TestCase("4k4/9/9/9/9/9/9/9/9/4K4 w", TestName = "Rejects facing Generals")]
        [TestCase("4k4/9/9/9/9/9/9/9/4R4/3K5 w", TestName = "Rejects side not to move being in check")]
        public void ImpossiblePositions_AreRejected(string fen)
        {
            Assert.Throws<FenException>(() => Position.FromFen(fen));
        }

        [Test]
        public void Square_ParsesAndFormatsIccs()
        {
            var s = Square.Parse("h9");
            Assert.That(s.File, Is.EqualTo(7));
            Assert.That(s.Rank, Is.EqualTo(9));
            Assert.That(s.ToString(), Is.EqualTo("h9"));
            Assert.That(Square.TryParse("j0", out _), Is.False);
            Assert.That(Square.TryParse("a", out _), Is.False);
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Square(9, 0));
        }

        [Test]
        public void Move_ParsesAndFormatsIccs()
        {
            var m = Move.Parse("h2e2");
            Assert.That(m.From, Is.EqualTo(Square.Parse("h2")));
            Assert.That(m.To, Is.EqualTo(Square.Parse("e2")));
            Assert.That(m.ToString(), Is.EqualTo("h2e2"));
            Assert.That(Move.Parse("H2-E2"), Is.EqualTo(m));
            Assert.That(Move.TryParse("h2e", out _), Is.False);
        }

        [Test]
        public void IccsRoundTrip_ForEveryLegalMoveOfManyPositions()
        {
            foreach (var position in RandomGames.SamplePositions(seed: 7, games: 40, maxPlies: 120, every: 3))
            {
                foreach (var move in position.LegalMoves())
                {
                    Assert.That(Move.Parse(move.ToString()), Is.EqualTo(move));
                }
            }
        }

        [Test]
        public void PieceIds_AreAssignedRedFirstInSquareOrder()
        {
            var p = Position.Initial();
            Assert.That(p.GetPiece(Square.Parse("a0"))!.Value.PieceId, Is.EqualTo(0));
            Assert.That(p.GetPiece(Square.Parse("e0"))!.Value.PieceId, Is.EqualTo(4));
            Assert.That(p.GetPiece(Square.Parse("i3"))!.Value.PieceId, Is.EqualTo(15));
            Assert.That(p.GetPiece(Square.Parse("a6"))!.Value.PieceId, Is.EqualTo(16));
            Assert.That(p.GetPiece(Square.Parse("i9"))!.Value.PieceId, Is.EqualTo(31));
        }
    }
}
