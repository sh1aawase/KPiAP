using System;

public class Warehouse
{
    public void CheckStock(int quantity)
    {
        if (quantity < 1)
        {
            throw new OutOfStockException("Ошибка: количество товара на складе меньше 1 (OutOfStockException)");
        }

        Console.WriteLine("Товар в наличии: " + quantity);
    }
}