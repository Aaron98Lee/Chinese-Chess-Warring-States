# 06 — Xiangqi Piece Design Matrix

| | |
|---|---|
| Document status | **v0.2: revised after your decisions** (seven states; strategist; crossbow unit). Concept stage; no assets exist |
| Date | 2026-11-20 |
| Depends on | 04 Historical Research (late Warring States, seven states), 05 Visual Direction |

> **Concept only.** Everything below is a design specification. No models, textures, animations or concept art exist yet. Every entry is subject to the historical approval gate and historian review.

**Units.** `P` = board pitch (distance between adjacent intersections). Proposed figure scale: 1 P ≈ 3.5 m equivalent, so a 1.75 m figure is ≈ 0.5 P tall. To be validated in the Milestone 1 greybox test.

**Structure.** 7 piece types × 7 states = **49 formation variants**. They are not 49 separate designs. Each piece type has **one base formation design** (shared skeletons, layout, animation set), and each state applies its **identity layer** (§2): palette, emblem, kit, headgear, armour finish, signature equipment. This is how the project stays coherent and affordable (document 05 §6.5).

---

## 1. Base formation matrix (all states)

| Piece | Traditional glyphs (first / second player) | Gameplay role | Formation | Primary subject (reads first) | Silhouette key | Height tier | Figures, full / reduced | Evidence |
|---|---|---|---|---|---|---|---|---|
| **General** | 帥 / 將 | Confined to palace; the piece to protect | Commander, standard-bearer, drummer, two guards | Commander under the great command banner | **Tallest object on the board: the command banner** | T5 (≈ 1.1 P) | 5 / 3 | E1 kit, E3 composition |
| **Advisor** | 仕 / 士 | Palace diagonal guard | Guard officer and two guards | Officer with rank cap | **Two polearms crossed at the tips (an "X" crest)** | T2 (≈ 0.7 P) | 3 / 2 | E1 kit, E3 composition |
| **Strategist** (Elephant / Minister) | 相 / 象 | Home defence; cannot cross the river | Strategist (軍師), aide with slips, canopy attendant | Strategist holding a wooden map board | **Round parasol canopy: a disc from above** | T3 (≈ 0.8 P) | 3 / 2 | E1 role and maps; E3 canopy |
| **Chariot** | 俥 / 車 | Long-range straight mover | Chariot, four horses, three crew | Chariot box and wheels | **Two large spoked wheels and a horse team** | T3 (≈ 0.8 P) | 3 + 4 horses / 3 + 2 horses | E1 |
| **Horse** | 傌 / 馬 | Jumping piece with blocked-leg rule | Three cavalrymen | Lead rider and horse | **Horse heads and necks, riders above** | T3 (≈ 0.75 P) | 3 / 2 | E1 (Qin), E1 text + E3 (others) |
| **Crossbow unit** (Cannon) | 炮 / 砲 | Captures by jumping a screen | Commander with signal pennant, two kneeling and two standing crossbowmen | Commander's signal pennant over a row of levelled crossbows | **Signal pennant over a horizontal "comb" of crossbow prods** | T4 (≈ 0.95 P pennant) | 5 / 3 | **E1 (strongest piece)** |
| **Soldier** | 兵 / 卒 | Forward mover; sideways after the river | Squad of five (伍), melee weapons only | Squad leader | **Low dense block with spear points** | T1 (≈ 0.6 P) | 5 / 3 | E1 |

**Height tiers:** T1 ≈ 0.6 P, T2 ≈ 0.7 P, T3 ≈ 0.75–0.85 P, T4 ≈ 0.95–1.0 P, T5 ≈ 1.1 P.

**Footprint:** all geometry within radius **0.45 P** in static poses. The Chariot is the hardest fit. With the elephant gone, it is the only large formation.

**Weapon-overlap rule:** **only the Crossbow unit carries crossbows.** Soldiers and Advisors use melee weapons, so the ranged piece is unmistakable. Cavalry use bows and short weapons; Qin cavalry crossbows are omitted for the same reason, a recorded design choice (E3).

**Glyphs:** traditional glyph sets follow the **turn role**, not the state: the first player uses 帥 仕 相 俥 傌 炮 兵, the second 將 士 象 車 馬 砲 卒 (decision D17). The 相/象 glyph keeps its traditional reading on the base even though the formation is a strategist, so Xiangqi players read the board instantly.

---

## 2. State identity layer

Applied to every formation of a state. "Signature" items are the ones that must read from the gameplay camera.

