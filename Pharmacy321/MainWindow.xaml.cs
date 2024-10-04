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
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty UserRoleProperty =
            DependencyProperty.Register("UserRole", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty, OnUserRoleChanged));

        public string UserRole
        {
            get { return (string)GetValue(UserRoleProperty); }
            set { SetValue(UserRoleProperty, value); }
        }

        private static void OnUserRoleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var mainWindow = d as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.SetButtonVisibility();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetButtonVisibility()
        {
            switch (UserRole)
            {
                case "Client":
                    MedicationsButton.Visibility = Visibility.Visible;
                    break;
                case "Pharmacist":
                    MedicationsButton.Visibility = Visibility.Visible;
                    ClientsButton.Visibility = Visibility.Visible;
                    EmployeesButton.Visibility = Visibility.Visible;
                    OrdersButton.Visibility = Visibility.Visible;
                    break;
                case "Admin":
                    MedicationsButton.Visibility = Visibility.Visible;
                    ClientsButton.Visibility = Visibility.Visible;
                    EmployeesButton.Visibility = Visibility.Visible;
                    OrdersButton.Visibility = Visibility.Visible;
                    ProvidersButton.Visibility = Visibility.Visible;
                    ContractsButton.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.Show();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesWindow employeesWindow = new EmployeesWindow();
            employeesWindow.Show();
        }

        private void MedicationsButton_Click(object sender, RoutedEventArgs e)
        {
            MedicationsWindow medicationsWindow = new MedicationsWindow();
            medicationsWindow.Show();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.Show();
        }

        private void ProvidersButton_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow providersWindow = new ProvidersWindow();
            providersWindow.Show();
        }

        private void ContractsButton_Click(object sender, RoutedEventArgs e)
        {
            ContractsWindow contractsWindow = new ContractsWindow();
            contractsWindow.Show();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}