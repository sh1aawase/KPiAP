using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FinanceApp.ViewModels;

namespace FinanceApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private async void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                await Task.Delay(100);
                await vm.SaveChangesCommand.ExecuteAsync(null);
            }
        }
    }
}