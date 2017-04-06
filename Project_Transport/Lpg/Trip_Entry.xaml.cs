
using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;
using System.Text.RegularExpressions;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Trip_Entry.xaml
    /// </summary>
    public partial class Trip_Entry : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        string chr = null;
        int i = 0;
        public Trip_Entry()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Hidden;
            lpg_trip_close_img2.Visibility = System.Windows.Visibility.Hidden;
            diesel_calculation.Visibility = System.Windows.Visibility.Hidden;           
            lpg_trip_expense_panel.Visibility = System.Windows.Visibility.Hidden;
        }

        string var_char = null;
        String X1, X2, X3;
        double da = 0;
        double tl = 0;
        double bal = 0;
        double balance = 0;
        double card_tot = 0;
        int[] no_of_time =new int[20];       
        int t_count = 1;
        int r_count = 1;
        int o_count = 1;
        string[] type = new string[20];
        string[] place = new string[20];
        double[] litter = new double[20];
        double[] price = new double[20];
        string[] date = new string[20];
        double[] tot_price = new double[20];
        string[] card_id = new string[20];
        string[] tollplace = new string[10];
        string[] rtoplace = new string[10];
        string[] others = new string[10];
        double[] tollamount = new double[10];
        double[] rtoamount = new double[10];
        double[] otheramount = new double[10];
        string[] otherreason = new string[10];
        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {
                if (chr == "u"|chr=="l"|chr=="c")
                {
                    lpg_trip_insert_imgs1.Visibility = System.Windows.Visibility.Visible;
                    lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
                else if (chr == "e")
                {
                    lpg_trip_close_img1.Visibility = System.Windows.Visibility.Visible;
                    lpg_trip_close_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
            }
            ii++;
        }
        private void trip_open_checked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Trip_Load_Number = "";
            g.Origin = "";
            g.Destination ="";
            g.Starting_km = "";
            g.Load_Weight = "";
            this.DataContext = g;
            open_control_view();
            unload_control_hide();
            close_control_hide();
            var_char = "N";
            trip_unload_date.Text = ""; trip_end_km.Text = ""; trip_total_km.Content = ""; trip_total_diesel.Content = ""; trip_diesel_amount.Content = ""; trip_total_mileage.Content = ""; trip_unload_weight.Text = ""; trip_number.Text = "";
            vehicle_numbers.Text = ""; corporation_txt.Content = ""; trip_id.Content = ""; trip_driver.Content = ""; trip_open_date.Text = ""; trip_open_origin.Text = ""; trip_open_detination.Text = ""; trip_starting_km.Text = ""; trip_load_weight.Text = "";
            lpg_trip_advance.Text = ""; lph_trip_frieght.Text = ""; lpg_trip_expenses.Content = "";  lpg_trip_BALANCE.Content = ""; lpg_trip_profit.Content = ""; lpg_trip_pay_type.Text = ""; trip_close_number.Text = "";
        }

        private void trip_unloding_checked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Trip_Unload_Number = "";
            g.End_Km = "";
            g.Unload_Weight = "";
            g.Card_Id = "";
            g.Place = "";
            g.Litter = "";
            g.Price = "";
            this.DataContext = g;
            open_control_hide();
            unload_control_view();
            close_control_hide();
            trip_number.Items.Clear();
            var_char = "U";
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select vehicle_number from lpg_trip_details where trip_status='RUNNING'", con.conn);
            OdbcDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {

                trip_number.Items.Add(DR[0]);
            }
            trip_unload_date.Text = ""; trip_end_km.Text = ""; trip_total_km.Content = ""; trip_total_diesel.Content = ""; trip_diesel_amount.Content = ""; trip_total_mileage.Content = ""; trip_unload_weight.Text = ""; trip_number.Text = "";
            vehicle_numbers.Text = ""; corporation_txt.Content = ""; trip_id.Content = ""; trip_driver.Content = ""; trip_open_date.Text = ""; trip_open_origin.Text = ""; trip_open_detination.Text = ""; trip_starting_km.Text = ""; trip_load_weight.Text = "";
            lpg_trip_advance.Text = ""; lph_trip_frieght.Text = ""; lpg_trip_expenses.Content = "";  lpg_trip_BALANCE.Content = ""; lpg_trip_profit.Content = ""; lpg_trip_pay_type.Text = ""; trip_close_number.Text = "";
            con.close_connection();
        }
        private void trip_close_checked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Trip_Close_Number = "";
            g.Fright = "";
            g.Advance = "";
            g.Load_Wages = "0";
            g.Unload_Wages = "0";
            g.Phone = "0";
            g.Spares = "0";
            g.Driver_Wages = "0";
            g.Clener_Wages = "0";
            g.Toll_Amount = "0";
            g.Toll_Place = "";
            g.Rto_Amount = "0";
            g.Rto_Place = "";
            g.Other_Amount = "0";
            g.Other_Reason = "";
            this.DataContext = g;
            open_control_hide();
            unload_control_hide();
            close_control_view();
            trip_close_number.Items.Clear();
            var_char = "C";
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select trip_number from lpg_trip_details where trip_status='UNLOADED'", con.conn);
            OdbcDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {

                trip_close_number.Items.Add(DR[0]);
            }
            trip_unload_date.Text = ""; trip_end_km.Text = ""; trip_total_km.Content = ""; trip_total_diesel.Content = ""; trip_diesel_amount.Content = ""; trip_total_mileage.Content = ""; trip_unload_weight.Text = ""; trip_number.Text = "";
            vehicle_numbers.Text = ""; corporation_txt.Content = ""; trip_id.Content = ""; trip_driver.Content = ""; trip_open_date.Text = ""; trip_open_origin.Text = ""; trip_open_detination.Text = ""; trip_starting_km.Text = ""; trip_load_weight.Text = "";
            lpg_trip_advance.Text = ""; lph_trip_frieght.Text = ""; lpg_trip_expenses.Content = "";  lpg_trip_BALANCE.Content = ""; lpg_trip_profit.Content = ""; lpg_trip_pay_type.Text = ""; trip_close_number.Text = "";
            con.close_connection();

        }


        private void trip_ioc_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                if (var_char == "N")
                {
                    new_trip_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from vechicle_details where corporation='IOC' and status='CLOSED'", con.conn);

                    OdbcDataReader da = cmd1.ExecuteReader();
                    vehicle_numbers.Items.Clear();
                    while (da.Read())
                    {
                        vehicle_numbers.Items.Add(da[0]);
                        corporation_txt.Content = "IOC";

                    }
                }
                else if (var_char == "U")
                {
                    trip_unloading_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from lpg_trip_details where corporation='IOC' and trip_status='RUNNING'", con.conn);
                    OdbcDataAdapter DA = new OdbcDataAdapter(cmd1);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        trip_number.Items.Clear();
                        for (int I = 0; I < DT.Rows.Count; I++)
                        {
                            trip_number.Items.Add(DT.Rows[I]["vehicle_number"]);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Vehicles Not Running Stage  ");
                    }

                }
                else if (var_char == "C")
                {
                    trip_closed_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select trip_number from lpg_trip_details where corporation='IOC' and trip_status='UNLOADED'", con.conn);
                    OdbcDataAdapter DA = new OdbcDataAdapter(cmd1);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        trip_close_number.Items.Clear();
                        for (int I = 0; I < DT.Rows.Count; I++)
                        {
                            trip_close_number.Items.Add(DT.Rows[I]["vehicle_number"]);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Vehicles Not Unloaded Stage  ");
                    }
                }

                con.close_connection();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }


        }

        private void trip_bpc_Checked_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                if (var_char == "N")
                {
                    new_trip_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from vechicle_details where corporation='BPC' and status='CLOSED'", con.conn);
                    OdbcDataReader da = cmd1.ExecuteReader();
                    vehicle_numbers.Items.Clear();
                    while (da.Read())
                    {
                        vehicle_numbers.Items.Add(da[0]);
                        corporation_txt.Content = "BPC";

                    }
                }
                else if (var_char == "U")
                {
                    trip_unloading_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from lpg_trip_details where corporation='BPC' and trip_status='RUNNING'", con.conn);
                    OdbcDataAdapter DA = new OdbcDataAdapter(cmd1);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        trip_number.Items.Clear();
                        for (int I = 0; I < DT.Rows.Count; I++)
                        {
                            trip_number.Items.Add(DT.Rows[I]["vehicle_number"]);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Vehicles Not Running Stage  ");
                    }

                }
                else if (var_char == "C")
                {
                    trip_closed_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select trip_number from lpg_trip_details where corporation='BPC' and trip_status='UNLOADED'", con.conn);
                    OdbcDataAdapter DA = new OdbcDataAdapter(cmd1);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        trip_close_number.Items.Clear();
                        for (int I = 0; I < DT.Rows.Count; I++)
                        {
                            trip_close_number.Items.Add(DT.Rows[I]["vehicle_number"]);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Vehicles Not Unload Stage  ");
                    }

                }

                con.close_connection();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
        }

        private void trip_hpc_Checked_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                if (var_char == "N")
                {
                    new_trip_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from vechicle_details where corporation='HPC' and status='CLOSED'", con.conn);
                    OdbcDataReader da = cmd1.ExecuteReader();
                    vehicle_numbers.Items.Clear();
                    while (da.Read())
                    {
                        vehicle_numbers.Items.Add(da[0]); 
                        corporation_txt.Content = "HPC";

                    }
                }
                else if (var_char == "U")
                {
                    trip_unloading_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from lpg_trip_details where corporation='HPC' and trip_status='RUNNING'", con.conn);
                    OdbcDataAdapter DA = new OdbcDataAdapter(cmd1);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        trip_number.Items.Clear();
                        for (int I = 0; I < DT.Rows.Count; I++)
                        {
                            trip_number.Items.Add(DT.Rows[I]["vehicle_number"]);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Vehicles Not Running Stage  ");
                    }

                }
                else if (var_char == "C")
                {
                    trip_closed_checked.IsChecked = true;
                    OdbcCommand cmd1 = new OdbcCommand("select trip_number from lpg_trip_details where corporation='HPC' and trip_status='UNLOADED'", con.conn);
                    OdbcDataAdapter DA = new OdbcDataAdapter(cmd1);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        trip_close_number.Items.Clear();
                        for (int I = 0; I < DT.Rows.Count; I++)
                        {
                            trip_close_number.Items.Add(DT.Rows[I]["vehicle_number"]);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Vehicles Not Unload Stage  ");
                    }

                }

                con.close_connection();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
        }

       
        private void Label_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        void trip_starting_km_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(vehicle_numbers.Text)&& !string.IsNullOrWhiteSpace(trip_starting_km.Text))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select ending_km from lpg_trip_details where vehicle_number='" + vehicle_numbers.Text + "' order by unload_date desc", con.conn);
                        OdbcDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            int n = 0;
                            if (string.IsNullOrWhiteSpace(dr[0].ToString()))
                            {
                                n = 0;
                            }
                            else
                            {
                                n = Convert.ToInt32(dr[0]);
                            }
                            int cur = 0;                          
                            cur = Convert.ToInt32(trip_starting_km.Text);
                            if (cur > n)
                            {

                            }
                            else if (cur < n&&cur!=-1)
                            {
                                    MessageBoxResult mr = MessageBox.Show("Trip starting km is Below the Previous Ending km", "Enter km correctly", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                    if (mr == MessageBoxResult.OK || mr == MessageBoxResult.Cancel)
                                    {
                                    trip_starting_km.Text = "";
                                    e.Handled = true;
                                    }
                             }
                             else if (cur == -1)
                             {
                                    trip_starting_km.Text = "0";
                             }                            
                             else if (trip_starting_km.Text == "")
                             {
                                    trip_starting_km.Text = "0";
                             }
                               
                             else
                             {
                                MessageBox.Show("Incorrect Value");
                                trip_starting_km.Text = "";
                                e.Handled = true;
                            }
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Enter Km and Vehicle Number");
                    e.Handled = true;
                }
              
            }
        }

        private void trip_open_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                if (new_trip_checked.IsChecked == true)
                {
                    if (!string.IsNullOrWhiteSpace(vehicle_numbers.Text) && !string.IsNullOrWhiteSpace(trip_id.Content.ToString()) & !string.IsNullOrWhiteSpace(trip_driver.Content.ToString()) & !string.IsNullOrWhiteSpace(trip_open_date.Text) & !string.IsNullOrWhiteSpace(trip_open_origin.Text) & !string.IsNullOrWhiteSpace(trip_open_detination.Text) & !string.IsNullOrWhiteSpace(trip_starting_km.Text) & !string.IsNullOrWhiteSpace(trip_load_weight.Text))
                    {
                        string l = vehicle_numbers.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            vehicle_numbers.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                try
                                {
                                    Connection con = new Connection();
                                    con.open_connection();
                                    OdbcCommand cmd = new OdbcCommand("insert into lpg_trip_details(corporation,vehicle_number,trip_number,driver_name,origin,destination,load_date,load_weight,starting_km,trip_status)values('" + corporation_txt.Content + "','" + vehicle_numbers.Text + "','" + trip_id.Content + "','" + trip_driver.Content + "','" + trip_open_origin.Text + "','" + trip_open_detination.Text + "','" + Convert.ToDateTime(trip_open_date.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDouble(trip_load_weight.Text) + "','" + Convert.ToInt32(trip_starting_km.Text) + "','RUNNING')", con.conn);
                                    cmd.ExecuteNonQuery();
                                    vehicle_numbers.Text = ""; corporation_txt.Content = ""; trip_id.Content = ""; trip_driver.Content = ""; trip_open_date.Text = ""; trip_open_origin.Text = ""; trip_open_detination.Text = ""; trip_starting_km.Text = ""; trip_load_weight.Text = ""; ioc_rbtn.IsChecked = false; bpc_rbtn.IsChecked = false; hpc_rbtn.IsChecked = false;
                                    con.close_connection();
                                    time1.Start();
                                    chr = "l";
                                    lpg_trip_insert_imgs1.Visibility = System.Windows.Visibility.Hidden;
                                    lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Visible;
                                }
                                catch (OdbcException ex)
                                {
                                    MessageBox.Show("Error :" + ex);
                                }
                            }
                            else if (mr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("Vehicle Number Invalid Format");
                        }
                        
                     

                    }
                    else
                    {
                        MessageBox.Show("should fill all field");
                    }
                }
                else if (trip_unloading_checked.IsChecked == true)
                {

                    if (!string.IsNullOrWhiteSpace(trip_unload_date.Text) & !string.IsNullOrWhiteSpace(trip_end_km.Text) & !string.IsNullOrWhiteSpace(trip_total_km.Content.ToString()) & !string.IsNullOrWhiteSpace(trip_diesel_amount.Content.ToString()) & !string.IsNullOrWhiteSpace(trip_unload_weight.Text))
                    {
                        string l = vehicle_numbers.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            vehicle_numbers.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                try
                                {
                                    Connection con = new Connection();
                                    con.open_connection();
                                    for (int k = 0; k < i; k++)
                                    {
                                        OdbcCommand cmd2 = new OdbcCommand("insert into diesel_balance_sheet(trip_number,corporation,card_id,vehicle_number,origin,destination,place,fill_date,noof_times,litters,price_per,total_cost,withdraw,entry_date)values('" + trip_id.Content + "','" + corporation_txt.Content + "','" + card_id[k] + "','" + trip_number.Text + "','" + trip_open_origin.Text + "','" + trip_open_detination.Text + "','" + place[k] + "','" + Convert.ToDateTime(date[k]).ToString("yyyy/MM/dd") + "','" + no_of_time[k] + "','" + Convert.ToDouble(litter[k]) + "','" + Convert.ToDouble(price[k]) + "','" + tot_price[k] + "','" + type[k] + "','" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy/MM/dd") + "')", con.conn);
                                        cmd2.ExecuteNonQuery();
                                    }
                                    
                                    OdbcCommand cmd = new OdbcCommand("update lpg_trip_details set unload_date='" + Convert.ToDateTime(trip_unload_date.Text).ToString("yyyy/MM/dd") + "',ending_km='" + Convert.ToInt32(trip_end_km.Text) + "',total_km='" + Convert.ToInt32(trip_total_km.Content) + "',trip_diesel='" + Convert.ToInt32(trip_total_diesel.Content) + "',diesel_amount='" + Convert.ToDouble(trip_diesel_amount.Content) + "',trip_mileage='" + Convert.ToDouble(trip_total_mileage.Content) + "',unload_weight='" + Convert.ToDouble(trip_unload_weight.Text) + "',trip_status='UNLOADED' where vehicle_number='" + trip_number.Text + "' and trip_number='" + trip_id.Content + "'", con.conn);
                                    cmd.ExecuteNonQuery();
                                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from lpg_trip_details where trip_status='RUNNING'", con.conn);
                                    OdbcDataReader DR = cmd1.ExecuteReader();
                                    trip_number.Items.Clear();
                                    while (DR.Read())
                                    {

                                        trip_number.Items.Add(DR[0]);
                                    }
                                    con.close_connection();
                                    trip_unload_date.Text = ""; trip_end_km.Text = ""; trip_total_km.Content = ""; trip_total_diesel.Content = ""; trip_diesel_amount.Content = ""; trip_total_mileage.Content = ""; trip_unload_weight.Text = ""; trip_number.Text = "";
                                    vehicle_numbers.Text = ""; corporation_txt.Content = ""; trip_id.Content = ""; trip_driver.Content = ""; trip_open_date.Text = ""; trip_open_origin.Text = ""; trip_open_detination.Text = ""; trip_starting_km.Text = ""; trip_load_weight.Text = "";
                                    i = 0;
                                    Array.Clear(type, 0, type.Length);
                                    Array.Clear(place, 0, place.Length);
                                    Array.Clear(litter, 0, litter.Length);
                                    Array.Clear(price, 0, price.Length);
                                    Array.Clear(date, 0, date.Length);
                                    Array.Clear(no_of_time, 0, no_of_time.Length);
                                    Array.Clear(tot_price, 0, tot_price.Length);
                                    Array.Clear(card_id, 0, card_id.Length);
                                    time1.Start();
                                    chr = "u";
                                    lpg_trip_insert_imgs1.Visibility = System.Windows.Visibility.Hidden;
                                    lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Visible;
                                }
                                catch (OdbcException ex)
                                {
                                    MessageBox.Show("Error :" + ex);
                                }
                            }
                            else if (mr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("Vehicle Number Invalid Format");
                        }
                     
                        

                    }
                    else
                    {
                        MessageBox.Show("Should Fill All Field");
                    }

                }
                else if (trip_closed_checked.IsChecked == true)
                {
                    if (!string.IsNullOrWhiteSpace(lpg_trip_advance.Text) & !string.IsNullOrWhiteSpace(lph_trip_frieght.Text) & !string.IsNullOrWhiteSpace(lpg_trip_expenses.Content.ToString()) & !string.IsNullOrWhiteSpace(lpg_trip_BALANCE.Content.ToString()) & !string.IsNullOrWhiteSpace(lpg_trip_profit.Content.ToString()) & !string.IsNullOrWhiteSpace(lpg_trip_pay_type.Text.ToString()) && !string.IsNullOrWhiteSpace(trip_number.Text))
                    {
                        string l = vehicle_numbers.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            vehicle_numbers.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                try
                                {
                                    string id = trip_driver.Content.ToString();
                                    if (id.Length <= 23)
                                    {
                                        Connection con1 = new Connection();
                                        con1.open_connection();

                                        for (int k = 0; k < t_count; k++)
                                        {
                                            OdbcCommand cmd3 = new OdbcCommand("insert into toll_spend(trip_number,place,amount,count)values('" + trip_id.Content + "','" + tollplace[k] + "','" + tollamount[k] + "'," + k + 1 + ")", con1.conn);
                                            cmd3.ExecuteNonQuery();
                                        }
                                        for (int k = 0; k < r_count; k++)
                                        {
                                            OdbcCommand cmd4 = new OdbcCommand("insert into rto_pc(trip_number,place,amount,count)values('" + trip_id.Content + "','" + rtoplace[k] + "','" + rtoamount[k] + "'," + k + 1 + ")", con1.conn);
                                            cmd4.ExecuteNonQuery();
                                        }
                                        for (int k = 0; k < o_count; k++)
                                        {
                                            OdbcCommand cmd5 = new OdbcCommand("insert into other_spend(trip_number,reason,amount,count)values('" + trip_id.Content + "','" + otherreason[k] + "','" + otheramount[k] + "'," + k + 1 + ")", con1.conn);
                                            cmd5.ExecuteNonQuery();
                                        }
                                        OdbcCommand cmd2 = new OdbcCommand("insert into lpg_trip_expense(vehicle_number,trip_number,load_wages,unload_wages,phone,spares,driver,cliner,toll_spend,rto_pc_gas,others)values('" + trip_number.Text + "','" + trip_id.Content + "','" + Convert.ToDouble(val11.Text) + "','" + Convert.ToDouble(val12.Text) + "','" + Convert.ToDouble(val13.Text) + "','" + Convert.ToDouble(val14.Text) + "','" + Convert.ToDouble(val15.Text) + "','" + Convert.ToDouble(val16.Text) + "','" + Convert.ToDouble(toll_total.Text) + "','" + Convert.ToDouble(rto_total.Text) + "','" + Convert.ToDouble(other_total.Text) + "')", con1.conn);
                                        cmd2.ExecuteNonQuery();
                                        con1.close_connection();
                                        Connection con = new Connection();
                                        con.open_connection();
                                        OdbcCommand cmd = new OdbcCommand("update lpg_trip_details set trip_advance='" + Convert.ToInt32(lpg_trip_advance.Text) + "',trip_frieght='" + Convert.ToInt32(lph_trip_frieght.Text) + "',trip_expense='" + Convert.ToDouble(lpg_trip_expenses.Content) + "',trip_balance='" + Convert.ToDouble(lpg_trip_BALANCE.Content) + "',trip_profit='" + Convert.ToDouble(lpg_trip_profit.Content) + "',payment_type='" + lpg_trip_pay_type.Text + "',trip_status='CLOSED' where vehicle_number='" + trip_number.Text + "' and trip_number='" + trip_id.Content + "'", con.conn);
                                        cmd.ExecuteNonQuery();
                                        OdbcCommand cmmd = new OdbcCommand("insert into driver_advance(driver_id,trip_number,vehicle_number,total_km,advance,expense,balance,closed_date)values('" + id + "','" + trip_id.Content + "','" + trip_number.Text + "','" + trip_total_km.Content + "','" + lpg_trip_advance.Text + "','" + Convert.ToDouble(lpg_trip_expenses.Content) + "','" + lpg_trip_BALANCE.Content + "','" + Convert.ToDateTime(trip_open_date.Text).ToString("yyyy/MM/dd") + "')", con.conn);
                                        cmmd.ExecuteNonQuery();
                                        OdbcCommand cmd1 = new OdbcCommand("select trip_number from lpg_trip_details where trip_status='UNLOADED'", con.conn);
                                        OdbcDataReader DR = cmd1.ExecuteReader();
                                        trip_close_number.Items.Clear();
                                        while (DR.Read())
                                        {

                                            trip_close_number.Items.Add(DR[0]);
                                        }
                                        con.close_connection();
                                        t_count = 1; r_count = 1; o_count = 1;
                                        Array.Clear(tollamount, 0, tollamount.Length);
                                        Array.Clear(tollplace, 0, tollplace.Length);
                                        Array.Clear(rtoamount, 0, rtoamount.Length);
                                        Array.Clear(rtoplace, 0, rtoplace.Length);
                                        Array.Clear(otheramount, 0, otheramount.Length);
                                        Array.Clear(otherreason, 0, otherreason.Length);
                                        val11.Text = "0"; val12.Text = "0"; val13.Text = "0"; val14.Text = "0"; val15.Text = "0"; val16.Text = "0";
                                        trip_unload_date.Text = ""; trip_end_km.Text = ""; trip_total_km.Content = ""; trip_total_diesel.Content = ""; trip_diesel_amount.Content = ""; trip_total_mileage.Content = ""; trip_unload_weight.Text = ""; trip_number.Text = "";
                                        vehicle_numbers.Text = ""; corporation_txt.Content = ""; trip_id.Content = ""; trip_driver.Content = ""; trip_open_date.Text = ""; trip_open_origin.Text = ""; trip_open_detination.Text = ""; trip_starting_km.Text = ""; trip_load_weight.Text = "";
                                        lpg_trip_advance.Text = ""; lph_trip_frieght.Text = ""; lpg_trip_expenses.Content = ""; lpg_trip_BALANCE.Content = ""; lpg_trip_profit.Content = ""; lpg_trip_pay_type.Text = ""; trip_close_number.Text = "";
                                        time1.Start();
                                        chr = "c";
                                        lpg_trip_insert_imgs1.Visibility = System.Windows.Visibility.Hidden;
                                        lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Visible;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Driver Id Exceeds Maximum Length");
                                    }

                                }
                                catch (OdbcException ex)
                                {
                                    MessageBox.Show("Error :" + ex);
                                }
                            }
                            else if (mr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("Vehicle Number Invalid Format");
                        }
                       
                       

                    }
                    else
                    {
                        MessageBox.Show("Should Fill All Text Field");
                    }
                }
                else
                {
                    MessageBox.Show("Should select What Type of Work You Want to Do");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }

        private void trip_number_KeyDown(object sender, KeyEventArgs e)
        {
            Connection con = new Connection();
            con.open_connection();
            if(!string.IsNullOrWhiteSpace(trip_number.Text))
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("select * from lpg_trip_details where vehicle_number='" + trip_number.Text + "' and trip_status='RUNNING'", con.conn);
                    OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DA.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        vehicle_numbers.Text = dt.Rows[0]["vehicle_number"].ToString();
                        corporation_txt.Content = dt.Rows[0]["corporation"];
                        trip_id.Content = dt.Rows[0]["trip_number"];
                        trip_driver.Content = dt.Rows[0]["driver_name"];
                        trip_open_date.Text = dt.Rows[0]["load_date"].ToString();
                        trip_open_origin.Text = dt.Rows[0]["origin"].ToString();
                        trip_open_detination.Text = dt.Rows[0]["destination"].ToString();
                        trip_starting_km.Text = dt.Rows[0]["starting_km"].ToString();
                        trip_load_weight.Text = dt.Rows[0]["load_weight"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Selected vehicle is not Running");
                    }
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
               
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number From DropDown List");
            }
            con.close_connection();
        }


        private void trip_end_km_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(trip_starting_km.Text)&&!string.IsNullOrWhiteSpace(trip_end_km.Text))
                {
                    int w = Convert.ToInt32(trip_starting_km.Text);
                    if (w == -1)
                    {
                        trip_total_km.Content = trip_end_km.Text;
                        //trip_end_km.Text = "-1";
                    }
                    else if (Convert.ToInt32(trip_end_km.Text) > Convert.ToInt32(trip_starting_km.Text))
                    {
                        trip_total_km.Content = Convert.ToInt32(trip_end_km.Text) - Convert.ToInt32(trip_starting_km.Text);

                    }

                    else
                    {
                        MessageBoxResult mbr = MessageBox.Show("Trip Ending Km is Less Then Starting Km", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        if (mbr == MessageBoxResult.OK)
                        {
                            trip_end_km.Text = "";
                            //trip_end_km.Focus();
                            e.Handled = true;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Strating and Eding Km");
                }
               

            }
        }


        private void trip_total_diesel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            diesel_calculation.Visibility = System.Windows.Visibility.Visible;
        }

        void trip_unload_weight_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (Convert.ToDouble(trip_unload_weight.Text) <= Convert.ToDouble(trip_load_weight.Text))
                {

                }
                else
                {
                    MessageBoxResult mbr = MessageBox.Show("Trip Unload Weight is Greater Then Starting Load Weight", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    if (mbr == MessageBoxResult.OK)
                    {
                        trip_unload_weight.Text = "";
                        e.Handled = true;
                        FocusManager.SetFocusedElement(this, trip_unload_weight);
                    }

                }

            }
        }

        private void trip_close_number_KeyDown(object sender, KeyEventArgs e)
        {
           
            if(!string.IsNullOrWhiteSpace(trip_close_number.Text))
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select * from lpg_trip_details where trip_number='" + trip_close_number.Text + "' and trip_status='UNLOADED'", con.conn);
                    OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DA.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        vehicle_numbers.Text = dt.Rows[0]["vehicle_number"].ToString();
                        corporation_txt.Content = dt.Rows[0]["corporation"];
                        trip_id.Content = dt.Rows[0]["trip_number"];
                        trip_driver.Content = dt.Rows[0]["driver_name"];
                        trip_open_date.Text = dt.Rows[0]["load_date"].ToString();
                        trip_open_origin.Text = dt.Rows[0]["origin"].ToString();
                        trip_open_detination.Text = dt.Rows[0]["destination"].ToString();
                        trip_starting_km.Text = dt.Rows[0]["starting_km"].ToString();
                        trip_load_weight.Text = dt.Rows[0]["load_weight"].ToString();
                        trip_unload_date.Text = dt.Rows[0]["unload_date"].ToString();
                        trip_end_km.Text = dt.Rows[0]["ending_km"].ToString();
                        trip_total_km.Content = dt.Rows[0]["total_km"];
                        trip_total_diesel.Content = dt.Rows[0]["trip_diesel"];
                        trip_diesel_amount.Content = dt.Rows[0]["diesel_amount"];
                        trip_total_mileage.Content = dt.Rows[0]["trip_mileage"];
                        trip_unload_weight.Text = dt.Rows[0]["unload_weight"].ToString();
                        trip_number.Text = dt.Rows[0]["vehicle_number"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Selected vehicle is Not Unloaded");
                    }
                    con.close_connection();
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
               
            }
            else
            {
                MessageBox.Show("Please Select Trip Number From DropDown List");
            }           
            
        }


        private void lpg_trip_expense_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lpg_trip_expense_panel.Visibility = System.Windows.Visibility.Visible;
            other_amount.Text = "0"; rto_amount.Text = "0"; toll_amount.Text = "0";
        }

       

        void cancel_trip_click(object sender, RoutedEventArgs e)
        {
            if (trip_closed_checked.IsChecked == true)
            {
                MessageBoxResult mr = MessageBox.Show("Are You Sure, Want to Cancel This Trip Details", "Cancel", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (mr == MessageBoxResult.OK)
                {

                    try
                    {
                       
                        trip_unload_date.Text = ""; trip_end_km.Text = ""; trip_total_km.Content = ""; trip_total_diesel.Content = ""; trip_diesel_amount.Content = ""; trip_total_mileage.Content = ""; trip_unload_weight.Text = ""; trip_number.Text = "";
                        vehicle_numbers.Text = ""; corporation_txt.Content = ""; trip_id.Content = ""; trip_driver.Content = ""; trip_open_date.Text = ""; trip_open_origin.Text = ""; trip_open_detination.Text = ""; trip_starting_km.Text = ""; trip_load_weight.Text = "";
                        lpg_trip_advance.Text = ""; lph_trip_frieght.Text = ""; lpg_trip_expenses.Content = ""; lpg_trip_BALANCE.Content = ""; lpg_trip_profit.Content = ""; lpg_trip_pay_type.Text = ""; trip_close_number.Text = "";
                        lpg_trip_close_img1.Visibility = System.Windows.Visibility.Hidden;
                        lpg_trip_close_img2.Visibility = System.Windows.Visibility.Visible;
                        i = 0;
                        Array.Clear(type, 0, type.Length);
                        Array.Clear(place, 0, place.Length);
                        Array.Clear(litter, 0, litter.Length);
                        Array.Clear(price, 0, price.Length);
                        Array.Clear(date, 0, date.Length);
                        Array.Clear(no_of_time, 0, no_of_time.Length);
                        Array.Clear(tot_price, 0, tot_price.Length);
                        Array.Clear(card_id, 0, card_id.Length);
                        time1.Start();
                        chr = "e";
                    }
                    catch(OdbcException ex)
                    {
                        MessageBox.Show("Error :"+ex);
                    }
                   
                }
                else if (mr == MessageBoxResult.Cancel)
                {

                }

            }
            else
            {               
                trip_unload_date.Text = ""; trip_end_km.Text = ""; trip_total_km.Content = ""; trip_total_diesel.Content = ""; trip_diesel_amount.Content = ""; trip_total_mileage.Content = ""; trip_unload_weight.Text = ""; trip_number.Text = "";
                vehicle_numbers.Text = ""; corporation_txt.Content = ""; trip_id.Content = ""; trip_driver.Content = ""; trip_open_date.Text = ""; trip_open_origin.Text = ""; trip_open_detination.Text = ""; trip_starting_km.Text = ""; trip_load_weight.Text = "";
                lpg_trip_advance.Text = ""; lph_trip_frieght.Text = ""; lpg_trip_expenses.Content = "";  lpg_trip_BALANCE.Content = ""; lpg_trip_profit.Content = ""; lpg_trip_pay_type.Text = ""; trip_close_number.Text = "";
            }

        }

        private void from_card_Checked(object sender, RoutedEventArgs e)
        {
            diesel_card_id.IsEnabled = true;
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select card_id from vechicle_details where vehicle_number='" + trip_number.Text + "'", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string s = dt.Rows[0]["card_id"].ToString();
                if (s.Equals(""))
                {
                    MessageBox.Show("Please Insert Card number to this Vehicle or Type your self");
                }
                else
                {
                    diesel_card_id.Text = s;
                }
            }
            try
            {
                if (!string.IsNullOrWhiteSpace(diesel_card_id.Text))
                {
                    OdbcCommand cmd1 = new OdbcCommand("select sum(credit_amount)as tot from credit_details where card_id='" + diesel_card_id.Text + "' and bool=0", con.conn);
                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        string ctda = dt1.Rows[0]["tot"].ToString();

                        if (ctda != "")
                        {
                            bal = Convert.ToDouble(dt1.Rows[0]["tot"]);
                            OdbcCommand cmd3 = new OdbcCommand("select sum(total_cost)as tot_cost from diesel_balance_sheet where card_id='" + diesel_card_id.Text + "'", con.conn);
                            OdbcDataAdapter da2 = new OdbcDataAdapter(cmd3);
                            DataTable dt2 = new DataTable();
                            da2.Fill(dt2);
                            if (dt2.Rows.Count > 0)
                            {
                                string zxc = dt2.Rows[0]["tot_cost"].ToString();
                                if (zxc == "")
                                {
                                    balance = 0;
                                }
                                else
                                {
                                    balance = Convert.ToDouble(dt2.Rows[0]["tot_cost"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Card Doesn't Exist");
                            }
                        }
                        else
                        {
                            bal = 0;
                        }
                        card_balance.Content = (bal - balance).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Card Doesn't Exist For This Vehicle");
                    }
                    con.close_connection();
                }
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
        }
               
           
        

        private void from_advance_Checked(object sender, RoutedEventArgs e)
        {
            diesel_card_id.IsEnabled = false;
            diesel_card_id.Text = "ADVANCE";
            card_balance.Content = "";
        }

        private void diesel_total_calculate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(string.IsNullOrWhiteSpace(diesel_price.Text))
                {
                    diesel_price.Text = "0";
                }
                if (from_card.IsChecked == true && !string.IsNullOrWhiteSpace(fill_place.Text) && !string.IsNullOrWhiteSpace(diesel_litter.Text) && !string.IsNullOrWhiteSpace(diesel_price.Text) && !string.IsNullOrWhiteSpace(fill_date.Text)&&!string.IsNullOrWhiteSpace(diesel_card_id.Text))
                {
                    try
                    {                       
                       
                        double td = Convert.ToDouble(diesel_litter.Text) * Convert.ToDouble(diesel_price.Text);
                        total_price.Content = td.ToString();                        
                        card_tot =Convert.ToDouble(card_balance.Content)- td;                        
                        if (Convert.ToDouble(card_balance.Content) < td)
                        {
                            MessageBoxResult mbr = MessageBox.Show("Card balance is Below the Amount", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            if (mbr == MessageBoxResult.OK)
                            {
                                //diesel_price.Text = "";
                                //diesel_litter.Text = "";
                                //diesel_price.Focus();
                                //da = 0;
                                //tl = 0;
                                //bal = 0;
                                //balance = 0;
                                //no_of_time = 1;
                                //total_price.Content = "";                              
                            }

                        }
                        else
                        {
                            card_balance.Content = card_tot.ToString();
                            tl += Convert.ToDouble(diesel_litter.Text);
                            da += td;
                            type[i] = "CARD";
                            place[i] = fill_place.Text;
                            litter[i] = Convert.ToDouble(diesel_litter.Text);
                            price[i] = Convert.ToDouble(diesel_price.Text);
                            date[i] = Convert.ToDateTime(fill_date.Text).ToString("yyyy/MM/dd");
                            no_of_time[i] = i+1;
                            tot_price[i] = td;
                            card_id[i] = diesel_card_id.Text;
                            i += 1;                                                      
                        }                        
                        fill_place.Text = ""; fill_date.Text = ""; diesel_price.Text = ""; diesel_litter.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Error from Diesel Total Cost Calculation");
                    }
                }
                else if (from_advance.IsChecked == true&&!string.IsNullOrWhiteSpace(fill_place.Text)&&!string.IsNullOrWhiteSpace(diesel_litter.Text)&&!string.IsNullOrWhiteSpace(diesel_price.Text)&&!string.IsNullOrWhiteSpace(fill_date.Text) && !string.IsNullOrWhiteSpace(diesel_card_id.Text))
                {
                    
                    tl += Convert.ToDouble(diesel_litter.Text);
                    double td = Convert.ToDouble(diesel_litter.Text) * Convert.ToDouble(diesel_price.Text);
                    total_price.Content = td.ToString();
                    da += td;
                    type[i] = "ADVANCE";
                    place[i] = fill_place.Text;
                    litter[i] = Convert.ToDouble(diesel_litter.Text);
                    price[i] = Convert.ToDouble(diesel_price.Text);
                    date[i] = Convert.ToDateTime(fill_date.Text).ToString("yyyy/MM/dd");
                    no_of_time[i] = i+1;
                    tot_price[i] = td;
                    card_id[i] = diesel_card_id.Text;
                    i += 1;                                             
                     fill_place.Text = ""; fill_date.Text = ""; diesel_price.Text = ""; diesel_litter.Text = "";
                }
                else
                {
                    MessageBox.Show("Should Fill All Field And Select Card or Advance");
                }

            }

        }

        private void diesel_back_click(object sender, RoutedEventArgs e)
        {
           
                try
                {
                    Array.Clear(type, 0, type.Length);
                    Array.Clear(place, 0, place.Length);
                    Array.Clear(litter, 0, litter.Length);
                    Array.Clear(price, 0, price.Length);
                    Array.Clear(date,0,date.Length);
                    Array.Clear(no_of_time, 0, no_of_time.Length);
                    Array.Clear(tot_price, 0, tot_price.Length);
                    Array.Clear(card_id, 0, card_id.Length);
                    i = 0;
                    diesel_calculation.Visibility = System.Windows.Visibility.Hidden;
                    diesel_price.Text = "";
                    diesel_litter.Text = "";
                    diesel_price.Focus();
                    da = 0;
                    tl = 0;
                    bal = 0;
                    balance = 0;                    
                    total_price.Content = "";
                }
                catch
                {
                    MessageBox.Show("Text Doesn't Clear");
                }            

        }

        private void diesel_calculation_done_click(object sender, RoutedEventArgs e)
        {

            if (tl != 0 & da != 0)
            {
                try
                {                                                         
                    diesel_calculation.Visibility = System.Windows.Visibility.Hidden;
                    trip_total_diesel.Content = tl.ToString();
                    trip_diesel_amount.Content = da.ToString();
                    trip_total_mileage.Content =Math.Round((Convert.ToDouble(trip_total_km.Content) / tl),2) .ToString();
                    from_card.IsChecked = false;
                    from_advance.IsChecked = false;
                    total_price.Content = ""; tl = 0; da = 0; diesel_card_id.Text = "";                    
                   
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
               
            }
            else
            {
                MessageBox.Show("Should Fill All Field");
            }

        }

        

       


        private void toll_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(toll_amount.Text))
                {
                    double t = Convert.ToDouble(toll_amount.Text) + Convert.ToDouble(toll_total.Text);
                    toll_total.Text = t.ToString();
                    tollamount[t_count-1] = t;
                    tollplace[t_count - 1] = toll_place.Text;                   
                    toll_amount.Text = "0"; toll_place.Text = ""; t_count += 1;
                }
                else if(string.IsNullOrWhiteSpace(toll_amount.Text))
                {
                    double t = Convert.ToDouble(toll_total.Text) + 0;
                    toll_total.Text = t.ToString();
                    tollamount[t_count - 1] = t;
                    tollplace[t_count - 1] = toll_place.Text;
                    toll_amount.Text = "0"; toll_place.Text = ""; t_count += 1;
                }
                else
                {
                    MessageBox.Show("Should fill all text field");
                }

            }

        }

        private void rto_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(rto_amount.Text))
                {
                    double t = Convert.ToDouble(rto_amount.Text) + Convert.ToDouble(rto_total.Text);
                    rto_total.Text = t.ToString();
                    rtoamount[r_count - 1] = t;
                    rtoplace[r_count - 1] = rto_place.Text;                   
                    rto_amount.Text = "0"; rto_place.Text = ""; r_count += 1;
                }
                else if(string.IsNullOrWhiteSpace(rto_amount.Text))
                {
                    double t = Convert.ToDouble(rto_total.Text) + 0;
                    rto_total.Text = t.ToString();
                    rtoamount[r_count - 1] = t;
                    rtoplace[r_count - 1] = rto_place.Text;
                    rto_amount.Text = "0"; rto_place.Text = ""; r_count += 1;
                }
                else
                {
                    MessageBox.Show("Should fill all text field");
                }

            }
        }

        private void other_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(other_amount.Text))
                {
                    double t = Convert.ToDouble(other_amount.Text) + Convert.ToDouble(other_total.Text);
                    other_total.Text = t.ToString();
                    otheramount[o_count - 1] = t;
                    otherreason[o_count - 1] = other_reason.Text;                   
                    other_amount.Text = "0"; other_reason.Text = ""; o_count += 1;
                }
                else if(string.IsNullOrWhiteSpace(other_amount.Text))
                {
                    double t = Convert.ToDouble(other_total.Text) + 0;
                    other_total.Text = t.ToString();
                    otheramount[o_count - 1] = t;
                    otherreason[o_count - 1] = other_reason.Text;
                    other_amount.Text = "0"; other_reason.Text = ""; o_count += 1;
                }
                else
                {
                    MessageBox.Show("Should fill all text field");
                }
            }
        }


        private void expense_done_Click(object sender, RoutedEventArgs e)
        {
            Double A1 = 0;
            //Double C1 = 0;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select sum(total_cost) as amount from diesel_balance_sheet where trip_number='" + trip_id.Content + "' and vehicle_number='" + trip_number.Text + "' and withdraw='ADVANCE'", con.conn);
                OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    string am = DT.Rows[0]["amount"].ToString();
                    if (!string.IsNullOrWhiteSpace(am))
                    {
                        A1 = Convert.ToDouble(am);
                    }
                    else
                    {
                        A1 = 0;
                    }

                }
                else
                {

                }
                //OdbcCommand cmd1 = new OdbcCommand("select sum(total_cost) as amount from diesel_balance_sheet where trip_number='" + trip_id.Content + "' and vehicle_number='" + trip_number.Text + "' and withdraw='CARD'", con.conn);
                //OdbcDataAdapter DA1 = new OdbcDataAdapter(cmd1);
                //DataTable DT1 = new DataTable();
                //DA1.Fill(DT1);
                //if (DT1.Rows.Count > 0)
                //{
                //    string am = DT1.Rows[0]["amount"].ToString();
                //    if (!string.IsNullOrWhiteSpace(am))
                //    {
                //        C1 = Convert.ToDouble(am);
                //    }
                //    else
                //    {
                //        C1 = 0;
                //    }
                //}
                //else
                //{

                //}
                con.close_connection();
                if (lph_trip_frieght.Text != null & trip_diesel_amount.Content != null & lpg_trip_advance.Text != null)
                {
                    double d = Convert.ToDouble(toll_total.Text) + Convert.ToDouble(rto_total.Text) + Convert.ToDouble(other_total.Text) + Convert.ToDouble(val11.Text) + Convert.ToDouble(val12.Text) + Convert.ToDouble(val13.Text) + Convert.ToDouble(val14.Text) + Convert.ToDouble(val15.Text) + Convert.ToDouble(val16.Text);
                    lpg_trip_expenses.Content = d.ToString();
                    lpg_trip_profit.Content = Convert.ToDouble(lph_trip_frieght.Text) - d - Convert.ToDouble(trip_diesel_amount.Content);
                    lpg_trip_BALANCE.Content = Convert.ToDouble(lpg_trip_advance.Text) - d - A1;                  
                    lpg_trip_expense_panel.Visibility = System.Windows.Visibility.Hidden;
                    toll_total.Text = "0"; rto_total.Text = "0"; other_total.Text = "0";                   
                }

                else
                {
                    MessageBox.Show(" ENTER TRIP FRIEGHT AND ADVANCE");
                }
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }


        }
 

        void open_control_hide()
        {
            /* ioc_rbtn.IsEnabled = false; bpc_rbtn.IsEnabled = false; hpc_rbtn.IsEnabled = false;*/
            trip_load_weight.IsEnabled = false;
            vehicle_numbers.IsEnabled = false; trip_open_date.IsEnabled = false; trip_open_origin.IsEnabled = false; trip_open_detination.IsEnabled = false; trip_starting_km.IsEnabled = false;
        }
        void open_control_view()
        {
            ioc_rbtn.IsEnabled = true; bpc_rbtn.IsEnabled = true; hpc_rbtn.IsEnabled = true; trip_load_weight.IsEnabled = true;
            vehicle_numbers.IsEnabled = true; trip_open_date.IsEnabled = true; trip_open_origin.IsEnabled = true; trip_open_detination.IsEnabled = true; trip_starting_km.IsEnabled = true;
        }
        void unload_control_hide()
        {
            trip_number.IsEnabled = false; trip_unload_date.IsEnabled = false; trip_end_km.IsEnabled = false; total_diesel.IsEnabled = false; trip_unload_weight.IsEnabled = false;

        }
        void unload_control_view()
        {
            trip_number.IsEnabled = true; trip_unload_date.IsEnabled = true; trip_end_km.IsEnabled = true; total_diesel.IsEnabled = true; trip_unload_weight.IsEnabled = true;
        }

        private void trip_expense_back_click(object sender, RoutedEventArgs e)
        {
            Array.Clear(tollamount, 0, tollamount.Length);
            Array.Clear(tollplace, 0, tollplace.Length);
            Array.Clear(rtoamount, 0, rtoamount.Length);
            Array.Clear(rtoplace, 0, rtoplace.Length);
            Array.Clear(otheramount, 0, otheramount.Length);
            Array.Clear(otherreason, 0, otherreason.Length);
            toll_total.Text = ""; rto_total.Text = ""; other_total.Text = ""; val11.Text = ""; val12.Text = ""; val13.Text = ""; val14.Text = ""; val15.Text = ""; val16.Text = "";
            t_count = 1; r_count = 1; o_count = 1;
            lpg_trip_expense_panel.Visibility = System.Windows.Visibility.Hidden;
        }

        void close_control_hide()
        {
            trip_close_number.IsEnabled = false; lph_trip_frieght.IsEnabled = false; lpg_trip_advance.IsEnabled = false; lpg_expense.IsEnabled = false; lpg_trip_pay_type.IsEnabled = false; 
        }
        void close_control_view()
        {
            trip_close_number.IsEnabled = true; lph_trip_frieght.IsEnabled = true; lpg_trip_advance.IsEnabled = true; lpg_expense.IsEnabled = true; lpg_trip_pay_type.IsEnabled = true; 
        }

        void Litter_Price_PreviewTextInput(object sender,TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender,e);
        }

        void Load_Vehicle_Number_PreviewKeydown(object sender,KeyEventArgs e)
        {
            int len = 0;
            string s = vehicle_numbers.Text;
            if (!string.IsNullOrWhiteSpace(vehicle_numbers.Text))
            {
                
                len = vehicle_numbers.Text.Length;
            }
            else
            {
                len = 0;
            }
            if (len <= 2)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isletter = char.IsLetter(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Should Enter First Two Letter Character");
                        vehicle_numbers.Text = "";
                    }
                }
            }
            if (len>10)
            {
                if (e.Key!=Key.Back)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }
               
            }
        }
        void Unload_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            string s = trip_number.Text;
            if (!string.IsNullOrWhiteSpace(trip_number.Text))
            {

                len = trip_number.Text.Length;
            }
            else
            {
                len = 0;
            }
            if (len <= 2)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isletter = char.IsLetter(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Should Enter First Two Letter Character");
                        trip_number.Text = "";
                    }
                }
            }
            if (len > 10)
            {
                if (e.Key != Key.Back)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }

            }
        }
        void Close_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(trip_close_number.Text))
            {

                len = trip_close_number.Text.Length;
            }
            else
            {
                len = 0;
            }

            if (len > 16)
            {
                if (e.Key != Key.Back)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }

            }
        }

        private void Unload_Wages_GotFocus(object sender, RoutedEventArgs e)
        {
            val12.Text = "";
        }
        void Unload_Wages_keydown(object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val12.Text))
                {
                    val12.Text = "0";
                }
            }
           
        }
        void Load_Wages_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val11.Text))
                {
                    val11.Text = "0";
                }
            }
           
        }
        void Load_Wages_Gotfocus(object sender,RoutedEventArgs e)
        {
            val11.Text = "";
        }
        void Phone_Wages_Gotfocus(object sender,RoutedEventArgs e)
        {
            val13.Text = ""; 
        }
        void Phone_Wages_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val13.Text))
                {
                    val13.Text = "0";
                }
            }
            
        }
        void Spares_Wages_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val14.Text))
                {
                    val14.Text = "0";
                }
            }
           
        }
        void Spares_Wages_Gotfocus(object sender,RoutedEventArgs e)
        {
            val14.Text = "";
        }
        void Driver_Wages_Gotfocus(object sender,RoutedEventArgs e)
        {
            val15.Text = "";
        }
        void Driver_Wages_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val15.Text))
                {
                    val15.Text = "0";
                }
            }
           
        }
        void Clener_Wages_Gotfocus(object sender,RoutedEventArgs e)
        {
            val16.Text = "";
        }
        void Cleaner_Wages_keydown(object sender,KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val16.Text))
                {
                    val16.Text = "0";
                }
            }
           
        }
         void Toll_Amount_Gotfocus(object sender,RoutedEventArgs e)
        {
            toll_amount.Text = "";
        }
        void Rto_Amount_Gotfocus(object sender, RoutedEventArgs e)
        {
            rto_amount.Text = "";
        }
        void Other_Amount_Gotfocus(object sender, RoutedEventArgs e)
        {
            other_amount.Text = "";
        }
        void Diesel_litter_Gotfocus(object sender, RoutedEventArgs e)
        {
            diesel_litter.Text = "";
        }
        void Diesel_Litter_keydown(object sender,KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(diesel_litter.Text))
                {
                    diesel_litter.Text = "0";
                }
            }          
        }

        void Disel_Price_Gotfocus(object sender, RoutedEventArgs e)
        {
            diesel_price.Text = "";
        }
        void Load_Weight_previewTextInput(object sender,TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender,e);
        }
        void Unload_Weight_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }

        private void vehicle_numbers_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {    if(vehicle_numbers.Text != null &&!string.IsNullOrWhiteSpace(trip_open_date.Text))
                {
                    String l = vehicle_numbers.Text; 
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        string user = Properties.Settings.Default.User;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            vehicle_numbers.Text = "";
                        }
                        else if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("select trip_status from lpg_trip_details where vehicle_number='" + vehicle_numbers.Text + "'AND trip_status='RUNNING'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                String S = null;
                                if (dt.Rows.Count > 0)
                                {
                                    S = dt.Rows[0]["trip_status"].ToString();

                                    S = trip_number.ToString();
                                    if (S.Equals("RUNNING"))
                                    {


                                        MessageBox.Show("This vehicle is Running, Select another vehicle");

                                    }


                                }
                                else
                                {
                                    X1 = Convert.ToDateTime(trip_open_date.Text).ToString("dd");
                                    X2 = Convert.ToDateTime(trip_open_date.Text).ToString("MM");
                                    X3 = Convert.ToDateTime(trip_open_date.Text).ToString("yy");
                                    String SUB_STR = X1 + X2 + X3;
                                    OdbcCommand cmd1 = new OdbcCommand("select trip_number from lpg_trip_details where vehicle_number='" + vehicle_numbers.Text + "' AND trip_number REGEXP  '^" + SUB_STR + "'", con.conn);
                                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                    DataTable dt1 = new DataTable();
                                    da1.Fill(dt1);
                                    if (dt1.Rows.Count > 0)
                                    {

                                        MessageBox.Show("TRIP NUMBER EXIST, Select Another Date");

                                    }
                                    else
                                    {
                                        trip_id.Content = ""; trip_driver.Content = "";
                                        string s = vehicle_numbers.Text.ToString();



                                        trip_id.Content = SUB_STR + s;
                                        Connection con1 = new Connection();
                                        con1.open_connection();
                                        OdbcCommand cmd2 = new OdbcCommand("select driver_name from vechicle_details where vehicle_number='" + vehicle_numbers.Text + "' and status='CLOSED'", con1.conn);
                                        OdbcDataAdapter DA = new OdbcDataAdapter(cmd2);
                                        DataTable dt2 = new DataTable();
                                        DA.Fill(dt2);
                                        if (dt2.Rows.Count > 0)
                                        {
                                            trip_driver.Content = dt2.Rows[0]["driver_name"];
                                        }
                                        else
                                        {
                                            MessageBox.Show("Driver id does not Exist for this Vehicle");
                                            trip_id.Content = "";
                                        }
                                        con1.close_connection();
                                    }
                                }

                                con.close_connection();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Access Denied");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Invalid Vehicle Number Format");
                    }
                }   
                else
                {
                    MessageBox.Show("Select Vehicle Number and Date");
                }         
               
            }
        }

        private void trip_starting_km_TextChanged(object sender, TextChangedEventArgs e)
        {
            Trip_Load tl = new Trip_Load();
            string MSG = tl.Startingkm_Textchanged(trip_starting_km.Text);
            if (MSG != "NO")
            {
                trip_starting_km.Text = string.Empty;
            }
        }

        private void diesel_card_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Tab||e.Key==Key.Enter)
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    if (!string.IsNullOrWhiteSpace(diesel_card_id.Text))
                    {
                        OdbcCommand cmd1 = new OdbcCommand("select sum(credit_amount)as tot from credit_details where card_id='" + diesel_card_id.Text + "' and bool=0", con.conn);
                        OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            string ctda = dt1.Rows[0]["tot"].ToString();

                            if (ctda != "")
                            {
                                bal = Convert.ToDouble(dt1.Rows[0]["tot"]);
                                OdbcCommand cmd3 = new OdbcCommand("select sum(total_cost)as tot_cost from diesel_balance_sheet where card_id='" + diesel_card_id.Text + "'", con.conn);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd3);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    string zxc = dt2.Rows[0]["tot_cost"].ToString();
                                    if (zxc == "")
                                    {
                                        balance = 0;
                                    }
                                    else
                                    {
                                        balance = Convert.ToDouble(dt2.Rows[0]["tot_cost"]);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Card Doesn't Exist");
                                }
                            }
                            else
                            {
                                bal = 0;
                            }
                            card_balance.Content = (bal - balance).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Card Doesn't Exist For This Vehicle");
                        }
                        con.close_connection();
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
            }
           
        }

        private void diesel_card_id_GotFocus(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select card_id from diesel_card_details",con.conn);
            OdbcDataReader dr = cmd.ExecuteReader();
            diesel_card_id.Items.Clear();
            while (dr.Read())
            {
                diesel_card_id.Items.Add(dr[0]);
            }
        }

        void Load_Weight_Textchanged(object sender, TextChangedEventArgs e)
        {
            string s = trip_load_weight.Text; 
            int len = s.Length;
            if (len <= 4)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isdigit = char.IsDigit(s[i]);
                    if (isdigit == true)
                    {
                        if (i == 1)
                        {
                            double d = Convert.ToDouble(trip_load_weight.Text);
                            if(d>20)
                            {
                                System.Media.SystemSounds.Beep.Play();
                                e.Handled = true;
                                MessageBox.Show("Should Enter Value Below 20");
                                trip_load_weight.Text = "";
                            }
                            
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Should Enter Number only");
                        //trip_load_weight.Text = "";
                    }
                }
            }
        }
        void Unload_Weight_Textchanged(object sender,TextChangedEventArgs e)
        {
            string s = trip_unload_weight.Text;
            int len = s.Length;
            if (len <= 4)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isdigit = char.IsDigit(s[i]);
                    if (isdigit == true)
                    {
                        if(i==1)
                        {
                            double d = Convert.ToDouble(trip_unload_weight.Text);
                            if (d > 20)
                            {
                                System.Media.SystemSounds.Beep.Play();
                                e.Handled = true;
                                MessageBox.Show("Should Enter Value Below 20");
                                trip_unload_weight.Text="";
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Should Enter Number only");
                        //trip_unload_weight.Text = "";
                    }
                }
            }
        }
    }
}
