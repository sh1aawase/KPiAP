using System;

Console.Write("Введите радиус: ");

if (double.TryParse(Console.ReadLine(), out double radius))
{
    double diametr  = 2 * radius;
    Console.WriteLine($"Диаметр: {diametr}");
}
else
{
    Console.WriteLine("Ошибка ввода.");
}