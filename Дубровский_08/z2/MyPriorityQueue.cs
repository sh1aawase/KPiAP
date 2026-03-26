using System;

namespace CourseWork
{
    public class MyPriorityQueue<T>
    {
        private T[] items;
        private int[] priorities;
        private int count;

        public MyPriorityQueue()
        {
            items = new T[10];
            priorities = new int[10];
            count = 0;
        }

        public void Enqueue(T item, int priority)
        {
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
                Array.Resize(ref priorities, priorities.Length * 2);
            }

            items[count] = item;
            priorities[count] = priority;
            count++;

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (priorities[i] > priorities[j])
                    {
                        int tempPriority = priorities[i];
                        priorities[i] = priorities[j];
                        priorities[j] = tempPriority;

                        T tempItem = items[i];
                        items[i] = items[j];
                        items[j] = tempItem;
                    }
                }
            }
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                Console.WriteLine("Очередь пуста");
                return default(T);
            }

            T firstItem = items[0];

            for (int i = 0; i < count - 1; i++)
            {
                items[i] = items[i + 1];
                priorities[i] = priorities[i + 1];
            }

            count--;
            return firstItem;
        }

        public T Peek()
        {
            if (count == 0) return default(T);
            return items[0];
        }

        public int GetCount()
        {
            return count;
        }
    }
}