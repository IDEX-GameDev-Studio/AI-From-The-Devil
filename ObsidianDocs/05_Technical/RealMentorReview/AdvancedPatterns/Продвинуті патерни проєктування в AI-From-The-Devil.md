# Основні патерни які були реалізовані (або плануються)

Розробка була б складною та довшою, якщо б ми не використовували патерни проєктування, цей doc буде про те, які ми плануємо або вже реалізували

## MVC vs. MVP

Коли я (MRMIL) починав розробку системи квестів, я ще не знав про MVC/MVP. В кінці з'ясувалося, поточний `QuestSystem` координує квести та обробляє події взаємодії. Після додавання `QuestView` ми плануємо організувати взаємодію за схемою MVP Passive View.

| **Роль**  | **В проєкті**                                  | **Статус** |
| --------- | ---------------------------------------------- | ---------- |
| Model     | `Quest` `QuestObjective` + `InteractObjective` | ✅          |
| View      | `Debug.Log` (тимчасово) Потім `QuestView`      | ⌛          |
| Presenter | `QuestSystem`                                  | ⌛`*`       |
`*` бо `QuestSystem`   поки що, не спілкується з View

### Головна відмінність MVP та MVC

У варіанті MVP Passive View, View показує дані та передає події користувача Presenter. Presenter керує оновленням View. У класичному MVC View може спостерігати за Model і читати її стан для відображення. Це не означає, що View має містити доменну логіку.

### Висновок

Для поточної системи квестів на uGUI ми обрали MVP Passive View. Після додавання `QuestView` Presenter явно оновлюватиме View. Unity 6 UI Toolkit підтримує runtime data binding, але ми не використовуємо його для цієї системи. MVVM можна розглянути окремо, якщо вимоги до UI зміняться.

MVC - не дефект, просто інший механізм

Ми фокусуємось не на назвах ролей, а на головній межі: View не знає про Model, вся комунікація йде через Presenter. Це і є Passive View — різновид MVP

## Simple Factory

Стандартні фабрики допомагають створювати нові об'єкти (як от наприклад квести) тримаючи чистоту коду та інкапсуляцію деталей

Фабрика централізує створення, а data-driven через конфіги - окремий майбутній крок.  Але на поточному варіанті може виглядати так: 

``` csharp
public class QuestFactory
{
    public Quest Create(string title, string description, string requiredActionID)
    {
        return new Quest(title, description,
            new List<QuestObjective> { new InteractObjective(requiredActionID) });
    }
}

```

## Factory Method

Але, якщо у нас з'явиться `TutorialQuestFactory` то краще під такі задачі створити абстракцію

``` csharp
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

Така структура підтримує DIP, якщо високорівневий клієнт залежить від абстракції `QuestCreator`, а конкретну фабрику отримує ззовні. Самого оголошення абстрактного класу недостатньо.

## Abstract Factory

Але якщо ми хочемо зробити сімейство об'єктів? Якщо нам потрібно багато квестів (Quest C# class), краще взяти звичайну фабрику, бо на даний момент вона потрібна тільки одна. Звичайної фабрики достатньо, коли продукт один (квести: один QuestFactory на всі). Абстрактна потрібна, коли замовляємо сімейства: ParanoiaFactory — абстракція, від неї наслідуються Level1ParanoiaFactory, Level2ParanoiaFactory і далі за кількістю рівнів параної. Кожна генерує узгоджений набір під свій ступінь (реєстрація та перемикання фабрик, окреме питання) 



> [!NOTE] Головне
> ParanoiaFactory оголошує CreateApparition/CreateSound/CreateScreenEffect, а конкретні Level1ParanoiaFactory (шорох+тінь) і Level3ParanoiaFactory (сутність+скрімер) видають узгоджені набори під рівень параної.

## Висновок

Ми ще використовували патерни як SOC (ScriptableObject Channel), але про них треба робити іншу документацію. Саме ці дії допоможуть робити модульну та якісну архітектуру яка не розпадеться при додаванні функціоналу

## Попередження

Деякі частини документації (як от фабрики та View) мають поки що теоретичний характер, але скоро будуть реалізовані в життя. Перша версія квестів була реалізована у гілці [feat/interactable-objects](https://github.com/IDEX-GameDev-Studio/AI-From-The-Devil/tree/feat/interactable-objects) [коміт b821d2cad6e64b8a995a02d3d9527530c8f6d444](https://github.com/IDEX-GameDev-Studio/AI-From-The-Devil/commit/b821d2cad6e64b8a995a02d3d9527530c8f6d444)
***
*By Mykhailo Lavrov (MRMIL)*
