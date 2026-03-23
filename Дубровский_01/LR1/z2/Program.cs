
using System;

Console.Write("Введите четырехзначное число: ");
if (int.TryParse(Console.ReadLine(), out int number) && number >= 1000 && number <= 9999)
{
    int d1 = number / 1000;
    int d2 = (number / 100) % 10;
    int d3 = (number / 10) % 10;
    int d4 = number % 10;

    bool result = (d1 + d2) == (d3 + d4);

    Console.WriteLine(result);
}
else
{
    Console.WriteLine("Ошибка: введите корректное четырехзначное число.");
}