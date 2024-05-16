using System;

namespace BossFight;

internal static class Program
{
    private static void Main()
    {
        const string SkipsMessage = "{0}. Маг пропускает ход.";

        const string BaseAttackCommand = "1";
        const string FireballCommand = "2";
        const string ExplodeCommand = "3";
        const string HealCommand = "4";

        Random random = new();

        int bossHealth = 100;
        int fullBossHealth = bossHealth;

        int bossDamage;
        int minBossDamage = 20;
        int maxBossDamage = 40;

        int minMagicianHealth = 60;
        int maxMagicianHealth = 90;
        int magicianHealth = random.Next(minMagicianHealth, maxMagicianHealth + 1);
        int fullMagicianHealth = magicianHealth;

        int minMagicianMana = 30;
        int maxMagicianMana = 50;
        int magicianMana = random.Next(minMagicianMana, maxMagicianMana + 1);
        int fullMagicianMana = magicianMana;

        bool isBossAlive = true;
        bool isMagicianAlive = true;

        int magicianDamage;
        int baseMagicianDamage = 10;
        int fireballDamage = 20;
        int explosionDamage = 40;

        int healthRestoredAmount = 40;
        int manaRestoredAmount = 10;
        int maxHealUses = 3;
        int healUsesLeft = maxHealUses;

        int fireballCost = 10;
        bool isFireballUsed = false;

        int positionOfAvailableSpells = 12;

        string availableSpells = $"""
                                  [{BaseAttackCommand}] Обычная атака.  Урон: {baseMagicianDamage}.
                                  [{FireballCommand}] Огненный шар.   Урон: {fireballDamage}. 
                                  [{ExplodeCommand}] Взрыв.          Урон: {explosionDamage}.
                                  Можно вызывать, только если был использован огненный шар. Для повторного применения надо повторно использовать огненный шар. 
                                  [{HealCommand}] Лечение.        Здоровье: +{healthRestoredAmount} | Мана: +{manaRestoredAmount}.
                                  Восстанавливает здоровье и ману, но не больше их максимального значения. Количество использований {maxHealUses}.
                                  """;

        Console.WriteLine("Бой начинается!");

        string errorMessage = string.Empty;
        string selectedSpell;

        while (isBossAlive && isMagicianAlive)
        {
            Console.Clear();
            Console.SetCursorPosition(0, positionOfAvailableSpells);
            Console.WriteLine(availableSpells);
            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"Босс [{bossHealth}|{fullBossHealth}]\t"
                              + $"Маг З:[{magicianHealth}|{fullMagicianHealth}] М:[{magicianMana}|{fullMagicianMana}] Л:[{healUsesLeft}]\n");

            Console.Write("Маг произносит заклинание ");
            selectedSpell = Console.ReadLine() ?? string.Empty;

            magicianDamage = 0;
            bossDamage = random.Next(minBossDamage, maxBossDamage + 1);

            switch (selectedSpell)
            {
                case BaseAttackCommand:
                    magicianDamage = baseMagicianDamage;
                    break;

                case FireballCommand:
                    if (magicianMana < fireballCost)
                    {
                        errorMessage = string.Format(SkipsMessage, "Недостаточно маны");
                        break;
                    }

                    magicianMana -= fireballCost;
                    isFireballUsed = true;
                    magicianDamage = fireballDamage;
                    break;

                case ExplodeCommand:
                    if (isFireballUsed == false)
                    {
                        errorMessage = string.Format(SkipsMessage, "Сначала используйте огненный шар");
                        break;
                    }

                    magicianDamage = explosionDamage;
                    isFireballUsed = false;
                    break;

                case HealCommand:
                    if (healUsesLeft <= 0)
                    {
                        errorMessage = string.Format(SkipsMessage, "Исцеление недоступно");
                        break;
                    }

                    magicianHealth = Math.Min(magicianHealth + healthRestoredAmount, fullMagicianHealth);
                    magicianMana = Math.Min(magicianMana + manaRestoredAmount, fullMagicianMana);
                    healUsesLeft--;

                    break;

                default:
                    errorMessage = string.Format(SkipsMessage, "Некорректный ввод");
                    break;
            }

            if (magicianDamage > 0)
            {
                bossHealth -= magicianDamage;
                Console.WriteLine($"Маг наносит боссу {magicianDamage} урона");

                isBossAlive = bossHealth > 0;
            }
            else
            {
                Console.WriteLine(errorMessage);
            }

            if (isBossAlive)
            {
                magicianHealth -= bossDamage;
                Console.WriteLine($"Босс наносит магу {bossDamage} урона");

                isMagicianAlive = magicianHealth > 0;
            }

            Console.ReadKey();
        }

        Console.Clear();

        if (isMagicianAlive)
            Console.WriteLine("Маг уничтожил босса и обрел покой");
        else if (isBossAlive)
            Console.WriteLine("Босс оказался сильнее и маг пал");
        else
            Console.WriteLine("Босс с магом пали в неравном бою");

        Console.ReadKey();
    }
}