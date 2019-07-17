using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Data;

using System.Data.Entity;
using WPF02EntityFW.Classes;
using WPF02EntityFW.DBInteractions;

namespace WPF02EntityFW
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string CONNECTION_STRING = @"Server=TRISRV10\SQLEXPRESS; Database=CS2019_BenNic; Trusted_Connection=True;";

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Click sui pulsanti
        /* Carica la tabella degl'impiegati. */
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            /* Carica i dati nella DataGrid, prendendoli col MainDBContext (che è un System.Data.Entity.DbContext). */
            using (var ctx = new MainDBContext(CONNECTION_STRING))
            {
                DtGEmployeesGrid.ItemsSource = ctx.Employees.ToList();
            }
            /* Con la classe a parte DBInteractions: */
            //DBInteraction dBInter = new DBInteraction();
            //DtGEmployeesGrid.ItemsSource = dBInter.ReadEmployeesFromDB();

            MessageBox.Show("Employees loaded!");
        }

        /* Crea un nuovo impiegato e salvalo sul DB. */
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Employee add mode.");

            /* Apertura finestra d'aggiunta. */
            Window employeeDetailWindow = new EmployeeDetailWindow();

            /* Nel caso prima non ci sia stato un load della tabella. */
            using (var ctx = new MainDBContext(CONNECTION_STRING))
            {
                DtGEmployeesGrid.ItemsSource = ctx.Employees.ToList();
            }
            /* Con la classe a parte DBInteractions: */
            //DBInteraction dBInter = new DBInteraction();
            //DtGEmployeesGrid.ItemsSource = dBInter.ReadEmployeesFromDB();

            #region Info su ShowDialog
            /* Se il «.ShowDialog()» restituisce true
                 * -> Vuol dire che
                 * -> . */
            /* Se il «.ShowDialog()» restituisce false -> Vuol dire che ->
             * -> Vuol dire che
             * -> . */
            /* public void Show();
             * Riepilogo:
             *      Apre una finestra e restituisce solo quando si chiude la finestra appena aperta.
             * Valori restituiti:
             *      Oggetto System.Nullable `1 valore di tipo System.Boolean che specifica se l'attività:
             *      true -> è stato accettato
             *      false -> annullato
             *      Il valore restituito è il valore di System.Windows.Window.DialogResult proprietà prima della chiusura di una finestra. */ 
            #endregion
            if (employeeDetailWindow.ShowDialog() != true)
                return;

            /* Prendo dalla finestra employeeDetailWindow l'Employee costruito in quella finestra e restituitomi tramite il «.Model». */
            //ytemporaneamente commentatovia
            //Employee newEmployee = employeeDetailWindow.Model;

            //ytemporaneamente commentatovia
            //using (var ctx = new MainDBContext(CONNECTION_STRING))
            //{
            //    ctx.Employees.Add(newEmployee);
            //    ctx.SaveChanges();
            //}


            /* Aggiorno la tabella a schermo. */
            //DtGEmployeesGrid.ItemsSource = dBInter.ReadEmployeesFromDB();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Hello NEW TO ME cruel world!");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Hello cruel world, DIE!");
        }
        #endregion

        #region Operazioni sugl_impiegati
        static void AddBonus(double productivityThreshold, int maxBonussableEmpoyees, int bonus)
        {
            DBInteraction dBInter = new DBInteraction();
            var employees = dBInter.ReadEmployeesFromDB();
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

            return;
        }
        #endregion

        #region Interazioni col DB

        #endregion

        #region Classi
        //Spostato in cartella "Classes".
        #endregion
    }
}