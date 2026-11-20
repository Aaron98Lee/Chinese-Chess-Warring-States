# 05 — Proposed Visual Direction

| | |
|---|---|
| Document status | **Draft v0.1, submitted for approval** |
| Date | 2026-11-20 |
| Depends on | 04 Historical Research, 06 Piece Design Matrix |

> **No images are included in this package.** It is a written direction plus a specification for the mood board, reference board and concept art to be produced in Milestone 1. Presenting descriptive concepts as finished art would breach the project brief.

---

## 1. Art direction statement

**"A living museum reconstruction."** The battlefield should look the way an archaeologist's best reconstruction would look if it came to life: bright bronze, lacquer, painted textiles, rammed earth and loess light. It should be legible at a glance as a game of Xiangqi.

We are not making a fantasy China, a film-costume China or a museum-grey China. The terracotta figures we draw on were brightly painted and their weapons were polished. The game shows that living colour, and it explains the evidence in an in-game Codex.

## 2. Visual pillars

| Pillar | Meaning | Test |
|---|---|---|
| **Evidence-led** | Every identity-critical element traces to the reference register | Register ID exists for each element (QH-01) |
| **Readable first** | Piece type and owner can be read instantly from the gameplay camera | ≥ 95% identification in timed tests (QV-01) |
| **Living diorama** | Formations breathe, shift and react; the board feels like a place | Idle variety, environment motion, no lockstep animation |
| **Restraint** | Conflict without gore; drama through banners, drums, light and motion | Rating target, decision D10 |
| **One system** | 32 pieces come from one modular kit with controlled variation, not 32 unrelated models | Shared skeletons, materials and part library (§6.5) |

## 3. Rendering style evaluation

| Approach | Visual ceiling | Readability | Animation | Production cost | 4K scalability | Verdict |
|---|---|---|---|---|---|---|
| Photorealistic 3D | Very high | Risky: detail noise, uncanny faces | High cost | Very high | Good, but heavy | Rejected: cost and readability |
| **Stylised realism, real-time 3D** | High | Good: controlled shape language | Full 3D animation | High but bounded | Excellent | **Recommended** |
| High-quality 2D illustration | High for stills | Excellent | Limited (frame-by-frame cost) | High per frame | Large textures | Use for UI, Codex and key art only |
| 2.5D pre-rendered sprites | Medium–high | Good | Fixed angles; heavy sprite sheets at 4K | Medium | Poor (memory at 4K) | Rejected for gameplay |
| Hybrid (3D pieces, painted 2D backdrop) | High | Good | Full 3D for pieces | Medium–high | Good | **Adopted for the far environment** |

**Recommendation:** real-time 3D with **stylised realism**: realistic anatomy, materials and proportions, with silhouette-defining elements such as banners, weapons, headgear and shields enlarged by about 10–15% for readability. The far environment combines 3D terrain with painted sky and distant-terrain backdrops.

## 4. Army identities: distinguishable without colour

Banner colour is a Xiangqi convention (document 04, §3.3). Ownership is carried by **four independent channels**, so the owner remains readable for colour-blind players and in greyscale:

| Channel | Red: Han | Black: Chu |
|---|---|---|
| 1. **Base design** | Round base with a vermilion lacquer rim and a **plain raised band** | Round base with a black lacquer rim carrying a **painted cloud-scroll band** (Chu lacquer motif) |
| 2. **Glyph** | Red-side character (帥 仕 相 俥 傌 炮 兵) on the base front, facing the player | Black-side character (將 士 象 車 馬 砲 卒) |
| 3. **Silhouette and equipment** | Bareheaded infantry with topknots; small riveted lamellar; crossbows prominent; long caps for officers | Some lacquered leather helmets; large laced lamellae; painted dragon-and-phoenix shields; tall caps for commanders |
| 4. **Material language** | Cinnabar and ochre textiles; natural bronze; dark armour with red, white and green cords | Black-ground lacquer with vermilion and yellow painting; rawhide brown-black; bronze |

**Board orientation** is a fifth cue: each army faces from its own side.

## 5. Colour and material palette (provisional)

Values are **starting points for concept art**, to be adjusted against pigment research (HR-15) and colour-blind checks. They are not final.

### 5.1 Faction signal colours (UI, bases, banners)

| Token | Use | Proposed sRGB |
|---|---|---|
| `han.signal` | Han banners, base rim, UI side colour | `#B3261E` (cinnabar red) |
| `han.signal.light` | Highlights, selection tint | `#E0564A` |
| `chu.signal` | Chu banners, base rim, UI side colour | `#1C1A19` (lacquer black) |
| `chu.accent` | Chu painted motifs (vermilion on black) | `#C8442E` |
| `chu.accent.gold` | Chu ochre painted motifs | `#C99A3B` |
| `neutral.bronze.new` | Polished bronze | `#B08D57` |

**Contrast requirement:** the black Chu signal sits on a lit board, so every Chu base includes a light painted band (channel 1). It must never depend on black-on-dark contrast.

### 5.2 Figure material palette (period-based ranges)

