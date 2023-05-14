namespace KnightsQuest;

public class WoodSword : Item
{
    // Variables
    public override bool inUse { get; set; } = true;
    public override bool owned { get; set; } = true;
    public override ItemType type { get; set; } = ItemType.Weapon;
    public override string? name { get; set; } = "Wood Sword";
    public override float attackMultiplier { get; set; } = 1.1f;

    // Methods

    /// <summary>
    /// When used, the all other weapons are set to not in use and this weapon is set to in use.
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
    /// When bought, the player's gold is reduced by the price of the weapon.
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
