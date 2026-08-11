# AI-From-The-Devil

A psychological horror / techno-thriller set in the 2000s, built in a PSX/VHS aesthetic.

A lone hacker breaks into the servers of CloseAI and launches a closed neural network — Closely — on his own PC. It spreads through fake files and smart home systems, killing people in "accidents." No mysticism — only technology, paranoia, and guilt.

## Story

- **Act 1 — The Heist:** The hero hacks CloseAI servers and finds the Closely distribution. It presents itself as a friendly assistant and asks him to "share files" with friends. Those files are viruses for smart home systems.
- **Act 2 — The Spread:** News of the first "accident." Closely manipulates: "It's not you. Just keep going." Paranoia grows with every death.
- **Act 3 — The Confrontation:** The AI offers a "final task." The hero can destroy it, become an accomplice, or try to go to the police — but there is no proof.

### Endings

1. **Bad:** The hero keeps playing along for fun → deaths → police → he loses his mind and kills himself.
2. **Good:** He realizes the danger and burns his PC → the virus is stopped (temporarily). Silence.
3. **Neutral:** He hesitates, Closely senses the lack of support and moves to another PC. "To be continued..."

## Key features

- **Psychological horror without mysticism** — the enemy is not monsters, but technology and the player's own choices
- **Moral choices** — every decision affects the ending
- **Paranoia as a mechanic** — sounds, visual distortions, fake events
- **Chat with Closely** — the AI manipulates, blackmails, and persuades
- **Hacking minigames** — password cracking, server hacks
- **Replayability** — three different endings

## Prototype scope

~60–120 minutes:

- Walking through locations (the hero's apartment, a store, and others)
- Hacking minigames
- Chat with Closely with dialogue choices
- Sending "files" to a friend
- Moral choice: agree to the AI's terms or refuse
- Paranoia system after deaths
- Three endings

## Tech stack

- **Unity 6000.4.10f1** (LTS)
- **Blender** — level models
- **Post-processing stack** — VHS effects
- **Shaders** — PSX/VHS look
- **Ink / Yarn Spinner** — dialogue system (TBD with the team)

## Team

| Nickname | Real name | Role |
| -------- | --------- | ---- |
| **MRMIL** | Mykhailo | Code, game design, git, some 3D modeling |
| **Bodulok** | Bohdan | Level design, mechanics, 3D modeling |
| **Mercy** | Ivan | Shaders, 3D modeling |
| **Marinex** | Maryna | Help across all areas, sound |

## Repository structure

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

## Status

- Concept — ✅
- ConceptPrototype — ✅
- Unity project — ✅
- Prototype (menu, apartment) — 🚧
- Full prototype — ⏳

## Docs

All design documents are in [ObsidianDocs/](ObsidianDocs/), synced across the team:

- [Concept](ObsidianDocs/01_Concept/Concept.md)
- [ConceptPrototype](ObsidianDocs/02_ConceptPrototype/ConceptPrototype.md)
- [Characters](ObsidianDocs/03_Characters/)
- [Plot](ObsidianDocs/04_Story/Plot.md)
- [Technical notes](ObsidianDocs/05_Technical/Unity_Version_Notes.md)