| Material | Appearance | Evidence |
|---|---|---|
| Lacquered rawhide armour | Deep brown-black, semi-gloss, with coloured lacing | HR-06, HR-07 |
| Riveted lamellar (Han) | Dark plates; red, white or pink cords and rivets | HR-10, HR-12 |
| Bronze (weapons, fittings) | **New**: gold-brown metallic, not green patina | HR-13 |
| Iron | Dark grey, darker at the edges | Document 04, §4.5 |
| Textiles | Varied: cinnabar, malachite green, azurite blue, purple, ochre, off-white; plain or simply patterned | HR-15 |
| Chu silks (command figures) | Brown, red and yellow ground with embroidered dragon and phoenix motifs | HR-37 |
| Timber (chariots, trebuchets, poles) | Oiled, some lacquered parts; bronze fittings | HR-16, HR-17 |
| Rammed earth | Warm loess yellow-brown, horizontal tamping layers visible | HR-36 |
| Roof tiles | Grey ceramic, round eave tiles | HR-36 |

**Variation within an army follows the polychromy evidence.** Clothing colours vary between figures, while armour, base and banner remain consistent. This is how the terracotta figures were painted, and it prevents the "clone army" look.

## 6. Formation system rules

### 6.1 Base

- Low circular lacquered base, diameter **0.84 P** (radius 0.42 P), bevelled, height ≈ 0.04 P.
- Faction rim and band (§4); glyph inset at the front edge, rotated to face the active player's camera.
- The base is part of the formation asset and is never hidden by figures. Figures stand inside the rim.
- The selection ring, threat ring and check pulse render **on the base rim**, so indicators never compete with figures.

### 6.2 Footprint and scale

- All figures, horses and machines fit within radius **0.45 P** in static poses (document 06, §1).
- Common figure scale: 1 P ≈ 3.5 m equivalent. Horses and the elephant use the same scale, arranged compactly. Any scale licence over ±10% is recorded as E4.
- Validated by the Milestone 1 greybox readability test before any final modelling.

### 6.3 Height tiers and occlusion

- Tiers T1–T5 (≈ 0.6–1.1 P). Only the General's banner reaches T5.
- At the default camera pitch (≈ 58°), an element of height *h* hides ground up to about 0.6 *h* behind it. A T5 banner (1.1 P) therefore cannot hide the base of the piece one rank behind. This is to be verified in the greybox.
- Fallbacks: thin banner geometry, a "lower banners" option, and an outline through occluders for the selected piece and its legal targets.

### 6.4 Visual hierarchy within a formation

1. **Primary subject:** largest, front-centre, highest local contrast, unique headgear or prop.
2. **Signature element:** banner, canopy, wheels, beam or crossed polearms (document 06 silhouette key).
3. **Supporting figures:** lower contrast, varied poses, never taller than the signature element.

### 6.5 Modular kit and controlled variation

Modelled on the Qin workshops' own modular production (HR-14):

- **Shared skeletons:** one human skeleton for all figures, one horse skeleton and one elephant skeleton. Animations are retargeted.
- **Part library per army:** heads (8–12 variants), hairstyles and caps, torsos with armour types, arms with weapon grips, legs and footwear, shields, weapons.
- **Paint masks:** each part uses RGBA mask textures to drive procedural colour variation from the period palette ranges.
- **Seeded assembly:** each formation instance is assembled from a deterministic seed, so the same game always looks the same and replays are consistent.
- **Result:** many visibly different soldiers from a bounded asset count.

## 7. Readability rules (non-negotiable)

1. Logical position is always unambiguous. The base centre sits exactly on the intersection.
2. Board lines, palace diagonals and the river edge stay visible between formations at all camera presets.
3. No decoration (fortifications, banners, foliage, particles) inside the board area may rise above T1 or cover an intersection.
4. Selection and legal-move indicators render on top, depth-tested against the board but not against figures, with outlines through occluders.
5. Animations never cover another formation's base for longer than one frame of a transition. The path planner (document 06, §3.1) ensures this.
6. **Classic view:** a toggle that replaces formations with high-quality lacquered disc tokens bearing the traditional glyphs. This serves accessibility, purists and analysis, and it is a finished asset in its own right.

## 8. Board and environment concept

**Setting:** the Hong Canal front at Guangwu, Xingyang, 203 BCE (HR-35).

| Element | Concept |
|---|---|
| Board surface | A levelled loess field laid out as a surveyed grid. Lines are shallow incised channels with a light rammed-earth edge, readable as lines from above |
| River (楚河漢界) | The Hong Canal: a real water channel crossing the board between ranks 4 and 5, with banks and subtle flow. The inscription 楚河　漢界 is carved into stone markers on each bank, outside the play area |
| Palaces | Low rammed-earth command enclosures with the traditional diagonals marked as inlaid timber or packed-earth paths. Walls stay below T1 inside the board area; taller towers stand outside the board edge |
| Board border | Rammed-earth embankments and palisades just outside the outer lines |
| Near environment | Each army's stronghold behind its home rank: Han to one side, Chu to the other, as the two facing camps on Guangwu Mountain |
| Far environment | Loess hills, ravine, distant Yellow River plain; painted backdrop |
| Ambient life | Banner flutter at camp walls, drifting dust, birds, water flow in the canal, occasional smoke from camp fires. All outside the play area or below T1 |
| Variants (later) | Dawn mist, high summer, overcast: same layout, different lighting |

