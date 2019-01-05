using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ABC.Helper;
using ABC.Model;
using MaterialDesignThemes.Wpf;

namespace ABC.ViewModel
{
    class ThemTietKiemViewModel : BindableBase
    {
        public ThemTietKiemViewModel()
        {
            cancelCommand = new MyICommand(onCancel);
            okCommand = new MyICommand(onOk);
			
        }


        public MyICommand cancelCommand { get; private set; }
        public MyICommand okCommand { get; private set; }

		#region Properties
		private int _idUser;
		public int IDUser
		{
			get { return _idUser; }
			set { SetProperty(ref _idUser, value); }
		}
		private string _tenKhoanTK;
		public string TenKhoanTK
		{
			get { return _tenKhoanTK; }
			set { SetProperty(ref _tenKhoanTK, value); }
		}
		private string _mucDich;
		public string MucDich
		{
			get { return _mucDich; }
			set { SetProperty(ref _mucDich, value); }
		}
		private int _mucTieu;
		public int MucTieu
		{
			get { return _mucTieu; }
			set { SetProperty(ref _mucTieu, value); }
		}
		private DateTime _ngay;
		public DateTime Ngay
		{
			get { return _ngay; }
			set { SetProperty(ref _ngay, value); }
		}
		#endregion


		void onCancel()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        void onOk()
        {
			DialogHost.CloseDialogCommand.Execute(null, null);
			try
			{


				using (var context = new QLChiTieuEntities())
				{
					System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));
					context.uspThemTietKiem(IDUser, TenKhoanTK, MucDich, MucTieu, Ngay, responseMessage);
					MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
				}
			} catch(Exception error)
			{
				MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
			}
		}
    }
}
