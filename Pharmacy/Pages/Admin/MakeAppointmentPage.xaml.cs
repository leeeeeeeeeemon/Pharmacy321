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

    public partial class MakeAppointmentPage : Page
    {
        private List<Klient> clients;
        private List<Sotrudnik> doctors;
        private List<Zapis_priem> appointments;

        public MakeAppointmentPage()
        {
            InitializeComponent();
            LoadClients();
            LoadDoctors();
            LoadAppointments();
        }

        private void LoadClients()
        {
            clients = DBManager.GetClients();
            ClientComboBox.ItemsSource = clients;
        }

        private void LoadDoctors()
        {
            doctors = DBManager.GetStaff();
            DoctorComboBox.ItemsSource = doctors.Where(d => d.Doljnost == "Окулист" || d.Doljnost == "Ортопед");
        }

        private void LoadAppointments()
        {
            appointments = DBManager.GetAppointments();
        }

        private bool isUserInitiated = true;
        private void AppointmentDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isUserInitiated) return;

            if (DoctorComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите врача!", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (AppointmentDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату!", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (AppointmentDatePicker.SelectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Нельзя выбрать прошедшую дату.", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                AppointmentTimeComboBox.SelectedItem = null;
                return;
            }

            LoadAppointments();

            var doctor = (Sotrudnik)DoctorComboBox.SelectedItem;
            var date = AppointmentDatePicker.SelectedDate.Value;

            var availableTimes = new List<string>
            {
                "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00"
            };

            var bookedTimes = appointments
                .Where(a => a.Id_sotrudnik == doctor.Id && a.Datetime.Value.Date == date.Date)
                .Select(a => a.Datetime.Value.TimeOfDay.ToString(@"hh\:mm"))
                .ToList();

            availableTimes = availableTimes.Except(bookedTimes).ToList();

            isUserInitiated = false;
            AppointmentTimeComboBox.ItemsSource = availableTimes.Select(t => new ComboBoxItem { Content = t }).ToList();
            AppointmentTimeComboBox.SelectedItem = null;
        }

        private void AppointmentTimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isUserInitiated) return;

            if (AppointmentDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату!");
                isUserInitiated = false;
                AppointmentTimeComboBox.SelectedItem = null;
            }
        }

        private void OnMakeAppointmentClick(object sender, RoutedEventArgs e)
        {
            if (ClientComboBox.SelectedItem == null || DoctorComboBox.SelectedItem == null || AppointmentDatePicker.SelectedDate == null || AppointmentTimeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (AppointmentDatePicker.SelectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Нельзя выбрать прошедшую дату.", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var client = (Klient)ClientComboBox.SelectedItem;
            var doctor = (Sotrudnik)DoctorComboBox.SelectedItem;
            var date = AppointmentDatePicker.SelectedDate.Value;
            var time = (ComboBoxItem)AppointmentTimeComboBox.SelectedItem;
            var appointmentDateTime = date.Date + TimeSpan.Parse(time.Content.ToString());

            foreach (var a in appointments)
            {
                if (a.Id_sotrudnik == doctor.Id && a.Datetime == appointmentDateTime)
                {
                    MessageBox.Show("Это время уже занято.", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            var appointment = new Zapis_priem
            {
                Datetime = appointmentDateTime,
                Id_klient = client.Id,
                Id_sotrudnik = doctor.Id,
                Date_oformlenia = DateTime.Now,
            };

            DBManager.MakeAppointment(appointment);

            MessageBox.Show("Успех!", "Запись на прием", MessageBoxButton.OK, MessageBoxImage.Information);

            ClientComboBox.SelectedItem = null;
            DoctorComboBox.SelectedItem = null;
            AppointmentDatePicker.SelectedDate = null;
            AppointmentTimeComboBox.SelectedItem = null;
            isUserInitiated = true;
        }
    }
}
