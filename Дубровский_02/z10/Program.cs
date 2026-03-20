using System;

class Program
{
    static void Main()
    {
        string text = "Привет";

        if (!string.IsNullOrEmpty(text) && char.IsUpper(text[0]))
        {
            Console.WriteLine("Да, начинается с заглавной");
        }
        else
        {
            Console.WriteLine("Нет");
        }
    }
}