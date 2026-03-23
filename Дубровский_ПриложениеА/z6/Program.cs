using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите трехзначное число: ");
        int n = int.Parse(Console.ReadLine());

        int first = n / 100;
        int last = n % 10;

        Console.WriteLine("Первая цифра: " + first);
        Console.WriteLine("Последняя цифра: " + last);

        Console.ReadKey();
    }
}