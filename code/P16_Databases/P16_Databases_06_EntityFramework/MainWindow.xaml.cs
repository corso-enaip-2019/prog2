using System.Linq;
using System.Windows;

namespace P16_Databases_06_EntityFramework
{
    public partial class MainWindow : Window
    {
        public const string CONNECTION_STRING = @"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;";

        private readonly MainDbContext _ctx;

        public MainWindow()
        {
            InitializeComponent();

            _ctx = new MainDbContext(CONNECTION_STRING);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadEmployees();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new EmployeeDetailWindow();

            if (detailWindow.ShowDialog() != true)
                return;

            _ctx.Employees.Add(detailWindow.Model);
            _ctx.SaveChanges();

            LoadEmployees();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.SelectedItem == null)
                return;

            var detailWindow = new EmployeeDetailWindow(MainGrid.SelectedItem as Employee);

            if (detailWindow.ShowDialog() != true)
                return;

            // Siccome il model è stato creato dal DbContext,
            // il DbContext conosce lo stato dell'oggetto,
            // quindi non serve fare Attach/Update, modificare lo State, ecc.

            // Basta solo salvare:
            _ctx.SaveChanges();

            LoadEmployees();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var toDelete = MainGrid.SelectedItem as Employee;

            if (toDelete == null)
                return;

            _ctx.Employees.Remove(toDelete);

            _ctx.SaveChanges();

            LoadEmployees();
        }

        private void LoadEmployees()
        {
            MainGrid.ItemsSource = _ctx.Employees.ToList();
        }
    }
}
