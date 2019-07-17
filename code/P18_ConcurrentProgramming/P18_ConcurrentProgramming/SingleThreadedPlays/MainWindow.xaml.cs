using System.Threading;
using System.Windows;

namespace SingleThreadedPlays
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainButton.Content = "loading...";

            // expensive operations:
            Thread.Sleep(5000);

            MainButton.Content = "Task finished!";
        }
    }
}
