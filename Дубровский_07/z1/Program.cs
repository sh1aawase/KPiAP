using System;

class Program
{
    static void Main()
    {
        Warehouse myWarehouse = new Warehouse();

        try
        {
            myWarehouse.CheckStock(0);
        }
        catch (OutOfStockException ex)
        {
            Console.WriteLine("Перехвачено исключение: " + ex.Message);

            if (ex.InnerException != null)
            {
                Console.WriteLine("Внутреннее исключение: " + ex.InnerException.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Общая ошибка: " + ex.Message);
        }

        Console.ReadLine();
    }
}