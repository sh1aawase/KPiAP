using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace FinanceApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Transaction> Transactions { get; set; }

        private Transaction _selectedTransaction;
        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set
            {
                _selectedTransaction = value;
                OnPropertyChanged("SelectedTransaction");
            }
        }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public MainViewModel()
        {
            Transactions = new ObservableCollection<Transaction>();

            AddCommand = new RelayCommand(obj => AddTransaction());

            EditCommand = new RelayCommand(
                obj => EditTransaction(),
                obj => SelectedTransaction != null 
            );

            DeleteCommand = new RelayCommand(
                obj => DeleteTransaction(),
                obj => SelectedTransaction != null 
            );
        }

        private void AddTransaction()
        {
            Transactions.Add(new Transaction { Amount = 1000, Category = "Доход", Date = DateTime.Now });
        }

        private void EditTransaction()
        {
            if (SelectedTransaction == null) return;

            var temp = new Transaction
            {
                Amount = SelectedTransaction.Amount,
                Category = SelectedTransaction.Category,
                Date = SelectedTransaction.Date
            };

            var win = new TransactionWindow();
            win.DataContext = temp; 
            win.Owner = Application.Current.MainWindow;

            if (win.ShowDialog() == true)
            {
                int index = Transactions.IndexOf(SelectedTransaction);

                Transactions[index] = temp;


                SelectedTransaction = temp;
            }
        }

        private void DeleteTransaction()
        {
            var result = MessageBox.Show("Удалить выбранную транзакцию?", "Подтверждение",
                                        MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Transactions.Remove(SelectedTransaction);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}