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
using System.Windows.Shapes;

namespace Pharmacy.Windows
{
    public partial class AuthorizationWindow : Window
    {
        private List<Sotrudnik> _staffList;
        private Sotrudnik _selectedEmployee;
        public AuthorizationWindow()
        {
            InitializeComponent();

            _staffList = DBManager.GetStaff();
            Login_CB.ItemsSource = _staffList;
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Login_CB.SelectedItem != null && _selectedEmployee.Password.ToString() == Password_PB.Password.Trim())
            {
                new AdminMain((Sotrudnik)Login_CB.SelectedItem).Show();
                this.Close();
            }
            else
                MessageBox.Show("Выберите пользователя или проверьте пароль!", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Login_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedEmployee = (Sotrudnik)Login_CB.SelectedItem;
        }
    }
}
