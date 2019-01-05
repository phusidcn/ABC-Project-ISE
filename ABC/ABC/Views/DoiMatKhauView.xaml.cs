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
using ABC.Helper;

namespace ABC.Views
{
    /// <summary>
    /// Interaction logic for DoiMatKhauView.xaml
    /// </summary>
    public partial class DoiMatKhauView : UserControl, IHavePassword
    {
        public DoiMatKhauView()
        {
            InitializeComponent();
        }

        public System.Security.SecureString Password
        {
            get
            {
                return pswNewPass.SecurePassword;
            }
        }

        public System.Security.SecureString RePassword
        {
            get
            {
                return pswCheck.SecurePassword;
            }
        }

        public System.Security.SecureString OldPassword
        {
            get
            {
                return pswOldPass.SecurePassword;
            }
        }
    }
}
