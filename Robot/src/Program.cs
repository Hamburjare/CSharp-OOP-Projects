namespace Robot;
class Program
{
    static void Main(string[] args)
    {
        var robot = new Robot();

        while (true)
        {
            Console.WriteLine($"Commands in queue: {string.Join(", ", robot.Commands.Select(c => c.GetType().Name))}");
            Console.WriteLine("Commands: on, off, up, down, left, right, clear, execute, exit");
            Console.Write("Enter command: ");
            string? command = Console.ReadLine();
            switch (command)
            {
                case "on":
                    robot.AddCommand(new TurnOn());
                    break;
                case "off":
                    robot.AddCommand(new TurnOff());
                    break;
                case "up":
                    robot.AddCommand(new MoveUp());
                    break;
                case "down":
                    robot.AddCommand(new MoveDown());
                    break;
                case "left":
                    robot.AddCommand(new MoveLeft());
                    break;
                case "right":
                    robot.AddCommand(new MoveRight());
                    break;
                case "clear":
                    robot.ClearCommands();
                    break;
                case "execute":
                    robot.ExecuteCommands();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
