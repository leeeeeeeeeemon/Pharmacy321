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
    public partial class OrdersWindow : Window
    {
        public ObservableCollection<Order> Orders { get; set; }

        public OrdersWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadOrders();
        }

        private void LoadOrders()
        {
            using (var context = new AptekaContext())
            {
                Orders = new ObservableCollection<Order>(context.Order.ToList());
            }
        }
    }
}
