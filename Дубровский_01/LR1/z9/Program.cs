using System;

double A = 2;
double B = 7;
int M = 15;
double H = (B - A) / M;

for (double x = A; x <= B + H / 2; x += H)
{
    double y = Math.Atan(x);
    Console.WriteLine($"x: {Math.Round(x, 2)} | y: {Math.Round(y, 4)}");
}