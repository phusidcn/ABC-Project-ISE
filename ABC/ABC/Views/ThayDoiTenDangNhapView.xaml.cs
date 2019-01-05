using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;
using ABC.Helper;


namespace ABC.Views
{
    /// <summary>
    /// Interaction logic for ThayDoiTenDangNhapView.xaml
    /// </summary>
    public partial class ThayDoiTenDangNhapView : UserControl, IHavePassword
    {
        public ThayDoiTenDangNhapView()
        {
            InitializeComponent();
        }

        public System.Security.SecureString Password
        {
            get
            {
                return pswValidate.SecurePassword;
            }
        }

        public System.Security.SecureString RePassword
        {
            get
            {
                return pswValidate.SecurePassword;
            }
        }

        public System.Security.SecureString OldPassword
        {
            get
            {
                return pswValidate.SecurePassword;
            }
        }
    }

}
