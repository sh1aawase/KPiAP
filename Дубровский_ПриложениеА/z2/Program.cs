using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите двузначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int firstDigit = number / 10;
        int lastDigit = number % 10;

        Console.WriteLine("Первая цифра: " + firstDigit);
        Console.WriteLine("Последняя цифра: " + lastDigit);

        Console.ReadLine();
    }
}