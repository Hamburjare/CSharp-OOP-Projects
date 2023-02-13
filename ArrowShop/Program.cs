namespace ArrowShop;

enum ArrowPointType
{
    Wood,
    Metal,
    Diamond
}

enum ArrowFetchType
{
    Leaf,
    ChickenFeather,
    EagleFeather
}

class Program
{
    static void Main(string[] args)
    {
        ArrowBuilder builder = new ArrowBuilder();
        Arrow arrow = new Arrow(
            builder.SelectPointType(),
            builder.SelectFetchType(),
            builder.GetShaftLength()
        );
        int price = arrow.GetPrice();
        Console.WriteLine($"Arrow's price will be: {price} golds");
    }
}

class ArrowBuilder
{
    int ReadNumber()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid input. Try again.");
        }
        return number;
    }

    public ArrowPointType SelectPointType()
    {
        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine("Select arrow point type:");
        Console.WriteLine("1. Wood");
        Console.WriteLine("2. Metal");
        Console.WriteLine("3. Diamond");
        int? pointType = ReadNumber();
        switch (pointType)
        {
            case 1:
                return ArrowPointType.Wood;
            case 2:
                return ArrowPointType.Metal;
            case 3:
                return ArrowPointType.Diamond;
            default:
                Console.WriteLine("Invalid input. Try again.");
                return SelectPointType();
        }
    }

    public ArrowFetchType SelectFetchType()
    {
        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine("Select arrow fetch type:");
        Console.WriteLine("1. Leaf");
        Console.WriteLine("2. Chicken feather");
        Console.WriteLine("3. Eagle feather");
        int? fetchType = ReadNumber();
        switch (fetchType)
        {
            case 1:
                return ArrowFetchType.Leaf;
            case 2:
                return ArrowFetchType.ChickenFeather;
            case 3:
                return ArrowFetchType.EagleFeather;
            default:
                Console.WriteLine("Invalid input. Try again.");
                return SelectFetchType();
        }
    }

    public int GetShaftLength()
    {
        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine("Enter shaft length in centimeters (60 - 100 cm):");
        int shaftLength = ReadNumber();
        if (shaftLength < 60 || shaftLength > 100)
        {
            Console.WriteLine("Invalid input. Try again.");
            return GetShaftLength();
        }
        return shaftLength;
    }
}

class ArrowPrices
{
    public static int WoodPointPrice = 3;
    public static int MetalPointPrice = 5;
    public static int DiamondPointPrice = 50;
    public static int LeafFetchPrice = 0;
    public static int ChickenFeatherFetchPrice = 1;
    public static int EagleFeatherFetchPrice = 5;
    public static float ShaftPricePerCentiMeter = 0.05f;
}

class Arrow
{
    public ArrowPointType pointType;
    public ArrowFetchType fetchType;
    public int shaftLength;

    public Arrow(ArrowPointType pointType, ArrowFetchType fetchType, int shaftLength)
    {
        this.pointType = pointType;
        this.fetchType = fetchType;
        this.shaftLength = shaftLength;
    }

    public int GetPrice()
    {
        int price = 0;
        switch (pointType)
        {
            case ArrowPointType.Wood:
                price += ArrowPrices.WoodPointPrice;
                break;
            case ArrowPointType.Metal:
                price += ArrowPrices.MetalPointPrice;
                break;
            case ArrowPointType.Diamond:
                price += ArrowPrices.DiamondPointPrice;
                break;
        }
        switch (fetchType)
        {
            case ArrowFetchType.Leaf:
                price += ArrowPrices.LeafFetchPrice;
                break;
            case ArrowFetchType.ChickenFeather:
                price += ArrowPrices.ChickenFeatherFetchPrice;
                break;
            case ArrowFetchType.EagleFeather:
                price += ArrowPrices.EagleFeatherFetchPrice;
                break;
        }
        price += (int)(ArrowPrices.ShaftPricePerCentiMeter * shaftLength);
        return price;
    }
}
