using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using ABC.Model;

namespace ABC.ViewModel
{
    public class TaiKhoanViewModel : BindableBase
    {
        public TaiKhoanViewModel()
        {
            int id = ABC.ViewModel.MainWindowViewModel.userID;
            using(var db = new QLChiTieuEntities())
            {
                SelectedUser = db.Users.Find(id);
            }
            
            OpenChangePassDialogCommand = new MyICommand<object>(OpenChangePassDialog);
            OpenChangeUserNameDialogCommand = new MyICommand<object>(OpenChangeUserNameDialog);
        }

        #region Properties
        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set { SetProperty(ref _selectedUser, value); }
        }
        #endregion

        #region child view
        private ThayDoiTenDangNhapViewModel doiTenVM = new ThayDoiTenDangNhapViewModel();
        private DoiMatKhauViewModel doiMkVM = new DoiMatKhauViewModel();
        #endregion

        #region add Child view
        //pretty much ignore all the stuff provided, and manage everything via custom commands and a binding for .IsOpen
        public MyICommand<object> OpenChangeUserNameDialogCommand { get; private set; }
        public MyICommand<object> OpenChangePassDialogCommand { get; private set; }
        private bool _isAddDialogOpen;
        private BindableBase _addContent;

        public bool IsAddDialogOpen
        {
            get { return _isAddDialogOpen; }
            set
            {
                if (_isAddDialogOpen == value) return;
                SetProperty(ref _isAddDialogOpen, value);
            }
        }

        public BindableBase AddContent
        {
            get { return _addContent; }
            set
            {
                if (_addContent == value) return;
                SetProperty(ref _addContent, value);
            }
        }

        private void OpenChangeUserNameDialog(object obj)
        {
            AddContent = doiTenVM;
            IsAddDialogOpen = true;
        }

        private void OpenChangePassDialog(object obj)
        {
            AddContent = doiMkVM;
            IsAddDialogOpen = true;
        }
        #endregion
    }
}
