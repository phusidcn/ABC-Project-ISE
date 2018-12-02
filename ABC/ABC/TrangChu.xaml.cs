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
    public partial class TrangChu : Page
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void frTrangChu_ContentRendered(object sender, EventArgs e)
        {
            frTrangChu.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

        }

        private void btnTienMat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThemVi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThemGiaoDich_Click(object sender, RoutedEventArgs e)
        {
            frTrangChu.Content = null;
            frTrangChu.Content = new ThemGiaoDich();
        }

        private void btnChuyenTien_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThongBao_Click(object sender, RoutedEventArgs e)
        {
            frTrangChu.Content = null;
            frTrangChu.Content = new ThongBao();
        }

        private void btnChonKhoangThoiGian_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnXemTheoNgay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnXemTheoNhom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnQuayLaiThangNay_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
