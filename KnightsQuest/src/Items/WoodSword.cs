namespace KnightsQuest;

public class WoodSword : Item
{
    public override bool inUse { get; set; } = true;
    public override bool owned { get; set; } = true;
    public override ItemType type { get; set; } = ItemType.Weapon;
    public override string? name { get; set; } = "Wood Sword";
    public override float attackMultiplier { get; set; } = 1.1f;

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