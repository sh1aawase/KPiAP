using System;

class Program
{
    static void Main()
    {
        double[] numbers = { 1.5, 2.0, 3.5, 4.0, 2.0, 8.5 };

        double product = 1;
        bool found = false;

        for (int i = 0; i < numbers.Length; i += 2)
        {
            product *= numbers[i];
            found = true;
        }

        if (found)
        {
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}