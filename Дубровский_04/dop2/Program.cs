using System;

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(GetLength(s));

        string[] arr = { "Программирование", "Студент" };
        Console.WriteLine(GetLength(arr));
    }

    static int GetLength(string str)
    {
        return str.Length;
    }

    static int GetLength(string[] strArray)
    {
        int total = 0;
        foreach (string s in strArray)
        {
            total += s.Length;
        }
        return total;
    }
}