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
    public class ThemThuViewModel : BindableBase
    {
        public ThemThuViewModel()
        {
            okCommand = new MyICommand(onOk);
            cancelCommand = new MyICommand(onCancel);
			using (var context = new QLChiTieuEntities())
			{
                try
                {
                    ViList = context.Vis.ToList();
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
			}
		}

		#region Properties

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

		public MyICommand okCommand { get; private set; }
        public MyICommand cancelCommand { get; private set; }

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
