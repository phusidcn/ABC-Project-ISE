using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaterialDesignThemes.Wpf;
using ABC.Commands;

namespace ABC.ViewModel
{
    class ThemTietKiemViewModel:BindableBase
    {
        public ThemTietKiemViewModel()
        {
            cancelCommand = new MyICommand(onCancel);
            okCommand = new MyICommand(onOk);
        }


        public MyICommand cancelCommand { get; private set; }
        public MyICommand okCommand { get; private set; }


        void onCancel()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        void onOk()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
    }
}
