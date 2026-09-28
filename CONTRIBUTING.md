# Contributing to AI-From-The-Devil

This is a small student team project and contributions are not guaranteed to be accepted. But issues and careful pull requests are welcome.

## Before a Large Change

Please open an issue first and describe what you want to do. Wait for a maintainer's reply before writing code.

## Pull Requests

- Target the `dev/prototype` branch (or the feature branch a maintainer points you to), not `main`.
- Explain **what changed and how it was tested** (use the PR template).
- One logical change per PR. Keep it small.
- Commits in English: `<type>(<scope>): <description>` (see `CODE_STYLE.md`).
- Do not include secrets, tokens, local settings (`.env`, `.vscode/settings.json`), or unlicensed assets.
- Do not remove IDEX studio copyright notices.
- Unity Asset Store assets are never committed (see README dependencies).

## AI-Assisted Code

AI-generated code must be **reviewed and understood by the author** before opening a PR. If you cannot explain a line, do not submit it.

## Environment Setup

1. Unity 6000.4.10f1 (LTS) via Unity Hub.
2. `git lfs install` once per machine, then `git lfs pull`.
3. Copy `.env.example` to `.env` and fill in your own tokens. Never commit `.env`.
4. Import the Asset Store dependencies listed in README (they are not in the repo).

## Languages

- Public docs and code: **English**.
- Team working notes (`ObsidianDocs/`): Ukrainian.
