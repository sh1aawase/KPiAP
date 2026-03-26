using CourseWork.Converters;
using System;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            if (int.TryParse(Console.ReadLine(), out int inputNumber))
            {
                NumberConverter binaryDel = BinaryConverter.ToBinary;
                NumberConverter hexDel = HexConverter.ToHex;

                Console.WriteLine($"\nЧисло: {inputNumber}");
                Console.WriteLine("----------------------------");

                Console.WriteLine($"BIN: {binaryDel(inputNumber)}");
                Console.WriteLine($"HEX: {hexDel(inputNumber)}");
            }

            Console.ReadKey();
        }
    }
}