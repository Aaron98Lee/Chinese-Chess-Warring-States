# 03 — Technology and Platform Decision Report

| | |
|---|---|
| Document status | **Draft v0.1. Recommendation submitted for approval (decisions D5, D6)** |
| Date | 2026-11-20 (licensing and version facts checked on this date; recheck at approval) |
| Scope | Engine, language, target platforms, rendering approach, asset workflow, performance, technical risks |

---

## 1. Requirements that drive the choice

Derived from the brief and the design documents (02, 05, 06):

| # | Requirement | Weight driver |
|---|---|---|
| R1 | Fixed-camera, small-scene real-time 3D at high fidelity, up to 4K | Visual fidelity |
| R2 | About 130 animated humans, about 28 horses, 2 elephants, 4 chariots and 4 trebuchets on screen at once (document 06 density "full") | Animation and crowd performance |
| R3 | Shared skeletons, retargeting, modular parts, paint-mask variation, LODs | Asset pipeline |
| R4 | Rules engine and AI independent of the engine, testable headless | Architecture fit |
| R5 | Text-diffable project files, headless CI builds and tests; development partly AI-assisted (Claude Code works in text) | Engineering workflow |
| R6 | High-DPI scalable UI with full CJK text | UI |
| R7 | PC first, macOS second, a later tablet or console port possible | Platform reach |
| R8 | Predictable commercial licensing | Licensing |
| R9 | Long-term maintainability and the ability to hire for it | Ecosystem |

## 2. Candidates

| Candidate | Version basis (checked 2026-11-20) | Licensing (summary) |
|---|---|---|
| **Unity 6** (URP) | Unity 6.3 LTS (Dec 2025, supported to Dec 2027); Unity 6.5 Update release (Jun 2026) | Personal: free below US$200k revenue and funding (trailing 12 months). Pro: US$2,310 per seat per year (2026 price). No runtime fee (cancelled 2024) |
| **Unreal Engine 5** | UE 5.x current | Free until US$1M lifetime gross per product, then a 5% royalty. Revenue through the Epic Games Store is exempt; a reduced rate may apply with an Epic Store launch (verify the current EULA) |
| **Godot 4** | 4.7.2 stable | MIT licence; no fees or royalties |
| Web stack (Three.js / Babylon.js) | Current | MIT / Apache-2.0 |

Bevy and other young engines were screened out: their tooling is immature for character animation and asset pipelines at this quality level.

**Unity render pipeline:** Unity has announced URP as its development focus, with HDRP moving to maintenance mode (reported 2026). This project therefore uses **URP** if Unity is chosen. HDRP is not recommended for a new production.

## 3. Comparison matrix

Scores run from 1 (poor) to 5 (excellent) **for this project's requirements**, not in general. They are professional judgements, open to challenge.

| Criterion (weight) | Unity 6 URP | Unreal Engine 5 | Godot 4 | Web stack |
|---|---|---|---|---|
| Visual fidelity for a fixed-camera small scene, 4K (15) | 4 | **5** | 3 | 2 |
| Character animation, retargeting, crowd/instancing (15) | 4 | **5** | 3 | 2 |
| Rendering scalability across hardware tiers (10) | **4** | 3 | **4** | 2 |
| Asset pipeline maturity: DCC import, LOD, variants (10) | 4 | **5** | 3 | 3 |
| Engineering workflow: text-diffable files, headless CI, AI-assisted development, testability (15) | 4 | 2 | **5** | **5** |
| Language and architecture fit: engine-independent core, AI search speed (10) | **5** | 4 | 4 | 3 |
| Platform reach: PC/Mac now, mobile and console later (10) | **5** | 4 | 3 | 4 |
| Licensing and commercial terms (10) | 3 | 3 | **5** | **5** |
| Ecosystem, longevity, hiring (5) | **5** | 4 | 3 | 3 |
| **Weighted total (out of 500)** | **415** | 390 | 370 | 320 |
| **Normalised (out of 100)** | **83** | 78 | 74 | 64 |

### 3.1 Notes on the scores

