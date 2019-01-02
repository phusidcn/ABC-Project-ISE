using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Commands;

namespace ABC.ViewModel
{
    public class TietKiemViewModel:BindableBase
    {

        public TietKiemViewModel()
        {
            themTietKiem = new MyICommand(OnClick);
            
        }

        private ThemTietKiemViewModel themTietKiemViewModel = new ThemTietKiemViewModel();
        private BindableBase _addView;

        public BindableBase addView
        {
            get { return _addView; }
            set { SetProperty(ref _addView, value); }
        }

        public MyICommand themTietKiem { get; private set; }

        private void OnClick(){
            addView = themTietKiemViewModel;
        }
    }
}
