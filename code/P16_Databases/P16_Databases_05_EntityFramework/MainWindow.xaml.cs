using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace P16_Databases_05_EntityFramework
{
    public partial class MainWindow : Window
    {
        public const string CONNECTION_STRING = @"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new MainDbContext(CONNECTION_STRING))
            {
                MainGrid.ItemsSource = ctx.Employees.ToList();
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new EmployeeDetailWindow();

            if (detailWindow.ShowDialog() != true)
                return;

            var newEmployee = detailWindow.Model;

            using (var ctx = new MainDbContext(CONNECTION_STRING))
            {
                Debug.WriteLine($"stato di Employee: {ctx.Entry(newEmployee).State}; Id: {newEmployee.Id}");
                ctx.Employees.Add(newEmployee);
                Debug.WriteLine($"stato di Employee: {ctx.Entry(newEmployee).State}; Id: {newEmployee.Id}");
                ctx.SaveChanges();
                Debug.WriteLine($"stato di Employee: {ctx.Entry(newEmployee).State}; Id: {newEmployee.Id}");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.SelectedItem == null)
                return;

            var detailWindow = new EmployeeDetailWindow(MainGrid.SelectedItem as Employee);

            if (detailWindow.ShowDialog() != true)
                return;

            var updated = detailWindow.Model;

            using (var ctx = new MainDbContext(CONNECTION_STRING))
            {
                Debug.WriteLine($"stato di Employee: {ctx.Entry(updated).State}; Id: {updated.Id}");

                // avendo creato un nuovo DbContext,
                // lui non ha registrato lo stato di updated,
                // quindi devo a mano configurarlo
                // perché consideri 'updated' come un model già creato e modificato:
                ctx.Employees.Attach(updated);
                ctx.Entry(updated).State = EntityState.Modified;

                Debug.WriteLine($"stato di Employee: {ctx.Entry(updated).State}; Id: {updated.Id}");

                ctx.SaveChanges();

                Debug.WriteLine($"stato di Employee: {ctx.Entry(updated).State}; Id: {updated.Id}");

                // E' meglio avere un unico DbContext,
                // passato/creato nel costruttore della MainWindow
                // e salvato come campo privato.
            }
        }
    }
}
