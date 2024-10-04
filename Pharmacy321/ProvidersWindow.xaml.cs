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
    public partial class ProvidersWindow : Window
    {
        public ObservableCollection<Provider> Providers { get; set; }

        public ProvidersWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadProviders();
        }

        private void LoadProviders()
        {
            using (var context = new AptekaContext())
            {
                Providers = new ObservableCollection<Provider>(context.Provider.ToList());
            }
        }
    }
}
