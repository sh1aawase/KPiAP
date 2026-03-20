using System;

Console.Write("n = ");
int n = int.Parse(Console.ReadLine());

int count = 0;

for (int i = 1; i <= n; i++)
{
    if (n % i == 0)
    {
        count++;
    }
}

Console.WriteLine(count);