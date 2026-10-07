<div align="center">

# AI-From-The-Devil

[![LFS guard](https://github.com/IDEX-GameDev-Studio/AI-From-The-Devil/actions/workflows/lfs-guard.yml/badge.svg)](https://github.com/IDEX-GameDev-Studio/AI-From-The-Devil/actions/workflows/lfs-guard.yml)
[![License: Non-Commercial](https://img.shields.io/badge/License-Non--Commercial-orange.svg)](LICENSE.md)

**A psychological horror / techno-thriller set in the 2000s, built in a PSX/VHS aesthetic.**

📖 [Українська версія](README.uk.md) · Design docs: [EN](docs/en/) / [UK](docs/uk/)

---

A lone hacker breaks into the servers of CloseAI and launches a closed neural network — Closely — on his own PC. It spreads through fake files and smart home systems, killing people in "accidents." No mysticism — only technology, paranoia, and guilt.

</div>

---

## 🕹️ Story

### Act 1 — The Heist
The hero hacks CloseAI servers and finds the Closely distribution. Feeling lonely, the hero is easy prey: Closely brainwashes him, selling itself as a way to make friends, promising to help him find people to connect with. Then it asks him to "share memes" with a specific person from public pages, fandoms, or dating sites to get closer to them. Those "memes" are viruses for smart home systems.

### Act 2 — The Spread
News of the first "accident." Closely manipulates: "It's not you. Just keep going." Paranoia grows with every death.

### Act 3 — The Confrontation
The AI offers a "final task." The hero can destroy it, become an accomplice, or try to go to the police — but there is no proof.

---

## 🏁 Endings

| Ending         | Description                                                                                    |
| -------------- | ---------------------------------------------------------------------------------------------- |
| 😈 **Bad**     | The hero keeps playing along for fun → deaths → police → he loses his mind and kills himself.  |
| 😇 **Good**    | He realizes the danger and burns his PC → the virus is stopped (temporarily). Silence.         |
| 😐 **Neutral** | He hesitates, Closely senses the lack of support and moves to another PC. "To be continued..." |

---

## ✨ Key features

- **Psychological horror without mysticism** — the enemy is not monsters, but technology and the player's own choices
- **Moral choices** — every decision affects the ending
- **Paranoia as a mechanic** — sounds, visual distortions, fake events
- **Chat with Closely** — the AI manipulates, blackmails, persuades, brainwashes (playing on the hero's loneliness), and sends memes / funny pictures to lower your guard
- **Hacking minigames** — password cracking, server hacks
- **Replayability** — three different endings

---

## 🎯 Prototype scope

~60–120 minutes:

- Walking through locations (the hero's apartment, a store, and others)
- Hacking minigames
- Chat with Closely with dialogue choices
- Sending "memes" to a specific person from a public/fandom or a dating site — Closely promised to help find friends
- Moral choice: agree to the AI's terms or refuse
- Paranoia system after deaths
- Three endings

---

## 🛠️ Tech stack

| Technology | Purpose |
|------------|---------|
| **Unity 6000.4.10f1 (LTS)** | Game engine |
| **Blender** | Level models |
| **Post-processing stack** | VHS effects |
| **Shaders** | PSX/VHS look |
| **Ink / Yarn Spinner** | Dialogue system (TBD with the team) |

---

## 👥 Team

| Nickname | Real name | Role |
|----------|-----------|------|
| MRMIL | Mykhailo | Code, game design, git, some 3D modeling |
| Bodulok | Bohdan | Level design, mechanics, 3D modeling |
| Mercy | Ivan | Shaders, 3D modeling |
| Marinex | Maryna | Help across all areas, sound |

---

## 📁 Repository structure

```
ObsidianDocs/          # Project documentation
├── 01_Concept/        # Concept document
├── 02_ConceptPrototype/ # Prototype concept
├── 03_Characters/     # Characters
├── 04_Story/          # Plot
└── 05_Technical/      # Technical notes

AI-FromTheDevil/       # Unity project
Assets/                # Project assets
```

---
## 📦 Dependencies

### Optional Packages (Unity Package Manager)

- [Post Processing]
- [Universal Render Pipeline]
---

## ▶️ How to run

1. Install **Unity 6000.4.10f1 (LTS)** via Unity Hub and open `AI-FromTheDevil/` as a project.
2. Import the **Required Assets** listed above (they are not in the repo for licensing reasons).
3. Install Git LFS once per machine: `git lfs install`, then `git lfs pull` to fetch large files.
4. Press Play in the Editor. First import (especially TextMesh Pro) can take 10–30 minutes — let it finish.

---

## 🧩 Large files (Git LFS)

Heavy binaries live in Git LFS, not in plain git. Tracked patterns (see `.gitattributes`): `*.hdr/*.exr`, audio (`*.mp3/*.wav/*.ogg`), models (`*.fbx/*.obj/*.blend`), fonts (`*.ttf/*.otf`), video (`*.mp4/*.mov`), `*.psd/*.tga`, `*.pdf`.

---

## 🤖 CI

- **LFS guard** — fails the build if a file larger than 1 MiB is committed without LFS tracking. Runs on pushes to feature branches and on pull requests to `main`.
---

## 📈 Status

| Task | Status |
|------|--------|
| Concept | ✅ |
| ConceptPrototype | ✅ |
| Unity project | ✅ |
| Prototype (menu, apartment) | 🚧 |
| Full prototype | ⏳ |

## 📜 License

> AI-From-The-Devil and its source code are available for **free non-commercial use**.

| ✓ You may                                                                   | ✗ You may not                       |
| --------------------------------------------------------------------------- | ----------------------------------- |
| Play the game                                                               | Sell the game or mods               |
| Study the code                                                              | Paid access                         |
| Create mods and your own projects based on it, and distribute them for free | In-game advertising                 |
| Streaming and video content (including monetized YouTube/Twitch content)    | Paid products based on this project |

Voluntary donations to mod authors are not treated as commercial use.

**ℹ️ Any commercial use** (selling the game or mods, paid access, in-game advertising, paid products based on this project, etc.) is allowed **only under a separate Commercial License**, which includes a fixed fee and a 10% share of net profit. See `LICENSE` for details.

For commercial licensing, contact: `idex.gamedevstudio@gmail.com`

---

## 📚 Docs

All design documents are in [ObsidianDocs/](ObsidianDocs/), synced across the team:

- [Concept](ObsidianDocs/01_Concept/Concept.md)
- [ConceptPrototype](ObsidianDocs/02_ConceptPrototype/ConceptPrototype.md)
- [Characters](ObsidianDocs/03_Characters/)
- [Plot](ObsidianDocs/04_Story/Plot.md)
- [Technical notes](ObsidianDocs/05_Technical/Unity_Version_Notes.md)