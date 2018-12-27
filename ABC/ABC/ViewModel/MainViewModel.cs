using ABC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ABC.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		public Boolean isShow = false;
		public MainViewModel()
		{
			if (!isShow)
			{
				isShow = true;
				Login login = new Login();
				login.ShowDialog();
			}

			var a = DataProvider.Instance.DB.Users.ToList();
		}

		
	}
}
