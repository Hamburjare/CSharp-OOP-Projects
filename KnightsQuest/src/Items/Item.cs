namespace KnightsQuest;

public enum ItemType
{
    Weapon,
    Shield
}


public abstract class Item {
    
    // Variables
    public virtual bool inUse { get; set; } = false;
    public virtual bool owned { get; set; } = false;
    public virtual ItemType type { get; set; }
    public virtual string? name { get; set; }
    public virtual int price { get; set; }
    public virtual float attackMultiplier { get; set; } = 1.0f; 
    public virtual float defenseMultiplier { get; set; } = 1.0f;
    
    // Methods
    
    public override string ToString()
    {
        return $"{name} ({price} gold) (Attack: {attackMultiplier}) (Defense: {defenseMultiplier})";
    }

    /// <summary>
    /// This is an abstract method named "Use" that has no implementation and must be defined in any
    /// class that inherits from the abstract class containing it.
    /// </summary>
    public abstract void Use();

    /// <summary>
    /// This is an abstract function named "Buy" that has no implementation and must be defined in a
    /// derived class.
    /// </summary>
    public abstract void Buy();

}