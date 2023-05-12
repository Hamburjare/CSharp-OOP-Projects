namespace KnightsQuest;

public class Lancelot : Knight
{
    public override bool owned { get; set; } = true;
    public override bool inUse { get; set; } = true;
    public override string? name { get; set; } = "Sir Lancelot";
    public override int health { get; set; } = 10;
    public override int defaultHealth { get; set; } = 100;
    public override int maxAttack { get; set; } = 10;
    public override int minAttack { get; set; } = 2;
    public override int maxDefense { get; set; } = 10;
    public override int minDefense { get; set; } = 2;

    public override void Use()
    {
        foreach (var knight in GameLoop.Instance.knights)
        {
            knight.inUse = false;
        }
        inUse = true;

        Console.WriteLine($"You are now using {name}.");
    }

    public override void Buy()
    {
        GameLoop.Instance.player.gold -= price;
        owned = true;
        Console.WriteLine(
            $"You bought {name} for {price} gold. You can equip it in the inventory."
        );
    }
}
