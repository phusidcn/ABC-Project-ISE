using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Commands;

namespace ABC.ViewModel
{
    public class GhiNoViewModel:BindableBase
    {
        public GhiNoViewModel()
        {
            themKhoanVayCommand = new MyICommand(themVay);
            themKhoanChoVayCommand = new MyICommand(themChoVay);
        }

        //Command
        #region Child View
        private ThemNoViewModel themKhoanVayVM = new ThemNoViewModel();
        private ThemThuViewModel themKhoanThuNoVM = new ThemThuViewModel();

        private BindableBase _themKhoanGhi;

        public BindableBase themKhoanGhi
        {
            get { return _themKhoanGhi; }
            set { SetProperty(ref _themKhoanGhi, value); }
        }

        private bool _isAddDialogOpen;

        public bool IsAddDialogOpen
        {
            get { return _isAddDialogOpen; }
            set
            {
                if (_isAddDialogOpen == value) return;
                SetProperty(ref _isAddDialogOpen, value);
            }
        }
        public MyICommand themKhoanChoVayCommand { get; private set; }
        public MyICommand themKhoanVayCommand { get; private set; }

        private void themVay()
        {
            themKhoanGhi = themKhoanVayVM;
            IsAddDialogOpen = true;
        }

        private void themChoVay()
        {
            themKhoanGhi = themKhoanThuNoVM;
            IsAddDialogOpen = true;
        }

        #endregion
    }
}
