using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using MaterialDesignThemes.Wpf;

namespace ABC.ViewModel
{
    public class TietKiemViewModel : BindableBase
    {

        public TietKiemViewModel()
        {
            themTietKiem = new MyICommand(OnClick);
        }

        #region Content
        private ThemTietKiemViewModel themTietKiemViewModel = new ThemTietKiemViewModel();
        private BindableBase _addView;

        public BindableBase addView
        {
            get { return _addView; }
            set { SetProperty(ref _addView, value); }
        }
        #endregion

        #region Popup Command
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
        public MyICommand themTietKiem { get; private set; }

        private void OnClick()
        {
            addView = themTietKiemViewModel;
            IsAddDialogOpen = true;
        }

        #endregion
    }
}
