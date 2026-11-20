using NUnit.Framework;
using Xiangqi.Core;

namespace Xiangqi.Core.Tests
{
    /// <summary>
    /// Move-generation conformance (QG-01). Depths 1–4 from the initial position are the published
    /// reference values (Chess Programming Wiki, "Chinese Chess Perft Results"; TalkChess perft threads).
    /// </summary>
    [TestFixture]
    public class PerftTests
    {
        [TestCase(1, 44L)]
        [TestCase(2, 1_920L)]
        [TestCase(3, 79_666L)]
        [TestCase(4, 3_290_240L)]
        public void InitialPosition_MatchesPublishedReference(int depth, long expected)
        {
            Assert.That(Perft.Count(Position.Initial(), depth), Is.EqualTo(expected));
        }

        /// <summary>
        /// Depth 5 (133,312,995 nodes, about 6 s). Value confirmed independently with Fairy-Stockfish
        /// (pyffish 0.0.91) on 2026-11-20; see docs/testing/test-register.md (TR-002).
        /// </summary>
        [Test]
        [Category("Slow")]
        public void InitialPosition_Depth5_MatchesIndependentEngine()
        {
            Assert.That(Perft.Count(Position.Initial(), 5), Is.EqualTo(133_312_995L));
        }

        [Test]
        public void Divide_SumsToTotal()
        {
            long total = 0;
            foreach (var entry in Perft.Divide(Position.Initial(), 3))
            {
                total += entry.Value;
            }

            Assert.That(total, Is.EqualTo(79_666L));
        }

        [Test]
        public void Perft_LeavesPositionUnchanged()
        {
            var p = Position.Initial();
            Perft.Count(p, 3);
            Assert.That(p.IsIdenticalTo(Position.Initial()), Is.True);
        }
    }
}
