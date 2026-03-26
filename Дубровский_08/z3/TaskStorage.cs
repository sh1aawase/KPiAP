using System;
using System.Collections.Generic;

namespace CourseWork
{
    public class TaskStorage<T>
    {
        private List<T> tasks;

        public TaskStorage()
        {
            tasks = new List<T>();
        }

        public void Save(T task)
        {
            tasks.Add(task);
        }

        public void Remove(T task)
        {
            tasks.Remove(task);
        }

        public List<T> GetAll()
        {
            return tasks;
        }
    }
}