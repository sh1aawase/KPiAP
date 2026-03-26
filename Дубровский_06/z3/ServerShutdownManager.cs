using System;

namespace ServerApp
{
    public delegate void ShutdownHandler(string reason);

    public class ServerShutdownManager
    {
        public event ShutdownHandler ServerShuttingDown;

        public void Shutdown(string reason)
        {
            Console.WriteLine($"\n[Сервер] Завершение работы инициировано. Причина: {reason}");

            ServerShuttingDown?.Invoke(reason);

            Console.WriteLine("[Сервер] Завершение работы выполнено.");
        }
    }
}