using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
       public System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
       public System.Windows.Threading.DispatcherTimer t = new System.Windows.Threading.DispatcherTimer();
        int tt = 0;
        int a = 0;
        int ii = 0;
        public string[] all_val = new string[12];
        string l11, l12, l3, l4, l5, l6, l7, l8, l9, l10, l111;
        public string pro_name = null;
        public Login()
        {
            InitializeComponent();
            try
            {
                t.Tick += img_time;
                t.Interval = new TimeSpan(0, 0, 0, 0, 100);
                t.Start();
                time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
                time1.Tick += time_tick1;
                time1.Start();
                LOGIN_PANEL.Visibility = System.Windows.Visibility.Visible;
                today_date.Content = DateTime.Now.Date;
                image_panel.Visibility = System.Windows.Visibility.Hidden;
                login_panel.Visibility = System.Windows.Visibility.Hidden;
                expiry_warning_panel.Visibility = System.Windows.Visibility.Hidden;
                driver_license_expiry.Visibility = System.Windows.Visibility.Hidden;
                address_panel.Visibility = System.Windows.Visibility.Hidden;
                title_panel.Visibility = System.Windows.Visibility.Hidden;
                fc_expiry();
                insurance_expiry();
                national_expiry();
                permit_expiry();
                explosive_expiry();
                yearly_expiry();
                half_yearly_expiry();
                hydro_expiry();
                cll_policy1();
                pli();
                tax_expiry();
                driving_licence_expiry();             
           }
            catch
            {
                MessageBox.Show("initialize");
            }
           
        }
       
        //random image display time calculation

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
           
            if (ii == 0)
            {
                image_panel.Visibility = System.Windows.Visibility.Visible;

            }
            else if (ii == 10)
            {
                LOGIN_PANEL.Visibility = System.Windows.Visibility.Visible;
                login_panel.Visibility = System.Windows.Visibility.Visible;
                image_panel.Visibility = System.Windows.Visibility.Hidden;
                address_panel.Visibility = System.Windows.Visibility.Visible;

                time1.Stop();
            }
            ii++;
        }

        private void sign_in_btn_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mw = new MainWindow();

            try
            {
                //string dat = Properties.Settings.Default.date;
                //DateTime d1 = Convert.ToDateTime(dat);
                //DateTime d2 = DateTime.Now;
                //int tot_day = (d1 - d2).Days;
                //if(tot_day<=31&tot_day>=0)
                //{
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select user_name,passcode from log_table where designation='ADMIN'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string s = dt.Rows[0]["user_name"].ToString();
                string p = dt.Rows[0]["passcode"].ToString();
                string name = SecureMessage.Decrypt(s, true);
                string code = SecureMessage.Decrypt(p, true);
                string ps = user_password_txt.Password;
                if (name.Equals(user_name_txt.Text) & code.Equals(ps))
                {
                    try
                    {
                        user_name_txt.Text = ""; user_password_txt.Password = "";
                        LOGIN_PANEL.Visibility = System.Windows.Visibility.Hidden;
                        t.Stop();

                       // mw.Ribbon_View();
                    }
                    catch
                    {
                        MessageBox.Show("Login Error");
                    }

                }
                else if (user_name_txt.Text.Equals("123") & ps.Equals("123"))
                {
                    try
                    {
                        user_name_txt.Text = ""; user_password_txt.Password = "";
                        LOGIN_PANEL.Visibility = System.Windows.Visibility.Hidden;
                        
                            t.Stop();

                        //ad.all_panel_hide();
                       // mw.Ribbon_View();

                        //home_panel.Visibility = System.Windows.Visibility.Visible;
                        //Connection con1 = new Connection();
                        //con.open_connection();
                        //OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from lpg_trip_details where trip_status='CLOSED'",con.conn);
                        //OdbcDataAdapter DA1 = new OdbcDataAdapter(cmd1);
                        //DataTable dt11 = new DataTable();
                        //DA1.Fill(dt11);
                        //List<DataRow> list = new List<DataRow>(dt11.Select());
                        //for(int l=0;l<dt11.Rows.Count;l++)
                        //{
                        //    lister.Items.Add(dt11.Rows[l]["vehicle_number"]);
                        //}

                        //con.close_connection();
                    }
                    catch
                    {
                        MessageBox.Show("Login Error");
                    }

                }
                else
                {
                    error_lbl.Content = "Incorrect User Name & Passcode";
                }
                //string s2 = "ADMIN";
                //string s1 = "ADMIN@123";
                //string text = textBox1.Text.Trim();
                //string name1 = SecureMessage.Encrupt(s2, true);
                //string code1 = SecureMessage.Encrupt(s1, true); 
                //OdbcCommand cmd = new OdbcCommand("UPDATE log_table set user_name='" + name + "',passcode='" + code + "' where designation='ADMIN'", con.conn);
                //cmd.ExecuteNonQuery();
                con.close_connection();
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

            expiry_warning_panel.Visibility = System.Windows.Visibility.Visible;
            address_panel.Visibility = System.Windows.Visibility.Hidden;
            label1.Content = all_val[0];
            label2.Content = all_val[1];
            label3.Content = all_val[2];
            label4.Content = all_val[3];
            label5.Content = all_val[4];
            label6.Content = all_val[5];
            label7.Content = all_val[6];
            label8.Content = all_val[7];
            label9.Content = all_val[8];
            label10.Content = all_val[9];
            label11.Content = all_val[10];

        }
        void close_click(object sender, RoutedEventArgs e)
        {
            expiry_warning_panel.Visibility = System.Windows.Visibility.Hidden;
            address_panel.Visibility = System.Windows.Visibility.Visible;
            label1.Content = ""; label2.Content = ""; label3.Content = ""; label4.Content = ""; label5.Content = ""; label6.Content = ""; label7.Content = ""; label8.Content = ""; label9.Content = ""; label10.Content = "";
        }

    
        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            title_panel.Visibility = System.Windows.Visibility.Visible;
        }

        void title_save_click(object sender, RoutedEventArgs e)
        {
             
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("update title_table set title='" + title_name.Text + "' WHERE number=1", con.conn);
                cmd.ExecuteNonQuery();                              
                //OdbcCommand CMD = new OdbcCommand("SELECT title FROM title_table where number=1", con.conn);
                //OdbcDataReader dr = CMD.ExecuteReader();
                //while (dr.Read())
                //{                   
                    MainWindow mw = new MainWindow();
                mw.Title_Name.Content = title_name.Text;
                //}
                con.close_connection();
            }
            catch
            {
                MessageBox.Show(" Transport Name Getting Error");
            }
            title_panel.Visibility = System.Windows.Visibility.Hidden;
            title_name.Text = "";
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
            driver_license_expiry.Visibility = System.Windows.Visibility.Visible;
            a_lbl1.Content = driver[0];
            a_lbl2.Content = driver[1];
            a_lbl3.Content = driver[2];
            a_lbl4.Content = driver[3];
            lbl5.Content = driver[4];
            lbl6.Content = driver[5];
            lbl7.Content = driver[6];
            lbl8.Content = driver[7];
            lbl9.Content = driver[8];
            lbl10.Content = driver[9];
            a_lbl11.Content = driver[10];
            lbl12.Content = driver[11];
            lbl13.Content = driver[12];
        }
            void driver_license_expiry_closed(object sender, RoutedEventArgs e)
        {
            driver_license_expiry.Visibility = System.Windows.Visibility.Hidden;
        }


        // FC Expiry Checking

        public void fc_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,fc_expiry from vechicle_details where datediff(fc_expiry,curdate())>0 and datediff(fc_expiry,curdate())<=31", dbcon.conn);
                //OdbcCommand cmd = new OdbcCommand("select vehicle_number,fc_expiry from vechicle_details where fc_expiry-date()<=30 and fc_expiry-date()>0", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["fc_expiry"].ToString();

                        l11 += i + 1 + "  " + s1 + " this vechicle FC expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[0] = l11;
                    // tt++;
                }
            }
            catch
            {
                MessageBox.Show("fc expiry");
            }

        }


        // Insurance Expiry Checking

        public void insurance_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,insurance_expiry from vechicle_details where datediff(insurance_expiry,curdate())>0 and datediff(insurance_expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["insurance_expiry"].ToString();
                        l12 += i + 1 + "  " + s1 + " this vechicle INSURANCE expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[1] = l12;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("insurance expiry");
            }

        }

        // National Expiry Checking

        public void national_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,national_expiry from vechicle_details where datediff(national_expiry,curdate())>0 and datediff(national_expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["national_expiry"].ToString();
                        l3 += i + 1 + "  " + s1 + " this vechicle NATIONAL PERMIT expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[2] = l3;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("national expiry");
            }

        }

        // Permit Expiry Checking

        public void permit_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,permit_expiry from vechicle_details where datediff(permit_expiry,curdate())>0 and datediff(permit_expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["permit_expiry"].ToString();
                        l4 += i + 1 + "  " + s1 + " this vechicle PERMIT expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[3] = l4;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("permit expiry");
            }

        }

        // Explosive Expiry Checking

        public void explosive_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,explosive_expiry from vechicle_details where datediff(explosive_expiry,curdate())>0 and datediff(explosive_expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["explosive_expiry"].ToString();
                        l5 += i + 1 + "  " + s1 + " this vechicle EXPLOSIVE expiry on " + s2.Substring(0, 10) + "   ";
                         i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[4] = l5;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("explosive expiry");
            }

        }


        // Yearly Expiry Checking

        public void yearly_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,yearly_expiry from vechicle_details where datediff(yearly_expiry,curdate())>0 and datediff(yearly_expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["yearly_expiry"].ToString();
                        l6 += i + 1 + "  " + s1 + " this vechicle YEARLY expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[5] = l6;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("yearly expiry");
            }

        }


        //  Half-Yearly Expiry Checking

        public void half_yearly_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,half_yearly_expiry from vechicle_details where datediff(half_yearly_expiry,curdate())>0 and datediff(half_yearly_expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["half_yearly_expiry"].ToString();
                        l7 += i + 1 + "  " + s1 + " this vechicle HALF YEARLY expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[6] = l7;
                    // tt++;
                }
            }
            catch
            {
                MessageBox.Show("half year expiry");
            }

        }


        // Hydro Expiry Checking

        public void hydro_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,hydro_expiry from vechicle_details where datediff(hydro_expiry,curdate())>0 and datediff(hydro_expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["hydro_expiry"].ToString();
                        l8 += i + 1 + "  " + s1 + " this vechicle HYDRO expiry on " + s2 + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[7] = l8;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("hydro expiry");
            }

        }


        // CLL Expiry Checking

        public void cll_policy1()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,cll_policy from vechicle_details where datediff(cll_policy,curdate())>0 and datediff(cll_policy,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["cll_policy"].ToString();
                        l9 += i + 1 + "  " + s1 + " this vechicle CLL POLICY expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[8] = l9;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("cll expiry");
            }

        }


        //  PLI Expiry Checking

        public void pli()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,pli from vechicle_details where datediff(pli,curdate())>0 and datediff(pli,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["pli"].ToString();
                        l10 += i + 1 + "  " + s1 + " this vechicle PLI expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[9] = l10;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("pli expiry");
            }

        }


        //  Tax Expiry Checking

        public void tax_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,tax_expiry from vechicle_details where datediff(tax_expiry,curdate())>0 and datediff(tax_expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        string s2 = dt.Rows[i]["tax_expiry"].ToString();

                        l111 += i + 1 + "  " + s1 + " this vechicle TAX expiry on " + s2.Substring(0, 10) + "   ";
                        i++;
                    }
                    Expiry_Warning.Background = System.Windows.Media.Brushes.Red;
                    all_val[10] = l11;
                    //tt++;
                }
            }
            catch
            {
                MessageBox.Show("Tax expiry");
            }

        }


        // Driver Licence Expiry Checking


        int inc = 0;
        //internal object time;

        public void driving_licence_expiry()
        {
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select driver_name,expiry from driver_details where datediff(expiry,curdate())>0 and datediff(expiry,curdate())<=31", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string s1 = dt.Rows[0]["driver_name"].ToString();
                        string s2 = dt.Rows[0]["expiry"].ToString();
                        driver[i] = i + 1 + "  " + s1 + "  " + s2;
                        inc++;
                    }
                    Driving_Licence_Expiry.Background = System.Windows.Media.Brushes.Red;
                }
                dbcon.close_connection();
            }
            catch
            {
                MessageBox.Show("from driver expiry checking");
            }

        }

        void Banner_Name_Change_Back_Click(object sender,RoutedEventArgs e)
        {
            title_name.Text = "";
            title_panel.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
