namespace KnightsQuest;

public class Inventory
{
    // use items and knights

    List<Item> ownedItems = new List<Item>();
    List<Knight> ownedKnights = new List<Knight>();

    public void InventoryLoop()
    {
        Console.WriteLine("Welcome to your inventory!");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Use Item");
        Console.WriteLine("2. Switch Knight");
        Console.WriteLine("3. Go Back");

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

    public void UseItem()
    {
        ownedItems.Clear();
        foreach (var item in GameLoop.Instance.items)
        {
            if (item.owned)
            {
                ownedItems.Add(item);
            }
        }

        Console.WriteLine("What item would you like to use?");
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
        Console.WriteLine($"{ownedItems.Count + 1}. Go Back");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == ownedItems.Count)
        {
            InventoryLoop();
        }
        else
        {
            ownedItems[index].Use();
            InventoryLoop();
        }
    }

    public void SwitchKnight()
    {
        ownedKnights.Clear();
        foreach (var knight in GameLoop.Instance.knights)
        {
            if (knight.owned)
            {
                ownedKnights.Add(knight);
            }
        }

        Console.WriteLine("What knight would you like to use?");
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
        Console.WriteLine($"{ownedKnights.Count + 1}. Go Back");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == ownedKnights.Count)
        {
            InventoryLoop();
        }
        else
        {
            ownedKnights[index].Use();
            InventoryLoop();
        }
    }
}
