using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Startup_Application(object sender,StartupEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Title = "Pro-z Solutions";
            mw.Show();
        }
    }
}
