namespace Xiangqi.Core
{
    /// <summary>
    /// Zobrist hashing keys. Generated from a fixed seed with SplitMix64 so hashes are identical on
    /// every platform and run, which keeps saves, replays and repetition detection deterministic.
    /// </summary>
    internal static class Zobrist
    {
        /// <summary>PieceSquare[pieceCode, square]; codes 0 and 8 are unused (zero keys).</summary>
        public static readonly ulong[,] PieceSquare = new ulong[16, Square.Count];

        /// <summary>XORed into the hash when Black is to move.</summary>
        public static readonly ulong BlackToMove;

        static Zobrist()
        {
            ulong state = 0x5851F42D4C957F2DUL; // Fixed seed: do not change, or stored hashes become invalid.
            for (int code = 1; code < 16; code++)
            {
                if (code == 8)
                {
                    continue;
                }

                for (int sq = 0; sq < Square.Count; sq++)
                {
                    PieceSquare[code, sq] = Next(ref state);
                }
            }

            BlackToMove = Next(ref state);
        }

        private static ulong Next(ref ulong state)
        {
            unchecked
            {
                state += 0x9E3779B97F4A7C15UL;
                ulong z = state;
                z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
                z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
                return z ^ (z >> 31);
            }
        }
    }
}
