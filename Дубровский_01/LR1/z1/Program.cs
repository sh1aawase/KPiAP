using System;

Console.Write("Введите радиус: ");

if (double.TryParse(Console.ReadLine(), out double radius))
{
    double diameter = 2 * radius;
    Console.WriteLine($"Диаметр: {diameter}");
}
else
{
    Console.WriteLine("Ошибка ввода.");
}