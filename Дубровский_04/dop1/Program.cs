using System;

class Program
{
    static void Main()
    {
        double xA = double.Parse(Console.ReadLine());
        double yA = double.Parse(Console.ReadLine());
        double xB = double.Parse(Console.ReadLine());
        double yB = double.Parse(Console.ReadLine());
        double xC = double.Parse(Console.ReadLine());
        double yC = double.Parse(Console.ReadLine());
        double xD = double.Parse(Console.ReadLine());
        double yD = double.Parse(Console.ReadLine());

        Console.WriteLine(Perim(xA, yA, xB, yB, xC, yC));
        Console.WriteLine(Perim(xA, yA, xB, yB, xD, yD));
        Console.WriteLine(Perim(xA, yA, xC, yC, xD, yD));
    }

    static double Side(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    static double Perim(double xA, double yA, double xB, double yB, double xC, double yC)
    {
        double ab = Side(xA, yA, xB, yB);
        double bc = Side(xB, yB, xC, yC);
        double ac = Side(xA, yA, xC, yC);

        return ab + bc + ac;
    }
}