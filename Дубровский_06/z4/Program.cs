using System;

namespace WarehouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WarehouseMonitor monitor = new WarehouseMonitor();
            InventoryTracker tracker = new InventoryTracker();

            tracker.Subscribe(monitor);

            monitor.MoveItem("Ноутбук", "Зона А-15");
            monitor.MoveItem("Смартфон", "Стеллаж Б-3");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}