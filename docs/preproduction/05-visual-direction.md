# 05 — Proposed Visual Direction

| | |
|---|---|
| Document status | **v0.2: revised after your decisions** (seven states, colour per state, *Qin Dynasty Epic* as art reference; D7 approved) |
| Date | 2026-11-20 |
| Depends on | 04 Historical Research, 06 Piece Design Matrix |

> **No images are included in this package.** This is a written direction plus a specification for the mood board, reference boards and concept art to be produced in Milestone 1. Generative AI may be used **for internal concept exploration only** (decision D11): logged, never shipped, and never presented as final art.

---

## 1. Art direction statement

**"A living museum reconstruction of the Warring States."** Seven armies, each recognisable at a glance, all drawn from one coherent late-Warring-States material culture: bright bronze, dark iron, lacquer, painted textiles, rammed earth and loess light. The look should sit comfortably beside the modern screen image of the period that Chinese audiences know (with *Qin Dynasty Epic* as our reference), while every identity-critical element is traced to archaeology and texts.

## 2. Visual pillars

| Pillar | Meaning | Test |
|---|---|---|
| **Evidence-led** | Identity-critical elements trace to the reference register; screen references only point to evidence | Register ID for every element (QH-01) |
| **Readable first** | Piece type and owner readable instantly in any of the 28 possible pairings | ≥ 95% / ≥ 99% identification (QV-01, QV-02) |
| **Seven distinct states** | Each state recognisable by its signature trait, not by colour alone | State-recognition target (QV-11) |
| **Living diorama** | Formations breathe, shift and react; the battlefield feels like a place | Idle variety, environment motion |
| **Restraint** | Conflict without gore | Rating target (D10) |
| **One system** | 49 formation variants from one modular kit plus seven identity layers | Shared skeletons, materials and part library (§6.5) |

## 3. Rendering style (approved, D7)