| Layer | Qin 秦 | Chu 楚 | Qi 齊 | Zhao 趙 | Yan 燕 | Wei 魏 | Han 韓 |
|---|---|---|---|---|---|---|---|
| State colour (banners, base rim) | Black | Vermilion | Purple | Ivory, dark trim | Azure | Ochre-gold | Green |
| Emblem (regional script) | 秦 in Qin script | 楚 in Chu script | 齊 in Qi script | 趙 in Jin script | 燕 in Yan script | 魏 in Jin script | 韓 in Jin script |
| **Signature** | Bareheaded topknot infantry; riveted small lamellar | Black-lacquer laced lamellae with vermilion painting; painted dragon-and-phoenix shields | Light sword-and-shield infantry; purple textiles | "Hu dress" jackets, trousers and boots; mounted archers | Dark iron helmets and weapons | Heavily armoured, helmeted infantry | Large-prod elite crossbows; fine swords |
| Infantry headgear | Topknot or cloth cap | Lacquered leather helmet (some) | Cloth cap or light helmet | Fur-trimmed cap (E3) | Iron helmet | Helmet | Cloth cap or light helmet |
| Officer and commander headgear | Rank caps (terracotta types) | Tall cap (command only) | Cap with purple ribbons (E4) | Fur-trimmed cap with plume (E3/E4) | Iron helmet with crest (E3) | Helmet with crest (E3) | Rank cap (E3) |
| Shields | Few (terracotta has few) | Painted lacquer shields | Rectangular shields (E3) | Small round or none (cavalry focus) (E3) | Leather shields with iron fittings (E3) | Rectangular shields (E3) | Few (crossbow focus) |
| Evidence weight | E1 | E1/E2 | E1 text + E3 | E1 text + E3 | E1 + E3 | E1 text + E3 | E1 text + E3 |

Identity elements marked E3/E4 are proposals for historian review. None will be modelled before review (document 11, QH-02).

---

## 3. Per-piece design cards

### 3.1 General: 帥 / 將

| | |
|---|---|
| Primary subject | Commander in the finest armour of the state's kit (Qin: fine plates, patterned borders, ribbon knots; Chu: black-lacquer laced armour; Yan: iron; and so on) |
| Supporting | Standard-bearer with the great state banner; war drummer with a barrel drum on a frame; two guards (Qin: ceremonial pole weapons as in terracotta pit 3; other states: their signature polearm) |
| Reduced (3) | Commander, standard-bearer, drummer |
| Exclusions | No chair or throne. The commander stands, or kneels on a mat |
| Codex flavour | Famous generals per state (for example Bai Qi or Wang Jian for Qin, Lian Po or Li Mu for Zhao, Yue Yi for Yan, Tian Dan for Qi, Wu Qi for Wei). Archetypes, not portraits |

### 3.2 Advisor: 仕 / 士

| | |
|---|---|
| Primary subject | Middle-rank guard officer in rank cap and armour |
| Supporting | Two guards with crossed polearms (sword-spears, halberds or dagger-axes by state) |
| Silhouette | "X" crest from the crossed polearms |
| Evidence | Terracotta officer types (HR-10); state kits (§2) |

### 3.3 Strategist (軍師 / 謀士): 相 / 象 (decision D3)

| | |
|---|---|
| Primary subject | Strategist in civilian robe and cap (no armour, or a light armour vest), holding a wooden map board |
| Supporting | Aide carrying bundles of bamboo slips and a writing brush; attendant holding a round parasol canopy over the strategist |
| Pose | Kneeling on a mat with the map board (idle); rising and pointing (selected) |
| Silhouette | Round canopy disc at T3: unique on the board and readable in the top-down view |
| Evidence | Sun Bin as adviser to Tian Ji (HR-46); wooden-board maps from Fangmatan (HR-47); slips (HR-31); canopy is an interpretation (E3, U11) |
| Naming | In-world: 軍師 / 謀士. The later title 參軍 is not used in in-world text (HR-48) |
| State variation | Robe colours and patterns; cap style; map board style; canopy fabric in the state colour |
| Gameplay link | Cannot cross the river: strategists plan from behind the lines |

### 3.4 Chariot: 俥 / 車

| | |
|---|---|
| Primary subject | Chariot with rectangular box, single draught pole and two large spoked wheels |
| Crew | Driver in long charioteer armour; archer or commander on the left; halberdier on the right |
| Team | Four horses tightly yoked (full); two (reduced) |
| State variation | Fittings (Chu bladed axle caps; Qin terracotta-type fittings), lacquer and painted rails, crew kit, banner pennant |
| Evidence | Qin bronze and pit chariots (HR-16); Chu finds (HR-17); other states' finds (HR-18, V0) |
| Footprint | Hardest fit: compressed team, oriented along the move direction |

### 3.5 Horse: 傌 / 馬

| | |
|---|---|
| Primary subject | Lead cavalryman |
| Supporting | Two riders |
| Tack | Saddle pad, girth, crupper, bridle and bit; cropped mane, tied tail; **no stirrups, no horseshoes** |
| State variation | Zhao is the signature cavalry: "Hu dress" and mounted archers. Qin: terracotta cavalry type. Others: state kit on the common cavalry pattern (E3) |
| Evidence | Pit 2 cavalry (HR-21); Zhao reform (HR-41) |

### 3.6 Crossbow unit (弩兵): 炮 / 砲 (decision D4)

