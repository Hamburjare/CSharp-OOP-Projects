namespace Inventory;

enum PotionTypes
{
    Health,
    Mana,
    Stamina,
    Strength,
    Dexterity,
    Intelligence,
    Wisdom,
    Charisma,
    Constitution,
    Luck
};

class MagicPotion : Object
{
    Random random = new Random();
    PotionTypes type;

    public MagicPotion() : base(2, 3)
    {
        type = (PotionTypes)random.Next(0, PotionTypes.GetNames(typeof(PotionTypes)).Length);
    }

    public override string ToString()
    {
        return $"{type} Potion";
    }
}
