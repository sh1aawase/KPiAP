using System;

class Program
{
    static void Main()
    {
        string text = "программирование это интересно и программирование это полезно";

        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            bool isDuplicate = false;

            for (int j = 0; j < i; j++)
            {
                if (words[i].ToLower() == words[j].ToLower())
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                result += words[i] + " ";
            }
        }

        Console.WriteLine(result.Trim());
    }
}