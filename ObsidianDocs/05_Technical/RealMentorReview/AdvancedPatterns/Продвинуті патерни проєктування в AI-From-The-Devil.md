# Основні патерни які були реалізовані (або плануються)

Розробка була б складною та довшою, якщо б ми не використовували патрени проєктування, цей doc буде про те, які ми плануємо або вже реалізували

## MVC vs. MVP

Коли я (MRMIL) починав розробку системи квестів, я ще не знав про MVC/MVP. В кінці з'ясувалося, що це чиста схема Model-View-Presenter, тільки залишається додати View для UI замість логів


| **Роль**  | **В проєкті**                                  | **Статус** |
| --------- | ---------------------------------------------- | ---------- |
| Model     | `Quest` `QuestObjective` + `InteractObjective` | ✅          |
| View      | `Debug.Log` (тимчасово) Потім `QuestView`      | ⌛          |
| Presenter | `QuestSystem`                                  | ✅          |
### Головна відмінність MVP та MVC

MVP - View максимально простий, просто показує а дані йому дає Presenter
MVC - View сам лізе до Model і оновлюється, тобто він обкладається додатковою логікою

### Висновок

MVC та МVP - це як молоток та перфаратор, якщо View тільки 1, то краще MVC, а якщо більше то MVP. Як плюс MVP легше тестувати.
Обрано MVP: View дізнається про зміни тільки від Presenter (QuestSystem), тому другий екран (HUD-трекер) не вимагатиме змін у моделях. Перевірка CheckProgress — це логіка предметної області, вона живе в Model за інкапсуляцією, а не в UI.

## Factory

Стандартні фабрики допомогають створювати нові об'єкти (як от наприклад квести) тримаючи чистоту коду та інкапсуляцію деталей

Як я вже сказав, ми плануємо не хардкодити квести, а використовувати для цього фабрику, а гнучко через фабрику. Наприклад: 

```
public class QuestFactory
{
    public Quest Create(string title, string description, string requiredActionID)
    {
        return new Quest(title, description,
            new List<QuestObjective> { new InteractObjective(requiredActionID) });
    }
}

```

Але, якщо у нас з'явиться `TutorialQuestFactory` то краще під такі задачі створити абстракцію

```
public abstract class QuestCreator
{
    public abstract Quest Create(string title, string description, string requiredActionID);
}

public class QuestFactory : QuestCreator
{
    public override Quest Create(string title, string description, string requiredActionID)
    {
        return new Quest(title, description,
            new List<QuestObjective> { new InteractObjective(requiredActionID) });
    }
}
```