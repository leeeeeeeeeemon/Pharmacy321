using Pharmacy321.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy321
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavFrame.Navigated += Frame_Navigated;
            NavFrame.NavigationService.Navigate(new smth());
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var pageContent = NavFrame.Content;
            

        }
    }
}