using System;

namespace CourseWork
{
    public class SessionManager
    {
        private static SessionManager instance;
        private string currentUser;

        private SessionManager()
        {
            currentUser = null;
        }

        public static SessionManager GetInstance()
        {
            if (instance == null)
            {
                instance = new SessionManager();
            }
            return instance;
        }

        public void Login(string user)
        {
            currentUser = user;
            Console.WriteLine("Пользователь вошел: " + currentUser);
        }

        public void Logout()
        {
            Console.WriteLine("Пользователь " + currentUser + " вышел из системы");
            currentUser = null;
        }

        public string GetCurrentUser()
        {
            return currentUser;
        }
    }
}