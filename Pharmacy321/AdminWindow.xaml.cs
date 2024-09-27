using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Pharmacy321
{
    public partial class AdminWindow : Window
    {
        private Database database;

        public AdminWindow()
        {
            InitializeComponent();
            database = new Database();
            LoadEmployeesGrid();
            LoadContractsGrid();
        }

        private void LoadEmployeesGrid()
        {
            DataTable employees = database.GetEmployees(); // Метод для получения сотрудников из БД
            EmployeesDataGrid.ItemsSource = employees.DefaultView;
        }

        private void LoadContractsGrid()
        {
            DataTable contracts = database.GetContracts(); // Метод для получения договоров из БД
            ContractsDataGrid.ItemsSource = contracts.DefaultView;
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string FName = FNameTextBox.Text;
            string Name = NameTextBox.Text;
            string Othestvo = OthestvoTextBox.Text;
            string Doljnost = DoljnostTextBox.Text;

            database.AddEmployee(FName, Name, Othestvo, Doljnost); // Метод для добавления сотрудника в БД
            MessageBox.Show("Сотрудник добавлен успешно!");

            // Очистка полей после добавления
            FNameTextBox.Clear();
            NameTextBox.Clear();
            OthestvoTextBox.Clear();
            DoljnostTextBox.Clear();

            LoadEmployeesGrid(); // Обновление списка сотрудников
        }

        private void CreateContractButton_Click(object sender, RoutedEventArgs e)
        {
            int employeeId = int.Parse(EmployeeIdTextBox.Text);
            string description = DogovorDescriptionTextBox.Text;

            database.CreateContract(employeeId, description); // Метод для создания договора в БД
            MessageBox.Show("Договор создан успешно!");

            // Очистка полей после добавления
            EmployeeIdTextBox.Clear();
            DogovorDescriptionTextBox.Clear();

            LoadContractsGrid(); // Обновление списка договоров
        }
    }
}
