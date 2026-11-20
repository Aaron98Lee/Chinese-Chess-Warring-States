# 01 — Executive Project Proposal

| | |
|---|---|
| Project | Historical Chinese Chess (Xiangqi). Codename *Warring States*; title TBD |
| Document status | **Draft v0.1, pre-production proposal submitted for approval** |
| Date | 2026-11-20 |
| Prepared by | Game Director and Technical Lead (pre-production team) |
| Implementation status | **Not started**, by design. No code, assets or tests exist yet. This package asks for approval to begin Milestones 1 and 2 |

---

## 1. Vision

A premium Xiangqi game that plays by the **exact traditional rules**, in which each of the 32 pieces is a **small, historically researched military formation**: a five-man infantry squad, a four-horse chariot with its crew, a traction trebuchet and its pullers, a commander under his great banner. The setting is the war the board itself commemorates: **Han against Chu across the Hong Canal (楚河漢界), 203 BCE**, the closing campaign of the Warring States world.

The rules engine is authoritative and independently tested. History is evidence-led and openly labelled. Presentation serves readability first and spectacle second.

## 2. What makes it different

1. **The board's own story.** The river inscription names this war. Our setting, armies and battlefield all follow from it.
2. **Formations, not figurines.** Each piece is a disciplined unit with a clear primary subject, built from a modular kit, as the Qin workshops built the Terracotta Army.
3. **History you can trust.** Every identity-critical design element traces to a reference register that separates evidence from interpretation. An in-game Codex shares that research with players.
4. **Uncompromised Xiangqi.** Exact rules, including stalemate counted as a loss, the flying-general rule, and perpetual-check adjudication. Fast input, notation support, a Classic glyph view, and an AI whose strength is benchmarked, not asserted.

## 3. Recommendations at a glance

| Area | Recommendation | Detail |
|---|---|---|
| Historical setting | Chu–Han Contention (206–202 BCE), Hong Canal front, on late Warring States and Qin material culture | Doc 04 §3 |
| Sides | Red = Han (textual support); Black = Western Chu (declared convention) | Doc 04 §3.3 |
| Elephant / Minister | Han 相 = Chancellor's office (Xiao He archetype); Chu 象 = war elephant (labelled interpretation) | Doc 04 §4.9, doc 06 |
| Cannon | Traction trebuchet (no gunpowder) for both sides | Doc 04 §4.8 |
| Engine | Unity 6 LTS + URP; C#; confirmed by a 2-week spike; Godot fallback | Doc 03 |
| Platforms | Windows (Steam) first, macOS second; ports evaluated later | Doc 03 §7 |
| Visual approach | Stylised realism in real-time 3D; fixed elevated camera; Classic glyph view | Doc 05 |
| Architecture | Engine-independent C# rules, session and AI libraries; event-driven presentation; validate-then-animate | Doc 07 |
| Vertical slice | Finished board + full mechanics + **Chariot formation for both armies** + polished UI | Doc 08 |
| MVP scope | Vs AI (6 levels), hotseat, tutorial, Codex, replay and analysis; EN, zh-Hans, zh-Hant | Doc 02 §6, §14 |
| Ruleset | `basic-asian` adjudication first; full WXF repetition rules by Milestone 5 | Doc 02 §5 |

## 4. Plan summary

| Milestone | Outcome | Indicative duration |
|---|---|---|
| M1 Concept and Research | Setting, art direction and engine locked; concept art; GDD and TDD v1.0 | 6–8 weeks |
| M2 Rules Prototype (parallel with M1) | Complete, tested rules engine; test AI; CLI | 4–6 weeks |
| M3 Vertical Slice | One finished formation type for both armies on a finished board; go/no-go | 12–16 weeks |
| M4 Complete Army | All 7 pieces × 2 armies | 6–9 months |
| M5 Complete Gameplay (parallel with M4) | All modes, AI levels, save/load, tutorial, localisation | ≈ 5–6 months |
| M6 Polish and Optimisation | Beta | 3 months |
| M7 Release Preparation | Release | 6–8 weeks |

**Indicative total: about 18–22 months from M1 start**, re-baselined at the M1 and M3 gates with measured production rates (doc 09).

## 5. Team and responsibilities (proposed)

- **You:** producer and final approver for direction, history, engine, scope and budget.
- **This pre-production and engineering team (Claude Code):** architecture, rules engine, AI, tools, tests, CI, technical art scripts, documentation, asset specifications and validation.
- **Human specialists (to engage):** historian (review and sign-off), concept artist, character, creature and vehicle artists, animator, environment artist, technical artist, UI artist, audio composer and sound designer, QA.

Stated plainly: production-quality 3D characters, horses, the elephant, textures, animation and music **cannot be produced by this team alone**. They require human artists or tools you approve (decisions D11, D12).

## 6. Top risks

1. **Art production cost and scope** (R1). Mitigated by measuring real rates in the vertical slice before committing to the full army.
2. **Historical evidence gaps** (R2), especially Chu dress, the elephant and the trebuchet. Mitigated by labelled interpretations and historian sign-off.
3. **Readability vs detail** (R3, R4). Mitigated by a greybox readability test in Milestone 1, before any final modelling.
4. **Rules adjudication complexity** (R6). Mitigated by staging rulesets and testing against official examples.

Full register: document 10.

## 7. Approval requested

1. Approve, amend or reject decisions **D1–D14** (document 10 §1).
2. Authorise **Milestone 2 (rules engine)** to start immediately. It is independent of the art and engine decisions and can be built and verified in this environment.
3. Authorise **Milestone 1 activities**: historian engagement, concept-art briefs, engine spike and greybox readability test.

No full implementation will begin until you have reviewed and approved this direction.

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
