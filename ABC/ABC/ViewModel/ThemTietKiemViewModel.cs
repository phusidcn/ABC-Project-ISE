using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Commands;

namespace ABC.ViewModel
{
    class ThemTietKiemViewModel:BindableBase
    {
        public ThemTietKiemViewModel()
        {
            DialogResult = false;
            cancel = new MyICommand(onCancel);
        }
        bool? DialogResult;

        public MyICommand cancel { get; private set; }

        private void onCancel()
        {
            DialogResult = true;
        }

        private void onOk()
        {
            //khi an nut ok, se lay du lieu va them vao db, dong thoi thoat
        }
    }
}
