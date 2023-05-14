namespace KnightsQuest;

public class WoodShield : Item
{
    // Variables
    public override bool inUse { get; set; } = true;
    public override bool owned { get; set; } = true;
    public override ItemType type { get; set; } = ItemType.Shield;
    public override string? name { get; set; } = "Wood Shield";
    public override float defenseMultiplier { get; set; } = 1.1f;

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
