# 04 — Historical Research and Reference Register

| | |
|---|---|
| Document status | **Draft v0.1, submitted for approval** |
| Date | 2026-11-20 |
| Owner | Historical research (Game Director sign-off) |
| Gate | Historical design approval gate (before any final asset production) |

---

## 1. Method

### 1.1 Evidence hierarchy

Sources are ranked as required by the project brief:

1. Museum collections and object catalogues
2. Archaeological excavation reports
3. Academic publications and university research
4. Historical military studies
5. Reputable reference works
6. Documented surviving artefacts
7. Carefully attributed reconstructions

Popular websites, game art, film and television costume, and "Romance"-tradition imagery are **not** admissible as evidence. They may only be cited as examples of what to avoid.

### 1.2 Classification used throughout this package

**Evidence class** (what kind of support a design element has):

| Class | Meaning | Use in design |
|---|---|---|
| **E1** | Direct evidence: excavated artefact, period depiction, or primary text | May be depicted as historical |
| **E2** | Scholarly reconstruction or interpretation in academic work | May be depicted; Codex text says "reconstructed" |
| **E3** | Reasoned design interpretation, extrapolated from E1/E2 close in time and place | Allowed; Codex text says "interpretation" |
| **E4** | Artistic invention or game convention, with no historical support | Allowed only for non-identity details, or with explicit approval; never presented as history |

**Confidence**: High, Medium or Low. This is our judgement of how well the evidence supports the specific design use.

**Verification status in this session**:

| Mark | Meaning |
|---|---|
| **V2** | Source located and its relevant content confirmed online during this research pass |
| **V1** | Source existence or bibliographic details confirmed, or content confirmed only by a secondary source; primary content not yet inspected |
| **V0** | Not yet verified in this session (from domain knowledge). **Must be checked against a primary source or critical edition before design lock.** |

> **Research limitation, stated openly:** this environment's network policy blocked the Chinese Text Project (ctext.org) and Wikisource. Classical-text references marked V0 or V1 are cited by standard chapter references to the received texts. They must be checked against a critical edition (for example, the Zhonghua Shuju punctuated *Shiji*) during Milestone 1. No quotation in this package should be used in shipped content until it is V2.

---

## 2. Candidate historical periods

The setting must give every Xiangqi piece a plausible military counterpart, and it must not force anachronistic combinations. The two most restrictive pieces are the **Horse**, which needs true cavalry and therefore a date after about 300 BCE, and the **Chariot**, which needs chariots still fielded and therefore a date before about 150 BCE. Together they bracket the viable window tightly.

| Period | Dates | Horse (cavalry) | Chariot | Cannon (artillery) | Elephant / Minister | Archaeological base | Link to Xiangqi | Anachronism risk | Verdict |
|---|---|---|---|---|---|---|---|---|---|
| A. Spring and Autumn | 770–476 BCE | ✗ No true cavalry | ✔✔ Chariot apogee | ✗ Not attested | Chu "torch elephants" 506 BCE (E1 text) | Moderate | Weak | High (cavalry) | **Rejected** |
| B. Late Warring States: Qin vs Chu | c. 300–221 BCE | ✔ Cavalry spreads after c. 307 BCE; Qin cavalry figures | ✔ Still fielded | ◐ Traction trebuchet in Mohist texts (E2) | ✗ Black's 象 would fall to Qin, which has no elephant evidence | Very strong | Indirect | Low–Medium | **Strong alternative** |
| C. Chu–Han Contention: Han vs Western Chu | 206–202 BCE | ✔ Cavalry corps attested on both sides | ✔ Attested | ◐ Same technology base as B | ✔ Red 相 = Han chancellor; Black 象 = Chu elephant (interpretive) | Strong, by bracketing (see §3.2) | **Direct**: the board's 楚河漢界 | Low–Medium | **Recommended** |
| D. Mature Western Han | c. 154–87 BCE | ✔✔ Cavalry dominant | ◐ Chariots marginal | ◐ | ◐ | Very strong | Weak | Low | Not recommended (weak Chariot) |
| E. Three Kingdoms | 220–280 CE | ✔ | ✗ Largely obsolete | ◐ | ✗ | Moderate, heavily overlaid by *Romance* iconography | Weak | High | **Rejected** |
| F. Northern Song | 960–1127 CE | ✔ | ✗ War carts only | ✔✔ Traction trebuchets, early gunpowder | ✗ | Strong (illustrated military manual of 1044) | Strong: modern Xiangqi took shape around this period | Low | Viable future army skin, not the core setting |

---

## 3. Recommended setting

### 3.1 Recommendation

**The Chu–Han Contention (206–202 BCE), centred on the Xingyang–Chenggao front and the Hong Canal partition of 203 BCE, built on late Warring States and Qin material culture.**

- **Red = Han (漢)**: the army of the King of Han.
- **Black = Western Chu (西楚)**: the army of the Hegemon-King of Western Chu.

Rationale:

