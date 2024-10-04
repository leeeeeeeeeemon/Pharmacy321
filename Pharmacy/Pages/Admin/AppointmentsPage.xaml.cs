﻿using Pharmacy.Data;
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
    public partial class AppointmentsPage : Page
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            LoadAppointmentsData();
        }

        private void LoadAppointmentsData()
        {
            List<Zapis_priem> staffList = DBManager.GetAppointments();
            AppointmentsDataGrid.ItemsSource = staffList;
        }
    }
}
