# 10 — Risks, Assumptions and Decisions

| | |
|---|---|
| Document status | **v0.2: decision log updated with your answers of 2026-11-20** |
| Date | 2026-11-20 |

---

## 1. Decision log

**Status key:** ✅ Approved · 🔁 Approved with change (your choice differs from the original recommendation) · ❓ Pending · 🆕 New decision arising from your answers.

| ID | Decision | Status | Outcome / recommendation |
|---|---|---|---|
| **D1** | Historical setting | 🔁 | **Warring States, 475–221 BCE. Each player, human or computer, chooses one of seven states: Qin 秦, Chu 楚, Zhao 趙, Yan 燕, Qi 齊, Wei 魏, Han 韓.** State choice never changes the rules |
| **D2** | Side colours | 🔁 | **A dedicated colour for each state**, using *Qin Dynasty Epic* (大秦賦, 2020) as the art-direction reference. Provisional palette in document 05 §5.1. The drama is used as an art reference and pointer to evidence, not as historical evidence, and its designs are not copied (document 04 §1.3) |
| **D3** | Elephant / Minister piece | 🔁 | **Strategist for every state.** Proposed in-world name **軍師 / 謀士**, because **參軍 is a late Eastern Han title** (document 04 §4.7). Confirm the naming |
| **D4** | Cannon piece | 🔁 | **Crossbow unit (弩兵)**, the best-evidenced troop type of the period |
| **D5** | Engine | ✅ | Unity 6 LTS + URP, confirmed by the Milestone 1 spike |
| **D6** | Platforms | 🔁 | **Windows only for now** (Steam). macOS and others deferred |
| **D7** | Visual approach and camera | ✅ | Stylised realism, real-time 3D, fixed elevated camera, Classic view |
| **D8** | Vertical-slice formation | ❓ **Clarification provided below (§1.1)** | Recommendation: **D8a Chariot; D8b Qin vs Chu** |
| **D9** | Ruleset baseline | ✅ | `basic-asian` in Milestone 2; full WXF repetition rules by Milestone 5 |
| **D10** | MVP scope, rating, monetisation | ✅ | Vs AI (6 levels), hotseat, tutorial, Codex, replay and analysis, Classic view; EN, zh-Hans, zh-Hant; premium purchase; no gore |
| **D11** | Generative-AI policy | 🔁 | **Permitted for concept exploration only, for now.** Internal use; prompts and outputs logged; never shipped; final assets human-made unless you separately approve otherwise. Steam disclosure reviewed before release |
| **D12** | Production model | ✅ | Small core team plus outsourced art, animation and audio; part-time historian |
| **D13** | Source-art storage | ✅ | Git LFS for runtime assets; separate storage for large source files |
| **D14** | Working title | ✅ | Deferred; codename *Warring States* |
| **D15** | Visual snapshot date | 🆕 ❓ | **Recommend late Warring States, c. 300–230 BCE** (centred on Changping, 260 BCE). Cavalry, needed for the Horse piece, only spreads after about 307 BCE, and all seven states coexist only before 230 BCE (document 04 §2.2) |
| **D16** | Same-state matches (e.g. Qin vs Qin) | 🆕 ❓ | **Recommend allowing them**, with the second player using the state's alternate palette. Ownership stays clear through the turn-role base band and glyphs (document 05 §4) |
| **D17** | Glyphs and first move | 🆕 ❓ | **Recommend traditional glyph sets by turn role** (first player 帥 仕 相 俥 傌 炮 兵; second player 將 士 象 車 馬 砲 卒), whichever states are chosen. Who moves first: chosen in the new-game screen (player choice or random) |
| **D18** | MVP battlefield and river inscription | 🆕 ❓ | **Recommend the Dan River valley at Changping (260 BCE)**, neutral to the chosen states. Keep the traditional **楚河 漢界** on the river markers as the board's convention, explained in the Codex, with an option to show the river's name (丹水) |

### 1.1 Clarifying D8: what "vertical-slice formation" means

The **vertical slice** (Milestone 3) is a small but **finished-quality** playable demo, built before committing money to the full art library. It contains:

- the complete, finished battlefield;
- the full Xiangqi rules, AI and polished interface;
- **only one piece type built as finished 3D formations.** All other pieces appear as finished "Classic" glyph discs, which are a real feature of the final game.

**D8 asks which piece type to build first, to that finished standard.** It is a production-risk decision, not a design change. All seven piece types will be built afterwards for all seven states. With seven states, D8 now has two parts:

| Part | Question | Recommendation | Why |
|---|---|---|---|
| **D8a** | Which piece type is built first, to finished quality? | **Chariot** | Hardest to build: humans, horses and a vehicle, the tightest space on the board, and the longest moves. If it works, the rest is lower risk. The **Soldier** squad is the lower-risk alternative, but it leaves horse and vehicle problems for later |
| **D8b** | Which two states does the slice show? | **Qin vs Chu** | Best historical evidence, and the strongest visual contrast (black riveted plates against vermilion and black lacquer). It also proves the state identity system on the two richest kits. Alternative: Qin vs Zhao, which matches the Changping battlefield |

