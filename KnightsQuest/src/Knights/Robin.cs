namespace KnightsQuest;

public class Robin : Knight
{
    // Variables
    public override bool owned { get; set; } = false;
    public override bool inUse { get; set; } = false;
    public override string? name { get; set; } = "Sir Robin";
    public override int health { get; set; } = 120;
    public override int defaultHealth { get; set; } = 120;
    public override int maxAttack { get; set; } = 13;
    public override int minAttack { get; set; } = 2;
    public override int maxDefense { get; set; } = 13;
    public override int minDefense { get; set; } = 2;
    public override int price { get; set; } = 100;

    // Methods

    public override void Attack(Monster monster)
    {
        Random random = new Random();
        int damage = random.Next(minAttack, maxAttack);

        // Robin has a 50% chance to deal double damage
        if (random.Next(0, 2) == 0)
        {
            damage *= 2;
            Console.WriteLine($"{name} attacked {monster.name} for {damage} damage! Critical hit!");
        }
        else
        {
            Console.WriteLine($"{name} attacked {monster.name} for {damage} damage!");
        }

        monster.health -= damage;
        if (monster.health < 0)
        {
            monster.health = 0;
        }
    }
}
