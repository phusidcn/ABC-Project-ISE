using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;

namespace ABC.ViewModel
{
    public class ThemGiaoDichViewModel : BindableBase
    {
        public ThemGiaoDichViewModel()
        {
            CancelCommand = new MyICommand(onCancel);
            OkCommand = new MyICommand(onOk);
        }
        public MyICommand CancelCommand { get; private set; }
        public MyICommand OkCommand { get; private set; }

        void onCancel()
        {
            DialogHost.CloseDialogCommand.Execute((bool)false, null);
        }

        void onOk()
        {
            DialogHost.CloseDialogCommand.Execute((bool)true, null);
        }
    }
}
