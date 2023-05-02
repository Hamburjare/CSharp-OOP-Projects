namespace Robot;

public class Robot
{
    private int x;

    private int y;

    public int X
    {
        get => x;
        set => x = value;
    }

    public int Y
    {
        get => y;
        set => y = value;
    }

    private bool isOn;

    public bool IsOn
    {
        get => isOn;
        set => isOn = value;
    }

    private List<ICommand> commands = new List<ICommand>();

    public List<ICommand> Commands
    {
        get => commands;
    }

    public Robot()
    {
        x = 0;
        y = 0;
        isOn = false;
    }

    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (ICommand command in commands)
        {
            command.Execute(this);
            string status = isOn ? "is on" : "is off";
            Console.WriteLine($"Robot {status}. Coordinates ({x}, {y}).");
        }
    }

    public void ClearCommands()
    {
        commands.Clear();
    }
    
}
