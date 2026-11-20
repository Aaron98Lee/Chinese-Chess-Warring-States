# 02 — Game Design Document (Initial Outline, v0.1)

| | |
|---|---|
| Document status | **Draft v0.1, outline for approval.** It will become GDD v1.0 at the end of Milestone 1 |
| Date | 2026-11-20 |
| Working title | **TBD.** Codename: *Warring States*. Candidate titles are listed in §14 |

---

## 1. Game concept

A premium, single-purchase Xiangqi game that plays by the exact traditional rules. It is presented as the last campaign of the Warring States world: the Han and Chu armies facing each other across the Hong Canal in 203 BCE. Each of the 32 pieces is a small, historically researched military formation that marches, wheels and yields on a living battlefield. The rules engine is authoritative; the presentation never changes the game.

**One-line pitch:** *Real Xiangqi, real history: command the armies of Han and Chu across the river that gave the board its name.*

## 2. Target audience

| Segment | Needs | Implication |
|---|---|---|
| Experienced Xiangqi players (Chinese-speaking, global diaspora, international clubs) | Correct rules, fast input, readable board, notation, strong AI, no gimmicks | Rules fidelity, Classic view, analysis view, notation support, low input friction |
| Strategy and board-game players new to Xiangqi | Learn the rules without friction | Interactive tutorial, legal-move hints, rule explanations on illegal attempts |
| History enthusiasts | Authenticity, context | Codex with evidence labels; accurate formations |
| Premium PC players | Visual quality, polish, 4K | High-end graphics profile, cinematic moments (skippable) |

Age target: 10+. Conflict is shown without gore (decision D10).

## 3. Design pillars

1. **The rules are sacred.** Exact traditional Xiangqi, configurable only where official rulesets differ, and always documented.
2. **Readable at a glance.** Formations never compromise clarity.
3. **History you can trust.** Evidence-led design; interpretations are labelled.
4. **Every move feels like an order.** Responsive input, weighty and short animations, sound that marks advance and withdrawal.

## 4. Core gameplay loop

```
Select formation ─► See legal moves (and why some are blocked)
      ▲                         │
      │                         ▼
Respond to the opponent ◄─ Issue order ─► Rules engine validates and applies
      │                                            │
      ▼                                            ▼
Check / threat feedback ◄────── Formation executes (animation, skippable)
      │
      ▼
Checkmate / stalemate (loss) / draw ─► Result ─► Review (replay, move list)
```

**Meta loop (proposed, minimal):** play → review → learn (tutorial and puzzles) → play. Codex entries unlock as you play. They are knowledge, not power: there are no gameplay unlocks and no microtransactions (decision D10).

## 5. Xiangqi rules specification

The rules engine implements the traditional rules below. **International chess rules are never substituted.** Where official rulesets differ, the difference is a named, documented ruleset option.

### 5.1 Board and coordinates

- 9 files × 10 ranks = 90 intersections; river between ranks 4 and 5; palaces on files d–f, ranks 0–2 (Red) and 7–9 (Black).
- Internal coordinates: file `a`–`i` (0–8), rank `0`–`9` from Red's side, as in ICCS notation.
- Displayed notations (§5.7): Chinese traditional, WXF and ICCS.

### 5.2 Initial position

FEN (letters as used by WXF and the common engine convention: R chariot, N horse, B elephant, A advisor, K general, C cannon, P soldier):

```
rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w - - 0 1
```

The parser also accepts the H (horse) / E (elephant) letter variant used by some sources, such as the Chess Programming Wiki perft page.

### 5.3 Piece movement

| Piece | Movement | Restrictions |
|---|---|---|
| General | One point orthogonally | Must stay in its palace |
| Advisor | One point diagonally | Must stay in its palace |
| Elephant | Exactly two points diagonally | Cannot cross the river; blocked if the intermediate (eye) point is occupied |
| Horse | One point orthogonally, then one point diagonally outward | Blocked if the orthogonal (leg) point is occupied |
| Chariot | Any number of points orthogonally | Cannot pass through pieces |
| Cannon | Moves like a chariot when not capturing | Captures only by jumping **exactly one** piece (the screen) of either colour along the line |
| Soldier | One point forward | After crossing the river, may also move one point sideways; never backward |

### 5.4 Legality and game end

- **Self-check is illegal.** A move that leaves one's own general attacked is rejected.
- **Flying General:** the two generals may never face each other on the same file with no piece between them. A move creating that position is illegal (equivalent to the general being attacked along the file).
- **Checkmate:** the side to move is in check and has no legal move → **loses**.
- **Stalemate:** the side to move is not in check and has no legal move → **loses** (困斃). *Unlike international chess, this is not a draw.*
- No castling, no en passant, no promotion, no double steps.

