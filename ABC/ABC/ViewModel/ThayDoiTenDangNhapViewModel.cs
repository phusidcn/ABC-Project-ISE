using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using MaterialDesignThemes.Wpf;
using ABC.Model;
using System.Windows;

namespace ABC.ViewModel
{


    public class ThayDoiTenDangNhapViewModel : BindableBase
    {
        int userID = ABC.ViewModel.MainWindowViewModel.userID;
        public ThayDoiTenDangNhapViewModel()
        {
            SaveCommand = new MyICommand<object>(OnSave);
            CancelCommand = new MyICommand(OnCancel);
        }

        #region Properties
        private string _newUserName;
        public string newUserName
        {
            get { return _newUserName; }
            set { SetProperty(ref _newUserName, value); }
        }

        private string _passWord;
        public string passWord
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }
        }
        #endregion

        #region Command
        public MyICommand<object> SaveCommand { get; private set; }
        public MyICommand CancelCommand { get; private set; }

        void OnSave(object parameter)
        {
            var container = parameter as IHavePassword;
            if (container != null)
            {
                var secureString = container.Password;
                passWord = ConvertToUnsecureString(secureString);
                /// doi ten tai khoan
                /// 
                using (var db = new QLChiTieuEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));
                    db.uspModifyUserName(userID, passWord, newUserName, responseMessage);
                    MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
                }
            }
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        void OnCancel()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
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
        #endregion

    }
}
