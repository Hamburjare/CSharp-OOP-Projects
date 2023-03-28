namespace Robot;

public class TurnOn : Command
{
    public override void Execute(Robot robot)
    {
        robot.IsOn = true;
    }
}

public class TurnOff : Command
{
    public override void Execute(Robot robot)
    {
        robot.IsOn = false;
    }
}

public class MoveUp : Command
{
    public override void Execute(Robot robot)
    {
        if (robot.IsOn)
        {
            robot.Y++;
        }
    }
}

public class MoveDown : Command
{
    public override void Execute(Robot robot)
    {
        if (robot.IsOn)
        {
            robot.Y--;
        }
    }
}

public class MoveLeft : Command
{
    public override void Execute(Robot robot)
    {
        if (robot.IsOn)
        {
            robot.X--;
        }
    }
}

public class MoveRight : Command
{
    public override void Execute(Robot robot)
    {
        if (robot.IsOn)
        {
            robot.X++;
        }
    }
}