using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using WPF01.Classes;
using System.Globalization;

namespace WPF01
{
    /// <summary>
    /// Logica di interazione per EmployeeDetail.xaml
    /// </summary>
    public partial class EmployeeDetail : Window
    {
        public EmployeeDetail()
        {
            InitializeComponent();
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            string nameStr = TxBxName.Text.ToString();
            string prodStr = TxBxProductivity.Text.ToString();
            string totBnsStr = TxBxTotalBonus.Text.ToString();

            float productivity;
            int totBonus;

            bool str2float_IsSuccessful = float.TryParse(prodStr.ToString(CultureInfo.InvariantCulture), out productivity);
            bool str2int_IsSuccessful = int.TryParse(totBnsStr.ToString(CultureInfo.InvariantCulture), out totBonus);

            MessageBox.Show($"N={nameStr}, P={prodStr}, TB={totBnsStr}." + "\n" + $"N={nameStr}, P={productivity}, TB={totBonus}.");

            //if (nameStr.IsNullOrWhiteSpace|| nameStr.IsNullOrEmpty)
            //{

            //}

            Employee employeeToAdd = new Employee(nameStr, 0.01f, 100);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("••• Aggiunta annullata!");

        }


    }
}