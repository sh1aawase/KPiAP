using System;

namespace WarehouseApp
{
    public class InventorySystem
    {
        public void UpdateRecord(string itemName, string location)
        {
            Console.WriteLine($"[Система учета] Данные обновлены: {itemName} теперь находится в {location}.");
        }
    }

    public class SecuritySystem
    {
        public void CheckPermission(string itemName, string location)
        {
            Console.WriteLine($"[Система безопасности] Проверка разрешений на перемещение '{itemName}' в '{location}'... Разрешено.");
        }
    }

    public class InventoryTracker
    {
        private InventorySystem _inventory = new InventorySystem();
        private SecuritySystem _security = new SecuritySystem();

        public void Subscribe(WarehouseMonitor monitor)
        {
            monitor.ItemMoved += _inventory.UpdateRecord;
            monitor.ItemMoved += _security.CheckPermission;
        }
    }
}