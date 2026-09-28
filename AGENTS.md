# AI-From-The-Devil — AI Agent Guidelines

## About the Project

**Title:** AI-From-The-Devil
**Genre:** Psychological horror (PSX/VHS style)
**Engine:** Unity 6000.x
**Type:** Student project (prototype)
**Deadline:** February 14, 2027
**Platform:** Windows

### Team

- **Mykhailo (MRMIL)** — code, game design, git
- **Bohdan** — level design, mechanics
- **Maryna** — sound, visuals (passive)
- **Ivan** — shaders, models (away at camp)

## Communication

- **Always reply in the user's language.** If the user writes in Ukrainian, answer in Ukrainian; if in Russian, answer in Russian; if in English, answer in English. Never switch languages unprompted.
- Keep answers short and factual. No flattery, no filler.

## Code Standards

### Naming

| Type | Example |
|-----|---------|
| Private fields | `_health`, `_coins` |
| Public fields | `MaxHealth` (PascalCase) |
| Methods | `TakeDamage()`, `SpawnEnemy()` |
| Classes | `TowerManager`, `EnemySpawner` |
| Constants | `MAX_WAVES` |

### Commits

**English only!** Format:

```
<type>(<scope>): <description>
```

**Type:** `feat`, `fix`, `refactor`, `docs`, `chore`, `perf`
**Scope:** `concept`, `prototype`, `story`, `ui`, `enemy`, `ai`, `docs`

**Breaking Changes (`!`):**
Placed after the type before `:`, when the change breaks backward compatibility:
```
feat!: rename SoulSystem -> ParanoiaSystem
fix(api)!: remove deprecated GetVictim method
```

When to use:
- Removing a public method/field
- Changing a method signature (parameters, name)
- Changing behavior other parts of the code rely on
- Renaming a class or namespace

Examples:
```
feat(concept): add ConceptPrototype with moral choices
fix(story): align endings between Concept and Prototype
docs: add AGENTS.md with guidelines
feat!: rename SoulSystem to ParanoiaSystem
```

### Branches

```
main              # stable documentation
├── feat/prototype  # prototype features
├── feat/story      # story
└── fix/*           # fixes
```

## Important Rules for AI Agents

- **Only the user pushes.** AI creates commits locally, shows the changes to the user, and only after confirmation does the user push to remote.
- **Do not modify `.gitignore`** without permission.
- **Do not delete files** without permission.
- **Before push** — show what will be pushed (git status, git diff --stat).

## Project Context

- **CloseAI** — developer company (like OpenAI), **Closely** — neural-network virus (like GPT) spreading via smart home systems
- **Story:** 2000s, the hero breaches CloseAI servers, launches Closely on his PC, unknowingly releases the virus
- **Genre:** psychological horror / techno-thriller (no mysticism)
- **Enemy:** not monsters, but paranoia, technology, and your own choice
- **PSX/VHS style** (low-poly + post-processing)
- **Concept:** the AI uses the hero as a distribution tool, blackmails on refusal

## Links

- Repository: https://github.com/IDEX-GameDev-Studio/AI-From-The-Devil
- Public docs (EN/UK): `docs/en/`, `docs/uk/`
- Team notes (UA): `ObsidianDocs/`
