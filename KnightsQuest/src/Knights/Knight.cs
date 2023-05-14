namespace KnightsQuest;

public abstract class Knight
{
    // Variables
    public virtual bool owned { get; set; }
    public virtual bool inUse { get; set; }
    public virtual string? name { get; set; }
    public virtual int health { get; set; }
    public virtual int defaultHealth { get; set; }
    public virtual int maxAttack { get; set; }
    public virtual int minAttack { get; set; }
    public virtual int maxDefense { get; set; }
    public virtual int minDefense { get; set; }
    public virtual int price { get; set; }

    // Methods

    public override string ToString()
    {
        return $"{name} ({price} gold) (Health: {health}) (Attack: {minAttack}-{maxAttack}) (Defense: {minDefense}-{maxDefense})";
    }

    /// <summary>
    /// When used, all other knights are set to not in use and this knight is set to in use.
    /// </summary>
    public virtual void Use()
    {
        foreach (var knight in GameLoop.Instance.knights)
        {
            knight.inUse = false;
        }
        inUse = true;

        Console.WriteLine($"You are now using {name}.");
    }

    /// <summary>
    /// When bought, the player's gold is reduced by the price of the knight.
    /// </summary>
    public virtual void Buy()
    {
        GameLoop.Instance.player.gold -= price;
        owned = true;
        Console.WriteLine(
            $"You bought {name} for {price} gold. You can equip it in the inventory."
        );
    }

    /// <summary>
    /// When attacking, the knight deals a random amount of damage between its min and max attack.
    /// </summary>

    /// <summary>
    /// This is an abstract function named "Attack" that has no implementation and must be defined in a
    /// derived class.
    /// </summary>
    public abstract void Attack(Monster monster);
}
