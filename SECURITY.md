# Security Policy

## Reporting a Vulnerability

**Do not open a public issue** for secrets, tokens, exploits, or vulnerabilities.

Email the maintainers privately: `idex.gamedevstudio@gmail.com`

Include:
- What is affected (file, commit, or release).
- How to reproduce (steps, logs without secrets).
- Your contact for follow-up questions.

We will confirm receipt, fix the issue, and credit you if you wish.

## Secrets Hygiene

- Never commit `.env`, tokens, passwords, or private keys.
- If you leaked a secret: revoke it immediately, then tell the maintainers so history can be cleaned.
- Push protection is enabled: GitHub blocks pushes containing known secret patterns.

## Supported Versions

Student prototype under active development. Only the latest `main` receives fixes.
