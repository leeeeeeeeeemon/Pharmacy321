using Pharmacy.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy.Pages.Admin
{
    public partial class RegisterClientPage : Page
    {
        public RegisterClientPage()
        {
            InitializeComponent();
        }

        private void OnRegisterClientClick(object sender, RoutedEventArgs e)
        {
            string surname = SurnameTextBox.Text;
            string name = NameTextBox.Text;
            string patronymic = PatronymicTextBox.Text;
            string phone = PhoneTextBox.Text;
            string email = EmailTextBox.Text;
            string skidka = SkidkaTextBox.Text;

            try
            {
                var newClient = new Klient
                {
                    Surname = surname,
                    Name = name,
                    Patronymic = String.IsNullOrEmpty(patronymic) ? "" : patronymic,
                    Phone = phone,
                    Email = email,
                    Skidka = String.IsNullOrEmpty(skidka) ? 0 : Convert.ToDecimal(skidka),
                };
                DBManager.AddClient(newClient);
                MessageBox.Show("Успех!", "Регистрация клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                PatronymicTextBox.Text = "";
                PhoneTextBox.Text = "";
                EmailTextBox.Text = "";
                SkidkaTextBox.Text = "";
            } catch
            {
                MessageBox.Show("Проверьте корректность заполнения полей!", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
            }          
        }
    }
}
