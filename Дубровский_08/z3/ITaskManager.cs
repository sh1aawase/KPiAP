using System;

namespace CourseWork
{
    public interface ITaskManager<T>
    {
        void AddTask(T task);
        void CompleteTask(T task);
    }
}