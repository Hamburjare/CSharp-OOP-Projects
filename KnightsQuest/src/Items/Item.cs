namespace KnightsQuest;

public enum ItemType
{
    Weapon,
    Shield
}


public class Item {
    public virtual bool inUse { get; set; } = false;
    public virtual bool owned { get; set; } = false;
    public virtual ItemType type { get; set; }
    public virtual string? name { get; set; }
    public virtual int price { get; set; }
    public virtual float attackMultiplier { get; set; } = 1.0f; 
    public virtual float defenseMultiplier { get; set; } = 1.0f;

    public override string ToString()
    {
        return $"{name} ({price} gold) (Attack: {attackMultiplier}) (Defense: {defenseMultiplier})";
    }
}