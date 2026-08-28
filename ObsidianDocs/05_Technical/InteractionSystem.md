# Система взаємодії — Конспект

## Навіщо це потрібно

Завдання від викладача: створити **універсальну систему взаємодії** героя з об'єктами через клавішу E. Система повинна бути гнучкою — щоб можна було додавати нові об'єкти (двері, вимикачі, комп'ютери) без переписування існуючого коду.

---

## Архітектура

```
IInteractable (інтерфейс)
      ↑
InteractableObject (абстракція)
      ↑
   Computer / Door / Switch (конкретні об'єкти)

PlayerInteraction (перевіряє взаємодію)
InteractionUI (показує підказку)

Quest (абстракція квесту)
  ↑
ComputerQuest / DoorQuest (конкретні квести)

QuestHolder<T> (контейнер для квестів)
QuestSystem (керує квестами)
```

---

## Ключові концепти

### 1. Інтерфейс (IInteractable)

**Що це:** контракт, який визначає "що може робити" об'єкт.

```csharp
public interface IInteractable
{
    string InteractionText { get; }
    void Interact();
}
```

**Чому інтерфейс, а не абстракція:**
- Інтерфейс **не має реалізації** — тільки оголошення
- Будь-який об'єкт може реалізувати інтерфейс (навіть не MonoBehaviour)
- Інтерфейс = "що ти вмієш", а не "як ти це робиш"

**Коли використовувати:**
- Коли потрібен контракт без спільної логіки
- Коли об'єкти не пов'язані ієрархією

---

### 2. Абстракція (InteractableObject)

**Що це:** базовий клас зі спільною логікою для всіх інтерактивних об'єктів.

```csharp
public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] protected string interactionText = "Press E to interact";

    public string InteractionText => interactionText;

    public abstract void Interact();
}
```

**Чому абстракція, а не інтерфейс:**
- Абстракція **має реалізацію** (спільні поля, методи)
- Не потрібно копіювати `interactionText` в кожен об'єкт
- `protected` — доступ тільки для дочірніх класів

**Коли використовувати:**
- Коли є спільна логіка (поля, методи)
- Коли об'єкти пов'язані ієрархією

---

### 3. Інтерфейс vs Абстракція — коли що

| Інтерфейс | Абстракція |
|-----------|------------|
| Тільки оголошення | Має реалізацію |
| Будь-який клас | Тільки наслідники |
| "Що ти вмієш" | "Як ти це робиш" |
| Коли немає спільної логіки | Коли є спільна логіка |

**У нашому випадку:**
- `IInteractable` — контракт (будь-який об'єкт може бути інтерактивним)
- `InteractableObject` — спільна логіка (всі інтерактивні об'єкти в Unity мають однакову базу)

---

### 4. Події (Events)

**Що це:** спосіб повідомити інші системи про те, що щось трапилося.

```csharp
// У PlayerInteraction
public static event Action<IInteractable> OnInteracted;

// Виклик
OnInteracted?.Invoke(currentInteractable);
```

**Навіщо:**
- `PlayerInteraction` **не знає** про `QuestSystem`
- `QuestSystem` **підписується** на подію і реагує
- Можна додавати нові системи без зміни `PlayerInteraction`

**Який SOLID застосовується:**
- **DIP** (Dependency Inversion) — модулі залежать від абстракцій, а не від конкретних класів
- **OCP** (Open/Closed) — відкритий для розширення (нові системи), закритий для змін (не чіпаємо PlayerInteraction)

**`static` навіщо:**
- В грі один герой і одна глобальна подія
- Не потрібно створювати екземпляр для доступу до події

---

### 5. Generic (QuestHolder<T>)

**Що це:** контейнер, який працює з різними типами квестів.

```csharp
public class QuestHolder<T> where T : Quest
{
    public T CurrentQuest { get; private set; }

    public void SetQuest(T quest)
    {
        CurrentQuest = quest;
    }
}
```

**Навіщо:**
- Один клас працює з `MainQuest`, `SideQuest`, `TutorialQuest`
- Не потрібно робити окремий контейнер для кожного типу
- `where T : Quest` — обмеження, щоб T був тільки нащадком Quest

**Чому не робити Computer або PlayerInteraction дженериками:**
- Вони працюють з конкретними типами
- Дженерик тут не дає практичної користі

---

### 6. Абстракція квесту (Quest)

**Що це:** базовий клас для всіх квестів зі спільною логікою.

```csharp
public abstract class Quest
{
    public string Description { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public abstract void CheckProgress(IInteractable interactable);
}
```

**Чому абстракція, а не інтерфейс:**
- `Description` та `IsCompleted` — спільні поля для всіх квестів
- Якщо був би інтерфейс — довелося б копіювати ці поля в кожний квест
- Абстракція дає це **один раз**

---

## SOLID у нашій системі

### SRP (Single Responsibility)
- `PlayerInteraction` — тільки визначає взаємодію
- `InteractionUI` — тільки показує підказку
- `Computer` — тільки логіка комп'ютера
- `QuestSystem` — тільки керування квестами

### OCP (Open/Closed)
- Новий об'єкт (Door) — додаємо наслідника InteractableObject
- Не змінюємо PlayerInteraction, QuestSystem

### LSP (Liskov Substitution)
- Будь-який наслідник InteractableObject може замінити батьківський клас
- PlayerInteraction працює з IInteractable — йому байдуже який саме об'єкт

### ISP (Interface Segregation)
- IInteractable містить тільки те, що потрібно для взаємодії
- Не має зайвих методів

### DIP (Dependency Inversion)
- PlayerInteraction залежить від IInteractable (абстракція)
- QuestSystem залежить від події (абстракція)
- Ніхто не залежить від конкретних класів

---

## Приклад роботи (крок за кроком)

1. Гравець отримує квест: "Увімкнути комп'ютер"
2. QuestSystem створює `ComputerQuest` і передає в `QuestHolder<ComputerQuest>`
3. UI показує опис квесту
4. Гравець підходить до комп'ютера
5. `PlayerInteraction` (через Raycast/SphereCast) знаходить `IInteractable`
6. `InteractionUI` показує: "Press E to interact"
7. Гравець натискає E
8. `PlayerInteraction` викликає `currentInteractable.Interact()`
9. `Computer.Interact()` виконує логіку (вмикає комп'ютер)
10. `PlayerInteraction` викликає подію `OnInteracted`
11. `QuestSystem` отримує подію, перевіряє квест
12. Якщо взаємодія була з комп'ютером → `IsCompleted = true`
13. UI оновлюється

---

## Структура файлів

```
Scripts/
├── Interaction/
│   ├── IInteractable.cs
│   ├── InteractableObject.cs
│   ├── PlayerInteraction.cs
│   └── InteractionUI.cs
├── Quests/
│   ├── Quest.cs
│   ├── ComputerQuest.cs
│   ├── QuestHolder.cs
│   └── QuestSystem.cs
└── Objects/
    ├── Computer.cs
    ├── Door.cs
    └── Switch.cs
```

---

## Питання для самоперевірки

1. Чому IInteractable — інтерфейс, а не абстрактний клас?
2. Навіщо static event Action<IInteractable> OnInteracted?
3. Що станеться, якщо прибрати where T : Quest з QuestHolder?
4. Який SOLID-принцип порушується, якщо PlayerInteraction напряму звернутися до QuestSystem?
5. Чому логіка анімації повинна бути окремо від InteractableObject?

---

*Створено: 26.08.2026*
*Автор: Михайло (MRMIL) + OpenCode Mentor*
