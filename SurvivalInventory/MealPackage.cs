namespace Inventory;

class MealPackage : Object
{
    string type = "Meal Package";
    public MealPackage() : base(1, 0.5f) {
        
    }

    public override string ToString()
    {
        return $"MealPackage: {type}";
    }
}