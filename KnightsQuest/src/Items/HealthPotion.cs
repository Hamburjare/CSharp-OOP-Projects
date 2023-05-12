namespace KnightsQuest;

public class HealthPotion : Item
{
    public override bool owned { get; set; } = false;
    public override string name { get; set; } = "Health Potion";
    public override int price { get; set; } = 10;

    public override void Use()
    {
        GameLoop.Instance.knights.Find(knight => knight.inUse).health = GameLoop.Instance.knights
            .Find(knight => knight.inUse)
            .defaultHealth;
        Console.WriteLine("You used a health potion!");
        owned = false;
    }

    public override void Buy()
    {
        GameLoop.Instance.player.gold -= price;
        owned = true;
        Console.WriteLine($"You bought a health potion for {price} gold.");
    }

    public override string ToString()
    {
        return $"{name} ({price} gold) gives you a full heal when used.";
    }
}
