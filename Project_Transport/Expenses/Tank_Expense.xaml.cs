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
    /// Interaction logic for Tank_Maintenance.xaml
    /// </summary>
    public partial class Tank_Maintenance : UserControl
    {
        public Tank_Maintenance()
        {
            InitializeComponent();
            t_l_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            t_l_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            t_l_done_bttn.Visibility = System.Windows.Visibility.Hidden;
        }

       public int btn_val = 0;
       public string btn_char = null;
        string[] des = new string[50];
        int[] qnty = new int[50];
        double[] qnt_rate = new double[50];
        double[] qnt_price = new double[50];
        int s_val = 0;
        int[] snos = new int[50];
        void lpg_tank_work(object sender, RoutedEventArgs e)
        {
            lpg_tank_expense.Background = System.Windows.Media.Brushes.Green;
            tank_work_expense.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_new_bill.IsEnabled = true; trailer_tank_edit_bill.IsEnabled = true; trailer_tank_view_bill.IsEnabled = true;
            btn_val = 1;
            btn_char = "";
            t_l_descrip.Items.Clear();
            add_item1();
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();

        }
        void tank_workshop(object sender, RoutedEventArgs e)
        {
            lpg_tank_expense.Background = System.Windows.Media.Brushes.Yellow;
            tank_work_expense.Background = System.Windows.Media.Brushes.Green;
            trailer_tank_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_new_bill.IsEnabled = true; trailer_tank_edit_bill.IsEnabled = true; trailer_tank_view_bill.IsEnabled = true;
            btn_val = 2;
            btn_char = "";
            t_l_descrip.Items.Clear();
            add_item2();
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }


        void tank_lpg_new_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tank_Vehicle_Number = "";
            g.Tank_Description = "";
            g.Tank_Quantity = "1";
            g.Tank_Rate = "";
            g.Tank_Bill_No = "";
            g.Tank_Discount = "";
            this.DataContext = g;
            trailer_tank_new_bill.Background = System.Windows.Media.Brushes.Green;
            trailer_tank_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            btn_char = "N";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from electrical", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            t_l_S_NO.Text = "1";
            clear_array();
            t_l_descrip.Visibility = System.Windows.Visibility.Visible;
            t_l_quantity.Visibility = System.Windows.Visibility.Visible;
            t_l_rate.Visibility = System.Windows.Visibility.Visible;
            t_l_price.Visibility = System.Windows.Visibility.Visible;
            t_l_bill_date.Visibility = System.Windows.Visibility.Visible;
            t_l_bill_no.Visibility = System.Windows.Visibility.Visible;
            t_l_bill_num.Visibility = System.Windows.Visibility.Visible;
            t_l_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            t_l_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            lbl1.Visibility = System.Windows.Visibility.Visible;
            lbl2.Visibility = System.Windows.Visibility.Visible;
            lbl3.Visibility = System.Windows.Visibility.Visible;
            lbl4.Visibility = System.Windows.Visibility.Visible;
            t_l_datagrid1.ItemsSource = null;
            t_l_datagrid1.Items.Refresh();
            t_l_bill_num.Text = "";
            t_l_bill_num.IsEnabled = true;
            t_l_descrip.Focus();
        }
        void tank_lpg_edit_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tank_Vehicle_Number = "";
            g.Tank_Description = "";
            g.Tank_Quantity = "1";
            g.Tank_Rate = "";
            g.Tank_Bill_No = "";
            g.Tank_Discount = "";
            this.DataContext = g;
            trailer_tank_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_edit_bill.Background = System.Windows.Media.Brushes.Green;
            trailer_tank_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            btn_char = "E";
            t_l_descrip.Visibility = System.Windows.Visibility.Visible;
            t_l_quantity.Visibility = System.Windows.Visibility.Visible;
            t_l_rate.Visibility = System.Windows.Visibility.Visible;
            t_l_price.Visibility = System.Windows.Visibility.Visible;
            t_l_bill_date.Visibility = System.Windows.Visibility.Hidden;
            t_l_bill_no.Visibility = System.Windows.Visibility.Hidden;
            t_l_bill_num.Visibility = System.Windows.Visibility.Hidden;
            t_l_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            t_l_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
            lbl1.Visibility = System.Windows.Visibility.Visible;
            lbl2.Visibility = System.Windows.Visibility.Visible;
            lbl3.Visibility = System.Windows.Visibility.Visible;
            lbl4.Visibility = System.Windows.Visibility.Visible;
            t_l_datagrid1.ItemsSource = null;
            t_l_datagrid1.Items.Refresh();

        }
        void tank_lpg_view_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tank_Vehicle_Number = "";
            g.Tank_Bill_Num = "";
            this.DataContext = g;
            trailer_tank_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            trailer_tank_view_bill.Background = System.Windows.Media.Brushes.Green;
            btn_char = "V";
            t_l_descrip.Visibility = System.Windows.Visibility.Hidden;
            t_l_quantity.Visibility = System.Windows.Visibility.Hidden;
            t_l_rate.Visibility = System.Windows.Visibility.Hidden;
            t_l_price.Visibility = System.Windows.Visibility.Hidden;
            t_l_bill_date.Visibility = System.Windows.Visibility.Hidden;
            t_l_bill_no.Visibility = System.Windows.Visibility.Hidden;
            t_l_bill_num.Visibility = System.Windows.Visibility.Hidden;
            t_l_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            t_l_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
            lbl1.Visibility = System.Windows.Visibility.Hidden;
            lbl2.Visibility = System.Windows.Visibility.Hidden;
            lbl3.Visibility = System.Windows.Visibility.Hidden;
            lbl4.Visibility = System.Windows.Visibility.Hidden;
            t_l_datagrid1.ItemsSource = null;
            t_l_datagrid1.Items.Refresh();

        }


        void t_l_quantity_rate_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                t_l_price.Text = (Convert.ToInt32(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text)).ToString();
            }
        }


        void t_l_vehicle_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER" )
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        t_l_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (btn_val == 1 & btn_char == "E" & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                        {


                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and expense_type='LPG-TANK' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                t_l_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }

                        else if (btn_val == 2 & btn_char == "E" & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and expense_type='WORK-SHOP' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                t_l_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (btn_val == 1 & btn_char == "V" & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and expense_type='LPG-TANK' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                t_l_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (btn_val == 2 & btn_char == "V" & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and expense_type='WORK-SHOP' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                t_l_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (btn_char == "N")
                        {

                        }
                        else
                        {
                            MessageBox.Show("Should Select Vehicle Number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
               
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }
        }


        void t_l_add_all_bill_number_checked(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        t_l_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (btn_val == 1 & btn_char == "E" & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and expense_type='LPG-TANK' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                t_l_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {

                                    for (int c = 0; c < dt.Rows.Count; c++)
                                    {
                                        t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (btn_val == 2 & btn_char == "E" & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and expense_type='WORK-SHOP' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                t_l_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {

                                    for (int c = 0; c < dt.Rows.Count; c++)
                                    {
                                        t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (btn_val == 1 & btn_char == "V" & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                        {
                            try
                            {

                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and expense_type='LPG-TANK' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            t_l_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
                            con.close_string();
                        }
                        else if (btn_val == 2 & btn_char == "V" & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and expense_type='WORK-SHOP' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                t_l_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {

                                    for (int c = 0; c < dt.Rows.Count; c++)
                                    {
                                        t_l_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Should Select Vehicle Number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
            }
            else
            {
                MessageBox.Show("please Select Vehicle Number");
            }
            
            
            
        }


        void t_l_bill_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                try
                {
                    if (t_l_bill_num.Text.Length >= 6)
                    {
                        MessageBoxResult mr = MessageBox.Show("Length Should be Less-than 6 Digit", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (mr == MessageBoxResult.OK)
                        {
                            e.Handled = true;
                            t_l_bill_num.Text = "";
                        }
                        else if(mr==MessageBoxResult.No)
                        {

                        }
                    }
                    else if (btn_char == "N" & string.IsNullOrWhiteSpace(t_l_bill_num.Text))
                    {
                        Connection con1 = new Connection();
                        con1.connection_string();
                        OdbcCommand cmd = new OdbcCommand("select MAX(bill_no)as bill_nos from expense_bill", con1.str);
                        OdbcDataAdapter da1 = new OdbcDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            try
                            {
                                t_l_bill_num.Text = (Convert.ToInt32(dt1.Rows[0]["bill_nos"]) + 1).ToString();
                                t_l_bill_num.IsEnabled = false;
                            }
                            catch
                            {
                                t_l_bill_num.Text = "0001";
                                t_l_bill_num.IsEnabled = false;
                            }

                        }
                        else
                        {
                            t_l_bill_num.Text = "0001";
                            t_l_bill_num.IsEnabled = false;
                        }
                        con1.close_string();
                    }
                    else
                    {
                        t_l_bill_num.IsEnabled = false;
                    }

                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
              
            }
        }


        void tank_lpg_add_new_row(object sender, RoutedEventArgs e)
        {
            if (btn_val == 1 & btn_char == "N")
            {
                if (!string.IsNullOrWhiteSpace(t_l_descrip.Text) & !string.IsNullOrWhiteSpace(t_l_quantity.Text) & !string.IsNullOrWhiteSpace(t_l_rate.Text) & !string.IsNullOrWhiteSpace(t_l_bill_num.Text) & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text) & !string.IsNullOrWhiteSpace(t_l_bill_date.Text))
                {
                    try
                    {
                        int count = Convert.ToInt32(t_l_S_NO.Text) - 1;
                        snos[count] = Convert.ToInt32(t_l_S_NO.Text);
                        des[count] = t_l_descrip.Text;
                        qnty[count] = Convert.ToInt32(t_l_quantity.Text);
                        qnt_rate[count] = Convert.ToDouble(t_l_rate.Text);
                        qnt_price[count] = Convert.ToInt32(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text);

                        Connection CON = new Connection();
                        CON.connection_string();
                        OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(t_l_S_NO.Text) + ",'" + t_l_descrip.Text + "'," + Convert.ToInt32(t_l_quantity.Text) + "," + Convert.ToDouble(t_l_rate.Text) + "," + Convert.ToInt32(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text) + ")", CON.str);
                        cmd.ExecuteNonQuery();
                        OdbcCommand cmd1 = new OdbcCommand("selEct S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        t_l_datagrid1.ItemsSource = dt.DefaultView;
                        gridsize();
                        double v = 0;
                        for (int i = 0; i < Convert.ToInt32(t_l_S_NO.Text); i++)
                        {
                            v += Convert.ToDouble(qnt_price[i]);
                            t_l_total_amount.Text = v.ToString();
                        }
                        t_l_S_NO.Text = (Convert.ToInt32(t_l_S_NO.Text) + 1).ToString();
                        CON.close_string();
                        t_l_descrip.Text = ""; t_l_quantity.Text = "1"; t_l_rate.Text = "0"; t_l_price.Text = "0";
                        t_l_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                        t_l_descrip.Focus();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Should Fill Empty Text Field");
                }
            }
            else if (btn_val == 2 & btn_char == "N")
            {
                if (!string.IsNullOrWhiteSpace(t_l_descrip.Text) & !string.IsNullOrWhiteSpace(t_l_quantity.Text) & !string.IsNullOrWhiteSpace(t_l_rate.Text) & !string.IsNullOrWhiteSpace(t_l_bill_num.Text) & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text) & !string.IsNullOrWhiteSpace(t_l_bill_date.Text))
                {
                    try
                    {
                        int count = Convert.ToInt32(t_l_S_NO.Text) - 1;
                        snos[count] = Convert.ToInt32(t_l_S_NO.Text);
                        des[count] = t_l_descrip.Text;
                        qnty[count] = Convert.ToInt32(t_l_quantity.Text);
                        qnt_rate[count] = Convert.ToDouble(t_l_rate.Text);
                        qnt_price[count] = Convert.ToInt32(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text);

                        Connection CON = new Connection();
                        CON.connection_string();
                        OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(t_l_S_NO.Text) + ",'" + t_l_descrip.Text + "'," + Convert.ToInt32(t_l_quantity.Text) + "," + Convert.ToDouble(t_l_rate.Text) + "," + Convert.ToInt32(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text) + ")", CON.str);
                        cmd.ExecuteNonQuery();
                        OdbcCommand cmd1 = new OdbcCommand("selEct S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        t_l_datagrid1.ItemsSource = dt.DefaultView;
                        gridsize();
                        double v = 0;
                        for (int i = 0; i < Convert.ToInt32(t_l_S_NO.Text); i++)
                        {
                            v += Convert.ToDouble(qnt_price[i]);
                            t_l_total_amount.Text = v.ToString();
                        }
                        t_l_S_NO.Text = (Convert.ToInt32(t_l_S_NO.Text) + 1).ToString();
                        CON.close_string();
                        t_l_descrip.Text = ""; t_l_quantity.Text = "1"; t_l_rate.Text = "0"; t_l_price.Text = "0";
                        t_l_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                        t_l_descrip.Focus();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Should Fill Empty Text Field");
                }
            }
            else if (btn_val == 1 & btn_char == "NE" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                try
                {
                    des[s_val - 1] = t_l_descrip.Text;
                    qnty[s_val - 1] = Convert.ToInt32(t_l_quantity.Text);
                    qnt_rate[s_val - 1] = Convert.ToDouble(t_l_rate.Text);
                    qnt_price[s_val - 1] = Convert.ToInt32(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text);
                    Connection con = new Connection();
                    con.connection_string();
                    OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + t_l_descrip.Text + "',quantity=" + Convert.ToInt32(t_l_quantity.Text) + ",rate=" + Convert.ToDouble(t_l_rate.Text) + ",price=" + Convert.ToDouble(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text) + " where s_no=" + s_val + "", con.str);
                    cmd.ExecuteNonQuery();
                    OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    t_l_datagrid1.ItemsSource = dt.DefaultView;
                    gridsize();
                    con.close_string();
                    double dv = 0;
                    for (int i = 0; i < Convert.ToInt32(t_l_S_NO.Text); i++)
                    {
                        dv += qnt_price[i];
                        t_l_total_amount.Text = dv.ToString();
                    }
                    btn_char = "N"; t_l_descrip.Text = ""; t_l_quantity.Text = "1"; t_l_rate.Text = "0"; t_l_price.Text = "0";
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
                
            }
            else if (btn_val == 2 & btn_char == "NE" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                try
                {
                    des[s_val - 1] = t_l_descrip.Text;
                    qnty[s_val - 1] = Convert.ToInt32(t_l_quantity.Text);
                    qnt_rate[s_val - 1] = Convert.ToDouble(t_l_rate.Text);
                    qnt_price[s_val - 1] = Convert.ToInt32(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text);
                    Connection con = new Connection();

                    con.connection_string();
                    OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + t_l_descrip.Text + "',quantity=" + Convert.ToInt32(t_l_quantity.Text) + ",rate=" + Convert.ToDouble(t_l_rate.Text) + ",price=" + Convert.ToDouble(t_l_quantity.Text) * Convert.ToDouble(t_l_rate.Text) + " where s_no=" + s_val + "", con.str);
                    cmd.ExecuteNonQuery();
                    OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    t_l_datagrid1.ItemsSource = dt.DefaultView;
                    gridsize();
                    con.close_string();
                    double dv = 0;
                    for (int i = 0; i < Convert.ToInt32(t_l_S_NO.Text); i++)
                    {
                        dv += qnt_price[i];
                        t_l_total_amount.Text = dv.ToString();
                    }
                    btn_char = "N"; t_l_descrip.Text = ""; t_l_quantity.Text = "1"; t_l_rate.Text = "0"; t_l_price.Text = "0";

                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
                            }
            else if (btn_val == 1 & btn_char == "E" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        t_l_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from tank_expense where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='LPG-TANK'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                t_l_datagrid1.ItemsSource = DT.DefaultView;
                                gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='LPG-TANK'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    t_l_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    t_l_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    t_l_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();
                                    t_l_bill_num.Text = dt.Rows[0]["bill_no"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Bill Total Doesn't Exist");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bill Doesn't Exist on This Date");
                            }
                            con.close_string();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }

               
                
            }
            else if (btn_val == 2 & btn_char == "E" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                 if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        t_l_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from tank_expense where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='WORK-SHOP'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                t_l_datagrid1.ItemsSource = DT.DefaultView;
                                gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='WORK-SHOP'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    t_l_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    t_l_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    t_l_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();
                                    t_l_bill_num.Text = dt.Rows[0]["bill_NO"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Bill Total Doesn't Exist");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bill Doesn't Exist on This Date");
                            }
                            con.close_string();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }

               
               
            }
            else if (btn_val == 1 & btn_char == "ED" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            t_l_vehicle_num.Text = "";
                        }
                        else if (!string.IsNullOrWhiteSpace(t_l_descrip.Text) & !string.IsNullOrWhiteSpace(t_l_quantity.Text) & !string.IsNullOrWhiteSpace(t_l_rate.Text) & !string.IsNullOrWhiteSpace(t_l_bill_num.Text) & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text) & !string.IsNullOrWhiteSpace(t_l_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update tank_expense set description='" + t_l_descrip.Text + "',quantity=" + Convert.ToInt32(t_l_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(t_l_rate.Text) + " where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='LPG-TANK' and s_no=" + s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM TANK_EXPENSE where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='LPG-TANK' ", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                double p_tot = 0;
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        p_tot += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Value Doesn't Exist");
                                }
                                t_l_total_amount.Text = p_tot.ToString();
                                t_l_grand_total.Text = (Convert.ToDouble(t_l_total_amount.Text) - Convert.ToDouble(t_l_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(t_l_total_amount.Text) + ",discount=" + Convert.ToDouble(t_l_discount_amount.Text) + ",gnd_total=" + t_l_grand_total.Text + " where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='LPG-TANK' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM TANK_EXPENSE where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='LPG-TANK' and bill_no=" + Convert.ToInt32(t_l_bill_num.Text) + "", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                t_l_datagrid1.ItemsSource = dt1.DefaultView;
                                gridsize();
                                con.close_string();
                                btn_char = "E";
                                t_l_descrip.Text = ""; t_l_quantity.Text = "1"; t_l_rate.Text = "0"; t_l_price.Text = "0";
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Should Fill All Text Fields");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
                
            }
            else if (btn_val == 2 & btn_char == "ED" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        t_l_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(t_l_descrip.Text) & !string.IsNullOrWhiteSpace(t_l_quantity.Text) & !string.IsNullOrWhiteSpace(t_l_rate.Text) & !string.IsNullOrWhiteSpace(t_l_bill_num.Text) & !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text) & !string.IsNullOrWhiteSpace(t_l_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update tank_expense set description='" + t_l_descrip.Text + "',quantity=" + Convert.ToInt32(t_l_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(t_l_rate.Text) + " where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='WORK-SHOP' and s_no=" + s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select quantity*quantity_rate as price from tank_expense where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='WORK-SHOP' ", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                double p_tot = 0;
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        p_tot += Convert.ToDouble(dt.Rows[i]["price"]);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Value Doesn't Exist");
                                }
                                t_l_total_amount.Text = p_tot.ToString();
                                t_l_grand_total.Text = (Convert.ToDouble(t_l_total_amount.Text) - Convert.ToDouble(t_l_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(t_l_total_amount.Text) + ",discount=" + Convert.ToDouble(t_l_discount_amount.Text) + ",gnd_total=" + t_l_grand_total.Text + " where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='WORK-SHOP' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM TANK_EXPENSE where  vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='WORK-SHOP' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                t_l_datagrid1.ItemsSource = dt1.DefaultView;
                                gridsize();
                                con.close_string();
                                btn_char = "E";
                                t_l_descrip.Text = ""; t_l_quantity.Text = "1"; t_l_rate.Text = "0"; t_l_price.Text = "0";
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Should Fill All Text Fields");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
                
            }
            else if (btn_val == 1 & btn_char == "V" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
               
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        t_l_vehicle_num.Text = "";
                    }
                  else  if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from tank_expense where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='LPG-TANK'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                t_l_datagrid1.ItemsSource = dt.DefaultView;
                                gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='LPG-TANK'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    t_l_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    t_l_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    t_l_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();
                                    t_l_bill_num.Text = dt1.Rows[0]["bill_no"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Bill Total Doesn't Exist");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bill Doesn't Exist");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
               
                
            }
            else if (btn_val == 2 & btn_char == "V" && !string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
               
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        t_l_vehicle_num.Text = "";
                    }
                   else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from tank_expense where vehicle='" + t_l_vehicle_num.Text + "' and bill_no = '" + t_l_view_bill_number.Text + "' and expense_type='WORK-SHOP'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                t_l_datagrid1.ItemsSource = dt.DefaultView;
                                gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + t_l_vehicle_num.Text + "' and bill_no='" + t_l_view_bill_number.Text + "' and expense_type='WORK-SHOP'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    t_l_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    t_l_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    t_l_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();
                                    t_l_bill_num.Text = dt1.Rows[0]["bill_no"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Bill Total Doesn't Exist");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bill Doesn't Exist");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
               
                
            }
            else
            {
                MessageBox.Show("Select Which Operation You Want To Do");
            }
        }

        void tank_lpg_datagrid1_mouseclick(object sender, MouseButtonEventArgs e)
        {
            if (btn_val == 1 & btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)t_l_datagrid1.SelectedItem;
                    t_l_descrip.Text = (dr["description"]).ToString();
                    s_val = Convert.ToInt32(dr["s_no"]);
                    t_l_quantity.Text = (dr["quantity"]).ToString();
                    t_l_rate.Text = (dr["rate"]).ToString();
                    t_l_price.Text = (dr["price"]).ToString();
                    btn_char = "NE";
                    t_l_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (btn_val == 2 & btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)t_l_datagrid1.SelectedItem;
                    t_l_descrip.Text = (dr["description"]).ToString();
                    s_val = Convert.ToInt32(dr["s_no"]);
                    t_l_quantity.Text = (dr["quantity"]).ToString();
                    t_l_rate.Text = (dr["rate"]).ToString();
                    t_l_price.Text = (dr["price"]).ToString();
                    btn_char = "NE";
                    t_l_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (btn_val == 1 & btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)t_l_datagrid1.SelectedItem;
                    t_l_descrip.Text = (dr["description"]).ToString();
                    s_val = Convert.ToInt32(dr["s_no"]);
                    t_l_quantity.Text = (dr["quantity"]).ToString();
                    t_l_rate.Text = (dr["quantity_rate"]).ToString();
                    t_l_price.Text = (dr["price"]).ToString();
                    btn_char = "ED";
                    t_l_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (btn_val == 2 & btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)t_l_datagrid1.SelectedItem;
                    t_l_descrip.Text = (dr["description"]).ToString();
                    s_val = Convert.ToInt32(dr["s_no"]);
                    t_l_quantity.Text = (dr["quantity"]).ToString();
                    t_l_rate.Text = (dr["quantity_rate"]).ToString();
                    t_l_price.Text = (dr["price"]).ToString();
                    btn_char = "ED";
                    t_l_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else
            {
                MessageBox.Show("Select Which Operation You Want To Do");
            }
        }


        void t_l_discount_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(string.IsNullOrWhiteSpace(t_l_discount_amount.Text))
                {
                    t_l_discount_amount.Text = "0";
                }
                if (btn_char == "N")
                {
                    t_l_grand_total.Text = (Convert.ToDouble(t_l_total_amount.Text) - Convert.ToDouble(t_l_discount_amount.Text)).ToString();
                    t_l_done_bttn.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    t_l_grand_total.Text = (Convert.ToDouble(t_l_total_amount.Text) - Convert.ToDouble(t_l_discount_amount.Text)).ToString();
                    t_l_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                }

            }
        }


        void tank_lpg_bill_details_done_click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = t_l_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        t_l_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (btn_val == 1 & btn_char == "N")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                                if (mbr == MessageBoxResult.OK)
                                {
                                    for (int i = 0; i < Convert.ToInt32(t_l_S_NO.Text) - 1; i++)
                                    {
                                        OdbcCommand cmd = new OdbcCommand("insert into tank_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(snos[i]) + ",'" + t_l_bill_num.Text + "','" + t_l_vehicle_num.Text + "','" + des[i] + "'," + qnty[i] + "," + qnt_rate[i] + ",'" + Convert.ToDateTime(t_l_bill_date.Text).ToString("yyyy/MM/dd") + "','LPG-TANK')", con.str);
                                        cmd.ExecuteNonQuery();
                                    }

                                    OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + t_l_bill_num.Text + "','" + Convert.ToDateTime(t_l_bill_date.Text).ToString("yyyy/MM/dd") + "','" + t_l_vehicle_num.Text + "'," + t_l_total_amount.Text + "," + t_l_discount_amount.Text + "," + t_l_grand_total.Text + ",'LPG-TANK')", con.str);
                                    cmd1.ExecuteNonQuery();
                                    clear_array();
                                    t_l_datagrid1.ItemsSource = null;
                                    t_l_datagrid1.Items.Refresh();
                                    t_l_vehicle_num.Text = ""; t_l_bill_date.Text = DateTime.Now.ToShortDateString(); t_l_bill_num.Text = ""; t_l_bill_num.IsEnabled = true; t_l_S_NO.Text = "1"; t_l_total_amount.Text = "0"; t_l_discount_amount.Text = "0"; t_l_grand_total.Text = "0";
                                    t_l_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                    t_l_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                    t_l_descrip.Focus();

                                }
                                else if (mbr == MessageBoxResult.Cancel)
                                {

                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else if (btn_val == 2 & btn_char == "N")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                                if (mbr == MessageBoxResult.OK)
                                {
                                    for (int i = 0; i < Convert.ToInt32(t_l_S_NO.Text) - 1; i++)
                                    {
                                        OdbcCommand cmd = new OdbcCommand("insert into tank_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(snos[i]) + ",'" + t_l_bill_num.Text + "','" + t_l_vehicle_num.Text + "','" + des[i] + "'," + qnty[i] + "," + qnt_rate[i] + ",'" + Convert.ToDateTime(t_l_bill_date.Text).ToString("yyyy/MM/dd") + "','WORK-SHOP')", con.str);
                                        cmd.ExecuteNonQuery();
                                    }

                                    OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + t_l_bill_num.Text + "','" + Convert.ToDateTime(t_l_bill_date.Text).ToString("yyyy/MM/dd") + "','" + t_l_vehicle_num.Text + "'," + t_l_total_amount.Text + "," + t_l_discount_amount.Text + "," + t_l_grand_total.Text + ",'WORK-SHOP')", con.str);
                                    cmd1.ExecuteNonQuery();
                                    clear_array();
                                    t_l_datagrid1.ItemsSource = null;
                                    t_l_datagrid1.Items.Refresh();
                                    t_l_vehicle_num.Text = ""; t_l_bill_date.Text = DateTime.Now.ToShortDateString(); t_l_bill_num.Text = ""; t_l_bill_num.IsEnabled = true; t_l_S_NO.Text = "1"; t_l_discount_amount.Text = "0"; t_l_grand_total.Text = "0"; t_l_total_amount.Text = "0";
                                    t_l_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                    t_l_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                    t_l_descrip.Focus();
                                }
                                else if (mbr == MessageBoxResult.Cancel)
                                {

                                }
                                con.close_string();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select New Button the Press Here");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number is Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }
           
           
        }


        void tank_lpg_clear_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.connection_string();
                OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
                cmd.ExecuteNonQuery();
                con.close_string();
            }
            catch
            {
                MessageBox.Show("Error Delete LPG Tank Details");
            }
           
            clear_array();
            t_l_datagrid1.ItemsSource = null;
            t_l_datagrid1.Items.Refresh();
            t_l_done_bttn.Visibility = System.Windows.Visibility.Hidden;
            t_l_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
            t_l_descrip.Text = ""; t_l_quantity.Text = "1"; t_l_rate.Text = "0"; t_l_price.Text = "0";
            t_l_vehicle_num.Text = ""; t_l_bill_date.Text = ""; t_l_bill_num.Text = ""; t_l_S_NO.Text = "1"; t_l_discount_amount.Text = "0"; t_l_grand_total.Text = "0"; t_l_total_amount.Text = "0";
        }


        void clear_array()
        {
            Array.Clear(des, 0, des.Length);
            Array.Clear(qnty, 0, qnty.Length);
            Array.Clear(qnt_rate, 0, qnt_rate.Length);
            Array.Clear(qnt_price, 0, qnt_price.Length); ;
            Array.Clear(snos, 0, snos.Length);

        }
       public void add_item1()
        {
            t_l_descrip.Items.Add("TOP");
            t_l_descrip.Items.Add("BOTTOM");
            t_l_descrip.Items.Add("HYDROWORK"); t_l_descrip.Items.Add("PURCHING"); t_l_descrip.Items.Add("HALF_YEAR"); t_l_descrip.Items.Add("YEARLY"); t_l_descrip.Items.Add("EXPLOSIVE");
        }
      public  void add_item2()
        {
            t_l_descrip.Items.Add("TURNPLATE");
            t_l_descrip.Items.Add("HANDBUSH");
            t_l_descrip.Items.Add("ALIGNMENT");
        }
        void gridsize()
        {
            t_l_datagrid1.Columns[0].Width = 72;
            t_l_datagrid1.Columns[1].Width = 250;
            t_l_datagrid1.Columns[2].Width = 120;
            t_l_datagrid1.Columns[3].Width = 120;
            t_l_datagrid1.Columns[4].Width = 120;

        }
        void Rate_PreViewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }

        void Discount_PreViewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }
        void Tank_Rate_Textchanged(object sender, TextChangedEventArgs e)
        {
            int len = 0;
            string s = t_l_rate.Text;
            if(!string.IsNullOrWhiteSpace(t_l_rate.Text))
            {
                len = t_l_rate.Text.Length;
                if (len < 4)
                {
                    for (int i = 0; i < len; i++)
                    {
                        bool isdigit = char.IsDigit(s[i]);
                        if (isdigit)
                        {

                        }
                        else
                        {
                            System.Media.SystemSounds.Beep.Play();
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }
            }
            
            
           
        }
        void Tank_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(t_l_vehicle_num.Text))
            {

                len = t_l_vehicle_num.Text.Length;
            }
            else
            {
                len = 0;
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
        void Tank_Bill_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(t_l_view_bill_number.Text))
            {

                len = t_l_view_bill_number.Text.Length;
            }
            else
            {
                len = 0;
            }

            if (len >= 8)
            {
                if (e.Key != Key.Back)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }

            }
        }
        void Tank_Description_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(t_l_descrip.Text))
            {

                len = t_l_descrip.Text.Length;
            }
            else
            {
                len = 0;
            }

            if (len >= 30)
            {
                if (e.Key != Key.Back)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            t_l_vehicle_num.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                t_l_vehicle_num.Items.Add(dt.Rows[i]["vehicle_number"]);
            }
        }
    }
}
