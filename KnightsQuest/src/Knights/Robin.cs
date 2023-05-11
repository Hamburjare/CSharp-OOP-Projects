namespace KnightsQuest;

public class Robin : Knight
{
    public override bool owned { get; set; } = false;
    public override bool inUse { get; set; } = false;
    public override string? name { get; set; } = "Sir Robin";
    public override int health { get; set; } = 120;
    public override int defaultHealth { get; set; } = 120;
    public override int maxAttack { get; set; } = 13;
    public override int minAttack { get; set; } = 2;
    public override int maxDefense { get; set; } = 13;
    public override int minDefense { get; set; } = 2;
    public override int price { get; set; } = 100;

    public override void Use()
    {
        foreach (var knight in GameLoop.Instance.knights)
        {
            knight.inUse = false;
        }
        inUse = true;

        Console.WriteLine($"You are now using {name}.");
    }
}
