using System;

Console.Write("Введите число: ");
int n = int.Parse(Console.ReadLine());

if (n < 0) n = -n;

int d1 = n / 10;
int d2 = n % 10;
int sum = d1 + d2;

if (sum % 2 == 0)
{
    Console.WriteLine("Четная");
}
else
{
    Console.WriteLine("Нечетная");
}