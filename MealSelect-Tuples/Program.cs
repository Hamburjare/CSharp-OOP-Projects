namespace MealSelect_Tuples;

enum MainDish
{
    nautaa,
    kanaa,
    kalkkunaa,
    kinkkua,
    kasviksia
}

enum SideDish
{
    perunaa,
    riisiä,
    salaattia,
    pastaa
}

enum Sauce
{
    curry,
    hapanimelä,
    pippuri,
    chili
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the meal selection program!");

        MealSelect();

        int ReadNumber()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Virheellinen syöte. Yritä uudelleen.");
            }
            return number;
        }

        void MealSelect()
        {
            Console.Write("How many meals would you like to order? (1-3) ");
            int? mealAmount = ReadNumber();
            switch (mealAmount)
            {
                case 1:
                    Console.WriteLine("You have selected one meal.");
                    (MainDish mainDish, SideDish sideDish, Sauce sauce) meal = (
                        MainDishSelect(),
                        SideDishSelect(),
                        SauceSelect()
                    );

                    Console.WriteLine("You have selected:");

                    Console.WriteLine(
                        $"{meal.mainDish} ja {meal.sideDish} {meal.sauce}-kastikkeella."
                    );

                    break;
                case 2:
                    Console.WriteLine("You have selected two meals.");

                    (MainDish mainDish, SideDish sideDish, Sauce sauce) meal1 = (
                        MainDishSelect(),
                        SideDishSelect(),
                        SauceSelect()
                    );

                    (MainDish mainDish, SideDish sideDish, Sauce sauce) meal2 = (
                        MainDishSelect(),
                        SideDishSelect(),
                        SauceSelect()
                    );

                    Console.WriteLine("You have selected:");

                    Console.WriteLine(
                        $"{meal1.mainDish} ja {meal1.sideDish} {meal1.sauce}-kastikkeella."
                    );

                    Console.WriteLine(
                        $"{meal2.mainDish} ja {meal2.sideDish} {meal2.sauce}-kastikkeella."
                    );

                    break;
                case 3:
                    Console.WriteLine("You have selected three meals.");

                    (MainDish mainDish, SideDish sideDish, Sauce sauce) meal3 = (
                        MainDishSelect(),
                        SideDishSelect(),
                        SauceSelect()
                    );

                    (MainDish mainDish, SideDish sideDish, Sauce sauce) meal5 = (
                        MainDishSelect(),
                        SideDishSelect(),
                        SauceSelect()
                    );

                    (MainDish mainDish, SideDish sideDish, Sauce sauce) meal4 = (
                        MainDishSelect(),
                        SideDishSelect(),
                        SauceSelect()
                    );

                    Console.WriteLine("You have selected:");

                    Console.WriteLine(
                        $"{meal3.mainDish} ja {meal3.sideDish} {meal3.sauce}-kastikkeella."
                    );

                    Console.WriteLine(
                        $"{meal4.mainDish} ja {meal4.sideDish} {meal4.sauce}-kastikkeella."
                    );

                    Console.WriteLine(
                        $"{meal5.mainDish} ja {meal5.sideDish} {meal5.sauce}-kastikkeella."
                    );

                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        MainDish MainDishSelect()
        {
            MainDish selected;
            while (true)
            {
                Console.WriteLine("Please select a main dish: ");
                foreach (string main in Enum.GetNames(typeof(MainDish)))
                {
                    Console.WriteLine(main);
                }
                Console.Write("Enter your choice: ");
                string? mainChoice = Console.ReadLine();
                if (Enum.TryParse(mainChoice, out MainDish mainType))
                {
                    selected = mainType;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");

                    continue;
                }

                break;
            }
            Console.WriteLine(new string('-', Console.WindowWidth));

            return selected;
        }

        SideDish SideDishSelect()
        {
            SideDish selected;
            while (true)
            {
                Console.WriteLine("Please select a side dish: ");
                foreach (string side in Enum.GetNames(typeof(SideDish)))
                {
                    Console.WriteLine(side);
                }
                Console.Write("Enter your choice: ");
                string? sideChoice = Console.ReadLine();
                if (Enum.TryParse(sideChoice, out SideDish sideType))
                {
                    selected = sideType;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");

                    continue;
                }
                break;
            }

            Console.WriteLine(new string('-', Console.WindowWidth));

            return selected;
        }

        Sauce SauceSelect()
        {
            Sauce selected;
            while (true)
            {
                Console.WriteLine("Please select a sauce: ");
                foreach (string sauce in Enum.GetNames(typeof(Sauce)))
                {
                    Console.WriteLine(sauce);
                }
                Console.Write("Enter your choice: ");
                string? sauceChoice = Console.ReadLine();
                if (Enum.TryParse(sauceChoice, out Sauce sauceType))
                {
                    selected = sauceType;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");

                    continue;
                }
                break;
            }

            Console.WriteLine(new string('-', Console.WindowWidth));

            return selected;
        }
    }
}
