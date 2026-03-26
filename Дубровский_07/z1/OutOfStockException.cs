using System;

public class OutOfStockException : Exception
{
    public OutOfStockException() : base("Товара нет на складе (OutOfStockException)")
    {
    }

    public OutOfStockException(string message) : base(message)
    {
    }

    public OutOfStockException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}