- **Unreal** has the highest visual and animation ceiling (Lumen, Nanite, Control Rig, motion matching, Sequencer). But Nanite and Lumen add little to a small, statically lit board scene. Blueprint and asset files are binary, and C++ iteration and build sizes are heavy, which costs diffability, review and AI-assisted workflows. Linux and cloud CI need source builds and large machines, and mobile scalability is weaker.
- **Unity** balances a high enough ceiling (URP in Unity 6: Forward+, adaptive probe volumes, GPU Resident Drawer, Spatial-Temporal Post-processing upscaler, VFX Graph) with mature animation (Mecanim humanoid retargeting, Animation Rigging, Timeline). It has the best multi-platform reach. Scenes and prefabs can be serialised as text YAML. **C# lets the rules engine and AI be plain .NET libraries, testable without Unity.** Licensing is a per-seat cost, and Unity's 2023 pricing controversy is a trust risk, mitigated by keeping the core engine-independent (§10).
- **Godot** has the best workflow and licensing: MIT, tiny editor, text scenes, trivially headless. Its 3D ceiling, animation tooling and asset ecosystem are a tier below the others for detailed animated characters, and console publishing goes through third parties.
- **Web** offers reach and an excellent workflow, but about 160 animated actors at 4K in a browser carries too much performance risk.

### 3.2 Sensitivity analysis

| If you weight... | Result |
|---|---|
| Visual ceiling and animation ×1.5 | Unreal ≈ Unity (Unreal leads by a few points) |
| Licensing ×2 (zero fees essential) | Godot rises to second; Unity still leads narrowly |
| Workflow ×2 (heavy AI-assisted development, no GPU workstation) | Godot ≈ Unity |
| Mobile-first | Unity clearly leads |

Unity is the most robust choice across reasonable weightings. **Godot is the documented fallback.** Because the core libraries are C#, and Godot supports C#, the rules engine and AI would transfer with minimal change.

## 4. Recommendation

**Unity 6, Universal Render Pipeline, on the current LTS at project start (6.3 LTS today).** Re-evaluate moving to the next LTS during the Milestone 1 engine spike, and pin the version in `ProjectSettings/ProjectVersion.txt`.

Justification, tied to the requirements:

1. Visual quality enough for stylised realism at 4K in a small scene (R1), with scalable quality tiers for lower hardware.
2. Mature humanoid animation, retargeting and instancing for 160+ animated actors (R2, R3).
3. **The rules engine and AI as pure C# libraries**, compiled into Unity through assembly definitions with `noEngineReferences`, and tested headless with `dotnet test` (R4, R5).
4. Text serialisation, a scriptable batch mode for CI, and UI Toolkit (CSS-like USS, UXML) for scalable high-DPI UI with dynamic CJK font atlases (R5, R6).
5. Broadest path to macOS, tablets and consoles (R7).

**Confirmation step:** the recommendation is confirmed only after a **2-week engine spike** in Milestone 1. It measures, on the agreed hardware tiers, a 160-actor animated scene, the 4K frame time, UI Toolkit CJK rendering and the import of one test character from the art pipeline. If the spike fails its criteria (document 11, QP-01 to QP-03), the fallback is Godot (workflow priority) or Unreal (fidelity priority).

## 5. Programming languages

| Area | Language | Notes |
|---|---|---|
| Rules engine, session, AI, tools | **C#** (language version limited to what the pinned Unity version supports, currently C# 9), targeting .NET Standard 2.1 | Compiles both inside Unity and as standalone .NET projects for CI |
| Unity presentation | C# | MonoBehaviours kept thin; logic lives in plain classes |
| Shaders | Shader Graph plus HLSL where needed | Paint-mask variation shader, board shader, base glyph shader |
| Build and tooling scripts | C# (editor), Python or shell (CI) | Minimal, documented |

## 6. Dependency policy

- **No new dependency without approval.** Each one is recorded with its licence, purpose and alternative considered.
- Proposed Unity packages, all first-party: URP, Input System, UI Toolkit (built in), Unity Test Framework (NUnit), Mathematics, Burst and Collections (only if profiling shows a need), Localization (decision in Milestone 1), Addressables (decision at Milestone 3, for army-set content).
- **Third-party candidates (not yet approved):** a Steamworks wrapper (Steamworks.NET or Facepunch.Steamworks, both MIT); FMOD or Wwise (Milestone 1 evaluation).
- **Explicitly excluded from the shipped game:** GPL engines such as Pikafish and Fairy-Stockfish (both GPL-3.0). They may be used **only as external benchmarking tools** in internal test harnesses and are never linked or distributed with the game.

## 7. Target platforms and hardware tiers (proposal for decision D6)

