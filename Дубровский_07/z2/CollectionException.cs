using System;

public class CollectionException : Exception
{
    public CollectionException() : base("Ошибка при работе с коллекцией (CollectionException)")
    {
    }

    public CollectionException(string message) : base(message)
    {
    }

    public CollectionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}