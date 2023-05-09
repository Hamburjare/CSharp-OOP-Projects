namespace KnightsQuest;


public class Item {
    public virtual string? name { get; set; }
    public virtual int price { get; set; }
    public virtual float attackMultiplier { get; set; } = 1.0f; 
    public virtual float defenseMultiplier { get; set; } = 1.0f;
}