### 5.5 Repetition, perpetual check and chase

The engine detects repeated positions using Zobrist hashing. Adjudication depends on the selected ruleset:

| Ruleset ID | Behaviour | Status |
|---|---|---|
| `casual` | Threefold repetition → draw, without perpetual adjudication | Milestone 2 |
| `basic-asian` (default from Milestone 2) | Perpetual check by one side loses; other repetitions → draw; mutual perpetual check → draw | Milestone 2 |
| `wxf` | Full WXF repetition rules, including perpetual chase of unprotected pieces and the exemptions defined by WXF | Target Milestone 5; requires a dedicated test corpus |
| `cxa` | Chinese Xiangqi Association rules variant | Candidate; scope decision D9 |

Full chase adjudication is the most complex part of the rules and the most frequent source of disputes. It is scheduled after the core is proven, with test cases drawn from the official rulebook examples (risk R6).

### 5.6 Other draw conditions

| Condition | Default | Notes |
|---|---|---|
| Draw by agreement | Enabled (hotseat; vs AI optional) | — |
| Move-count limit without capture | Configurable | The default count comes from the chosen official rulebook and must be confirmed before Milestone 2 closes; do not assume chess's 50-move rule |
| Insufficient material | Configurable automatic draw when neither side has any attacking piece (chariot, horse, cannon, soldier) | Official rules treat this through adjudication; documented as an option |
| Time controls | None (MVP); per-move and Fischer increment later | — |

### 5.7 Notation and records

