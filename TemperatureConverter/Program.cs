namespace TemperatureConverter;
public class LampotilaTesti
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Mitä haluat muuntaa?");
        Console.WriteLine("1. Celsius-asteita fahrenheit-asteiksi.");
        Console.WriteLine("2. Fahrenheit-asteita celsius-asteiksi.");

        string selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                Console.Write("Anna celsius-asteet: ");
                double fahrenheit = LampotilaMuuntaja.CelsiusFahrenheitiksi(Double.Parse(Console.ReadLine()));
                Console.WriteLine("Lämpötila fahrenheit-asteina: {0:F2}", fahrenheit);
                break;

            case "2":
                Console.Write("Anna fahrenheit-asteet: ");
                double celsius = LampotilaMuuntaja.FahrenheitCelsiukseksi(Double.Parse(Console.ReadLine()));
                Console.WriteLine("Lämpötila celsius-asteina: {0:F2}", celsius);
                break;

            default:
                Console.WriteLine("Valitse 1 tai 2.");
                break;
        }
    }
}
