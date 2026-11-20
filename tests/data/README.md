# Test reference data

## `perft-fairy-stockfish.json`

Perft node counts (depths 1–3) for a set of Xiangqi positions, produced by an **independent engine**
so our move generator is checked against an implementation we did not write (acceptance criterion
QG-01).

| Item | Value |
|---|---|
| Oracle | Fairy-Stockfish, through its Python binding `pyffish` (version recorded in the file's `oracle` field) |
| How it was run | Externally, in a scratch environment outside this repository. Counts were computed by recursing over `pyffish.legal_moves` |
| Positions | The initial position, four hand-picked rule probes, and positions reached by seeded random games (uniformly random, and capture-biased to reach sparse endgames, checkmates and stalemates) |
| Licence note | Fairy-Stockfish is GPL-3.0. **No Fairy-Stockfish code is included in or linked by this project.** Only the resulting numbers, which are facts about the positions, are stored here |
| Generated | 2026-11-20 |

During generation, the full sorted legal-move list of every position was also compared move by move
with our engine's list. The result is recorded in `docs/testing/test-register.md` (TR-010).

To regenerate, install `pyffish` in a separate virtual environment and recompute the counts. Never add
`pyffish` or Fairy-Stockfish as a dependency of any project in this repository.
