using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using ABC.Model;

namespace ABC.ViewModel
{
    public class ThemGiaoDichViewModel : BindableBase
    {
        public ThemGiaoDichViewModel()
        {
            CancelCommand = new MyICommand(onCancel);
            OkCommand = new MyICommand(onOk);
            //using (var context = new QLChiTieuEntities())
            //{
            //    Nhom = context.Nhoms.ToList();
            //}
		}

		#region Properties
		// So giao dich properties
		private List<Nhom> _nhom;
		public List<Nhom> Nhom
		{
			get { return _nhom; }
			set { SetProperty(ref _nhom, value); }
		}


		private DateTime _ngay;
		public DateTime Ngay
		{
			get { return _ngay; }
			set { SetProperty(ref _ngay, value); }
		}

		private string _ghiChu;
		public string GhiChu
		{
			get { return _ghiChu; }
			set { SetProperty(ref _ghiChu, value); }
		}

		private int _soTien;
		public int SoTien
		{
			get { return _soTien; }
			set { SetProperty(ref _soTien, value); }
		}


		#endregion
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
