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
    /// Interaction logic for ThemThu.xaml
    /// </summary>
    public partial class ThemThu : Page
    {
        public ThemThu()
        {
            InitializeComponent();
        }
        private void btnCloseProgram_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }
    }
}
