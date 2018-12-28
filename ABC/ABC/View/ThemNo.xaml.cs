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
    /// Interaction logic for ThemNo.xaml
    /// </summary>
    public partial class ThemNo : Page
    {
        public ThemNo()
        {
            InitializeComponent();
        }
        private void btnCloseProgram_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }
    }
}
