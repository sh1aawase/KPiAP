using System;
using System.Windows;
using z1.ViewModels;

namespace z1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new FinanceViewModel();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            FinanceViewModel vm = DataContext as FinanceViewModel;
            if (vm != null)
            {
                vm.PasswordInput = PassBox.Password;
                vm.LoginCommand.Execute(null);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (ChatIn != null)
            {
                string text = ChatIn.Text;

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    ChatIn.Clear();
                    ChatIn.Focus();
                }));
            }
        }
    }
}