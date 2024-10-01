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
          
            LoadContractsGrid();
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

        }

        private void CreateContractButton_Click(object sender, RoutedEventArgs e)
        {
            string Nomer_Dogovota = Nomer_DogovotaTextBox.Text;

            if (string.IsNullOrWhiteSpace(Nomer_Dogovota))
            {
                MessageBox.Show("Пожалуйста, введите описание договора.");
                return;
            }

            database.CreateContract(Nomer_Dogovota); // Создание договора в БД
            MessageBox.Show("Договор создан успешно!");

            // Очистка полей после добавления
            Nomer_DogovotaTextBox.Clear();

            LoadContractsGrid(); // Обновление списка договоров
        }

    }
}
