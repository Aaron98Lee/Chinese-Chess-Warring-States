# Xiangqi.Core

The authoritative Xiangqi rules engine. Engine-independent: no Unity references, no I/O, no wall-clock
time, no randomness. Targets .NET Standard 2.1 with C# 9 so the same sources compile in Unity
(`Xiangqi.Core.asmdef` sets `noEngineReferences: true`) and in plain .NET for headless testing.

## What it implements

| Rule | Where |
|---|---|
| Board, coordinates (ICCS: files a–i, ranks 0–9 from Red), initial position | `Primitives.cs`, `Position.cs` |
| General and Advisor palace restrictions | `BoardGeometry.cs`, `Position.Legality.cs` |
| Elephant: two points diagonally, river restriction, eye blocking | same |
| Horse: leg blocking | same |
| Chariot: obstruction | same |
| Cannon: moves like a Chariot; captures over exactly one screen | same |
| Soldier: forward; sideways after the river; never backward | same |
| No move may leave one's own General in check | `Position.cs` (`IsSafeAfter`, `Check`) |
| Flying-General rule (Generals may not face on an open file) | `Position.cs`, `Position.Legality.cs` |
| Checkmate and **stalemate both lose** for the side to move | `Position.Status()`, `Position.Winner()` |
| FEN parsing (WXF letters, plus H/E variants) with position validation; FEN output | `Position.Fen.cs` |
| Zobrist hashing (fixed seed, platform-independent) | `Zobrist.cs` |
| Exact undo, stable piece identities (0–31) for the presentation layer | `Position.cs`, `UndoRecord` |
| Perft and divide | `Perft.cs` |

History-dependent rules (repetition, perpetual check and chase, move limits, agreed draws) belong to
the session layer (`Xiangqi.Session`, next increment), which owns the game history.

## Key API

```csharp
var p = Position.Initial();                       // or Position.FromFen(fen)
IReadOnlyList<Move> moves = p.LegalMoves();
MoveCheck check = p.Check(Move.Parse("b0b1"));    // IsLegal == false, Reason == InvalidMovePattern
UndoRecord undo = p.Make(Move.Parse("h2e2"));     // throws on illegal moves, with the reason
p.Unmake(undo);                                   // exact restore, including hash and counters
PositionStatus status = p.Status();               // Ongoing, Checkmate or Stalemate
```

`MoveCheck.Reason` and `MoveCheck.RelatedSquare` let the UI explain an illegal move
("Horse leg blocked by the piece on b1") without reimplementing any rule.

## Verification

See `docs/testing/test-register.md` for executed results. Summary of the test suite:
per-rule positive and negative cases with exact reasons, perft against published reference values,
1,000,000 make/unmake round trips with hash verification, full `Check` vs `LegalMoves` agreement over
thousands of positions, FEN round-trips, determinism, and an external cross-check against an
independent engine.

## Developer CLI

```bash
dotnet run --project src/Xiangqi.Tools.Cli -c Release -- perft 5
dotnet run --project src/Xiangqi.Tools.Cli -c Release -- divide 2 "<fen>"
dotnet run --project src/Xiangqi.Tools.Cli -c Release -- fen "<fen>"
```
