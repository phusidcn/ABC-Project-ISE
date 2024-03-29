﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Helper;
using ABC.Model;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace ABC.ViewModel
{
	public class MainWindowViewModel : BindableBase
	{
		public static int userID { get; set; }
		public MainWindowViewModel()
		{
			Load();
			NavCommand = new MyICommand<string>(OnNav);
			ButtonClickCommand = new MyICommand<string>(OnClick);
			CurrentViewModel = giaoDichViewModel;
			CurrentWindowState = WindowState.Normal;
			logOutCommand = new MyICommand<object>(onLogOut);
		}

		#region Properties
		private User _curentUser;
		public User curentUser
		{
			get { return _curentUser; }
			set { SetProperty(ref _curentUser, value); }
		}

		private void Load()
		{
			var db = new QLChiTieuEntities();
			curentUser = db.Users.Find(userID);
		}
		#endregion

		#region ViewModel
		private TrangChuViewModel giaoDichViewModel = new TrangChuViewModel();
		private GhiNoViewModel ghiNoViewModel = new GhiNoViewModel();
		private TietKiemViewModel tietKiemViewModel = new TietKiemViewModel();
		private NhomCanDungViewModel nhomViewModel = new NhomCanDungViewModel();
		private XuHuongViewModel xuHuongViewModel = new XuHuongViewModel();
		private BieuDoViewModel bieuDoViewModel = new BieuDoViewModel();
		private GiupDoViewModel giupDoViewModel = new GiupDoViewModel();
		private TaiKhoanViewModel taiKhoanViewModel = new TaiKhoanViewModel();
		private BindableBase _CurrentViewModel;
		public BindableBase CurrentViewModel
		{
			get { return _CurrentViewModel; }
			set { SetProperty(ref _CurrentViewModel, value); }
		}

		private WindowState _CurrentWindowState;
		public WindowState CurrentWindowState
		{
			get { return _CurrentWindowState; }
			set { SetProperty(ref _CurrentWindowState, value); }
		}

		#endregion

		#region Commands
		public MyICommand<string> NavCommand { get; private set; }
		public MyICommand<string> ButtonClickCommand { get; private set; }
		public MyICommand<object> logOutCommand { get; private set; }

		private void OnNav(string des)
		{
			switch (des)
			{
				case "giao_dich":
					CurrentViewModel = giaoDichViewModel;
					break;
				case "ghi_no":
					CurrentViewModel = ghiNoViewModel;
					break;
				case "tiet_kiem":
					CurrentViewModel = tietKiemViewModel;
					break;
				case "nhom":
					CurrentViewModel = nhomViewModel;
					break;
				case "xu_huong":
					CurrentViewModel = xuHuongViewModel;
					break;
				case "bieu_do":
					CurrentViewModel = bieuDoViewModel;
					break;
				case "giup_do":
					CurrentViewModel = giupDoViewModel;
					break;
				case "chinh_sua":
					CurrentViewModel = taiKhoanViewModel;
					break;
				default:
					break;
			}
		}

		private void onLogOut(object parameter)
		{
			var window = parameter as Window;
			if (window != null)
			{
				if (File.Exists("session"))
				{
					File.Delete("session");
				}
				Window login = new Login();
				window.Visibility = Visibility.Hidden;
				login.Show();
			}
		}

		private void OnClick(string btn)
		{
			switch (btn)
			{
				case "close":
					ABC.App.Current.Shutdown();
					break;
				case "minimize":
					CurrentWindowState = WindowState.Minimized;
					break;
				default:
					break;
			}
		}
		#endregion
	}
}
