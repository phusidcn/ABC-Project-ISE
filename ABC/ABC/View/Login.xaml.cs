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
using System.Windows.Shapes;

namespace ABC
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

		private void btnCloseLogin_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void btnMinimizeLogin_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		

		private void BtnLogin_Click(object sender, RoutedEventArgs e)
		{

            string username = txtUserName.Text;
            string password = pswPassword.Password;
			using (var context = new QLChiTieuEntities())
			{
				System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));

				context.uspLogin(username, password, responseMessage);

				MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
				//Console.WriteLine(responseMessage.ToString());
			}
		}

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window signup = new View.SignUp();
            signup.Show();
        }
    }
}
