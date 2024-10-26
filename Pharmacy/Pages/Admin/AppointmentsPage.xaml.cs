using Pharmacy.Data;
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
    public partial class AppointmentsPage : Page
    {
        private Sotrudnik _currentEmployee;
        private List<Zapis_priem> _staffList;
        public AppointmentsPage(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            _currentEmployee = sotrudnik;
            LoadAppointmentsData();
        }

        private void LoadAppointmentsData()
        {
            if (_currentEmployee.Id == 1)
                _staffList = DBManager.GetAppointments();
            else
                _staffList = DBManager.GetAppointments().Where(z => z.Id_sotrudnik == _currentEmployee.Id).ToList();
            AppointmentsDataGrid.ItemsSource = _staffList;
        }
    }
}