| Tier | Example hardware (to be agreed) | Target |
|---|---|---|
| **Minimum** | Windows 10 22H2 / 11 64-bit; 4-core CPU (i5-8400 / Ryzen 5 2600 class); 8 GB RAM; GTX 1060 6 GB / RX 580 class | 1080p, 60 fps, Low–Medium |
| **Recommended** | 6-core CPU; 16 GB RAM; RTX 3060 / RX 6600 XT class | 1440p, 60 fps, High |
| **4K** | RTX 4070 / RX 7800 XT class | 2160p, 60 fps, High (native; upscaling allowed only if disclosed in settings) |
| **macOS** | Apple silicon (M1 baseline; M-series Pro for Retina 4K-class output) | Medium at 1440p-class, 60 fps; validated in the spike |
| Stretch | Integrated GPUs (Iris Xe, Radeon 780M class) | 1080p Low, 30–60 fps |

**Distribution:** Steam first (Windows and macOS). Other stores (Epic, GOG, Mac App Store) to be evaluated. **Mainland China publication requires separate regulatory approval for games** and is outside the initial scope unless decided otherwise (risk R12).

## 8. Rendering approach

- **URP Forward+**, linear colour, HDR, physically based materials.
- **Lighting:** one dynamic directional sun plus baked global illumination for static geometry; adaptive probe volumes or light probes for formations; contact shadows.
- **Anti-aliasing and upscaling:** TAA or STP at 4K, plus an MSAA option for players who prefer sharpness. Validated for shimmer on thin spears and banner edges.
- **Skinned characters:** GPU skinning, animator culling, LODs (3 levels plus base), quality-dependent bone weights. If profiling shows a CPU bottleneck, **vertex animation textures** for supporting figures' idle loops (decision deferred to measurement).
- **Instancing and batching:** GPU Resident Drawer and SRP Batcher for static and repeated meshes; shared materials with per-instance properties for paint variation.
- **Post:** colour grading, SSAO, restrained bloom; **no depth of field during play**.
- **Quality profiles:** Low, Medium, High, Ultra, plus Custom. Profiles scale shadows, AO, LOD bias, figure density (full or reduced), cloth simulation and texture mip bias. **Readability features are never scaled down.**

## 9. Asset production workflow

```
Reference board (register IDs) ─► Concept sheet ─► Historian review + readability test ─► APPROVED
    ─► Blockout/greybox (scale, footprint) ─► High-poly sculpt (ZBrush/Blender) ─► Game-res retopo + UVs
    ─► Texturing (Substance Painter or Blender; PBR + RGBA paint masks) ─► Rig (shared skeleton)
    ─► Animation (motion capture and/or keyframe; retarget) ─► Export (FBX; glTF where suitable)
    ─► Unity import (validated by import scripts: naming, scale, tris, texel density, bones)
    ─► Formation assembly (FormationDefinition data) ─► In-game review ─► QA checklist ─► DONE
```

| Item | Standard (proposed) |
|---|---|
| DCC tools | Blender (free; output is not licence-encumbered) as the baseline; Maya, ZBrush or Substance where the artist prefers. Licences tracked |
| Scale and units | 1 unit = 1 m in DCC; formation assembly applies the board-pitch scale |
| Triangle budgets (LOD0, PC High) | Principal human ≤ 30k; supporting human ≤ 15k; horse ≤ 20k; elephant ≤ 40k; chariot ≤ 30k; trebuchet ≤ 25k. LOD1 ≈ 50%, LOD2 ≈ 25%, LOD3 ≈ 10% |
| Textures | Shared 2K atlases or texture sets per character archetype; 4K only for the board surface and hero environment pieces; texel density target 512–1024 px/m on figures (screen-size analysis: §10) |
| Compression | BC7 (colour), BC5 (normals); ASTC for future mobile |
| Naming convention | `<Faction>_<Category>_<Name>_<Variant>_<LOD>`, e.g. `HAN_CHR_Infantry_Torso_A_LOD0`, `CHU_VEH_Chariot_Body_LOD1` |
| Version control for art | Git LFS for binaries (FBX, PSD, textures, audio); large source files (sculpts, Substance projects) in LFS or separate art storage (decision D13) |
| Validation | Automated import checks (scale, triangle count, bone count, texture sizes, naming, missing LODs) run in CI |
| Rights | Every asset records author, tool, licence and ownership; generative-AI use only under the policy in decision D11 |

**Who produces the assets.** Claude Code can produce code, tests, shaders, editor tools, import validators, procedural greybox geometry, specifications and documentation. **Production-quality sculpted characters, horses, the elephant, textures and animation require human artists** (in-house or outsourced) or tools you approve. This report does not pretend otherwise (decision D12).

## 10. Performance considerations

