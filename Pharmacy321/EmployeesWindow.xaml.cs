using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class EmployeesWindow : Window
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeesWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            using (var context = new AptekaContext())
            {
                Employees = new ObservableCollection<Employee>(context.Employee.ToList());
            }
        }
    }
}

