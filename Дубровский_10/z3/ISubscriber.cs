namespace CourseWork
{
    public interface ISubscriber
    {
        void Update(string channelName, string videoTitle);
    }
}