using System;
using System.Collections.Generic;

namespace CourseWork
{
    public class YouTubeChannel
    {
        private List<ISubscriber> subscribers = new List<ISubscriber>();
        private string channelName;

        public YouTubeChannel(string name)
        {
            channelName = name;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void UploadVideo(string title)
        {
            Console.WriteLine("Канал " + channelName + " загружает видео: " + title);
            NotifySubscribers(title);
        }

        private void NotifySubscribers(string videoTitle)
        {
            foreach (ISubscriber subscriber in subscribers)
            {
                subscriber.Update(channelName, videoTitle);
            }
        }
    }
}