using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy321
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database database;
        public MainWindow()
        {
            InitializeComponent();
            database = new Database();
            LoadData();
        }
        private void LoadData()
        {
            dataGridClients.ItemsSource = database.GetClients().DefaultView;
        }

    }
}