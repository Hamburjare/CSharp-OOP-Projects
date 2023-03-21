namespace Inventory;

class Arrow : Object
{
    string type = "Arrow";

    public Arrow() : base(0.1f, 0.05f) {
        
    }

    public override string ToString()
    {
        return $"Arrow: {type}";
    }
}