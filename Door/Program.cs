enum DoorState
{
    Open,
    Closed,
    Locked
};

class Door
{
    public DoorState State { get; private set; }

    public Door()
    {
        State = DoorState.Closed;
    }

    public void Open()
    {
        if (State == DoorState.Closed)
        {
            State = DoorState.Open;
        }
    }

    public void Close()
    {
        if (State == DoorState.Open)
        {
            State = DoorState.Closed;
        }
    }

    public void Lock()
    {
        if (State == DoorState.Closed)
        {
            State = DoorState.Locked;
        }
    }

    public void Unlock()
    {
        if (State == DoorState.Locked)
        {
            State = DoorState.Closed;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Door door = new Door();
        while(true)
        {
            Console.WriteLine("Door is {0}", door.State);
            Console.Write("What do you want to do: ");
            string? command = Console.ReadLine();
            switch (command?.ToLower())
            {
                case "open":
                    door.Open();
                    break;
                case "close":
                    door.Close();
                    break;
                case "lock":
                    door.Lock();
                    break;
                case "unlock":
                    door.Unlock();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

    }
}