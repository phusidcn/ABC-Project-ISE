using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Commands;
using ABC.Model;

namespace ABC.ViewModel
{
    public class MainWindowViewModel:BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = giaoDichViewModel;
        }

        #region ViewModel
        private TrangChuViewModel giaoDichViewModel = new TrangChuViewModel();
        private GhiNoViewModel ghiNoViewModel = new GhiNoViewModel();
        private TietKiemViewModel tietKiemViewModel = new TietKiemViewModel();
        private NhomCanDungViewModel nhomViewModel = new NhomCanDungViewModel();
        private NganSachViewModel nganSachViewModel = new NganSachViewModel();
        private XuHuongViewModel xuHuongViewModel = new XuHuongViewModel();
        private BieuDoViewModel bieuDoViewModel = new BieuDoViewModel();
        private GiupDoViewModel giupDoViewModel = new GiupDoViewModel();
        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }
        #endregion

        #region Commands
        public MyICommand<string> NavCommand { get; private set; }

        private void OnNav(string des)
        {
            switch (des)
            {
                case "giao_dich":
                    CurrentViewModel = giaoDichViewModel;
                    break;
                case "ghi_no":
                    CurrentViewModel = ghiNoViewModel;
                    break;
                case "tiet_kiem":
                    CurrentViewModel = tietKiemViewModel;
                    break;
                case "nhom":
                    CurrentViewModel = nhomViewModel;
                    break;
                case "ngan_sach":
                    CurrentViewModel = nganSachViewModel;
                    break;
                case "xu_huong":
                    CurrentViewModel = xuHuongViewModel;
                    break;
                case "bieu_do":
                    CurrentViewModel = bieuDoViewModel;
                    break;
                case "giup_do":
                    CurrentViewModel = giupDoViewModel;
                    break;
                default:
                    break;
            }
        }
        #endregion      
    }
}
