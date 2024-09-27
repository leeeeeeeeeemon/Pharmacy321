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

namespace Pharmacy321
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private Database database;

        public AdminWindow()
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