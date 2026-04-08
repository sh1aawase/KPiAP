using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinanceApp
{
    public class Transaction : INotifyPropertyChanged
    {
        private decimal _amount;
        private string _category;
        private DateTime _date;

        public decimal Amount { get => _amount; set => SetProperty(ref _amount, value); }
        public string Category { get => _category; set => SetProperty(ref _category, value); }
        public DateTime Date { get => _date; set => SetProperty(ref _date, value); }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            if (Equals(field, value)) return;
            field = value;
            OnPropertyChanged(name);
        }
    }

    public class CategoryModel
    {
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public double Percentage { get; set; }
    }
}