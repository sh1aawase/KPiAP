using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using FinanceApp.ViewModels;

namespace FinanceApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Loaded += (_, _) => RefreshAnalytics(animated: false);
        }

        private async void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                await Task.Delay(100);
                await vm.SaveChangesCommand.ExecuteAsync(null);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                vm.PasswordInput = PassBox.Password;
                vm.LoginCommand.Execute(null);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                ChatIn.Clear();
                ChatIn.Focus();
            }));
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                vm.NextMonthCommand.Execute(null);
                AnimateFlip(1);
            }
        }

        private void PrevMonth_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                vm.PrevMonthCommand.Execute(null);
                AnimateFlip(-1);
            }
        }

        private void AnimateFlip(int direction)
        {
            var slideOut = new DoubleAnimation
            {
                To = direction * -50,
                Duration = TimeSpan.FromMilliseconds(150)
            };

            slideOut.Completed += (_, _) =>
            {
                RefreshAnalytics(animated: true);
                MonthTextTransform.X = direction * 50;
                var slideIn = new DoubleAnimation
                {
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(150)
                };
                MonthTextTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
            };

            MonthTextTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        }

        private void RefreshAnalytics(bool animated)
        {
            if (DataContext is not MainViewModel vm)
            {
                return;
            }

            MonthLabel.Text = vm.CurrentMonth;
            AnimateBar(IncomeBar, vm.MonthIncome, animated);
            AnimateBar(ExpenseBar, vm.MonthExpense, animated);
            UpdateBackground(vm.MonthIncome, vm.MonthExpense);
        }

        private static void AnimateBar(System.Windows.Shapes.Rectangle bar, double newHeight, bool animated)
        {
            if (!animated)
            {
                bar.Height = newHeight;
                return;
            }

            var animation = new DoubleAnimation
            {
                From = bar.Height,
                To = newHeight,
                Duration = TimeSpan.FromSeconds(0.6),
                EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseOut }
            };

            bar.BeginAnimation(HeightProperty, animation);
            bar.Height = newHeight;
        }

        private void UpdateBackground(double income, double expense)
        {
            var targetColor = expense > income ? Color.FromRgb(255, 230, 230) : Colors.White;
            var animation = new ColorAnimation
            {
                To = targetColor,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            if (MainGrid.Background is not SolidColorBrush brush)
            {
                brush = new SolidColorBrush(Colors.White);
                MainGrid.Background = brush;
            }
            else if (brush.IsFrozen)
            {
                brush = new SolidColorBrush(brush.Color);
                MainGrid.Background = brush;
            }

            brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }
    }
}