- **Chinese traditional:** for example 炮二平五, 馬8進7 (Red files in Chinese numerals, Black in Arabic numerals, counted from each player's right).
- **WXF:** for example `C2.5`, `H8+7` (operators `+` forward, `-` backward, `.` sideways; tandem pieces disambiguated per WXF).
- **ICCS:** for example `h2e2`, used internally for records.
- **Import/export:** FEN; game records (WXF/PGN-style text) in Milestone 5.

### 5.8 Undo, redo and replay

- Undo restores the exact previous state, including hash, repetition history and clocks.
- Undo policy is per mode: unlimited in casual and vs AI; disabled in rated or online play (future).
- Replay steps through the history in both directions, with jump-to-move.

## 6. Game modes

| Mode | Scope | Milestone |
|---|---|---|
| **Versus AI** | 6 difficulty levels; choose side; optional hints | MVP (M5); 3 levels in the vertical slice |
| **Local two-player (hotseat)** | Same device; optional board rotation | MVP |
| **Interactive tutorial** | Lessons per piece and rule, each introduced by its historical formation; checkmate patterns | MVP |
| **Rules and Codex** | Full rules reference; historical Codex with evidence labels (E1–E4 in player-friendly words) | MVP |
| **Replay and analysis** | Step through finished games; analysis view; export notation | MVP |
| Endgame puzzles (殘局) | Curated positions under standard rules | Post-MVP candidate |
| Historical scenario positions | Themed starting positions (standard rules, composed positions) | Post-MVP candidate |
| Online multiplayer | Ranked and casual, authoritative server | Post-MVP; needs a separate scope decision |
| Additional army sets | For example "Qin vs Zhao (Changping, 260 BCE)" or a Song-era set | Post-MVP candidate |

## 7. Piece identities and military formations

Specified in **document 06 (Piece Design Matrix)**. Summary: Han (Red) and Western Chu (Black); five-man squads as Soldiers; Qin-type and Chu-type chariots; traction trebuchets as Cannons; Han Chancellor (相) and Chu war elephant (象) as the Elephant pieces.

## 8. User interface and experience

### 8.1 Screen flow

```
Splash ► Main menu ─┬─► New game (mode, side, difficulty, ruleset) ► Board
                    ├─► Continue (last save)
                    ├─► Tutorial ► Lessons
                    ├─► Codex and Rules
                    ├─► Replays
                    ├─► Settings (graphics, audio, controls, accessibility, language)
                    └─► Quit
Board ► Pause menu (resume, restart, settings, save, resign, offer draw, quit) ► Result screen ► Review
```

### 8.2 In-game HUD (16:9 reference layout)

- **Centre:** the board, about 70% of screen height at the strategic zoom.
- **Left panel:** move list (switchable notation), undo/redo, replay controls.
- **Right panel:** turn indicator (army emblem plus text), captured pieces tray (glyph tokens), AI "thinking" indicator, clocks (when enabled).
- **Top:** check warning banner (text plus icon plus sound, never colour alone).
- **Contextual:** hover tooltip on any intersection explaining why a move is illegal: "Horse leg blocked by the Soldier at e3", "Elephants cannot cross the river", "This move would expose your general (flying general)", "Your general would be in check".
- Panels collapse for an unobstructed board.

### 8.3 Interaction

- **Mouse:** click a formation, then click the target. Drag-and-drop optional. Generous hit target: the nearest intersection within 0.5 P of the cursor, so no pixel-hunting on figures.
- **Keyboard:** cursor navigation across intersections; type moves in ICCS or WXF notation; shortcuts for undo, flip board, Classic view and analysis view.
- **Gamepad:** cursor snapping between intersections (PC controller support; required later for consoles).
- **Touch:** designed in from the start for a future tablet port (tap-tap; larger targets).

### 8.4 UI art direction

Lacquer panels (black ground, vermilion trim), bamboo-slip move list, seal-style emblems, restrained ink-wash transitions. Typography: a licensed CJK serif for headings (for example Source Han Serif / Noto Serif CJK under the SIL Open Font License) and a highly legible sans for body text, with full Simplified and Traditional Chinese glyph coverage. Custom calligraphic glyphs for the pieces are commissioned (licensing tracked).

## 9. Animation

Specified in document 06, §3. Player settings: animation speed (0.5×–2×), **instant moves**, reduced motion (no camera moves, simplified idles, no screen effects), skip cinematics.

## 10. Audio

| Layer | Direction | Evidence link |
|---|---|---|
| Music | Period instrument palette: bronze chime bells, chime stones, drums, zither (*qin* and *se*), mouth organ (*sheng*), vessel flute (*xun*). Adaptive intensity tied to material balance and check states | HR-34 |
| Command signals | Drum motif for moves and advances; metal bell or gong motif for withdrawal and undo | HR-33 |
| Formation SFX | Footsteps on loess, armour lacing and plates, chariot wheels, hooves, trebuchet creak and release, elephant calls, banner cloth | — |
| Ambience | Wind over loess, canal water, distant camp | — |
| Voice | None at launch, or non-verbal only. Avoids anachronistic modern Mandarin battle cries | — |

Audio middleware (FMOD/Wwise) versus engine-native audio is evaluated in Milestone 1. The default is engine-native, to avoid a dependency.

## 11. Accessibility

- Ownership readable without colour (four channels; document 05, §4). Colour-blind simulation is part of acceptance.
- Classic view (glyph discs) and glyph overlay.
- High-contrast board option.
- Text scaling 100–200%; UI scaling independent of resolution.
- Reduced motion, instant moves, no flashing effects (photosensitivity).
- Full keyboard play; notation input; remappable controls; mouse-only and one-handed play possible.
- Subtitles and captions for any voiced or significant audio cues.
- Hint system: legal moves and threats on demand.

## 12. Difficulty and AI

| Level | Name (working) | Intent | Time budget (min-spec target) |
|---|---|---|---|
| 1 | Recruit | Beginner; makes human-like mistakes | ≤ 0.5 s |
| 2 | Squad leader | Casual | ≤ 0.5 s |
| 3 | Officer | Club beginner | ≤ 1.5 s |
| 4 | Commander | Club player | ≤ 1.5 s |
| 5 | General | Strong amateur (claim only after benchmarking) | ≤ 5 s |
| 6 | Hegemon | Strongest setting; time-configurable | ≤ 5 s default |

Strength claims are made only after benchmarking (document 07, §11; document 11, QA-03). AI design is in document 07.

## 13. Platforms and performance

Proposed: **Windows PC (Steam) first, macOS second**, with tablet and console ports evaluated after launch. Performance targets by hardware tier are in documents 03 (§7) and 11 (§4). All are subject to decision D6.

## 14. Release scope, monetisation and naming (for approval)

- **MVP / 1.0:** versus AI, hotseat, tutorial, Codex, replay and analysis, both armies complete, Classic view, three languages (English, Simplified Chinese, Traditional Chinese).
- **Monetisation (proposed):** premium single purchase, no microtransactions. Possible paid army-set expansions later.
- **Candidate titles:** *Chu River, Han Border* (楚河漢界); *Xiangqi: The Hong Canal*; *Warring States Xiangqi*. A trademark search is needed before selection.

## 15. Future features (not approved scope)

Online multiplayer, puzzles, historical scenarios, additional army sets, player profiles and statistics, achievements, spectator mode, tablet port, console ports, a Song-era army set to accompany the history of the game itself.

## 16. Open design questions

1. Board rotation in hotseat: rotate, or fixed with an indicator?
2. Should the AI offer and accept draws?
3. Codex unlocks: unlocked by play, or all open from the start?
4. Does the after-river "skirmish line" state for Soldiers aid comprehension or add noise? To be tested in the slice.
5. Default notation per locale: Chinese for zh locales, WXF for en?
