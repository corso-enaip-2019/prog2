using P16_Databases_04_TableAdapters.MainDataSetTableAdapters;
using System.Windows;
using static P16_Databases_04_TableAdapters.MainDataSet;

namespace P16_Databases_04_TableAdapters
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            using (var ta = new EmployeesTableAdapter())
            {
                var table = ta.GetData();
                MainGrid.ItemsSource = table;
            }
        }

        private void SaveAllButton_Click(object sender, RoutedEventArgs e)
        {
            using (var ta = new EmployeesTableAdapter())
            {
                var table = MainGrid.ItemsSource as EmployeesDataTable;
                ta.Update(table);
            }
        }
    }
}