| Topic | Estimate or plan (to be measured in the spike) |
|---|---|
| Screen size of a figure | At 4K in the strategic view the board spans about 1,800 px vertically, so 1 P ≈ 190 px and a figure (≈ 0.5 P) ≈ 90–100 px tall; about 2× that in the tactical view. **A 2K texture set per archetype is ample; 4K textures per figure would waste memory** |
| Triangle load | ≈ 3–3.5M triangles of formations at LOD0, less in practice with LODs, plus about 1–2M for board and environment. Comfortable for the recommended tier |
| Animated actors | ≈ 160 skinned meshes plus cloth on about 10 banners. Main risk: CPU animation cost on minimum spec. Mitigations: animator culling, update-rate reduction for idles, vertex animation textures for supporting figures |
| Draw calls | Shared materials, SRP Batcher, GPU Resident Drawer; target under 1,500 draw calls at High (to measure) |
| Memory | Target ≤ 3 GB RAM, ≤ 2 GB VRAM (Low) to ≤ 3.5 GB VRAM (4K High) |
| AI | Runs on a worker thread with time limits and cancellation; never blocks the render thread |
| Loading | Single battlefield scene; all formations preloaded at board entry (target ≤ 5 s on SSD) |

All targets are formalised in document 11, §4.

## 11. Development environment and CI

- **This cloud session** has no GPU and no Unity editor (verified). It can build and test the engine-independent C# libraries once the .NET SDK is installed, and it can author code, tests, tools and documentation.
- **Visual and Unity work needs a workstation** with a supported GPU and a Unity licence. A self-hosted or GPU CI runner is needed for automated performance tests.
- **CI plan:** (1) core libraries: `dotnet build` and `dotnet test` on every push (Linux, no licence needed); (2) Unity edit-mode and play-mode tests plus builds in batch mode, which requires a Unity licence configured as a CI secret; (3) nightly performance capture on the reference hardware.

## 12. Development risks (technical)

| ID | Risk | Mitigation |
|---|---|---|
| T1 | Unity licensing or pricing changes | Engine-independent C# core; documented Godot fallback |
| T2 | CPU cost of about 160 animated actors on minimum spec | Spike measurement; animator LOD, vertex animation textures, reduced density tier |
| T3 | Thin geometry (spears, banners) shimmers at 4K | TAA/STP tuning; MSAA option; geometry and normal guidelines |
| T4 | CJK font atlas memory and rendering quality | Dynamic SDF atlases; subset fonts per locale; spike test |
| T5 | Large binary assets in Git (repository bloat, LFS costs) | LFS from day one; storage policy (D13) |
| T6 | No GPU in the cloud development environment | Workstation and GPU CI runner; keep logic headless-testable |
| T7 | C# language level constrained by Unity's compiler | Core restricted to the supported language subset; enforced in CI |

## 13. Decisions requiring approval (from this report)

| ID | Decision | Recommendation |
|---|---|---|
| D5 | Engine | Unity 6 LTS + URP, confirmed by the Milestone 1 spike; Godot as fallback |
| D6 | Platforms and hardware tiers | Windows (Steam) first, macOS second; tiers as in §7 |
| D11 | Generative-AI policy for assets | No generative-AI final art unless legally reviewed and disclosed on Steam |
| D12 | Asset production model | Outsourced character, animation and environment production under specs from this team; in-house art lead or director |
| D13 | Source-art storage | Git LFS for runtime assets; separate storage for large source files |

### Sources (checked 2026-11-20)

- Unity pricing updates: https://unity.com/products/pricing-updates
- Unity 6.3 LTS overview (CG Channel, Dec 2025): https://www.cgchannel.com/2025/12/unity-6-3-lts-is-out-see-5-key-features-for-cg-artists/
- Unity 6.5 overview (CG Channel, Jun 2026): https://www.cgchannel.com/2026/06/unity-releases-unity-6-5-discover-5-key-features-for-cg-artists/
- Unreal Engine licence: https://www.unrealengine.com/en-US/license
- Unreal Engine FAQ: https://www.unrealengine.com/en-US/faq
- Godot 4.7.2 stable: https://godotengine.org/download/archive/4.7.2-stable/
- Fairy-Stockfish (GPL-3.0): https://github.com/ianfab/Fairy-Stockfish
- Pikafish wiki (GPL-3.0; weights under a separate licence): https://github.com/official-pikafish/Pikafish/wiki
- Steam AI disclosure policy update (PC Gamer): https://www.pcgamer.com/software/ai/steam-updates-ai-disclosure-form-to-specify-that-its-focused-on-ai-generated-content-that-is-consumed-by-players-not-efficiency-tools-used-behind-the-scenes/
