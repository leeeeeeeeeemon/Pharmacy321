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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy321.Windows
{
    /// <summary>
    /// Логика взаимодействия для smth.xaml
    /// </summary>
    public partial class smth : Page
    {
        public smth()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Order());
            if (logtb.Text == "123" )
            {

            }
            else
            {
                MessageBox.Show("Not right password");
            }
        }
    }
}
