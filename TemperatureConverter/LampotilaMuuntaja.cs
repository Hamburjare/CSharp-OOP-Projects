namespace TemperatureConverter;

public static class LampotilaMuuntaja
{
    public static double CelsiusFahrenheitiksi(double celsius)
    {
        double fahrenheit = (celsius * 9 / 5) + 32;

        return fahrenheit;
    }

    public static double FahrenheitCelsiukseksi(double fahrenheit)
    {
        double celsius = (fahrenheit - 32) * 5 / 9;

        return celsius;
    }
}