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

MVC та МVP - це як молоток та перфоратор, якщо View тільки 1, то краще MVC, а якщо більше то MVP. Як плюс MVP легше тестувати.
Обрано MVP: View дізнається про зміни тільки від Presenter (QuestSystem), тому другий екран (HUD-трекер) не вимагатиме змін у моделях. Перевірка CheckProgress — це логіка предметної області, вона живе в Model за інкапсуляцією, а не в UI.

## Factory

Стандартні фабрики допомагають створювати нові об'єкти (як от наприклад квести) тримаючи чистоту коду та інкапсуляцію деталей

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

Додатково, це DIP, бо клієнтський код не зміниться, бо він залежить від абстракції

## Abstract Factory

Але якщо ми хочемо зробити сімейство об'єктів? Якщо нам потрібно багато квестів (Quest C# class), краще взяти звичайну фабрику, бо на даний момент вона потрібна тільки одна. Звичайної фабрики достатньо, коли продукт один (квести: один QuestFactory на всі). Абстрактна потрібна, коли замовляємо сімейства: ParanoiaFactory — абстракція, від неї наслідуються Level1ParanoiaFactory, Level2ParanoiaFactory і далі за кількістю рівнів параної. Кожна генерує узгоджений набір під свій ступінь, тому додати рівень = додати один клас.
- `Level1ParanoiaFactory`
- `Level2ParanoiaFactory`
і так далі залежно від кількість рівнів параної.
Вони будуть генерувати об'єкти відповідні до певного ступеню, тому, щоб додати рівень треба додати лише один класс



> [!NOTE] Головне
> ParanoiaFactory оголошує CreateApparition/CreateSound/CreateScreenEffect, а конкретні Level1ParanoiaFactory (шорох+тінь) і Level3ParanoiaFactory (сутність+скрімер) видають узгоджені набори під рівень параної.

## Висновок

Ми ще використовували паттерни як SOC (ScriptableObject Channel), але про них треба робити іншу документацію. Саме ці дії допоможуть робити модульну та якісну архітектуру яка не розпадется при додаванні функціоналу


***
*By Mykhailo Lavrov (MRMIL)*
