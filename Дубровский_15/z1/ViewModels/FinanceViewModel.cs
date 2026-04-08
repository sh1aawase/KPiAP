using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceApp
{
    public class FinanceViewModel : INotifyPropertyChanged
    {
        private readonly FinanceService _financeService;
        private bool _isLoading;

        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();
        public ObservableCollection<CategoryModel> Stats { get; set; } = new ObservableCollection<CategoryModel>();

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataCommand { get; }

        public FinanceViewModel()
        {
            _financeService = new FinanceService();
            LoadDataCommand = new RelayCommand(async _ => await LoadDataAsync());

            _ = LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            if (IsLoading) return;

            try
            {
                IsLoading = true;
                var data = await _financeService.GetTransactionsFromApiAsync();

                Transactions.Clear();
                foreach (var t in data) Transactions.Add(t);

                var statistics = _financeService.CalculateStatistics(Transactions);
                Stats.Clear();
                foreach (var s in statistics) Stats.Add(s);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}