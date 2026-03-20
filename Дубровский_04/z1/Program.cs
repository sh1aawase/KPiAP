using System;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        if (IsPrime(number))
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}