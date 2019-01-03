using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using MaterialDesignThemes.Wpf;

namespace ABC.ViewModel
{
    public class ThayDoiTenDangNhapViewModel : BindableBase
    {
        public ThayDoiTenDangNhapViewModel()
        {
            SaveCommand = new MyICommand(OnSave);
            CancelCommand = new MyICommand(OnCancel);
        }

        #region Command
        public MyICommand SaveCommand { get; private set; }
        public MyICommand CancelCommand { get; private set; }

        void OnSave()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        void OnCancel()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
        #endregion

    }
}
