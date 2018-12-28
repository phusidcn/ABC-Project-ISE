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
    /// Interaction logic for HomePageMinisize.xaml
    /// </summary>
    public partial class SoNo : Page
    {
        public SoNo()
        {
            InitializeComponent();
        }
        private void btnThemNguoiNo_Click(object sender, RoutedEventArgs e)
        {
            frSoNo.Content = null;
            frSoNo.Content = new ThemThu();
        }

        private void btnThemNoNguoi_Click(object sender, RoutedEventArgs e)
        {
            frSoNo.Content = null;
            frSoNo.Content = new ThemNo();
        }

        private void frSoNo_ContentRendered(object sender, EventArgs e)
        {
            frSoNo.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
    }
}
