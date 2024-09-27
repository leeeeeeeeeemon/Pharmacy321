using System.Collections.Generic;
using System.Windows;

namespace Pharmacy321
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database database; // Объявление переменной database

        public MainWindow()
        {
            InitializeComponent();
            database = new Database();

            RoleComboBox.ItemsSource = new List<string> { "Администратор", "Сотрудник", "Бухгалтер", "Специалист" };
        }

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

        private bool CheckAdminPassword(string password)
        {
            return password == "admin_password";
        }

        private bool CheckEmployeePassword(string password)
        {
            return password == "employee_password";
        }

        private bool CheckAccountantPassword(string password)
        {
            return password == "accountant_password";
        }

        private bool CheckSpecialistPassword(string password)
        {
            return password == "123";
        }
    }
}
