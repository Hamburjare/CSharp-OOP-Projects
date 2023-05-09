namespace KnightsQuest;

public class Monster {
    public virtual string? Name { get; set; }
    public virtual int Health { get; set; }
    public virtual int MaxAttack { get; set; }
    public virtual int MinAttack { get; set; }
    public virtual int MaxDefense { get; set; }
    public virtual int MinDefense { get; set; }
    public virtual int MinLevel { get; set; }
 }
