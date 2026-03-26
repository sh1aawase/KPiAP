using System;
using System.Linq;

public class PasswordManager
{
    public void ValidatePassword(string password)
    {
        bool hasDigit = password.Any(char.IsDigit);

        if (password.Length < 8 || !hasDigit)
        {
            throw new WeakPasswordException("Ошибка: пароль должен быть не короче 8 символов и содержать хотя бы одну цифру (WeakPasswordException)");
        }

        Console.WriteLine("Пароль успешно прошел проверку.");
    }
}