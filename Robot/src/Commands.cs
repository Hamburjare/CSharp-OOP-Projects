namespace Robot;

public interface ICommand
{
    void Execute(Robot robot);
}

public class TurnOn : ICommand
{
    public void Execute(Robot robot)
    {
        robot.IsOn = true;
    }
}

public class TurnOff : ICommand
{
    public void Execute(Robot robot)
    {
        robot.IsOn = false;
    }
}

public class MoveUp : ICommand
{
    public void Execute(Robot robot)
    {
        if (robot.IsOn)
        {
            robot.Y++;
        }
    }
}

public class MoveDown : ICommand
{
    public void Execute(Robot robot)
    {
        if (robot.IsOn)
        {
            robot.Y--;
        }
    }
}

public class MoveLeft : ICommand
{
    public void Execute(Robot robot)
    {
        if (robot.IsOn)
        {
            robot.X--;
        }
    }
}

public class MoveRight : ICommand
{
    public void Execute(Robot robot)
    {
        if (robot.IsOn)
        {
            robot.X++;
        }
    }
}
