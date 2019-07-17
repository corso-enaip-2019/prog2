using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;

namespace P16_Databases_03_Readers
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
            MainGrid.ItemsSource = ReadEmployeesFromDb();
        }

        private static List<Employee> ReadEmployeesFromDb()
        {
            var result = new List<Employee>();

            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Id, Name, Productivity, TotalBonus FROM Employees";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var e = new Employee
                            {
                                Id = (int)reader[0],                // indexer per indice di colonna
                                Name = (string)reader["Name"],      // indexer per nome di colonna
                                Productivity = reader.GetDouble(2), // metodo tipizzato per indice di colonna
                                TotalBonus = reader.GetInt32(3),    // i metodi tipizzati sono diversi: per int, double, string, DateTime, ...
                            };
                            result.Add(e);
                        }
                    }
                }
            }

            return result;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new EmployeeDetailWindow();

            if (detailWindow.ShowDialog() != true)
                return;

            var newEmployee = detailWindow.Model;

            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    // Questo modo di costruire le stringhe è SBAGLIATO,
                    // perché concatenare i valori a mano
                    // espone l'applicativo ad attacchi di tipo SQL INJECTION:
                    //cmd.CommandText =
                    //    $" INSERT INTO Employees" +
                    //    $" (Name, Productivity, TotalBonus)" +
                    //    $" values" +
                    //    $" ('{newEmployee.Name}', {newEmployee.Productivity.ToString(CultureInfo.InvariantCulture)}, {newEmployee.TotalBonus})";

                    cmd.CommandText =
                        $" INSERT INTO Employees" +
                        $" (Name, Productivity, TotalBonus)" +
                        $" values" +
                        $" (@Name, @Productivity, @TotalBonus)";

                    cmd.Parameters.AddWithValue("@Name", newEmployee.Name);
                    cmd.Parameters.AddWithValue("@Productivity", newEmployee.Productivity.ToString(CultureInfo.InvariantCulture));
                    cmd.Parameters.AddWithValue("@TotalBonus", newEmployee.TotalBonus);

                    cmd.ExecuteNonQuery();
                }
            }

            MainGrid.ItemsSource = ReadEmployeesFromDb();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.SelectedItem == null)
                return;

            var detailWindow = new EmployeeDetailWindow(MainGrid.SelectedItem as Employee);

            if (detailWindow.ShowDialog() != true)
                return;

            var updated = detailWindow.Model;

            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        $" UPDATE Employees" +
                        $" SET Name='{updated.Name}', Productivity={updated.Productivity.ToString(CultureInfo.InvariantCulture)}, TotalBonus={updated.TotalBonus}" +
                        $" WHERE Id={updated.Id};";

                    cmd.ExecuteNonQuery();
                }
            }

            MainGrid.ItemsSource = ReadEmployeesFromDb();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Productivity { get; set; }
        public int TotalBonus { get; set; }
    }
}
