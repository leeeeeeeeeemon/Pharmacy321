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
    public partial class ContractsWindow : Window
    {
        public ObservableCollection<Contract> Contracts { get; set; }

        public ContractsWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadContracts();
        }

        private void LoadContracts()
        {
            using (var context = new AptekaContext())
            {
                Contracts = new ObservableCollection<Contract>(context.Contract.ToList());
            }
        }
    }
}
