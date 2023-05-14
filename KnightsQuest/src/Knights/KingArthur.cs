namespace KnightsQuest;

public class KingArthur : Knight
{
    public override string? name { get; set; } = "King Arthur";
    public override int health { get; set; } = 200;
    public override int defaultHealth { get; set; } = 200;
    public override int maxAttack { get; set; } = 30;
    public override int minAttack { get; set; } = 10;
    public override int maxDefense { get; set; } = 20;
    public override int minDefense { get; set; } = 5;
    public override int price { get; set; } = 300;

    /// <summary>
    /// When attacking, the knight deals a random amount of damage between its min and max attack.
    /// </summary>

    public override void Attack(Monster monster)
    {
        Random random = new Random();
        int damage = random.Next(minAttack, maxAttack);
        int chance = random.Next(1, 10);

        switch (chance)
        {
            case 1:
                damage = damage * 2;
                Console.WriteLine($"{name} crit for {damage} damage!");
                break;
            case 2:
                damage *= 3;
                Console.WriteLine($"{name} hit super hard for {damage} damage!");
                break;
            default:
                Console.WriteLine($"{name} attacked {monster.name} for {damage} damage!");
                break;
        }

        monster.health -= damage;
        if (monster.health < 0)
        {
            monster.health = 0;
        }
    }
}
