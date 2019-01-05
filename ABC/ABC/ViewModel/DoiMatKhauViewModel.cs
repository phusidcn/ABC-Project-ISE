using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using MaterialDesignThemes.Wpf;
using ABC.Helper;
using ABC.Model;

namespace ABC.ViewModel
{
    public class DoiMatKhauViewModel:BindableBase
    {
        int id = ABC.ViewModel.MainWindowViewModel.userID;
        public DoiMatKhauViewModel()
        {
            SaveCommand = new MyICommand<object>(OnSave);
            CancelCommand = new MyICommand(OnCancel);
        }

        #region Command
        public MyICommand<object> SaveCommand { get; private set; }
        public MyICommand CancelCommand { get; private set; }

        void OnSave(object parameter)
        {
            var passWordContainer = parameter as IHavePassword;
            if (passWordContainer != null)
            {
                var newPassword = passWordContainer.Password;
                var reEnterPassword = passWordContainer.RePassword;
                string nPass = ConvertToUnsecureString(newPassword);
                string rePass = ConvertToUnsecureString(reEnterPassword);

                if (nPass == rePass)
                {
                   
                    using(var db = new QLChiTieuEntities()){
                        System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));

                        db.uspModifyPassWord(pId: id, nPassword: nPass, responseMessage: responseMessage);

                        if (responseMessage != null)
                        {
                            MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
                            DialogHost.CloseDialogCommand.Execute(null, null);
                        }
                    }
                }
            }
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
