namespace KnightsQuest;

public class Lancelot : Knight
{
    // Variables
    public override bool owned { get; set; } = true;
    public override bool inUse { get; set; } = true;
    public override string? name { get; set; } = "Sir Lancelot";
    public override int health { get; set; } = 100;
    public override int defaultHealth { get; set; } = 100;
    public override int maxAttack { get; set; } = 10;
    public override int minAttack { get; set; } = 2;
    public override int maxDefense { get; set; } = 10;
    public override int minDefense { get; set; } = 2;

    // Methods


    /// <summary>
    /// When attacking, the knight deals a random amount of damage between its min and max attack.
    /// </summary>
    public override void Attack(Monster monster)
    { 
        Random random = new Random();
        int damage = random.Next(minAttack, maxAttack);
        monster.health -= damage;
        if (monster.health < 0)
        {
            monster.health = 0;
        }
        Console.WriteLine($"{name} attacked {monster.name} for {damage} damage!");
    }
}
