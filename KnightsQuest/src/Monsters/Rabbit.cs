namespace KnightsQuest;

public class Rabbit : Monster
{
    public override string? Name { get; set; } = "Rabbit";
    public override int Health { get; set; } = 100;
    public override int MaxAttack { get; set; } = 7;
    public override int MinAttack { get; set; } = 2;
    public override int MaxDefense { get; set; } = 10;
    public override int MinDefense { get; set; } = 10;
    public override int MinLevel { get; set; } = 0;
}
