using System.Linq;
using System.Windows;

using WPF02EntityFW.Classes;
using System.Globalization;

/* Contiene i dettagli dell'Employee scelto od in creazione / Eliminazione. */

namespace WPF02EntityFW
{
    /// <summary>
    /// Logica di interazione per EmployeeDetail.xaml
    /// </summary>
    public partial class EmployeeDetailWindow : Window
    {
        public EmployeeDetailWindow(Employee model=null)
        {
            InitializeComponent();

            /* Se in input al costruttore della finestra è stato dato un Employee/model vuoto (per esempio quando se ne crea uno nuovo), creane uno nuovo. */
            /* x = y ?? z;
                 y != null -> x=y
                 y == null -> x=z */
            Model = model ?? new Employee(0,"NewEmployee", 0f, 0);

            /* Pre-riempimento delle TextBox. */
            TxBxID.Text = Model.ID.ToString();
            TxBxName.Text = Model.Name.ToString();
            TxBxProductivity.Text = Model.Productivity.ToString();
            TxBxTotalBonus.Text = Model.TotalBonus.ToString();
        }

        #region Click sui pulsanti
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string nameStr = TxBxName.Text.ToString();
            string prodStr = TxBxProductivity.Text.ToString();
            string totBnsStr = TxBxTotalBonus.Text.ToString();

            float productivity;
            int totBonus;

            bool str2float_IsSuccessful = float.TryParse(prodStr.ToString(CultureInfo.InvariantCulture), out productivity);
            bool str2int_IsSuccessful = int.TryParse(totBnsStr.ToString(CultureInfo.InvariantCulture), out totBonus);

            MessageBox.Show($"N={nameStr}, P={prodStr}, TB={totBnsStr}." + "\n" + $"N={nameStr}, P={productivity}, TB={totBonus}.");

            if (!(!(string.IsNullOrEmpty(nameStr)) && str2float_IsSuccessful&& str2int_IsSuccessful))
            {
                MessageBox.Show("Dati immessi non buoni!");
            }

            /* "Riempimento" del Model. */
            Model.Name = nameStr;
            Model.Productivity = productivity;
            Model.TotalBonus = totBonus;

            DialogResult = true;

            // ???
            //Employee employeeToAdd = new Employee(nameStr, 0.01f, 100);
            // ???
            //var updatedEmployee = EmployeeDetailWindow.Window.Model;
            // ???
            //using (var ctx = new MainDBContext(CONNECTION_STRING))
            //{
            //    ctx.Employees.Attach(updated);
            //    ctx.Entry(updated).State = EntityState.Modified;
            //    DtGEmployeesGrid.ItemsSource = ctx.Employees.ToList();
            //}
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("••• Aggiunta annullata!");

            DialogResult = false;
        }
        #endregion

        /* prop pubblica che sarà accessibile dall'esterno. */
        public Employee Model { get; set; } 
    }
}