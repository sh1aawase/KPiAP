using System;
using System.Collections;

namespace CourseWork
{
    public class Logger
    {
        private Stack logStack;

        public Logger()
        {
            logStack = new Stack();
        }

        public void AddLog(string message)
        {
            LogEntry newLog = new LogEntry(message);
            logStack.Push(newLog);
            Console.WriteLine("Запись добавлена");
        }

        public void RemoveLastLog()
        {
            if (logStack.Count > 0)
            {
                LogEntry removed = (LogEntry)logStack.Pop();
                Console.WriteLine("Удалена запись: " + removed);
            }
            else
            {
                Console.WriteLine("Список пуст");
            }
        }

        public void ShowLogs()
        {
            if (logStack.Count == 0)
            {
                Console.WriteLine("История логов пуста");
                return;
            }

            Console.WriteLine("--- Все логи ---");
            foreach (object item in logStack)
            {
                LogEntry log = (LogEntry)item;
                Console.WriteLine(log.ToString());
            }
        }

        public void FindLogs(string text)
        {
            Console.WriteLine("--- Результаты поиска ---");
            bool found = false;
            foreach (object item in logStack)
            {
                LogEntry log = (LogEntry)item;
                if (log.Message.ToLower().Contains(text.ToLower()))
                {
                    Console.WriteLine(log);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Совпадений нет");
            }
        }

        public void ClearAll()
        {
            logStack.Clear();
            Console.WriteLine("Очистка завершена");
        }
    }
}