namespace KnightsQuest;

public class Rabbit : Monster
{
    public override string? name { get; set; } = "Rabbit";
    public override int health { get; set; } = 100;
    public override int defaultHealth { get; set; } = 100;
    public override int maxAttack { get; set; } = 15;
    public override int minAttack { get; set; } = 3;
    public override int minLevel { get; set; } = 0;
}
