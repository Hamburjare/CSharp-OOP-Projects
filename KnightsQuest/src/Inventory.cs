namespace KnightsQuest;

public class Inventory
{
    List<Item> ownedItems = new List<Item>();
    List<Knight> ownedKnights = new List<Knight>();

    /// <summary>
    /// Main inventory loop.
    /// </summary>
    public void InventoryLoop()
    {
        Console.WriteLine("Welcome to your inventory!");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Use Item");
        Console.WriteLine("2. Switch Knight");
        Console.WriteLine("3. Go Back");

        // Get input
        string? input = Console.ReadLine();
        Console.Clear();

        switch (input)
        {
            case "1":
                UseItem();
                break;
            case "2":
                SwitchKnight();
                break;
            case "3":
                break;
            default:
                Console.WriteLine("Invalid input");
                InventoryLoop();
                break;
        }
    }

    /// <summary>
    /// Use an item.
    /// </summary>
    public void UseItem()
    {
        // Get owned items
        ownedItems.Clear();
        foreach (var item in GameLoop.Instance.items)
        {
            if (item.owned)
            {
                ownedItems.Add(item);
            }
        }

        Console.WriteLine("What item would you like to use?");

        // Display owned items
        for (int i = 0; i < ownedItems.Count; i++)
        {
            if (ownedItems[i].inUse)
            {
                Console.WriteLine($"{i + 1}. {ownedItems[i].ToString()} (In Use)");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {ownedItems[i].ToString()}");
            }
        }

        // Display go back option
        Console.WriteLine($"{ownedItems.Count + 1}. Go Back");

        // Get input
        string? input = Console.ReadLine();
        Console.Clear();

        // Parse input
        int index = int.Parse(input!) - 1;
        
        // Check input
        switch (index)
        {
            case int i when i == ownedItems.Count:
                // if go back option is selected, go back
                InventoryLoop();
                break;
            case int i when i < ownedItems.Count:
                // if item is selected, use it
                ownedItems[index].Use();
                InventoryLoop();
                break;
            default:
                Console.WriteLine("Invalid input");
                InventoryLoop();
                break;
        }
    }

    /// <summary>
    /// Switch knight.
    /// </summary>
    public void SwitchKnight()
    {
        // Get owned knights
        ownedKnights.Clear();
        foreach (var knight in GameLoop.Instance.knights)
        {
            if (knight.owned)
            {
                ownedKnights.Add(knight);
            }
        }

        Console.WriteLine("What knight would you like to use?");

        // Display owned knights
        for (int i = 0; i < ownedKnights.Count; i++)
        {
            if (ownedKnights[i].inUse)
            {
                Console.WriteLine($"{i + 1}. {ownedKnights[i].ToString()} (In Use)");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {ownedKnights[i].ToString()}");
            }
        }

        // Display go back option
        Console.WriteLine($"{ownedKnights.Count + 1}. Go Back");

        // Get input
        string? input = Console.ReadLine();
        Console.Clear();

        // Parse input
        int index = int.Parse(input!) - 1;

        // Check input
        switch (index)
        {
            case int i when i == ownedKnights.Count:
                // if go back option is selected, go back
                InventoryLoop();
                break;
            case int i when i < ownedKnights.Count:
                // if knight is selected, use it
                ownedKnights[index].Use();
                InventoryLoop();
                break;
            default:
                Console.WriteLine("Invalid input");
                InventoryLoop();
                break;
        }
    }
}
