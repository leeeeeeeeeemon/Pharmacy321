using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MedicationsWindow : Window
    {
        public ObservableCollection<Medication> Medications { get; set; }

        public MedicationsWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadMedications();
        }

        private void LoadMedications()
        {
            using (var context = new AptekaContext())
            {
                Medications = new ObservableCollection<Medication>(context.Medication.ToList());
            }
        }
    }
}
