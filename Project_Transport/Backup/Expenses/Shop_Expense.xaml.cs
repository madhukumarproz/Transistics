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
    /// Interaction logic for Shop_Expense.xaml
    /// </summary>
    public partial class Shop_Expense : UserControl
    {
        public Shop_Expense()
        {
            InitializeComponent();
            shop_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            shop_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            shop_done_bttn.Visibility = System.Windows.Visibility.Hidden;
        }


        int shop_btn_val = 0;
        string shop_btn_char = null;
        string[] shop_des = new string[50];
        int[] shop_qnty = new int[50];
        double[] shop_qnt_rate = new double[50];
        double[] shop_qnt_price = new double[50];
        int shop_s_val = 0;
        int[] shop_snos = new int[50];
        void automobile_expense_click(object sender, RoutedEventArgs e)
        {
            automobile_expense.Background = System.Windows.Media.Brushes.Green;
            oil_expense.Background = System.Windows.Media.Brushes.Yellow;
            shop_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_new_bill.IsEnabled = true; shop_edit_bill.IsEnabled = true; shop_view_bill.IsEnabled = true;
            shop_btn_val = 1;
            shop_btn_char = "";


            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();

        }
        void oil_expense_click(object sender, RoutedEventArgs e)
        {
            automobile_expense.Background = System.Windows.Media.Brushes.Yellow;
            oil_expense.Background = System.Windows.Media.Brushes.Green;
            shop_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_new_bill.IsEnabled = true; shop_edit_bill.IsEnabled = true; shop_view_bill.IsEnabled = true;
            shop_btn_val = 2;
            shop_btn_char = "";


            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void shop_new_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Shop_Vehicle_Number = "";
            g.Shop_Description = "";
            g.Shop_Quantity = "1";
            g.Shop_Rate = "";
            g.Shop_Bill_No = "";
            g.Shop_Discount = "";
            this.DataContext = g;
            shop_new_bill.Background = System.Windows.Media.Brushes.Green;
            shop_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_btn_char = "N";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            shop_S_NO.Text = "1";
            shop_clear_array();
            shop_descrip.Visibility = System.Windows.Visibility.Visible;
            shop_quantity.Visibility = System.Windows.Visibility.Visible;
            shop_rate.Visibility = System.Windows.Visibility.Visible;
            shop_price.Visibility = System.Windows.Visibility.Visible;
            shop_bill_date.Visibility = System.Windows.Visibility.Visible;
            shop_bill_no.Visibility = System.Windows.Visibility.Visible;
            shop_bill_num.Visibility = System.Windows.Visibility.Visible;
            shop_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            shop_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            lbl11.Visibility = System.Windows.Visibility.Visible;
            lbl22.Visibility = System.Windows.Visibility.Visible;
            lbl33.Visibility = System.Windows.Visibility.Visible;
            lbl44.Visibility = System.Windows.Visibility.Visible;
            shop_datagrid1.ItemsSource = null;
            shop_datagrid1.Items.Refresh();
            shop_bill_num.Text = "";
            shop_bill_num.IsEnabled = true;
            shop_descrip.Focus();
        }
        void shop_edit_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Shop_Vehicle_Number = "";
            g.Shop_Description = "";
            g.Shop_Quantity = "1";
            g.Shop_Rate = "";
            g.Shop_Bill_No = "";
            g.Shop_Discount = "";
            this.DataContext = g;
            shop_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_edit_bill.Background = System.Windows.Media.Brushes.Green;
            shop_view_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_btn_char = "E";
            shop_descrip.Visibility = System.Windows.Visibility.Visible;
            shop_quantity.Visibility = System.Windows.Visibility.Visible;
            shop_rate.Visibility = System.Windows.Visibility.Visible;
            shop_price.Visibility = System.Windows.Visibility.Visible;
            shop_bill_date.Visibility = System.Windows.Visibility.Hidden;
            shop_bill_no.Visibility = System.Windows.Visibility.Hidden;
            shop_bill_num.Visibility = System.Windows.Visibility.Hidden;
            shop_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            shop_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
            lbl11.Visibility = System.Windows.Visibility.Visible;
            lbl22.Visibility = System.Windows.Visibility.Visible;
            lbl33.Visibility = System.Windows.Visibility.Visible;
            lbl44.Visibility = System.Windows.Visibility.Visible;
            shop_datagrid1.ItemsSource = null;
            shop_datagrid1.Items.Refresh();
            shop_bill_num.IsEnabled = false;
            shop_total_amount.Text = "0"; shop_discount_amount.Text = "0"; shop_grand_total.Text = "0";
        }
        void shop_view_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Shop_Vehicle_Number = "";
            g.Shop_Bill_Num = "";
            this.DataContext = g;
            shop_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            shop_view_bill.Background = System.Windows.Media.Brushes.Green;
            shop_btn_char = "V";
            shop_descrip.Visibility = System.Windows.Visibility.Hidden;
            shop_quantity.Visibility = System.Windows.Visibility.Hidden;
            shop_rate.Visibility = System.Windows.Visibility.Hidden;
            shop_price.Visibility = System.Windows.Visibility.Hidden;
            shop_bill_date.Visibility = System.Windows.Visibility.Hidden;
            shop_bill_no.Visibility = System.Windows.Visibility.Hidden;
            shop_bill_num.Visibility = System.Windows.Visibility.Hidden;
            shop_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            shop_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
            lbl11.Visibility = System.Windows.Visibility.Hidden;
            lbl22.Visibility = System.Windows.Visibility.Hidden;
            lbl33.Visibility = System.Windows.Visibility.Hidden;
            lbl44.Visibility = System.Windows.Visibility.Hidden;
            shop_datagrid1.ItemsSource = null;
            shop_datagrid1.Items.Refresh();
            shop_bill_num.IsEnabled = false;
            shop_total_amount.Text = "0"; shop_discount_amount.Text = "0"; shop_grand_total.Text = "0";
        }


        void shop_quantity_rate_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                shop_price.Text = (Convert.ToInt32(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text)).ToString();
            }
        }


        void shop_vehicle_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (shop_btn_val == 1 & shop_btn_char == "E" & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER")
                    {
                        string l = shop_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            shop_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + shop_vehicle_num.Text + "' and expense_type='AUTOMOBILE' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                shop_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
              else  if (shop_btn_val == 2 & shop_btn_char == "E" & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER")
                    {
                        string l = shop_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            shop_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + shop_vehicle_num.Text + "' and expense_type='OIL' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                shop_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
               else if (shop_btn_val == 1 & shop_btn_char == "V" & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + shop_vehicle_num.Text + "' and expense_type='AUTOMOBILE' order by bill_no DESC", con.str);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        shop_view_bill_number.Items.Clear();
                        if (dt.Rows.Count > 0)
                        {
                            //dt.AsEnumerable().Take(10);
                            if (dt.Rows.Count > 10)
                            {
                                for (int c = 0; c < 10; c++)
                                {
                                    shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }
                            }
                            else
                            {
                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
               else if (shop_btn_val == 2 & shop_btn_char == "V" & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + shop_vehicle_num.Text + "' and expense_type='OIL' order by bill_no DESC", con.str);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        shop_view_bill_number.Items.Clear();
                        if (dt.Rows.Count > 0)
                        {
                            //dt.AsEnumerable().Take(10);
                            if (dt.Rows.Count > 10)
                            {
                                for (int c = 0; c < 10; c++)
                                {
                                    shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                }
                            }
                            else
                            {
                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                else if (shop_btn_char == "N")
                {

                }
                else
                {
                    MessageBox.Show("Should Select Vehicle Number");
                }
            }
        }


        void shop_add_all_bill_number_checked(object sender, RoutedEventArgs e)
        {
            shop_add_all_bill_number.IsChecked = false;
            if (shop_btn_val == 1 && shop_btn_char == "E" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and expense_type='AUTOMOBILE' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            shop_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
                
               
            }
           else  if (shop_btn_val == 2 && shop_btn_char == "E" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and expense_type='OIL' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            shop_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
               
               
            }
          else  if (shop_btn_val == 1 && shop_btn_char == "V" & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and expense_type='AUTOMOBILE' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            shop_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                        MessageBox.Show("Vehicle Number Invalid Format");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
               
               
            }
           else if (shop_btn_val == 2 && shop_btn_char == "V" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and expense_type='OIL' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            shop_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    shop_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                MessageBox.Show("Should Select Vehicle Number");
            }
        }


        void shop_bill_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                try
                {
                    if (shop_bill_num.Text.Length >= 6)
                    {
                        MessageBoxResult mr = MessageBox.Show("Length Should be Less-than 6 Digit", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (mr == MessageBoxResult.OK)
                        {
                            e.Handled = true;
                            shop_bill_num.Text = "";
                        }
                        else if(mr==MessageBoxResult.Cancel)
                        {

                        }
                    }
                    else if (shop_btn_char == "N" & string.IsNullOrWhiteSpace(shop_bill_num.Text))
                    {
                        Connection con1 = new Connection();
                        con1.connection_string();
                        OdbcCommand cmd = new OdbcCommand("select MAX(bill_no)as bill_noS from expense_bill", con1.str);
                        OdbcDataAdapter da1 = new OdbcDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            try
                            {
                                shop_bill_num.Text = (Convert.ToInt32(dt1.Rows[0]["bill_noS"]) + 1).ToString();
                                shop_bill_num.IsEnabled = false;
                            }
                            catch
                            {
                                shop_bill_num.Text = "0001";
                                shop_bill_num.IsEnabled = false;
                            }

                        }
                        else
                        {
                            shop_bill_num.Text = "0001";
                            shop_bill_num.IsEnabled = false;
                        }
                        con1.close_string();
                    }
                    else
                    {
                        shop_bill_num.IsEnabled = false;
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
               

            }
        }


        void shop_add_new_row(object sender, RoutedEventArgs e)
        {
            if (shop_btn_val == 1 & shop_btn_char == "N" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(shop_descrip.Text) & !string.IsNullOrWhiteSpace(shop_quantity.Text) & !string.IsNullOrWhiteSpace(shop_rate.Text) & !string.IsNullOrWhiteSpace(shop_bill_num.Text) & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text) & !string.IsNullOrWhiteSpace(shop_bill_date.Text))
                        {
                            try
                            {
                                int count = Convert.ToInt32(shop_S_NO.Text) - 1;
                                shop_snos[count] = Convert.ToInt32(shop_S_NO.Text);
                                shop_des[count] = shop_descrip.Text;
                                shop_qnty[count] = Convert.ToInt32(shop_quantity.Text);
                                shop_qnt_rate[count] = Convert.ToDouble(shop_rate.Text);
                                shop_qnt_price[count] = Convert.ToInt32(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(shop_S_NO.Text) + ",'" + shop_descrip.Text + "'," + Convert.ToInt32(shop_quantity.Text) + "," + Convert.ToDouble(shop_rate.Text) + "," + Convert.ToInt32(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                shop_datagrid1.ItemsSource = dt.DefaultView;
                                shop_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(shop_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(shop_qnt_price[i]);
                                    shop_total_amount.Text = v.ToString();
                                }
                                shop_S_NO.Text = (Convert.ToInt32(shop_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                shop_descrip.Text = ""; shop_quantity.Text = "1"; shop_rate.Text = "0"; shop_price.Text = "0";
                                shop_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                shop_descrip.Focus();
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
            else if (shop_btn_val == 2 & shop_btn_char == "N" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(shop_descrip.Text) & !string.IsNullOrWhiteSpace(shop_quantity.Text) & !string.IsNullOrWhiteSpace(shop_rate.Text) & !string.IsNullOrWhiteSpace(shop_bill_num.Text) & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text) & !string.IsNullOrWhiteSpace(shop_bill_date.Text))
                        {
                            try
                            {
                                int count = Convert.ToInt32(shop_S_NO.Text) - 1;
                                shop_snos[count] = Convert.ToInt32(shop_S_NO.Text);

                                shop_des[count] = shop_descrip.Text;
                                shop_qnty[count] = Convert.ToInt32(shop_quantity.Text);
                                shop_qnt_rate[count] = Convert.ToDouble(shop_rate.Text);
                                shop_qnt_price[count] = Convert.ToInt32(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(shop_S_NO.Text) + ",'" + shop_descrip.Text + "'," + Convert.ToInt32(shop_quantity.Text) + "," + Convert.ToDouble(shop_rate.Text) + "," + Convert.ToInt32(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("selEct S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                shop_datagrid1.ItemsSource = dt.DefaultView;
                                shop_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(shop_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(shop_qnt_price[i]);
                                    shop_total_amount.Text = v.ToString();
                                }
                                shop_S_NO.Text = (Convert.ToInt32(shop_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                shop_descrip.Text = ""; shop_quantity.Text = "1"; shop_rate.Text = "0"; shop_price.Text = "0";
                                shop_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                shop_descrip.Focus();
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

            else if (shop_btn_val == 1 & shop_btn_char == "NE" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            shop_des[shop_s_val - 1] = shop_descrip.Text;
                            shop_qnty[shop_s_val - 1] = Convert.ToInt32(shop_quantity.Text);
                            shop_qnt_rate[shop_s_val - 1] = Convert.ToDouble(shop_rate.Text);
                            shop_qnt_price[shop_s_val - 1] = Convert.ToInt32(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + shop_descrip.Text + "',quantity=" + Convert.ToInt32(shop_quantity.Text) + ",rate=" + Convert.ToDouble(shop_rate.Text) + ",price=" + Convert.ToDouble(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text) + " where s_no=" + shop_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            shop_datagrid1.ItemsSource = dt.DefaultView;
                            shop_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                shop_total_amount.Text = dv.ToString();
                            }
                            shop_btn_char = "N"; shop_descrip.Text = ""; shop_quantity.Text = "1"; shop_rate.Text = "0"; shop_price.Text = "0";
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
            else if (shop_btn_val == 2 & shop_btn_char == "NE" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            shop_des[shop_s_val - 1] = shop_descrip.Text;
                            shop_qnty[shop_s_val - 1] = Convert.ToInt32(shop_quantity.Text);
                            shop_qnt_rate[shop_s_val - 1] = Convert.ToDouble(shop_rate.Text);
                            shop_qnt_price[shop_s_val - 1] = Convert.ToInt32(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text);
                            Connection con = new Connection();

                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + shop_descrip.Text + "',quantity=" + Convert.ToInt32(shop_quantity.Text) + ",rate=" + Convert.ToDouble(shop_rate.Text) + ",price=" + Convert.ToDouble(shop_quantity.Text) * Convert.ToDouble(shop_rate.Text) + " where s_no=" + shop_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            shop_datagrid1.ItemsSource = dt.DefaultView;
                            shop_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                shop_total_amount.Text = dv.ToString();
                            }
                            shop_btn_char = "N"; shop_descrip.Text = ""; shop_quantity.Text = "1"; shop_rate.Text = "0"; shop_price.Text = "0";
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
            else if (shop_btn_val == 1 & shop_btn_char == "E" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='AUTOMOBILE'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                shop_datagrid1.ItemsSource = DT.DefaultView;
                                shop_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='AUTOMOBILE'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    shop_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    shop_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    shop_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();
                                    shop_bill_num.Text = dt.Rows[0]["bill_no"].ToString();
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
            else if (shop_btn_val == 2 & shop_btn_char == "E" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='OIL'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                shop_datagrid1.ItemsSource = DT.DefaultView;
                                shop_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='OIL'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    shop_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    shop_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    shop_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();
                                    shop_bill_num.Text = dt.Rows[0]["bill_NO"].ToString();
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
            else if (shop_btn_val == 1 & shop_btn_char == "ED" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(shop_descrip.Text) & !string.IsNullOrWhiteSpace(shop_quantity.Text) & !string.IsNullOrWhiteSpace(shop_rate.Text) & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text) & !string.IsNullOrWhiteSpace(shop_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update shop_expense set description='" + shop_descrip.Text + "',quantity=" + Convert.ToInt32(shop_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(shop_rate.Text) + " where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='AUTOMOBILE' and  s_no=" + shop_s_val + "", con.str);
                                cmd.ExecuteNonQuery();


                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM SHOP_EXPENSE where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='AUTOMOBILE' ", con.str);
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
                                shop_total_amount.Text = p_tot.ToString();
                                shop_grand_total.Text = (Convert.ToDouble(shop_total_amount.Text) - Convert.ToDouble(shop_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(shop_total_amount.Text) + ",discount=" + Convert.ToDouble(shop_discount_amount.Text) + ",gnd_total=" + shop_grand_total.Text + " where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='AUTOMOBILE' and ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM SHOP_EXPENSE where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='AUTOMOBILE' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                shop_datagrid1.ItemsSource = dt1.DefaultView;
                                shop_gridsize();
                                con.close_string();
                                shop_btn_char = "E";
                                shop_descrip.Text = ""; shop_quantity.Text = "1"; shop_rate.Text = "0"; shop_price.Text = "0";
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
            else if (shop_btn_val == 2 & shop_btn_char == "ED" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(shop_descrip.Text) & !string.IsNullOrWhiteSpace(shop_quantity.Text) & !string.IsNullOrWhiteSpace(shop_rate.Text) & !string.IsNullOrWhiteSpace(shop_vehicle_num.Text) & !string.IsNullOrWhiteSpace(shop_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update shop_expense set description='" + shop_descrip.Text + "',quantity=" + Convert.ToInt32(shop_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(shop_rate.Text) + " where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='OIL' and  s_no=" + shop_s_val + "", con.str);
                                cmd.ExecuteNonQuery();


                                OdbcCommand cmd1 = new OdbcCommand("select quantity*quantity_rate as price from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='OIL' ", con.str);
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
                                shop_total_amount.Text = p_tot.ToString();
                                shop_grand_total.Text = (Convert.ToDouble(shop_total_amount.Text) - Convert.ToDouble(shop_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(shop_total_amount.Text) + ",discount=" + Convert.ToDouble(shop_discount_amount.Text) + ",gnd_total=" + shop_grand_total.Text + " where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='OIL' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM SHOP_EXPENSE where  vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='OIL' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);


                                shop_datagrid1.ItemsSource = dt1.DefaultView;
                                shop_gridsize();
                                con.close_string();
                                shop_btn_char = "E";
                                shop_descrip.Text = ""; shop_quantity.Text = "1"; shop_rate.Text = "0"; shop_price.Text = "0";

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
            else if (shop_btn_val == 1 & shop_btn_char == "V" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='AUTOMOBILE'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                shop_datagrid1.ItemsSource = dt.DefaultView;
                                shop_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='AUTOMOBILE'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    shop_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    shop_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    shop_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();
                                    shop_bill_num.Text = dt1.Rows[0]["bill_no"].ToString();
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
            else if (shop_btn_val == 2 & shop_btn_char == "V" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = shop_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        shop_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from shop_expense where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='OIL'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                shop_datagrid1.ItemsSource = dt.DefaultView;
                                shop_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + shop_vehicle_num.Text + "' and bill_no='" + shop_view_bill_number.Text + "' and expense_type='OIL'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    shop_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    shop_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    shop_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();
                                    shop_bill_num.Text = dt1.Rows[0]["bill_no"].ToString();
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


        void shop_datagrid1_mouseclick(object sender, MouseButtonEventArgs e)
        {
            if (shop_btn_val == 1 & shop_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)shop_datagrid1.SelectedItem;
                    shop_descrip.Text = (dr["description"]).ToString();
                    shop_s_val = Convert.ToInt32(dr["s_no"]);
                    shop_quantity.Text = (dr["quantity"]).ToString();
                    shop_rate.Text = (dr["rate"]).ToString();
                    shop_price.Text = (dr["price"]).ToString();
                    shop_btn_char = "NE";
                    shop_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (shop_btn_val == 2 & shop_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)shop_datagrid1.SelectedItem;
                    shop_descrip.Text = (dr["description"]).ToString();
                    shop_s_val = Convert.ToInt32(dr["s_no"]);
                    shop_quantity.Text = (dr["quantity"]).ToString();
                    shop_rate.Text = (dr["rate"]).ToString();
                    shop_price.Text = (dr["price"]).ToString();
                    shop_btn_char = "NE";
                    shop_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (shop_btn_val == 1 & shop_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)shop_datagrid1.SelectedItem;
                    shop_descrip.Text = (dr["description"]).ToString();
                    shop_s_val = Convert.ToInt32(dr["s_no"]);
                    shop_quantity.Text = (dr["quantity"]).ToString();
                    shop_rate.Text = (dr["quantity_rate"]).ToString();
                    shop_price.Text = (dr["price"]).ToString();
                    shop_btn_char = "ED";
                    shop_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (shop_btn_val == 2 & shop_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)shop_datagrid1.SelectedItem;
                    shop_descrip.Text = (dr["description"]).ToString();
                    shop_s_val = Convert.ToInt32(dr["s_no"]);
                    shop_quantity.Text = (dr["quantity"]).ToString();
                    shop_rate.Text = (dr["quantity_rate"]).ToString();
                    shop_price.Text = (dr["price"]).ToString();
                    shop_btn_char = "ED";
                    shop_descrip.Focus();
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


        void shop_discount_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(shop_discount_amount.Text))
                {
                    shop_discount_amount.Text = "0";
                }
                if (shop_btn_char == "N")
                {
                    shop_grand_total.Text = (Convert.ToDouble(shop_total_amount.Text) - Convert.ToDouble(shop_discount_amount.Text)).ToString();
                    shop_done_bttn.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    shop_grand_total.Text = (Convert.ToDouble(shop_total_amount.Text) - Convert.ToDouble(shop_discount_amount.Text)).ToString();
                    shop_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                }

            }
        }



        void shop_bill_details_done_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER" && !string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {
                string l = shop_vehicle_num.Text;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    shop_vehicle_num.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    if (shop_btn_val == 1 & shop_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(shop_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into shop_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(shop_snos[i]) + ",'" + shop_bill_num.Text + "','" + shop_vehicle_num.Text + "','" + shop_des[i] + "'," + shop_qnty[i] + "," + shop_qnt_rate[i] + ",'" + Convert.ToDateTime(shop_bill_date.Text).ToString("yyyy/MM/dd") + "','AUTOMOBILE')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + shop_bill_num.Text + "','" + Convert.ToDateTime(shop_bill_date.Text).ToString("yyyy/MM/dd") + "','" + shop_vehicle_num.Text + "'," + shop_total_amount.Text + "," + shop_discount_amount.Text + "," + shop_grand_total.Text + ",'AUTOMOBILE')", con.str);
                                cmd1.ExecuteNonQuery();
                                shop_clear_array();
                                shop_datagrid1.ItemsSource = null;
                                shop_datagrid1.Items.Refresh();
                                shop_vehicle_num.Text = ""; shop_bill_date.Text = DateTime.Now.ToShortDateString(); shop_bill_num.Text = ""; shop_bill_num.IsEnabled = true; shop_S_NO.Text = "1"; shop_total_amount.Text = "0"; shop_discount_amount.Text = "0"; shop_grand_total.Text = "0";
                                shop_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                shop_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                shop_descrip.Focus();
                            }
                            else if(mbr==MessageBoxResult.Cancel)
                            {

                            }
                            con.close_string();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (shop_btn_val == 2 & shop_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(shop_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into shop_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(shop_snos[i]) + ",'" + shop_bill_num.Text + "','" + shop_vehicle_num.Text + "','" + shop_des[i] + "'," + shop_qnty[i] + "," + shop_qnt_rate[i] + ",'" + Convert.ToDateTime(shop_bill_date.Text).ToString("yyyy/MM/dd") + "','OIL')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + shop_bill_num.Text + "','" + Convert.ToDateTime(shop_bill_date.Text).ToString("yyyy/MM/dd") + "','" + shop_vehicle_num.Text + "'," + shop_total_amount.Text + "," + shop_discount_amount.Text + "," + shop_grand_total.Text + ",'OIL')", con.str);
                                cmd1.ExecuteNonQuery();
                                shop_clear_array();
                                shop_datagrid1.ItemsSource = null;
                                shop_datagrid1.Items.Refresh();
                                shop_vehicle_num.Text = ""; shop_bill_date.Text = DateTime.Now.ToShortDateString(); shop_bill_num.Text = ""; shop_bill_num.IsEnabled = true; shop_S_NO.Text = "1"; shop_total_amount.Text = "0"; shop_discount_amount.Text = "0"; shop_grand_total.Text = "0";
                                shop_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                shop_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                shop_descrip.Focus();
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
                    MessageBox.Show("Vehicle Number Invalid Format");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }



        void shop_clear_click(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            shop_clear_array();
            shop_datagrid1.ItemsSource = null;
            shop_datagrid1.Items.Refresh();
            shop_done_bttn.Visibility = System.Windows.Visibility.Hidden;
            shop_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
            shop_descrip.Text = ""; shop_quantity.Text = "1"; shop_rate.Text = "0"; shop_price.Text = "0";
            shop_vehicle_num.Text = ""; shop_bill_date.Text = ""; shop_bill_num.Text = ""; shop_S_NO.Text = "1"; shop_total_amount.Text = "0"; shop_discount_amount.Text = "0"; shop_grand_total.Text = "0";
        }
        void shop_clear_array()
        {
            Array.Clear(shop_des, 0, shop_des.Length);
            Array.Clear(shop_qnty, 0, shop_qnty.Length);
            Array.Clear(shop_qnt_rate, 0, shop_qnt_rate.Length);
            Array.Clear(shop_qnt_price, 0, shop_qnt_price.Length); ;
            Array.Clear(shop_snos, 0, shop_snos.Length);

        }


        void shop_gridsize()
        {
            shop_datagrid1.Columns[0].Width = 72;
            shop_datagrid1.Columns[1].Width = 250;
            shop_datagrid1.Columns[2].Width = 120;
            shop_datagrid1.Columns[3].Width = 120;
            shop_datagrid1.Columns[4].Width = 120;

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
        void Shop_Rate_Textchanged(object sender, TextChangedEventArgs e)
        {
            int len = 0;
            string s = shop_rate.Text;
            if(!string.IsNullOrWhiteSpace(shop_rate.Text))
            {
                len = shop_rate.Text.Length;
                if (len <= 6)
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
        void Shop_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(shop_vehicle_num.Text))
            {

                len = shop_vehicle_num.Text.Length;
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
        void Shop_Bill_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(shop_view_bill_number.Text))
            {

                len = shop_view_bill_number.Text.Length;
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
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            shop_vehicle_num.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                shop_vehicle_num.Items.Add(dt.Rows[i]["vehicle_number"]);
            }
        }
    }
}
