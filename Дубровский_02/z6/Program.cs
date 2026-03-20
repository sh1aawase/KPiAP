using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();

        string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        int count = 0;

        foreach (string word in words)
        {
            bool onlyLatin = true;

            foreach (char c in word)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                {
                    onlyLatin = false;
                    break;
                }
            }

            if (onlyLatin)
            {
                count++;
            }
        }

        Console.WriteLine("Количество латинских слов: " + count);
    }
}