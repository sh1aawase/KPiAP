using System;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager<string> myManager = new TaskManager<string>();

            myManager.AddTask("Подготовить отчет по практике");
            myManager.AddTask("Сдать лабораторную работу");
            myManager.AddTask("Купить продукты");

            Console.WriteLine();
            myManager.PrintTasks();

            Console.WriteLine();
            myManager.CompleteTask("Купить продукты");

            Console.WriteLine("\nОбновленное состояние:");
            myManager.PrintTasks();

            Console.ReadLine();
        }
    }
}