using System;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger manager = new Logger();

            manager.AddLog("Система запущена");
            manager.AddLog("Ошибка доступа");
            manager.AddLog("Действие выполнено");

            manager.ShowLogs();

            Console.WriteLine();
            manager.FindLogs("Ошибка");

            Console.WriteLine();
            manager.RemoveLastLog();

            Console.WriteLine("\nОбновленный список:");
            manager.ShowLogs();

            Console.ReadLine();
        }
    }
}