using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ABC.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		public bool isShow = false;
		public ICommand LoadedWindowCommand { get; set; }
		public MainViewModel()
		{
			LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				isShow = true;
				Login loginWindow = new Login();
				loginWindow.ShowDialog();
			});
		}
	}
}
