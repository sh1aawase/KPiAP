using System.Windows;

namespace FinanceApp 
{
    public partial class TransactionWindow : Window
    {
        public TransactionWindow()
        {
            
            InitializeComponent();
        }

        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}