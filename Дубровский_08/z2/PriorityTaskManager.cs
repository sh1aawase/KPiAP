using System;

namespace CourseWork
{
    public class PriorityTaskManager<T>
    {
        private MyPriorityQueue<T> myQueue;

        public PriorityTaskManager()
        {
            myQueue = new MyPriorityQueue<T>();
        }

        public void AddNewTask(T task, int p)
        {
            myQueue.Enqueue(task, p);
            Console.WriteLine("Задача успешно добавлена");
        }

        public void RunTask()
        {
            if (myQueue.GetCount() > 0)
            {
                T task = myQueue.Dequeue();
                Console.WriteLine("Выполнено: " + task);
            }
            else
            {
                Console.WriteLine("Задач нет");
            }
        }

        public void ShowNext()
        {
            T next = myQueue.Peek();
            if (next != null)
            {
                Console.WriteLine("Следующая задача: " + next);
            }
        }

        public void PrintStatus()
        {
            Console.WriteLine("Осталось задач: " + myQueue.GetCount());
        }
    }
}