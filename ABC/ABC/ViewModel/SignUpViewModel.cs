using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ABC.Model;
using ABC.Helper;

namespace ABC.ViewModel
{
	public class SignUpViewModel : BindableBase
	{
		public SignUpViewModel()
		{
			CurrentState = WindowState.Normal;
			MinimizeCommand = new MyICommand(OnMinimizeCommand);
			CloseCommand = new MyICommand(OnCloseCommand);
			CancelCommand = new MyICommand<object>(OnCancelCommand);
			SignUpCommand = new MyICommand<object>(OnSignUpCommand);
		}

		#region Properties
		//Trang thai man hinh
		private WindowState _currentState;
		public WindowState CurrentState
		{
			get { return _currentState; }
			set { SetProperty(ref _currentState, value); }
		}
		// User properties
		private string _userName;
		public string UserName
		{
			get { return _userName; }
			set { SetProperty(ref _userName, value); }
		}

		private string _customerName;
		public string CustomerName
		{
			get { return _customerName; }
			set { SetProperty(ref _customerName, value); }
		}

		private string _dayOfBirth;
		public string DayOfBirth
		{
			get { return _dayOfBirth; }
			set { SetProperty(ref _dayOfBirth, value); }
		}

		private string _passWord;
		private string _reEnterPassWord;
		#endregion

		#region Commands
		public MyICommand MinimizeCommand { get; private set; }
		public MyICommand CloseCommand { get; private set; }
		public MyICommand<object> CancelCommand { get; private set; }
		public MyICommand<object> SignUpCommand { get; private set; }

		public void OnMinimizeCommand()
		{
			CurrentState = WindowState.Minimized;
		}

		private void OnCloseCommand()
		{
			ABC.App.Current.Shutdown();
		}

		private void OnCancelCommand(object parameter)
		{
			var container = parameter as Window;
			if (container != null)
			{
				container.Visibility = Visibility.Hidden;
				Window signin = new Login();
				signin.Show();
			}
		}

		private string ConvertToUnsecureString(System.Security.SecureString securePassword)
		{
			if (securePassword == null)
			{
				return string.Empty;
			}

			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
				return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}


		private void OnSignUpCommand(object parameter)
		{
			var pwContainer = parameter as IHavePassword;
			if (pwContainer != null)
			{
				try
				{
					var secureString = pwContainer.Password;
					var reEnterSecureString = pwContainer.RePassword;
					_passWord = ConvertToUnsecureString(secureString);
					_reEnterPassWord = ConvertToUnsecureString(reEnterSecureString);
					var dob = Convert.ToDateTime(DayOfBirth);
					if (_passWord != _reEnterPassWord)
					{
						throw new Exception("password and password confirm are different");
					}
					using (var context = new QLChiTieuEntities())
					{
						System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));

						context.uspAddUser(UserName, _passWord, CustomerName, dob, responseMessage);

						MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
					}
				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
				}
				var container = parameter as Window;
				container.Visibility = Visibility.Hidden;
				Window signin = new Login();
				signin.Show();
			}
		}
		#endregion

        //private void OnSignUpCommand(object parameter)
        //{
        //    var pwContainer = parameter as IHavePassword;
        //    if (pwContainer != null)
        //    {
        //        try
        //        {
        //            var secureString = pwContainer.Password;
        //            var reEnterSecureString = pwContainer.RePassword;
        //            _passWord = ConvertToUnsecureString(secureString);
        //            _reEnterPassWord = ConvertToUnsecureString(reEnterSecureString);
        //            var dob = Convert.ToDateTime(DayOfBirth);
        //            if (_passWord != _reEnterPassWord)
        //            {
        //                throw new Exception("password and password confirm are different");
        //            }
        //            using (QLChiTieuEntities context = new QLChiTieuEntities())
        //            {
        //                System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(String));

        //                context.uspAddUser(UserName, _passWord, CustomerName, dob, responseMessage);
        //                MessageBox.Show(responseMessage.Value.ToString(), "Notification", MessageBoxButton.OK);
        //            }
        //        }
        //        catch (Exception error)
        //        {
        //            MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        //        }
        //        var container = parameter as Window;
        //        container.Visibility = Visibility.Hidden;
        //        Window signin = new Login();
        //        signin.Show();
        //    }
        //}
        //#endregion


	}
}
