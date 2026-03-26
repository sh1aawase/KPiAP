using System;

namespace WarehouseApp
{
    public delegate void ItemMovedHandler(string itemName, string location);

    public class WarehouseMonitor
    {
        public event ItemMovedHandler ItemMoved;

        public void MoveItem(string itemName, string location)
        {
            Console.WriteLine($"\n[Склад] Товар '{itemName}' перемещен в секцию: {location}");
            ItemMoved?.Invoke(itemName, location);
        }
    }
}