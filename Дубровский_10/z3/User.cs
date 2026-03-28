using System;

namespace CourseWork
{
    public class User : ISubscriber
    {
        private string userName;

        public User(string name)
        {
            userName = name;
        }

        public void Update(string channelName, string videoTitle)
        {
            Console.WriteLine("Уведомление для " + userName + ": На канале " + channelName + " вышло новое видео — " + videoTitle);
        }
    }
}