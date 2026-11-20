# 08 — Vertical Slice Specification (Milestone 3)

| | |
|---|---|
| Document status | **Draft v0.1, submitted for approval (decision D8)** |
| Date | 2026-11-20 |
| Prerequisites | Milestone 1 approvals (setting, art direction, engine spike pass); Milestone 2 rules engine complete |

---

## 1. Purpose

Prove, with one shippable-quality slice of the game, that:

1. The **visual direction** works: formations are historically credible, attractive and readable from the gameplay camera.
2. The **technical pipeline** works end to end: concept → model → texture → rig → animation → engine → formation assembly → gameplay, all within budget.
3. **Gameplay correctness survives presentation**: the authoritative rules engine drives everything, and animation never changes the game.
4. **Performance targets are achievable** on the agreed hardware tiers.

The slice is a **go/no-go gate** for full army production (Milestone 4), which is the most expensive phase of the project.

## 2. Representative formation: recommendation

**Recommended: the Chariot (俥 / 車), produced for both armies.**

| Criterion | Chariot | Soldier (alternative) |
|---|---|---|
| Exercises human characters | ✔ 3 crew | ✔ 5 infantry |
| Exercises horses (quadruped rig, locomotion) | ✔ 4 horses | ✗ |
| Exercises a vehicle (wheels, pole, harness) | ✔ | ✗ |
| Exercises the hardest footprint fit | ✔ (worst case) | ✗ (easy case) |
| Exercises long moves (up to 9 points) and timing curves | ✔ | ✗ (single steps) |
| Exercises the modular variation system | Partial | ✔✔ |
| Strength of historical evidence | Very strong (Qin bronze chariots, pit chariots) | Very strong |
| Production risk inside the slice | Higher | Lower |

The Chariot retires the most production and technical risk before committing to the full army: horses, vehicles, footprint compression and long-move choreography. Horse and Chariot rigs are later reused by the Horse formation. **Alternative:** the Soldier squad is lower risk and better tests the variation system, but leaves horse, vehicle and footprint risk for Milestone 4.

**Both armies:** the Han and Chu Chariots are both produced, so the slice validates ownership distinction (document 05, §4) and the faction kits.

## 3. Scope

### 3.1 In scope: finished quality

| Area | Content |
|---|---|
| Board and environment | Complete battlefield: board surface and lines, Hong Canal river with inscription markers, both palaces, embankments, near strongholds, far backdrop, lighting (default late-afternoon preset), ambient motion |
| Formations | **Chariot: Han and Chu**, complete with LODs, full and reduced density, all animations in document 06 §3 |
| Other 30 pieces | **Classic-view lacquered disc tokens** with calligraphic glyphs. These are finished assets (the Classic view is a shipping feature, document 05 §7), not placeholders |
| Bases | Final base designs for both armies, including glyph rendering and indicator rims |
| Gameplay | Full Xiangqi rules (Milestone 2 engine), `basic-asian` ruleset; versus AI (3 levels) and hotseat |
| Interaction | Mouse selection and targets with generous picking; keyboard move entry (ICCS/WXF); legal-move indicators; illegal-move reasons; last-move marker; check and flying-general explanations |
| Animation | Chariot idle, selected, move (short, medium, long), capture attack, captured, gives check, victory/defeat; disc-token move, capture and check animations; speed setting and instant mode |
| Camera | Gameplay camera with pitch and zoom presets, limited orbit; analysis (top-down) view |
| UI | Minimal main menu (New game, Settings, Quit); in-game HUD (turn, move list with notation toggle, undo/redo, captured tray, AI thinking indicator); pause menu; result screen; settings (graphics profile, resolution, audio volumes, animation speed, reduced motion, language) |
| Audio | Drum and bell command signals; Chariot SFX; capture, check and result stingers; one ambient bed; one music cue (placeholder-free, licensed or commissioned) |
| Localisation | English and Simplified Chinese (Traditional Chinese text pass if time allows) |
| Performance | Measured on all agreed hardware tiers (document 03 §7); profiling report |

### 3.2 Out of scope (explicitly)

- The other six formation types (they appear as finished Classic tokens).
- Tutorial, Codex, replay browser, puzzles, online play.
- Save/load UI (the engine-level save format and tests **are** in scope from Milestone 2).
- Full WXF chase adjudication (`basic-asian` is used).
- Platform store integration (Steam SDK), achievements.
- Console and tablet builds.

### 3.3 Mixed display rule

During the slice, formations and tokens share the board. To keep the comparison fair, the tokens use the same base diameter, glyph style and indicator rims as the formation bases. The Classic-view toggle switches the Chariots to tokens as well.

## 4. Content list (asset deliverables)

