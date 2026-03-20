using System;

public partial class BankClient
{
    public string Name;
    public decimal AccountBalance;

    public BankClient(string name, decimal balance)
    {
        Name = name;
        AccountBalance = balance;
    }
}