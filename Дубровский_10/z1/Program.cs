using System;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            SessionManager session = SessionManager.GetInstance();

            session.Login("Иван");

            string current = session.GetCurrentUser();
            Console.WriteLine("Текущий пользователь в системе: " + current);

            session.Logout();

            if (session.GetCurrentUser() == null)
            {
                Console.WriteLine("Сессия пуста");
            }

            Console.ReadKey();
        }
    }
}