namespace KnightsQuest;

public class BlackKnight : Monster
{
    public override string? name { get; set; } = "Black Knight";
    public override int health { get; set; } = 120;
    public override int defaultHealth { get; set; } = 120;
    public override int maxAttack { get; set; } = 20;
    public override int minAttack { get; set; } = 5;
    public override int minLevel { get; set; } = 5;

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
                damage -= defence;

                Console.WriteLine($"{name} missed!");
                break;
            case 2:
                damage = damage * 2;
                damage -= defence;

                Console.WriteLine($"{name} crit for {damage} damage!");
                break;
            case 3:
                defence = defence * 2;
                damage -= defence;

                Console.WriteLine($"{name} blocked for {defence} damage!");
                break;
            case 4:
                damage = damage * 2;
                defence = defence * 2;
                damage -= defence;

                Console.WriteLine($"{name} crit and blocked for {damage} damage!");
                break;
            case 5:
                defence = 0;
                damage -= defence;

                Console.WriteLine($"{name} broke through {knight.name}'s defence! {name} attacked {knight.name} for {damage} damage!");
                break;
            default:
                damage -= defence;

                Console.WriteLine($"{name} attacked {knight.name} for {damage} damage!");
                break;
        }

        damage -= defence;

        knight.health -= damage;

        if (knight.health < 0)
        {
            knight.health = 0;
        }
    }
}
