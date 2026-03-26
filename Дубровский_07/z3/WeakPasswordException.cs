using System;

public class WeakPasswordException : Exception
{
    public WeakPasswordException() : base("Пароль слишком слабый (WeakPasswordException)")
    {
    }

    public WeakPasswordException(string message) : base(message)
    {
    }

    public WeakPasswordException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}