namespace KnightsQuest;

public class FrenchTaunter : Monster
{
    public override string? name { get; set; } = "French Taunter";
    public override int health { get; set; } = 150;
    public override int defaultHealth { get; set; } = 150;
    public override int maxAttack { get; set; } = 25;
    public override int minAttack { get; set; } = 10;
    public override int minLevel { get; set; } = 10;
    public int mana { get; set; } = 100;

    /// <summary>
    /// Monster attacks knight.
    /// </summary>
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
                mana -= 10;
                damage -= defence;

                Console.WriteLine(
                    $"{name} broke through {knight.name}'s defence! {name} attacked {knight.name} for {damage} damage! {name} lost 10 mana and now has {mana} mana."
                );
                break;
            case 6:
                mana -= 10;
                damage = damage * 2;
                damage -= defence;

                Console.WriteLine(
                    $"{name} broke through {knight.name}'s defence! {name} lost 10 mana and made a crit for {damage} damage!"
                );
                break;
            default:
                damage -= defence;

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