Answering **"D8a Chariot, D8b Qin vs Chu"**, or your alternatives, is all that is needed.

## 2. Risk register

L = likelihood, I = impact (High / Medium / Low).

| ID | Risk | L | I | Mitigation | Owner |
|---|---|---|---|---|---|
| R1 | **Art scope and cost, raised by D1: 7 piece types × 7 states = 49 formation variants** (was 14) | H | H | Shared base kit plus state identity layers (document 05 §6.5); slice measures real rates before Milestone 4; production staged by state with the strongest evidence first; reduced-density tier | Producer, Art lead |
| R2 | Historical evidence gaps | M | M | Improved: elephant and trebuchet removed (D3, D4). Remaining gaps are mostly per-state kit details (see R18) | Research lead |
| R3 | Readability vs detail at the gameplay camera | M | H | Milestone 1 greybox test; silhouette and height tiers; turn-role band; Classic view | Art director, UX |
| R4 | Footprint and scale (Chariot within 0.45 P) | M | M | Reduced: only the Chariot is large now. Greybox resolution; two-horse fallback | Tech art |
| R5 | Engine licensing or pricing change | L | M | Engine-independent C# core; Godot fallback | Tech lead |
| R6 | Perpetual chase rule complexity | H | M | Staged rulesets; official examples as tests | Rules specialist |
| R7 | AI strength expectations | M | M | Benchmark before any claim | AI engineer |
| R8 | Performance on minimum spec (about 130 animated humans + 28 horses) | M | M | Spike measurement; animation LOD; density tiers | Graphics engineer |
| R9 | Reference image rights | H | L–M | Internal-only reference policy | Art lead |
| R10 | Generative-AI provenance | M | M | D11: concept-only, logged, never shipped | Producer |
| R11 | Cultural reception by Chinese-speaking audiences | M | H | Historian; native-speaker localisation; alignment with familiar screen conventions (D2) | Director |
| R12 | Market access (mainland China approval; ratings) | M | M | China a separate later decision; IARC ratings | Producer |
| R13 | No GPU or Unity in the cloud environment | H | M | Logic headless-testable (being built now); workstation and GPU CI runner | Tech lead |
| R14 | Decision latency | M | M | Decision log with "needed by" dates | Producer |
| R15 | Repository growth from binary assets | M | L | D13; asset validation | Tech lead |
| R16 | Outsourcing vendor quality variance | M | H | Paid test asset; style guide and validators | Art lead |
| R17 | Font and glyph licensing (CJK, calligraphic glyphs, regional-script emblems) | M | M | OFL UI fonts; commissioned glyphs and emblems with full rights | UI lead |
| R18 | **Evidence imbalance across states**: Qin and Chu rich; Zhao, Yan, Qi, Wei, Han rely on texts and scattered finds | H | M | Signature traits drawn from the strongest evidence for each state; E3 elements labelled; historian review per state; produce the five less-documented states after Qin and Chu | Research lead |
| R19 | **Screen-reference misuse**: copying copyrighted designs from *Qin Dynasty Epic*, or importing its departures from the evidence | M | M | Policy in document 04 §1.3; every borrowed look traced to an artefact; art review | Art director |
| R20 | **Colour distinguishability across 28 pairings**, including under colour-vision deficiency | H | M | Ownership never depends on colour (turn-role band, glyphs, orientation); QV-03 tests all pairings | UX lead |

## 3. Assumptions

| ID | Assumption | If wrong |
|---|---|---|
| A1 | Premium, paid PC title with a professional-quality bar | Re-scope |
| A2 | Small core team plus outsourcing; you are producer and final approver | Re-plan capacity |
| A3 | Launch languages: English, Simplified Chinese, Traditional Chinese | Adjust localisation |
| A4 | No online multiplayer at launch | Adds large scope |
| A5 | **Windows only** for launch (D6) | Re-plan platform work |
| A6 | Budget supports outsourced art for **seven states** at the specified quality (estimated in M1) | Reduce variants per state or density |
| A7 | Claude Code covers engineering, tools, tests and documentation; human artists produce final 3D, animation and audio | Re-plan the art pipeline |
| A8 | WXF-based adjudication is acceptable to the audience | Add CXA ruleset |
| A9 | A historian and a palaeography consultant can be engaged in M1 | Authenticity gate cannot be signed off |
| A10 | **All seven states are in the 1.0 release** (D1) | Staged release plan |

## 4. Change control

After approval, changes to the historical setting, art direction, engine, architecture, scope or monetisation require a written change request covering the change, its reason, and its impact on schedule, cost, quality and risk. It is recorded as an ADR or a decision-log entry before work proceeds.
