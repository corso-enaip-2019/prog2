using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitPlays
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainButton.Content = "calculating...";

            var n = 500_000_227;

            Task<bool> task = Task.Run(() =>
            {
                return IsPrime(n);
            });

            var result = await task;

            MainButton.Content = result
                ? "Is Prime!"
                : "Is not Prime!";
        }

        private bool IsPrime(long n)
        {
            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        private async void ErroredButton_Click(object sender, RoutedEventArgs e)
        {
            ErroredButton.Content = "calculating...";

            var text = InputNumberTextBox.Text;

            Task<bool> task = Task.Run(() =>
            {
                var n = int.Parse(text);
                return IsPrime(n);
            });

            try
            {
                var result = await task;

                ErroredButton.Content = result
                    ? "Is Prime!"
                    : "Is not Prime!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
