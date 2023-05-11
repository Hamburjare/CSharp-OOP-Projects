namespace KnightsQuest;

public class Fight
{
    bool isFighting = true;
    Random random = new Random();
    int minXP = 10;
    int maxXP = 20;
    int minGold = 10;
    int maxGold = 20;

    List<Item> equippedItems = new List<Item>();

    public void SelectMonster(Knight knight)
    {
        Console.WriteLine(GameLoop.Instance.player.ToString());
        Console.WriteLine("Select a monster to fight:");
        for (int i = 0; i < GameLoop.Instance.monsters.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {GameLoop.Instance.monsters[i]}");
        }
        Console.WriteLine($"{GameLoop.Instance.monsters.Count + 1}. Go back");
        string? input = Console.ReadLine();
        if (input == null || input == "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input");
            SelectMonster(knight);
        }
        else
        {
            int index = int.Parse(input!) - 1;
            if (index == GameLoop.Instance.monsters.Count)
            {
                return;
            }
            else if (index < GameLoop.Instance.monsters.Count)
            {
                FightLoop(knight, GameLoop.Instance.monsters[index]);
            }
            else
            {
                Console.WriteLine("Invalid input");
                SelectMonster(knight);
            }
        }
    }

    void FightLoop(Knight knight, Monster monster)
    {
        foreach (Item item in GameLoop.Instance.items)
        {
            if (item.inUse)
            {
                equippedItems.Add(item);
            }
        }

        Console.Clear();

        while (isFighting)
        {
            // Knight attacks monster
            KnightAttack(knight, monster);

            // Monster attacks knight
            MonsterAttack(knight, monster);

            Console.WriteLine($"{knight.name} - {knight.health} HP");
            Console.WriteLine($"{monster.name} - {monster.health} HP");

            // Check if someone is dead
            CheckHealths(knight, monster);

            // Wait for input
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        isFighting = true;
    }

    void ResetHealths(Monster monster)
    {
        GameLoop.Instance.monsters.Find(m => m.name == monster.name).health = monster.defaultHealth;
    }

    void CheckHealths(Knight knight, Monster monster)
    {
        // Check if knight is dead
        if (knight.health <= 0)
        {
            if(GameLoop.Instance.items.Find(item => item.name == "Health Potion").owned) {
                Console.WriteLine("You have a health potion! Would you like to use it? (y/n)");
                string? input = Console.ReadLine();
                if (input == "y")
                {
                    GameLoop.Instance.items.Find(item => item.name == "Health Potion").Use();
                    Console.WriteLine("You used a health potion!");
                    return;
                }
            } 

            ResetHealths(monster);
            Console.Clear();
            Console.WriteLine($"{knight.name} has died!");
            isFighting = false;
        }

        // Check if monster is dead
        if (monster.health <= 0)
        {
            ResetHealths(monster);
            Console.Clear();
            Console.WriteLine($"{monster.name} has died!");
            isFighting = false;
            int xp = random.Next(minXP, maxXP);
            int gold = random.Next(minGold, maxGold);
            GameLoop.Instance.player.AddExperience(xp);
            GameLoop.Instance.player.AddGold(gold);

            Console.WriteLine($"You gained {xp} experience!");
            Console.WriteLine($"You gained {gold} gold!");
        }
    }

    void MonsterAttack(Knight knight, Monster monster)
    {
        // Monster attacks knight
        float monsterAttack = random.Next(monster.minAttack, monster.maxAttack);
        float knightDefense = random.Next(knight.minDefense, knight.maxDefense);

        foreach (Item item in equippedItems)
        {
            knightDefense *= item.defenseMultiplier;
        }

        float monsterDamage = monsterAttack - knightDefense;
        if (monsterDamage < 0)
        {
            monsterDamage = 0;
        }
        knight.health -= (int)monsterDamage;
        Console.WriteLine($"{monster.name} attacks {knight.name} for {monsterDamage} damage!");
    }

    void KnightAttack(Knight knight, Monster monster)
    {
        // Knight attacks monster
        float knightAttack = random.Next(knight.minAttack, knight.maxAttack);

        foreach (Item item in equippedItems)
        {
            knightAttack *= item.attackMultiplier;
        }

        if (knightAttack < 0)
        {
            knightAttack = 0;
        }
        monster.health -= (int)knightAttack;
        Console.WriteLine($"{knight.name} attacks {monster.name} for {knightAttack} damage!");
    }
}
