namespace Blacksmith;

enum SwordPointType
{
    Pronze,
    Metal,
    Mithril
}

enum SwordHandleType
{
    Wood,
    MetalwithLeather,
    DragonBone
}

enum GemStone
{
    WaterStone,
    FireStone,
    EarthStone,
    WindStone
}

class Program
{
    static void Main(string[] args)
    {
        SwordBuilder builder = new SwordBuilder();
        Sword sword = new Sword(
            builder.SelectSwordPointType(),
            builder.SelectSwordHandleType(),
            builder.SelectGemStone()
        );
        int price = sword.GetPrice();
        Console.WriteLine($"Sword's price will be: {price} golds");
    }
}

class SwordPrices
{
    // Sword Point
    public static int PronzeSwordPrice = 5;
    public static int MetalSwordPrice = 10;
    public static int MithrilSwordPrice = 50;
    public static int WoodSwordPrice = 5;

    // Sword Handle
    public static int MetalwithLeatherSwordPrice = 8;
    public static int DragonBoneSwordPrice = 30;

    // GemStone
    public static int WaterStoneSwordPrice = 15;
    public static int FireStoneSwordPrice = 20;
    public static int EarthStoneSwordPrice = 13;
    public static int WindStoneSwordPrice = 18;
}

class SwordBuilder
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

    public SwordPointType SelectSwordPointType()
    {
        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine("Select sword point type:");
        Console.WriteLine("1. Pronze");
        Console.WriteLine("2. Metal");
        Console.WriteLine("3. Mithril");
        int? pointType = ReadNumber();
        switch (pointType)
        {
            case 1:
                return SwordPointType.Pronze;
            case 2:
                return SwordPointType.Metal;
            case 3:
                return SwordPointType.Mithril;
            default:
                Console.WriteLine("Invalid input. Try again.");
                return SelectSwordPointType();
        }
    }

    public SwordHandleType SelectSwordHandleType()
    {
        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine("Select sword handle type:");
        Console.WriteLine("1. Wood");
        Console.WriteLine("2. Metal with Leather");
        Console.WriteLine("3. Dragon Bone");
        int? handleType = ReadNumber();
        switch (handleType)
        {
            case 1:
                return SwordHandleType.Wood;
            case 2:
                return SwordHandleType.MetalwithLeather;
            case 3:
                return SwordHandleType.DragonBone;
            default:
                Console.WriteLine("Invalid input. Try again.");
                return SelectSwordHandleType();
        }
    }

    public GemStone SelectGemStone()
    {
        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine("Select gemstone type:");
        Console.WriteLine("1. Water Stone");
        Console.WriteLine("2. Fire Stone");
        Console.WriteLine("3. Earth Stone");
        Console.WriteLine("4. Wind Stone");
        int? gemStone = ReadNumber();
        switch (gemStone)
        {
            case 1:
                return GemStone.WaterStone;
            case 2:
                return GemStone.FireStone;
            case 3:
                return GemStone.EarthStone;
            case 4:
                return GemStone.WindStone;
            default:
                Console.WriteLine("Invalid input. Try again.");
                return SelectGemStone();
        }
    }
}

class Sword
{
    public SwordPointType SwordPointType { get; set; }
    public SwordHandleType SwordHandleType { get; set; }
    public GemStone GemStone { get; set; }

    public Sword(SwordPointType swordPointType, SwordHandleType swordHandleType, GemStone gemStone)
    {
        SwordPointType = swordPointType;
        SwordHandleType = swordHandleType;
        GemStone = gemStone;
    }

    public int GetPrice()
    {
        int price = 0;
        switch (SwordPointType)
        {
            case SwordPointType.Pronze:
                price += SwordPrices.PronzeSwordPrice;
                break;
            case SwordPointType.Metal:
                price += SwordPrices.MetalSwordPrice;
                break;
            case SwordPointType.Mithril:
                price += SwordPrices.MithrilSwordPrice;
                break;
        }

        switch (SwordHandleType)
        {
            case SwordHandleType.Wood:
                price += SwordPrices.WoodSwordPrice;
                break;
            case SwordHandleType.MetalwithLeather:
                price += SwordPrices.MetalwithLeatherSwordPrice;
                break;
            case SwordHandleType.DragonBone:
                price += SwordPrices.DragonBoneSwordPrice;
                break;
        }

        switch (GemStone)
        {
            case GemStone.WaterStone:
                price += SwordPrices.WaterStoneSwordPrice;
                break;
            case GemStone.FireStone:
                price += SwordPrices.FireStoneSwordPrice;
                break;
            case GemStone.EarthStone:
                price += SwordPrices.EarthStoneSwordPrice;
                break;
            case GemStone.WindStone:
                price += SwordPrices.WindStoneSwordPrice;
                break;
        }

        return price;
    }
}
