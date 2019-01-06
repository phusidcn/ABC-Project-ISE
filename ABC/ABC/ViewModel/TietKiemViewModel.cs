using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using ABC.Model;
using MaterialDesignThemes.Wpf;

namespace ABC.ViewModel
{
	public class TietKiemViewModel : BindableBase
	{

		public TietKiemViewModel()
		{
			themTietKiem = new MyICommand(OnClick);
			using(var context = new QLChiTieuEntities())
			{
				System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));
				context.uspThemKhoanTietKiem(IDUser, IDTK, IDVI, SoTien, responseMessage);
			}
		}

		#region Properties
        //private List<TietKiem> _listTK;
        //public List<TietKiem> ListTK
        //{
        //    get { return _listTK; }
        //    set { SetProperty(ref _listTK, value); }
        //}

		private int _idUser;
		public int IDUser
		{
			get { return _idUser; }
			set { SetProperty(ref _idUser, value); }
		}
		private int _idTK;
		public int IDTK
		{
			get { return _idTK; }
			set { SetProperty(ref _idTK, value); }
		}
		private int _idVi;
		public int IDVI
		{
			get { return _idVi; }
			set { SetProperty(ref _idVi, value); }
		}
		private int _soTien;
		public int SoTien
		{
			get { return _soTien; }
			set { SetProperty(ref _soTien, value); }
		}

		#endregion

		#region Content
		private ThemTietKiemViewModel themTietKiemViewModel = new ThemTietKiemViewModel();
		private BindableBase _addView;

		public BindableBase addView
		{
			get { return _addView; }
			set { SetProperty(ref _addView, value); }
		}
		#endregion

		#region Popup Command
		private bool _isAddDialogOpen;
		public bool IsAddDialogOpen
		{
			get { return _isAddDialogOpen; }
			set
			{
				if (_isAddDialogOpen == value) return;
				SetProperty(ref _isAddDialogOpen, value);
			}
		}
		public MyICommand themTietKiem { get; private set; }

		private void OnClick()
		{
			addView = themTietKiemViewModel;
			IsAddDialogOpen = true;
		}

		#endregion
	}
}
