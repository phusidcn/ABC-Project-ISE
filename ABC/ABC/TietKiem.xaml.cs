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
    /// Interaction logic for TietKiem.xaml
    /// </summary>
    public partial class TietKiem : Page
    {
        public TietKiem()
        {
            InitializeComponent();
        }

        private void btnThemTietKiem_Click(object sender, RoutedEventArgs e)
        {
            frTietKiem.Content = new ThemTietKiem();
        }

        private void frTietKiem_ContentRendered(object sender, EventArgs e)
        {
            frTietKiem.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
    }
}
