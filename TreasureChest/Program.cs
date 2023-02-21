namespace TreasureChest;

enum ChestState
{
    Locked,
    Open,
    Closed
}

class Chest
{
    public ChestState State { get; private set; }

    public int goldInChest { get; private set; }

    public Chest()
    {
        State = ChestState.Closed;
    }

    public void Open()
    {
        if (State == ChestState.Closed)
        {
            State = ChestState.Open;
        }
    }

    public void Close()
    {
        if (State == ChestState.Open)
        {
            State = ChestState.Closed;
        }
    }

    public void Lock()
    {
        if (State == ChestState.Closed)
        {
            State = ChestState.Locked;
        }
    }

    public void Unlock()
    {
        if (State == ChestState.Locked)
        {
            State = ChestState.Closed;
        }
    }

    public string PutGold(int gold)
    {
        if (State == ChestState.Open)
        {
            if (gold <= 0)
            {
                return "error";
            }
            goldInChest += gold;
            return "done";
        }
        return "not open";
    }

    public string TakeGold(int gold)
    {
        if (State == ChestState.Open)
        {
            if (gold <= 0 || gold > goldInChest)
            {
                return "error";
            }
            goldInChest -= gold;
            return "done";
        }
        return "not open";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Chest chest = new Chest();
        while (true)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.WriteLine("Chest is {0}", chest.State);
            Console.WriteLine("There is {0} gold in the chest", chest.goldInChest);
            Console.WriteLine("Commands: open, close, lock, unlock, put, take, quit");
            Console.Write("What do you want to do to the treasure chest: ");
            string? command = Console.ReadLine();
            switch (command?.ToLower())
            {
                case "open":
                    chest.Open();
                    break;
                case "close":
                    chest.Close();
                    break;
                case "lock":
                    chest.Lock();
                    break;
                case "unlock":
                    chest.Unlock();
                    break;
                case "put":
                    Console.Write("How much gold do you want to put in the chest: ");
                    string? gold = Console.ReadLine();
                    if (gold != null)
                    {
                        string goldPut = chest.PutGold(int.Parse(gold));
                        if (goldPut == "error")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can't put negative gold in the chest");
                            Console.ResetColor();
                        }
                        else if (goldPut != "not open")
                        {
                            Console.WriteLine("You put {0} gold in the chest", gold);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(
                                "You can't put gold in the chest while it is {0}",
                                chest.State.ToString().ToLower()
                            );
                            Console.ResetColor();
                        }
                    }
                    break;
                case "take":
                    Console.Write("How much gold do you want to take from the chest: ");
                    gold = Console.ReadLine();
                    if (gold != null)
                    {
                        string goldTake = chest.TakeGold(int.Parse(gold));
                        if (goldTake == "error")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(
                                "You can't take negative gold from the chest or more than there is in the chest"
                            );
                            Console.ResetColor();
                        }
                        else if (goldTake != "not open")
                        {
                            Console.WriteLine("You took {0} gold from the chest", gold);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine(
                                "You can't take gold from the chest while it is {0}",
                                chest.State.ToString().ToLower()
                            );
                            Console.ResetColor();
                        }
                    }
                    break;
                case "quit":
                    return;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }
}
