# Test Register

Every row records a test that was **actually executed**, with its environment and evidence. A criterion is
never reported as passed without a row here (document 11, §7). Criteria not yet executed are listed at
the end as "not yet run".

## Environment for runs dated 2026-11-20

| Item | Value |
|---|---|
| Host | Linux container (Ubuntu 24.04), 4 cores, no GPU |
| .NET SDK | 8.0.134 (pinned by `global.json` to the 8.0 feature bands) |
| Test framework | NUnit 3.14.0, NUnit3TestAdapter 4.6.0, Microsoft.NET.Test.Sdk 17.11.1 |
| Build | Release, warnings as errors, C# 9 |
| Code | Milestone 2 increment 1 (branch `claude/sleepy-hamilton-7inm6s`) |

## Results

| ID | Criterion | Test | Result | Evidence |
|---|---|---|---|---|
| TR-001 | QG-01 | Perft from the initial position, depths 1–4, against published reference values (44 / 1,920 / 79,666 / 3,290,240) | **Pass** | `PerftTests.InitialPosition_MatchesPublishedReference` (4 cases) |
| TR-002 | QG-01 | Perft from the initial position, depth 5 | **133,312,995** (5.7 s, about 23M nodes/s). Independent confirmation at depth 5 by Fairy-Stockfish **started, not yet completed** (about 1 hour); depths 1–4 already confirmed (TR-010) | `xiangqi-cli perft 5` |
| TR-003 | QG-02 | Per-rule tests: every piece's legal moves and each illegal-move reason with its related square (palace, river, eye, leg, obstruction, cannon 0/1/2 screens, soldier before and after the river, own piece, opponent's piece, empty source, self-check through a pin, flying General), check by cannon and horse, checkmate, **stalemate = loss** | **Pass** (39 tests) | `RuleTests` |
| TR-004 | QG-03 | `Check` agrees with `LegalMoves` for every from/to pair (8,100) in each of 2,467 positions sampled from seeded random games; per-square generation agrees with whole-board generation | **Pass** | `PropertyTests.Check_AgreesWithLegalMoves_ForEveryFromToPair` |
| TR-005 | QG-05 | 1,000,000 make/unmake round trips over 4,697 seeded random games: position restored bit-identically, and the incremental hash equals the recomputed hash after every move | **Pass** | `PropertyTests.MakeUnmake_RestoresExactPosition_AndHashStaysConsistent` |
| TR-006 | QG-06 | Capture removes the piece from play; undo restores it with the same stable identity | **Pass** | `PropertyTests.Capture_AndUndo_PreservePieceIdentities` |
| TR-007 | QG-04 | Same moves give the same final hash; transpositions give identical positions and hashes | **Pass (single platform)**. Cross-platform determinism (Windows) not yet run | `PropertyTests.SameMoveSequence_IsDeterministic`, `Transpositions_ProduceIdenticalPositionsAndHashes` |
| TR-008 | QG-10 | FEN round-trips (initial position, counters, random positions); H/E letter variants; 14 impossible positions rejected | **Pass** | `FenAndNotationTests`, `PropertyTests.Fen_RoundTripsForRandomPositions` |
| TR-009 | QG-09 (partial) | ICCS notation: parse and format; round-trip for every legal move of sampled positions | **Pass**. WXF and Chinese notation not yet implemented | `FenAndNotationTests` |
| TR-010 | QG-01 | External cross-check against an independent engine (Fairy-Stockfish via pyffish 0.0.91, run externally): for **305 positions** (initial position, 4 rule probes, 300 seeded random-game positions: 102 with 25–32 pieces, 72 with 17–24, 50 with 9–16, 81 with ≤ 8 pieces, including 11 checkmates and 18 stalemates), the **exact sorted legal-move list** and **perft depths 1–3** were compared. Also initial-position perft depths 3 and 4 (79,666 and 3,290,240) | **Pass: 0 mismatches; 8,639,642 leaf nodes compared.** Initial-position depths 3 and 4 match | Counts stored in `tests/data/perft-fairy-stockfish.json` and re-checked on every test run by `ExternalReferenceTests` |
| TR-011 | — | Status consistency: Ongoing if and only if legal moves exist; otherwise Checkmate when in check, else Stalemate, and the side to move loses (247 terminal positions reached) | **Pass** | `PropertyTests.Status_IsConsistentWithLegalMovesAndCheck` |
| TR-012 | QR-03 (early) | Clean CI build and test on GitHub Actions (`ubuntu-latest`) from commit `8af85d5`: build with warnings as errors, full test suite, perft depth-4 smoke test | **Pass** | GitHub Actions run 44696614832 (job 136154773868), 2026-11-20 |

**Suite total (2026-11-20):** 77 tests, 77 passed, 0 failed (about 4 s).

One test failed on its first run because of an error in the test, not the engine: it expected b0→b2 to be rejected as `InvalidMovePattern`, but b2 holds Red's own Cannon in the opening position, so the engine's `OwnPieceAtTarget` was correct. The test now uses b0→b1.

## Not yet run

| Criterion | Reason |
|---|---|
| QG-07 repetition adjudication | Session layer not yet implemented (increment 2) |
| QG-08 save/load consistency | Session layer not yet implemented (increment 2) |
| QG-09 WXF and Chinese notation | Increment 2 |
| QA-01 to QA-05 (AI) | AI not yet implemented (increment 3) |
| Coverage measurement (document 11 §7) | Coverage tooling not yet added |
| All QP, QV, QH, QR criteria | Require the Unity project, assets or release builds |
