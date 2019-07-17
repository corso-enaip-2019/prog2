using System.Linq;
using System.Windows;

namespace P16_Databases_07_EntityFramework
{
    public partial class AuthorsWindow : Window
    {
        private readonly MainDbContext _ctx;

        public AuthorsWindow()
        {
            InitializeComponent();

            _ctx = new MainDbContext();

            AuthorsDataGrid.ItemsSource = _ctx.Authors.ToList();
        }
    }
}
