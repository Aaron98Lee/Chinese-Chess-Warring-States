using System;
using System.Diagnostics;
using System.Globalization;
using Xiangqi.Core;

namespace Xiangqi.Tools.Cli
{
    /// <summary>Developer command-line tool for the rules engine. Not shipped with the game.</summary>
    internal static class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
                return 1;
            }

            try
            {
                switch (args[0])
                {
                    case "perft":
                        return RunPerft(args, divide: false);
                    case "divide":
                        return RunPerft(args, divide: true);
                    case "fen":
                        return ShowFen(args);
                    case "perft-file":
                        return RunPerftFile(args);
                    default:
                        PrintUsage();
                        return 1;
                }
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return 2;
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("xiangqi-cli perft  <depth> [fen]   count leaf nodes (default: initial position)");
            Console.WriteLine("xiangqi-cli divide <depth> [fen]   per-move perft breakdown");
            Console.WriteLine("xiangqi-cli fen    [fen]           validate a FEN and list legal moves");
            Console.WriteLine("xiangqi-cli perft-file <depth> <file>  for each FEN line: perft 1..depth and sorted legal moves");
        }

        private static Position ParsePosition(string[] args, int index) =>
            args.Length > index ? Position.FromFen(string.Join(" ", args, index, args.Length - index)) : Position.Initial();

        private static int RunPerft(string[] args, bool divide)
        {
            if (args.Length < 2 || !int.TryParse(args[1], NumberStyles.None, CultureInfo.InvariantCulture, out int depth) || depth < 1)
            {
                Console.Error.WriteLine("Depth must be a positive integer.");
                return 1;
            }

            var position = ParsePosition(args, 2);
            var sw = Stopwatch.StartNew();
            long total;
            if (divide)
            {
                total = 0;
                foreach (var entry in Perft.Divide(position, depth))
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                    total += entry.Value;
                }
            }
            else
            {
                total = Perft.Count(position, depth);
            }

            sw.Stop();
            double seconds = Math.Max(sw.Elapsed.TotalSeconds, 1e-9);
            Console.WriteLine($"perft({depth}) = {total}  [{sw.Elapsed.TotalMilliseconds:F0} ms, {total / seconds:F0} nodes/s]");
            return 0;
        }

        private static int RunPerftFile(string[] args)
        {
            if (args.Length < 3 || !int.TryParse(args[1], NumberStyles.None, CultureInfo.InvariantCulture, out int depth) || depth < 1)
            {
                Console.Error.WriteLine("Usage: perft-file <depth> <file>");
                return 1;
            }

            foreach (string raw in System.IO.File.ReadAllLines(args[2]))
            {
                string line = raw.Trim();
                if (line.Length == 0 || line.StartsWith("#", StringComparison.Ordinal))
                {
                    continue;
                }

                var position = Position.FromFen(line);
                var counts = new long[depth];
                for (int d = 1; d <= depth; d++)
                {
                    counts[d - 1] = Perft.Count(position, d);
                }

                var moves = new System.Collections.Generic.List<string>();
                foreach (var m in position.LegalMoves())
                {
                    moves.Add(m.ToString());
                }

                moves.Sort(StringComparer.Ordinal);
                Console.WriteLine($"{line}\t{string.Join(",", counts)}\t{string.Join(" ", moves)}\t{position.Status()}");
            }

            return 0;
        }

        private static int ShowFen(string[] args)
        {
            var position = ParsePosition(args, 1);
            Console.WriteLine(position.ToFen());
            Console.WriteLine($"Side to move: {position.SideToMove}; in check: {position.IsInCheck()}; status: {position.Status()}");
            Console.WriteLine($"Legal moves ({position.LegalMoves().Count}): {string.Join(" ", position.LegalMoves())}");
            return 0;
        }
    }
}
