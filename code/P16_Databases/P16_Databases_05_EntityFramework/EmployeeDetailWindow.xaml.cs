using System.Globalization;
using System.Windows;

namespace P16_Databases_05_EntityFramework
{
    public partial class EmployeeDetailWindow : Window
    {
        public EmployeeDetailWindow(Employee model = null)
        {
            InitializeComponent();

            Model = model ?? new Employee();

            NameTextBox.Text = Model.Name;
            ProductivityTextBox.Text = Model.Productivity.ToString();
            TotalBonusTextBox.Text = Model.TotalBonus.ToString();
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Name = NameTextBox.Text;
            Model.Productivity = double.Parse(ProductivityTextBox.Text, CultureInfo.InvariantCulture);
            Model.TotalBonus = int.Parse(TotalBonusTextBox.Text, CultureInfo.InvariantCulture);

            DialogResult = true;
        }

        public Employee Model { get; set; }
    }
}