1. **The board itself names this war.** The traditional river inscription 楚河漢界 ("Chu River, Han Border") refers to the Hong Canal (鴻溝) line. The *Shiji* records that the two sides agreed to divide the realm along it (HR-01). The setting and the board share one story.
2. **Every piece has a defensible counterpart.** Cavalry and chariots are both attested in this war (HR-18 to HR-20). The traditional glyphs map naturally: Red's 相 ("minister") becomes the Han chancellor's office (HR-30), and Black's 象 ("elephant") becomes a southern Chu elephant unit (an interpretation, HR-28/29).
3. **It is the closing act of the Warring States world.** Both armies were raised, trained and equipped in the Warring States tradition. The Chu side is the restored Warring States kingdom of Chu. The project's "Warring States" identity is preserved.
4. **Exceptional archaeological evidence.** The Qin Terracotta Army was buried about four years before the war began.

If you prefer a setting strictly inside 475–221 BCE, option **B (Qin vs Chu, c. 230–223 BCE)** is the alternative. Its main weakness is that Black's 象 (elephant) would belong to Qin, for which there is no elephant evidence. That piece would become an E4 invention or need an asymmetric reinterpretation. See decision D1 in document 10.

### 3.2 "Bracketing" evidence approach

Few military artefacts can be dated precisely to 206–202 BCE. Instead, the design relies on evidence that brackets the period:

