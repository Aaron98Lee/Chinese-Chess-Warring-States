# 10 — Risks, Assumptions and Decisions Requiring Approval

| | |
|---|---|
| Document status | **Draft v0.1. This is the approval checklist for the pre-production package** |
| Date | 2026-11-20 |

---

## 1. Decisions requiring your approval

Each decision lists the recommendation, the main alternatives, and what is blocked until it is made. Reply with the decision ID and your choice (e.g. "D1: approve", "D3: use the alternative").

| ID | Decision | Recommendation | Alternatives | Blocks | Needed by |
|---|---|---|---|---|---|
| **D1** | Historical setting | **Chu–Han Contention, 206–202 BCE** (Hong Canal front), on late Warring States and Qin material culture (document 04 §3) | B: Late Warring States, Qin vs Chu (c. 230–223 BCE). F: Song-era setting | All concept art | Start of M1 |
| **D2** | Side assignment | **Red = Han, Black = Western Chu** (Red has textual support; Black is a declared convention) | Swap (conflicts with the traditional glyph mapping in D3) | Concept art, UI colours | Start of M1 |
| **D3** | Elephant / Minister interpretation | **Asymmetric, following the glyphs:** Han 相 = Chancellor's office; Chu 象 = war elephant (labelled interpretation, E4 for this war) | Symmetric "minister" formations for both sides; or elephants for both sides (E4 for Han) | Concept sheets for this piece | M1 concept phase |
| **D4** | Cannon interpretation | **Small traction trebuchet for both sides**; no gunpowder | Large frame crossbow cart for one or both sides (also E2, Mohist texts) | Cannon concept | M1 concept phase |
| **D5** | Engine | **Unity 6 LTS + URP**, confirmed by the M1 spike | Godot 4 (workflow and licence priority); Unreal Engine 5 (fidelity priority) | M3 and all engine work (not M2) | End of M1 |
| **D6** | Platforms and hardware tiers | **Windows (Steam) first, macOS second**; tiers as in document 03 §7 | Windows only; add tablets at launch | Performance targets, spike plan | Start of M1 |
| **D7** | Visual approach and camera | **Stylised realism, real-time 3D; fixed elevated camera with limited adjustment; Classic disc view** | Photorealism; 2.5D | Concept art | Start of M1 |
| **D8** | Vertical-slice formation | **Chariot (both armies)** | Soldier squad (lower risk, leaves horse and vehicle risk for M4) | M3 planning | End of M1 |
| **D9** | Ruleset baseline | **`basic-asian` in M2; full WXF repetition and chase rules by M5** | Also implement CXA rules; or casual only | M2 test corpus | Start of M2 |
| **D10** | MVP scope, rating and monetisation | **MVP: vs AI (6 levels), hotseat, tutorial, Codex, replay and analysis, Classic view; EN, zh-Hans, zh-Hant. Premium purchase, no microtransactions. No-gore depiction (target around PEGI 7 / ESRB E10+)** | Add online play at launch (large scope and cost increase); different rating target | M5 planning | End of M1 |
| **D11** | Generative-AI policy for assets | **No generative-AI imagery, models or audio in shipped content** unless individually approved, legally reviewed, rights-cleared and disclosed on Steam. AI-assisted *code and documentation* allowed with human review | Permit generative AI for concept exploration only (never final) | Art vendor contracts | Start of M1 |
| **D12** | Production model and budget | **Small core team (you as producer and approver; engineering AI-assisted) + outsourced art, animation and audio under this team's specifications; part-time historian** | Fully in-house art team; asset-store purchases (rarely meet the historical bar; licence review needed) | M1 vendor selection, budget | Start of M1 |
| **D13** | Source-art storage | **Git LFS for runtime assets; separate managed storage for large source files** | All in Git LFS (cost and size growth) | Repository setup | Start of M3 |
| **D14** | Working title and naming | Defer; codename *Warring States*; trademark search before choosing | — | Marketing only | Before M6 |

## 2. Risk register

Likelihood (L) and impact (I) are rated High, Medium or Low. Owners are roles; named owners are assigned after D12.

