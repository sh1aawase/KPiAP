using System;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 10, 5, 5 },
            { 1, 2, 3 },
            { 4, 8, 2 }
        };

        Console.Write("Введите номер строки (0-2): ");
        int row = int.Parse(Console.ReadLine());

        int sum = 0;
        for (int j = 0; j < 3; j++)
        {
            sum += matrix[row, j];
        }

        if (sum % 10 == 0)
        {
            Console.WriteLine("Верно: сумма " + sum + " оканчивается на 0");
        }
        else
        {
            Console.WriteLine("Неверно: сумма " + sum + " не оканчивается на 0");
        }
    }
}