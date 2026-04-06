using System;
using System.Windows;

namespace FinanceApp 
{
    
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(); 
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}