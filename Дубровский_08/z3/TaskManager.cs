using System;

namespace CourseWork
{
    public class TaskManager<T> : ITaskManager<T>
    {
        private TaskStorage<T> storage;

        public TaskManager()
        {
            storage = new TaskStorage<T>();
        }

        public void AddTask(T task)
        {
            storage.Save(task);
            Console.WriteLine("Задача успешно добавлена: " + task);
        }

        public void CompleteTask(T task)
        {
            storage.Remove(task);
            Console.WriteLine("Задача отмечена как выполненная: " + task);
        }

        public void PrintTasks()
        {
            var allTasks = storage.GetAll();
            if (allTasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст");
                return;
            }

            Console.WriteLine("--- Текущий список задач ---");
            foreach (T task in allTasks)
            {
                Console.WriteLine("- " + task);
            }
        }
    }
}