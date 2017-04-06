using System.Windows;
using System.Windows.Threading;
using System;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Loding_Window.xaml
    /// </summary>
    public partial class Loding_Window : Window
    {
        
        public Loding_Window()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(7d);
            timer.Tick += TimerTick;
            timer.Start();

        }
        public   void TimerTick(object sender,EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            this.Close();
            //return 0;
        }
        private void LoadingAnimation_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
