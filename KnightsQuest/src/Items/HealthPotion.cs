namespace KnightsQuest;

public class HealthPotion : Item
{
    public override bool owned { get; set; } = false;
    public override string? name { get; set; } = "Health Potion";
    public override int price { get; set; } = 10;

    /// <summary>
    /// When used, the player's health is set to the default health of the knight in use.
    /// </summary>
    public override void Use()
    {
        GameLoop.Instance.knights.Find(knight => knight.inUse)!.health = GameLoop.Instance.knights
            .Find(knight => knight.inUse)!
            .defaultHealth;
        Console.WriteLine("You used a health potion!");
        owned = false;
    }

    /// <summary>
    /// When bought, the player's gold is reduced by the price of the potion.
    /// </summary>
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
