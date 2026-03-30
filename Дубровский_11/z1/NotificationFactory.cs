

public abstract class NotificationFactory
{
    public abstract INotification CreateNotification();

    public void SendNotification(string message)
    {
        var notification = CreateNotification();
        notification.Send(message);
    }
}