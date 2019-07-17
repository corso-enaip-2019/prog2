using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Readers
{
    class Program
    {
        static void Main(string[] args)
        {
            AddBonus(0.05, 3, 111);
        }

        static void AddBonus(double productivityThreshold, int maxBonussableEmpoyees, int bonus)
        {
            var employees = ReadEmployeesFromDB();
            var employeesAboveProductivityThreshold = employees
                .Where(emp => emp.Productivity > productivityThreshold)
                .ToList();

            if (employeesAboveProductivityThreshold.Count > maxBonussableEmpoyees)
            {
                /* Troppi impegati bravi. -> Riduci il numero d' impiegati da premiare a maxBonussableEmpoyees. */
                employeesAboveProductivityThreshold = employeesAboveProductivityThreshold
                    .OrderByDescending(emp => emp.Productivity) // Pari all'«ORDER BY Productivity DESC» dell'SQL.
                    .Take(maxBonussableEmpoyees)                // Pari all'«TOP(maxBonussableEmpoyees)» dell'SQL.
                    .ToList();
            }

            employeesAboveProductivityThreshold.ForEach(goodE => goodE.TotalBonus += bonus);

            #region foreach_Standard
            /* Non tutti considerano buona la sintassi in stile LinQ, quindi è preferiible con il «foreach» standard ("foreach" in minuscolo = quello std, .ForEach() per quello in LinQ). Vedi: blogs.msdn.microsoft.com/ericlippert/2009/05/18/foreach-vs-foreach */
            //foreach (Employee goodE in employeesAboveProductivityThreshold)
            //{
            //    goodE.TotalBonus += bonus;
            //} 
            #endregion

        }

        static List<Employee> ReadEmployeesFromDB()
        {
            var outList = new List<Employee>();

            //string myServer = @"TRISRV10\SQLEXPRESS";
            //string myDB = @"CS2019_BenNic";
            //bool isATrustedCnn = true;
            //string myIsATrustedCnn = isATrustedCnn ? "True" : "False2";
            //string connectionString = "Server=" + myServer + ";Database=" + myDB + ";Trusted_Connection=" + myIsATrustedCnn + ";";
            string connectionString = @"Server=TRISRV10\SQLEXPRESS; Database=dbo.CS2019_BenNic; Trusted_Connection=True;";
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT [ID], [Name], Productivity, TotalBonus FROM dbo.x04Prdct_Employee";

                    int numberOfModifiedRows = cmd.ExecuteNonQuery();

                    using (var rdr = cmd.ExecuteReader())
                    {

                        /* Se prova a leggere un ...
                         * Record con contenuto -> rdr.Read() == true
                         * Record che non esiste -> rdr.Read() == false */
                        while (rdr.Read())
                        {
                            var emp = new Employee()
                            {
                                ID = (int)rdr[0],               // Accesso diretto con l'indice + casting.
                                Name = (string)rdr["Name"],     // Accesso tramite nome della colonna + casting.
                                Productivity = rdr.GetFloat(2), // Accesso & casting tramite metodo tipizzato (l'accesso alla colonna tramite indice, dipende dal metodo).
                                TotalBonus = rdr.GetInt32(3)    // Accesso & casting tramite metodo tipizzato (l'accesso alla colonna tramite indice, dipende dal metodo).
                            };

                            outList.Add(emp);
                        }
                    }
                }
            }

            return outList;
        }

        private static SqlCommand CreateCmd4Update(Employee emp, SqlConnection cnn)
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE dbo.x04Prdct_Employee SET TotalBonus = {emp.TotalBonus} WHERE ID = {emp.ID}";
            /*SELECT [ID], [Name], Productivity, TotalBonus FROM dbo.x04Prdct_Employee*/

            return cmd;
        }

        private static void UpdateEmployees(List<Employee> employees)
        {
            string connectionString = @"Server=TRISRV10\SQLEXPRESS; Database=dbo.CS2019_BenNic; Trusted_Connection=True;";
            using (var cnn = new SqlConnection(connectionString))
            {
                foreach (Employee emp in employees)
                {
                    CreateCmd4Update(emp, cnn);
                }
            }

            return;
        }
    }
}