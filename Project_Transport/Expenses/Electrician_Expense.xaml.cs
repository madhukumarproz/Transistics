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
    /// Interaction logic for Electrician_Maintenance.xaml
    /// </summary>
    public partial class Electrician_Maintenance : UserControl
    {
        public Electrician_Maintenance()
        {
            InitializeComponent();
            elc_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            elc_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            elc_done_bttn.Visibility = System.Windows.Visibility.Hidden;
        }


        int button_val = 0;
        string character = null;
        int[] elc_sno = new int[50];
        string[] billno = new string[50];
        string[] vno = new string[50];
        string[] desc = new string[50];
        int[] quan = new int[50];
        double[] rate = new double[50];
        double[] cost = new double[50];
        string[] billdate = new string[50];
        DataTable data_table;
        int nos = 0;
        int noss = 0;
        void battery_expense(object sender, RoutedEventArgs e)
        {
            elc_battery_expense.Background = System.Windows.Media.Brushes.Green;
            elc_dynamo_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_self_motor_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_electrian_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.IsEnabled = true;
            elc_edit_bill.IsEnabled = true;
            elc_view_bill.IsEnabled = true;
            elc_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            button_val = 1;
            elc_datagrid1.ItemsSource = null;
            elc_datagrid1.Items.Refresh();
            character = "";
        }
        void dynamo_expense(object sender, RoutedEventArgs e)
        {
            elc_battery_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_dynamo_expense.Background = System.Windows.Media.Brushes.Green;
            elc_self_motor_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_electrian_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.IsEnabled = true;
            elc_edit_bill.IsEnabled = true;
            elc_view_bill.IsEnabled = true;
            elc_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            button_val = 2;
            elc_datagrid1.ItemsSource = null;
            elc_datagrid1.Items.Refresh();
            character = "";
        }
        void self_motor_expense(object sender, RoutedEventArgs e)
        {
            elc_battery_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_dynamo_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_self_motor_expense.Background = System.Windows.Media.Brushes.Green;
            elc_electrian_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.IsEnabled = true;
            elc_edit_bill.IsEnabled = true;
            elc_view_bill.IsEnabled = true;
            elc_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            button_val = 3;
            elc_datagrid1.ItemsSource = null;
            elc_datagrid1.Items.Refresh();
            character = "";
        }
        void elc_electrician_expense(object sender, RoutedEventArgs e)
        {
            elc_battery_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_dynamo_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_self_motor_expense.Background = System.Windows.Media.Brushes.Yellow;
            elc_electrian_expense.Background = System.Windows.Media.Brushes.Green;
            elc_new_bill.IsEnabled = true;
            elc_edit_bill.IsEnabled = true;
            elc_view_bill.IsEnabled = true;
            elc_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            button_val = 4;
            elc_datagrid1.ItemsSource = null;
            elc_datagrid1.Items.Refresh();
            character = "";
        }



        void elc_new_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Elc_Vehicle_Number = "";
            g.Elc_Description = "";
            g.Elc_Quantity = "1";
            g.Elc_Rate = "";
            g.Elc_Bill_No = "";
            g.Elc_Discount = "";
            g.Elc_Bill_Num = "";
            this.DataContext = g;
            elc_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.Background = System.Windows.Media.Brushes.Green;
            character = "N";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd2 = new OdbcCommand("delete  from electrical", con.str);
            cmd2.ExecuteNonQuery();
            con.close_string();
            array_clear();
            elc_discount_amount.IsEnabled = true;
            elc_descrip.Visibility = System.Windows.Visibility.Visible;
            elc_quantity.Visibility = System.Windows.Visibility.Visible;
            elc_rate.Visibility = System.Windows.Visibility.Visible;
            elc_price.Visibility = System.Windows.Visibility.Visible;
            elc_bill_date.Visibility = System.Windows.Visibility.Visible;
            elc_bill_no.Visibility = System.Windows.Visibility.Visible;
            elc_bill_num.Visibility = System.Windows.Visibility.Visible;
            elc_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            elc_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            elc_discount_amount.IsEnabled = true;
            elc_S_NO.Text = "1";
            elc_bill_num.IsEnabled = true;
            elc_bill_num.Text = "";
            elc_descrip.Focus();
            elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0"; elc_discount_amount.Text = "0"; elc_total_amount.Text = "0"; elc_grand_total.Text = "0"; elc_vehicle_num.Text = "VEHICLE";
        }


        void elc_edit_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Elc_Vehicle_Number = "";
            g.Elc_Description = "";
            g.Elc_Quantity = "1";
            g.Elc_Rate = "";
            g.Elc_Bill_No = "";
            g.Elc_Discount = "";
            g.Elc_Bill_Num = "";
            this.DataContext = g;
            elc_edit_bill.Background = System.Windows.Media.Brushes.Green;
            elc_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            character = "E";
            elc_discount_amount.IsEnabled = true;
            elc_descrip.Visibility = System.Windows.Visibility.Visible;
            elc_quantity.Visibility = System.Windows.Visibility.Visible;
            elc_rate.Visibility = System.Windows.Visibility.Visible;
            elc_price.Visibility = System.Windows.Visibility.Visible;
            elc_bill_date.Visibility = System.Windows.Visibility.Hidden;
            elc_bill_no.Visibility = System.Windows.Visibility.Hidden;
            elc_bill_num.Visibility = System.Windows.Visibility.Hidden;
            elc_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            elc_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
            elc_datagrid1.ItemsSource = null;
            elc_datagrid1.Items.Refresh();
            elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0"; elc_discount_amount.Text = "0"; elc_total_amount.Text = "0"; elc_grand_total.Text = "0"; elc_vehicle_num.Text = "VEHICLE";
        }
        void elc_view_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Elc_Vehicle_Number = "";
            g.Bill_Num = "";
            this.DataContext = g;
            elc_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            elc_view_bill.Background = System.Windows.Media.Brushes.Green;
            elc_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            character = "V";
            elc_discount_amount.IsEnabled = false;
            elc_descrip.Visibility = System.Windows.Visibility.Hidden;
            elc_quantity.Visibility = System.Windows.Visibility.Hidden;
            elc_rate.Visibility = System.Windows.Visibility.Hidden;
            elc_price.Visibility = System.Windows.Visibility.Hidden;
            elc_bill_date.Visibility = System.Windows.Visibility.Hidden;
            elc_bill_no.Visibility = System.Windows.Visibility.Hidden;
            elc_bill_num.Visibility = System.Windows.Visibility.Hidden;
            elc_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            elc_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
            elc_bill_num.IsEnabled = false;
            elc_datagrid1.ItemsSource = null;
            elc_datagrid1.Items.Refresh();
            elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0"; elc_discount_amount.Text = "0"; elc_total_amount.Text = "0"; elc_grand_total.Text = "0"; elc_vehicle_num.Text = "VEHICLE";
        }

        void elc_quantity_rate_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                elc_price.Text = (Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text)).ToString();

            }
        }


        void elc_vehicle_number(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter && !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (button_val == 1 && character == "E")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='BATTERY' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                elc_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }


                        }
                        else if (button_val == 2 && character == "E")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='DYNAMO' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                elc_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (button_val == 3 && character == "E")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='SELFMOTOR' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                elc_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (button_val == 4 && character == "E")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='ELECTRICIAN' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                elc_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (button_val == 1 && character == "V")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='BATTERY' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                elc_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (button_val == 2 && character == "V")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='DYNAMO' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                elc_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (button_val == 3 && character == "V")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='SELFMOTOR' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                elc_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (button_val == 4 && character == "V")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='ELECTRICIAN' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                elc_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else if (character == "N")
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
        }


        void elc_add_all_bill_number_checked(object sender, RoutedEventArgs e)
        {
            elc_add_all_bill_number.IsChecked = false;
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER" & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string l = elc_vehicle_num.Text;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    elc_vehicle_num.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    if (character == "E" & button_val == 1 & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
                    {

                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='BATTERY' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else if (character == "E" & button_val == 2 & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='DYNAMO' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else if (character == "E" & button_val == 3 & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='SELFMOTOR' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else if (character == "E" & button_val == 4 & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='ELECTRICIAN' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else if (character == "V" & button_val == 1 & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='BATTERY' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else if (character == "V" & button_val == 2 & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='DYNAMO' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else if (character == "V" & button_val == 3 & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='SELFMOTOR' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                    }
                    else if (character == "V" & button_val == 4 & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + elc_vehicle_num.Text + "' AND expense_type='ELECTRICIAN' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    elc_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Bill Doesnot Exist, Please Make Bill Entry");
                            }
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


        void elc_bill_num_keydown(object sender, KeyEventArgs e)
        {
            if (elc_bill_num.Text.Length >= 6)
            {
                MessageBoxResult mr = MessageBox.Show("Length Should be Less-than 6 Digit", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (mr == MessageBoxResult.OK)
                {
                    e.Handled = true;
                    elc_bill_num.Text = "";
                }
                else if(mr==MessageBoxResult.Cancel)
                {

                }
            }
            else if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (character == "N" & string.IsNullOrWhiteSpace(elc_bill_num.Text))
                {
                    try
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
                                elc_bill_num.Text = (Convert.ToInt32(dt1.Rows[0]["bill_nos"]) + 1).ToString();
                                elc_bill_num.IsEnabled = false;
                            }
                            catch
                            {
                                elc_bill_num.Text = "0001";
                                elc_bill_num.IsEnabled = false;
                            }

                        }
                        else
                        {
                            elc_bill_num.Text = "0001";
                            elc_bill_num.IsEnabled = false;
                        }
                        con1.close_string();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                   
                }
                else
                {
                    elc_bill_num.IsEnabled = false;
                }


            }
        }


        void elc_add_new_row(object sender, RoutedEventArgs e)
        {
            

            if (button_val == 1 & character.Equals("N") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            elc_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                            double tot = 0;
                            int sno = Convert.ToInt32(elc_S_NO.Text) - 1;
                            elc_sno[sno] = Convert.ToInt32(elc_S_NO.Text);
                            billno[sno] = elc_bill_num.Text;
                            vno[sno] = elc_vehicle_num.Text;
                            desc[sno] = elc_descrip.Text;
                            quan[sno] = Convert.ToInt32(elc_quantity.Text);
                            rate[sno] = Convert.ToDouble(elc_rate.Text);
                            cost[sno] = Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text);
                            billdate[sno] = Convert.ToDateTime(elc_bill_date.Text).ToString("dd/MM/yyyy");
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("insert into electrical(s_no,description,quantity,quantity_rate,price)values(" + Convert.ToInt32(elc_S_NO.Text) + ",'" + elc_descrip.Text + "'," + Convert.ToInt32(elc_quantity.Text) + "," + Convert.ToDouble(elc_rate.Text) + "," + Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text) + ")", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE from electrical", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            data_table = new DataTable();
                            da.Fill(data_table);

                            for (int i = 0; i <= sno; i++)
                            {

                                tot += Convert.ToDouble(cost[i]);
                            }
                            elc_datagrid1.ItemsSource = data_table.DefaultView;
                            grid_size();

                            elc_descrip.Focus();
                            elc_total_amount.Text = tot.ToString();
                            elc_S_NO.Text = (Convert.ToInt32(elc_S_NO.Text) + 1).ToString();
                            elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0";
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
            else if (button_val == 2 & character.Equals("N") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            elc_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                            double tot = 0;
                            int sno = Convert.ToInt32(elc_S_NO.Text) - 1;
                            elc_sno[sno] = Convert.ToInt32(elc_S_NO.Text);
                            billno[sno] = elc_bill_num.Text;
                            vno[sno] = elc_vehicle_num.Text;
                            desc[sno] = elc_descrip.Text;
                            quan[sno] = Convert.ToInt32(elc_quantity.Text);
                            rate[sno] = Convert.ToDouble(elc_rate.Text);
                            cost[sno] = Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text);
                            billdate[sno] = Convert.ToDateTime(elc_bill_date.Text).ToString("dd/MM/yyyy");
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("insert into electrical(s_no,description,quantity,quantity_rate,price)values(" + Convert.ToInt32(elc_S_NO.Text) + ",'" + elc_descrip.Text + "'," + Convert.ToInt32(elc_quantity.Text) + "," + Convert.ToDouble(elc_rate.Text) + "," + Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text) + ")", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE from electrical", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            data_table = new DataTable();
                            da.Fill(data_table);


                            for (int i = 0; i <= sno; i++)
                            {

                                tot += Convert.ToDouble(cost[i]);
                            }
                            elc_datagrid1.ItemsSource = data_table.DefaultView;
                            grid_size();
                            elc_descrip.Focus();

                            elc_total_amount.Text = tot.ToString();
                            elc_S_NO.Text = (Convert.ToInt32(elc_S_NO.Text) + 1).ToString();
                            elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0";
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
            else if (button_val == 3 & character.Equals("N") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            elc_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                            double tot = 0;
                            int sno = Convert.ToInt32(elc_S_NO.Text) - 1;
                            elc_sno[sno] = Convert.ToInt32(elc_S_NO.Text);
                            billno[sno] = elc_bill_num.Text;
                            vno[sno] = elc_vehicle_num.Text;
                            desc[sno] = elc_descrip.Text;
                            quan[sno] = Convert.ToInt32(elc_quantity.Text);
                            rate[sno] = Convert.ToDouble(elc_rate.Text);
                            cost[sno] = Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text);
                            billdate[sno] = Convert.ToDateTime(elc_bill_date.Text).ToString("dd/MM/yyyy");
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("insert into electrical(s_no,description,quantity,quantity_rate,price)values(" + Convert.ToInt32(elc_S_NO.Text) + ",'" + elc_descrip.Text + "'," + Convert.ToInt32(elc_quantity.Text) + "," + Convert.ToDouble(elc_rate.Text) + "," + Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text) + ")", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE from electrical", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            data_table = new DataTable();
                            da.Fill(data_table);


                            for (int i = 0; i <= sno; i++)
                            {

                                tot += Convert.ToDouble(cost[i]);
                            }
                            elc_datagrid1.ItemsSource = data_table.DefaultView;
                            grid_size();

                            elc_total_amount.Text = tot.ToString();
                            elc_descrip.Focus();
                            elc_S_NO.Text = (Convert.ToInt32(elc_S_NO.Text) + 1).ToString();
                            elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0";
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
            else if (button_val == 4 & character.Equals("N") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            elc_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                            double tot = 0;
                            int sno = Convert.ToInt32(elc_S_NO.Text) - 1;
                            elc_sno[sno] = Convert.ToInt32(elc_S_NO.Text);
                            billno[sno] = elc_bill_num.Text;
                            vno[sno] = elc_vehicle_num.Text;
                            desc[sno] = elc_descrip.Text;
                            quan[sno] = Convert.ToInt32(elc_quantity.Text);
                            rate[sno] = Convert.ToDouble(elc_rate.Text);
                            cost[sno] = Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text);
                            billdate[sno] = Convert.ToDateTime(elc_bill_date.Text).ToString("dd/MM/yyyy");
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("insert into electrical(s_no,description,quantity,quantity_rate,price)values(" + Convert.ToInt32(elc_S_NO.Text) + ",'" + elc_descrip.Text + "'," + Convert.ToInt32(elc_quantity.Text) + "," + Convert.ToDouble(elc_rate.Text) + "," + Convert.ToDouble(elc_rate.Text) * Convert.ToInt32(elc_quantity.Text) + ")", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE from electrical", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            data_table = new DataTable();
                            da.Fill(data_table);


                            for (int i = 0; i <= sno; i++)
                            {

                                tot += Convert.ToDouble(cost[i]);
                            }
                            elc_datagrid1.ItemsSource = data_table.DefaultView;
                            grid_size();

                            elc_total_amount.Text = tot.ToString();
                            elc_descrip.Focus();
                            elc_S_NO.Text = (Convert.ToInt32(elc_S_NO.Text) + 1).ToString();
                            elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0";
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
            else if (button_val == 1 & character.Equals("E") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='BATTERY'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt1.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='BATTERY'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    elc_discount_amount.Text = dt2.Rows[0]["discount"].ToString();
                                    elc_grand_total.Text = dt2.Rows[0]["gnd_total"].ToString();
                                }
                                else
                                {
                                    // MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
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
                            MessageBox.Show("Please Select Vehicle Number and Date");
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
            else if (button_val == 2 & character.Equals("E") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='DYNAMO'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt1.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='DYNAMO'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    elc_discount_amount.Text = dt2.Rows[0]["discount"].ToString();
                                    elc_grand_total.Text = dt2.Rows[0]["gnd_total"].ToString();
                                }
                                else
                                {
                                    //MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
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
                            MessageBox.Show("Please Select Vehicle Number and Date");
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
            else if (button_val == 3 & character.Equals("E") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='SELFMOTOR'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt1.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='SELFMOTOR'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    elc_discount_amount.Text = dt2.Rows[0]["discount"].ToString();
                                    elc_grand_total.Text = dt2.Rows[0]["gnd_total"].ToString();
                                }
                                else
                                {
                                    // MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
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
                            MessageBox.Show("Please Select Vehicle Number and Date");
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
            else if (button_val == 4 & character.Equals("E") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='ELECTRICIAN'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt1.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='ELECTRICIAN'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    elc_discount_amount.Text = dt2.Rows[0]["discount"].ToString();
                                    elc_grand_total.Text = dt2.Rows[0]["gnd_total"].ToString();
                                }
                                else
                                {
                                    // MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
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
                            MessageBox.Show("Please Select Vehicle Number and Date");
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
            else if (button_val == 1 & character.Equals("V") )
            {
                if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                    {
                        string l = elc_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            elc_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='BATTERY'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt1.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='BATTERY'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    elc_discount_amount.Text = dt2.Rows[0]["discount"].ToString();
                                    elc_grand_total.Text = dt2.Rows[0]["gnd_total"].ToString();

                                }
                                else
                                {
                                    // MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
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
                else
                {
                    MessageBox.Show("Please Select Vehicle Number and Date");
                }
            }
            else if (button_val == 2 & character.Equals("V") )
            {
                if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                    {
                        string l = elc_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            elc_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='DYNAMO'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt1.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='DYNAMO'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    elc_discount_amount.Text = dt2.Rows[0]["discount"].ToString();
                                    elc_grand_total.Text = dt2.Rows[0]["gnd_total"].ToString();

                                }
                                else
                                {
                                    //MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
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
                else
                {
                    MessageBox.Show("Please Select Vehicle Number and Date");
                }
            }
            else if (button_val == 3 & character.Equals("V") )
            {
                if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                    {
                        string l = elc_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            elc_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='SELFMOTOR'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt1.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='SELFMOTOR'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    elc_discount_amount.Text = dt2.Rows[0]["discount"].ToString();
                                    elc_grand_total.Text = dt2.Rows[0]["gnd_total"].ToString();

                                }
                                else
                                {
                                    // MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
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
                else
                {
                    MessageBox.Show("Please Select Vehicle Number and Date");
                }
            }
            else if (button_val == 4 & character.Equals("V") )
            {
                if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                    {
                        string l = elc_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            elc_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='ELECTRICIAN'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt1.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='ELECTRICIAN'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    elc_discount_amount.Text = dt2.Rows[0]["discount"].ToString();
                                    elc_grand_total.Text = dt2.Rows[0]["gnd_total"].ToString();

                                }
                                else
                                {
                                    // MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
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


                else
                {
                    MessageBox.Show("Please Select Vehicle Number and Date");
                }
            }
            else if (button_val == 1 & character.Equals("NE") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        double tot_val = 0;
                        desc[nos] = elc_descrip.Text;
                        quan[nos] = Convert.ToInt32(elc_quantity.Text);
                        rate[nos] = Convert.ToDouble(elc_rate.Text);
                        cost[nos] = Convert.ToInt32(elc_quantity.Text) * Convert.ToDouble(elc_rate.Text);
                        for (int i = 0; i < Convert.ToInt32(elc_S_NO.Text) - 1; i++)
                        {
                            tot_val += cost[i];
                        }
                        elc_total_amount.Text = tot_val.ToString();
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update electrical set description='" + elc_descrip.Text + "',quantity=" + Convert.ToInt32(elc_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(elc_rate.Text) + ",price=" + Convert.ToDouble(elc_price.Text) + " where  s_no=" + noss + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE FROM electrical ", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_datagrid1.ItemsSource = dt.DefaultView;
                            grid_size();
                            con.close_string();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                        character = "N";
                        elc_descrip.Focus();
                        elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0";
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
            else if (button_val == 2 & character.Equals("NE") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        double tot_val = 0;
                        desc[nos] = elc_descrip.Text;
                        quan[nos] = Convert.ToInt32(elc_quantity.Text);
                        rate[nos] = Convert.ToDouble(elc_rate.Text);
                        cost[nos] = Convert.ToInt32(elc_quantity.Text) * Convert.ToDouble(elc_rate.Text);
                        for (int i = 0; i < Convert.ToInt32(elc_S_NO.Text) - 1; i++)
                        {
                            tot_val += cost[i];
                        }
                        elc_total_amount.Text = tot_val.ToString();
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update electrical set description='" + elc_descrip.Text + "',quantity=" + Convert.ToInt32(elc_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(elc_rate.Text) + ",price=" + Convert.ToDouble(elc_price.Text) + " where  s_no=" + noss + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE FROM electrical ", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_datagrid1.ItemsSource = dt.DefaultView;
                            grid_size();
                            con.close_string();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                        character = "N";
                        elc_descrip.Focus();
                        elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0";
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
            else if (button_val == 3 & character.Equals("NE") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        double tot_val = 0;
                        desc[nos] = elc_descrip.Text;
                        quan[nos] = Convert.ToInt32(elc_quantity.Text);
                        rate[nos] = Convert.ToDouble(elc_rate.Text);
                        cost[nos] = Convert.ToInt32(elc_quantity.Text) * Convert.ToDouble(elc_rate.Text);
                        for (int i = 0; i < Convert.ToInt32(elc_S_NO.Text) - 1; i++)
                        {
                            tot_val += cost[i];
                        }
                        elc_total_amount.Text = tot_val.ToString();
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update electrical set description='" + elc_descrip.Text + "',quantity=" + Convert.ToInt32(elc_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(elc_rate.Text) + ",price=" + Convert.ToDouble(elc_price.Text) + " where  s_no=" + noss + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE FROM electrical ", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_datagrid1.ItemsSource = dt.DefaultView;
                            grid_size();
                            con.close_string();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                        character = "N";
                        elc_descrip.Focus();
                        elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0";
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
            else if (button_val == 4 & character.Equals("NE") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        double tot_val = 0;
                        desc[nos] = elc_descrip.Text;
                        quan[nos] = Convert.ToInt32(elc_quantity.Text);
                        rate[nos] = Convert.ToDouble(elc_rate.Text);
                        cost[nos] = Convert.ToInt32(elc_quantity.Text) * Convert.ToDouble(elc_rate.Text);
                        for (int i = 0; i < Convert.ToInt32(elc_S_NO.Text) - 1; i++)
                        {
                            tot_val += cost[i];
                        }
                        elc_total_amount.Text = tot_val.ToString();
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update electrical set description='" + elc_descrip.Text + "',quantity=" + Convert.ToInt32(elc_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(elc_rate.Text) + ",price=" + Convert.ToDouble(elc_price.Text) + " where  s_no=" + noss + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE FROM electrical ", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            elc_datagrid1.ItemsSource = dt.DefaultView;
                            grid_size();
                            con.close_string();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }

                        character = "N";
                        elc_descrip.Focus();
                        elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0";
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
            else if (button_val == 1 & character.Equals("ED") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text) & !string.IsNullOrWhiteSpace(elc_descrip.Text) & elc_rate.Text != "0")
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update electrician_expense set description='" + elc_descrip.Text + "',quantity='" + elc_quantity.Text + "',quantity_rate='" + elc_rate.Text + "' where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and s_no=" + nos + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE from electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='BATTERY' ", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                double dd = 0;
                                if (dt.Rows.Count > 0)
                                {
                                    for (int I = 0; I < dt.Rows.Count; I++)
                                    {
                                        dd += Convert.ToDouble(dt.Rows[I]["PRICE"]);
                                    }
                                    elc_total_amount.Text = dd.ToString();
                                    elc_grand_total.Text = (dd - Convert.ToDouble(elc_discount_amount.Text)).ToString();
                                    OdbcCommand cmd3 = new OdbcCommand("update expense_bill set sub_total='" + elc_total_amount.Text + "',gnd_total='" + elc_grand_total.Text + "' where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='BATTERY' ", con.str);
                                    cmd3.ExecuteNonQuery();
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='BATTERY'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt2.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Record Doesn't Exist");
                                }
                                elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0"; //elc_total_amount.Text = "0"; elc_grand_total.Text = "0"; elc_discount_amount.Text = "0";
                                character = "E";
                                elc_descrip.Focus();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Check Vehicle Number,Date,Description and Rate is Empty");
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
            else if (button_val == 2 & character.Equals("ED") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text) & !string.IsNullOrWhiteSpace(elc_descrip.Text) & elc_rate.Text != "0")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update electrician_expense set description='" + elc_descrip.Text + "',quantity='" + elc_quantity.Text + "',quantity_rate='" + elc_rate.Text + "' where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and s_no=" + nos + "", con.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE from electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='DYNAMO'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                double dd = 0;
                                if (dt.Rows.Count > 0)
                                {
                                    for (int I = 0; I < dt.Rows.Count; I++)
                                    {
                                        dd += Convert.ToDouble(dt.Rows[I]["PRICE"]);
                                    }
                                    elc_total_amount.Text = dd.ToString();
                                    elc_grand_total.Text = (dd - Convert.ToDouble(elc_discount_amount.Text)).ToString();
                                    OdbcCommand cmd3 = new OdbcCommand("update expense_bill set sub_total='" + elc_total_amount.Text + "',gnd_total='" + elc_grand_total.Text + "' where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='DYNAMO' ", con.str);
                                    cmd3.ExecuteNonQuery();
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='DYNAMO'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt2.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Record Doesn't Exist");
                                }
                                character = "E";
                                elc_descrip.Focus();
                                elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0"; //elc_total_amount.Text = "0"; elc_grand_total.Text = "0"; elc_discount_amount.Text = "0";
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Check Vehicle Number,Date,Description and Rate is Empty");
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
            else if (button_val == 3 & character.Equals("ED") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text) & !string.IsNullOrWhiteSpace(elc_descrip.Text) & elc_rate.Text != "0")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update electrician_expense set description='" + elc_descrip.Text + "',quantity='" + elc_quantity.Text + "',quantity_rate='" + elc_rate.Text + "' where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and s_no=" + nos + "", con.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE from electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='SELFMOTOR'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                double dd = 0;
                                if (dt.Rows.Count > 0)
                                {
                                    for (int I = 0; I < dt.Rows.Count; I++)
                                    {
                                        dd += Convert.ToDouble(dt.Rows[I]["PRICE"]);
                                    }
                                    elc_total_amount.Text = dd.ToString();
                                    elc_grand_total.Text = (dd - Convert.ToDouble(elc_discount_amount.Text)).ToString();
                                    OdbcCommand cmd3 = new OdbcCommand("update expense_bill set sub_total='" + elc_total_amount.Text + "',gnd_total='" + elc_grand_total.Text + "' where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='SELFMOTOR' ", con.str);
                                    cmd3.ExecuteNonQuery();
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='SELFMOTOR'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt2.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Record Doesn't Exist");
                                }
                                character = "E";
                                elc_descrip.Focus();
                                elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0"; //elc_total_amount.Text = "0"; elc_grand_total.Text = "0"; elc_discount_amount.Text = "0";
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Check Vehicle Number,Date,Description and Rate is Empty");
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
            else if (button_val == 4 & character.Equals("ED") & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = elc_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        elc_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_bill_date.Text) & elc_bill_date.Text != "" & !string.IsNullOrWhiteSpace(elc_descrip.Text) & elc_rate.Text != "0")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update electrician_expense set description='" + elc_descrip.Text + "',quantity='" + elc_quantity.Text + "',quantity_rate='" + elc_rate.Text + "' where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and s_no=" + nos + "", con.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE from electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='ELECTRICIAN'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                double dd = 0;
                                if (dt.Rows.Count > 0)
                                {
                                    for (int I = 0; I < dt.Rows.Count; I++)
                                    {
                                        dd += Convert.ToDouble(dt.Rows[I]["PRICE"]);
                                    }
                                    elc_total_amount.Text = dd.ToString();
                                    elc_grand_total.Text = (dd - Convert.ToDouble(elc_discount_amount.Text)).ToString();
                                    OdbcCommand cmd3 = new OdbcCommand("update expense_bill set sub_total='" + elc_total_amount.Text + "',gnd_total='" + elc_grand_total.Text + "' where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='ELECTRICIAN' ", con.str);
                                    cmd3.ExecuteNonQuery();
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from electrician_expense where vehicle='" + elc_vehicle_num.Text + "' and bill_no='" + elc_view_bill_number.Text + "' and expense_type='ELECTRICIAN'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    elc_datagrid1.ItemsSource = dt2.DefaultView;
                                    grid_size();
                                }
                                else
                                {
                                    MessageBox.Show("Record Doesn't Exist");
                                }
                                character = "E";
                                elc_descrip.Focus();
                                elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0"; //elc_total_amount.Text = "0"; elc_grand_total.Text = "0"; elc_discount_amount.Text = "0";
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Check Vehicle Number,Date,Description and Rate is Empty");
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
            else if (character == "")
            {
                MessageBox.Show("Select New Bill or Edit or View");
            }
            else
            {
                MessageBox.Show("Select Which Type of work You Want to Do");
            }

        }


        void elc_datagrid1_mouseclick(object sender, MouseButtonEventArgs e)
        {
            if (button_val == 1 & character.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)elc_datagrid1.SelectedItem;
                    nos = Convert.ToInt32(dr["s_no"]) - 1;
                    noss = Convert.ToInt32(dr["s_no"]);
                    elc_descrip.Text = (dr["description"]).ToString();
                    elc_quantity.Text = (dr["quantity"]).ToString();
                    elc_rate.Text = (dr["quantity_rate"]).ToString();
                    elc_price.Text = (dr["price"]).ToString();
                    character = "NE";
                    elc_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Data Grid is Empty");
                }
            }
            else if (button_val == 2 & character.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)elc_datagrid1.SelectedItem;
                    nos = Convert.ToInt32(dr["s_no"]) - 1;
                    elc_descrip.Text = (dr["description"]).ToString();
                    elc_quantity.Text = (dr["quantity"]).ToString();
                    elc_rate.Text = (dr["quantity_rate"]).ToString();
                    elc_price.Text = (dr["price"]).ToString();
                    character = "NE";
                    elc_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Data Grid is Empty");
                }
            }
            else if (button_val == 3 & character.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)elc_datagrid1.SelectedItem;
                    nos = Convert.ToInt32(dr["s_no"]) - 1;
                    elc_descrip.Text = (dr["description"]).ToString();
                    elc_quantity.Text = (dr["quantity"]).ToString();
                    elc_rate.Text = (dr["quantity_rate"]).ToString();
                    elc_price.Text = (dr["price"]).ToString();
                    character = "NE";
                    elc_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Data Grid is Empty");
                }
            }
            else if (button_val == 4 & character.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)elc_datagrid1.SelectedItem;
                    nos = Convert.ToInt32(dr["s_no"]) - 1;
                    elc_descrip.Text = (dr["description"]).ToString();
                    elc_quantity.Text = (dr["quantity"]).ToString();
                    elc_rate.Text = (dr["quantity_rate"]).ToString();
                    elc_price.Text = (dr["price"]).ToString();
                    character = "NE";
                    elc_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Data Grid is Empty");
                }
            }
            else if (button_val == 1 & character.Equals("E"))
            {

                if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                {
                    try
                    {
                        DataRowView dr = (DataRowView)elc_datagrid1.SelectedItem;
                        nos = Convert.ToInt32(dr["s_no"]);
                        elc_descrip.Text = (dr["description"]).ToString();
                        elc_quantity.Text = (dr["quantity"]).ToString();
                        elc_rate.Text = (dr["quantity_rate"]).ToString();
                        elc_price.Text = (dr["price"]).ToString();
                        character = "ED";
                        elc_descrip.Focus();

                    }
                    catch
                    {
                        MessageBox.Show("Data Grid is Empty");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Vehicle Number and Date");
                }



            }
            else if (button_val == 2 & character.Equals("E"))
            {

                if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                {
                    try
                    {
                        DataRowView dr = (DataRowView)elc_datagrid1.SelectedItem;
                        nos = Convert.ToInt32(dr["s_no"]);
                        elc_descrip.Text = (dr["description"]).ToString();
                        elc_quantity.Text = (dr["quantity"]).ToString();
                        elc_rate.Text = (dr["quantity_rate"]).ToString();
                        elc_price.Text = (dr["price"]).ToString();
                        character = "ED";
                        elc_descrip.Focus();

                    }
                    catch
                    {
                        MessageBox.Show("Data Grid is Empty");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Vehicle Number and Date");
                }


            }
            else if (button_val == 3 & character.Equals("E"))
            {

                if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                {
                    try
                    {
                        DataRowView dr = (DataRowView)elc_datagrid1.SelectedItem;
                        nos = Convert.ToInt32(dr["s_no"]);
                        elc_descrip.Text = (dr["description"]).ToString();
                        elc_quantity.Text = (dr["quantity"]).ToString();
                        elc_rate.Text = (dr["quantity_rate"]).ToString();
                        elc_price.Text = (dr["price"]).ToString();
                        character = "ED";
                        elc_descrip.Focus();

                    }
                    catch
                    {
                        MessageBox.Show("Data Grid is Empty");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Vehicle Number and Date");
                }

            }
            else if (button_val == 4 & character.Equals("E"))
            {

                if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
                {
                    try
                    {
                        DataRowView dr = (DataRowView)elc_datagrid1.SelectedItem;
                        nos = Convert.ToInt32(dr["s_no"]);
                        elc_descrip.Text = (dr["description"]).ToString();
                        elc_quantity.Text = (dr["quantity"]).ToString();
                        elc_rate.Text = (dr["quantity_rate"]).ToString();
                        elc_price.Text = (dr["price"]).ToString();
                        character = "ED";
                        elc_descrip.Focus();

                    }
                    catch
                    {
                        MessageBox.Show("Data Grid is Empty");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Vehicle Number and Date");
                }

            }
            else if (character == "V")
            {
                MessageBox.Show("You Can't Edit in View Mode");
            }
            else
            {
                MessageBox.Show("Select Which Type of work You Want to Do");
            }
        }



        void elc_discount_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(elc_discount_amount.Text))
                {
                    elc_discount_amount.Text = "0";
                }
                if (Convert.ToDouble(elc_total_amount.Text) != 0)
                {
                    if (character == "ED")
                    {
                        elc_grand_total.Text = (Convert.ToDouble(elc_total_amount.Text) - Convert.ToDouble(elc_discount_amount.Text)).ToString();
                        elc_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        elc_grand_total.Text = (Convert.ToDouble(elc_total_amount.Text) - Convert.ToDouble(elc_discount_amount.Text)).ToString();
                        elc_done_bttn.Visibility = System.Windows.Visibility.Visible;
                    }

                }
                else
                {
                    MessageBox.Show("Add Atleast One Bill Details");
                }

            }
        }



        void electrician_bill_details_done_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER" & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {
                string l = elc_vehicle_num.Text;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    elc_vehicle_num.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    if (button_val == 1 & character.Equals("N"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_bill_num.Text) & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_bill_date.Text))
                        {
                            if (elc_bill_date.Text.Equals("Select Date"))
                            {
                                MessageBox.Show("Select Date from Date Field");
                            }
                            else
                            {
                                try
                                {
                                    Connection con = new Connection();
                                    con.connection_string();
                                    MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                                    if (mbr == MessageBoxResult.OK)
                                    {
                                        for (int i = 0; i < Convert.ToInt32(elc_S_NO.Text) - 1; i++)
                                        {
                                            OdbcCommand cmd = new OdbcCommand("insert into electrician_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + elc_sno[i] + ",'" + elc_bill_num.Text + "','" + elc_vehicle_num.Text + "','" + desc[i] + "'," + quan[i] + "," + rate[i] + ",'" + Convert.ToDateTime(elc_bill_date.Text).ToString("yyyy/MM/dd") + "','BATTERY')", con.str);
                                            cmd.ExecuteNonQuery();

                                        }
                                        OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + elc_bill_num.Text + "','" + Convert.ToDateTime(elc_bill_date.Text).ToString("yyyy/MM/dd") + "','" + elc_vehicle_num.Text + "','" + Convert.ToDouble(elc_total_amount.Text) + "'," + Convert.ToDouble(elc_discount_amount.Text) + "," + Convert.ToDouble(elc_grand_total.Text) + ",'BATTERY')", con.str);
                                        cmd1.ExecuteNonQuery();
                                        elc_bill_num.Text = ""; elc_bill_num.IsEnabled = true;
                                        elc_vehicle_num.Text = ""; elc_bill_date.Text = DateTime.Now.ToShortDateString(); elc_total_amount.Text = "0"; elc_discount_amount.Text = "0"; elc_grand_total.Text = "0";
                                        elc_S_NO.Text = "1";
                                        elc_datagrid1.ItemsSource = null;
                                        elc_datagrid1.Items.Refresh();
                                        elc_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                        OdbcCommand cmd2 = new OdbcCommand("delete  from electrical", con.str);
                                        cmd2.ExecuteNonQuery();
                                        con.close_string();
                                        array_clear();
                                        elc_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                        elc_descrip.Focus();
                                    }
                                    else if(mbr==MessageBoxResult.Cancel)
                                    {

                                    }
                                }
                                catch (OdbcException ex)
                                {
                                    MessageBox.Show("Error :" + ex);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Vehicle Number and Date");
                        }

                    }
                    else if (button_val == 2 & character.Equals("N"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_bill_num.Text) & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_bill_date.Text))
                        {
                            if (elc_bill_date.Text.Equals("Select Date"))
                            {
                                MessageBox.Show("Select Date from Date Field");
                            }
                            else
                            {
                                try
                                {
                                    Connection con = new Connection();
                                    con.connection_string();
                                    MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                                    if (mbr == MessageBoxResult.OK)
                                    {
                                        for (int i = 0; i < Convert.ToInt32(elc_S_NO.Text) - 1; i++)
                                        {
                                            OdbcCommand cmd = new OdbcCommand("insert into electrician_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + elc_sno[i] + ",'" + elc_bill_num.Text + "','" + elc_vehicle_num.Text + "','" + desc[i] + "'," + quan[i] + "," + rate[i] + ",'" + Convert.ToDateTime(elc_bill_date.Text).ToString("yyyy/MM/dd") + "','DYNAMO')", con.str);
                                            cmd.ExecuteNonQuery();

                                        }
                                        OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + elc_bill_num.Text + "','" + Convert.ToDateTime(elc_bill_date.Text).ToString("yyyy/MM/dd") + "','" + elc_vehicle_num.Text + "','" + Convert.ToDouble(elc_total_amount.Text) + "'," + Convert.ToDouble(elc_discount_amount.Text) + "," + Convert.ToDouble(elc_grand_total.Text) + ",'DYNAMO')", con.str);
                                        cmd1.ExecuteNonQuery();
                                        elc_bill_num.Text = ""; elc_bill_num.IsEnabled = true;
                                        elc_vehicle_num.Text = ""; elc_bill_date.Text = DateTime.Now.ToShortDateString(); elc_total_amount.Text = "0"; elc_discount_amount.Text = "0"; elc_grand_total.Text = "0";
                                        elc_S_NO.Text = "1";
                                        elc_datagrid1.ItemsSource = null;
                                        elc_datagrid1.Items.Refresh();
                                        elc_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                        OdbcCommand cmd2 = new OdbcCommand("delete  from electrical", con.str);
                                        cmd2.ExecuteNonQuery();
                                        con.close_string();
                                        array_clear();
                                        elc_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                        elc_descrip.Focus();
                                    }
                                    else if(mbr==MessageBoxResult.Cancel)
                                    {

                                    }
                                }
                                catch (OdbcException ex)
                                {
                                    MessageBox.Show("Error :" + ex);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Vehicle Number and Date");
                        }

                    }
                    else if (button_val == 3 & character.Equals("N"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_bill_num.Text) & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_bill_date.Text))
                        {
                            if (elc_bill_date.Text.Equals("Select Date"))
                            {
                                MessageBox.Show("Select Date from Date Field");
                            }
                            else
                            {
                                try
                                {
                                    Connection con = new Connection();
                                    con.connection_string();
                                    MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                                    if (mbr == MessageBoxResult.OK)
                                    {
                                        for (int i = 0; i < Convert.ToInt32(elc_S_NO.Text) - 1; i++)
                                        {
                                            OdbcCommand cmd = new OdbcCommand("insert into electrician_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + elc_sno[i] + ",'" + elc_bill_num.Text + "','" + elc_vehicle_num.Text + "','" + desc[i] + "'," + quan[i] + "," + rate[i] + ",'" + Convert.ToDateTime(elc_bill_date.Text).ToString("yyyy/MM/dd") + "','SELFMOTOR')", con.str);
                                            cmd.ExecuteNonQuery();

                                        }
                                        OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + elc_bill_num.Text + "','" + Convert.ToDateTime(elc_bill_date.Text).ToString("yyyy/MM/dd") + "','" + elc_vehicle_num.Text + "','" + Convert.ToDouble(elc_total_amount.Text) + "'," + Convert.ToDouble(elc_discount_amount.Text) + "," + Convert.ToDouble(elc_grand_total.Text) + ",'SELFMOTOR')", con.str);
                                        cmd1.ExecuteNonQuery();
                                        elc_bill_num.Text = ""; elc_bill_num.IsEnabled = true;
                                        elc_vehicle_num.Text = ""; elc_bill_date.Text = DateTime.Now.ToShortDateString(); elc_total_amount.Text = "0"; elc_discount_amount.Text = "0"; elc_grand_total.Text = "0";
                                        elc_S_NO.Text = "1";
                                        elc_datagrid1.ItemsSource = null;
                                        elc_datagrid1.Items.Refresh();
                                        elc_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                        OdbcCommand cmd2 = new OdbcCommand("delete  from electrical", con.str);
                                        cmd2.ExecuteNonQuery();
                                        con.close_string();
                                        array_clear();
                                        elc_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                        elc_descrip.Focus();
                                    }
                                    else if(mbr==MessageBoxResult.Cancel)
                                    {

                                    }
                                }
                                catch (OdbcException ex)
                                {
                                    MessageBox.Show("Error :" + ex);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Vehicle Number and Date");
                        }

                    }
                    else if (button_val == 4 & character.Equals("N"))
                    {
                        if (!string.IsNullOrWhiteSpace(elc_bill_num.Text) & !string.IsNullOrWhiteSpace(elc_vehicle_num.Text) & !string.IsNullOrWhiteSpace(elc_bill_date.Text))
                        {
                            if (elc_bill_date.Text.Equals("Select Date"))
                            {
                                MessageBox.Show("Select Date from Date Field");
                            }
                            else
                            {
                                try
                                {
                                    Connection con = new Connection();
                                    con.connection_string();
                                    MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                                    if (mbr == MessageBoxResult.OK)
                                    {
                                        for (int i = 0; i < Convert.ToInt32(elc_S_NO.Text) - 1; i++)
                                        {
                                            OdbcCommand cmd = new OdbcCommand("insert into electrician_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + elc_sno[i] + ",'" + elc_bill_num.Text + "','" + elc_vehicle_num.Text + "','" + desc[i] + "'," + quan[i] + "," + rate[i] + ",'" + Convert.ToDateTime(elc_bill_date.Text).ToString("yyyy/MM/dd") + "','ELECTRICIAN')", con.str);
                                            cmd.ExecuteNonQuery();

                                        }
                                        OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + elc_bill_num.Text + "','" + Convert.ToDateTime(elc_bill_date.Text).ToString("yyyy/MM/dd") + "','" + elc_vehicle_num.Text + "','" + Convert.ToDouble(elc_total_amount.Text) + "'," + Convert.ToDouble(elc_discount_amount.Text) + "," + Convert.ToDouble(elc_grand_total.Text) + ",'ELECTRICIAN')", con.str);
                                        cmd1.ExecuteNonQuery();
                                        elc_bill_num.Text = ""; elc_bill_num.IsEnabled = true;
                                        elc_vehicle_num.Text = ""; elc_bill_date.Text = DateTime.Now.ToShortDateString(); elc_total_amount.Text = "0"; elc_discount_amount.Text = "0"; elc_grand_total.Text = "0";
                                        elc_S_NO.Text = "1";
                                        elc_datagrid1.ItemsSource = null;
                                        elc_datagrid1.Items.Refresh();
                                        elc_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                        OdbcCommand cmd2 = new OdbcCommand("delete  from electrical", con.str);
                                        cmd2.ExecuteNonQuery();
                                        con.close_string();
                                        array_clear();
                                        elc_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                        elc_descrip.Focus();
                                    }
                                    else if(mbr==MessageBoxResult.Cancel)
                                    {

                                    }
                                }
                                catch (OdbcException ex)
                                {
                                    MessageBox.Show("Error :" + ex);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Vehicle Number and Date");
                        }
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


        void elc_clear_click(object sender, RoutedEventArgs e)
        {
            array_clear();
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd2 = new OdbcCommand("delete  from electrical", con.str);
            cmd2.ExecuteNonQuery();
            con.close_string();
            elc_datagrid1.ItemsSource = null;
            elc_datagrid1.Items.Refresh();
            elc_S_NO.Text = "1"; elc_descrip.Text = ""; elc_quantity.Text = "1"; elc_rate.Text = "0"; elc_price.Text = "0"; elc_bill_num.Text = ""; elc_discount_amount.Text = "0"; elc_total_amount.Text = ""; elc_grand_total.Text = "0";
        }


        void grid_size()
        {
            elc_datagrid1.Columns[0].Width = 72;
            elc_datagrid1.Columns[1].Width = 250;
            elc_datagrid1.Columns[2].Width = 120;
            elc_datagrid1.Columns[3].Width = 120;
            elc_datagrid1.Columns[4].Width = 120;
        }
        void array_clear()
        {
            Array.Clear(elc_sno, 0, elc_sno.Length);
            Array.Clear(billno, 0, billno.Length);
            Array.Clear(vno, 0, vno.Length);
            Array.Clear(desc, 0, desc.Length);
            Array.Clear(quan, 0, quan.Length);
            Array.Clear(rate, 0, rate.Length);
            Array.Clear(cost, 0, cost.Length);
            Array.Clear(billdate, 0, billdate.Length);
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
        void Elc_Rate_Textchanged(object sender, TextChangedEventArgs e)
        {
            int len = 0;
            string s = elc_rate.Text;
            if(!string.IsNullOrWhiteSpace(elc_rate.Text))
            {
                len = elc_rate.Text.Length;
                if (len <=6) 
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
        void Elc_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(elc_vehicle_num.Text))
            {

                len = elc_vehicle_num.Text.Length;
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
        void Elc_Bill_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(elc_view_bill_number.Text))
            {

                len = elc_view_bill_number.Text.Length;
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                elc_vehicle_num.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    elc_vehicle_num.Items.Add(dt.Rows[i]["vehicle_number"]);
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
           
        }
    }
}
