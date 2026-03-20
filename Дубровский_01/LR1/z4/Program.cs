using System;

Console.Write("x = ");
double x = double.Parse(Console.ReadLine());

double y;

if (x > 2.8 && x < 6)
{
    y = (x - 1) / (x + 1);
    Console.WriteLine(y);
}

if (x > 6)
{
    y = Math.Exp(x) + Math.Sin(x);
    Console.WriteLine(y);
}