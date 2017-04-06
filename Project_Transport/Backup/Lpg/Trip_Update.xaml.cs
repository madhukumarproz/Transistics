using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Linq;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Trip_Update.xaml
    /// </summary>
    public partial class Trip_Update : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        string chr = null;
        int no = 0;
        String type = null;
        int array_size = 0;
        string[] date=new string[50] ;
        int[] litter=new int[50] ;
        double[] price = new double[50];
        double[] amount = new double[50];
        int[] count = new int[50];
        int inc = 0;
        string[] t_place = new string[50];
        double[] t_amnt = new double[50];
        int[] t_count = new int[50];
        int t_inc = 0;
        string[] r_place = new string[50];
        double[] r_amnt = new double[50];
        int[] r_count = new int[50];
        int r_inc = 0;
        string[] o_place = new string[50];
        double[] o_amoun=new double[50];
        int[] o_count = new int[50];
        int o_inc = 0;
        int d_index = 0;
        
        public Trip_Update()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            lpg_trip_update_imgs2.Visibility = System.Windows.Visibility.Hidden;
            lpg_trip_cancel_imgs2.Visibility = System.Windows.Visibility.Hidden;
            lpg_diesel_update_panel.Visibility = System.Windows.Visibility.Hidden;
            trip_expense_update_panel.Visibility = System.Windows.Visibility.Hidden;
            balance_update_img2.Visibility = System.Windows.Visibility.Hidden;
        }

       

        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {
                if (chr == "u")
                {
                    lpg_trip_update_imgs1.Visibility = System.Windows.Visibility.Visible;
                    lpg_trip_update_imgs2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
                else if (chr == "c")
                {
                    lpg_trip_cancel_imgs1.Visibility = System.Windows.Visibility.Visible;
                    lpg_trip_cancel_imgs2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
                else if(chr=="b")
                {
                    balance_update_img1.Visibility = System.Windows.Visibility.Visible;
                    balance_update_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
            }
            ii++;
        }

        void update_trip_open_checked(Object sender, RoutedEventArgs e)
        {
            try
            {
                Get_String g = new Get_String();
                g.Vehicle_Numbers = "";
                g.Update_Driver_Name = "";
                g.Update_Corporation = "";
                g.Update_Origin = "";
                g.Update_Destination = "";
                g.Update_Load_Weight = "";
                this.DataContext = g;
                Connection con = new Connection();
                con.open_connection();
                update_trip_numbers.Items.Clear();
                OdbcCommand cmd = new OdbcCommand("select trip_number from lpg_trip_details where trip_status='RUNNING'", con.conn);
                OdbcDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    update_trip_numbers.Items.Add(DR[0]);
                }
                update_trip_starting_km.IsEnabled = true;
                update_trip_unload_date.IsEnabled = false;
                update_trip_end_km.IsEnabled = false;
                update_trip_total_km.IsEnabled = false;
                update_trip_total_diesel.IsEnabled = false;
                update_trip_diesel_amount.IsEnabled = false;
                update_trip_total_mileage.IsEnabled = false;
                update_trip_unload_weight.IsEnabled = false;
                update_lph_trip_frieght.IsEnabled = false;
                update_lpg_trip_advance.IsEnabled = false;
                update_lpg_trip_expenses.IsEnabled = false;
                update_lpg_trip_profit.IsEnabled = false;
                update_lpg_trip_BALANCE.IsEnabled = false;
                update_lpg_trip_pay_type.IsEnabled = false;
                update_total_diesel.IsEnabled = false;
                update_lpg_expense.IsEnabled = false;
                con.close_connection();
            }

            catch
            {
                MessageBox.Show("TRIP NUMBER NOT EXIST");

            }

        }


        void update_trip_close_checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Get_String g = new Get_String();
                g.Vehicle_Numbers = "";
                g.Update_End_Km = "";
                g.Update_Unload_Weight = "";
                g.Update_Frieght = "";
                g.Update_Advance = "";
                g.Pay_Type = "";
                g.Update_Amount = "";              
                g.Date = "";
                g.Update_Litter = "";
                g.Update_Price = "";
                g.Update_Load_Wages = "";
                g.Update_Load_Weight = "";
                g.Update_Phone = "";
                g.Update_Spares = "";
                g.Update_Driver_Wages = "";
                g.Update_Clener_Wages = "";
                g.Update_Toll_Place = "";
                g.Update_Toll_Amount = "";
                g.Update_Rto_Place = "";
                g.Update_Rto_Amount = "";
                g.Update_Other_Reason = "";
                g.Update_Other_Amount = "";                
                g.Price = "";
                g.Litter = "";
                //g.Amount = "";
                g.Date = "";                
                this.DataContext = g;
                Connection con = new Connection();
                con.open_connection();
                update_trip_numbers.Items.Clear();
                OdbcCommand cmd = new OdbcCommand("select trip_number from lpg_trip_details where trip_status='CLOSED'", con.conn);
                OdbcDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    update_trip_numbers.Items.Add(DR[0]);
                }
                update_trip_starting_km.IsEnabled = false;
                update_trip_unload_date.IsEnabled = true;
                update_trip_end_km.IsEnabled = true;
                update_trip_total_km.IsEnabled = false;
                update_trip_total_diesel.IsEnabled = false;
                update_trip_diesel_amount.IsEnabled = false;
                update_trip_total_mileage.IsEnabled = false;
                update_trip_unload_weight.IsEnabled = true;
                update_lph_trip_frieght.IsEnabled = true;
                update_lpg_trip_advance.IsEnabled = true;
                update_lpg_trip_expenses.IsEnabled = false;
                update_lpg_trip_profit.IsEnabled = false;
                update_lpg_trip_BALANCE.IsEnabled = false;
                update_lpg_trip_pay_type.IsEnabled = true;
                update_total_diesel.IsEnabled = true;
                update_lpg_expense.IsEnabled = true;
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("TRIP NUMBER NOT EXIST");

            }
        }


        void update_trip_numbers_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {


                if (update_trip_checked.IsChecked == true & !string.IsNullOrWhiteSpace(update_trip_numbers.Text))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select corporation,driver_name,vehicle_number,load_date,origin,destination,starting_km,load_weight from lpg_trip_details where trip_number='" + update_trip_numbers.Text + "' and trip_status='RUNNING'", con.conn);
                        OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                        DataTable DT = new DataTable();
                        DA.Fill(DT);
                        if (DT.Rows.Count > 0)
                        {
                            update_corporation_txt.Text = DT.Rows[0]["corporation"].ToString();
                            update_trip_driver.Text = DT.Rows[0]["driver_name"].ToString();
                            update_trip_id.Text = DT.Rows[0]["vehicle_number"].ToString();
                            update_trip_open_date.Text = DT.Rows[0]["load_date"].ToString();
                            update_trip_open_origin.Text = DT.Rows[0]["origin"].ToString();
                            update_trip_open_detination.Text = DT.Rows[0]["destination"].ToString();
                            update_trip_starting_km.Text = DT.Rows[0]["starting_km"].ToString();
                            update_trip_load_weight.Text = DT.Rows[0]["load_weight"].ToString();
                            con.close_connection();
                        }
                        else
                        {
                            MessageBox.Show("Trip information not exist");
                        }
                    }
                    catch(OdbcException ex)
                    {
                        MessageBox.Show("Error :"+ex);
                    }
                }
                else if (update_trip_closed_checked.IsChecked == true & !string.IsNullOrWhiteSpace(update_trip_numbers.Text))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select corporation,driver_name,vehicle_number,load_date,origin,destination,starting_km,load_weight,unload_weight,unload_date,ending_km,total_km,trip_diesel,diesel_amount,trip_mileage,trip_advance,trip_frieght,trip_expense,trip_balance,trip_profit,payment_type from lpg_trip_details where trip_number='" + update_trip_numbers.Text + "' and trip_status='CLOSED'", con.conn);
                        OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                        DataTable DT = new DataTable();
                        DA.Fill(DT);
                        if (DT.Rows.Count > 0)
                        {
                            update_corporation_txt.Text = DT.Rows[0]["corporation"].ToString();
                            update_trip_driver.Text = DT.Rows[0]["driver_name"].ToString();
                            update_trip_id.Text = DT.Rows[0]["vehicle_number"].ToString();
                            update_trip_open_date.Text = DT.Rows[0]["load_date"].ToString();
                            update_trip_open_origin.Text = DT.Rows[0]["origin"].ToString();
                            update_trip_open_detination.Text = DT.Rows[0]["destination"].ToString();
                            update_trip_starting_km.Text = DT.Rows[0]["starting_km"].ToString();
                            update_trip_load_weight.Text = DT.Rows[0]["load_weight"].ToString();
                            update_trip_unload_date.Text = DT.Rows[0]["unload_date"].ToString();
                            update_trip_end_km.Text = DT.Rows[0]["ending_km"].ToString();
                            update_trip_total_km.Text = DT.Rows[0]["total_km"].ToString();
                            update_trip_total_diesel.Text = DT.Rows[0]["trip_diesel"].ToString();
                            update_trip_diesel_amount.Text = DT.Rows[0]["diesel_amount"].ToString();
                            update_trip_total_mileage.Text = DT.Rows[0]["trip_mileage"].ToString();
                            update_trip_unload_weight.Text = DT.Rows[0]["unload_weight"].ToString();
                            update_lph_trip_frieght.Text = DT.Rows[0]["trip_frieght"].ToString();
                            update_lpg_trip_advance.Text = DT.Rows[0]["trip_advance"].ToString();
                            update_lpg_trip_expenses.Text = DT.Rows[0]["trip_expense"].ToString();
                            update_lpg_trip_profit.Text = DT.Rows[0]["trip_profit"].ToString();
                            update_lpg_trip_BALANCE.Text = DT.Rows[0]["trip_balance"].ToString();
                            update_lpg_trip_pay_type.Text = DT.Rows[0]["payment_type"].ToString();
                            con.close_connection();
                        }
                        else
                        {
                            MessageBox.Show("Trip information not exist");
                        }
                    }
                    catch(OdbcException ex)
                    {
                        MessageBox.Show("Error :"+ex);
                    }
                }
                else
                {
                    MessageBox.Show("Please select radio button");
                }
            }
        }


        void update_trip_starting_km_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(update_trip_numbers.Text)&&!string.IsNullOrWhiteSpace(update_trip_id.Text))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select max(ending_km) from lpg_trip_details where vehicle_number='" + update_trip_id.Text + "' and trip_number='" + update_trip_numbers.Text + "'", con.conn);
                        OdbcDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            int n = Convert.ToInt32(dr[0]);
                            int cur = Convert.ToInt32(update_trip_starting_km.Text);
                            if (cur > n)
                            {

                            }
                            else if (n == -1 | cur == -1)
                            {
                                update_trip_starting_km.Text = "-1";
                            }
                            else if (update_trip_starting_km.Text == "")
                            {
                                update_trip_starting_km.Text = "-1";
                            }
                            else
                            {
                                MessageBoxResult mr = MessageBox.Show("Trip starting km is below the previous ending km", "Enter km correctly", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                if (mr == MessageBoxResult.OK | mr == MessageBoxResult.Cancel)
                                {
                                    update_trip_starting_km.Text = "";
                                    update_trip_starting_km.Focus();
                                }
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
                    MessageBox.Show("Trip Number or Vehicle Number is Empty");
                }               
            }
        }


        void update_trip_open_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER")
            {
                if (update_trip_checked.IsChecked == true & !string.IsNullOrWhiteSpace(update_corporation_txt.Text) & !string.IsNullOrWhiteSpace(update_trip_open_date.Text) & !string.IsNullOrWhiteSpace(update_trip_driver.Text) & !string.IsNullOrWhiteSpace(update_trip_id.Text) & !string.IsNullOrWhiteSpace(update_trip_open_origin.Text) & !string.IsNullOrWhiteSpace(update_trip_open_detination.Text) & !string.IsNullOrWhiteSpace(update_trip_starting_km.Text) & !string.IsNullOrWhiteSpace(update_trip_load_weight.Text) & !string.IsNullOrWhiteSpace(update_trip_numbers.Text))
                {
                    string l = update_trip_numbers.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        update_trip_numbers.Text = "";
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
                                OdbcCommand cmd = new OdbcCommand("update lpg_trip_details set corporation='" + update_corporation_txt.Text + "',driver_name='" + update_trip_driver.Text + "',vehicle_number='" + update_trip_id.Text + "',load_date='" + Convert.ToDateTime(update_trip_open_date.Text).ToString("yyyy/MM/dd") + "',origin='" + update_trip_open_origin.Text + "',destination='" + update_trip_open_detination.Text + "',starting_km='" + update_trip_starting_km.Text + "',load_weight='" + Convert.ToDouble(update_trip_load_weight.Text) + "'  where trip_number='" + update_trip_numbers.Text + "' and trip_status='RUNNING'", con.conn);
                                cmd.ExecuteNonQuery();
                                update_trip_numbers.Text = "";
                                update_corporation_txt.Text = "";
                                update_trip_driver.Text = "";
                                update_trip_id.Text = "";
                                update_trip_open_date.Text = "";
                                update_trip_open_origin.Text = "";
                                update_trip_open_detination.Text = "";
                                update_trip_starting_km.Text = "";
                                update_trip_load_weight.Text = "";
                                con.close_connection();
                                lpg_trip_update_imgs1.Visibility = System.Windows.Visibility.Hidden;
                                lpg_trip_update_imgs2.Visibility = System.Windows.Visibility.Visible;
                                time1.Start();
                                chr = "u";
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
                else if (update_trip_closed_checked.IsChecked == true & !string.IsNullOrWhiteSpace(update_trip_numbers.Text) & !string.IsNullOrWhiteSpace(update_corporation_txt.Text) & !string.IsNullOrWhiteSpace(update_trip_driver.Text) & !string.IsNullOrWhiteSpace(update_trip_id.Text) & !string.IsNullOrWhiteSpace(update_trip_open_date.Text) & !string.IsNullOrWhiteSpace(update_trip_open_origin.Text) & !string.IsNullOrWhiteSpace(update_trip_open_detination.Text) & !string.IsNullOrWhiteSpace(update_trip_starting_km.Text) & !string.IsNullOrWhiteSpace(update_trip_load_weight.Text) & !string.IsNullOrWhiteSpace(update_trip_unload_weight.Text) & !string.IsNullOrWhiteSpace(update_trip_unload_date.Text) & !string.IsNullOrWhiteSpace(update_trip_end_km.Text) & !string.IsNullOrWhiteSpace(update_trip_total_diesel.Text) & !string.IsNullOrWhiteSpace(update_trip_diesel_amount.Text) & !string.IsNullOrWhiteSpace(update_trip_total_mileage.Text) & !string.IsNullOrWhiteSpace(update_lpg_trip_advance.Text) & !string.IsNullOrWhiteSpace(update_lph_trip_frieght.Text) & !string.IsNullOrWhiteSpace(update_lpg_trip_expenses.Text) & !string.IsNullOrWhiteSpace(update_lpg_trip_expenses.Text) & !string.IsNullOrWhiteSpace(update_lpg_trip_BALANCE.Text) & !string.IsNullOrWhiteSpace(update_lpg_trip_profit.Text) & !string.IsNullOrWhiteSpace(update_lpg_trip_pay_type.Text))
                {
                    string a = update_trip_numbers.Text;
                    if (Regex.IsMatch(a, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(a, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(a, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        update_trip_numbers.Text = "";
                    }
                    else if (Regex.IsMatch(a, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(a, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(a, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(a, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(a, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (mr == MessageBoxResult.OK)
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("update lpg_trip_expense set load_wages=" + Convert.ToDouble(val1.Text) + ",unload_wages=" + Convert.ToDouble(val2.Text) + ",phone=" + Convert.ToDouble(val3.Text) + ",spares=" + Convert.ToDouble(val4.Text) + ",driver=" + Convert.ToDouble(val5.Text) + ",cliner=" + Convert.ToDouble(val6.Text) + ", toll_spend=" + Convert.ToDouble(toll_wages.Text) + ",rto_pc_gas=" + Convert.ToDouble(rto_amounts.Text) + ",others=" + Convert.ToDouble(other_wages.Text) + " where trip_number='" + update_trip_numbers.Text + "'", con.conn);
                                cmd.ExecuteNonQuery();
                                toll_wages.Text = "0"; rto_amounts.Text = "0"; other_wages.Text = "0";
                                for (int i = 0; i < no_of_row; i++)
                                {
                                    OdbcCommand CMD = new OdbcCommand("update diesel_balance_sheet set fill_date='" + Convert.ToDateTime(date[i]).ToString("yyyy/MM/dd") + "',litters=" + litter[i] + ",price_per=" + price[i] + ",total_cost=" + amount[i] + " where trip_number='" + update_trip_numbers.Text + "' and noof_times=" + count[i] + "", con.conn);
                                    CMD.ExecuteNonQuery();
                                }
                                no_of_row = 0; inc = 0;
                                for (int k = 0; k < t_row; k++)
                                {
                                    OdbcCommand cmmd = new OdbcCommand("update toll_spend set place='" + t_place[k] + "',amount=" + t_amnt[k] + " where trip_number='" + update_trip_numbers.Text + "' and count=" + t_count[k] + "", con.conn);
                                    cmmd.ExecuteNonQuery();
                                }
                                t_row = 0; r_inc = 0;
                                for (int l = 0; l < r_row; l++)
                                {
                                    OdbcCommand cmmd2 = new OdbcCommand("update rto_pc set place='" + r_place[l] + "',amount=" + r_amnt[l] + " where trip_number='" + update_trip_numbers.Text + "' and count=" + r_count[l] + "", con.conn);
                                    cmmd2.ExecuteNonQuery();
                                }
                                r_row = 0; r_inc = 0;
                                for (int j = 0; j < o_row; j++)
                                {
                                    OdbcCommand cmmd1 = new OdbcCommand("update other_spend set reason='" + o_place[j] + "',amount=" + o_amoun[j] + " where trip_number='" + update_trip_numbers.Text + "' and count=" + o_count[j] + "", con.conn);
                                    cmmd1.ExecuteNonQuery();
                                }
                                o_row = 0; o_inc = 0;
                                OdbcCommand cmd2 = new OdbcCommand("update lpg_trip_expense set load_wages='" + Convert.ToDouble(val1.Text) + "',unload_wages='" + Convert.ToDouble(val2.Text) + "',phone='" + Convert.ToDouble(val3.Text) + "',spares='" + Convert.ToDouble(val4.Text) + "',driver='" + Convert.ToDouble(val5.Text) + "',cliner='" + Convert.ToDouble(val6.Text) + "',toll_spend='" + Convert.ToDouble(toll_totals.Text) + "',rto_pc_gas='" + Convert.ToDouble(rto_totals.Text) + "',others='" + Convert.ToDouble(other_totals.Text) + "' where vehicle_number='" + update_trip_id.Text + "' and trip_number='" + update_trip_numbers.Text + "'", con.conn);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("update lpg_trip_details set corporation='" + update_corporation_txt.Text + "',driver_name='" + update_trip_driver.Text + "',vehicle_number='" + update_trip_id.Text + "',load_date='" + Convert.ToDateTime(update_trip_open_date.Text).ToString("yyyy/MM/dd") + "',origin='" + update_trip_open_origin.Text + "',destination='" + update_trip_open_detination.Text + "',starting_km='" + update_trip_starting_km.Text + "',load_weight='" + Convert.ToDouble(update_trip_load_weight.Text) + "',unload_weight='" + Convert.ToDouble(update_trip_unload_weight.Text) + "',unload_date='" + Convert.ToDateTime(update_trip_unload_date.Text).ToString("yyyy/MM/dd") + "',ending_km='" + update_trip_end_km.Text + "',total_km='" + update_trip_total_km.Text + "',trip_diesel='" + update_trip_total_diesel.Text + "',diesel_amount='" + Convert.ToDouble(update_trip_diesel_amount.Text) + "',trip_mileage='" + Convert.ToDouble(update_trip_total_mileage.Text) + "',trip_advance='" + Convert.ToInt32(update_lpg_trip_advance.Text) + "',trip_frieght='" + Convert.ToInt32(update_lph_trip_frieght.Text) + "',trip_expense='" + Convert.ToDouble(update_lpg_trip_expenses.Text) + "',trip_balance='" + Convert.ToDouble(update_lpg_trip_BALANCE.Text) + "',trip_profit='" + Convert.ToDouble(update_lpg_trip_profit.Text) + "',payment_type='" + update_lpg_trip_pay_type.Text + "'  where trip_number='" + update_trip_numbers.Text + "' and trip_status='CLOSED'", con.conn);
                                cmd3.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("update driver_advance set total_km='" + update_trip_total_km.Text + "',advance='" + Convert.ToInt32(update_lpg_trip_advance.Text) + "',expense='" + Convert.ToDouble(update_lpg_trip_expenses.Text) + "',balance='" + Convert.ToDouble(update_lpg_trip_BALANCE.Text) + "'  where trip_number='" + update_trip_numbers.Text + "' ", con.conn);
                                cmd1.ExecuteNonQuery();
                                val1.Text = "0"; val2.Text = "0"; val3.Text = "0"; val4.Text = "0"; val5.Text = "0"; val6.Text = "0";
                                toll_totals.Text = "0"; rto_totals.Text = "0"; other_totals.Text = "0";
                                update_trip_numbers.Text = "";
                                update_corporation_txt.Text = "";
                                update_trip_driver.Text = "";
                                update_trip_id.Text = "";
                                update_trip_open_date.Text = "";
                                update_trip_open_origin.Text = "";
                                update_trip_open_detination.Text = "";
                                update_trip_starting_km.Text = "";
                                update_trip_load_weight.Text = "";
                                update_trip_unload_date.Text = "";
                                update_trip_end_km.Text = "";
                                update_trip_total_km.Text = "";
                                update_trip_total_diesel.Text = "";
                                update_trip_diesel_amount.Text = "";
                                update_trip_total_mileage.Text = "";
                                update_trip_unload_weight.Text = "";
                                update_lph_trip_frieght.Text = "";
                                update_lpg_trip_advance.Text = "";
                                update_lpg_trip_expenses.Text = "";
                                update_lpg_trip_profit.Text = "";
                                update_lpg_trip_BALANCE.Text = "";
                                update_lpg_trip_pay_type.Text = "";
                                con.close_connection();
                                lpg_trip_update_imgs1.Visibility = System.Windows.Visibility.Hidden;
                                lpg_trip_update_imgs2.Visibility = System.Windows.Visibility.Visible;
                                time1.Start();
                                chr = "u";
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
                    MessageBox.Show("Please select radio button  and check trip_number or check text field is empty or not");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           

        }


        void update_trip_cancel_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN")
            {
                MessageBoxResult dr = MessageBox.Show("Are you sure want to Delete this Record", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (dr == MessageBoxResult.OK)
                {
                    if (update_trip_checked.IsChecked == true & !string.IsNullOrWhiteSpace(update_trip_numbers.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand(" delete from lpg_trip_details where trip_number='" + update_trip_numbers.Text + "'", con.conn);
                            cmd.ExecuteNonQuery();
                            update_trip_numbers.Items.Clear();
                            OdbcCommand cmd1 = new OdbcCommand("select trip_number from lpg_trip_details where trip_status='RUNNING'", con.conn);
                            OdbcDataReader DR = cmd1.ExecuteReader();
                            while (DR.Read())
                            {
                                update_trip_numbers.Items.Add(DR[0]);
                            }
                            con.close_connection();
                            update_trip_numbers.Text = "";
                            update_corporation_txt.Text = "";
                            update_trip_driver.Text = "";
                            update_trip_id.Text = "";
                            update_trip_open_date.Text = "";
                            update_trip_open_origin.Text = "";
                            update_trip_open_detination.Text = "";
                            update_trip_starting_km.Text = "";
                            update_trip_load_weight.Text = "";
                            lpg_trip_cancel_imgs1.Visibility = System.Windows.Visibility.Hidden;
                            lpg_trip_cancel_imgs2.Visibility = System.Windows.Visibility.Visible;
                            time1.Start();
                            chr = "c";
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else if (update_trip_closed_checked.IsChecked == true & !string.IsNullOrWhiteSpace(update_trip_numbers.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("delete from lpg_trip_expense where trip_number='" + update_trip_numbers.Text + "' AND vehicle_number='" + update_trip_id.Text + "'", con.conn);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("delete from lpg_trip_details where trip_number='" + update_trip_numbers.Text + "' AND vehicle_number='" + update_trip_id.Text + "'", con.conn);
                            cmd1.ExecuteNonQuery();
                            OdbcCommand cmd2 = new OdbcCommand("delete from diesel_balance_sheet where trip_number='" + update_trip_numbers.Text + "' AND vehicle_number='" + update_trip_id.Text + "'", con.conn);
                            cmd2.ExecuteNonQuery();
                            OdbcCommand cmd3 = new OdbcCommand("delete from driver_advance where trip_number='" + update_trip_numbers.Text + "' AND vehicle_number='" + update_trip_id.Text + "'", con.conn);
                            cmd3.ExecuteNonQuery();
                            OdbcCommand cmd4 = new OdbcCommand("delete from toll_spend where trip_number='" + update_trip_numbers.Text + "' ", con.conn);
                            cmd4.ExecuteNonQuery();
                            OdbcCommand cmd5 = new OdbcCommand("delete from other_spend where trip_number='" + update_trip_numbers.Text + "' ", con.conn);
                            cmd5.ExecuteNonQuery();
                            OdbcCommand cmd6 = new OdbcCommand("delete from rto_pc where trip_number='" + update_trip_numbers.Text + "' ", con.conn);
                            cmd6.ExecuteNonQuery();
                            con.close_connection();
                            OdbcCommand cmd7 = new OdbcCommand("select trip_number from lpg_trip_details where trip_status='CLOSED'", con.conn);
                            OdbcDataReader DR = cmd7.ExecuteReader();
                            while (DR.Read())
                            {
                                update_trip_numbers.Items.Add(DR[0]);
                            }
                            con.close_connection();
                            update_trip_numbers.Text = "";
                            update_corporation_txt.Text = "";
                            update_trip_driver.Text = "";
                            update_trip_id.Text = "";
                            update_trip_open_date.Text = "";
                            update_trip_open_origin.Text = "";
                            update_trip_open_detination.Text = "";
                            update_trip_starting_km.Text = "";
                            update_trip_load_weight.Text = "";
                            update_trip_unload_date.Text = "";
                            update_trip_end_km.Text = "";
                            update_trip_total_km.Text = "";
                            update_trip_total_diesel.Text = "";
                            update_trip_diesel_amount.Text = "";
                            update_trip_total_mileage.Text = "";
                            update_trip_unload_weight.Text = "";
                            update_lph_trip_frieght.Text = "";
                            update_lpg_trip_advance.Text = "";
                            update_lpg_trip_expenses.Text = "";
                            update_lpg_trip_profit.Text = "";
                            update_lpg_trip_BALANCE.Text = "";
                            update_lpg_trip_pay_type.Text = "";
                            lpg_trip_cancel_imgs1.Visibility = System.Windows.Visibility.Hidden;
                            lpg_trip_cancel_imgs2.Visibility = System.Windows.Visibility.Visible;
                            time1.Start();
                            chr = "c";
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please check Radio Button is Select and Trip Number is Selected");
                    }

                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           

        }


        void update_trip_back_click(object sender, RoutedEventArgs e)
        {
            //all_panel_hide();
            //home_panel.Visibility = System.Windows.Visibility.Visible;
            update_trip_numbers.Text = "";
            update_corporation_txt.Text = "";
            update_trip_driver.Text = "";
            update_trip_id.Text = "";
            update_trip_open_date.Text = "";
            update_trip_open_origin.Text = "";
            update_trip_open_detination.Text = "";
            update_trip_starting_km.Text = "";
            update_trip_load_weight.Text = "";
            update_trip_unload_date.Text = "";
            update_trip_end_km.Text = "";
            update_trip_total_km.Text = "";
            update_trip_total_diesel.Text = "";
            update_trip_diesel_amount.Text = "";
            update_trip_total_mileage.Text = "";
            update_trip_unload_weight.Text = "";
            update_lph_trip_frieght.Text = "";
            update_lpg_trip_advance.Text = "";
            update_lpg_trip_expenses.Text = "";
            update_lpg_trip_profit.Text = "";
            update_lpg_trip_BALANCE.Text = "";
            update_lpg_trip_pay_type.Text = "";
        }


        void update_trip_end_km_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(update_trip_end_km.Text)&&!string.IsNullOrWhiteSpace(update_trip_starting_km.Text))
                {
                    if (Convert.ToDouble(update_trip_end_km.Text) < Convert.ToDouble(update_trip_starting_km.Text))
                    {
                        MessageBox.Show("Trip End Km is Below The Starting Km");
                    }
                    else
                    {
                        update_trip_total_km.Text = (Convert.ToDouble(update_trip_end_km.Text) - Convert.ToDouble(update_trip_starting_km.Text)).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill End and Start Kms");
                    e.Handled = true;
                }                               
            }
        }

        int no_of_row = 0;
        void lpg_diesel_update_panel_open(object sender, MouseButtonEventArgs e)
        {                       
            if(!string.IsNullOrWhiteSpace(update_trip_numbers.Text))
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select TRIP_NUMBER,CARD_ID,ORIGIN,DESTINATION,DATE_FORMAT(FILL_DATE,'%d/%m/%Y') as FILL_DATE,NOOF_TIMES,LITTERS,PRICE_PER,TOTAL_COST,WITHDRAW from diesel_balance_sheet where trip_number='" + update_trip_numbers.Text + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    balance_sheet_view.ItemsSource = dt.DefaultView;
                    lpg_diesel_update_panel.Visibility = System.Windows.Visibility.Visible;
                    for(int i=0;i< dt.Rows.Count;i++)
                    {
                        date[i] = dt.Rows[i]["FILL_DATE"].ToString();
                        litter[i] = Convert.ToInt32(dt.Rows[i]["LITTERS"]);
                        price[i] = Convert.ToDouble(dt.Rows[i]["PRICE_PER"]);
                        amount[i] = Convert.ToDouble(dt.Rows[i]["TOTAL_COST"]);
                        count[i] = Convert.ToInt32(dt.Rows[i]["NOOF_TIMES"]);
                        no_of_row = dt.Rows.Count;
                    }
                    
                    con.close_connection();
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
            }   
            else
            {
                MessageBox.Show("Select Trip Number");
            }                         
        }
        int t_row = 0;
        int r_row = 0;
        int o_row = 0;
        private void update_lpg_expense_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Connection con = new Connection();
            con.open_connection();
            try
            {
                OdbcCommand cmd = new OdbcCommand("select load_wages,unload_wages,phone,spares,driver,cliner from lpg_trip_expense where trip_number='" + update_trip_numbers.Text + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    val1.Text = dt.Rows[0]["load_wages"].ToString();
                    val2.Text = dt.Rows[0]["unload_wages"].ToString();
                    val3.Text = dt.Rows[0]["phone"].ToString();
                    val4.Text = dt.Rows[0]["spares"].ToString();
                    val5.Text = dt.Rows[0]["driver"].ToString();
                    val6.Text = dt.Rows[0]["cliner"].ToString();
                   
                }
                else
                {
                    MessageBox.Show("Trip Expense Records not Found");
                }
                try
                {
                    OdbcCommand cmd1 = new OdbcCommand("select place,amount,count from toll_spend where trip_number='" + update_trip_numbers.Text + "'", con.conn);
                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        double val = 0;
                        toll_spend.ItemsSource = dt1.DefaultView;
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                           val += Convert.ToDouble(dt1.Rows[i]["amount"]);
                            t_place[i] = dt1.Rows[i]["place"].ToString();
                            t_amnt[i] =Convert.ToDouble( dt1.Rows[i]["amount"]);
                            t_count[i] = Convert.ToInt32(dt1.Rows[i]["count"]);
                        }
                        toll_totals.Text = val.ToString();                        
                        t_row = dt1.Rows.Count;
                    }
                    else
                    {
                       // MessageBox.Show("Toll details records not found");
                        toll_spend.ItemsSource = dt1.DefaultView;
                    }
                    try
                    {
                        OdbcCommand cmd2 = new OdbcCommand("select place,amount,count from rto_pc where trip_number='" + update_trip_numbers.Text + "'", con.conn);
                        OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            double val = 0;
                            rto_pc_spend.ItemsSource = dt2.DefaultView;
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                val += Convert.ToDouble(dt2.Rows[i]["amount"]);
                                r_place[i] = dt2.Rows[i]["place"].ToString(); 
                                r_amnt[i] = Convert.ToDouble(dt2.Rows[i]["amount"]);
                                r_count[i] = Convert.ToInt32(dt2.Rows[i]["count"]);
                            }
                            rto_totals.Text = val.ToString();                           
                            r_row = dt2.Rows.Count;
                        }
                        else
                        {
                            //MessageBox.Show("Rto and Pc records not found");
                            rto_pc_spend.ItemsSource = dt2.DefaultView;
                        }
                        try
                        {
                            OdbcCommand cmd3 = new OdbcCommand("select reason,amount,count from other_spend where trip_number='" + update_trip_numbers.Text + "'", con.conn);
                            OdbcDataAdapter da3 = new OdbcDataAdapter(cmd3);
                            DataTable dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                double val = 0;
                                other_spend.ItemsSource = dt3.DefaultView;
                                for (int i = 0; i < dt3.Rows.Count; i++)
                                {
                                    val += Convert.ToDouble(dt3.Rows[i]["amount"]);
                                    o_place[i] = dt3.Rows[i]["place"].ToString(); ;
                                    o_amoun[i] = Convert.ToDouble(dt3.Rows[i]["amount"]);
                                    o_count[i] = Convert.ToInt32(dt3.Rows[i]["count"]);
                                }
                                other_totals.Text = val.ToString();                               
                                o_row = dt3.Rows.Count;
                                //all_panel_hide();
                                trip_expense_update_panel.Visibility = System.Windows.Visibility.Visible;
                            }
                            else
                            {
                                //MessageBox.Show("Others spend records not found");
                                other_spend.ItemsSource = dt3.DefaultView;
                            }
                        }
                        catch(OdbcException ex)
                        {
                            MessageBox.Show("Error :"+ex);
                        }
                    }
                    catch(OdbcException ex)
                    {
                        MessageBox.Show("Error :"+ex);
                    }
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }

        }


        void d_price_keydown(object sender, KeyEventArgs e)
        {

            //if (e.Key == Key.Tab | e.Key == Key.Enter)
            //{
            //    if (!string.IsNullOrWhiteSpace(d_litter.Text) & !string.IsNullOrWhiteSpace(d_price.Text))
            //    {    
            //        if(inc<no_of_row)
            //        {
            //            d_amount.Text = (Convert.ToDouble(d_litter.Text) * Convert.ToDouble(d_price.Text)).ToString();
            //            litter[inc] = Convert.ToInt32(d_litter.Text);
            //            price[inc] = Convert.ToDouble(d_price.Text);
            //            amount[inc] = Convert.ToDouble(d_amount.Text);
            //            count[inc] = no;
            //            f_date.Text = ""; d_litter.Text = ""; d_price.Text = ""; d_amount.Text = "";
            //            inc++;
            //        } 
            //        else
            //        {
            //            MessageBox.Show("Edit a Row One Time Only");
            //        }               
                                          
            //    }
            //    else
            //    {
            //        MessageBox.Show("Litter or Price is Empty");
            //        d_amount.IsEnabled = true;
            //    }

            //}

            // t_number.Content ="";
        }

        void d_amount_keydown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Tab | e.Key == Key.Enter)
            //{
            //    if (!string.IsNullOrWhiteSpace(d_amount.Text) & !string.IsNullOrWhiteSpace(d_price.Text))
            //    {
            //        if (inc < no_of_row)
            //        {
            //            d_amount.Text = (Convert.ToDouble(d_amount.Text) * Convert.ToDouble(d_price.Text)).ToString();
            //            litter[inc] = Convert.ToInt32(d_litter.Text);
            //            price[inc] = Convert.ToDouble(d_price.Text);
            //            amount[inc] = Convert.ToDouble(d_amount.Text);
            //            count[inc] = no;
            //            f_date.Text = ""; d_litter.Text = ""; d_price.Text = ""; d_amount.Text = "";
            //            inc++;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Edit a Row One Time Only");
            //        }
            //        //d_litter.IsEnabled = false;                   
            //        //OdbcCommand cmd1 = new OdbcCommand("select TRIP_NUMBER,CARD_ID,ORIGIN,DESTINATION,DATE_FORMAT(FILL_DATE,'%d/%m/%Y') as FILL_DATE,NOOF_TIMES,LITTERS,PRICE_PER,TOTAL_COST,WITHDRAW from diesel_balance_sheet where trip_number='" + t_number.Content + "'", con.conn);
            //        //OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            //        //DataTable dt = new DataTable();
            //        //da.Fill(dt);
            //        //balance_sheet_view.ItemsSource = dt.DefaultView; 
            //        //con.close_connection();
            //    }
            //    else
            //    {
            //       // d_litter.IsEnabled = true;
            //    }

            //}
        }

        
        void balance_sheet_update(object sender, RoutedEventArgs e)
        {           
            if (string.IsNullOrWhiteSpace(d_amount.Text) && !string.IsNullOrWhiteSpace(d_litter.Text) & !string.IsNullOrWhiteSpace(d_price.Text))
            {
                for(int i=0;i< no_of_row;i++)
                {
                    if (count.Contains(no))
                    {
                        d_amount.Text = (Convert.ToDouble(d_litter.Text) * Convert.ToDouble(d_price.Text)).ToString();
                        litter[d_index] = Convert.ToInt32(d_litter.Text);
                        price[d_index] = Convert.ToDouble(d_price.Text);
                        amount[d_index] = Convert.ToDouble(d_amount.Text);
                        count[d_index] = no;
                        date[d_index] = Convert.ToDateTime(f_date.Text).ToString("yyyy/MM/dd");                        
                        f_date.Text = ""; d_litter.Text = ""; d_price.Text = ""; d_amount.Text = "";
                    }
                    else
                    {
                       // MessageBox.Show("Selected index is null");
                    }
                }
               
           }
           else if(string.IsNullOrWhiteSpace(d_litter.Text) && !string.IsNullOrWhiteSpace(d_amount.Text) & !string.IsNullOrWhiteSpace(d_price.Text))
           {
                for(int i=0;i< no_of_row; i++)
                {
                    if (count.Contains(no) && !string.IsNullOrWhiteSpace(d_amount.Text) && !string.IsNullOrWhiteSpace(d_price.Text))
                    {
                        d_litter.Text = (Convert.ToDouble(d_amount.Text) / Convert.ToDouble(d_price.Text)).ToString();
                        litter[d_index] = Convert.ToInt32(d_litter.Text);
                        price[d_index] = Convert.ToDouble(d_price.Text);
                        amount[d_index] = Convert.ToDouble(d_amount.Text);
                        count[d_index] = no;
                        date[d_index] = Convert.ToDateTime(f_date.Text).ToString("yyyy/MM/dd");                       
                        f_date.Text = ""; d_litter.Text = ""; d_price.Text = ""; d_amount.Text = "";
                    }
                    else
                    {
                        //MessageBox.Show("Edit a Row One Time Only");
                    }
                }
               
            }
            else if (string.IsNullOrWhiteSpace(d_price.Text) && !string.IsNullOrWhiteSpace(d_amount.Text) & !string.IsNullOrWhiteSpace(d_litter.Text))
            {
                for (int i = 0; i < no_of_row; i++)
                {
                    if (count.Contains(no)&&!string.IsNullOrWhiteSpace(d_amount.Text) &&!string.IsNullOrWhiteSpace(d_litter.Text))
                    {
                        d_price.Text = (Convert.ToDouble(d_amount.Text) / Convert.ToDouble(d_litter.Text)).ToString();
                        litter[d_index] = Convert.ToInt32(d_litter.Text);
                        price[d_index] = Convert.ToDouble(d_price.Text);
                        amount[d_index] = Convert.ToDouble(d_amount.Text);
                        count[d_index] = no;
                        date[d_index] = Convert.ToDateTime(f_date.Text).ToString("yyyy/MM/dd");                       
                        f_date.Text = ""; d_litter.Text = ""; d_price.Text = ""; d_amount.Text = "";
                    }
                    else
                    {
                       // MessageBox.Show("Edit a Row One Time Only");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Give any Two Values");
            }
           
            update_trip_total_diesel.Text = (litter.Sum()).ToString();
            update_trip_diesel_amount.Text = (amount.Sum()).ToString();
            update_trip_total_mileage.Text = (Convert.ToDouble(update_trip_total_km.Text) / litter.Sum()).ToString();                                 
        }
        void Update_Balance_Sheet_Close_Click(object sender,RoutedEventArgs e)
        {
            lpg_diesel_update_panel.Visibility = System.Windows.Visibility.Hidden;
            f_date.Text = ""; d_litter.Text = ""; d_price.Text = ""; d_amount.Text = "";t_number.Content = "";
            balance_sheet_view.ItemsSource = null;
        }
        void select_grid_row_data(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dr = (DataRowView)balance_sheet_view.SelectedItem;

                if (dr["noof_times"].Equals(""))
                {
                    MessageBox.Show("no of times column is null, should fill first");
                }
                else
                {
                    t_number.Content = (dr["trip_number"]);
                    f_date.Text = (dr["fill_date"]).ToString();
                    d_litter.Text = (dr["litters"]).ToString();
                    d_price.Text = (dr["price_per"]).ToString();
                    d_amount.Text = (dr["total_cost"]).ToString(); ;
                    no = Convert.ToInt32(dr["noof_times"]);
                    type = (dr["withdraw"]).ToString();
                    d_index = balance_sheet_view.SelectedIndex;
                }
            }
            catch
            {

            }
           
        }

        void toll_wages_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dr = (DataRowView)toll_spend.SelectedItem;
                d_index = toll_spend.SelectedIndex;
                array_size = Convert.ToInt32(dr["count"]);
                toll_places.Text = (dr["place"]).ToString();
                toll_wages.Text = (dr["amount"]).ToString();
            }
            catch
            {
                //MessageBox.Show("Error");
            }


        }
        
        void rto_pc_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dr = (DataRowView)rto_pc_spend.SelectedItem;
                d_index = rto_pc_spend.SelectedIndex;
                array_size = Convert.ToInt32(dr["count"]);
                rto_places.Text = (dr["place"]).ToString();
                rto_amounts.Text = (dr["amount"]).ToString();
            }
            catch
            {
               // MessageBox.Show("Error :");
            }
        }
       
        void other_wages_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dr = (DataRowView)other_spend.SelectedItem;
                d_index = other_spend.SelectedIndex;
                array_size = Convert.ToInt32(dr["count"]);
                other_reasons.Text = (dr["reason"]).ToString();
                other_wages.Text = (dr["amount"]).ToString();
            }
            catch
            {
                MessageBox.Show("Error :");
            }
        }


        void toll_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(toll_wages.Text) &&!string.IsNullOrWhiteSpace(toll_places.Text))
                {
                    if(t_count.Contains(array_size))
                    {
                        t_amnt[d_index] = Convert.ToDouble(toll_wages.Text);
                        t_place[d_index] = toll_places.Text;
                        t_count[d_index] = array_size;
                        t_inc++;
                        toll_totals.Text = t_amnt.Sum().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Index Not Exist");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please Fill Empty TextBox");
                }
                //try
                //{
                //    Connection CON = new Connection();
                //    CON.open_connection();
                //    double D = 
                //    OdbcCommand cmd = new OdbcCommand("update toll_spend set place='" + toll_places.Text + "',amount=" + D + " where trip_number='" + update_trip_numbers.Text + "' and count=" + array_size + "", CON.conn);
                //    cmd.ExecuteNonQuery();
                //    OdbcCommand cmd1 = new OdbcCommand("select sum(amount) from toll_spend where trip_number='" + update_trip_numbers.Text + "'", CON.conn);
                //    OdbcDataReader dr = cmd1.ExecuteReader();
                //    if (dr.Read())
                //    {
                //        toll_totals.Text = dr[0].ToString();
                //    }
                //    CON.close_connection();
                //}
                //catch(OdbcException ex)
                //{
                //    MessageBox.Show("Error :"+ex);
                //}

            }

        }
        void rto_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(rto_places.Text) &&!string.IsNullOrWhiteSpace(rto_amounts.Text))
                {
                    if(r_count.Contains(array_size))
                    {
                       r_amnt[d_index]= Convert.ToDouble(rto_amounts.Text);
                        r_place[d_index] = rto_places.Text;
                        r_count[d_index] = array_size;
                        r_inc++;
                        rto_totals.Text = r_amnt.Sum().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Index Not Exist");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Empty Textbox");
                }
                //try
                //{
                //    Connection CON = new Connection();
                //    CON.open_connection();
                //    double D = Convert.ToDouble(rto_amounts.Text);
                //    OdbcCommand cmd = new OdbcCommand("update rto_pc set place='" + rto_places.Text + "',amount=" + D + " where trip_number='" + update_trip_numbers.Text + "' and count=" + array_size + "", CON.conn);
                //    cmd.ExecuteNonQuery();
                //    OdbcCommand cmd1 = new OdbcCommand("select sum(amount) from rto_pc where trip_number='" + update_trip_numbers.Text + "'", CON.conn);
                //    OdbcDataReader dr = cmd1.ExecuteReader();
                //    if (dr.Read())
                //    {
                //        rto_totals.Text = dr[0].ToString();
                //    }
                //    CON.close_connection();
                //}
                //catch(OdbcException ex)
                //{
                //    MessageBox.Show("Error :"+ex);
                //}
            }
        }
        void other_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(other_reasons.Text) &&!string.IsNullOrWhiteSpace(other_wages.Text))
                {
                    if(o_count.Contains(array_size))
                    {
                        o_amoun[d_index ]= Convert.ToDouble(other_wages.Text);
                        o_place[d_index] = other_reasons.Text;
                        o_count[d_index] = array_size;
                        o_inc++;
                        other_totals.Text = o_amoun.Sum().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Index Not Exist");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Empty Textbox");
                }
                //try
                //{
                //    Connection CON = new Connection();
                //    CON.open_connection();
                //    double D = Convert.ToDouble(other_wages.Text);
                //    OdbcCommand cmd = new OdbcCommand("update other_spend set reason='" + other_reasons.Text + "',amount=" + D + " where trip_number='" + update_trip_numbers.Text + "' and count=" + array_size + "", CON.conn);
                //    cmd.ExecuteNonQuery();
                //    OdbcCommand cmd1 = new OdbcCommand("select sum(amount) from other_spend where trip_number='" + update_trip_numbers.Text + "'", CON.conn);
                //    OdbcDataReader dr = cmd1.ExecuteReader();
                //    if (dr.Read())
                //    {
                //        other_totals.Text = dr[0].ToString();
                //    }
                //    CON.close_connection();
                //}
                //catch(OdbcException ex)
                //{
                //    MessageBox.Show("Error :"+ex);
                //}
            }
        }


        void trip_expens_update_back_click(object sender, RoutedEventArgs e)
        {           
            trip_update_panel.Visibility = System.Windows.Visibility.Visible;
            val1.Text = "0"; val2.Text = "0"; val3.Text = "0"; val4.Text = "0"; val5.Text = "0"; val6.Text = "0"; ;
            toll_wages.Text = "0"; rto_amounts.Text = "0"; other_wages.Text = "0"; toll_totals.Text = "0"; rto_totals.Text = "0"; other_totals.Text = "0";
        }


        void trip_expense_update_done_click(object sender, RoutedEventArgs e)
        {           
            trip_update_panel.Visibility = System.Windows.Visibility.Visible;
            trip_expense_update_panel.Visibility = System.Windows.Visibility.Hidden;
            Connection con = new Connection();
            con.open_connection();
            double d1 = Convert.ToDouble(toll_totals.Text);
            double d2 = Convert.ToDouble(rto_totals.Text);
            double d3 = Convert.ToDouble(other_totals.Text);
            double A1 = 0; /*double C1 = 0;*/
            if (d1 != 0 & d2 != 0 & d3 != 0 | d1 == 0 | d2 == 0 | d3 == 0&&!string.IsNullOrWhiteSpace(update_lph_trip_frieght.Text) && !string.IsNullOrWhiteSpace(update_lpg_trip_advance.Text) && !string.IsNullOrWhiteSpace(update_lpg_trip_expenses.Text))
            {
                try
                {
                    double val_total = Convert.ToDouble(val1.Text) + Convert.ToDouble(val2.Text) + Convert.ToDouble(val3.Text) + Convert.ToDouble(val4.Text) + Convert.ToDouble(val5.Text) + Convert.ToDouble(val6.Text);
                    update_lpg_trip_expenses.Text = (val_total + d1 + d2 + d3).ToString();

                    OdbcCommand cmd1 = new OdbcCommand("select sum(total_cost) as amount from diesel_balance_sheet where trip_number='" + update_trip_numbers.Text + "' and withdraw='ADVANCE'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string val = dt.Rows[0]["amount"].ToString();
                        if (val == "")
                        {
                            A1 = 0;
                        }
                        else
                        {
                            A1 = Convert.ToDouble(dt.Rows[0]["amount"]);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Doesnot Get Withdraw Type");
                    }
                    //OdbcCommand cmd2 = new OdbcCommand("select sum(total_cost) as amount from diesel_balance_sheet where trip_number='" + update_trip_numbers.Text + "' and withdraw='CARD'", con.conn);
                    //OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                    //DataTable dt2 = new DataTable();
                    //da2.Fill(dt2);
                    //if (dt2.Rows.Count > 0)
                    //{

                    //    string val = dt.Rows[0]["amount"].ToString();
                    //    if (val == "")
                    //    {
                    //        C1 = 0;
                    //    }
                    //    else
                    //    {
                    //        C1 = Convert.ToDouble(dt.Rows[0]["amount"]);
                    //    }
                    //}
                    //else
                    //{
                    //    //MessageBox.Show("Doesnot Get Withdraw Type");
                    //}
                    
                    con.close_connection();
                    update_lpg_trip_profit.Text = (Convert.ToDouble(update_lph_trip_frieght.Text) - Convert.ToDouble(update_lpg_trip_expenses.Text) - Convert.ToDouble(update_trip_diesel_amount.Text)).ToString();
                    update_lpg_trip_BALANCE.Text = (Convert.ToDouble(update_lpg_trip_advance.Text) - Convert.ToDouble(update_lpg_trip_expenses.Text) - A1).ToString();
                    
                    
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
              
            }
            else
            {
                MessageBox.Show("Please Fill Frieght and Advances");

            }


        }

        void Trip_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(update_trip_numbers.Text))
            {

                len = update_trip_numbers.Text.Length;
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
         void Trip_Update_Driver_Name_Textchanged(object sender,TextCompositionEventArgs e)
        {
            string s = update_trip_driver.Text;
            int len = s.Length;
            if (len > 4)
            {
                int val = 0;
                string sub = s.Substring(len - 4, 4);
                for (int i = 0; i < 4; i++)
                {
                    bool isdigit = char.IsDigit(sub[i]);
                    if (isdigit)
                    {
                        val += 1;
                        if (val == 4)
                        {
                            System.Media.SystemSounds.Beep.Play();
                            e.Handled = true;
                        }
                    }
                }

            }
            
            
        } 
        void Load_Weight_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }
        void Load_Weight_Textchanged(object sender, TextChangedEventArgs e)
        {
            string s = update_trip_load_weight.Text;
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
                            double d = Convert.ToDouble(update_trip_load_weight.Text);
                            if (d > 20)
                            {
                                System.Media.SystemSounds.Beep.Play();
                                e.Handled = true;
                                MessageBox.Show("Should Enter Value Below 20");
                                update_trip_load_weight.Text = "";
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

        void Unload_Weight_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }
        void Unload_Weight_Textchanged(object sender, TextChangedEventArgs e)
        {
            string s = update_trip_unload_weight.Text; 
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
                            double d = Convert.ToDouble(update_trip_unload_weight.Text);
                            if (d > 20)
                            {
                                System.Media.SystemSounds.Beep.Play();
                                e.Handled = true;
                                MessageBox.Show("Should Enter Value Below 20");
                                update_trip_unload_weight.Text = "";
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
        void Litter_Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }

        private void update_trip_unload_weight_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab&&e.Key==Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(update_trip_load_weight.Text) &&!string.IsNullOrWhiteSpace(update_trip_unload_weight.Text))
                {
                    if(Convert.ToDouble(update_trip_unload_weight.Text)>Convert.ToDouble(update_trip_load_weight.Text))
                    {
                        MessageBox.Show("Should Enter Below Or Equal of Load Weight");
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Should Fill Load and Unload Weight");
                }
            }
        }
    }
}
