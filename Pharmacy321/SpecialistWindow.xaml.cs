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

namespace Pharmacy321
{
    public partial class SpecialistWindow : Window
    {
        private Database database;

        public SpecialistWindow()
        {
            InitializeComponent();
            database = new Database();
            LoadClients();
            LoadSpecialists();
        }

        private void LoadClients()
        {
            // Загрузка клиентов в ComboBox
            ClientsComboBox.ItemsSource = database.GetClients().DefaultView; // Убедитесь, что это возвращает нужные данные
        }

        private void LoadSpecialists()
        {
            // Загрузка специалистов в ComboBox
            // Например, если у вас есть таблица специалистов, загрузите их оттуда
            SpecialistsComboBox.ItemsSource = new List<string> { "Специалист 1", "Специалист 2", "Специалист 3" }; // Замените на реальных специалистов
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            // Считывание данных из текстовых полей
            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string middleName = MiddleNameTextBox.Text;
            string email = EmailTextBox.Text;
            string phone = PhoneTextBox.Text;
            string discount = DiscountTextBox.Text;

            // Добавление клиента в базу данных
            database.AddClient(lastName, firstName, middleName, email, phone, discount);
            MessageBox.Show("Клиент добавлен успешно!");

            // Очистка полей после добавления
            LastNameTextBox.Clear();
            FirstNameTextBox.Clear();
            MiddleNameTextBox.Clear();
            EmailTextBox.Clear();
            PhoneTextBox.Clear();
            DiscountTextBox.Clear();
        }

        private void RecordAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика записи клиента на прием
            string selectedClient = ClientsComboBox.SelectedItem.ToString();
            string selectedSpecialist = SpecialistsComboBox.SelectedItem.ToString();

            // Здесь должна быть логика для записи на прием в базу данных
            database.RecordAppointment(selectedClient, selectedSpecialist);
            MessageBox.Show("Запись на прием выполнена успешно!");
        }
    }
}