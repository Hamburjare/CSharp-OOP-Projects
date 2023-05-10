namespace KnightsQuest;

public class WoodShield : Item
{
    public override bool inUse { get; set; } = true;
    public override bool owned { get; set; } = true;
    public override ItemType type { get; set; } = ItemType.Shield;
    public override string? name { get; set; } = "Wood Shield";
    public override float defenseMultiplier { get; set; } = 1.1f;

}
