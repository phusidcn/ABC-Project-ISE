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

namespace ABC.View
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void BtnCloseSignUp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Window turnback = new Login();
            turnback.Show();
        }

        private void BtnMinimizeSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (pswPass.Password != pswReEnter.Password)
            {
                MessageBox.Show("Password are not valid", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }
            System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));
            using (var context = new QLChiTieuEntities())
            {
                //Create new user

                User newUser = new User();
                newUser.Ten = txtUserName.Text;
                context.Users.Add(newUser);
                try
                {
                    var birthday = txtBirthDay.Text;
                    var DateOfBirth = Convert.ToDateTime(birthday);
                    context.uspAddUser(txtEmail.Text, pswPass.Password, txtUserName.Text, DateOfBirth, responseMessage);
                    MessageBox.Show("Your Account was created", "Notification", MessageBoxButton.OK,
                        MessageBoxImage.Information, MessageBoxResult.OK);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }


                //var DSUser = from user in context.Users
                //			 orderby user.ID descending
                //			 select user;

                //foreach (User us in DSUser)
                //{
                //	Console.WriteLine(us.Ten);
                //}


            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window turnback = new Login();
            turnback.Show();
        }
    }
}