| ID | Risk | L | I | Mitigation | Owner |
|---|---|---|---|---|---|
| R1 | **Art production scope and cost** exceed budget (14 formation variants, horses, elephant, vehicles, animation) | H | H | Vertical slice measures real production rates before M4; modular kit and shared skeletons; reduced-density tier; stage formations by reuse | Producer, Art lead |
| R2 | **Historical evidence gaps** (Chu dress and cavalry, elephant, trebuchet) cause rework or criticism | H | M | Labelled interpretations; historian sign-off before modelling; Codex transparency | Research lead |
| R3 | **Readability vs detail**: detailed formations become noisy at the gameplay camera | M | H | M1 greybox test before art; silhouette and height tiers; four ownership channels; Classic view | Art director, UX |
| R4 | **Footprint and scale conflicts** (chariot, elephant, trebuchet within 0.45 P) | H | M | Greybox resolution in M1; compressed arrangements; documented scale licence; two-horse fallback | Tech art |
| R5 | **Engine licensing or pricing change** | L | M | Engine-independent C# core; Godot fallback documented | Tech lead |
| R6 | **Perpetual chase rules** are complex and disputed; bugs undermine trust | H | M | Staged rulesets; official rulebook examples as tests; WXF behind its own test corpus | Rules specialist |
| R7 | **AI strength expectations** of experienced players | M | M | Benchmark before any claim; time-configurable top level; honest level descriptions | AI engineer |
| R8 | **Performance on minimum spec** with about 160 animated actors | M | M | Spike measurement; animation LOD and update-rate control; vertex animation textures; density tiers | Graphics engineer |
| R9 | **Reference image rights**: museum photography is copyrighted | H | L–M | Internal-reference-only policy; licence anything published; prefer own photography | Art lead |
| R10 | **Generative-AI provenance**: unclear rights or store disclosure issues | M | H | Policy D11; vendor contracts with warranties and AI clauses | Producer |
| R11 | **Cultural reception**: Chinese-speaking audiences scrutinise historical and linguistic accuracy | M | H | Historian; native-speaker localisation and review; avoid caricature and *Romance* clichés | Director |
| R12 | **Market access**: mainland China requires separate game approval; other regions have rating requirements | M | M | Treat China as a separate later decision; IARC ratings for Steam regions | Producer |
| R13 | **Development environment**: the cloud environment has no GPU or Unity; visual work needs workstations and GPU CI | H | M | Keep logic headless-testable; workstation and GPU CI runner budgeted | Tech lead |
| R14 | **Decision latency**: approvals gate the critical path | M | M | Clear decision log with "needed by" dates; batch decisions at gates | Producer |
| R15 | **Repository growth** from binary assets (LFS storage and bandwidth costs) | M | L | D13; asset validation; prune source files from the runtime repository | Tech lead |
| R16 | **Single-source dependency on outsourced vendors** (quality variance) | M | H | Paid test asset before contracts; style guide and validators; milestone-based payment | Art lead |
| R17 | **Font and glyph licensing** for CJK and calligraphic piece glyphs | M | M | OFL fonts for UI (Source Han / Noto CJK); commissioned piece glyphs with full rights transfer | UI lead |

## 3. Assumptions

These underpin the plan. If any is wrong, tell us; the plan changes accordingly.

| ID | Assumption | If wrong |
|---|---|---|
| A1 | Premium, paid PC title with a professional-quality bar | Re-scope visuals and platforms |
| A2 | Small core team plus outsourcing; you act as producer and final approver | Re-plan capacity and schedule |
| A3 | Launch languages: English, Simplified Chinese, Traditional Chinese | Adjust localisation budget |
| A4 | No online multiplayer at launch | Adds server, matchmaking, anti-cheat and operations scope |
| A5 | Windows is the primary platform; macOS secondary | Re-run the engine and platform evaluation |
| A6 | Budget sufficient for outsourced art at the specified quality (to be estimated in M1) | Reduce formation density or variants; consider fewer animations |
| A7 | Claude Code supports engineering, tooling, testing and documentation; human artists produce final 3D, animation and audio assets | Re-plan the art pipeline |
| A8 | Traditional Xiangqi rules with WXF-based adjudication are acceptable to the target audience | Add CXA ruleset (D9) |
| A9 | A part-time external historian can be engaged in M1 | Authenticity gate cannot be signed off |
| A10 | The repository is currently empty (verified 2026-11-20); no prior work to preserve | — |

## 4. Change control

After approval, changes to the historical setting, art direction, engine, architecture, scope or monetisation require a written change request: the change, its reason, and its impact on schedule, cost, quality and risk. The change is recorded as an ADR or a decision-log entry before work proceeds.
