

public class EncryptionDecorator : NotificationDecorator
{
    public EncryptionDecorator(INotification n) : base(n) { }
    public override void Send(string message)
    {
        string encrypted = $"<Encrypted>{message}</Encrypted>";
        base.Send(encrypted);
    }
}