using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        CollectionHandler handler = new CollectionHandler();
        List<int> numbers = new List<int> { 10, 20, 30 };

        try
        {
            handler.ProcessCollection(numbers, 10);
        }
        catch (CollectionException ex)
        {
            Console.WriteLine("Сообщение: " + ex.Message);
            Console.WriteLine("Стек вызовов: " + ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine("\n--- Внутреннее исключение ---");
                Console.WriteLine("Тип: " + ex.InnerException.GetType());
                Console.WriteLine("Сообщение: " + ex.InnerException.Message);
                Console.WriteLine("Стек внутреннего исключения: " + ex.InnerException.StackTrace);
            }
        }

        Console.ReadLine();
    }
}