using ABC;
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

namespace ABC
{
    /// <summary>
    /// Interaction logic for HomePageMaximumsize.xaml
    /// </summary>
    public partial class HomePageMaximumsize : Page
    {
        public HomePageMaximumsize()
        {
            InitializeComponent();
        }

        private void frNotification_ContentRendered(object sender, EventArgs e)
        {
            frNotification.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void btnNotification_Click(object sender, RoutedEventArgs e)
        {
            frNotification.Content = new NotificationMaximumsize();
        }

        private void btnAddDeal_Click(object sender, RoutedEventArgs e)
        {
            frNotification.Content = new addDealMaximumsize();
        }

        private void btnExchange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInterval_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewByDay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewByGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnComeBackThisMonth_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
