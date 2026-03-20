using System;

class Program
{
    static void Main()
    {
        int intNum = 5;
        CalculateFactorial(in intNum, out long fact);
        Console.WriteLine(fact);

        double doubleNum = 3.0;
        CalculateFactorial(in doubleNum, out double factDouble);
        Console.WriteLine(factDouble);
    }

    static void CalculateFactorial(in int number, out long result)
    {
        result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
    }

    static void CalculateFactorial(in double number, out double result)
    {
        double tempResult = 1;
        int limit = (int)Math.Round(number);

        for (int i = 1; i <= limit; i++)
        {
            tempResult *= i;
        }

        result = tempResult;
    }
}