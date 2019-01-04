using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace ABC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private int readId()
        {
            BinaryReader br;
            int id = -1;
            try
            {
                br = new BinaryReader(new FileStream("session", FileMode.OpenOrCreate));
                id = br.ReadInt32();  
            }
            catch (Exception)
            {
                Console.WriteLine("Cant read");
                return -1;
            }
            return id;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var identity = readId();
            if (identity == -1)
            {
                Window Login = new Login();
                Login.Show();
            }
            else
            {
                ABC.ViewModel.MainWindowViewModel.userID = identity;
                Window Main = new MainWindow();
                Main.Show();
            }
        }
    }
}
