using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.ViewModel
{
	public class LoginViewModel : BaseViewModel
	{
		public Boolean isShow = false;
		public LoginViewModel()
		{
			if (!isShow)
			{
				isShow = true;
				Login login = new Login();
				login.ShowDialog();
			}

		}

	}
}
