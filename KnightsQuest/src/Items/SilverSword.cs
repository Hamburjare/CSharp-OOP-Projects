namespace KnightsQuest;

public class SilverSword : Item
{
    public override bool inUse { get; set; } = false;
    public override bool owned { get; set; } = false;
    public override ItemType type { get; set; } = ItemType.Weapon;
    public override string? name { get; set; } = "Silver Sword";
    public override int price { get; set; } = 100;
    public override float attackMultiplier { get; set; } = 1.5f;

}