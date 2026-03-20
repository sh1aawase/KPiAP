using System;

class Program
{
    static void Main()
    {
        int[,] a = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        double E = 2;
        double F = 7;
        double sumSq = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (a[i, j] > E && a[i, j] <= F)
                {
                    sumSq += a[i, j] * a[i, j];
                }
            }
        }
        Console.WriteLine("Сумма квадратов: " + sumSq);

        Console.Write("Введите k (0-2): ");
        int k = int.Parse(Console.ReadLine());
        int sumCol = 0;

        for (int i = 0; i < 3; i++)
        {
            sumCol += a[i, k];
        }
        Console.WriteLine("Сумма столбца: " + sumCol);
    }
}