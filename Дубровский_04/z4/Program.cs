using System;

static class DoubleExtensions
{
    public static double Round(this double value, int digits)
    {
        return Math.Round(value, digits);
    }
}

class Program
{
    static void Main()
    {
        double number = 3.1415926535;
        int precision = 2;

        double result = number.Round(precision);

        Console.WriteLine(result);
    }
}