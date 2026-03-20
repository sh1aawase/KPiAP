using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < 100; i++)
        {
            numbers[i] = i + 1;
        }

        int count = 0;
        for (int i = 99; i >= 0; i--)
        {
            Console.Write(numbers[i] + "\t");
            count++;

            if (count % 6 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}