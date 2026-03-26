using System;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerShutdownManager manager = new ServerShutdownManager();
            BackupService backup = new BackupService();
            AlertSystem alert = new AlertSystem();

            manager.ServerShuttingDown += backup.CreateBackup;
            manager.ServerShuttingDown += alert.NotifyAdmin;

            manager.Shutdown("Плановое техническое обслуживание");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}