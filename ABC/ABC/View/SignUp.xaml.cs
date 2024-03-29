﻿using ABC.Model;
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
using System.Windows.Shapes;
using ABC.Helper;

namespace ABC.View
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window, IHavePassword
    {
        public SignUp()
        {
            InitializeComponent();
        }

        public System.Security.SecureString Password
        {
            get
            {
                return pswPass.SecurePassword;
            }
        }

        public System.Security.SecureString RePassword
        {
            get
            {
                return pswReEnter.SecurePassword;
            }
        }

        public System.Security.SecureString OldPassword
        {
            get
            {
                return pswPass.SecurePassword;
            }
        }
    }
}
