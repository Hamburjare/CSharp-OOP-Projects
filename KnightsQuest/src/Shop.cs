namespace KnightsQuest;

public class Shop
{
    public void ShopLoop()
    {
        Console.WriteLine("Welcome to the shop!");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Buy Item");
        Console.WriteLine("2. Buy Knight");
        Console.WriteLine("3. Sell");
        Console.WriteLine("4. Go Back");
        string? input = Console.ReadLine();
        Console.Clear();
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

    public void BuyKnight()
    {
        Console.WriteLine("What would you like to buy?");
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
        Console.WriteLine($"{GameLoop.Instance.knights.Count + 1}. Go Back");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == GameLoop.Instance.knights.Count)
        {
            ShopLoop();
        }
        else if (index < GameLoop.Instance.knights.Count)
        {
            if (GameLoop.Instance.knights[index].owned)
            {
                Console.WriteLine($"You already own {GameLoop.Instance.knights[index].name}.");
                ShopLoop();
            }
            else if (GameLoop.Instance.player.gold >= GameLoop.Instance.knights[index].price)
            {
                GameLoop.Instance.knights[index].Buy();

                ShopLoop();
            }
            else
            {
                Console.WriteLine("You don't have enough gold");
                ShopLoop();
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
            ShopLoop();
        }
    }

    public void Buy()
    {
        Console.WriteLine("What would you like to buy?");
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
        Console.WriteLine($"{GameLoop.Instance.items.Count + 1}. Go Back");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == GameLoop.Instance.items.Count)
        {
            ShopLoop();
        }
        else if (index < GameLoop.Instance.items.Count)
        {
            if (GameLoop.Instance.items[index].owned)
            {
                Console.WriteLine($"You already own {GameLoop.Instance.items[index].name}.");
                ShopLoop();
            }
            else if (GameLoop.Instance.player.gold >= GameLoop.Instance.items[index].price)
            {
                GameLoop.Instance.items[index].Buy();

                ShopLoop();
            }
            else
            {
                Console.WriteLine("You don't have enough gold");
                ShopLoop();
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
            ShopLoop();
        }
    }

    public void Sell()
    {
        List<Item> ownedItems = new List<Item>();
        foreach (var item in GameLoop.Instance.items)
        {
            if (item.owned && item.price > 0)
            {
                ownedItems.Add(item);
            }
        }
        Console.WriteLine("What would you like to sell?");
        for (int i = 0; i < ownedItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ownedItems[i].name} - {ownedItems[i].price} gold");
        }
        Console.WriteLine($"{ownedItems.Count + 1}. Go Back");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == ownedItems.Count)
        {
            ShopLoop();
        }
        else if (index < ownedItems.Count)
        {
            GameLoop.Instance.player.gold += ownedItems[index].price;
            Console.WriteLine(
                $"You sold {ownedItems[index].name} for {ownedItems[index].price} gold"
            );
            GameLoop.Instance.items.Find(item => item.name == ownedItems[index].name).owned = false;
            GameLoop.Instance.items.Find(item => item.name == ownedItems[index].name).inUse = false;
            ShopLoop();
        }
        else
        {
            Console.WriteLine("Invalid input");
            ShopLoop();
        }
    }
}
