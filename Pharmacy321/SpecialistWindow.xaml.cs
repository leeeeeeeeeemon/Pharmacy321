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


        private void LoadSpecialists()
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
           
            string selectedClient = ClientsTextBox.Text.ToLower();
            string selectedSpecialist = SpecialistsComboBox.SelectedItem.ToString();

            
            database.RecordAppointment(selectedClient, selectedSpecialist);
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
            }
        }
        //private void TelefonTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    var textBox = sender as TextBox;
        //    if (textBox != null)
        //    {
        //        int cursorPosition = textBox.SelectionStart;
        //        string currentText = textBox.Text;

        //        if (!char.IsDigit(e.Text[0]))
        //        {
        //            e.Handled = true; // Блокируем ввод, если это не цифра
        //            return;
        //        }

        //        // Формат телефона +7(___) ___-__-__
        //        if (currentText.Length < 16)
        //        {
        //            currentText = ApplyPhoneMask(currentText, e.Text);
        //            textBox.Text = currentText;
        //            textBox.SelectionStart = cursorPosition + 1; // Обновляем позицию курсора
        //            e.Handled = true; // Блокируем дальнейший ввод, так как мы уже обработали текст
        //        }
        //    }
        //}

        //private string ApplyPhoneMask(string text, string newText)
        //{
        //    // Удаляем нецифровые символы из текущего текста
        //    string digits = new string(text.Where(char.IsDigit).ToArray()) + newText;
        //    string formattedText = "+7(";

        //    if (digits.Length > 1) formattedText += digits.Substring(1, Math.Min(3, digits.Length - 1));
        //    if (digits.Length > 4) formattedText += ") " + digits.Substring(4, Math.Min(3, digits.Length - 4));
        //    if (digits.Length > 7) formattedText += "-" + digits.Substring(7, Math.Min(2, digits.Length - 7));
        //    if (digits.Length > 9) formattedText += "-" + digits.Substring(9, Math.Min(2, digits.Length - 9));

        //    return formattedText;
        //}
    }
}