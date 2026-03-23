using System;

namespace MultiplicationTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Введите третье число: ");
            int c = int.Parse(Console.ReadLine());

            int result = a * b * c;

            Console.WriteLine();
            Console.WriteLine(a + " * " + b + " * " + c + " = " + result);
            Console.WriteLine(c + " * " + b + " * " + a + " = " + result);

            Console.ReadKey();
        }
    }
}