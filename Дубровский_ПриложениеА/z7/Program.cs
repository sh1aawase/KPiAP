using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите m: ");
        double m = double.Parse(Console.ReadLine());

        double numerator = Math.Sqrt(Math.Pow(3 * m + 2, 2) - 24 * m);
        double denominator = 3 * Math.Sqrt(m) - (2 / Math.Sqrt(m));
        double z1 = numerator / denominator;

        double z2 = -Math.Sqrt(m);

        Console.WriteLine("z1 = " + z1);
        Console.WriteLine("z2 = " + z2);

        Console.ReadKey();
    }
}