namespace KnightsQuest;

public class SilverShield : Item
{
    // Variables
    public override bool inUse { get; set; } = false;
    public override bool owned { get; set; } = false;
    public override ItemType type { get; set; } = ItemType.Shield;
    public override string? name { get; set; } = "Silver Shield";
    public override int price { get; set; } = 100;
    public override float defenseMultiplier { get; set; } = 1.5f;

    // Methods

    /// <summary>
    /// When used, the all other shields are set to not in use and this shield is set to in use.
    /// </summary>
    public override void Use()
    {
        foreach (var item in GameLoop.Instance.items)
        {
            if (item.type == type)
            {
                item.inUse = false;
            }
        }

        inUse = true;
    }

    /// <summary>
    /// When bought, the player's gold is reduced by the price of the shield.
    /// </summary>
    public override void Buy()
    {
        GameLoop.Instance.player.gold -= price;
        owned = true;
        Console.WriteLine(
            $"You bought a {name} for {price} gold. You can equip it in the inventory."
        );
    }
}
