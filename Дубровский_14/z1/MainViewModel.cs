using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace FinanceApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Transaction> Transactions { get; set; }
        public ICollectionView TransactionsView { get; set; }

        private Transaction _selectedTransaction;
        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set { _selectedTransaction = value; OnPropertyChanged(nameof(SelectedTransaction)); }
        }

        private DateTime? _filterDate;
        public DateTime? FilterDate
        {
            get => _filterDate;
            set
            {
                _filterDate = value;
                OnPropertyChanged(nameof(FilterDate));
                TransactionsView.Refresh();
            }
        }

        public decimal TotalBalance => Transactions.Sum(t => t.Amount);

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand ResetFilterCommand { get; }

        public MainViewModel()
        {
            Transactions = new ObservableCollection<Transaction>();

            Transactions.CollectionChanged += (s, e) => {
                OnPropertyChanged(nameof(TotalBalance));
                if (e.NewItems != null)
                {
                    foreach (Transaction item in e.NewItems)
                        item.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(TotalBalance));
                }
            };

            TransactionsView = CollectionViewSource.GetDefaultView(Transactions);
            TransactionsView.Filter = (obj) =>
            {
                if (FilterDate == null) return true;
                var t = obj as Transaction;
                return t != null && t.Date.Date == FilterDate.Value.Date;
            };

            AddCommand = new RelayCommand(obj => AddTransaction());
            EditCommand = new RelayCommand(obj => EditTransaction(), obj => SelectedTransaction != null);
            DeleteCommand = new RelayCommand(obj => DeleteTransaction(), obj => SelectedTransaction != null);
            ResetFilterCommand = new RelayCommand(obj => { FilterDate = null; });
        }

        private void AddTransaction()
        {
            DateTime targetDate = FilterDate ?? DateTime.Now;
            var newItem = new Transaction { Date = targetDate, Category = "Новая запись", Amount = 0 };
            var win = new TransactionWindow { DataContext = newItem, Owner = Application.Current.MainWindow };

            if (win.ShowDialog() == true)
            {
                Transactions.Add(newItem);
                TransactionsView.Refresh();
            }
        }

        private void EditTransaction()
        {
            var win = new TransactionWindow { DataContext = SelectedTransaction, Owner = Application.Current.MainWindow };
            win.ShowDialog();
            OnPropertyChanged(nameof(TotalBalance));
            TransactionsView.Refresh();
        }

        private void DeleteTransaction()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Transactions.Remove(SelectedTransaction);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}