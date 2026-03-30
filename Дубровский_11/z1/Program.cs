using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        NotificationFactory factory = new EmailFactory();
        INotification email = factory.CreateNotification();

        INotification sms = new SMSFactory().CreateNotification();
        INotification secureSms = new EncryptionDecorator(sms);

        List<ICommand> commands = new List<ICommand>
        {
            new SendNotificationCommand(email, "Обычное письмо"),
            new SendNotificationCommand(secureSms, "Зашифрованное SMS")
        };

        foreach (var command in commands)
        {
            command.Execute();
        }
    }
}