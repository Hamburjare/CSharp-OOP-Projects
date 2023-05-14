namespace KnightsQuest;

public class Shop
{
    /// <summary>
    /// Shop loop.
    /// </summary>
    public void ShopLoop()
    {
        Console.WriteLine("Welcome to the shop!");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Buy Item");
        Console.WriteLine("2. Buy Knight");
        Console.WriteLine("3. Sell");
        Console.WriteLine("4. Go Back");

        // Get input
        string? input = Console.ReadLine();
        Console.Clear();

        // Check input
        switch (input)
        {
            case "1":
                Buy();
                break;
            case "2":
                BuyKnight();
                break;
            case "3":
                Sell();
                break;
            case "4":
                break;
            default:
                Console.WriteLine("Invalid input");
                ShopLoop();
                break;
        }
    }

    /// <summary>
    /// Buy a knight.
    /// </summary>
    public void BuyKnight()
    {
        Console.WriteLine("What would you like to buy?");

        // Display knights
        for (int i = 0; i < GameLoop.Instance.knights.Count; i++)
        {
            if (GameLoop.Instance.knights[i].inUse && GameLoop.Instance.knights[i].owned)
            {
                Console.WriteLine(
                    $"{i + 1}. {GameLoop.Instance.knights[i].ToString()} (Owned) (In Use)"
                );
            }
            else if (GameLoop.Instance.knights[i].owned)
            {
                Console.WriteLine($"{i + 1}. {GameLoop.Instance.knights[i].ToString()} (Owned)");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {GameLoop.Instance.knights[i].ToString()}");
            }
        }

        // Display go back option
        Console.WriteLine($"{GameLoop.Instance.knights.Count + 1}. Go Back");

        // Get input
        string? input = Console.ReadLine();
        Console.Clear();

        // Check input
        int index = int.Parse(input!) - 1;

        switch (index)
        {
            case int i when i == GameLoop.Instance.knights.Count:
                // if go back option is selected, go back
                ShopLoop();
                break;
            case int i when i < GameLoop.Instance.knights.Count:
                // Check if knight is owned
                if (GameLoop.Instance.knights[index].owned)
                {
                    // Player already owns knight
                    Console.WriteLine($"You already own {GameLoop.Instance.knights[index].name}.");
                    ShopLoop();
                }
                else if (GameLoop.Instance.player.gold >= GameLoop.Instance.knights[index].price)
                {
                    // Player has enough gold so buy knight
                    GameLoop.Instance.knights[index].Buy();

                    // Go back to shop
                    ShopLoop();
                }
                else
                {
                    // Player doesn't have enough gold
                    Console.WriteLine("You don't have enough gold");

                    // Go back to shop
                    ShopLoop();
                }
                break;
            default:
                Console.WriteLine("Invalid input");
                ShopLoop();
                break;
        }
    }

    /// <summary>
    /// Buy an item.
    /// </summary>
    public void Buy()
    {
        Console.WriteLine("What would you like to buy?");

        // Display items
        for (int i = 0; i < GameLoop.Instance.items.Count; i++)
        {
            if (GameLoop.Instance.items[i].inUse && GameLoop.Instance.items[i].owned)
            {
                Console.WriteLine(
                    $"{i + 1}. {GameLoop.Instance.items[i].ToString()} (Owned) (In Use)"
                );
            }
            else if (GameLoop.Instance.items[i].owned)
            {
                Console.WriteLine($"{i + 1}. {GameLoop.Instance.items[i].ToString()} (Owned)");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {GameLoop.Instance.items[i].ToString()}");
            }
        }

        // Display go back option
        Console.WriteLine($"{GameLoop.Instance.items.Count + 1}. Go Back");

        // Get input
        string? input = Console.ReadLine();
        Console.Clear();

        // Check input
        int index = int.Parse(input!) - 1;

        switch (index)
        {
            case int i when i == GameLoop.Instance.items.Count:
                // if go back option is selected, go back
                ShopLoop();
                break;
            case int i when i < GameLoop.Instance.items.Count:
                // Check if item is owned
                if (GameLoop.Instance.items[index].owned)
                {
                    // Player already owns item
                    Console.WriteLine($"You already own {GameLoop.Instance.items[index].name}.");
                    ShopLoop();
                }
                else if (GameLoop.Instance.player.gold >= GameLoop.Instance.items[index].price)
                {
                    // Player has enough gold so buy item
                    GameLoop.Instance.items[index].Buy();

                    // Go back to shop
                    ShopLoop();
                }
                else
                {
                    // Player doesn't have enough gold
                    Console.WriteLine("You don't have enough gold");

                    // Go back to shop
                    ShopLoop();
                }
                break;
            default:
                Console.WriteLine("Invalid input");
                ShopLoop();
                break;
        }
    }

    /// <summary>
    /// Sell an item.
    /// </summary>
    public void Sell()
    {
        // Get owned items
        List<Item> ownedItems = new List<Item>();
        foreach (var item in GameLoop.Instance.items)
        {
            if (item.owned && item.price > 0)
            {
                ownedItems.Add(item);
            }
        }

        // Ask what item to sell
        Console.WriteLine("What would you like to sell?");

        // Display owned items
        for (int i = 0; i < ownedItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ownedItems[i].name} - {ownedItems[i].price} gold");
        }

        // Display go back option
        Console.WriteLine($"{ownedItems.Count + 1}. Go Back");

        // Get input
        string? input = Console.ReadLine();
        Console.Clear();

        // Check input
        int index = int.Parse(input!) - 1;

        switch (index)
        {
            case int i when i == ownedItems.Count:
                // if go back option is selected, go back
                ShopLoop();
                break;
            case int i when i < ownedItems.Count:
                // Check if item is in use
                if (ownedItems[index].inUse)
                {
                    // Item is in use
                    Console.WriteLine(
                        $"You can't sell {ownedItems[index].name} because it is in use."
                    );
                    ShopLoop();
                }
                else
                {
                    // Sell item
                    GameLoop.Instance.player.gold += ownedItems[index].price;
                    Console.WriteLine(
                        $"You sold {ownedItems[index].name} for {ownedItems[index].price} gold"
                    );
                    GameLoop.Instance.items
                        .Find(item => item.name == ownedItems[index].name)!
                        .owned = false;
                    ShopLoop();
                }
                break;
            default:
                Console.WriteLine("Invalid input");
                ShopLoop();
                break;
        }
    }
}
