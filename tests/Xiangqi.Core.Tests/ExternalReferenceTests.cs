using System.IO;
using System.Text.Json;
using NUnit.Framework;
using Xiangqi.Core;

namespace Xiangqi.Core.Tests
{
    /// <summary>
    /// Compares perft counts against reference values produced by an independent engine
    /// (Fairy-Stockfish, run externally through its Python binding; see tests/data/README.md).
    /// Only the resulting numbers are stored in this repository: no third-party code is included.
    /// </summary>
    [TestFixture]
    public class ExternalReferenceTests
    {
        private const string DataFile = "perft-fairy-stockfish.json";

        [Test]
        public void PerftMatchesIndependentEngine_ForAllReferencePositions()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "data", DataFile);
            Assert.That(File.Exists(path), Is.True, $"Reference data not found: {path}");

            using var doc = JsonDocument.Parse(File.ReadAllText(path));
            int checkedPositions = 0;
            long checkedNodes = 0;

            foreach (var entry in doc.RootElement.GetProperty("positions").EnumerateArray())
            {
                string fen = entry.GetProperty("fen").GetString()!;
                var position = Position.FromFen(fen);
                int depth = 0;
                foreach (var expected in entry.GetProperty("perft").EnumerateArray())
                {
                    depth++;
                    long actual = Perft.Count(position, depth);
                    if (actual != expected.GetInt64())
                    {
                        Assert.Fail($"perft({depth}) = {actual}, reference {expected.GetInt64()} for {fen}");
                    }

                    checkedNodes += actual;
                }

                checkedPositions++;
            }

            Assert.That(checkedPositions, Is.GreaterThan(100));
            TestContext.WriteLine($"Matched {checkedPositions} positions, {checkedNodes:N0} leaf nodes in total.");
        }
    }
}
