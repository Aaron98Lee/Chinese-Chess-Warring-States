using System;
using System.Collections.Generic;

namespace Xiangqi.Core
{
    /// <summary>
    /// Perft: counts the leaf nodes of the legal move tree to a fixed depth. The standard way to verify
    /// a move generator against published reference values and independent engines.
    /// </summary>
    public static class Perft
    {
        /// <summary>Counts leaf nodes at <paramref name="depth"/> plies from the position.</summary>
        public static long Count(Position position, int depth)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (depth < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depth), depth, "Depth must be non-negative.");
            }

            var buffers = new List<Move>[depth + 1];
            for (int i = 0; i <= depth; i++)
            {
                buffers[i] = new List<Move>(64);
            }

            return CountRecursive(position, depth, buffers);
        }

        /// <summary>Per-move breakdown of the perft count, for locating move-generation bugs.</summary>
        public static IReadOnlyList<KeyValuePair<Move, long>> Divide(Position position, int depth)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (depth < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(depth), depth, "Depth must be at least 1.");
            }

            var result = new List<KeyValuePair<Move, long>>();
            foreach (var move in position.LegalMoves())
            {
                var undo = position.MakeUnchecked(move);
                result.Add(new KeyValuePair<Move, long>(move, Count(position, depth - 1)));
                position.Unmake(undo);
            }

            return result;
        }

        private static long CountRecursive(Position position, int depth, List<Move>[] buffers)
        {
            if (depth == 0)
            {
                return 1;
            }

            var moves = buffers[depth];
            position.GenerateLegalMoves(moves);
            if (depth == 1)
            {
                return moves.Count;
            }

            long nodes = 0;
            for (int i = 0; i < moves.Count; i++)
            {
                var undo = position.MakeUnchecked(moves[i]);
                nodes += CountRecursive(position, depth - 1, buffers);
                position.Unmake(undo);
            }

            return nodes;
        }
    }
}
