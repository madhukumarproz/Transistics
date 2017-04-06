using System.Data;
using System.Windows;
using System.Data.Odbc;
using System;
using System.Windows.Input;
using Microsoft.Win32;
using System.ComponentModel;
using System.Threading;  

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class test : Window
    {
        public System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        public System.Windows.Threading.DispatcherTimer t = new System.Windows.Threading.DispatcherTimer();
        int tt = 0;
        int a = 0;
       // int ii = 0;
        public string[] all_val = new string[12];
        string l11, l12, l3, l4, l5, l6, l7, l8, l9, l10, l111;
        public string pro_name = null;
        public test()
        {
           
            Change_Date();
            //GET_NAME1();
            Count T = new Count();
            T.counts();
            int i = Properties.Settings.Default.Counts;
            if(i<0)
            {
               MessageBoxResult mr= MessageBox.Show("Your Time limit Exceeds, Please Contact Admin","Application Closed",MessageBoxButton.OK,MessageBoxImage.Stop);
                if(mr==MessageBoxResult.OK)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Loding_Window lw = new Loding_Window();
                lw.Show();
                InitializeComponent();                            
                Title_Name.Content = Properties.Settings.Default.Title;
                ribbon.Visibility = Visibility.Hidden;              
                t.Tick += img_time;
                t.Interval = new TimeSpan(0, 0, 0, 0, 100);
                t.Start();
                time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
                time1.Tick += time_tick1;
                time1.Start();               
                today_date.Content = DateTime.Now.ToShortDateString();                                           
                    lw.Close();                
            }
           
        }
     
        void Change_Date()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            key.SetValue("sShortDate", "dd-MM-yyyy");
        }
        // Hide All panel
        public void hide_all_panel()
        {
            LOGIN_PANEL.Visibility = Visibility.Hidden;
            vehicle_panel.Visibility = Visibility.Hidden;
            diesel_panel.Visibility = Visibility.Hidden;
            driver_panel.Visibility = Visibility.Hidden;
            trip_entry_panel.Visibility = Visibility.Hidden;
            trip_update_panel.Visibility = Visibility.Hidden;
            trip_view_panel.Visibility = Visibility.Hidden;
            body_expense.Visibility = Visibility.Hidden;
            electrician_panel.Visibility = Visibility.Hidden;
            tank_panel.Visibility = Visibility.Hidden;
            shop_panel.Visibility = Visibility.Hidden;
            mechanical_panel.Visibility = Visibility.Hidden;
            other_panel.Visibility = Visibility.Hidden;
            maintenance_view_panel.Visibility = Visibility.Hidden;
            tyre_panel.Visibility = Visibility.Hidden;
            transport_list.Visibility = Visibility.Hidden;
            baner.Visibility = Visibility.Hidden;
            vehicle_view.Visibility = Visibility.Hidden;
            diesel_card_view.Visibility = Visibility.Hidden;
            diesel_card_deposit.Visibility = Visibility.Hidden;
            diesel_card_edit.Visibility = Visibility.Hidden;
            driver_salary.Visibility = Visibility.Hidden;
            driver_view.Visibility = Visibility.Hidden;
            driver_update.Visibility = Visibility.Hidden;
            vehicle_update.Visibility = Visibility.Hidden;
            profit_viewer.Visibility = Visibility.Hidden;
            user_create.Visibility = Visibility.Hidden;
            tyre_report.Visibility = Visibility.Hidden;
            load_trailer.Visibility = Visibility.Hidden;
            load_trailer_view.Visibility = Visibility.Hidden;
            load_pay.Visibility = Visibility.Hidden;
            load_update.Visibility = Visibility.Hidden;
            trailer_tyre.Visibility = Visibility.Hidden;
            load_tyre.Visibility = Visibility.Hidden;
            dashboard.Visibility = Visibility.Hidden;
            expiry_bill_view.Visibility = Visibility.Hidden;
            expiry_bill_update.Visibility = Visibility.Hidden;
            expiry_bill.Visibility = Visibility.Hidden;
        }

       

        void main_page_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            User_Name.Content = "";
            Properties.Settings.Default.User = "Null";
            Properties.Settings.Default.Save();
            LOGIN_PANEL.Visibility = Visibility.Visible;          
            t.Start();
            ribbon.Visibility = Visibility.Hidden;
        }

      

        //***   Vehicle Entry Panel   ***//

        void New_Entry_Click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            vehicle_panel.Visibility = Visibility.Visible;
            Get_String g = new Get_String();
            g.Model = "";
            g.Vehicle_Number = "";
            g.Load_Number = "";
            g.Trailer_Number = "";
            g.Corporation = "";
            g.Load_Model = "";
            g.Trailer_Model = "";
            this.DataContext = g;
        }

        void Update_Click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            vehicle_update.Visibility = Visibility.Visible;           
            Get_String g = new Get_String();
            g.Update_Trailer_Number = "";
            g.Update_Trailer_Trans_Name = "";
            g.Update_Load_Number = "";
            g.Update_Load_Trans_Name = "";
            g.Update_Model = "";
            g.Update_Vehicle_Corporation = "";
            g.Update_Vehicle_Number = "";
            g.Up_Load_Model = "";
            g.Up_Trailer_Model = "";
            this.DataContext = g;
        }

        void View_Detail_Click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            vehicle_view.Visibility = Visibility.Visible; 
           

        }

        void Report_View_Click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            profit_viewer.Visibility = Visibility.Visible;
        }
        //***  Diesel Card Entry    ***//


        void diesel_card_entry_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Customer_Id = "";
            g.Card_Id = "";
            this.DataContext = g;
            hide_all_panel();
            diesel_panel.Visibility = Visibility.Visible;                   
        }
        void diesel_card_edit_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Corporation = "";
            g.Card_Id = "";
            g.Customer_Id = "";
            this.DataContext = g;
            hide_all_panel();
            diesel_card_edit.Visibility = Visibility.Visible;                     
        }

       public void deposit_entry_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Credit_Amount = "";
            this.DataContext = g;
            hide_all_panel();
            diesel_card_deposit.Visibility = Visibility.Visible;  
                    
        }

        void diesel_view_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Trip_Num = "";
            this.DataContext = g;
            hide_all_panel();
            diesel_card_view.Visibility = Visibility.Visible;           
        }

        //*** LPG Trip Entry   ***//
        
       public void lpg_entry_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();           
            trip_entry_panel.Visibility = Visibility.Visible;
        }

        //***   LPG Trip View   ***//
        
        void trip_view_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            trip_view_panel.Visibility = Visibility.Visible;           
        }

        //***   LPG Trip Update   ***//
        
        void trip_update_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
           trip_update_panel.Visibility = Visibility.Visible;                      
        }
      public  void load_line_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            load_trailer.Visibility = System.Windows.Visibility.Visible;
            load_trailer_String gs = new load_trailer_String();
            gs.venum = string.Empty;
            gs.tripnum = string.Empty;
            gs.driid = string.Empty;
            gs.frm = string.Empty;
            gs.too = string.Empty;
            gs.startkm = string.Empty;
            gs.chaln = string.Empty;
            gs.ldadv = string.Empty;
            gs.driadv = string.Empty;
            gs.tripadv = string.Empty;
            gs.frght = string.Empty;
            gs.clname = string.Empty;
            gs.ldname = string.Empty;
            gs.wght = string.Empty;
            gs.endkm = string.Empty;
            gs.unloadwght = string.Empty;
            gs.pay = string.Empty;
            gs.dripay = "0";
            gs.clipay = "0";
            gs.commi = "0";
            gs.frghtred = "0";
            gs.Card_Id = string.Empty;
            gs.Place = string.Empty;
            gs.Litter = string.Empty;
            gs.Price = string.Empty;
            gs.Load_Wages = string.Empty;
            gs.Unload_Wages = string.Empty;
            gs.Phone = string.Empty;
            gs.spares = string.Empty;
            gs.Driver_Wages = string.Empty;
            gs.Clener_Wages = string.Empty;
            gs.Toll_Place = string.Empty;
            gs.Toll_Amount = string.Empty;
            gs.Rto_Place = string.Empty;
            gs.rto_amount = string.Empty;
            gs.Other_Reason = string.Empty;
            gs.Other_Amount = string.Empty;
            this.DataContext = gs;
            //MessageBox.Show("Please Contact Admin");
        }

        void loads_view_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            load_trailer_view.Visibility = System.Windows.Visibility.Visible;
            //MessageBox.Show("Please Contact Admin");
        }



        //***    Driver Details   ***//
        
        void driver_new_entry_click(object sender, RoutedEventArgs e)
        {
            
            hide_all_panel();
            driver_panel.Visibility = Visibility.Visible;            
            Get_String g = new Get_String();
            g.Driver_Name = "";
            g.Licence_No = "";
            g.Address = "";
            g.Contact = "";
            g.Referer_Name = "";
            g.Bank_Name = "";
            g.Acc_No = "";
            g.Branch = "";
            g.IFSC = "";
            this.DataContext = g;
        }
        void driver_update_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            driver_update.Visibility = Visibility.Visible;           
            Get_String g = new Get_String();
            g.Update_Driver_Name1 = "";
            g.Update_Licence_No = "";
            g.Update_Address = "";
            g.Update_Contact = "";
            g.Update_Referer_Name = "";
            g.Update_Bank_Name = "";
            g.Update_Acc_No = "";
            g.Update_Branch = "";
            g.Update_IFSC = "";
            this.DataContext = g;
        }

       public  void driver_payment_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Month = "";
            g.Year = "";
            g.Expense_Cost = "0";
            g.Remarks = "NOTHING";
            g.Remarks_Amount = "0";
            g.Salary = "0";
            this.DataContext = g;
            hide_all_panel();
            driver_salary.Visibility = Visibility.Visible;
        }

        void driver_view_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            driver_view.Visibility = Visibility.Visible;           
        }



        //***    Body Expense   ***//
        
        void body_builder_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
           body_expense.Visibility = Visibility.Visible;          
        }


        //*** Electrician Expense   ***//
        

        void electrical_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            electrician_panel.Visibility = Visibility.Visible;           
        }



        //*** Tank Expense   ***//

        
        void trailer_tank_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            tank_panel.Visibility = Visibility.Visible;            
        }

        //***   Shop Expense   ***//
        

        void shop_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            shop_panel.Visibility = Visibility.Visible;            
        }


        //***   Mechanical Expense   ***//
       
        void mechanical_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            mechanical_panel.Visibility = Visibility.Visible;          
        }


        //*** Other Expense    ***//
        
        void others_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            other_panel.Visibility = Visibility.Visible;          
        }


        //***   Maintenance View   ***//
       
        void maintenance_view_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            maintenance_view_panel.Visibility = Visibility.Visible;
            //Get_String g = new Get_String();
            //g.Vehicle_Number = "";
            //g.Month = "";
            //g.Year = "";
            //this.DataContext =g;
            Get_String g = new Get_String();
            g.Maintenance_Number = "";
            g.Maintenance_Month = "";
            g.Maintenance_Year = "";
            this.DataContext = g;
        }


        //***    Tyre Maintenance    ***//
        
        void lpg_tyre_entry_click(object sender, RoutedEventArgs e) 
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = "";
            this.DataContext = g;
            hide_all_panel();
            tyre_panel.Visibility = System.Windows.Visibility.Visible;          
        }


        //***   Settings Panel   ***//
       
        void transport_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            //setting_panel.Visibility = System.Windows.Visibility.Visible;
            baner.Visibility = System.Windows.Visibility.Visible;           
        }

        void transport_name_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            //setting_panel.Visibility = System.Windows.Visibility.Visible;
            transport_list.Visibility = System.Windows.Visibility.Visible;
                                           
        }

        private void User_Creation_panel_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            user_create.Visibility = System.Windows.Visibility.Visible;           
            Get_String g = new Get_String();
            g.Name = "";
            this.DataContext = g;
        }



        void img_time(object sender, EventArgs e)
        {
            time_now.Content = DateTime.Now.ToString("hh:mm:ss tt");
            a++;

            if (a % 10 == 0)
            {
                if (tt < 4)
                {

                    random_image_display();
                    tt++;
                }
                else
                {
                    tt = 0;
                    random_image_display();
                }
            }
        }

        //random image selection

        void random_image_display()
        {
            //string path = @"Resources\image\image1.jpg";
            //BitmapImage bmi = new BitmapImage(new Uri(path));
            //img.Source = bmi;
            if (tt == 0)
            {
                panel_hide();
                panel0.Visibility = System.Windows.Visibility.Visible;
            }
            else if (tt == 1)
            {
                panel_hide();
                panel1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (tt == 2)
            {
                panel_hide();
                panel2.Visibility = System.Windows.Visibility.Visible;
            }
            else if (tt == 3)
            {
                panel_hide();
                panel3.Visibility = System.Windows.Visibility.Visible;

            }
        }


        // Hide the panel

        void panel_hide()
        {
            panel0.Visibility = System.Windows.Visibility.Hidden;
            panel1.Visibility = System.Windows.Visibility.Hidden;
            panel2.Visibility = System.Windows.Visibility.Hidden;
            panel3.Visibility = System.Windows.Visibility.Hidden;
        }

        // Animated image close function

        void time_tick1(object sender, EventArgs e)
        {

            //if (ii == 0)
            //{
            //    //image_panel.Visibility = System.Windows.Visibility.Visible;

            //}
            //else if (ii == 10)
            //{
            //    LOGIN_PANEL.Visibility = System.Windows.Visibility.Visible;
            //    login_panel.Visibility = System.Windows.Visibility.Visible;
            //   // image_panel.Visibility = System.Windows.Visibility.Hidden;
            //    address_panel.Visibility = System.Windows.Visibility.Visible;

            //    time1.Stop();
            //}
            //ii++;
           // LOGIN_PANEL.Visibility = System.Windows.Visibility.Visible;
           // login_panel.Visibility = System.Windows.Visibility.Visible;
            // image_panel.Visibility = System.Windows.Visibility.Hidden;
           // address_panel.Visibility = System.Windows.Visibility.Visible;
        }

        private void sign_in_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string dat = Properties.Settings.Default.date;
                //DateTime d1 = Convert.ToDateTime(dat);
                //DateTime d2 = DateTime.Now;
                //int tot_day = (d1 - d2).Days;
                //if(tot_day<=31&tot_day>=0)
                //{

                if (!string.IsNullOrWhiteSpace(user_name_txt.Text) & !string.IsNullOrWhiteSpace(user_password_txt.Password))
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select user_name,passcode,designation from log_table WHERE DESIGNATION like '" + user_name_txt.Text + "' ", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string s = dt.Rows[0]["user_name"].ToString();
                        string p = dt.Rows[0]["passcode"].ToString();
                        string name = SecureMessage.Decrypt(s, true);
                        string code = SecureMessage.Decrypt(p, true);
                        string ps = user_password_txt.Password;
                        if (name.Equals(user_name_txt.Text) && ps.Equals(code))
                        {
                            Properties.Settings.Default.User = dt.Rows[0]["designation"].ToString();
                            Properties.Settings.Default.Save();
                            int i = Properties.Settings.Default.Counts;
                            string st = dt.Rows[0]["designation"].ToString();
                            user_name_txt.Text = ""; user_password_txt.Password = "";
                            LOGIN_PANEL.Visibility = System.Windows.Visibility.Hidden;
                            t.Stop();
                            ribbon.Visibility = Visibility.Visible;
                            home.Visibility = Visibility.Visible;
                            User_Name.Content = st;
                            dashboard.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect UserName & Password");
                            user_name_txt.Text = ""; user_password_txt.Password = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("User Details Not Exist");
                        user_name_txt.Text = ""; user_password_txt.Password = "";
                    }

                    con.close_connection();
                }
                else
                {
                    error_lbl.Content = "Please Enter User Name & Passcode";
                }

               
                //}
                //else
                //{
                //    expiry_panel.Visibility = System.Windows.Visibility.Visible;
                //}

            }
            catch
            {
                MessageBox.Show("Login Error");
            }

        }



        private void Expiry_Warning_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            //expiry_warning_panel.Visibility = System.Windows.Visibility.Visible;
            //address_panel.Visibility = Visibility.Hidden;
            //label1.Content = all_val[0];
            //label2.Content = all_val[1];
            //label3.Content = all_val[2];
            //label4.Content = all_val[3];
            //label5.Content = all_val[4];
            //label6.Content = all_val[5];
            //label7.Content = all_val[6];
            //label8.Content = all_val[7];
            //label9.Content = all_val[8];
            //label10.Content = all_val[9];
            //label11.Content = all_val[10];

        }
        void close_click(object sender, RoutedEventArgs e)
        {
            //expiry_warning_panel.Visibility = Visibility.Hidden;
            //address_panel.Visibility = Visibility.Visible;
            //label1.Content = ""; label2.Content = ""; label3.Content = ""; label4.Content = ""; label5.Content = ""; label6.Content = ""; label7.Content = ""; label8.Content = ""; label9.Content = ""; label10.Content = "";
        }


        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            title_panel.Visibility = System.Windows.Visibility.Visible;
        }

        void title_save_click(object sender, RoutedEventArgs e)
        {           
            if(!string.IsNullOrWhiteSpace(title_name.Text))
            {
                Properties.Settings.Default.Title = title_name.Text;
                Properties.Settings.Default.Save();
                Title_Name.Content = Properties.Settings.Default.Title;
                title_panel.Visibility = Visibility.Hidden;
                title_name.Text = "";
            }
            else
            {
                MessageBox.Show("Enter Title Name");
            }
           
        }

        private void user_name_txt_GotFocus(object sender, RoutedEventArgs e)
        {
            error_lbl.Content = "";
            user_name_txt.Text = "";
            user_password_txt.Password = "";
        }

        public string[] driver = new string[30];

        private void Driving_Licence_Expiry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //driver_license_expiry.Visibility = Visibility.Visible;
            //a_lbl1.Content = driver[0];
            //a_lbl2.Content = driver[1];
            //a_lbl3.Content = driver[2];
            //a_lbl4.Content = driver[3];
            //lbl5.Content = driver[4];
            //lbl6.Content = driver[5];
            //lbl7.Content = driver[6];
            //lbl8.Content = driver[7];
            //lbl9.Content = driver[8];
            //lbl10.Content = driver[9];
            //a_lbl11.Content = driver[10];
            //lbl12.Content = driver[11];
            //lbl13.Content = driver[12];
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            dashboard.Visibility = Visibility.Visible;
        }

        private void expiry_bill_view_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            expiry_bill.Visibility = Visibility.Visible;
        }

        private void expiry_update_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            expiry_bill_update.Visibility = Visibility.Visible;
        }

        private void expiry_bill_open(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            expiry_bill_view.Visibility = Visibility.Visible;
        }

        void driver_license_expiry_closed(object sender, RoutedEventArgs e)
        {
            //driver_license_expiry.Visibility = Visibility.Hidden;
        }


      

        private void Window_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult dr = MessageBox.Show("Are You Sure Want to Exit", "Application Closed", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (dr == MessageBoxResult.OK)
            {
                //exp.Stop();
                //Properties.Settings.Default.expir = "expir";
                //Properties.Settings.Default.Save();
                //Application.Current.Shutdown();
                //Properties.Settings.Default.name;

                e.Cancel = false;
                Environment.Exit(0);
            }
            else if(dr==MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dr = MessageBox.Show("Are You Sure Want to Exit", "Application Closed", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (dr == MessageBoxResult.OK)
            {
                //exp.Stop();
                //Properties.Settings.Default.expir = "expir";
                //Properties.Settings.Default.Save();
                //Application.Current.Shutdown();
                //Properties.Settings.Default.name;

                //e.Cancel = false;
                Environment.Exit(0);
            }
            else if (dr == MessageBoxResult.Cancel)
            {
                //e.Cancel = true;
               //string s= Environment.MachineName.ToString();
                
            }
        }

        private void lpg_tyre_price_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            tyre_report.Visibility = Visibility.Visible;
        }

       

        private void sign_in_btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    //string dat = Properties.Settings.Default.date;
                    //DateTime d1 = Convert.ToDateTime(dat);
                    //DateTime d2 = DateTime.Now;
                    //int tot_day = (d1 - d2).Days;
                    //if(tot_day<=31&tot_day>=0)
                    //{

                    if (!string.IsNullOrWhiteSpace(user_name_txt.Text) & !string.IsNullOrWhiteSpace(user_password_txt.Password))
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select user_name,passcode,designation from log_table WHERE DESIGNATION like '" + user_name_txt.Text + "' ", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string s = dt.Rows[0]["user_name"].ToString();
                            string p = dt.Rows[0]["passcode"].ToString();
                            string name = SecureMessage.Decrypt(s, true);
                            string code = SecureMessage.Decrypt(p, true);
                            string ps = user_password_txt.Password;
                            if (name.Equals(user_name_txt.Text) && ps.Equals(code))
                            {
                                Properties.Settings.Default.User = dt.Rows[0]["designation"].ToString();
                                Properties.Settings.Default.Save();
                                int i = Properties.Settings.Default.Counts;
                                string st = dt.Rows[0]["designation"].ToString();
                                user_name_txt.Text = ""; user_password_txt.Password = "";
                                LOGIN_PANEL.Visibility = System.Windows.Visibility.Hidden;
                                t.Stop();
                                ribbon.Visibility = Visibility.Visible;
                                home.Visibility = Visibility.Visible;
                                User_Name.Content = st;
                                dashboard.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                MessageBox.Show("Incorrect UserName & Password");
                                user_name_txt.Text = ""; user_password_txt.Password = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("User Details Not Exist");
                            user_name_txt.Text = ""; user_password_txt.Password = "";
                        }

                        con.close_connection();
                    }
                    else
                    {
                        error_lbl.Content = "Please Enter User Name & Passcode";
                        user_name_txt.Text = ""; user_password_txt.Password = "";
                    }


                    //}
                    //else
                    //{
                    //    expiry_panel.Visibility = System.Windows.Visibility.Visible;
                    //}

                }
                catch
                {
                    MessageBox.Show("Login Error");
                }
            }
        }
       

        public void load_payment_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            load_pay.Visibility = Visibility.Visible;
            // MessageBox.Show("Please Contact Admin");
        }

        private void load_update_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            load_update.Visibility = Visibility.Visible;
            // MessageBox.Show("Please Contact Admin");
           
        }

        private void trailer_tyre_entry_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            trailer_tyre.Visibility = Visibility.Visible;
            //MessageBox.Show("Please Contact Admin");
        }

        private void load_tyre_entry_click(object sender, RoutedEventArgs e)
        {
            hide_all_panel();
            load_tyre.Visibility = Visibility.Visible;
            //MessageBox.Show("Please Contact Admin");
        }

        

       

        void Banner_Name_Change_Back_Click(object sender, RoutedEventArgs e)
        {
            title_name.Text = "";
            title_panel.Visibility = Visibility.Hidden;
        }
    }
}
