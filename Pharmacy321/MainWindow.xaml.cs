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
            //LoadData();
            RoleComboBox.ItemsSource = new List<string> { "Администратор", "Сотрудник", "Бухгалтер", "Специалист" };
        }
        //private void LoadData()
        //{
        //    dataGridClients.ItemsSource = database.GetClients().DefaultView;
        //}

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedRole = RoleComboBox.SelectedItem.ToString();
            string password = PasswordBox.Password;

            // Здесь должна быть логика проверки пароля для каждой роли
            bool isAuthenticated = false;

            // Пример простейшей логики авторизации
            switch (selectedRole)
            {
                case "Администратор":
                    isAuthenticated = CheckAdminPassword(password);
                    if (isAuthenticated)
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close(); // Закрыть текущее окно
                    }
                    break;
                case "Сотрудник":
                    isAuthenticated = CheckEmployeePassword(password);
                    if (isAuthenticated)
                    {
                        EmployeeWindow employeeWindow = new EmployeeWindow();
                        employeeWindow.Show();
                        this.Close();
                    }
                    break;
                case "Бухгалтер":
                    isAuthenticated = CheckAccountantPassword(password);
                    if (isAuthenticated)
                    {
                        AccountantWindow accountantWindow = new AccountantWindow();
                        accountantWindow.Show();
                        this.Close();
                    }
                    break;
                case "Специалист":
                    isAuthenticated = CheckSpecialistPassword(password);
                    if (isAuthenticated)
                    {
                        SpecialistWindow specialistWindow = new SpecialistWindow();
                        specialistWindow.Show();
                        this.Close();
                    }
                    break;
                default:
                    MessageBox.Show("Выберите роль!");
                    break;
            }

            if (!isAuthenticated)
            {
                MessageBox.Show("Неверный пароль. Попробуйте снова.");
            }
        }

        // Пример функций для проверки паролей
        private bool CheckAdminPassword(string password)
        {
            // Здесь должна быть реальная проверка пароля
            return password == "admin_password"; // замените на реальный пароль
        }

        private bool CheckEmployeePassword(string password)
        {
            return password == "employee_password"; // замените на реальный пароль
        }

        private bool CheckAccountantPassword(string password)
        {
            return password == "accountant_password"; // замените на реальный пароль
        }

        private bool CheckSpecialistPassword(string password)
        {
            return password == "specialist_password"; // замените на реальный пароль
        }
    }
}