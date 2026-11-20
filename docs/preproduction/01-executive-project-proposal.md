# 01 — Executive Project Proposal

| | |
|---|---|
| Project | Historical Chinese Chess (Xiangqi). Codename *Warring States*; title TBD |
| Document status | **v0.2: direction approved with changes (2026-11-20).** Remaining decisions: D8, D15–D18 |
| Date | 2026-11-20 |
| Prepared by | Game Director and Technical Lead |
| Implementation status | **Milestone 2 (rules engine) started 2026-11-20.** No art assets exist yet |

---

## 1. Vision

A premium Xiangqi game that plays by the **exact traditional rules**, set in the **Warring States period**. Each player, human or computer, leads one of the **seven states**: Qin 秦, Chu 楚, Zhao 趙, Yan 燕, Qi 齊, Wei 魏 or Han 韓. Each of the 32 pieces is a **small, historically researched military formation** in its state's armour, weapons and colours: a five-man infantry squad, a four-horse chariot, a crossbow unit under its signal pennant, a strategist with his map board, a commander under the great banner.

The rules engine is authoritative and independently tested. State choice and presentation never change the game. History is evidence-led and openly labelled.

## 2. What makes it different

1. **Seven armies, one game.** Choose your state; see its army on the board, built from a shared Warring States kit with a distinct identity layer for each state.
2. **Formations, not figurines.** Each piece is a disciplined unit with a clear primary subject, built modularly, as the Qin workshops built the Terracotta Army.
3. **History you can trust.** Every identity-critical element traces to a reference register that separates evidence from interpretation. The in-game Codex shares that research.
4. **Uncompromised Xiangqi.** Exact rules, including stalemate counted as a loss, the flying-general rule and perpetual-check adjudication. Fast input, notation, a Classic glyph view and a benchmarked AI.

## 3. Direction at a glance

| Area | Direction | Status | Detail |
|---|---|---|---|
| Setting | Warring States (475–221 BCE); seven selectable states | ✅ D1 | Doc 04 |
| Visual snapshot | Late Warring States, c. 300–230 BCE | ❓ D15 | Doc 04 §2.2 |
| Colours | One colour per state; *Qin Dynasty Epic* as art reference | ✅ D2 | Doc 04 §1.3, §3.3; doc 05 §5 |
| Elephant / Minister piece | **Strategist (軍師 / 謀士)** for every state | ✅ D3 (naming to confirm) | Doc 04 §4.7; doc 06 §3.3 |
| Cannon piece | **Crossbow unit (弩兵)** | ✅ D4 | Doc 04 §4.6; doc 06 §3.6 |
| Engine | Unity 6 LTS + URP; C#; confirmed by spike | ✅ D5 | Doc 03 |
| Platform | Windows (Steam) only for now | ✅ D6 | Doc 03 §7 |
| Visual approach | Stylised realism, real-time 3D, fixed elevated camera, Classic view | ✅ D7 | Doc 05 |
| Vertical slice | Chariot (D8a) for Qin vs Chu (D8b) | ❓ D8 | Doc 08; doc 10 §1.1 |
| Ruleset | `basic-asian` first; WXF by Milestone 5 | ✅ D9 | Doc 02 §5 |
| MVP scope | Vs AI (6 levels), hotseat, tutorial, Codex, replay and analysis; all seven states; EN, zh-Hans, zh-Hant | ✅ D10 | Doc 02 §6, §14 |
| Generative AI | Concept exploration only, for now | ✅ D11 | Doc 10 |
| Production model | Core team plus outsourced art, animation and audio | ✅ D12 | Doc 09 §4 |
| Same-state matches; glyphs and first move; battlefield and river inscription | Proposals | ❓ D16–D18 | Doc 10 |

## 4. Plan summary

| Milestone | Outcome | Indicative duration |
|---|---|---|
| M1 Concept and Research | Art direction for seven states; concept art; engine spike; GDD and TDD v1.0 | 8–10 weeks |
| M2 Rules Prototype (**started**) | Complete, tested rules engine; test AI; CLI | 4–6 weeks |
| M3 Vertical Slice | One finished formation type for two states on a finished board; go/no-go | 12–16 weeks |
| M4 Complete Army | 7 piece types × 7 states (49 variants) from a shared kit | 9–12 months |
| M5 Complete Gameplay (parallel with M4) | All modes, state selection, AI, save/load, tutorial, localisation | ≈ 6 months |
| M6 Polish and Optimisation | Beta | 3 months |
| M7 Release Preparation | Release (Windows) | 6–8 weeks |

**Indicative total: about 21–26 months from M1 start** (was 18–22 before the seven-state decision). The schedule is re-baselined with measured production rates at the M1 and M3 gates (doc 09).

## 5. Impact of the seven-state decision (for awareness)

- **Art scope:** 49 formation variants instead of 14. Managed by one shared kit plus seven identity layers, not 49 separate designs. Indicative art effort rises by roughly 40–60% rather than 3.5×; total project effort is about 115–180 person-months (doc 09 §4).
- **Evidence:** Qin and Chu are richly documented; Zhao, Yan, Qi, Wei and Han rely more on texts and scattered finds, so their kits carry more labelled interpretation (risk R18).
- **Readability:** with 28 possible pairings, ownership is guaranteed by a turn-role base band and the traditional glyphs, never by state colour alone (doc 05 §4).
- **Historical improvement:** the strategist and the crossbow unit are better evidenced than the elephant and trebuchet they replace.

## 6. Team and responsibilities

- **You:** producer and final approver.
- **Engineering, tools, tests, documentation (Claude Code):** architecture, rules engine (in progress), AI, CI, technical art scripts, asset specifications and validation.
- **Human specialists to engage:** historian, palaeography consultant (regional-script state emblems), concept artist, character and vehicle artists, animator, environment artist, technical artist, UI artist, composer and sound designer, QA.

Production-quality 3D characters, horses, textures, animation and music **cannot be produced by this team alone**.

## 7. Top risks

1. **Art scope and cost** (R1), now higher with seven states. Mitigated by the shared kit and by measuring real rates in the slice.
2. **Evidence imbalance across states** (R18). Mitigated by signature traits drawn from each state's strongest evidence, labelled interpretation and historian review.
3. **Readability across 28 pairings** (R3, R20). Mitigated by turn-role bands, glyphs and the M1 greybox test.
4. **Rules adjudication complexity** (R6). Mitigated by staged rulesets and official examples as tests.

## 8. Package contents

| # | Document |
|---|---|
| 01 | Executive project proposal (this document) |
| 02 | [Game Design Document outline](02-game-design-document-outline.md) |
| 03 | [Technology and platform decision report](03-technology-selection-report.md) |
| 04 | [Historical research and reference register](04-historical-research-and-reference-register.md) |
| 05 | [Proposed visual direction](05-visual-direction.md) |
| 06 | [Xiangqi piece design matrix](06-piece-design-matrix.md) |
| 07 | [Target architecture](07-target-architecture.md) |
| 08 | [Vertical-slice specification](08-vertical-slice-specification.md) |
| 09 | [Development roadmap](09-development-roadmap.md) |
| 10 | [Risks, assumptions and decisions](10-risks-assumptions-and-decisions.md) |
| 11 | [Quality standards and acceptance criteria](11-quality-standards-and-acceptance-criteria.md) |
