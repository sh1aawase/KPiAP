using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("Привет, студент");
        string suffix = "студент";

        bool result = sb.ToString().EndsWith(suffix);

        if (result)
        {
            Console.WriteLine("Да");
        }
        else
        {
            Console.WriteLine("Нет");
        }
    }
}