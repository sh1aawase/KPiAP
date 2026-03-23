using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите трехзначное число: ");
        int n = int.Parse(Console.ReadLine());

        int d1 = n / 100;
        int d2 = (n / 10) % 10;
        int d3 = n % 10;

        int result = d1 * 100 + d3 * 10 + d2;

        Console.WriteLine("Результат: " + result);
        Console.ReadKey();
    }
}