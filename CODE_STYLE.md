# Code Style

## Language

- Use English for code, commits, branches, and public documentation.

## C#

- Use PascalCase for classes, methods, and properties.
- Use camelCase for private fields and parameters.
- Private fields: `_health`, `_coins`. Public fields: `MaxHealth` (PascalCase).
- Constants: `MAX_WAVES`.
- Prefer interfaces for capabilities and composition over unnecessary inheritance.
- Avoid Singleton unless the lifetime and global ownership are intentional.
- Prefer C# events or `Action` when subscriptions are controlled by code.
- Use `UnityEvent` when Inspector configuration is an intentional design requirement.

## Git

- Commits: `<type>(<scope>): <description>`, English only.
  Types: `feat`, `fix`, `refactor`, `docs`, `chore`, `perf`.
- Breaking changes get `!`: `feat!: rename SoulSystem -> ParanoiaSystem`.
- Branches: `feat/*`, `fix/*`, `docs/*`, `chore/*`. Never commit directly to `main`.
- Large binaries go through Git LFS (see `.gitattributes`). Files over 1 MiB without LFS fail CI.

## Pull Requests

- Every pull request must explain what changed and how it was tested.
- AI-generated code must be reviewed and understood before merging.
- One approval from a maintainer is required to merge into `main`.
