# 06 — Xiangqi Piece Design Matrix

| | |
|---|---|
| Document status | **Draft v0.1, submitted for approval** (concept stage; no assets exist) |
| Date | 2026-11-20 |
| Depends on | 04 Historical Research (setting: Han vs Western Chu, 206–202 BCE), 05 Visual Direction |

> **Concept only.** Everything below is a design specification. No models, textures, animations or concept art exist yet. Every entry is subject to the historical approval gate and the external historian's review.

**Units.** `P` = board pitch, the distance between adjacent intersections. All footprints and heights are given in `P` so the spec is independent of the engine's world scale. The proposed figure scale is 1 P ≈ 3.5 m equivalent, so a 1.75 m figure is ≈ 0.5 P tall. This is validated in the Milestone 1 greybox test.

**Evidence classes** E1–E4 are defined in document 04, §1.2.

---

## 1. Master matrix

| Piece | Glyphs (Red / Black) | Gameplay role | Red: Han formation | Black: Chu formation | Primary subject (must read first) | Silhouette key | Height tier | Figures, full / reduced | Evidence |
|---|---|---|---|---|---|---|---|---|---|
| **General** | 帥 / 將 | Confined to palace; the piece to protect | King of Han's command group | Hegemon-King's command group | Commander with the great command banner | Tallest element on the board: the command banner | T5 (≈ 1.1 P) | 5 / 3 | E1 kit, E3 composition |
| **Advisor** | 仕 / 士 | Palace diagonal guard | Langzhong guard officers (郎中) | Jiangdong elite retainers (江東子弟) | Armoured officer with rank cap | Paired long sword-spears or halberds crossed at the tips | T2 (≈ 0.7 P) | 3 / 2 | E1 kit, E3 composition |
| **Elephant / Minister** | 相 / 象 | Home defence; cannot cross the river | **Chancellor's office**: chancellor, scribe, guards (Xiao He archetype) | **War elephant** with mahout and torch-handlers | Han: chancellor under a canopy; Chu: elephant | Han: square canopy; Chu: elephant mass | T3 (≈ 0.85 P) | Han 4 / 3; Chu 3 + elephant / 1 + elephant | Han E1 role, E3 visual; Chu E1 precedent, **E4 for this war** |
| **Chariot** | 俥 / 車 | Long-range straight mover | Qin-type chariot, 4 horses, 3 crew | Chu-type chariot, 4 horses, 3 crew | Chariot box and wheels | Two large spoked wheels and a horse team | T3 (≈ 0.8 P) | 3 + 4 horses / 3 + 2 horses | E1 |
| **Horse** | 傌 / 馬 | Jumping piece with blocked-leg rule | Han cavalry (Guan Ying's corps type) | Chu cavalry (Gaixia riders type) | Lead rider and horse | Horse heads and necks; riders above | T3 (≈ 0.75 P) | 3 riders / 2 riders | Han E1; Chu E1 text, E3 kit |
| **Cannon** | 炮 / 砲 | Captures by jumping a screen | Traction trebuchet crew | Traction trebuchet crew | The trebuchet beam | Tall slanted beam with sling | T4 (≈ 1.0 P beam raised) | 5 / 3 | E2 machine, E3 detail |
| **Soldier** | 兵 / 卒 | Forward mover; gains sideways moves after the river | Han squad (伍) | Chu squad (伍) | Squad leader | Low dense block with spear points | T1 (≈ 0.6 P with spears) | 5 / 3 | E1 |

**Height tiers** keep silhouettes distinct even in a top-down glance, because pieces differ in height as well as shape:
T1 ≈ 0.6 P, T2 ≈ 0.7 P, T3 ≈ 0.75–0.85 P, T4 ≈ 1.0 P, T5 ≈ 1.1 P.

**Footprint:** every formation must fit within a circle of radius **0.45 P** in all static poses. That leaves a visual gap of ≥ 0.10 P to a neighbour's footprint. Large formations (Chariot, Chu Elephant, Cannon) achieve this through compressed arrangements, not by shrinking figures. Any figure-scale licence over ±10% must be recorded as E4 in the register.

**Density tiers:** "full" is the PC High/Ultra preset; "reduced" is for small screens and low-end hardware. The primary subject is always present, and only supporting figures drop out. Logical gameplay is unaffected.

---

## 2. Per-piece design cards

### 2.1 General: 帥 (Han) / 將 (Chu)

| | Han 帥 | Chu 將 |
|---|---|---|
| Primary subject | Commander in elaborate officer armour (fine plates, patterned borders, ribbon knots), long cap of the highest rank type | Commander in fine black-lacquered laced armour with red-painted details; tall cap |
| Supporting (full) | Standard-bearer with the great banner (red); war drummer with a barrel drum on a frame; two guards with ceremonial pole weapons (殳), as in the terracotta pit 3 command guard | Standard-bearer (black banner with Chu painted motif); drummer; two guards with multi-blade halberds and painted shields; optional groom holding a dark horse (reference to Xiang Yu's horse Zhui, E1 text, decorative) |
| Reduced (3) | Commander, standard-bearer, drummer | Commander, standard-bearer, drummer |
| Weapons and equipment | Sword (劍) at the waist; drum; bronze bell for signals | Sword; drum; bronze bell |
| Silhouette | Great banner is the tallest object on the board | Same rule; different banner finial and pennant shape |
| Evidence | Officer armour and pit 3 guards (HR-10, HR-24), drum and metal signals (HR-33) | Chu armour (HR-07), shields (HR-08); the tall cap is an interpretation (U11) |
| Exclusions | No chair or throne (§6 of document 04); the commander stands or kneels on a mat | Same |

### 2.2 Advisor: 仕 (Han) / 士 (Chu)

| | Han 仕 | Chu 士 |
|---|---|---|
| Primary subject | Middle-rank officer, armour with ribbon knots, mid-rank cap | Elite retainer officer, lacquered armour, lacquered leather helmet |
| Supporting | Two guards with long sword-spears (鈹) | Two retainers with halberds (戟) and painted shields |
| Silhouette | Two tall polearms crossed at the tips form an "X" crest, which is unique on the board | Same "X" crest, built from different weapons and finials |
| Evidence | Terracotta officer types (HR-10); sword-spears (HR-24); the Langzhong guard as a palace corps (E1 text, V0) | Jiangdong troops of Xiang Yu (E1 text, V0); Chu kit (HR-07, HR-08, HR-25) |

### 2.3 Elephant / Minister: 相 (Han) / 象 (Chu)

This is the only piece whose two versions differ in kind (§4.9 of document 04). Readability is protected by matching footprint, height tier and placement, and by the glyph on the base.

| | Han 相: Chancellor's office | Chu 象: War elephant |
|---|---|---|
| Primary subject | The chancellor in court robe and cap, holding a bundle of bamboo-slip registers | An Asian elephant (*Elephas maximus*), unarmoured |
| Supporting | Scribe with a writing brush, knife and slips; map case on a carrying frame; two guards with halberds; low square canopy on a pole | Mahout seated on the neck; two handlers on foot with torches and goads |
| Silhouette | Square canopy at T3 | Elephant mass at T3 |
| Evidence | Xiao He secured the Qin statutes, maps and registers, then managed supply (HR-30, E1 text); writing media (HR-31) | Chu torch-elephant episode of 506 BCE (HR-28); elephant range (HR-29). **No evidence for elephants in this war (U3): labelled interpretation** |
| Exclusions | No paper, no chairs, no writing desks of later form | No howdah, no armour, no tusk blades, no South Asian caparisons |
| Gameplay link | Cannot cross the river: the administrator who keeps the home base and supply running | Cannot cross the river: a defensive beast held close to the home line |
| Alternative (decision D3) | — | Symmetric "Chu minister" formation (official and retinue) |

### 2.4 Chariot: 俥 (Han) / 車 (Chu)

| | Han 俥 | Chu 車 |
|---|---|---|
| Primary subject | Qin-type chariot: rectangular box, single draught pole, two large spoked wheels | Chu-type chariot: Chu fittings, bladed axle caps, black lacquer with red-painted rail decoration |
| Crew | Driver in long charioteer armour (arm and hand guards, high collar); left archer or commander; right halberdier | Driver; archer; halberdier with a multi-blade halberd |
| Team | Four horses, tightly yoked (full); two (reduced) | Same |
| Silhouette | Wheels and horse team | Wheels and horse team; Chu banner pennant on the box |
| Evidence | Qin bronze chariots, pit chariots (HR-16); charioteer armour (HR-12); chariots in this war (HR-18) | Chu chariot finds (HR-17, V0), "Hymn to the Fallen" (V2) |
| Footprint note | Hardest fit (§1). Team compressed; the formation is oriented along the file direction, rotating to face its move direction | Same |

### 2.5 Horse: 傌 (Han) / 馬 (Chu)

| | Han 傌 | Chu 馬 |
|---|---|---|
| Primary subject | Lead cavalryman: short armour vest, close cap tied under the chin, crossbow | Lead rider: lacquered leather vest, Chu helmet variant, bow |
| Supporting | Two riders (one crossbow, one halberd) | Two riders (bow, halberd) |
| Tack | Saddle pad, girth, crupper, bridle with bit; cropped mane, tied tail; **no stirrups, no horseshoes** | Same tack; Chu lacquered or painted harness ornaments |
| Evidence | Pit 2 cavalry (HR-21); Guan Ying's corps (HR-19) | Gaixia riders (HR-20); equipment extrapolated (E3, U5) |

### 2.6 Cannon: 炮 (Han) / 砲 (Chu)

| | Han 炮 | Chu 砲 |
|---|---|---|
| Primary subject | Small traction trebuchet: single throwing beam on a timber A-frame, sling at the long arm, pull ropes at the short arm | Same machine class; Chu lacquer-painted beam bands and Chu pennant |
| Crew (full) | Four pullers and one loader (5) | Same |
| Crew (reduced) | Two pullers and one loader (3) | Same |
| Projectile | Shaped stone | Same |
| Evidence | Mohist siege engines as interpreted by Yates and Needham (HR-26, E2); field use in this war undocumented (E3, U4) | Same |
| Exclusions | No gunpowder, no barrels, no counterweight box, no Song-specific hardware (HR-27) | Same |
| Glyph note | Red's 炮 (fire radical) is a later writing convention; the machine is still a stone-thrower | 砲 (stone radical) matches the machine |

### 2.7 Soldier: 兵 (Han) / 卒 (Chu)

| | Han 兵 | Chu 卒 |
|---|---|---|
| Composition | One squad (伍) of five: squad leader (armoured, sword and spear), two armoured halberdiers, one unarmoured spearman, one kneeling or standing crossbowman | Squad leader (lacquered armour, helmet), two shield-and-dagger-axe men, one spearman, one archer |
| Heads | Mostly bareheaded with topknots; cloth caps (HR-11) | Mix of lacquered leather helmets and bare heads (E3) |
| Silhouette | Low dense block; spear tips at T1 | Low block; painted shield faces visible from the camera |
| Variation | Modular heads, torsos, arms and poses, so no two squads are identical (HR-14) | Same system |
| After crossing the river | Optional visual state: formation shifts from column to a looser skirmish line, a cue for the new sideways moves | Same |

---

## 3. Animation matrix

All animations are **presentation only**: the rules engine has already applied the move (document 07, §9). Every animation can be interrupted or skipped and snaps to the authoritative state. Target durations are at the default speed (1.0×); the player can set 0.5×–2× or "instant" (document 02, §9).

| Piece | Idle (looping, subtle) | Selected | Move (target duration) | Capture: attacker | Captured: defender | Gives check | Victory / defeat |
|---|---|---|---|---|---|---|---|
| General | Banner sways; drummer taps; guards shift weight | Commander raises sword; drum roll | Short march within the palace (0.5 s per step) | Guards advance first | Banner lowered; figures kneel, then fade | — | Victory: drums and banner raised. Defeat: banner falls, figures kneel |
| Advisor | Guards ground polearms | Officer signals; polearms lift | Diagonal step (0.5 s) | Polearms lower to charge | Kneel, weapons laid down, fade | Polearms point toward the enemy general | Kneel or salute |
| Han 相 | Scribe writes; chancellor reads slips | Chancellor looks up and gestures | Diagonal two-point walk **via the eye point** (0.8 s) | Guards advance | Slips dropped; figures withdraw and fade | — | Bow or withdraw |
| Chu 象 | Ear and trunk motion; handlers adjust torches | Elephant raises its trunk | Diagonal walk via the eye point (0.9 s) | Trunk swing toward the target | Elephant turns away and is led off, fading. **No injury to the animal is depicted** | Trunk raised toward the enemy general | Trunk raised or lowered |
| Chariot | Horses stamp; driver holds reins | Driver lifts the whip; horses toss heads | Accelerate, cruise, decelerate along the file or rank (0.6–1.4 s by distance) | Archer draws; halberd levels | Crew dismounts and the chariot is abandoned in place, fading | Archer aims toward the general | Victory: wheel turn and salute. Defeat: horses held |
| Horse | Horses shift; riders adjust | Lead horse rears slightly | Path follows **one orthogonal point, then one diagonal** (visualising the leg rule) (0.7 s) | Charge | Riders dismount, lead horses away, fade | Lead rider points | Victory: circle and halt |
| Cannon | Crew checks ropes; loader holds a stone | Beam cocks back | Crew hauls the engine along the line (0.6–1.4 s) | **Fires: projectile arcs over the screen piece** to the target, then the crew hauls the engine to the target point **along a path that bulges around the screen piece** | Crew abandons the engine, fading | Beam aimed toward the general | Victory: crew cheers |
| Soldier | Weight shifts; leader looks around | Leader raises spear | March step (0.5 s) | Spears lower and advance | Kneel, ground weapons, fade | — | Victory: weapons raised |

### 3.1 Animation rules shared by all formations

1. **No visual overlap of formations.** Only a Cannon capture passes another piece. Chariots cannot pass pieces, and Horse legs and Elephant eyes must be empty for the move to be legal. The path planner therefore bulges the Cannon's travel path around the screen piece.
2. **Defender before attacker.** A captured formation starts its "captured" animation before the attacker arrives, so the two formations never occupy the same footprint.
3. **No gore.** Capture shows yielding, kneeling, withdrawing and fading. There is no blood, no dismemberment and no injury to animals. This targets an age rating around PEGI 7 / ESRB E10+, decision D10.
4. **Rule-teaching motion.** Horse and Elephant paths visibly pass through the leg or eye point, so the blocking rules are visible in play.
5. **Facing.** Formations turn to face their move direction, then settle back to face the enemy side when idle.
6. **Crowd desynchronisation.** Idle loops are offset and varied per figure. Identical clips never play in lockstep across a formation.

---

## 4. Ownership and readability checklist (per formation)

Every formation must pass all of these before sign-off (measured in document 11, QV-01 to QV-06):

- [ ] Piece type identifiable from silhouette alone (greyscale, gameplay camera, 1080p)
- [ ] Owner identifiable **without colour**: base design, glyph, faction equipment language
- [ ] Glyph legible on the base from the default camera
- [ ] Fits the 0.45 P footprint in all static poses
- [ ] Height within its tier
- [ ] Primary subject visually dominant (largest, centred or front, highest contrast)
- [ ] Every element has an evidence class recorded in the register
- [ ] No item from the anachronism exclusion list (document 04, §6)
