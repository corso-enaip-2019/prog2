using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16_Databases_01_Readers
{
    class Program
    {
        static void Main(string[] args)
        {
            AddBonus(0.7, 3, 100);

            Console.Write("Operation successful, press a key to exit...");
            Console.Read();
        }

        static void AddBonus(double minProductivity, int maxCount, int bonus)
        {
            var employees = ReadEmployeesFromDb();

            var employeesAboveProd = employees
                .Where(x => x.Productivity > minProductivity)
                .ToList();

            if (employeesAboveProd.Count > maxCount)
            {
                employeesAboveProd = employeesAboveProd
                    .OrderByDescending(x => x.Productivity)
                    .Take(maxCount)
                    .ToList();
            }

            foreach (var e in employeesAboveProd)
                e.TotalBonus += bonus;
            //equivalente: employeesAboveProd.ForEach(e => e.TotalBonus += bonus);

            UpdateEmployees(employeesAboveProd);
        }

        private static List<Employee> ReadEmployeesFromDb()
        {
            var result = new List<Employee>();

            using (var conn = new SqlConnection(@"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;"))
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

        private static void UpdateEmployees(List<Employee> employees)
        {
            using (var conn = new SqlConnection(@"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;"))
            {
                conn.Open();

                var updates = employees
                    .Select(e => CreateCmdForUpdate(e, conn));

                foreach (var cmd in updates)
                    cmd.ExecuteNonQuery();
            }
        }

        private static SqlCommand CreateCmdForUpdate(Employee e, SqlConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE Employees SET TotalBonus = {e.TotalBonus} WHERE Id = {e.Id}";

            return cmd;
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Productivity { get; set; }
        public int TotalBonus { get; set; }
    }
}
