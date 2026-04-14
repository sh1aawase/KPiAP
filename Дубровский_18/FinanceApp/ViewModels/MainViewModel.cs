using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceApp.Data;
using FinanceApp.Models;
using FinanceApp.Services;

namespace FinanceApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly TransactionRepository _repository;
        private readonly FinanceContext _context;
        private readonly DataService _dataService = new();
        private readonly InterProcessService _interProcessService = new();

        private readonly string[] _months =
        {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };

        private readonly double[,] _analyticsData =
        {
            { 150, 80 }, { 120, 170 }, { 210, 110 }, { 90, 150 },
            { 180, 170 }, { 220, 190 }, { 250, 240 }, { 200, 240 },
            { 150, 180 }, { 170, 150 }, { 140, 190 }, { 240, 230 }
        };

        private int _currentMonthIndex;

        [ObservableProperty]
        private ObservableCollection<Transaction> transactions = new();

        [ObservableProperty]
        private decimal totalBalance;

        [ObservableProperty]
        private ObservableCollection<string> chatMessages = new();

        [ObservableProperty]
        private bool isAuthenticated;

        [ObservableProperty]
        private string loginInput = string.Empty;

        [ObservableProperty]
        private string passwordInput = string.Empty;

        [ObservableProperty]
        private User? currentUser;

        [ObservableProperty]
        private string reminder = "Нет активных напоминаний";

        [ObservableProperty]
        private string newCategory = string.Empty;

        [ObservableProperty]
        private string newAmount = string.Empty;

        [ObservableProperty]
        private string currentMonth = "Январь";

        [ObservableProperty]
        private double monthIncome;

        [ObservableProperty]
        private double monthExpense;

        public bool IsAdmin => CurrentUser?.Role == UserRole.Admin;

        public MainViewModel()
        {
            _context = new FinanceContext();
            _context.Database.EnsureCreated();
            _repository = new TransactionRepository(_context);

            UpdateAnalyticsData();
            _interProcessService.StartPipeServer(OnPipeMessageReceived);
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
            if (string.IsNullOrWhiteSpace(NewCategory))
            {
                return;
            }

            if (!decimal.TryParse(NewAmount, NumberStyles.Number, CultureInfo.CurrentCulture, out var amount) &&
                !decimal.TryParse(NewAmount, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
            {
                return;
            }

            var t = new Transaction { Description = NewCategory.Trim(), Amount = amount };
            await _repository.AddTransactionAsync(t);
            await _repository.SaveAsync();
            Transactions.Add(t);
            NewCategory = string.Empty;
            NewAmount = string.Empty;
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

        [RelayCommand]
        private void Login()
        {
            var user = _dataService.Authenticate(LoginInput, PasswordInput);
            if (user == null)
            {
                MessageBox.Show("Ошибка входа");
                return;
            }

            CurrentUser = user;
            IsAuthenticated = true;
            Reminder = _interProcessService.ReadReminder();

            ChatMessages.Clear();
            foreach (var message in _dataService.LoadChat())
            {
                ChatMessages.Add(message);
            }
        }

        [RelayCommand]
        private void SendMessage(string? text)
        {
            if (!IsAuthenticated || CurrentUser == null || string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            var message = $"[{DateTime.Now:HH:mm}] {CurrentUser.Username}: {text.Trim()}";
            AppendMessageIfMissing(message);
            _interProcessService.SendPipeMessage(message);
        }

        [RelayCommand]
        private void SaveReminder(string? text)
        {
            if (!IsAdmin || string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            var normalized = text.Trim();
            _interProcessService.WriteReminder(normalized);
            Reminder = normalized;
        }

        [RelayCommand]
        private void NextMonth()
        {
            _currentMonthIndex = (_currentMonthIndex + 1) % _months.Length;
            UpdateAnalyticsData();
        }

        [RelayCommand]
        private void PrevMonth()
        {
            _currentMonthIndex = (_currentMonthIndex - 1 + _months.Length) % _months.Length;
            UpdateAnalyticsData();
        }

        partial void OnCurrentUserChanged(User? value)
        {
            OnPropertyChanged(nameof(IsAdmin));
        }

        private void UpdateAnalyticsData()
        {
            CurrentMonth = _months[_currentMonthIndex];
            MonthIncome = _analyticsData[_currentMonthIndex, 0];
            MonthExpense = _analyticsData[_currentMonthIndex, 1];
        }

        private void OnPipeMessageReceived(string message)
        {
            if (Application.Current == null)
            {
                return;
            }

            Application.Current.Dispatcher.Invoke(() => AppendMessageIfMissing(message));
        }

        private void AppendMessageIfMissing(string message)
        {
            if (ChatMessages.Contains(message))
            {
                return;
            }

            ChatMessages.Add(message);
            _dataService.SaveChat(ChatMessages.ToList());
        }
    }
}