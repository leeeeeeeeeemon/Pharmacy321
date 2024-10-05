using Pharmacy.Pages.Admin;
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

namespace Pharmacy.Windows
{
    public partial class AdminMain : Window
    {
        private Sotrudnik _currentEmployee;
        public AdminMain(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            _currentEmployee = sotrudnik;
            userName.Text = _currentEmployee.Surname + " " + _currentEmployee.Name;
            userProfession.Text = _currentEmployee.Doljnost;
            MainFrame.Navigate(new MainPage());

            if (sotrudnik.Doljnost == "Фармацевт")
            {
                AppointmentsTB.Visibility = Visibility.Collapsed;
                StaffTB.Visibility = Visibility.Collapsed;
                DeliveriesTB.Visibility = Visibility.Collapsed;
                EquipmentTB.Visibility = Visibility.Collapsed;
                DeliveriesTB.Visibility = Visibility.Collapsed;
                ReportsTB.Visibility = Visibility.Collapsed;
                ContractsTB.Visibility = Visibility.Collapsed;
            } else if (sotrudnik.Doljnost == "Окулист" || sotrudnik.Doljnost == "Ортопед")
            {
                StaffTB.Visibility = Visibility.Collapsed;
                DeliveriesTB.Visibility = Visibility.Collapsed;
                EquipmentTB.Visibility = Visibility.Collapsed;
                DeliveriesTB.Visibility = Visibility.Collapsed;
                ReportsTB.Visibility = Visibility.Collapsed;
                ContractsTB.Visibility = Visibility.Collapsed;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Window.GetWindow(this).Close();
        }

        private void Nav_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                switch (textBlock.Text)
                {
                    case "Главная":
                        MainFrame.Navigate(new MainPage());
                        break;
                    case "Записи к врачам":
                        MainFrame.Navigate(new AppointmentsPage());
                        break;
                    case "Сотрудники":
                        MainFrame.Navigate(new StaffPage());
                        break;
                    case "Поставщики":
                        MainFrame.Navigate(new DeliversPage());
                        break;
                    case "Оборудование":
                        MainFrame.Navigate(new EquipmentPage());
                        break;
                    case "Продажи":
                        MainFrame.Navigate(new SalesPage());
                        break;
                    case "Поставки":
                        MainFrame.Navigate(new DeliveriesPage());
                        break;
                    case "Лекарства":
                        MainFrame.Navigate(new MedicinesPage());
                        break;
                    case "Отчеты":
                        MainFrame.Navigate(new ReportsPage());
                        break;
                    case "Договоры":
                        MainFrame.Navigate(new ContractsPage());
                        break;
                    default:
                        MainFrame.Navigate(new MainPage());
                        break;
                }
            }
        }
    }
}