## 9. Camera

| Mode | Description | Default |
|---|---|---|
| **Gameplay (default)** | Perspective camera, narrow field of view (≈ 30°) to minimise distortion, pitch ≈ 58°, player's army at the bottom | Yes |
| Pitch adjust | 45°–75° within limits; player preference saved | — |
| Orbit | Limited yaw ±15°, with snap back | — |
| Zoom | Two presets: strategic (whole board) and tactical (≈ 1.6× closer), with smooth transition and clamps | Strategic |
| Analysis view | Orthographic, top-down: pure positional clarity; formations remain, glyph overlay recommended | Optional |
| Hotseat | Board rotates 180° between turns (optional) or stays fixed with an indicator | Option |
| Cinematic | **Only** outside active input: game start, checkmate, victory. Short and always skippable. Off during play by default | — |

The board's taller-than-wide shape (8 × 9 intervals), foreshortened by the pitch, fits naturally in a 16:9 frame. That leaves side space for the move list and the captured-pieces tray (document 02, §8).

## 10. Lighting and post-processing

- **Key light:** late-afternoon sun, low and warm, with long readable shadows that point *away* from the camera so they never hide bases.
- **Global illumination:** baked for the static environment, with light probes for the formations.
- **Shadows:** soft, stable cascades; contact shadows under figures for grounding.
- **Post:** subtle colour grading (warm loess, cooler shadows), ambient occlusion, mild bloom on bronze highlights only, temporal anti-aliasing or upscaling. **No depth of field during play**, because it harms readability. **No heavy vignette or film grain.**
- **Quality profiles** scale shadows, AO, figure density and LOD distances, never readability features (document 03, §8).

## 11. Animation style

- **Grounded and weighty:** motion-captured or carefully keyed base motion for humans and horses. No superhuman leaps or wuxia physics.
- **Formation choreography:** figures in a formation move as a disciplined unit, with small offsets in timing and gait.
- **Responsiveness:** selection feedback within one frame; move animation starts within 100 ms of a valid command (document 11).
- **Readable timing:** anticipation, then action, then settle. Default move durations 0.5–1.4 s (document 06, §3), with speed control and reduced motion.

## 12. Visual effects and capture depiction

- VFX vocabulary: dust from marching and wheels, canal splashes, torch flames (Chu elephant), the trebuchet projectile arc and a dust impact, banner cloth simulation, subtle ink-wash flourishes in the UI only.
- Capture: the defeated formation lowers its banner, kneels or withdraws, and dissolves into wind-blown loess dust. No blood, no bodies left on the board.
- Check: a pulse on the threatened general's base rim, a drum accent, and a line from the checking piece. Flying-general violations are explained with a line between the generals (document 02, §8).

## 13. Mood board and reference board: Milestone 1 specification

To be assembled by the art lead with the historian, **for internal use only**, recording the rights status of every image (most museum photography is copyrighted).

| Board | Content | Source pool |
|---|---|---|
| **Mood board** | Light, atmosphere, landscape (loess, canal, Guangwu terrain), lacquer surfaces, bronze in light, banners in wind | Own photography, licensed stock, museum images under licence |
| **Han equipment board** | Terracotta infantry, crossbowmen, cavalry, officers and general figures; armour close-ups; bronze chariots; weapons | HR-09 to HR-13, HR-16, HR-21 to HR-24 |
| **Chu equipment board** | Zeng Hou Yi armour and shields; Chu weapons; Chu chariot finds; Chu silks and lacquer; Chu tall-cap depictions | HR-05 to HR-08, HR-17, HR-25, HR-37 |
| **Machines and animals board** | Trebuchet mechanics (generic), elephant anatomy and handling, horse breeds and tack | HR-21, HR-26, HR-28, HR-29 |
| **Architecture and environment board** | Rammed earth, Qin palace platforms, eave tiles, palisades, Guangwu site | HR-35, HR-36 |
| **Negative board ("never")** | Examples of excluded tropes: Romance-style generals, Ming armour, howdahs, gunpowder cannons, green-patina weapons | Document 04, §6 |

### 13.1 Concept art deliverables (Milestone 1)

1. Two **style frames**: a full board in the gameplay view, and a tactical close-up.
2. **Piece concept sheets:** 7 pieces × 2 armies. Front and three-quarter view, gameplay-camera thumbnail, greyscale silhouette test, callouts linked to register IDs.
3. **Base and glyph design sheet** for both armies, including the colour-blind simulation.
4. **Board and environment** layout paintover.
5. **UI style sheet** (document 02, §8).

All concept sheets go through the historian review and the readability test before approval.