**Stylised realism in real-time 3D.** Realistic anatomy, materials and proportions, with silhouette-defining elements (banners, weapons, headgear, shields, the strategist's canopy) enlarged by about 10–15% for readability. The far environment combines 3D terrain with painted sky and distant-terrain backdrops. High-quality 2D illustration is used for UI, Codex and key art.

## 4. Ownership and state identity: never colour alone

In any match, two states face each other. That gives **21 distinct pairings plus 7 same-state matches** (decision D16). Ownership is carried by channels that work in **every** pairing, including for colour-blind players:

| Channel | What it shows | Works for same-state matches? | Works without colour? |
|---|---|---|---|
| 1. **Turn-role base band** | First player: **plain raised band**. Second player: **notched band** (a repeating cut pattern) | ✔ | ✔ |
| 2. **Traditional glyph** | First-player set 帥 仕 相 俥 傌 炮 兵 / second-player set 將 士 象 車 馬 砲 卒 | ✔ | ✔ |
| 3. **State emblem** | State name in its regional script on the banner and base | ✗ (same emblem) | ✔ |
| 4. **State kit and silhouette** | Signature traits (document 06 §2) | ✗ (same kit) | ✔ |
| 5. **State colour** | Banners, base rim, UI side colour | Via the alternate palette | ✗ |
| 6. **Board orientation** | Each army faces from its own side | ✔ | ✔ |

Channels 1, 2 and 6 guarantee ownership even in a same-state match. Channels 3 to 5 carry state identity.

## 5. Colour and material palette (provisional)

### 5.1 State colours

These values are **starting points for concept art**, to be reconciled with the *Qin Dynasty Epic* reference sheet and validated under colour-blind simulation (QV-03). The basis for each colour is in document 04 §3.3.

| State | Primary (banner, rim) | Secondary (trim) | Alternate palette (same-state match, second player) |
|---|---|---|---|
| Qin 秦 | Black `#1C1A19` | Bronze `#B08D57` | Black with a cinnabar trim `#B3261E` |
| Chu 楚 | Vermilion `#B3261E` | Lacquer black `#1C1A19` | Black ground with vermilion trim |
| Qi 齊 | Purple `#5B2A6E` | Ivory `#E8DFC8` | Ivory with purple trim |
| Zhao 趙 | Ivory `#E8DFC8` | Charcoal `#2B2B2B` | Charcoal with ivory trim |
| Yan 燕 | Azure `#2F6EA5` | Iron grey `#4A4E52` | Iron grey with azure trim |
| Wei 魏 | Ochre-gold `#C99A3B` | Umber `#5A3E22` | Umber with ochre trim |
| Han 韓 | Green `#3C7A3B` | Bronze `#B08D57` | Bronze with green trim |

**Rules:**

- Each state colour sits on a base band with a contrasting value, so dark colours (Qin, Qi) never depend on dark-on-dark contrast.
- Problem pairs under colour-vision deficiency (for example Chu and Han, Yan and Han, Qi and Yan) are covered by channels 1, 2 and 6 (§4). They are explicitly included in the QV-03 test matrix.
- Within an army, **clothing colours vary**, following the polychromy evidence (HR-15). State colour lives on banners, base, emblems, trims and lacquer, not on uniforms.

### 5.2 Figure material palette (period-based ranges)

| Material | Appearance | Evidence |
|---|---|---|
| Lacquered rawhide armour (Chu and others) | Deep brown-black, semi-gloss, coloured lacing | HR-06, HR-07 |
| Riveted lamellar (Qin) | Dark plates; red, white or pink cords and rivets | HR-10, HR-12 |
| Iron armour and weapons (Yan especially) | Dark grey, darker edges, slight sheen | HR-42 |
| Bronze | **New**: gold-brown metallic, never green patina | HR-13 |
| Textiles | Varied: cinnabar, malachite green, azurite blue, purple, ochre, off-white | HR-15 |
| Timber (chariots, poles, map boards) | Oiled; lacquered parts; bronze fittings | HR-16, HR-47 |
| Rammed earth | Warm loess yellow-brown, visible tamping layers | HR-36 |

## 6. Formation system rules

### 6.1 Base

- Low circular lacquered base, diameter **0.84 P**, bevelled, height ≈ 0.04 P.
- **Rim in the state colour; band pattern by turn role** (plain or notched); traditional glyph at the front edge, facing the active player's camera; small state emblem on the rim.
- Selection, threat and check indicators render **on the base rim**, never on figures.

### 6.2 Footprint and scale

- All geometry within radius **0.45 P** in static poses. Common figure scale: 1 P ≈ 3.5 m equivalent.
- Any scale licence over ±10% is recorded as E4. The Chariot is the only large formation.
- Validated in the Milestone 1 greybox readability test before any final modelling.

### 6.3 Height tiers and occlusion

- Tiers T1–T5 (≈ 0.6–1.1 P); only the General's banner reaches T5.
- At the default pitch (≈ 58°) an element of height *h* hides ground up to about 0.6 *h* behind it, so a T5 banner cannot hide the base one rank behind. To be verified in the greybox.
- Fallbacks: thin banner geometry, a "lower banners" option, outlines through occluders.

### 6.4 Visual hierarchy within a formation

1. **Primary subject:** largest, front-centre, highest contrast, unique headgear or prop.
2. **Signature element:** banner, canopy, wheels, pennant over crossbows, or crossed polearms.
3. **Supporting figures:** lower contrast, varied poses, never taller than the signature element.

### 6.5 Shared kit plus state identity layers

Modelled on the Qin workshops' own modular production (HR-14):

- **Shared skeletons:** one human skeleton and one horse skeleton for all states; animations are shared and retargeted.
- **Shared base kit:** bodies, common garments, common weapons, chariot base, map board, banner rigs.
- **State identity layer** (document 06 §2): state-specific armour sets, headgear, shields, signature weapons, emblem decals, palettes.
- **Paint masks:** RGBA masks drive colour variation within each state's palette ranges.
- **Seeded assembly:** each formation instance is assembled from a deterministic seed, so replays look identical.

**Production consequence:** the art cost of seven states is driven by the number of identity-layer parts, not by 49 unique formations. Estimates are in document 09 §4.

## 7. Readability rules (non-negotiable)

1. Logical position is always unambiguous: the base centre sits exactly on the intersection.
2. Board lines, palace diagonals and the river edge stay visible at all camera presets.
3. No decoration inside the board area rises above T1 or covers an intersection.
4. Selection and legal-move indicators render on top, with outlines through occluders.
5. Animations never cover another formation's base (path planner, document 06 §4.1).
6. **Classic view:** a toggle that shows high-quality lacquered disc tokens bearing the traditional glyphs. These are finished assets, rimmed in the state colour and carrying the turn-role band.

## 8. Board and environment concept

**MVP battlefield (decision D18): the Dan River valley at Changping, 260 BCE** (HR-35). It is neutral to the chosen states.

| Element | Concept |
|---|---|
| Board surface | A levelled loess field laid out as a surveyed grid; lines are shallow incised channels with light rammed-earth edges |
| River | The Dan River (丹水) crossing the board between ranks 4 and 5, with banks and subtle flow |
| River inscription | Traditional **楚河　漢界** carved on stone markers on each bank, outside the play area, as the board's convention. Option: show 丹水 instead. The Codex explains the inscription's later origin |
| Palaces | Low rammed-earth command enclosures, diagonals as inlaid timber or packed-earth paths, kept below T1 inside the board |
| Board border | Rammed-earth embankments and palisades just outside the outer lines |
| Near environment | Each player's field camp behind their home rank, flying that player's state banners. This is the only environment element that changes with state choice |
| Far environment | Loess ridges of the Changping valley; painted backdrop |
| Ambient life | Banner flutter, drifting dust, birds, river flow, camp smoke. All outside the play area or below T1 |
| Future battlefields | Maling, Yique, Jimo and others (post-MVP candidates) |

## 9. Camera

| Mode | Description | Default |
|---|---|---|
| **Gameplay** | Perspective, narrow field of view (≈ 30°), pitch ≈ 58°, player's army at the bottom | Yes |
| Pitch adjust | 45°–75° within limits | — |
| Orbit | Limited yaw ±15°, snap back | — |
| Zoom | Strategic (whole board) and tactical (≈ 1.6×) presets | Strategic |
| Analysis view | Orthographic top-down; the strategist's canopy disc and the base glyphs read clearly | Optional |
| Hotseat | Optional 180° rotation between turns | Option |
| Cinematic | Only outside active input (game start, checkmate, victory); short and skippable | — |

## 10. Lighting and post-processing

- Key light: late-afternoon sun, low and warm, with shadows falling away from the camera.
- Baked global illumination for the static environment; probes for formations; contact shadows.
- Post: subtle grading, ambient occlusion, mild bloom on bronze only, TAA or upscaling. **No depth of field during play; no heavy vignette or grain.**
- Quality profiles scale cost, never readability (document 03 §8).

## 11. Animation style

Grounded and weighty (motion capture or careful keyframing; no wuxia physics). Formations move as disciplined units with small timing offsets. Selection feedback within one frame; move animation starts within 100 ms. Default move durations 0.5–1.4 s, with speed control and reduced motion.

## 12. Visual effects and capture depiction

- VFX: marching and wheel dust, river splashes, crossbow volley streaks with a soft dust impact, banner cloth, ink-wash flourishes in the UI only.
- Capture: the defeated formation lowers its banner, kneels or withdraws, and dissolves into wind-blown loess dust. No blood, no bodies.
- Check: pulse on the threatened general's base rim, drum accent, a line from the checking piece. Flying-general violations are explained with a line between the generals.

## 13. Mood board and reference boards: Milestone 1 specification

**For internal use only**, recording the rights status of every image.

| Board | Content |
|---|---|
| **Mood board** | Light and atmosphere; Changping loess terrain; lacquer, bronze and iron in light; banners in wind |
| **Screen reference sheet: *Qin Dynasty Epic*** | Stills showing how each state is colour-coded and how armies read on screen. **Every borrowed look is traced to its artefact** (document 04 §1.3); no designs are copied |
| **Seven state boards** | One per state: armour, weapons, headgear, textiles, emblem script samples, signature traits (document 06 §2), with register IDs |
| **Common kit board** | Shared garments, weapons, chariot, horses and tack, map boards, banners |
| **Architecture and environment board** | Rammed earth, palisades, field camps, Changping valley |
| **Negative board ("never")** | Romance-style generals, Ming armour, pavises, gunpowder, elephants, trebuchets, green-patina weapons, copied screen designs |

### 13.1 Concept art deliverables (Milestone 1)

1. Two **style frames**: full board in the gameplay view, and a tactical close-up.
2. **Base formation sheets**: the seven piece types, neutral kit, with silhouette tests.
3. **State identity sheets**: seven sheets, each showing the identity layer on a Soldier, a Crossbow unit and a General.
4. **Base, band, emblem and glyph sheet**, including colour-blind simulations of all 28 pairings.
5. **Board and environment** paintover.
6. **UI style sheet**.

Generative AI may be used to explore ideas before these sheets are drawn (D11). The approved sheets themselves are human-made and reviewed by the historian.
