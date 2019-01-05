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
    public class ThemNoViewModel : BindableBase
    {
        public ThemNoViewModel()
        {

            onCancelCommand = new MyICommand(onCancel);
            onOKCommand = new MyICommand(onOk);
        }

		#region Properties
		// So giao dich properties
		private List<Vi> _viList;
		public List<Vi> ViList
		{
			get { return _viList; }
			set { SetProperty(ref _viList, value); }
		}


		private DateTime _ngay;
		public DateTime Ngay
		{
			get { return _ngay; }
			set { SetProperty(ref _ngay, value); }
		}

		private string _loai;
		public string Loai
		{
			get { return _loai; }
			set { SetProperty(ref _loai, value); }
		}
		private int _idgiaodich;
		public int IDGiaoDich
		{
			get { return _idgiaodich; }
			set { SetProperty(ref _idgiaodich, value); }
		}

		private string _person;
		public string Person
		{
			get { return _person; }
			set { SetProperty(ref _person, value); }
		}

		private int _stt;
		public int STT
		{
			get { return _stt; }
			set { SetProperty(ref _stt, value); }
		}
		#endregion

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
