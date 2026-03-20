using System;

Console.Write("A = ");
int A = int.Parse(Console.ReadLine());
Console.Write("B = ");
int B = int.Parse(Console.ReadLine());
Console.Write("X = ");
int X = int.Parse(Console.ReadLine());

for (int i = A; i <= B; i++)
{
    if (Math.Abs(i) % 10 == X)
    {
        Console.WriteLine(i);
    }
}