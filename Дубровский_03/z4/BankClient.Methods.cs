using System;

public partial class BankClient
{
    public void DisplayInfo()
    {
        Console.WriteLine("Клиент: " + Name + ", Баланс: " + AccountBalance);
    }
}