namespace Inventory;

enum BowTypes
{
    Longbow,
    Shortbow,
    Crossbow,
    CompositeBow,
    RecurveBow,
    CompoundBow,
    SelfBow,
    HorseBow,
    HandBow,
    WarBow
};

class Bow : Object
{
    Random random = new Random();
    BowTypes type;

    public Bow() : base(1, 4)
    {
        type = (BowTypes)random.Next(0, BowTypes.GetNames(typeof(BowTypes)).Length);
    }

    public override string ToString()
    {
        return $"Bow: {type}";
    }
}
