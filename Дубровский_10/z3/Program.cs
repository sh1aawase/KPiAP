using System;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            YouTubeChannel myChannel = new YouTubeChannel("Программирование на C#");

            User user1 = new User("Алексей");
            User user2 = new User("Мария");
            User user3 = new User("Дмитрий");

            myChannel.Subscribe(user1);
            myChannel.Subscribe(user2);
            myChannel.Subscribe(user3);

            myChannel.UploadVideo("Урок по паттерну Наблюдатель");

            Console.WriteLine("\n--- Дмитрий отписался ---");
            myChannel.Unsubscribe(user3);

            myChannel.UploadVideo("Новый влог");

            Console.ReadKey();
        }
    }
}