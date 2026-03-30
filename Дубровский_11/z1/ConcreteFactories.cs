

public class EmailFactory : NotificationFactory
{
    public override INotification CreateNotification() => new EmailNotification();
}

public class SMSFactory : NotificationFactory
{
    public override INotification CreateNotification() => new SMSNotification();
}

public class PushFactory : NotificationFactory
{
    public override INotification CreateNotification() => new PushNotification();
}