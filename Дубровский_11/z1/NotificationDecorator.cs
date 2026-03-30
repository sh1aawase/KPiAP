

public abstract class NotificationDecorator : INotification
{
    protected INotification _wrapped;
    public NotificationDecorator(INotification notification) => _wrapped = notification;
    public virtual void Send(string message) => _wrapped.Send(message);
}