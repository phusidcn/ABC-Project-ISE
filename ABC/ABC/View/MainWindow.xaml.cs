using ABC.Model;
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
            //frTrangChu.Content = new TrangChu();
        }

        //private void btnCloseProgram_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        //private void btnMinimizeProgram_Click(object sender, RoutedEventArgs e)
        //{
        //    this.WindowState = WindowState.Minimized;
        //}

        //private void frTrangChu_ContentRendered(object sender, EventArgs e)
        //{
        //    frTrangChu.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        //}

        //private void btnGiaoDich_Click(object sender, RoutedEventArgs e)
        //{
        //    frTrangChu.Content = null;
        //    frTrangChu.Content = new TrangChu();
        //}

        //private void btnGhiNo_Click(object sender, RoutedEventArgs e)
        //{
        //    frTrangChu.Content = null;
        //    frTrangChu.Content = new SoNo();
        //}

        //private void btnTietKiem_Click(object sender, RoutedEventArgs e)
        //{
        //    frTrangChu.Content = null;
        //    frTrangChu.Content = new TietKiem();
        //}

        //private void btnNhom_Click(object sender, RoutedEventArgs e)
        //{
        //    //frTrangChu.Content = null;
        //    //frTrangChu.Content = new NhomCanDung();

        //    //using (var context = new QLChiTieuEntities())
        //    //{
        //    //	List<User> users = context.Users.ToList();	

        //    //	foreach(User user in users)
        //    //	{
        //    //		MessageBox.Show(user.Ten);
        //    //	}
        //    //}
        //}

        //private void btnXuHuong_Click(object sender, RoutedEventArgs e)
        //{
        //    frTrangChu.Content = null;
        //    frTrangChu.Content = new XuHuong();
        //}

        //private void btnBieuDo_Click(object sender, RoutedEventArgs e)
        //{
        //    frTrangChu.Content = null;
        //    frTrangChu.Content = new BieuDo();
        //}

        //private void btnGiupDo_Click(object sender, RoutedEventArgs e)
        //{
        //    frTrangChu.Content = null;
        //    frTrangChu.Content = new GiupDo();
        //}

        //private void btnNganSach_Click(object sender, RoutedEventArgs e)
        //{
        //    frTrangChu.Content = null;
        //    frTrangChu.Content = new NganSach();
        //}
    
    }
}
