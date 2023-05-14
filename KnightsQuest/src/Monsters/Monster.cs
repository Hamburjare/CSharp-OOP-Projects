namespace KnightsQuest;

public abstract class Monster
{
    public virtual string? name { get; set; }
    public virtual int health { get; set; }
    public virtual int defaultHealth { get; set; }
    public virtual int maxAttack { get; set; }
    public virtual int minAttack { get; set; }
    public virtual int minLevel { get; set; }

    public override string ToString()
    {
        return $"{name} (Health: {health}) (Attack: {minAttack}-{maxAttack}) (You need to be: {minLevel} level to fight this monster)";
    }

    public abstract void Attack(Knight knight);
}
