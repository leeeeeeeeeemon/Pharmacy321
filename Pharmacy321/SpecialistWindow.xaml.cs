using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Xml.Linq;

namespace Pharmacy321
{
    public partial class SpecialistWindow : Window
    {
        private Database database;

        public SpecialistWindow()
        {
            InitializeComponent();
            database = new Database();
            //LoadClients();
            LoadSpecialists();
            LoadClientsGrid();
        }

        //private void LoadClients()
        //{
        //    // Загрузка клиентов в ComboBox
        //    ClientsComboBox.ItemsSource = database.GetClients().DefaultView; // Убедитесь, что это возвращает нужные данные
        //}

        private void LoadSpecialists()
        {
            // Загрузка специалистов в ComboBox
            // Например, если у вас есть таблица специалистов, загрузите их оттуда
            SpecialistsComboBox.ItemsSource = new List<string> { "Специалист 1", "Специалист 2", "Специалист 3" }; // Замените на реальных специалистов
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            // Считывание данных из текстовых полей
            string FName = FNameTextBox.Text;
            string Name = NameTextBox.Text;
            string Othestvo = OthestvoTextBox.Text;
            string Pochta = PochtaTextBox.Text;
            string Telefon = TelefonTextBox.Text;
            string Skidka = SkidkaTextBox.Text;

            // Добавление клиента в базу данных
            database.AddClient(FName, Name, Othestvo, Pochta, Telefon, Skidka);
            MessageBox.Show("Клиент добавлен успешно!");

            // Очистка полей после добавления
            FNameTextBox.Clear();
            NameTextBox.Clear();
            OthestvoTextBox.Clear();
            PochtaTextBox.Clear();
            TelefonTextBox.Clear();
            SkidkaTextBox.Clear();
        }

        private void RecordAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика записи клиента на прием
            string selectedClient = ClientsTextBox.Text.ToLower();
            string selectedSpecialist = SpecialistsComboBox.SelectedItem.ToString();

            // Здесь должна быть логика для записи на прием в базу данных
            database.RecordAppointment(selectedClient, selectedSpecialist);
            MessageBox.Show("Запись на прием выполнена успешно!");
        }

        private void LoadClientsGrid()
        {
            // Загрузка клиентов в DataGrid
            var clients = database.GetClients(); // Убедитесь, что этот метод возвращает нужные данные
            ClientsDataGrid.ItemsSource = clients.DefaultView; // Здесь нет ошибки, так как метод GetClients() используется из объекта database
        }
        private void ClientsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = ClientsTextBox.Text.ToLower(); // Приведение к нижнему регистру для простоты поиска
            if (string.IsNullOrWhiteSpace(input))
            {
                ClientsListBox.Visibility = Visibility.Collapsed;
                return;
            }

            DataTable clients = database.GetClients(); // Получаем всех клиентов из базы данных
            var filteredClients = clients.AsEnumerable()
                .Where(row => row.Field<string>("FName").ToLower().StartsWith(input) || row.Field<string>("Name").ToLower().StartsWith(input))
                .Select(row => new
                {
                    ID = row.Field<int>("ID_Klient"),
                    FullName = $"{row.Field<string>("FName")} {row.Field<string>("Name")}"
                })
                .ToList();

            if (filteredClients.Any())
            {
                ClientsListBox.ItemsSource = filteredClients;
                ClientsListBox.DisplayMemberPath = "FullName";
                ClientsListBox.SelectedValuePath = "ID";
                ClientsListBox.Visibility = Visibility.Visible;
            }
            else
            {
                ClientsListBox.Visibility = Visibility.Collapsed;
            }
        }

        private void ClientsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientsListBox.SelectedItem != null)
            {
                var selectedClient = ClientsListBox.SelectedItem;
                ClientsTextBox.Text = (selectedClient as dynamic).FullName; // Заполнение текстового поля выбранным клиентом
                ClientsListBox.Visibility = Visibility.Collapsed;
            }
        }

    }
}