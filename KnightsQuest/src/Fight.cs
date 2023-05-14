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

    /// <summary>
    /// Select a monster to fight.
    /// </summary>
    public void SelectMonster(Knight knight)
    {
        // print stats
        GameLoop.Instance.PrintStats();

        // select monster
        Console.WriteLine("Select a monster to fight:");

        // print monsters
        for (int i = 0; i < GameLoop.Instance.monsters.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {GameLoop.Instance.monsters[i]}");
        }

        // print go back
        Console.WriteLine($"{GameLoop.Instance.monsters.Count + 1}. Go back");

        // get input
        string? input = Console.ReadLine();

        // check input
        if (input == null || input == "")
        {
            // invalid input

            Console.Clear();
            Console.WriteLine("Invalid input");

            // go back to select monster
            SelectMonster(knight);
        }
        else
        {
            // valid input

            Console.Clear();

            int index = int.Parse(input!) - 1;
            
            // check if index is valid
            if (index == GameLoop.Instance.monsters.Count)
            {
                // go back
                return;
            }
            else if (index < GameLoop.Instance.monsters.Count)
            {
                // check if player has high enough level
                if (GameLoop.Instance.player.level < GameLoop.Instance.monsters[index].minLevel)
                {
                    Console.WriteLine("You are too weak to fight this monster!");
                    SelectMonster(knight);
                }

                // start fight
                FightLoop(knight, GameLoop.Instance.monsters[index]);
            }
            else
            {
                // invalid input
                Console.WriteLine("Invalid input");

                // go back to select monster
                SelectMonster(knight);
            }
        }
    }

    /// <summary>
    /// Fight loop.
    /// </summary>
    /// <param name="knight">Knight.</param>
    /// <param name="monster">Monster.</param>
    void FightLoop(Knight knight, Monster monster)
    {
        // Check if knight has any equipped items
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
            knight.Attack(monster);

            // Monster attacks knight
            monster.Attack(knight);

            // Print stats
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

    /// <summary>
    /// Reset healths.
    /// </summary>
    /// <param name="monster">Monster.</param>
    void ResetHealths(Monster monster)
    {
        GameLoop.Instance.monsters.Find(m => m.name == monster.name)!.health =
            monster.defaultHealth;
    }

    /// <summary>
    /// Checks if someone is dead.
    /// </summary>
    /// <param name="knight">Knight.</param>
    /// <param name="monster">Monster.</param>
    void CheckHealths(Knight knight, Monster monster)
    {
        // Check if knight is dead
        if (knight.health <= 0)
        {
            // Check if knight has a health potion
            if (GameLoop.Instance.items.Find(item => item.name == "Health Potion")!.owned)
            {
                // Ask if player wants to use it
                Console.WriteLine("You have a health potion! Would you like to use it? (y/n)");

                // Get input
                string? input = Console.ReadLine();

                // Check input
                if (input == "y")
                {
                    // Use health potion
                    GameLoop.Instance.items.Find(item => item.name == "Health Potion")!.Use();
                    return;
                }
            }

            // Knight is dead
            ResetHealths(monster);
            Console.Clear();
            Console.WriteLine($"{knight.name} has died!");
            isFighting = false;
        }

        // Check if monster is dead
        if (monster.health <= 0)
        {
            // Monster is dead
            ResetHealths(monster);

            Console.Clear();
            Console.WriteLine($"{monster.name} has died!");
            isFighting = false;

            // Give player experience and gold
            int xp = random.Next(minXP, maxXP);
            int gold = random.Next(minGold, maxGold);

            
            GameLoop.Instance.player.AddExperience(xp);
            GameLoop.Instance.player.AddGold(gold);

            Console.WriteLine($"You gained {xp} experience!");
            Console.WriteLine($"You gained {gold} gold!");
        }
    }
}
