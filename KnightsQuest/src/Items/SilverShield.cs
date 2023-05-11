namespace KnightsQuest;

public class SilverShield : Item
{
    public override bool inUse { get; set; } = false;
    public override bool owned { get; set; } = false;
    public override ItemType type { get; set; } = ItemType.Shield;
    public override string? name { get; set; } = "Silver Shield";
    public override int price { get; set; } = 100;
    public override float defenseMultiplier { get; set; } = 1.5f;

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

}