using System;

class Program
{
    static void Main()
    {
        Console.Write("Масштаб карты (км в 1 см) —> ");
        double scale = double.Parse(Console.ReadLine());

        Console.Write("Расстояние между точками (см) -> ");
        double distanceCm = double.Parse(Console.ReadLine());

        double realDistance = scale * distanceCm;

        Console.WriteLine("Расстояние между населенными пунктами " + realDistance + " км.");

        Console.ReadKey();
    }
}