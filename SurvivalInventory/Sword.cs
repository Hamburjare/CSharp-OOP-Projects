namespace Inventory;

enum SwordTypes
{
    Katana,
    Longsword,
    Broadsword,
    Claymore,
    BastardSword,
    Scimitar,
    Falchion,
    Cutlass,
    Sabre,
    Rondel
};

class Sword : Object
{
    Random random = new Random();
    SwordTypes type;

    public Sword() : base(5, 3)
    {
        type = (SwordTypes)random.Next(0, SwordTypes.GetNames(typeof(SwordTypes)).Length);
    }

    public override string ToString()
    {
        return $"Sword: {type}";
    }
}
