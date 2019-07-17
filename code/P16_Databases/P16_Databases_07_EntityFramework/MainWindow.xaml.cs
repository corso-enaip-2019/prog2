using System.Windows;

namespace P16_Databases_07_EntityFramework
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenAuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new AuthorsWindow();
            w.ShowDialog();
        }

        private void OpenBooksButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new BooksWindow();
            w.ShowDialog();
        }
    }
}
