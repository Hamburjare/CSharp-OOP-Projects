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

    string savePath = @"saves\save.json";

    public static GameLoop Instance { get; private set; } = null!;

    Knight? enabledKnight;

    public GameLoop()
    {
        Instance = this;
        Save save;

        // Load save file
        // If no save file, create new game
        // If save file, load game
        // Run game loop
        // Save game

        if (File.Exists(savePath))
        {
            save = JsonConvert.DeserializeObject<Save>(File.ReadAllText(savePath))!;

            player = save.player;
            knights = save.knights;
            monsters = save.monsters;
            items = save.items;
        }
        else
        {
            // Create new game
            // Create player
            player = new Player();
            // Create knights
            knights.Add((Knight)new Lancelot());
            knights.Add((Knight)new Robin());
            // knights.Add(new Knight("Sir Robin", 100, 10, 10, 10, new(), new(), 10, 10, 10));
            // knights.Add(new Knight("Sir Galahad", 100, 10, 10, 10, new(), new(), 10, 10, 10));
            // knights.Add(new Knight("Sir Bedevere", 100, 10, 10, 10, new(), new(), 10, 10, 10));
            // knights.Add(new Knight("King Arthur", 100, 10, 10, 10, new(), new(), 10, 10, 10));
            // Create monsters
            monsters.Add((Monster)new Rabbit());
            monsters.Add((Monster)new BlackKnight());
            // monsters.Add(new Monster("Rabbit", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // monsters.Add(new Monster("Black Knight", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // monsters.Add(new Monster("French Taunter", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // monsters.Add(new Monster("Tim the Enchanter", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // monsters.Add(new Monster("Killer Rabbit of Caerbannog", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // // Create items
            items.Add((Item)new WoodSword());
            items.Add((Item)new WoodShield());
            items.Add((Item)new SilverShield());
            items.Add((Item)new SilverSword());
            // items.Add(new Item("Holy Hand Grenade", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // items.Add(new Item("Coconut", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // items.Add(new Item("Shrubbery", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // items.Add(new Item("Grail", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            // items.Add(new Item("Rabbit's Foot", 100, 10, 10, 10, 10, 10, 10, 10, 10, 10));

            // Create save
            save = new Save(player, monsters, items, knights);

            var saveContent = JsonConvert.SerializeObject(save);

            Console.WriteLine(saveContent);

            // Save game
            Save();
        }
    }

    public void Save()
    {
        Save save = new Save(player, monsters, items, knights);

        // Save game

        // Create save directory if it doesn't exist
        if (!Directory.Exists(Path.GetDirectoryName(savePath)))
            Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

        File.WriteAllText(savePath, JsonConvert.SerializeObject(save));

        Console.WriteLine("Game saved!");
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

            Console.WriteLine(player.ToString());
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Shop");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Quit");

            var input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    fight.SelectMonster(enabledKnight!);
                    break;
                case "2":
                    shop.ShopLoop();
                    break;
                case "3":
                    Save();
                    break;
                case "4":
                    Save();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
