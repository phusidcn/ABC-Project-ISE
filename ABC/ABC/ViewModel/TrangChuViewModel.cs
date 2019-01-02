using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.ViewModel
{
    public class TrangChuViewModel:BindableBase
    {
        public TrangChuViewModel()
        {

        }

        #region Child
        private ThemGiaoDichViewModel themGiaoDich = new ThemGiaoDichViewModel();
        private BindableBase _CurrentChild;
        public BindableBase CurrentChild
        {
            get { return _CurrentChild; }
            set { SetProperty(ref _CurrentChild, value); }
        }
        #endregion
    }
}
