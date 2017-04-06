using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for testwindow.xaml
    /// public partial class MainWindow : RibbonWindow
    /// </summary>
    public partial class testwindow : RibbonWindow
    {
        public testwindow()
        {
            InitializeComponent();
            _ribbon.RibbonState = Syncfusion.Windows.Tools.RibbonState.Adorner;
        }

        TabItem _tabUserPage;///user tap references
       
        private void entry(object sender, RoutedEventArgs e)
        {
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems
            var userControls = new Dashboard();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls
            MainTab.Items.Refresh();
        }
    }

}
