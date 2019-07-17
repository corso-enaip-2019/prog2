using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPF01.Classes;
using System.Data.SqlClient;
using System.Data;

namespace WPF01.DBInteractions
{
    public class DBInteraction
    {
        //#region Singleton
        //private static DBInteraction dBIInstance = new DBInteraction();

        //private DBInteraction()
        //{ }

        //public static DBInteraction DBIInstance
        //{
        //    get { return dBIInstance; }
        //}
        //#endregion

        public List<Employee> ReadEmployeesFromDB()
        {
            var outList = new List<Employee>();

            //string myServer = @"TRISRV10\SQLEXPRESS";
            //string myDB = @"CS2019_BenNic";
            //bool isATrustedCnn = true;
            //string myIsATrustedCnn = isATrustedCnn ? "True" : "False2";
            //string connectionString = "Server=" + myServer + ";Database=" + myDB + ";Trusted_Connection=" + myIsATrustedCnn + ";";
            string connectionString = @"Server=TRISRV10\SQLEXPRESS; Database=CS2019_BenNic; Trusted_Connection=True;";
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
                                ID = (int)rdr[0],                                   // Accesso diretto con l'indice + casting.
                                Name = rdr["Name"].ToString(),                      // Accesso tramite nome della colonna + .ToString().
                                Productivity = (float)(double)rdr["Productivity"],  // Accesso tramite nome della colonna + casting + casting (TSQL's float = C#'s double).
                                TotalBonus = (int)rdr["TotalBonus"]                 // Accesso tramite nome della colonna + casting.
                            };

                            outList.Add(emp);
                        }
                    }
                }
            }

            return outList;
        }

        public void AddEmployeeToDB(Employee employeeToAdd)
        {
            var outList = new List<Employee>();

            //string myServer = @"TRISRV10\SQLEXPRESS";
            //string myDB = @"CS2019_BenNic";
            //bool isATrustedCnn = true;
            //string myIsATrustedCnn = isATrustedCnn ? "True" : "False2";
            //string connectionString = "Server=" + myServer + ";Database=" + myDB + ";Trusted_Connection=" + myIsATrustedCnn + ";";
            string connectionString = @"Server=TRISRV10\SQLEXPRESS; Database=CS2019_BenNic; Trusted_Connection=True;";
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $"USE [CS2019_BenNic] GO INSERT INTO [dbo].[x04Prdct_Employee] ([Name], [Productivity], [TotalBonus]) VALUES ({employeeToAdd.Name}, {(float)employeeToAdd.Productivity}, {employeeToAdd.TotalBonus}) GO";

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
                                ID = (int)rdr[0],                                   // Accesso diretto con l'indice + casting.
                                Name = rdr["Name"].ToString(),                      // Accesso tramite nome della colonna + .ToString().
                                Productivity = (float)(double)rdr["Productivity"],  // Accesso tramite nome della colonna + casting + casting (TSQL's float = C#'s double).
                                TotalBonus = (int)rdr["TotalBonus"]                 // Accesso tramite nome della colonna + casting.
                            };

                            outList.Add(emp);
                        }
                    }
                }
            }

            return;
        }
    }
}