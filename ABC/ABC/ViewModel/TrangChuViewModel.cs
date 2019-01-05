using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using ABC.Model;
using MaterialDesignThemes.Wpf;


namespace ABC.ViewModel
{
    public class TrangChuViewModel : BindableBase
    {
        private QLChiTieuEntities db;
        int idUser = ABC.ViewModel.MainWindowViewModel.userID;
        public TrangChuViewModel()
        {
            giaoDichs = new ObservableCollection<SO_GIAO_DICH>();
            Load();
            OpenAddDialogCommand = new MyICommand<object>(OpenAddDialog);
        }

        #region Properties
        private ObservableCollection<SO_GIAO_DICH> _giaoDichs;
        public ObservableCollection<SO_GIAO_DICH> giaoDichs
        {
            get { return _giaoDichs; }
            set { SetProperty(ref _giaoDichs, value); }
        }

        private SO_GIAO_DICH _giaoDichDuocChon;
        public SO_GIAO_DICH giaoDichDuocChon
        {
            get { return _giaoDichDuocChon; }
            set { SetProperty(ref _giaoDichDuocChon, value); }
        }

        private DateTime _currentDate;
        public DateTime currentDate
        {
            get { return _currentDate; }
            set { SetProperty(ref _currentDate, value); }
        }

        private int _thuNhapTrongThang;
        public int thuNhapTrongThang
        {
            get { return _thuNhapTrongThang; }
            set { SetProperty(ref _thuNhapTrongThang, value); }
        }

        private int _chiTieuTrongThang;
        public int chiTieuTrongThang
        {
            get { return _chiTieuTrongThang; }
            set { SetProperty(ref _chiTieuTrongThang, value); }
        }

        private int _conLai;
        public int conLai
        {
            get { return _conLai; }
            set { SetProperty(ref _conLai, value); }
        }
        #endregion

        #region data function
        void Load()
        {
            currentDate = DateTime.Now;
            db = new QLChiTieuEntities();
            var userGD = db.Users.Find(idUser).SO_GIAO_DICH;
            foreach (var gd in userGD)
            {
                if (gd.NGAY.Value.Date == currentDate.Date)
                {
                    giaoDichs.Add(gd);
                }
            }
            thuNhapTrongThang = TinhThuNhapTrongThang(userGD, currentDate);
            chiTieuTrongThang = TinhChiTieuTrongThang(userGD, currentDate);
            conLai = thuNhapTrongThang - chiTieuTrongThang;
        }

        int TinhChiTieuTrongThang(ICollection<SO_GIAO_DICH> giaoDich, DateTime current)
        {
            int count = 0;
            foreach (var gd in giaoDich)
            {
   
                if (gd.NGAY.Value.Month == current.Month && gd.Nhom.ID != 7)
                {
                    count += gd.SO_TIEN;
                }
            }
            return count;
        }

        int TinhThuNhapTrongThang(ICollection<SO_GIAO_DICH> giaoDich, DateTime current)
        {
            int count = 0;
            foreach (var gd in giaoDich)
            {

                if (gd.NGAY.Value.Month == current.Month && gd.Nhom.ID == 7)
                {
                    count += gd.SO_TIEN;
                }
            }
            return count;
        }
        #endregion

        #region Child
        private ThemGiaoDichViewModel themGiaoDich = new ThemGiaoDichViewModel();
        #endregion

        #region them giao dich buttom
        //pretty much ignore all the stuff provided, and manage everything via custom commands and a binding for .IsOpen
        public MyICommand<object> OpenAddDialogCommand { get; private set; }

        private bool _isAddDialogOpen;
        private BindableBase _addContent;

        public bool IsAddDialogOpen
        {
            get { return _isAddDialogOpen; }
            set
            {
                if (_isAddDialogOpen == value) return;
                SetProperty(ref _isAddDialogOpen, value);
            }
        }

        public BindableBase AddContent
        {
            get { return _addContent; }
            set
            {
                if (_addContent == value) return;
                SetProperty(ref _addContent, value);
            }
        }

        private void OpenAddDialog(object obj)
        {
            AddContent = themGiaoDich;
            IsAddDialogOpen = true;
        }
        #endregion
    }
}
