using System;

namespace UserManagement
{
    public class UserOperations
    {
        public static void BlockUser(int id)
        {
            Console.WriteLine($"Пользователь с ID {id} успешно заблокирован.");
        }

        public static void UnblockUser(int id)
        {
            Console.WriteLine($"Пользователь с ID {id} успешно разблокирован.");
        }

        public static void PerformUserAction(int id, UserAction action)
        {
            Console.WriteLine($"--- Подготовка операции для ID: {id} ---");
            action(id);
        }
    }
}