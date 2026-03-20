using System;

class A
{
    public int a;
    public int b;

    public A(int valA, int valB)
    {
        a = valA;
        b = valB;
    }

    public double CalculateExpression()
    {
        return a * Math.Pow(b, 4) - 3;
    }

    public double GetSquareOfQuotient()
    {
        return Math.Pow((double)a / b, 2);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("a: ");
        int inputA = int.Parse(Console.ReadLine());

        Console.Write("b: ");
        int inputB = int.Parse(Console.ReadLine());

        A obj = new A(inputA, inputB);

        Console.WriteLine("Поле a = " + obj.a);
        Console.WriteLine("Поле b = " + obj.b);

        Console.WriteLine("Результат ab^4 - 3: " + obj.CalculateExpression());

        if (obj.b != 0)
        {
            Console.WriteLine("Квадрат частного: " + obj.GetSquareOfQuotient());
        }
        else
        {
            Console.WriteLine("Ошибка: деление на ноль");
        }

        Console.ReadKey();
    }
}