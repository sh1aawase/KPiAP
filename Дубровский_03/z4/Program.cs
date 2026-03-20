using System;

class Bank
{
    public BankClient[] Clients;

    public Bank(BankClient[] clients)
    {
        Clients = clients;
    }

    public void GetClientsWithLowBalance(decimal minBalance)
    {
        for (int i = 0; i < Clients.Length; i++)
        {
            if (Clients[i].AccountBalance < minBalance)
            {
                Clients[i].DisplayInfo();
            }
        }
    }

    public BankClient GetRichestClient()
    {
        if (Clients.Length == 0) return null;

        BankClient richest = Clients[0];
        for (int i = 1; i < Clients.Length; i++)
        {
            if (Clients[i].AccountBalance > richest.AccountBalance)
            {
                richest = Clients[i];
            }
        }
        return richest;
    }
}

class Program
{
    static void Main()
    {
        BankClient[] list = new BankClient[]
        {
            new BankClient("Иван", 500.50m),
            new BankClient("Анна", 15000.00m),
            new BankClient("Олег", 100.00m),
            new BankClient("Мария", 3000.00m)
        };

        Bank myBank = new Bank(list);

        Console.WriteLine("Клиенты с балансом ниже 1000:");
        myBank.GetClientsWithLowBalance(1000);

        Console.WriteLine("\nСамый богатый клиент:");
        BankClient rich = myBank.GetRichestClient();
        if (rich != null)
        {
            rich.DisplayInfo();
        }

        Console.ReadKey();
    }
}