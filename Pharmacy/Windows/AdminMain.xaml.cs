using Pharmacy.Pages.Admin;
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

namespace Pharmacy.Windows
{
    public partial class AdminMain : Window
    {
        private Sotrudnik _currentEmployee;
        public AdminMain(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            _currentEmployee = sotrudnik;
            userName.Text = _currentEmployee.Surname + " " + _currentEmployee.Name;
            userProfession.Text = _currentEmployee.Doljnost;
            MainFrame.Navigate(new MainPage());
        }
    }
}
