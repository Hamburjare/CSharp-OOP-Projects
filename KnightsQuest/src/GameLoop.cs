namespace KnightsQuest;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class GameLoop
{
    public List<Knight> knights = new List<Knight>();
    public List<Monster> monsters = new List<Monster>();
    public List<Item> items = new List<Item>();

    Shop shop = new Shop();

    public Player player = new Player();

    public Fight fight = new Fight();

    public static GameLoop Instance { get; private set; } = null!;

    public Knight? enabledKnight;

    Inventory inventory = new Inventory();

    public GameLoop()
    {
        Instance = this;

        // Create new game

        // Create player
        player = new Player();

        // Create knights
        knights.Add((Knight)new Lancelot());
        knights.Add((Knight)new Robin());
        knights.Add((Knight)new KingArthur());

        // Create monsters
        monsters.Add((Monster)new Rabbit());
        monsters.Add((Monster)new BlackKnight());
        monsters.Add((Monster)new FrenchTaunter());

        // Create items
        items.Add((Item)new HealthPotion());
        items.Add((Item)new WoodSword());
        items.Add((Item)new WoodShield());
        items.Add((Item)new SilverShield());
        items.Add((Item)new SilverSword());
    }

    Knight SelectKnight()
    {
        Console.WriteLine("Select a knight:");
        for (int i = 0; i < knights.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {knights[i].name}");
        }

        var input = Console.ReadLine();

        if (int.TryParse(input, out int index))
        {
            if (index > 0 && index <= knights.Count)
            {
                knights[index - 1].inUse = true;
                return knights[index - 1];
            }
        }

        Console.WriteLine("Invalid input");
        return SelectKnight();
    }

    public void PrintStats()
    {
        Console.WriteLine(player.ToString());
        Console.WriteLine($"You are playing as {enabledKnight!.name}");
    }

    public void Run()
    {
        bool running = true;
        Console.Clear();
        Console.WriteLine("Welcome to Knights Quest!");

        while (running)
        {
            foreach (var knight in knights)
            {
                if (knight.inUse)
                {
                    enabledKnight = knight;
                }
            }

            if (enabledKnight == null)
            {
                enabledKnight = SelectKnight();
            }

            PrintStats();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Shop");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("4. Quit");

            var input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    if (enabledKnight.health < enabledKnight.defaultHealth)
                    {
                        if (items.Find(item => item.name == "Health Potion")!.owned)
                        {
                            Console.WriteLine(
                                "Your knight does not have full health, would you like to use a health potion? (y/n)"
                            );
                            var potionInput = Console.ReadLine();
                            if (potionInput!.ToLower() == "y")
                            {
                                items.Find(item => item.name == "Health Potion")!.Use();
                            }
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine(
                                "Your knight does not have full health and you do not have any health potions."
                            );
                            Console.WriteLine("Do you want to continue anyway? (y/n)");
                            var potionInput = Console.ReadLine();
                            if (potionInput!.ToLower() == "n")
                            {
                                Console.Clear();
                                break;
                            }
                            Console.Clear();
                        }
                    }
                    fight.SelectMonster(enabledKnight!);
                    break;
                case "2":
                    shop.ShopLoop();
                    break;
                case "3":
                    inventory.InventoryLoop();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
