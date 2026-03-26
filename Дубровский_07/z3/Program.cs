using System;

class Program
{
    static void Main()
    {
        PasswordManager manager = new PasswordManager();

        try
        {
            Console.Write("Введите пароль для проверки: ");
            string input = Console.ReadLine();

            manager.ValidatePassword(input);
        }
        catch (WeakPasswordException ex)
        {
            Console.WriteLine("Обнаружена проблема: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка: " + ex.Message);
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}