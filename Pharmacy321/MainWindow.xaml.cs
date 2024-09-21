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
        private readonly string adminPassword = "admin123";//админ
        private readonly string employeePassword = "emp123";//сотрудник
        private readonly string accountantPassword = "acc123";//бухгалтер
        private readonly string doctorPassword = "doc123";//врач
        public MainWindow()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = new string[] { "Администратор", "Сотрудник", "Бухгалтер", "Специалист" };
            RoleComboBox.SelectedIndex = 0;
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedRole = RoleComboBox.SelectedItem.ToString();
            string enteredPassword = PasswordBox.Password;

            // Проверка пароля для каждой роли
            if (selectedRole == "Администратор" && enteredPassword == adminPassword)
            {
                OpenAdminWindow();
            }
            else if (selectedRole == "Сотрудник" && enteredPassword == employeePassword)
            {
                OpenEmployeeWindow();
            }
            else if (selectedRole == "Бухгалтер" && enteredPassword == accountantPassword)
            {
                OpenAccountantWindow();
            }
            else if (selectedRole == "Специалист" && enteredPassword == doctorPassword)
            {
                OpenDoctorWindow();
            }
            else
            {
                MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Методы для открытия окон для каждой роли
        private void OpenAdminWindow()
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void OpenEmployeeWindow()
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }

        private void OpenAccountantWindow()
        {
            AccountantWindow accountantWindow = new AccountantWindow();
            accountantWindow.Show();
            this.Close();
        }

        private void OpenDoctorWindow()
        {
            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.Show();
            this.Close();
        }
    }
}