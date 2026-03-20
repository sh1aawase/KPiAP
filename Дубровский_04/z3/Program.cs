using System;

class Program
{
    static void Main()
    {
        try
        {
            int baseNum = int.Parse(Console.ReadLine());
            int expNum = int.Parse(Console.ReadLine());

            if (expNum < 0)
            {
                throw new Exception("Negative exponent");
            }

            long result = Power(baseNum, expNum);
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static long Power(int n, int p)
    {
        if (p == 0)
        {
            return 1;
        }

        return n * Power(n, p - 1);
    }
}