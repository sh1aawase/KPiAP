using System;
using UserManagement;

namespace UserManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ID пользователя: ");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                UserAction block = UserOperations.BlockUser;
                UserAction unblock = UserOperations.UnblockUser;

                UserOperations.PerformUserAction(userId, block);
                UserOperations.PerformUserAction(userId, unblock);
            }
            else
            {
                Console.WriteLine("Некорректный ID.");
            }

            Console.ReadKey();
        }
    }
}