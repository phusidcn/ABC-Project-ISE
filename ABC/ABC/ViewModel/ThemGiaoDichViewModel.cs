using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ABC.Helper;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using ABC.Model;
using System.Windows;

namespace ABC.ViewModel
{
	public class ThemGiaoDichViewModel : BindableBase
	{
        int userId = ABC.ViewModel.MainWindowViewModel.userID;
		public ThemGiaoDichViewModel()
		{
            LoadData();
			CancelCommand = new MyICommand(onCancel);
			OkCommand = new MyICommand(onOk);
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

        private Vi _viHienTai;
        public Vi viHienTai
        {
            get { return _viHienTai; }
            set { SetProperty(ref _viHienTai, value); }
        }

        private string _nguoiLienQuan;
        public string nguoiLienQuan
        {
            get { return _nguoiLienQuan; }
            set { SetProperty(ref _nguoiLienQuan, value); }
        }

        private int _selectedNhom;
        public int selectedNhom
        {
            get { return _selectedNhom; }
            set { SetProperty(ref _selectedNhom, value); }
        }

		#endregion

        #region function
        public MyICommand CancelCommand { get; private set; }
		public MyICommand OkCommand { get; private set; }

		void onCancel()
		{
			DialogHost.CloseDialogCommand.Execute((bool)false, null);
		}

		void onOk()
		{
            try
            {
                using (var context = new QLChiTieuEntities())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));
                    context.uspThemGiaoDich(userId, viHienTai.ID, _selectedNhom, SoTien, GhiChu, nguoiLienQuan, Ngay, responseMessage);
                    DialogHost.CloseDialogCommand.Execute((bool)true, null);
                    MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Notification", MessageBoxButton.OK);
            }
            DialogHost.CloseDialogCommand.Execute((bool)true, null);
        }

        void LoadData()
        {
            using (var context = new QLChiTieuEntities())
            {
                Nhom = context.Nhoms.ToList();
                viHienTai = ABC.ViewModel.TrangChuViewModel.viHienTai;
                Ngay = DateTime.Now;
            }
        }

        #endregion
    }
}
