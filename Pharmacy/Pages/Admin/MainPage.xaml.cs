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

namespace Pharmacy.Pages.Admin
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void MakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MakeAppointmentPage());
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterClientPage());
        }

        private void MakeReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
