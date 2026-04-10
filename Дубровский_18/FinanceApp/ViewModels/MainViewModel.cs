using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceApp.Models;
using FinanceApp.Data;

namespace FinanceApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly TransactionRepository _repository;
        private readonly FinanceContext _context;

        [ObservableProperty]
        private ObservableCollection<Transaction> transactions = new();

        [ObservableProperty]
        private decimal totalBalance;

        public MainViewModel()
        {
            _context = new FinanceContext();
            _context.Database.EnsureCreated();
            _repository = new TransactionRepository(_context);
            _ = LoadData();
        }

        private async Task LoadData()
        {
            var data = await _repository.GetTransactionsAsync();
            Transactions = new ObservableCollection<Transaction>(data);
            UpdateBalance();
        }

        public void UpdateBalance() => TotalBalance = Transactions.Sum(t => t.Amount);

        [RelayCommand]
        private async Task AddTransaction()
        {
            var t = new Transaction { Description = "Новая запись", Amount = 0 };
            await _repository.AddTransactionAsync(t);
            await _repository.SaveAsync();
            Transactions.Add(t);
            UpdateBalance();
        }

        [RelayCommand]
        private async Task DeleteTransaction(object? p)
        {
            if (p is Transaction t)
            {
                await _repository.DeleteTransactionAsync(t);
                await _repository.SaveAsync();
                Transactions.Remove(t);
                UpdateBalance();
            }
        }

        [RelayCommand]
        public async Task SaveChanges()
        {
            await _repository.SaveAsync();
            UpdateBalance();
        }
    }
}