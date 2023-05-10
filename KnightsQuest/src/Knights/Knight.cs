namespace KnightsQuest;

public class Knight
{
    public virtual bool owned { get; set; }
    public virtual bool inUse { get; set; }
    public virtual string? name { get; set; }
    public virtual int health { get; set; }
    public virtual int defaultHealth { get; set; }
    public virtual int maxAttack { get; set; }
    public virtual int minAttack { get; set; }
    public virtual int maxDefense { get; set; }
    public virtual int minDefense { get; set; }
    public virtual int price { get; set; }

    public override string ToString()
    {
        return $"{name} ({price} gold) (Health: {health}) (Attack: {minAttack}-{maxAttack}) (Defense: {minDefense}-{maxDefense})";
    }
}
