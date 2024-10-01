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
        private int? SelectedClientId; // Для хранения ID клиента
        private int? SelectedSpecialistId; // Для хранения ID специалиста
        private int? SelectedContractId; // Для хранения ID договора


        public SpecialistWindow()
        {
            InitializeComponent();
            database = new Database();
            //LoadClients();
            LoadSpecialists();
            LoadClientsGrid();
            LoadContracts();
        }


        protected void LoadSpecialists()
        {
    
            DataTable specialists = database.GetSpecialists();


            SpecialistsComboBox.ItemsSource = specialists.DefaultView;


            SpecialistsComboBox.DisplayMemberPath = "FullNameAndPosition"; 
            SpecialistsComboBox.SelectedValuePath = "ID_Sotrudnic"; 
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {

            string FName = FNameTextBox.Text;
            string Name = NameTextBox.Text;
            string Othestvo = OthestvoTextBox.Text;
            string Pochta = PochtaTextBox.Text;
            string Telefon = TelefonTextBox.Text;
            string Skidka = (SkidkaComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();



            database.AddClient(FName, Name, Othestvo, Pochta, Telefon, Skidka);
            MessageBox.Show("Клиент добавлен успешно!");

            // Очистка полей после добавления
            FNameTextBox.Clear();
            NameTextBox.Clear();
            OthestvoTextBox.Clear();
            PochtaTextBox.Clear();
            TelefonTextBox.Clear();
            SkidkaComboBox.SelectedIndex = -1;
        }

        private void RecordAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!SelectedClientId.HasValue ||
                !SelectedSpecialistId.HasValue ||
                !SelectedContractId.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите клиента, специалиста и договор.");
                return;
            }

            database.RecordAppointment(SelectedClientId.Value, SelectedSpecialistId.Value, SelectedContractId.Value);
            MessageBox.Show("Запись на прием выполнена успешно!");
        }





        private void LoadClientsGrid()
{
    var clients = database.GetClients(); 
    ClientsDataGrid.ItemsSource = clients.DefaultView; 
}

        private void ClientsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = ClientsTextBox.Text.ToLower(); 
            if (string.IsNullOrWhiteSpace(input))
            {
                ClientsListBox.Visibility = Visibility.Collapsed;
                return;
            }

            DataTable clients = database.GetClients();
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
                ClientsTextBox.Text = (selectedClient as dynamic).FullName;
                ClientsListBox.Visibility = Visibility.Collapsed;

                // Сохранение ID клиента для использования при записи
                SelectedClientId = (selectedClient as dynamic).ID; // добавьте переменную SelectedClientId в класс
            }
        }

        private void LoadContracts()
        {
            DataTable contracts = database.GetContracts(); // Получаем контракты
            ContractsComboBox.ItemsSource = contracts.DefaultView;
            ContractsComboBox.DisplayMemberPath = "Nomer_Dogovota"; // Отображаем номер договора
            ContractsComboBox.SelectedValuePath = "ID_Dogovora"; // Используем ID_Dogovora как значение
        }

        private void SpecialistsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SpecialistsComboBox.SelectedItem != null)
            {
                SelectedSpecialistId = (int)SpecialistsComboBox.SelectedValue; // Получаем ID_Sotudnica
            }
        }

        private void ContractsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContractsComboBox.SelectedItem != null)
            {
                SelectedContractId = (int)ContractsComboBox.SelectedValue; // Получаем ID_Dogovora
            }
        }
    }
}