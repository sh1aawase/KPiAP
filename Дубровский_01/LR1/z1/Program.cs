using System;

Console.Write("Введите радиус: ");

if (double.TryParse(Console.ReadLine(), out double radius))
{
    double dia = 2 * radius;
    Console.WriteLine($"Диаметр: {dia}");
}
else
{
    Console.WriteLine("Ошибка ввода.");
}