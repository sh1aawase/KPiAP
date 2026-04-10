using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using z1.Models;
using z1.Services;

namespace z1.ViewModels
{
    public class FinanceViewModel : INotifyPropertyChanged
    {
        private readonly TransactionRepository _repo = new TransactionRepository();
        private readonly DataService _data = new DataService();
        private readonly InterProcessService _ipc = new InterProcessService();

        private bool _isAuth;
        private User _user;
        private string _rem;
        private string _nCat;
        private string _nAmt;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsAuthenticated { get { return _isAuth; } set { _isAuth = value; OnPropertyChanged("IsAuthenticated"); } }
        public User CurrentUser { get { return _user; } set { _user = value; OnPropertyChanged("CurrentUser"); OnPropertyChanged("IsAdmin"); } }
        public bool IsAdmin { get { return CurrentUser != null && CurrentUser.Role == UserRole.Admin; } }
        public string Reminder { get { return _rem; } set { _rem = value; OnPropertyChanged("Reminder"); } }
        public string NewCategory { get { return _nCat; } set { _nCat = value; OnPropertyChanged("NewCategory"); } }
        public string NewAmount { get { return _nAmt; } set { _nAmt = value; OnPropertyChanged("NewAmount"); } }

        public string LoginInput { get; set; }
        public string PasswordInput { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; }
        public ObservableCollection<string> ChatMessages { get; set; }

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand AddTransactionCommand { get; set; }
        public RelayCommand DeleteTransactionCommand { get; set; }
        public RelayCommand SendCommand { get; set; }
        public RelayCommand SaveReminderCommand { get; set; }

        public FinanceViewModel()
        {
            Transactions = new ObservableCollection<Transaction>();
            ChatMessages = new ObservableCollection<string>();
            LoginInput = ""; PasswordInput = "";

            LoadDataAsync();

            LoginCommand = new RelayCommand(delegate (object o) {
                User u = _data.Authenticate(LoginInput, PasswordInput);
                if (u != null)
                {
                    CurrentUser = u;
                    IsAuthenticated = true;
                    Reminder = _ipc.ReadReminder();

                    ChatMessages.Clear();
                    var lc = _data.LoadChat();
                    if (lc != null) foreach (var m in lc) ChatMessages.Add(m);
                }
                else MessageBox.Show("Ошибка входа!");
            });

            AddTransactionCommand = new RelayCommand(async delegate (object o) {
                decimal a;
                if (decimal.TryParse(NewAmount, out a) && !string.IsNullOrEmpty(NewCategory))
                {
                    var t = new Transaction { Date = DateTime.Now, Category = NewCategory, Amount = a };
                    await _repo.AddTransactionAsync(t);
                    Transactions.Add(t);
                    NewCategory = ""; NewAmount = "";
                    OnPropertyChanged("NewCategory"); OnPropertyChanged("NewAmount");
                }
            });

            DeleteTransactionCommand = new RelayCommand(async delegate (object o) {
                if (o is Transaction t)
                {
                    await _repo.DeleteTransactionAsync(t);
                    Transactions.Remove(t);
                }
            });

            SendCommand = new RelayCommand(delegate (object o) {
                if (o != null && !string.IsNullOrWhiteSpace(o.ToString()))
                {
                    string m = string.Format("[{0:HH:mm}] {1}: {2}", DateTime.Now, CurrentUser.Username, o);
                    if (!ChatMessages.Contains(m)) { ChatMessages.Add(m); _data.SaveChat(ChatMessages.ToList()); }
                    _ipc.SendPipeMessage(m);
                }
            });

            _ipc.StartPipeServer(delegate (string m) {
                if (Application.Current != null) Application.Current.Dispatcher.Invoke(new Action(delegate () {
                    if (!ChatMessages.Contains(m)) { ChatMessages.Add(m); _data.SaveChat(ChatMessages.ToList()); }
                }));
            });

            SaveReminderCommand = new RelayCommand(delegate (object o) {
                if (o != null) { _ipc.WriteReminder(o.ToString()); Reminder = o.ToString(); }
            });
        }

        private async void LoadDataAsync()
        {
            var data = await _repo.GetTransactionsAsync();
            Transactions.Clear();
            foreach (var t in data) Transactions.Add(t);
        }

        protected void OnPropertyChanged(string n)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(n));
        }
    }
}