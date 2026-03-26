using System;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityTaskManager<string> manager = new PriorityTaskManager<string>();

            manager.AddNewTask("Помыть посуду", 3);
            manager.AddNewTask("Сделать лабу", 1);
            manager.AddNewTask("Сходить в магазин", 2);

            Console.WriteLine();
            manager.PrintStatus();
            manager.ShowNext();

            Console.WriteLine("\n--- Процесс выполнения ---");
            manager.RunTask();
            manager.RunTask();
            manager.RunTask();

            Console.WriteLine();
            manager.PrintStatus();

            Console.ReadLine();
        }
    }
}