| ID | Asset | Notes | Budget (LOD0) |
|---|---|---|---|
| VS-A01 | Han charioteer (long armour, arm and hand guards) | Shared human skeleton | ≤ 30k tris (principal) |
| VS-A02 | Han chariot archer or commander | | ≤ 15k |
| VS-A03 | Han chariot halberdier | | ≤ 15k |
| VS-A04 | Chu charioteer | Chu lacquer armour kit | ≤ 30k |
| VS-A05 | Chu archer | | ≤ 15k |
| VS-A06 | Chu halberdier (multi-blade halberd) | | ≤ 15k |
| VS-A07 | Draught horse (shared skeleton) plus Han and Chu harness variants | Cropped mane, tied tail, no stirrups or horseshoes | ≤ 20k each |
| VS-A08 | Han chariot (Qin type) | Wheels animate | ≤ 30k |
| VS-A09 | Chu chariot (Chu fittings, lacquer) | | ≤ 30k |
| VS-A10 | Bases and glyph set (14 glyphs × 2 armies) | Custom calligraphy, licensed | — |
| VS-A11 | Classic disc tokens (shared mesh, 14 glyph materials) | Final quality | ≤ 2k |
| VS-A12 | Board surface, lines, river, palaces | 4K hero textures allowed | — |
| VS-A13 | Environment: embankments, strongholds, far terrain, backdrop | | — |
| VS-A14 | Animation set: humans (crew), horses (team), chariot | See document 06 §3 | — |
| VS-A15 | VFX: wheel dust, capture dust-fade, check pulse | | — |
| VS-A16 | UI kit: lacquer panels, emblems, icons, fonts | OFL or licensed fonts | — |
| VS-A17 | Audio set | Licensed or commissioned | — |

Each asset needs: a concept sheet approved by the historian, register IDs, metadata (author, licence, tools) and a passing validation report.

## 5. Quality bar ("finished" means)

- No placeholder art, audio or text in the slice. Classic tokens are finished assets, not placeholders.
- Historian sign-off on both Chariot formations, against the register.
- Passes the readability protocol (document 11, QV-01 to QV-06).
- No clipping between crew, chariot and horses in any animation at review speed or at 2×.
- Stable lighting with no visible artefacts (shadow acne, light leaks, shimmer) at 1080p, 1440p and 4K.
- UI fully functional with mouse and keyboard; consistent styling; no truncated text in English or Simplified Chinese.

## 6. Acceptance tests for the slice

| ID | Test | Pass criterion |
|---|---|---|
| VS-T01 | Rules suite (Milestone 2) runs in CI and in the Unity Test Runner | 100% pass |
| VS-T02 | State and visual agreement: scripted 500-game self-play with random skips, undos and speed changes | After every event, every formation and token is at the square given by `Core`. 0 mismatches |
| VS-T03 | Chariot footprint | Within 0.45 P in all static poses (automated bounds check) |
| VS-T04 | Long-move choreography | Chariot moves of 1–9 points complete in 0.6–1.4 s at 1×; no overlap with other footprints (automated) |
| VS-T05 | Responsiveness | Selection highlight on the next rendered frame; move animation starts ≤ 100 ms after a valid command (instrumented) |
| VS-T06 | Readability (human test) | ≥ 95% correct piece type and ≥ 99% correct owner for the Chariot formations within 2 s, including greyscale and colour-blind simulations (n ≥ 12 participants) |
| VS-T07 | Performance | Meets the document 11 §4 targets on each agreed tier at the specified resolution and profile |
| VS-T08 | AI | 3 levels; no illegal moves in 10,000 self-play games; response within level budgets |
| VS-T09 | Accessibility basics | Ownership readable without colour; instant moves; reduced motion; keyboard play end to end |
| VS-T10 | Build reproducibility | Clean CI build from a tagged commit yields a runnable Windows build; build log archived |

## 7. Deliverables at the slice gate

1. Playable Windows build (plus a macOS build if D6 includes macOS for the slice).
2. Slice review video (gameplay camera, plus a close-up showcase, clearly labelled).
3. Test register with actual results and evidence (document 11, §7).
4. Performance report per hardware tier (frame-time distributions, memory, draw calls, CPU animation cost).
5. Historian review report on both Chariot formations.
6. Production metrics: actual hours per asset type against estimates, used to re-plan Milestone 4 cost and schedule.
7. Updated risk register and a Milestone 4 recommendation (go, go with changes, or no-go).

## 8. Review protocol

- **Internal review** at 50% and 90% of the slice schedule (art lock and feature lock).
- **Gate review** with you: play session, evidence pack, decision.
- **Readability sessions** with players outside the team (mixed Xiangqi experience).

## 9. Slice-specific risks

| Risk | Mitigation |
|---|---|
| Chariot footprint cannot meet 0.45 P at the agreed figure scale | Resolve in the Milestone 1 greybox *before* modelling; fallback: two-horse team (also historically attested) |
| Horse locomotion quality | Licensed horse motion capture or a specialist animator; early animation blockout review |
| Slice overruns from scope creep | Strict in/out list (§3); changes go through change control |
| Mixed tokens and formations feel inconsistent | Shared base, glyph and indicator language (§3.3); evaluated in review |
