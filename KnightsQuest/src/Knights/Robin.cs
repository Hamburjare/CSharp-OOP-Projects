namespace KnightsQuest;

public class Robin : Knight
{
    public override bool owned { get; set; } = false;
    public override bool inUse { get; set; } = false;
    public override string? name { get; set; } = "Sir Robin";
    public override int health { get; set; } = 120;
    public override int maxAttack { get; set; } = 100;
    public override int minAttack { get; set; } = 100;
    public override int maxDefense { get; set; } = 100;
    public override int minDefense { get; set; } = 100;
    public override int price { get; set; } = 100;

    public override string ToString()
    {
        return name!;
    }
}
