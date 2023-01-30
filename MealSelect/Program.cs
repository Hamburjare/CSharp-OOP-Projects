enum MeatType
{
    Beef,
    Chicken,
    Pork,
    Fish,
    Tofu
}

enum SideDishType
{
    Rice,
    Noodles,
    Potatoes,
    Salad,
    Vegetables
}

enum SauceType
{
    Curry,
    Teriyaki,
    Pepper,
    Chili,
    Creamy
}

class Meal
{
    public MeatType Meat { get; set; }
    public SideDishType SideDish { get; set; }
    public SauceType Sauce { get; set; }
}

class MealSelect
{
    static void Main(string[] args)
    {
        Meal meal = new Meal();

        Console.WriteLine("Welcome to the meal select program!");

        while (true)
        {
            Console.WriteLine("Please select a meat type: ");
            foreach (string meat in Enum.GetNames(typeof(MeatType)))
            {
                Console.WriteLine(meat);
            }
            Console.Write("Enter your choice: ");
            string? meatChoice = Console.ReadLine();
            if (Enum.TryParse(meatChoice, out MeatType meatType))
            {
                meal.Meat = meatType;
            }
            else
            {
                Console.WriteLine("Invalid choice.");

                continue;
            }
            break;
        }

        Console.WriteLine(new string('-', Console.WindowWidth));

        while (true)
        {
            Console.WriteLine("Please select a side dish type: ");

            foreach (string sideDish in Enum.GetNames(typeof(SideDishType)))
            {
                Console.WriteLine(sideDish);
            }
            Console.Write("Enter your choice: ");
            string? sideDishChoice = Console.ReadLine();
            if (Enum.TryParse(sideDishChoice, out SideDishType sideDishType))
            {
                meal.SideDish = sideDishType;
            }
            else
            {
                Console.WriteLine("Invalid choice.");

                continue;
            }
            break;
        }

        Console.WriteLine(new string('-', Console.WindowWidth));

        while(true)
        {
            Console.WriteLine("Please select a sauce type: ");
            foreach (string sauce in Enum.GetNames(typeof(SauceType)))
            {
                Console.WriteLine(sauce);
            }
            Console.Write("Enter your choice: ");
            string? sauceChoice = Console.ReadLine();
            if (Enum.TryParse(sauceChoice, out SauceType sauceType))
            {
                meal.Sauce = sauceType;
            }
            else
            {
                Console.WriteLine("Invalid choice.");

                continue;
            }
            break;
        }


        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine(
            "You choose a {0} with {1} and {2} Sauce.",
            meal.Meat,
            meal.SideDish,
            meal.Sauce
        );

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
