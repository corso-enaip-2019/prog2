using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace P16_Databases_07_EntityFramework
{
    public partial class BooksWindow : Window
    {
        private readonly MainDbContext _ctx;

        public BooksWindow()
        {
            InitializeComponent();

            _ctx = new MainDbContext();

            LoadBooks();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new BookDetailWindow();

            if (detailWindow.ShowDialog() != true)
                return;

            _ctx.Books.Add(detailWindow.Model);
            _ctx.SaveChanges();

            LoadBooks();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var toUpdate = BooksGrid.SelectedItem as BookRowVM;

            if (toUpdate == null)
                return;

            var detailWindow = new BookDetailWindow(toUpdate.Id);

            if (detailWindow.ShowDialog() == true)
                LoadBooks();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var toDelete = BooksGrid.SelectedItem as Book;

            if (toDelete == null)
                return;

            _ctx.Books.Remove(toDelete);

            _ctx.SaveChanges();

            LoadBooks();
        }

        private void LoadBooks()
        {
            // potrei usare una classe anonima:
            //BooksGrid.ItemsSource = _ctx.Books
            //    .Include(x => x.Author)
            //    .Select(x => new
            //        {
            //            x.Id,
            //            x.Title,
            //            x.Year,
            //            Author = x.Author.Name + " " + x.Author.Surname
            //        })
            //    .ToList();

            // ma poi non posso fare cast e riutilizzarla.

            // Meglio creare una classe specifica:
            BooksGrid.ItemsSource = _ctx.Books
                .Include(x => x.Author)
                .Select(x => new BookRowVM
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Year = x.Year,
                        Author = x.Author.Name + " " + x.Author.Surname
                    })
                .ToList();
        }
    }
}
