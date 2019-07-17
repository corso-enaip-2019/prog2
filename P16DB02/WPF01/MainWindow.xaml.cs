using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Data;

using WPF01.Classes;
using WPF01.DBInteractions;

namespace WPF01
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();




            //AddBonus(0.05, 3, 111);
        }

        #region Click sui pulsanti
        /* Carica la tabella degl'impiegati. */
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            DBInteraction dBInter = new DBInteraction();
            DtGEmployeesGrid.ItemsSource = dBInter.ReadEmployeesFromDB();

            MessageBox.Show("Employees loaded!");
        }

        /* Crea un nuovo impiegato e lo salva sul DB. */
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Employee add mode.");

            /* Nel caso non ci sia stato un load della tabella. */
            DBInteraction dBInter = new DBInteraction();
            DtGEmployeesGrid.ItemsSource = dBInter.ReadEmployeesFromDB();

            /* Apertura finestra d'aggiunta. */
            Window employeeDetailWindow = new EmployeeDetail();
            employeeDetailWindow.Show();

            /* Aggiorno la tabella a schermo. */
            DtGEmployeesGrid.ItemsSource = dBInter.ReadEmployeesFromDB();
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