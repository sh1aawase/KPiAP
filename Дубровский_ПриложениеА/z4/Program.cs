using System;

class Program
{
    static void Main()
    {
        double x = 2.7;

        double term1 = 3 * Math.Pow(x, 2);
        double term2 = Math.Exp(Math.Sqrt(x)) / (2 * Math.PI);
        double term3 = Math.Log(Math.Sqrt(Math.Abs(3 - Math.Pow(Math.Sin(x), 2))));

        double y = term1 + term2 - term3;

        Console.WriteLine("При x = " + x);
        Console.WriteLine("Результат y = " + y);

        Console.ReadKey();
    }
}