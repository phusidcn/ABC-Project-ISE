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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frTrangChu.Content = new TrangChu();
        }

        private void btnCloseProgram_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimizeProgram_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void frTrangChu_ContentRendered(object sender, EventArgs e)
        {
            frTrangChu.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void btnGiaoDich_Click(object sender, RoutedEventArgs e)
        {
            frTrangChu.Content = null;
            frTrangChu.Content = new TrangChu();
        }

        private void btnGhiNo_Click(object sender, RoutedEventArgs e)
        {
            frTrangChu.Content = null;
            frTrangChu.Content = new SoNo();
        }

        private void btnTietKiem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNhom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnXuHuong_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBieuDo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGiupDo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNganSach_Click(object sender, RoutedEventArgs e)
        {

        }
    
    }
}
