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
            // if GameLoop.Instance.knights name is in players GameLoop.Instance.knights list
            
            if (GameLoop.player.knights.Contains(GameLoop.Instance.knights[i]))
            {
                Console.WriteLine($"{i + 1}. {GameLoop.Instance.knights[i].name} (Owned)");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {GameLoop.Instance.knights[i].name} ({GameLoop.Instance.knights[i].price} gold)");
            }
        }
        Console.WriteLine($"{GameLoop.Instance.knights.Count + 1}. Exit");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == GameLoop.Instance.knights.Count)
        {
            GameLoop.Instance.Save();
            GameLoop.Instance.Save();
            ShopLoop();
        }
        else if (index < GameLoop.Instance.knights.Count)
        {
            if (GameLoop.player.knights.Contains(GameLoop.Instance.knights[index]))
            {
                Console.WriteLine("You already own this knight");
                GameLoop.Instance.Save();
                ShopLoop();
            }
            else if (GameLoop.player.gold >= GameLoop.Instance.knights[index].price)
            {
                GameLoop.player.gold -= GameLoop.Instance.knights[index].price;
                foreach (var knight in GameLoop.player.knights)
                {
                    knight.inUse = false;
                }
                GameLoop.Instance.knights[index].inUse = true;

                GameLoop.player.knights.Add(GameLoop.Instance.knights[index]);
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
            Console.WriteLine($"{i + 1}. {GameLoop.Instance.items[i].name} - {GameLoop.Instance.items[i].price} gold");
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
            if (GameLoop.player.gold >= GameLoop.Instance.items[index].price)
            {
                GameLoop.player.gold -= GameLoop.Instance.items[index].price;
                GameLoop.player.items.Add(GameLoop.Instance.items[index]);
                Console.WriteLine($"You bought {GameLoop.Instance.items[index].name} for {GameLoop.Instance.items[index].price} gold");
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
        Console.WriteLine("What would you like to sell?");
        for (int i = 0; i < GameLoop.player.items.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {GameLoop.player.items[i].name} - {GameLoop.player.items[i].price} gold"
            );
        }
        Console.WriteLine($"{GameLoop.player.items.Count + 1}. Exit");
        string? input = Console.ReadLine();
        Console.Clear();
        int index = int.Parse(input!) - 1;
        if (index == GameLoop.player.items.Count)
        {
            GameLoop.Instance.Save();
            ShopLoop();
        }
        else if (index < GameLoop.player.items.Count)
        {
            GameLoop.player.gold += GameLoop.player.items[index].price;
            Console.WriteLine(
                $"You sold {GameLoop.player.items[index].name} for {GameLoop.player.items[index].price} gold"
            );
            GameLoop.player.items.RemoveAt(index);
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
