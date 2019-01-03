using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using MaterialDesignThemes.Wpf;


namespace ABC.ViewModel
{
    public class TrangChuViewModel : BindableBase
    {
        public TrangChuViewModel()
        {
            OpenAddDialogCommand = new MyICommand<object>(OpenAddDialog);
        }

        #region Child
        private ThemGiaoDichViewModel themGiaoDich = new ThemGiaoDichViewModel();
        #endregion

        #region them giao dich buttom
        //pretty much ignore all the stuff provided, and manage everything via custom commands and a binding for .IsOpen
        public MyICommand<object> OpenAddDialogCommand { get; private set; }

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

        private void OpenAddDialog(object obj)
        {
            AddContent = themGiaoDich;
            IsAddDialogOpen = true;
        }
        #endregion
    }
}
