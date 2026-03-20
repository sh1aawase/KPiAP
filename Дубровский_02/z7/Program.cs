using System;

class Program
{
    static void Main()
    {
        string original = "Привет колледж!";
        string toInsert = "прекрасный ";
        int index = 7;

        string result = original.Insert(index, toInsert);

        Console.WriteLine(result);
    }
}