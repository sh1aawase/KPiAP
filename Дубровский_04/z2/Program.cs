using System;

class Program
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        int D1 = int.Parse(Console.ReadLine());
        int D2 = int.Parse(Console.ReadLine());

        AddLeftDigit(D1, ref K);
        Console.WriteLine(K);

        AddLeftDigit(D2, ref K);
        Console.WriteLine(K);
    }

    static void AddLeftDigit(int D, ref int K)
    {
        int temp = K;
        int power = 1;

        while (temp > 0)
        {
            temp /= 10;
            power *= 10;
        }

        K = D * power + K;
    }
}