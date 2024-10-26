using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Pharmacy.Data;

namespace Pharmacy.Pages.Admin
{
    public partial class MedicinesPage : Page
    {
        private List<Preparat> _medicines;

        public MedicinesPage()
        {
            InitializeComponent();
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            _medicines = DBManager.GetMedicines();
            MedicinesDataGrid.ItemsSource = _medicines;
        }
    }
}