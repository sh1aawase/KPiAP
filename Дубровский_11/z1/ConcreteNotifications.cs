using System;

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[Email] {message}");
}

public class SMSNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[SMS] {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[Push] {message}");
}