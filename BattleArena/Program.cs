namespace BattleArena;

enum Elements
{
    Fire,
    Ice,
    Air,
    Earth,
    Water,
    Light,
    Dark
}

class Program
{
    static void Main(string[] args)
    {
        int rounds = 3;
        Monster player = CreateMonster();

        for (int i = 0; i < rounds; i++)
        {
            Monster monsterAI = CreateRandomMonster();
            Fight(player, monsterAI);
            if (!player.IsAlive())
            {
                break;
            }
            Console.WriteLine(new string('-', Console.WindowWidth));

            player.PrintStats();
            Console.WriteLine(new string('-', Console.WindowWidth));

            Shop(player);
        }
        if (player.IsAlive())
        {
            Console.WriteLine("You won the turnament!");
        }
        else
        {
            Console.WriteLine("You lost the turnament!");
        }
    }

    public static void Shop(Monster player)
    {
        Console.WriteLine("Welcome to the shop!");
        Console.WriteLine("What would you like to buy?");
        Console.WriteLine("1. Health Potion");
        Console.WriteLine("2. Mana Potion");
        while (true)
        {
            string? choice2 = Console.ReadLine();
            switch (choice2)
            {
                case "1":
                    Console.WriteLine("You bought a health potion! And it healed you!");

                    player.RestoreHealth();
                    return;
                case "2":
                    Console.WriteLine("You bought a mana potion! And it restored your mana!");

                    player.RestoreMana();
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    continue;
            }
            return;
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void Fight(Monster player, Monster monsterAI)
    {
        while (player.IsAlive() && monsterAI.IsAlive())
        {
            Console.Clear();
            player.PrintStats();
            Console.WriteLine(new string('-', Console.WindowWidth));

            monsterAI.PrintStats();
            PlayersTurn(player, monsterAI);
            if (!monsterAI.IsAlive())
            {
                break;
            }
            AIsTurn(player, monsterAI);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        if (player.IsAlive())
        {
            Console.Clear();
            Console.WriteLine($"{player.GetName()} won the fight!");
        }
        else
        {
            Console.WriteLine($"{monsterAI.GetName()} won the fight!");
        }
    }

    public static void PlayersTurn(Monster player, Monster enemy)
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Element Attack");
        while (true)
        {
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    float defaultAttack = player.DefaultAttack();
                    enemy.TakeDamage(defaultAttack);
                    Console.WriteLine($"{player.GetName()} made {defaultAttack} damage!");
                    break;
                case "2":
                    float attack = player.ElementAttack(player.GetElement(), enemy.GetElement());
                    enemy.TakeDamage(attack);
                    if (attack == -1)
                    {
                        Console.WriteLine(
                            $"{player.GetName()} tried to use an element attack, but didn't have enough mana!"
                        );
                    }
                    else if (attack == 0)
                    {
                        Console.WriteLine(
                            $"{player.GetName()} tried to use an element attack, but it had no effect!"
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            $"{player.GetName()} used an element attack and made {attack} damage!"
                        );
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    continue;
            }
            return;
        }
    }

    public static void AIsTurn(Monster player, Monster enemy)
    {
        Random random = new Random();
        int choice = random.Next(1, 3);
        switch (choice)
        {
            case 1:
                float defaultAttack = enemy.DefaultAttack();
                player.TakeDamage(defaultAttack);
                Console.WriteLine($"{enemy.GetName()} made {defaultAttack} damage!");
                break;
            case 2:
                float attack = enemy.ElementAttack(enemy.GetElement(), player.GetElement());
                player.TakeDamage(attack);
                if (attack == -1)
                {
                    Console.WriteLine(
                        $"{enemy.GetName()} tried to use an element attack, but didn't have enough mana!"
                    );
                }
                else if (attack == 0)
                {
                    Console.WriteLine(
                        $"{enemy.GetName()} tried to use an element attack, but it had no effect!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        $"{enemy.GetName()} used an element attack and made {attack} damage!"
                    );
                }
                break;
        }
    }

    public static Monster CreateMonster()
    {
        Console.Write("What is the name of your monster? ");
        string? name = Console.ReadLine();

        Console.Write(
            "What is the element of your monster? (Fire, Ice, Water, Earth, Air, Light, Dark) "
        );
        string? element = Console.ReadLine();
        while (true)
        {
            if (Enum.TryParse(element, out Elements elementEnum))
            {
                return new Monster(name, elementEnum);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Console.Write(
                    "What is the element of your monster? (Fire, Ice, Water, Earth, Air, Light, Dark) "
                );
                element = Console.ReadLine();
            }
        }
    }

    public static Monster CreateRandomMonster()
    {
        Random random = new Random();
        string[] names = new string[]
        {
            "Bob",
            "John",
            "Steve",
            "Joe",
            "Bill",
            "Tom",
            "Jim",
            "Mike",
            "Dave",
            "Jeff"
        };
        string name = names[random.Next(0, names.Length)];
        Elements element = (Elements)random.Next(0, Enum.GetNames(typeof(Elements)).Length);
        return new Monster($"{name} (AI)", element);
    }
}

class Monster
{
    string name { get; set; }
    Elements element { get; set; }
    float health { get; set; }
    int maxHealth { get; set; }
    int mana { get; set; }
    int maxMana { get; set; }

    public Monster(string name, Elements element)
    {
        Random random = new Random();
        this.name = name;
        this.element = element;
        this.maxHealth = random.Next(30, 51);
        this.health = this.maxHealth;
        this.maxMana = random.Next(10, 21);
        this.mana = this.maxMana;
    }

    public void PrintStats()
    {
        Console.WriteLine($"Stats for {this.name}");
        Console.WriteLine("Name: " + this.name);
        Console.WriteLine("Elements: " + this.element);
        Console.WriteLine("Health: " + this.health + "/" + this.maxHealth);
        Console.WriteLine("Mana: " + this.mana + "/" + this.maxMana);
    }

    public string GetName()
    {
        return this.name;
    }

    public Elements GetElement()
    {
        return this.element;
    }

    public bool IsAlive()
    {
        return this.health > 0;
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
    }

    public void RestoreHealth()
    {
        health = maxHealth;
    }

    public float GetHealth()
    {
        return this.health;
    }

    public float GetMaxHealth()
    {
        return this.maxHealth;
    }

    public void RestoreMana()
    {
        mana = maxMana;
    }

    public float GetMana()
    {
        return this.mana;
    }

    public float GetMaxMana()
    {
        return this.maxMana;
    }

    public int DefaultAttack()
    {
        Random random = new Random();
        return random.Next(3, 7);
    }

    public float ElementAttack(Elements monsterElement, Elements opponentElement)
    {
        Random random = new Random();
        if (mana < 5)
        {
            return -1;
        }

        mana -= 5;

        if (opponentElement == element)
        {
            return 0;
        }

        float multiplier = 1f;

        if (monsterElement == Elements.Fire && opponentElement == Elements.Ice)
        {
            multiplier = 2f;
        }
        else if (monsterElement == Elements.Water && opponentElement == Elements.Fire)
        {
            multiplier = 0.5f;
        }
        else if (monsterElement == Elements.Air && opponentElement == Elements.Earth)
        {
            multiplier = 0.5f;
        }
        else if (monsterElement == Elements.Earth && opponentElement == Elements.Air)
        {
            multiplier = 2f;
        }
        else if (monsterElement == Elements.Ice && opponentElement == Elements.Water)
        {
            multiplier = 2f;
        }
        else if (monsterElement == Elements.Fire && opponentElement == Elements.Water)
        {
            multiplier = 0.5f;
        }
        else if (monsterElement == Elements.Water && opponentElement == Elements.Air)
        {
            multiplier = 2f;
        }
        else if (monsterElement == Elements.Air && opponentElement == Elements.Ice)
        {
            multiplier = 2f;
        }
        else if (monsterElement == Elements.Ice && opponentElement == Elements.Earth)
        {
            multiplier = 0.5f;
        }
        else if (monsterElement == Elements.Earth && opponentElement == Elements.Fire)
        {
            multiplier = 2f;
        }
        else if (monsterElement == Elements.Light && opponentElement == Elements.Dark)
        {
            multiplier = 2f;
        }
        else if (monsterElement == Elements.Dark && opponentElement == Elements.Light)
        {
            multiplier = 2f;
        }

        return random.Next(6, 11) * multiplier;
    }
}
