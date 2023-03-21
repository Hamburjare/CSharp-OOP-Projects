namespace Inventory;
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int maxWeight = random.Next(10, 50);
        int maxVolume = random.Next(10, 50);
        int maxItems = random.Next(10, 50);

        bool success;


        Bag bag = new Bag(maxWeight, maxVolume, maxItems);
        while (true) {
            Console.Clear();
            Console.WriteLine(bag.ToString());
            Console.WriteLine("What item would you like to add?");
            Console.WriteLine("1. Arrow");
            Console.WriteLine("2. Bow");
            Console.WriteLine("3. Sword");
            Console.WriteLine("4. Magic Potion");
            Console.WriteLine("5. Meal Package");
            Console.WriteLine("5. Exit");
            Console.Write("Enter a number: ");
            while (true) {
                if (int.TryParse(Console.ReadLine(), out int choice)) {
                    switch (choice) {
                        case 1:
                            success = bag.AddObject((Object)new Arrow());
                            if (!success) {
                                Console.WriteLine("Item doesnt fit. Press any key to continue.");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            success = bag.AddObject((Object)new Bow());
                            if (!success) {
                                Console.WriteLine("Item doesnt fit. Press any key to continue.");
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            success = bag.AddObject((Object)new Sword());
                            if (!success) {
                                Console.WriteLine("Item doesnt fit. Press any key to continue.");
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            success = bag.AddObject((Object)new MagicPotion());
                            if (!success) {
                                Console.WriteLine("Item doesnt fit. Press any key to continue.");
                                Console.ReadKey();
                            }
                            break;
                        case 5:
                            success = bag.AddObject((Object)new MealPackage());
                            if (!success) {
                                Console.WriteLine("Item doesnt fit. Press any key to continue.");
                                Console.ReadKey();
                            }
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                    break;
                }
                else {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }
}
