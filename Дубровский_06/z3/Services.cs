using System;

namespace ServerApp
{
    public class BackupService
    {
        public void CreateBackup(string reason)
        {
            Console.WriteLine("[Служба бэкапа] Создание резервной копии базы данных...");
            Console.WriteLine("[Служба бэкапа] Резервная копия успешно сохранена.");
        }
    }

    public class AlertSystem
    {
        public void NotifyAdmin(string reason)
        {
            Console.WriteLine($"[Система оповещения] Оповещение отправлено админу: Сервер отключается! Причина: {reason}");
        }
    }
}