using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FinanceApp
{
    public partial class MainWindow : Window
    {
        private string[] months = {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };

        private double[,] data = {
            { 150, 80 }, { 120, 170 }, { 210, 110 }, { 90, 150 },
            { 180, 170 }, { 220, 190 }, { 250, 240 }, { 200, 240 },
            { 150, 180 }, { 170, 150 }, { 140, 190 }, { 240, 230 }
        };

        private int currentIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) => UpdateUI();
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            currentIndex = (currentIndex + 1) % months.Length;
            AnimateFlip(1);
        }

        private void PrevMonth_Click(object sender, RoutedEventArgs e)
        {
            currentIndex = (currentIndex - 1 + months.Length) % months.Length;
            AnimateFlip(-1);
        }

        private void AnimateFlip(int direction)
        {
            DoubleAnimation slideOut = new DoubleAnimation
            {
                To = direction * -50,
                Duration = TimeSpan.FromMilliseconds(150)
            };

            slideOut.Completed += (s, e) =>
            {
                UpdateUI();
                MonthTextTransform.X = direction * 50;
                DoubleAnimation slideIn = new DoubleAnimation
                {
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(150)
                };
                MonthTextTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
            };

            MonthTextTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        }

        private void UpdateUI()
        {
            MonthLabel.Text = months[currentIndex];
            double income = data[currentIndex, 0];
            double expense = data[currentIndex, 1];

            AnimateBar(IncomeBar, income);
            AnimateBar(ExpenseBar, expense);

            CheckBudgetStatus(income, expense);
        }

        private void AnimateBar(System.Windows.Shapes.Rectangle bar, double newHeight)
        {
            DoubleAnimation anim = new DoubleAnimation
            {
                From = bar.Height,
                To = newHeight,
                Duration = TimeSpan.FromSeconds(0.6),
                EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseOut }
            };
            bar.BeginAnimation(HeightProperty, anim);
            bar.Height = newHeight;
        }

        private void CheckBudgetStatus(double income, double expense)
        {
            Color targetColor = (expense > income) ? Color.FromRgb(255, 230, 230) : Colors.White;

            ColorAnimation backgroundAnim = new ColorAnimation
            {
                To = targetColor,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            if (MainGrid.Background is SolidColorBrush brush)
            {
                if (brush.IsFrozen)
                    MainGrid.Background = new SolidColorBrush(brush.Color);

                MainGrid.Background.BeginAnimation(SolidColorBrush.ColorProperty, backgroundAnim);
            }
            else
            {
                MainGrid.Background = new SolidColorBrush(Colors.White);
                MainGrid.Background.BeginAnimation(SolidColorBrush.ColorProperty, backgroundAnim);
            }
        }
    }
}