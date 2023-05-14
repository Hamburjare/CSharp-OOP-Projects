namespace KnightsQuest;

public class Rabbit : Monster
{
    public override string? name { get; set; } = "Rabbit";
    public override int health { get; set; } = 100;
    public override int defaultHealth { get; set; } = 100;
    public override int maxAttack { get; set; } = 15;
    public override int minAttack { get; set; } = 3;
    public override int minLevel { get; set; } = 0;

    public override void Attack(Knight knight)
    {
        Random random = new Random();
        int damage = random.Next(minAttack, maxAttack);
        int defence = random.Next(knight.minDefense, knight.maxDefense);
        int chance = random.Next(1, 10);

        switch (chance)
        {
            case 1:
                damage = 0;
                Console.WriteLine($"{name} missed!");
                break;
            case 2:
                damage = damage * 2;
                damage -= defence;

                Console.WriteLine($"{name} crit for {damage} damage!");
                break;
            default:
                Console.WriteLine($"{name} attacked {knight.name} for {damage} damage!");

                break;
        }

        knight.health -= damage;
        if (knight.health < 0)
        {
            knight.health = 0;
        }
    }
}
