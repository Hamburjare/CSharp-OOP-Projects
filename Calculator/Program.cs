namespace Calculator;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Calculator.Add(1, 2));
        Console.WriteLine(Calculator.Subtract(1, 2));
        Console.WriteLine(Calculator.Multiply(1, 2));
        Console.WriteLine(Calculator.Divide(8, 9));
    }
}

class Calculator
{
    public static double Add(double a, double b)
    {
        return (double)a + b;
    }

    public static double Subtract(double a, double b)
    {
        return (double)a - b;
    }

    public static double Multiply(double a, double b)
    {
        return (double)a * b;
    }

    public static double Divide(double a, double b)
    {
        return (double)a / b;
    }


}
