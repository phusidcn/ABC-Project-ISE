using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using ABC.Helper;
using ABC.Model;
using System.Windows;
namespace ABC.ViewModel
{
    public class ThemViViewModel:BindableBase
    {

        public ThemViViewModel()
        {
            usId = ABC.ViewModel.MainWindowViewModel.userID;
            OkCommand = new MyICommand(onOk);
            CancelCommand = new MyICommand(onCancel);
        }
        #region Properties
        private int _usId;
        public int usId
        {
            get { return _usId; }
            set { SetProperty(ref _usId, value); }
        }
        private int _soTienVi;
        public int soTienVi
        {
            get { return _soTienVi; }
            set { SetProperty(ref _soTienVi, value); }
        }

        private string _tenVi;
        public string tenVi
        {
            get { return _tenVi; }
            set { SetProperty(ref _tenVi, value); }
        }
        #endregion

        #region Command
        public MyICommand OkCommand { get; private set; }
        public MyICommand CancelCommand { get; private set; }

        void onOk()
        {
            try
            {
                using (var db = new QLChiTieuEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));
                    db.uspThemVi(usId, tenVi, soTienVi, responseMessage);
                    DialogHost.CloseDialogCommand.Execute((bool)true, null);
                    MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
                }
            }
            catch (Exception e)
            {
                DialogHost.CloseDialogCommand.Execute((bool)true, null);
                MessageBox.Show(e.Message, "Notification", MessageBoxButton.OK);
            }
        }

        void onCancel()
        {
            DialogHost.CloseDialogCommand.Execute((bool)true, null);
        }
        #endregion
    }
}
