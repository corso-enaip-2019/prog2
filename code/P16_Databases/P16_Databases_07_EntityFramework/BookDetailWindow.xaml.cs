using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace P16_Databases_07_EntityFramework
{
    public partial class BookDetailWindow : Window
    {
        public BookDetailWindow(int? id = null)
        {
            InitializeComponent();

            _ctx = new MainDbContext();

            if (id != null)
                Model = _ctx.Books.First(x => x.Id == id);
            else
                Model = new Book();

            AuthorsComboBox.ItemsSource = _ctx.Authors.ToList();

            DataContext = Model;
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            _ctx.SaveChanges();

            DialogResult = true;
        }

        public Book Model { get; private set; }

        private MainDbContext _ctx;

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Title += "ciao";
        }
    }
}
