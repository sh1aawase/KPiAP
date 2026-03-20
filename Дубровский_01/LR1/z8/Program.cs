using System;

Console.Write("A = ");
int A = int.Parse(Console.ReadLine());
Console.Write("B = ");
int B = int.Parse(Console.ReadLine());

int n = 0;

for (int i = B - 1; i > A; i--)
{
    Console.WriteLine(i);
    n++;
}

Console.WriteLine("N = " + n);