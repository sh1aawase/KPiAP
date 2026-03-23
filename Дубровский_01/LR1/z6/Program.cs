using System;

Console.Write("Введите номер месяца: ");
int month = int.Parse(Console.ReadLine());

if (month >= 1 && month <= 12)
{
    int remaining = 12 - month;
    Console.WriteLine(remaining);
}
else
{
    Console.WriteLine("Ошибка");
}   