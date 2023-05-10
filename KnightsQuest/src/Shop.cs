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
        Console.WriteLine("4. Exit");
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
                Console.WriteLine(
                    $"{i + 1}. {GameLoop.Instance.knights[i].ToString()} ({GameLoop.Instance.knights[i].price} gold)"
                );
            }
        }
        Console.WriteLine($"{GameLoop.Instance.knights.Count + 1}. Exit");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == GameLoop.Instance.knights.Count)
        {
            GameLoop.Instance.Save();
            ShopLoop();
        }
        else if (index < GameLoop.Instance.knights.Count)
        {
            if (GameLoop.Instance.knights[index].owned)
            {
                Console.WriteLine(
                    $"You already own {GameLoop.Instance.knights[index].name} and have set it as your active knight"
                );
                foreach (var knight in GameLoop.Instance.knights)
                {
                    knight.inUse = false;
                }
                GameLoop.Instance.knights[index].inUse = true;
                GameLoop.Instance.Save();
                ShopLoop();
            }
            else if (GameLoop.Instance.player.gold >= GameLoop.Instance.knights[index].price)
            {
                GameLoop.Instance.player.gold -= GameLoop.Instance.knights[index].price;
                foreach (var knight in GameLoop.Instance.knights)
                {
                    knight.inUse = false;
                }
                GameLoop.Instance.knights[index].inUse = true;
                GameLoop.Instance.knights[index].owned = true;

                Console.WriteLine(
                    $"You bought {GameLoop.Instance.knights[index].name} for {GameLoop.Instance.knights[index].price} gold and set it as your active knight"
                );
                GameLoop.Instance.Save();
                ShopLoop();
            }
            else
            {
                Console.WriteLine("You don't have enough gold");
                GameLoop.Instance.Save();
                ShopLoop();
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
            GameLoop.Instance.Save();
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
                Console.WriteLine(
                    $"{i + 1}. {GameLoop.Instance.items[i].ToString()} ({GameLoop.Instance.items[i].price} gold)"
                );
            }
        }
        Console.WriteLine($"{GameLoop.Instance.items.Count + 1}. Exit");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == GameLoop.Instance.items.Count)
        {
            GameLoop.Instance.Save();
            ShopLoop();
        }
        else if (index < GameLoop.Instance.items.Count)
        {
            if (GameLoop.Instance.items[index].owned)
            {
                Console.WriteLine(
                    $"You already own {GameLoop.Instance.items[index].name} and have set it as your active item"
                );
                foreach (var item in GameLoop.Instance.items)
                {
                    item.inUse = false;
                }
                GameLoop.Instance.items[index].inUse = true;
                GameLoop.Instance.Save();
                ShopLoop();
            }
            else if (GameLoop.Instance.player.gold >= GameLoop.Instance.items[index].price)
            {
                GameLoop.Instance.player.gold -= GameLoop.Instance.items[index].price;
                Console.WriteLine(
                    $"You bought {GameLoop.Instance.items[index].name} for {GameLoop.Instance.items[index].price} gold and added it to your inventory"
                );

                foreach (var item in GameLoop.Instance.items)
                {
                    if (item.type == GameLoop.Instance.items[index].type)
                    {
                        item.inUse = false;
                    }
                }

                GameLoop.Instance.items[index].owned = true;
                GameLoop.Instance.items[index].inUse = true;

                GameLoop.Instance.Save();
                ShopLoop();
            }
            else
            {
                Console.WriteLine("You don't have enough gold");
                GameLoop.Instance.Save();
                ShopLoop();
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
            GameLoop.Instance.Save();
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
        Console.WriteLine($"{ownedItems.Count + 1}. Exit");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == ownedItems.Count)
        {
            GameLoop.Instance.Save();
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
            GameLoop.Instance.Save();
            ShopLoop();
        }
        else
        {
            Console.WriteLine("Invalid input");
            GameLoop.Instance.Save();
            ShopLoop();
        }
    }
}
