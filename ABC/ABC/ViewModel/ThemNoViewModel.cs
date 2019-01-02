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
    public class ThemNoViewModel:BindableBase
    {
        public ThemNoViewModel()
        {

            onCancelCommand = new MyICommand(onCancel);
            onOKCommand = new MyICommand(onOk);
        }

        public MyICommand onOKCommand { get; private set; }
        public MyICommand onCancelCommand { get; private set; }

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