| Bracket | Sources | Used mainly for |
|---|---|---|
| Lower (≤ 210 BCE) | Qin Terracotta Army pits 1–3, Qin bronze chariots, stone armour pit K9801, Qin weapons | Han side (Qin-trained Guanzhong armies, ex-Qin specialists) |
| Contemporary region | Late Warring States Chu tombs: Zeng Hou Yi (c. 433 BCE, Chu client state), Baoshan, Mashan, Jiuliandun; Chu lacquer; *Chu Ci* poetry | Chu side |
| Upper (c. 2nd century BCE) | Early Western Han figurine armies: Yangjiawan (Xianyang) and Shizishan (Xuzhou, the Han-dynasty kingdom of Chu at Pengcheng, Xiang Yu's former capital) | Cross-check: continuity confirms an element; anything only attested here is excluded |

**Rule:** an element must be attested in at least one bracket and not contradicted by the others. Elements first attested after about 150 BCE are excluded (§6).

### 3.3 Side identities

| Aspect | Red: Han 漢 | Black: Western Chu 西楚 |
|---|---|---|
| Commander archetype | King of Han's command group (Liu Bang archetype; no portrait claimed) | Hegemon-King's command group (Xiang Yu archetype; no portrait claimed) |
| Military lineage | Guanzhong and Ba-Shu levies, ex-Qin soldiers and specialists | Chu and Jiangdong troops, Warring States Chu tradition |
| Visual lineage | Qin Terracotta Army typology | Chu lacquer, Zeng Hou Yi armour, Chu tomb finds |
| Colour basis | Red banners at Liu Bang's rising in 209 BCE (*Shiji*, Annals of Gaozu; HR-02). Caveat: the early Han court is said to have kept the Qin water-virtue colour, black (HR-03) | **No securely attested banner colour.** Black follows Xiangqi convention and the popular "Red Han, Black Chu" tradition, expressed through Chu's black-ground lacquer aesthetic (E1, HR-05). Caveat: some scholars propose a Chu preference for red |
| Elephant piece (相 / 象) | 相: the chancellor's office (Xiao He archetype) | 象: elephant unit (interpretive) |
| Signature silhouette cues | Bareheaded infantry with topknots; officer caps; riveted lamellar | Lacquered leather helmets on some troops; painted dragon-and-phoenix shields; large laced lamellae |

**Design consequence:** ownership must never rely on banner colour alone. Colour is a game convention here. Silhouette, equipment and material language carry the historical identity (see document 05).

---

## 4. Research findings by topic

Each topic records what the evidence shows, what has to be interpreted, and the resulting design decision. Register IDs (HR-xx) refer to §8.

### 4.1 Military organisation and hierarchy

- Warring States and Qin armies were organised in nested units, starting from the five-man squad (伍) and ten-man file (什). Merit ranks followed the Qin twenty-rank system introduced under Shang Yang. Excavated Qin legal texts such as the Shuihudi slips document Qin administrative and military law (E1/E2; HR-31).
- Battlefield command used **drums to advance and metal instruments to withdraw**, as stated in *Xunzi*, "Debate on Military Affairs" (議兵) (E1 text, V0; HR-33).
- **Design:** the Soldier formation is one five-man squad (伍), and the five Soldier pieces per side echo this. Rank is shown through headgear and armour typology (HR-10). The general's formation includes a drummer.

### 4.2 Infantry

- **Han:** the Terracotta Army shows armoured and unarmoured infantry, kneeling and standing crossbowmen, and close-combat troops with polearms (E1; HR-09, HR-23, HR-24). Clothing: knee-length robes, trousers, leg wraps or shin guards, square-toed shoes. Most infantry figures are **bareheaded**, with hair dressed in a topknot or a cloth cap (E1; HR-11).
- **Chu:** fewer figurative sources survive. Chu armour was lacquered rawhide. *Xunzi* describes Chu armour of shark skin and rhinoceros hide (V0), and the *Chu Ci* poem "Hymn to the Fallen" (國殤) describes warriors who "grasp Wu dagger-axes and wear rhinoceros-hide armour" (V2) (E1 text; HR-06). Excavated Chu tombs supply armour, shields, weapons and bows (E1; HR-07, HR-08, HR-25).
- **Interpretation needed:** Chu infantry dress details (E3) are extrapolated from Chu tomb figurines and textiles plus general Warring States practice.
- **Design:** Han squads mix armoured spearmen, halberdiers and a crossbowman. Chu squads carry painted shields, dagger-axes or halberds and bows, and some wear lacquered leather helmets. The difference in silhouette is the point: Han heads are bare, while some Chu heads are helmeted.

### 4.3 Cavalry

- Cavalry spread in the late 4th century BCE. Terracotta pit 2 cavalrymen wear short tunics, short armour vests without shoulder guards, and close-fitting caps tied under the chin. Each holds the reins of a saddled horse **without stirrups** (E1; HR-21).
- In the Chu–Han war, Liu Bang formed a cavalry corps under Guan Ying, reportedly around former Qin cavalrymen (E1 text; V1; HR-19). Xiang Yu broke out of Gaixia with about 800 horsemen (E1 text; V0; HR-20).
- **Interpretation needed:** Chu cavalry equipment is not directly attested (E3). It will follow the general late Warring States cavalry pattern, with Chu materials and decoration.
- **Design:** three riders per Horse formation. Saddle pad, girth, crupper and bridle with bit; **no stirrups, no horseshoes**. Manes cropped and tails tied, as on the terracotta horses (V0).

### 4.4 Armour and helmets

- **Han / Qin type (E1):** lamellar armour made of small plates fastened with rivets and cords, as sculpted on the terracotta figures. The type varies by role: charioteers wear long armour with arm and hand guards and a high collar; infantry wear chest and back armour with shoulder guards; cavalry wear short vests; officers wear finer plates with patterned borders and ribbon knots (HR-10, HR-12).
- **Helmets existed** even though the terracotta infantry are bareheaded. Pit K9801 contained dozens of stone armour suits and helmets made of plates linked with bronze wire (E1, V2; HR-11).
- **Chu type (E1):** the Zeng Hou Yi tomb (c. 433 BCE) yielded 13 suits of lacquered leather armour. The Hubei Provincial Museum displays a reconstruction worn by a warrior model (E1 + E2; V2; HR-07).
- **Design:** the two armour languages are deliberately distinct. Han armour has small riveted plates with coloured cords. Chu armour has larger laced lacquered lamellae with black-ground lacquer and red details.

### 4.5 Weapons

- **Common to both (E1):** bronze swords (劍), dagger-axes (戈), spears (矛), halberds combining the two (戟), long sword-spears (鈹), crossbows with bronze trigger mechanisms, bows, and pyramidal bronze arrowheads. Pit 3, the command unit, contains guards equipped with ceremonial pole weapons (殳) (V0; HR-24).
- **Chu specific (E1):** multi-blade halberds (Zeng Hou Yi), fine Chu bronze swords, and painted shields (HR-08, HR-25). *Xunzi* also mentions Chu iron weapons (V0).
- **Appearance:** living weapons were bright bronze or dark iron. The green patina seen in museums comes from burial. A 2019 study also showed that surface chromium on Terracotta Army bronzes is contamination from lacquer, not an ancient anti-rust technology (E2, V2; HR-13).
- **Design:** weapons are rendered as new polished bronze. Weapon allocation follows formation roles (document 06). Romance-tradition weapons such as the 偃月刀 "guandao" are excluded.

### 4.6 Command and officers

- Terracotta officer figures show a rank typology. Generals wear distinctive long caps and elaborate armour with ribbon knots; middle- and junior-ranking officers wear lesser caps; ordinary soldiers are bareheaded or wear cloth caps (E1/E2; V0; HR-10).
- **Chu:** literary sources describe tall caps among the Chu elite, such as the "cloud-cutting" cap in the *Chu Ci* poem "Crossing the River" (涉江) (E1 text, V0). A Chu silk painting of a man riding a dragon shows a tall cap (E1, V0; HR-37). Whether such caps were worn in the field is uncertain (E3).
- **Design:** the General and Advisor formations use headgear and armour finish for rank. Chu officers wear a tall cap only in command (non-melee) roles, which is a labelled interpretation.

### 4.7 Chariots

- **Han (E1):** Qin chariot construction is known in detail from the bronze chariots and horses (Nos. 1 and 2) and the wooden chariots in pits 1–3. Both show a single draught pole, two large wheels and a four-horse team. Pit chariots carried a crew of three: driver, left-side archer or commander, and right-side halberdier (V1; HR-16).
- **Chu (E1):** Chu chariot finds include the Zeng Hou Yi chariot fittings, among them bladed axle caps (V0), and Chu chariot-and-horse pits such as Jiuliandun and Xiongjiazhong (V0). The "Hymn to the Fallen" describes chariot hubs clashing in battle (V2; HR-17).
- **In this war (E1 text):** Xiahou Ying served as Liu Bang's charioteer, and Liu Bang escaped from Pengcheng (205 BCE) by chariot (V0; HR-18). Chariots were declining relative to cavalry and infantry but were still fielded.
- **Design:** a four-horse chariot with three crew for both sides. The Chu variant uses Chu fittings and lacquer decoration. The horse team is tightly compressed to fit the footprint (document 05, §6).

### 4.8 Artillery (the Cannon piece)

- **Gunpowder artillery is anachronistic** for this setting by more than a thousand years and is excluded.
- Black's traditional glyph is **砲**, written with the stone radical, which denotes a stone-throwing engine. This fits a **traction trebuchet** (man-powered lever-sling artillery).
- **Evidence:** the Mohist city-defence chapters of the *Mozi* (4th–3rd century BCE) describe siege engines, including one called 籍車, which scholars interpret as a traction trebuchet. The key works are Robin Yates' studies and Needham and Yates' *Science and Civilisation in China*, vol. 5 pt 6 (E2; V1; HR-26).
- **Interpretation needed:** use of trebuchets in the 206–202 BCE field war is not documented (E3). Detailed Chinese trebuchet illustrations come only from the Song military manual of 1044, which is about 1,250 years later. Copying them would import anachronistic detail (HR-27).
- **Design:** a minimal single-beam traction trebuchet on a simple timber frame, with sling and pull ropes, and four pullers plus a loader. No Song-specific hardware. It is the same machine class for both sides, differing only in finish and decoration. Its indirect fire also fits the Cannon's rule: the capture animation lobs the projectile **over** the screen piece (document 06).

### 4.9 The Elephant / Minister piece

The traditional glyphs differ by side: Red **相** ("minister, chancellor") and Black **象** ("elephant"). The design follows the glyphs rather than forcing one interpretation on both armies.

- **Han 相: the Chancellor (E1 for the role, E3 for the visual).** When Han forces entered Xianyang, Xiao He secured the Qin statutes, maps and registers. He later managed supply from Guanzhong as Chancellor (*Shiji*, Hereditary House of Chancellor Xiao; V0; HR-30). This suits the piece's rules well: the Elephant/Minister cannot cross the river and defends home territory, much as Xiao He kept the home base and supply running. The formation shows a chancellor with bamboo-slip registers and a map case, a scribe, and two guards.
- **Chu 象: the war elephant (E1 precedent, E4 for this war).** The *Zuo Zhuan* records that in 506 BCE the King of Chu drove elephants carrying torches against the Wu army (定公四年; E1 text, V2 via scholarly discussion; HR-28). Elephants still ranged widely across southern and central China in antiquity (Elvin 2004; E2, V1; HR-29). **There is no evidence of elephants in Xiang Yu's army.** The Chu elephant is a labelled creative interpretation built on a documented Chu precedent.
- **Design constraints:** no howdah and no elephant armour, both of which belong to later South and South-East Asian traditions. A mahout and two handlers on foot, carrying torches and goads.
- **Alternative, if the interpretive elephant is rejected:** a symmetric "Minister" formation for Chu (a Chu official with retinue). The Elephant piece would then lose its traditional identity for Black. See decision D3.

### 4.10 Banners, insignia and colour

- Military textiles do not survive from the battlefields. Banner forms come from period depictions: Warring States bronze vessels inlaid with battle and siege scenes show pennants on poles with feather or tassel finials (E1 depiction, V0; HR-32).
- Colour symbolism: the Qin water-virtue decree favoured black for clothing and banners after unification. This is recorded in the *Shiji* (V2 via text snippet), but its historicity is debated in modern scholarship (E2; HR-04).
- **Terracotta polychromy (E2):** the figures were originally painted in a wide range of colours, not in uniform colours. Studied pigments include cinnabar red, malachite green, azurite blue, "Han purple", bone white and carbon black (V0; HR-15). There is **no evidence for faction uniforms in the modern sense**.
- **Design:** clothing colours vary within each army, as the polychromy evidence shows. Faction identity is carried by banners (a game convention for colour), lacquer finishes, shield art and silhouette. In-world inscriptions use period scripts (Qin seal and clerical styles for Han; Chu script for Chu, E2). The UI uses modern scripts.

### 4.11 Music and signals (audio research)

- Drums advance and metal instruments withdraw (*Xunzi*; HR-33). The bronze chime bells of Zeng Hou Yi (曾侯乙編鐘), with their surviving tuning, give an authentic period timbre reference (E1; V1; HR-34).
- **Design:** the drum motif marks advance and moves; a metal bell or gong motif marks withdrawal and undo. The music palette uses period instruments: bells, chime stones, drums, zither, mouth organ and vessel flute. No modern "Chinese film" clichés such as erhu-led orchestral pop. Erhu-type instruments arrived later and are excluded as signature instruments.

### 4.12 Battlefield environment and architecture

- **Site:** the Guangwu Mountain front at Xingyang, Henan. Here the Han and Chu armies faced each other across the Hong Canal ravine, and the remains of two facing walled camps (漢霸二王城, the "twin cities of Han and the Hegemon") are traditionally identified (E1 site, V0; HR-35). The site matches the board's geometry: two strongholds facing each other across a water barrier.
- **Materials (E1):** rammed earth (夯土) walls and platforms, timber-frame gate towers with grey ceramic roof tiles and round eave-tile ends (瓦當), palisades, loess terrain (HR-36).
- **Design:** the river is the Hong Canal. The two palaces read as rammed-earth fortified command enclosures, kept low so they never obstruct pieces. The backdrop shows the loess hills of Guangwu and the facing fortresses.

### 4.13 The game itself: avoiding a meta-anachronism

Xiangqi was not played in 203 BCE. The earliest literary descriptions of a related "elephant game" are commonly traced to the Tang dynasty (for example, Niu Sengru's *Xuanguai lu*). The Cannon piece and the modern form are generally associated with the Song, and a Northern Song tomb at Luoyang is reported to have yielded a set of pieces (V1; HR-38). When the 楚河漢界 inscription became standard is uncertain. In-game Codex text must say plainly that the game is a later abstraction set in this war, not a claim about ancient play.

---

## 5. Historical uncertainties (explicit register)

| ID | Uncertainty | Impact | Handling |
|---|---|---|---|
| U1 | Chu banner and army colours unknown | Black-side identity | Black is labelled a game convention; identity via lacquer, shields, silhouette |
| U2 | Han ritual colour: red banners in 209 BCE versus the early-court water virtue (black) | Red-side justification | Red is justified by the Annals of Gaozu; the caveat is noted in the Codex |
| U3 | No evidence of elephants in the Chu–Han war | Black Elephant piece | Labelled interpretation from the 506 BCE Chu precedent; alternative offered (D3) |
| U4 | Form and field use of traction trebuchets in the 3rd century BCE | Cannon piece | Minimal generic design; labelled reconstruction |
| U5 | Chu cavalry equipment | Black Horse piece | General late Warring States pattern plus Chu finishes (E3) |
| U6 | Chu infantry dress | Black Soldier, Advisor | Extrapolated from Chu tomb figurines and textiles (E3); historian review |
| U7 | Scale of chariot use in 206–202 BCE | Chariot piece | Attested in texts; no claim about numbers |
| U8 | Banner shapes and finials | All formations with banners | Based on period vessel depictions (E1 depiction); simple forms |
| U9 | Appearance of historical individuals | General, Han 相 | Archetypes, not portraits; names only in Codex flavour text |
| U10 | Reconstructions of terracotta polychromy vary | Palette | Use published pigment ranges; avoid single-source "definitive" colours |
| U11 | Whether Chu tall caps were worn in a military context | Chu officers | Command (non-melee) figures only; labelled interpretation |
| U12 | Origin of Xiangqi and of the board inscription | Codex text | Stated as uncertain |

---

## 6. Anachronism exclusion list

These elements are **prohibited** in all assets for this setting unless the art direction is formally changed:

| Excluded element | Reason |
|---|---|
| Stirrups | Earliest Chinese evidence is several centuries later (4th century CE) |
| Horseshoes | Not in use |
| Gunpowder weapons; "cannon" as a gun barrel | Gunpowder is first documented about a millennium later |
| Counterweight trebuchet | Reached China in the 13th century CE |
| Ring-pommel single-edged sabre (環首刀) as the standard sidearm | Becomes standard later in the Han; the sword (劍) is the sidearm |
| Tang, Song, Ming or Qing armour (e.g., 明光鎧, plumed later helmets) | Later periods |
| *Romance of the Three Kingdoms* iconography (guandao, flowing-beard "Guan Yu" generals) | Literary tradition, more than a millennium later |
| Japanese armour or helmet influences | Wrong culture |
| Howdahs and elephant armour | Later and foreign traditions |
| Yellow imperial dragon banners; Qing-style triangular pennants | Later periods |
| Paper documents | Bamboo and wooden slips and silk are the period media |
| Chairs and folding stools | People sat on mats and platforms; the folding stool (胡床) arrived later |
| Weathered green bronze and unpainted grey "terracotta" looks on living troops | Museum condition, not period appearance |
| Modern Chinese characters on in-world objects | In-world text uses period scripts; modern scripts only in UI |

---

## 7. Reference register

Columns follow the project brief, with **Verif.** added (§1.2).

| ID | Design element | Proposed period | Reference | Evidence | Conf. | Verif. | Design decision |
|---|---|---|---|---|---|---|---|
| HR-01 | Overall setting: Hong Canal partition | 203 BCE | *Shiji* 7, Annals of Xiang Yu (項羽本紀); secondary: People's Daily, 2014 (variant wording "鴻溝而西者為漢") | E1 text | High | V1 | Adopt Chu–Han setting; the river is the Hong Canal |
| HR-02 | Red = Han | 209–202 BCE | *Shiji* 8, Annals of Gaozu (高祖本紀): white-serpent / Red Emperor's son episode and red banners | E1 text | Med | V1 (episode confirmed in a teaching edition; banner phrase still to confirm) | Red banners and base rim for Han |
| HR-03 | Early Han court colour (water virtue, black) | 206 BCE onward | *Shiji* 96, Biography of Chancellor Zhang (張丞相列傳) | E1 text | Med | V0 | Recorded caveat; Han not shown in black |
| HR-04 | Qin water virtue, black banners; scholarly debate | 221 BCE | *Shiji* 6, Annals of Qin Shihuang (26th year); debate summarised at aisixiang.com (Kurihara Tomonobu; Chen Kanli) | E1 text + E2 | Med | V2 | Background for option B only |
| HR-05 | Black = Chu (convention); Chu black-ground lacquer | Warring States–early Han | Popular tradition; Chu lacquer (Zeng Hou Yi lacquer objects, Hubei Provincial Museum, Google Arts & Culture story) | E4 (convention) + E1 (lacquer) | Low as history; High for lacquer | V1 | Black as declared convention; lacquer aesthetic carries Chu identity |
| HR-06 | Chu armour material: rawhide, rhinoceros hide | Warring States | *Xunzi* 15 (議兵); *Chu Ci*, "Hymn to the Fallen" (國殤), chinaheritage.net edition | E1 text | Med | V2 (國殤) / V0 (*Xunzi*) | Chu armour: dark lacquered rawhide lamellae |
| HR-07 | Chu lacquered leather armour construction | c. 433 BCE (lower context) | Zeng Hou Yi tomb: 13 armour suits; armoured-warrior model with replica armour (Hubei Provincial Museum via Google Arts & Culture); Univ. of Washington *Chinese Civilization* page; excavation report *Zeng Hou Yi mu* (Wenwu, 1989) | E1 + E2 | High | V2 | Base the Chu armour kit on the Zeng Hou Yi reconstruction |
| HR-08 | Chu painted shields | Warring States | Lacquered shield with dragon and phoenix patterns, Hubei Provincial Museum (Google Arts & Culture) | E1 | High | V2 | Chu shield shape and motif family |
| HR-09 | Han infantry kit and typology | ≤ 210 BCE | Terracotta Army pits 1–3 (Emperor Qinshihuang's Mausoleum Site Museum); UNESCO World Heritage listing no. 441 | E1 | High | V1 | Han infantry, crossbowmen, officers per terracotta types |
| HR-10 | Rank shown by headgear, armour finish, ribbon knots | ≤ 210 BCE | Terracotta general and officer figures; J. Portal (ed.), *The First Emperor: China's Terracotta Army* (British Museum Press, 2007) | E1/E2 | High | V0 | Rank system in General and Advisor formations |
| HR-11 | Bareheaded infantry; helmets exist | ≤ 210 BCE | Terracotta figures; stone armour and helmets of pit K9801 (China Daily, 23 Dec 2013) | E1 | High | V2 | Han infantry bareheaded with topknots; helmets only where justified |
| HR-12 | Armour types by role | Warring States–Qin | A. E. Dien, "A Study of Early Chinese Armor", *Artibus Asiae* 43 (1981–82); A. E. Dien, "Warring States Armor and Pit Three at Qin Shihuangdi's Tomb", *Early China* | E2 | High | V1 | Armour variants per formation role |
| HR-13 | Bright bronze; no "chrome plating" myth | ≤ 210 BCE | M. Martinón-Torres et al., *Scientific Reports* 9:5289 (2019); UCL news release | E2 | High | V2 | Weapons rendered as new bronze; Codex avoids the myth |
| HR-14 | Modular production as a model for asset variation | ≤ 210 BCE | L. Ledderose, *Ten Thousand Things: Module and Mass Production in Chinese Art* (Princeton UP, 2000) | E2 | High | V1 | Asset variation system modelled on the terracotta modular kit |
| HR-15 | Polychromy and pigments | ≤ 210 BCE | Published pigment studies of Terracotta Army polychromy (cinnabar, malachite, azurite, Han purple, bone white, carbon black) | E2 | Med | V0 | Palette ranges and paint-mask variation |
| HR-16 | Han chariot construction and harness | ≤ 210 BCE | Qin bronze chariots Nos. 1 and 2 (excavated 1980); terracotta pit chariots | E1 | High | V1 | Han chariot model, four-horse team, three crew |
| HR-17 | Chu chariot variant | Warring States | Zeng Hou Yi chariot fittings (bladed axle caps); Chu chariot pits (Jiuliandun, Xiongjiazhong); "Hymn to the Fallen" | E1 | Med | V0 (finds) / V2 (poem) | Chu chariot fittings and decoration |
| HR-18 | Chariots in the Chu–Han war | 206–202 BCE | *Shiji* 95 (樊酈滕灌列傳: Xiahou Ying as charioteer); Annals of Gaozu (flight from Pengcheng, 205 BCE) | E1 text | Med | V0 | Justifies the Chariot piece |
| HR-19 | Han cavalry corps | 205 BCE onward | *Shiji* 95 (Guan Ying's cavalry; former Qin cavalrymen) | E1 text | Med | V1 (Guan Ying's "langzhong cavalry" confirmed via secondary source) | Han Horse formation |
| HR-20 | Chu cavalry | 202 BCE | *Shiji* 7 (Gaixia breakout with c. 800 riders) | E1 text | Med | V0 | Chu Horse formation (equipment E3) |
| HR-21 | Horse tack without stirrups | ≤ 210 BCE | Terracotta pit 2 cavalry horses (saddle, girth, crupper, bridle) | E1 | High | V0 | Tack design; no stirrups, no horseshoes |
| HR-22 | Early Western Han figurine armies (upper bracket) | c. 2nd century BCE | Yangjiawan figurines (Xianyang); Shizishan figurines (Xuzhou; tomb of Liu Wu, King of Chu of the Han) | E1 | High | V2 / V1 | Cross-check of details; later-only elements excluded |
| HR-23 | Crossbows | ≤ 210 BCE | Terracotta bronze trigger mechanisms; kneeling and standing archer figures | E1 | High | V0 | Crossbowmen in Han Soldier and Cavalry formations |
| HR-24 | Swords, dagger-axes, halberds, spears, sword-spears, ceremonial poles | ≤ 210 BCE | Terracotta pits (pit 3 command guard with 殳) | E1 | High | V0 | Weapon allocation per formation |
| HR-25 | Chu weapons | Warring States | Zeng Hou Yi multi-blade halberds; Chu bronze swords (e.g., Wangshan tomb no. 1, Jiangling) | E1 | High | V0 | Chu weapon set |
| HR-26 | Traction trebuchet | 4th–3rd century BCE | *Mozi* city-defence chapters (籍車); R. D. S. Yates, studies of late Zhou siege engines (1982); J. Needham & R. D. S. Yates, *Science and Civilisation in China* vol. 5 pt 6 (Cambridge UP, 1994); secondary: Wikipedia, "Chinese siege weapons" | E2 | Low–Med | V1 | Cannon = minimal traction trebuchet |
| HR-27 | Later trebuchet illustrations | 1044 CE (anachronistic) | *Wujing Zongyao* | E1 for the Song only | — | V0 | Mechanics sanity check only; no Song details copied |
| HR-28 | Chu military use of elephants | 506 BCE | *Zuo Zhuan*, Duke Ding year 4 (王使執燧象以奔吳師); Huang Sheng-song, *Tamkang Chinese Literature Bulletin* 52 (2025) on the reading of 執 | E1 text (single event) + E2 | Low | V2 (passage via scholarly article) | Chu Elephant = labelled interpretation |
| HR-29 | Elephant range in early China | Antiquity | M. Elvin, *The Retreat of the Elephants: An Environmental History of China* (Yale UP, 2004) | E2 | Med | V1 | Plausibility of elephants in Chu lands |
| HR-30 | Han chancellor's role | 206–202 BCE | *Shiji* 53, Hereditary House of Chancellor Xiao (蕭相國世家) | E1 text | High | V0 | Han 相 formation: chancellor with slip registers and maps |
| HR-31 | Writing media and Qin law | Qin | Shuihudi Qin bamboo slips (excavated 1975); Liye Qin slips | E1 | High | V0 | Documents as slips and silk; no paper |
| HR-32 | Banner forms; battle depictions | Warring States | Bronze vessels with inlaid battle scenes (e.g., the Baihuatan *hu*, Sichuan Museum) | E1 depiction | Med | V0 | Pennants with feather or tassel finials |
| HR-33 | Command signals | Warring States | *Xunzi* 15 (聞鼓聲而進，聞金聲而退) | E1 text | High | V0 | Drum = advance cue; metal = withdraw / undo cue |
| HR-34 | Period instruments | c. 433 BCE | Zeng Hou Yi chime bells (Hubei Provincial Museum) | E1 | High | V1 | Audio palette and tuning reference |
| HR-35 | Battlefield site | 203 BCE | Guangwu Mountain twin camps (漢霸二王城), Xingyang; Hong Canal ravine | E1 site | Med | V0 | Environment layout: Han stronghold west, Chu east, canal between |
| HR-36 | Architecture and materials | Qin–early Han | Qin Xianyang palace sites; rammed earth; eave tiles | E1 | High | V0 | Palaces as rammed-earth enclosures; gate towers in backdrop |
| HR-37 | Chu dress and tall caps | Warring States | *Chu Ci*, "Crossing the River" (涉江); silk painting "Man Riding a Dragon" (Hunan Museum); Mashan tomb no. 1 silks | E1 | Med | V0 | Chu officer silhouette and textile patterns |
| HR-38 | Origins of Xiangqi | Tang–Song | Niu Sengru, *Xuanguai lu*; Northern Song piece set from Luoyang; H. J. R. Murray, *A History of Chess* (1913) | E1/E2 | Med | V1 | Codex: the game is a later abstraction |
| HR-39 | Modern Xiangqi rules | Current | World Xiangqi Federation rules (worldmindgames.net); "Complete Implementation of WXF Chinese Chess Rules", arXiv:2412.17334 | E1 (rules) | High | V1 | Ruleset baseline (document 02, §5) |
| HR-40 | Han military cartography as a UI motif | 168 BCE | Mawangdui "Garrison Map" (駐軍圖), Hunan Museum | E1 | Med | V0 | Map-style UI elements (minimap, codex maps) |

---

## 8. Bibliography and links

URLs listed here were returned by searches in this session unless marked otherwise. Museum images are copyrighted and are **for internal reference only**. None may be shipped or published without a licence.

**Primary texts (critical editions to be consulted in Milestone 1)**

- Sima Qian, *Shiji* (史記), ch. 6, 7, 8, 53, 95, 96. Recommended edition: Zhonghua Shuju punctuated edition. Online: Chinese Text Project, https://ctext.org/shiji (blocked from this environment; to verify).
- *Xunzi* (荀子), ch. 15 "Debate on Military Affairs" (議兵). English: E. L. Hutton (trans.), *Xunzi: The Complete Text* (Princeton UP, 2014).
- *Chu Ci* (楚辭): "Hymn to the Fallen" (國殤): https://chinaheritage.net/journal/essays/sub-essays/hymn-to-the-fallen/ ; "Crossing the River" (涉江).
- *Zuo Zhuan* (左傳), Duke Ding year 4.
- *Mozi* (墨子), city-defence chapters (備城門 and following).
- Annals of Qin Shihuang (Wikisource): https://zh.wikisource.org/zh-hans/%E7%A7%A6%E5%A7%8B%E7%9A%87%E6%9C%AC%E7%BA%AA

**Archaeology and museums**

- Zeng Hou Yi armoured warrior model, Hubei Provincial Museum: https://artsandculture.google.com/asset/model-of-an-armored-warrior/6AF_ZGfGXJ2E2A
- Lacquered shield with dragon and phoenix patterns: https://artsandculture.google.com/asset/lacquered-shield-with-patterns-of-dragons-and-phoenixes/mgFq5NXcxjpmcw
- Tomb of Marquis Yi of Zeng, University of Washington: https://depts.washington.edu/chinaciv/archae/2marmain.htm
- Stone armour pit K9801 (China Daily, 2013): https://europe.chinadaily.com.cn/culture/2013-12/23/content_17191062.htm
- Qin bronze chariots (overview): https://en.wikipedia.org/wiki/Qin_bronze_chariot
- Yangjiawan terracotta army (overview): https://en.wikipedia.org/wiki/Yangjiawan_terracotta_army
- Shizishan Han terracotta warriors, Xuzhou (overview): https://travelchinaguide.com/attraction/jiangsu/xuzhou/terracotta.htm
- UNESCO, Mausoleum of the First Qin Emperor: https://whc.unesco.org/en/list/441 (not fetched in this session)
- Excavation reports to obtain: *Zeng Hou Yi mu* (Wenwu, 1989); Qin terracotta pit 1 excavation report (Wenwu, 1988); *Baoshan Chu mu* (Wenwu, 1991). Bibliographic details to verify.

**Scholarship**

- Dien, A. E., "Warring States Armor and Pit Three at Qin Shihuangdi's Tomb", *Early China*: https://www.cambridge.org/core/journals/early-china/article/warring-states-armor-and-pit-three-at-qin-shihuangdis-tomb/596E0EC37751A35415C76CC34D23B505
- Dien, A. E., "A Study of Early Chinese Armor", *Artibus Asiae* 43 (1981–82).
- Martinón-Torres, M., et al., *Scientific Reports* 9:5289 (2019): https://www.ucl.ac.uk/news/2019/apr/scientists-shed-light-preservation-mystery-terracotta-army-weapons
- Ledderose, L., *Ten Thousand Things* (Princeton UP, 2000): https://press.princeton.edu/node/50552
- Elvin, M., *The Retreat of the Elephants* (Yale UP, 2004); review: https://cambridge.org/core/journals/china-quarterly/article/retreat-of-the-elephants-an-environmental-history-of-china-by-mark-elvin-new-haven-and-london-yale-university-press-2004-xxviii564-pp-isbn-0300101112/43EA3FBEE08A7077493227E76EF324EE
- Huang Sheng-song (黃聖松), 2025, on Yu Yue's readings of the *Zuo Zhuan*: https://tkujcl.tacx.tku.edu.tw/uploads/papers/tw/02-黃聖松.pdf
- Debate on Qin water virtue: https://www.aisixiang.com/data/161672.html
- Needham, J. & Yates, R. D. S., *Science and Civilisation in China*, vol. 5 pt 6 (Cambridge UP, 1994).
- Lewis, M. E., *Sanctioned Violence in Early China* (SUNY Press, 1990), on Warring States military organisation.
- Portal, J. (ed.), *The First Emperor: China's Terracotta Army* (British Museum Press, 2007).
- Secondary overview (not evidence): Wikipedia, "Chinese siege weapons": https://en.wikipedia.org/wiki/Chinese_siege_weapons

**Xiangqi rules and history**

- WXF rules (World Mind Games): https://www.worldmindgames.net/xiangqi/rules/
- "Complete Implementation of WXF Chinese Chess Rules", arXiv:2412.17334: https://arxiv.org/html/2412.17334v1
- Chess Programming Wiki, Chinese Chess Perft Results: https://www.chessprogramming.org/Chinese_Chess_Perft_Results
- Ludii portal (history, quoting Murray): https://ludii.games/data.php?gameId=21

---

## 9. Next research actions (Milestone 1)

1. **Engage an external historian** specialising in Qin–Han military history or Chu archaeology, to review this register and every concept sheet. This is a sign-off role (acceptance criterion QH-04, document 11).
2. **Move every V0/V1 entry used for identity-critical elements to V2.** Read critical editions of the classical texts, and the excavation reports.
3. **Assemble the reference board** (document 05, §13) from museum catalogues, recording rights status for each image.
4. **Commission period-script consultation** for in-world inscriptions (Qin seal and clerical styles; Chu script).
5. **Confirm the Guangwu twin-camp site details** and terrain for the environment.
6. **Record every historian finding** as a register update, with version history.
