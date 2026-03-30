

public class SendNotificationCommand : ICommand
{
    private INotification _notification;
    private string _message;

    public SendNotificationCommand(INotification n, string m)
    {
        _notification = n;
        _message = m;
    }

    public void Execute() => _notification.Send(_message);
}