using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.Odbc;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Baner_name.xaml
    /// </summary>
    public partial class Baner_name : UserControl 
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        public Baner_name()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            transport_name_insert_img2.Visibility = System.Windows.Visibility.Hidden;
        }


        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {              
                    transport_name_insert_img1.Visibility = System.Windows.Visibility.Visible;
                    transport_name_insert_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();                               
            }
            ii++;
        }

        void transport_name_insert_click(Object sender, RoutedEventArgs e)
        {                     
            if (!string.IsNullOrWhiteSpace(t_name.Text))
            {               
                Properties.Settings.Default.Title = t_name.Text;
                Properties.Settings.Default.Save();                
                ((MainWindow)System.Windows.Application.Current.MainWindow).Title_Name.Content = t_name.Text;
                t_name.Text = "";
                transport_name_insert_img1.Visibility = System.Windows.Visibility.Hidden;
                transport_name_insert_img2.Visibility = System.Windows.Visibility.Visible;
                time1.Start();
            }
            else
            {
                MessageBox.Show("Enter Transport Name");
            }

            //con.close_connection();
            
        }

     void transport_name_change_back_click(object sender,RoutedEventArgs e)
        {

            ((MainWindow)System.Windows.Application.Current.MainWindow).baner.Visibility = Visibility.Hidden;
            t_name.Text = "";
        }

      
    }
}
