using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ABC.Commands;
using MaterialDesignThemes.Wpf;

namespace ABC.ViewModel
{
    public class ThemThuViewModel:BindableBase
    {
        public ThemThuViewModel()
        {
            okCommand = new MyICommand(onOk);
            cancelCommand = new MyICommand(onCancel);
        }
        public MyICommand okCommand { get; private set; }
        public MyICommand cancelCommand { get; private set; }

        void onOk()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        void onCancel()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
    }
}
