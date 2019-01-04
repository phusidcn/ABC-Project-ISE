using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using ABC.Helper;
using ABC.Model;

namespace ABC.ViewModel
{
    public class LoginViewModel:BindableBase
    {
        
        public LoginViewModel()
        {
            CurrentState  = WindowState.Normal;
            MinimizeCommand = new MyICommand(OnMinimizeCommand);
            CloseCommand = new MyICommand(OnCloseCommand);
            LoginCommand = new MyICommand<object>(OnLoginCommand);
            SignUpCommand = new MyICommand<object>(OnSignUpCommand);
        }
        
        private string successLogin = "User successfully logged in";
        private string incorrectPass = "Incorrect password";
        private string invalid = "Invalid login";

        #region Properties
        //Trang thai man hinh
        private WindowState _currentState;
        public WindowState CurrentState {
            get {return _currentState;}
            set {SetProperty(ref _currentState, value);}
        }
        // User properties
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string PassWord
        {
            get { return _password; }
            set {SetProperty(ref _password, value);}
        }
        #endregion

        #region Commands
        public MyICommand MinimizeCommand { get; private set; }
        public MyICommand CloseCommand { get; private set; }
        public MyICommand<object> LoginCommand { get; private set; }
        public MyICommand<object> SignUpCommand { get; private set; }

        public void OnMinimizeCommand()
        {
            CurrentState = WindowState.Minimized;
        }

        private void OnCloseCommand()
        {
            ABC.App.Current.Shutdown();
        }

        private void OnLoginCommand(object parameter)
        {
            var pwContainer = parameter as IHavePassword;
            if (pwContainer != null)
            {
                var secureString = pwContainer.Password;
                PassWord = ConvertToUnsecureString(secureString);
                var userN = UserName;

                using (var context = new QLChiTieuEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));

                    context.uspLogin(userN, PassWord, responseMessage);

                    MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
                    if (responseMessage.Value.ToString() == successLogin)
                    {
                        int id = GetCustomerIdByUserName(userN);
                        writeToSession(id);
                        Window main = new MainWindow();
                        ABC.ViewModel.MainWindowViewModel.userID = id;
                        main.Show();
                    }
                }
            }
        }

        private int GetCustomerIdByUserName(string usName)
        {
            using (var db = new QLChiTieuEntities())
            {
                var query = db.Users.Where(s => s.UserName == usName).First<User>();
                return query.ID;
            }
        }

        private void writeToSession(int id)
        {
            BinaryWriter bw;
            try
            {
                bw = new BinaryWriter(new FileStream("session", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            try
            {
                bw.Write(id);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            bw.Close();
        }

        private string ConvertToUnsecureString(System.Security.SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        } 

        private void OnSignUpCommand(object parameter)
        {
            var container = parameter as Window;
            if (container != null)
            {
                container.Visibility = Visibility.Hidden;
                Window signup = new View.SignUp();
                signup.Show();
            }
        }
        #endregion


    }
}
