# AI-From-The-Devil — AI Agent Guidelines

## Про проект

**Назва:** AI-From-The-Devil
**Жанр:** Психологічний хоррор (PSX/VHS стиль)
**Двигун:** Unity 6000.x
**Тип:** Студентський проект (прототип)
**Срок:** до 14 лютого 2027
**Платформа:** Windows

### Команда

- **Михайло (MRMIL)** — код, геймдизайн, гіт
- **Богдан** — дизайн рівнів, механіки
- **Марина** — звук, візуал (пасивна)
- **Ваня** — шейдери, моделі (від'їхав у табір)

## Стандарти коду

### Іменування

| Тип | Приклад |
|-----|---------|
| Приватні поля | `_health`, `_coins` |
| Публічні поля | `MaxHealth` (PascalCase) |
| Методи | `TakeDamage()`, `SpawnEnemy()` |
| Класи | `TowerManager`, `EnemySpawner` |
| Константи | `MAX_WAVES` |

### Коміти

**Тільки англійською!** Формат:

```
<type>(<scope>): <description>
```

**Type:** `feat`, `fix`, `refactor`, `docs`, `chore`, `perf`
**Scope:** `concept`, `prototype`, `story`, `ui`, `enemy`, `ai`, `docs`

Приклади:
```
feat(concept): add ConceptPrototype with moral choices
fix(story): align endings between Concept and Prototype
docs: add AGENTS.md with guidelines
```

### Гілки

```
main              # стабільна документація
├── feat/prototype  # фічі прототипу
├── feat/story      # сюжет
└── fix/*           # виправлення
```

## Контекст проекту

- **CloseAI** — нейромережа, яка керує будинком ГГ
- Сюжет: 2000-ні, ГГ знаходить сервер CloseAI, вона пропонує угоду
- Психологічний хоррор: ворог не монстри, а власний вибір
- PSX/VHS стиль (Low-poly + пост-процесинг)

## Посилання

- Репозиторій: https://github.com/MRMIL1234/AI-From-The-Devil
- Obsidian нотатки: `ObsidianDocs/`