| | |
|---|---|
| Primary subject | Unit commander raising a signal pennant |
| Supporting | Two kneeling crossbowmen at the front, shooting, as in the terracotta kneeling archer; two standing crossbowmen at the back, spanning and loading |
| Weapons | Crossbows with bronze trigger mechanisms, bolt quivers, swords at the waist |
| State variation | **Han:** larger-prod elite crossbows (signature). **Wei:** helmeted, heavily armoured crossbowmen. **Qin:** terracotta crossbowmen. Others: state kit |
| Silhouette | Signal pennant (T4) over a horizontal row of crossbow prods |
| Evidence | Trigger mechanisms and terracotta crossbow arrays (HR-23); Wei (HR-43); Han (HR-45); Maling (HR-51) |
| Glyph note | The traditional 炮/砲 glyphs remain on the base for Xiangqi literacy |
| Exclusions | No pavises; no repeating crossbows of later types; no "bed crossbows" |

### 3.7 Soldier: 兵 / 卒

| | |
|---|---|
| Composition | One squad (伍) of five with melee weapons: squad leader (sword and spear or dagger-axe), two halberdiers or dagger-axe men, one spearman, one shield-and-sword man |
| State variation | Qin bareheaded with topknots; Chu lacquer helmets and painted shields; Qi light sword-and-shield; Wei heavy helmeted; Yan iron helmets; Zhao "Hu dress"; Han light infantry with fine swords |
| Variation within a state | Modular heads, torsos, arms and poses, so no two squads look identical (HR-14) |
| After crossing the river | Optional visual cue: formation loosens from column into a skirmish line (to be tested in the slice) |

---

## 4. Animation matrix

All animations are **presentation only**: the rules engine has already applied the move (document 07 §9). Every animation can be interrupted or skipped and snaps to the authoritative state. Default speed 1.0×; player range 0.5×–2× or instant.

| Piece | Idle (looping, subtle) | Selected | Move (target duration) | Capture: attacker | Captured: defender | Gives check | Victory / defeat |
|---|---|---|---|---|---|---|---|
| General | Banner sways; drummer taps; guards shift | Commander raises sword; drum roll | March within the palace (0.5 s per step) | Guards advance | Banner lowered; kneel; fade | — | Drums and banner raised / banner falls, figures kneel |
| Advisor | Polearms grounded | Polearms lift | Diagonal step (0.5 s) | Polearms lower to charge | Weapons laid down; kneel; fade | Polearms point at the enemy general | Salute / kneel |
| Strategist | Studies map; aide writes; canopy sways | Rises and points at the map | Diagonal two-point walk **via the eye point** (0.8 s) | Points decisively at the target; the defender yields, outmanoeuvred (no combat shown) | Slips dropped; withdraws; fades | Points across the board at the enemy general | Bows / withdraws |
| Chariot | Horses stamp; driver holds reins | Driver lifts whip; horses toss heads | Accelerate, cruise, decelerate (0.6–1.4 s by distance) | Archer draws; halberd levels | Crew dismounts; chariot abandoned; fade | Archer aims at the general | Wheel turn and salute / horses held |
| Horse | Horses shift; riders adjust | Lead horse rears slightly | Path **one orthogonal point, then one diagonal** (0.7 s) | Charge | Riders dismount and lead horses away; fade | Lead rider points | Circle and halt |
| Crossbow unit | Bolts checked; commander scans | Pennant raised; crossbows level | Unit advances in step (0.6–1.4 s) | **Pennant drops; volley lofted over the screen piece** to the target, then the unit advances to the target along a path that **bulges around the screen piece** | Crossbows lowered and set down; fade | Crossbows level at the enemy general | Pennant waved / crossbows grounded |
| Soldier | Weight shifts | Leader raises spear | March step (0.5 s) | Spears lower and advance | Kneel; weapons grounded; fade | — | Weapons raised / kneel |

### 4.1 Shared animation rules

1. **No visual overlap of formations.** Only a Crossbow-unit capture passes another piece, so the path planner bulges its route around the screen piece.
2. **Defender before attacker.** The captured formation starts yielding before the attacker arrives.
3. **No gore.** Yielding, kneeling, withdrawing and fading only. No blood, no bodies. Rating target around PEGI 7 / ESRB E10+ (D10, approved).
4. **Rule-teaching motion.** Horse and Strategist paths visibly pass through the leg or eye point.
5. **Facing.** Formations turn to the move direction, then settle facing the enemy.
6. **Crowd desynchronisation.** Idle loops are offset and varied per figure.

---

## 5. Ownership and readability checklist (per formation variant)

- [ ] Piece type identifiable from silhouette alone (greyscale, gameplay camera, 1080p)
- [ ] Owner identifiable **without colour** in every state pairing, including same-state matches: turn-role base band, emblem, silhouette
- [ ] State recognisable from its signature trait (target in document 11, QV-11)
- [ ] Traditional glyph legible on the base from the default camera
- [ ] Fits the 0.45 P footprint in all static poses
- [ ] Height within its tier
- [ ] Primary subject visually dominant
- [ ] Every element has an evidence class in the register
- [ ] No item from the anachronism exclusion list (document 04 §6)
