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
    /// Interaction logic for Other_Expense.xaml
    /// </summary>
    public partial class Other_Expense : UserControl
    {
        public Other_Expense()
        {
            InitializeComponent();
            other_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            other_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            other_done_bttn.Visibility = System.Windows.Visibility.Hidden;
        }


        string other_btnval = null;
        string[] others_description = new string[50];
        int[] others_quantity = new int[50];
        double[] others_b_rate = new double[50];
        double[] others_price = new double[50];
        int[] others_s_no = new int[50];
        int jj = 0;
        int kj = 0;
        void other_expense_insert(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Other_Vehicle_Number = "";
            g.Other_Description = "";
            g.Other_Quantity = "1";
            g.Other_Rate = "";
            g.Other_Bill_No = "";
            g.Other_Discount = "";            
            this.DataContext = g;
            other_btn1.Background = System.Windows.Media.Brushes.Green;
            other_btn2.Background = System.Windows.Media.Brushes.Yellow;
            other_btn3.Background = System.Windows.Media.Brushes.Yellow;
            other_sample.Visibility = System.Windows.Visibility.Visible;
            other_btnval = "N";
            other_control_view();
            other_bill_date.Visibility = System.Windows.Visibility.Visible;
            other_bill_no.Visibility = System.Windows.Visibility.Visible;
            other_bill_num.Visibility = System.Windows.Visibility.Visible;
            other_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            other_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from electrical", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            other_bill_num.IsEnabled = true;
            other_bill_num.Text = "";
            other_array_clear();
            other_sample.ItemsSource = null;
            other_sample.Items.Refresh();
            other_descrip.Focus();
        }
        void other_expense_update(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Other_Vehicle_Number = "";
            g.Other_Description = "";
            g.Other_Quantity = "1";
            g.Other_Rate = "";
            g.Other_Bill_No = "";
            g.Other_Discount = "";           
            this.DataContext = g;
            other_btn1.Background = System.Windows.Media.Brushes.Yellow;
            other_btn2.Background = System.Windows.Media.Brushes.Green;
            other_btn3.Background = System.Windows.Media.Brushes.Yellow;
            other_sample.Visibility = System.Windows.Visibility.Visible;
            other_btnval = "E";
            other_control_view();
            other_sample.ItemsSource = null;
            other_sample.Items.Refresh();
        }
        void other_expense_view(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Other_Vehicle_Number = "";
            g.Other_Bill_Num = "";
            this.DataContext = g;
            other_btn1.Background = System.Windows.Media.Brushes.Yellow;
            other_btn2.Background = System.Windows.Media.Brushes.Yellow;
            other_btn3.Background = System.Windows.Media.Brushes.Green;
            other_sample.Visibility = System.Windows.Visibility.Visible;
            other_btnval = "V";
            other_control_hide();
            other_sample.ItemsSource = null;
            other_sample.Items.Refresh();
        }


        void other_rate_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                other_price.Text = (Convert.ToDouble(other_quantity.Text) * Convert.ToDouble(other_rate.Text)).ToString();

            }
        }



        void other_vehicle_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (other_btnval == "V"  & !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                    {
                        string l = other_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            other_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select  bill_no from expense_bill  where vehicle='" + other_vehicle_num.Text + "' and expense_type='OTHER' ORDER BY bill_no DESC ", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                other_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            other_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            other_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                else if (other_btnval == "E" && !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER")
                    {
                        string l = other_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            other_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select  bill_no from expense_bill  where vehicle='" + other_vehicle_num.Text + "' and expense_type='OTHER' ORDER BY bill_no DESC ", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                other_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            other_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            other_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                else if (other_btnval == "N")
                {

                }
                //else
                //{
                //    MessageBox.Show("Should Select Vehicle Number");
                //}


            }
        }


        void other_add_all_bill_number_checked(object sender, RoutedEventArgs e)
        {
            if (other_btnval == "V" && !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = other_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        other_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select  bill_no from expense_bill where vehicle='" + other_vehicle_num.Text + "' AND EXPENSE_TYPE='OTHER' order by bill_no DESC",con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            other_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                for (int v = 0; v < dt.Rows.Count; v++)
                                {
                                    other_view_bill_number.Items.Add(dt.Rows[v]["bill_no"]);
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
            else if(other_btnval == "E" && !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = other_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        other_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select  bill_no from expense_bill where vehicle='" + other_vehicle_num.Text + "' AND EXPENSE_TYPE='OTHER' order by bill_no DESC",con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            other_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                for (int v = 0; v < dt.Rows.Count; v++)
                                {
                                    other_view_bill_number.Items.Add(dt.Rows[v]["bill_no"]);
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


        void other_bill_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (other_bill_num.Text.Length >= 6)
                {
                    MessageBoxResult mr = MessageBox.Show("Length Should be Less-than 6 Digit", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (mr == MessageBoxResult.OK)
                    {
                        other_bill_num.Focus();
                        other_bill_num.Text = "";
                    }
                    else if(mr==MessageBoxResult.No)
                    {

                    }
                }
                else if (other_btnval == "N" & String.IsNullOrWhiteSpace(other_bill_num.Text))
                {
                    try
                    {
                        Connection con1 = new Connection();
                        con1.connection_string();
                        OdbcCommand cmd1 = new OdbcCommand("select max(BILL_NO)as bill_nos from expense_bill", con1.str);
                        OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            try
                            {
                                other_bill_num.Text = (Convert.ToInt32(dt1.Rows[0]["bill_nos"].ToString()) + 1).ToString();
                                other_bill_num.IsEnabled = false;
                            }
                            catch
                            {
                                other_bill_num.Text = "0001";
                                other_bill_num.IsEnabled = false;
                            }

                        }
                        else
                        {
                            other_bill_num.Text = "0001";
                            other_bill_num.IsEnabled = false;
                        }
                        con1.close_string();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                    
                }
                else if (other_btnval == "N" & !String.IsNullOrWhiteSpace(other_bill_num.Text))
                {
                    other_bill_num.IsEnabled = false;
                }
                else
                {
                    other_bill_num.IsEnabled = false;
                }
            }

        }


        void other_add_new_row(object sender, RoutedEventArgs e)
        {

            if (other_btnval == "N" && !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = other_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        other_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(other_descrip.Text) & !string.IsNullOrWhiteSpace(other_quantity.Text) & !string.IsNullOrWhiteSpace(other_rate.Text) & !string.IsNullOrWhiteSpace(other_bill_num.Text) & !string.IsNullOrWhiteSpace(other_vehicle_num.Text) & !string.IsNullOrWhiteSpace(other_bill_date.Text))
                        {
                            try
                            {
                                int val = Convert.ToInt32(other_S_NO.Text);
                                others_description[val - 1] = other_descrip.Text;
                                others_quantity[val - 1] = Convert.ToInt32(other_quantity.Text);
                                others_b_rate[val - 1] = Convert.ToDouble(other_rate.Text);
                                others_price[val - 1] = Convert.ToDouble(other_price.Text);
                                others_s_no[val - 1] = val;
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into electrical(s_no,description,quantity,quantity_rate,price)values(" + Convert.ToInt32(other_S_NO.Text) + ",'" + other_descrip.Text + "'," + Convert.ToInt32(other_quantity.Text) + "," + Convert.ToDouble(other_rate.Text) + "," + Convert.ToDouble(other_rate.Text) * Convert.ToInt32(other_quantity.Text) + ")", con.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE FROM electrical", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                other_sample.ItemsSource = dt.DefaultView;
                                gsize1();
                                other_S_NO.Text = (Convert.ToInt32(other_S_NO.Text) + 1).ToString();
                                double cb = 0;
                                for (int i = 0; i < val; i++)
                                {

                                    cb += Convert.ToDouble(others_price[i]);

                                }
                                other_total_amount.Text = cb.ToString();
                                other_descrip.Text = ""; other_quantity.Text = "1"; other_price.Text = "0"; other_rate.Text = "0";
                                other_descrip.Focus();
                                other_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                con.close_string();
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
            else if (other_btnval == "NE" && !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = other_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        other_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            others_description[jj - 1] = other_descrip.Text;
                            others_quantity[jj - 1] = Convert.ToInt32(other_quantity.Text);
                            others_b_rate[jj - 1] = Convert.ToDouble(other_rate.Text);
                            others_price[jj - 1] = Convert.ToDouble(other_price.Text);
                            others_s_no[jj - 1] = jj;
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update electrical set description='" + other_descrip.Text + "',quantity=" + Convert.ToInt32(other_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(other_rate.Text) + ",price=" + Convert.ToDouble(other_rate.Text) * Convert.ToDouble(other_quantity.Text) + " where s_no=" + jj + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE FROM electrical", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            other_sample.ItemsSource = null;
                            other_sample.Items.Refresh();
                            other_sample.ItemsSource = dt.DefaultView;
                            gsize1();
                            double cv = 0;
                            for (int i = 0; i < Convert.ToInt32(other_S_NO.Text) - 1; i++)
                            {
                                cv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                            }
                            other_total_amount.Text = cv.ToString();
                            other_btnval = "N";
                            other_descrip.Text = ""; other_quantity.Text = "1"; other_price.Text = "0"; other_rate.Text = "0";
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
            else if (other_btnval == "E")
            {
                if (!string.IsNullOrWhiteSpace(other_vehicle_num.Text) & !string.IsNullOrWhiteSpace(other_view_bill_number.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER")
                    {
                        string l = other_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            other_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM other_expense where vehicle='" + other_vehicle_num.Text + "' and bill_no='" + other_view_bill_number.Text + "' and expense_type='OTHER'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    other_sample.ItemsSource = dt1.DefaultView;
                                    gsize1();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + other_vehicle_num.Text + "' and bill_no='" + other_view_bill_number.Text + "' and expense_type='OTHER'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    other_total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    other_discount.Text = dt2.Rows[0]["discount"].ToString();
                                    other_gnd_total_amount.Text = dt2.Rows[0]["gnd_total"].ToString();
                                }
                                else
                                {
                                    // MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }

                                con.close_string();
                                other_descrip.Text = ""; other_quantity.Text = "1"; other_price.Text = "0"; other_rate.Text = "0";
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
            else if (other_btnval == "ED")
            {
                if (!string.IsNullOrWhiteSpace(other_descrip.Text) & !string.IsNullOrWhiteSpace(other_quantity.Text) & !string.IsNullOrWhiteSpace(other_rate.Text) & !string.IsNullOrWhiteSpace(other_view_bill_number.Text) & !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
                {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER")
                    {
                        string l = other_vehicle_num.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            other_vehicle_num.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update other_expense set description='" + other_descrip.Text + "',quantity=" + Convert.ToInt32(other_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(other_rate.Text) + " where vehicle='" + other_vehicle_num.Text + "' and bill_no='" + other_view_bill_number.Text + "' and expense_type='OTHER'  and s_no=" + jj + "", con.str);
                                cmd.ExecuteNonQuery();


                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM other_EXPENSE where vehicle='" + other_vehicle_num.Text + "' and bill_no='" + other_view_bill_number.Text + "' and expense_type='OTHER' ", con.str);
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
                                other_total_amount.Text = p_tot.ToString();
                                other_gnd_total_amount.Text = (Convert.ToDouble(other_total_amount.Text) - Convert.ToDouble(other_discount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(other_total_amount.Text) + ",discount=" + Convert.ToDouble(other_discount.Text) + ",gnd_total=" + other_gnd_total_amount.Text + " where vehicle='" + other_vehicle_num.Text + "' and bill_no='" + other_view_bill_number.Text + "' and expense_type='OTHER' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM other_EXPENSE where vehicle='" + other_vehicle_num.Text + "' and bill_no='" + other_view_bill_number.Text + "' and expense_type='OTHER' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                other_sample.ItemsSource = dt1.DefaultView;
                                gsize1();
                                con.close_string();
                                other_btnval = "E";
                                other_descrip.Text = ""; other_quantity.Text = "1"; other_rate.Text = "0"; other_price.Text = "0";
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
                    MessageBox.Show("Should Fill All Text Fields");
                }

            }
            else if (other_btnval == "V" && !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = other_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        other_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from other_expense where vehicle='" + other_vehicle_num.Text + "' and bill_no='" + other_view_bill_number.Text + "' and expense_type='OTHER'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                other_sample.ItemsSource = dt.DefaultView;
                                gsize1();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + other_vehicle_num.Text + "' and bill_no='" + other_view_bill_number.Text + "' and expense_type='OTHER'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    other_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    other_discount.Text = dt1.Rows[0]["discount"].ToString();
                                    other_gnd_total_amount.Text = dt1.Rows[0]["gnd_total"].ToString();
                                    //bill_num.Text = dt1.Rows[0]["bill_no"].ToString();
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
                MessageBox.Show("Should Select Which Process You Want Made");
            }



        }



        void other_sample_mouseclick(object sender, MouseButtonEventArgs e)
        {
            if (other_btnval == "N")
            {
                try
                {
                    DataRowView dr = (DataRowView)other_sample.SelectedItem;
                    jj = kj = Convert.ToInt32(dr["S_NO"]);
                    other_descrip.Text = (dr["DESCRIPTION"]).ToString();
                    other_quantity.Text = (dr["QUANTITY"]).ToString();
                    other_rate.Text = (dr["QUANTITY_RATE"]).ToString();
                    other_price.Text = (dr["PRICE"]).ToString();
                    other_btnval = "NE";
                    other_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Please Insert Atleast One Bill");
                }

            }
            else if (other_btnval == "E")
            {
                try
                {
                    DataRowView dr = (DataRowView)other_sample.SelectedItem;
                    jj = kj = Convert.ToInt32(dr["S_NO"]);
                    other_descrip.Text = (dr["DESCRIPTION"]).ToString();
                    other_quantity.Text = (dr["QUANTITY"]).ToString();
                    other_rate.Text = (dr["QUANTITY_RATE"]).ToString();
                    other_price.Text = (dr["PRICE"]).ToString();
                    other_btnval = "ED";
                    other_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Please Insert Atleast One Bill");
                }

            }
            else if (other_btnval == "V")
            {
                MessageBox.Show("You Could Not Edit in View Mode");
            }
            else
            {
                MessageBox.Show("Grid Is Empty");
            }

        }



        void other_discount_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(other_discount.Text))
                {
                    other_discount.Text = "0";
                }
                if (other_btnval == "N")
                {
                    other_gnd_total_amount.Text = (Convert.ToDouble(other_total_amount.Text) - Convert.ToDouble(other_discount.Text)).ToString();
                    other_done_bttn.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    other_gnd_total_amount.Text = (Convert.ToDouble(other_total_amount.Text) - Convert.ToDouble(other_discount.Text)).ToString();
                    other_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }


        void insert_other_details(object sender, RoutedEventArgs e)
        {
            if (other_btnval == "N" && !string.IsNullOrWhiteSpace(other_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER" )
                {
                    string l = other_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        other_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection CON = new Connection();
                            CON.connection_string();
                            string SS = Convert.ToDateTime(other_bill_date.Text).ToString("yyyy/MM/dd");
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + other_bill_num.Text + "','" + SS + "','" + other_vehicle_num.Text + "'," + Convert.ToDouble(other_total_amount.Text) + "," + Convert.ToDouble(other_discount.Text) + "," + Convert.ToDouble(other_gnd_total_amount.Text) + ",'OTHER')", CON.str);
                                cmd1.ExecuteNonQuery();
                                for (int I = 0; I < Convert.ToInt32(other_S_NO.Text) - 1; I++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into other_expense(s_no,bill_no,description,quantity,quantity_rate,vehicle,bill_date,expense_type)values(" + others_s_no[I] + ",'" + other_bill_num.Text + "','" + others_description[I] + "','" + others_quantity[I] + "','" + others_b_rate[I] + "','" + other_vehicle_num.Text + "','" + SS + "','OTHER')", CON.str);
                                    cmd.ExecuteNonQuery();

                                }

                                other_bill_num.Text = ""; other_bill_num.IsEnabled = true;
                                other_total_amount.Text = "0"; other_vehicle_num.Text = ""; other_bill_date.Text = DateTime.Now.ToShortDateString(); other_S_NO.Text = "1"; other_discount.Text = "0"; other_gnd_total_amount.Text = "0";
                                other_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                other_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                other_array_clear();
                                other_sample.ItemsSource = null;
                                other_sample.Items.Refresh();
                                other_descrip.Focus();
                                OdbcCommand cmd2 = new OdbcCommand("delete from electrical", CON.str);
                                cmd2.ExecuteNonQuery();
                                CON.close_string();
                            }
                            else if(mbr==MessageBoxResult.Cancel)
                            {

                            }
                            CON.close_string();
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
                MessageBox.Show("Select NEW Button And Hit Here");
            }


        }



        void other_details_clear(object sender, RoutedEventArgs e)
        {

            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from electrical", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            other_sample.ItemsSource = null;
            other_sample.Items.Refresh();
            other_array_clear();
            other_bill_num.Text = ""; other_total_amount.Text = "0"; other_vehicle_num.Text = ""; other_bill_date.Text = DateTime.Now.ToShortDateString(); other_S_NO.Text = "1"; other_discount.Text = "0"; other_total_amount.Text = "0";
            other_descrip.Text = ""; other_quantity.Text = "1"; other_rate.Text = "0"; other_price.Text = "0";
        }


        void other_control_hide()
        {
            other_descrip.Visibility = System.Windows.Visibility.Hidden;
            other_bl1.Visibility = System.Windows.Visibility.Hidden;
            other_quantity.Visibility = System.Windows.Visibility.Hidden;
            other_bl2.Visibility = System.Windows.Visibility.Hidden;
            other_rate.Visibility = System.Windows.Visibility.Hidden;
            other_bl3.Visibility = System.Windows.Visibility.Hidden;
            other_price.Visibility = System.Windows.Visibility.Hidden;
            other_bl4.Visibility = System.Windows.Visibility.Hidden;
            other_bill_date.Visibility = System.Windows.Visibility.Hidden;
            other_bill_no.Visibility = System.Windows.Visibility.Hidden;
            other_bill_num.Visibility = System.Windows.Visibility.Hidden;
            other_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            other_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
        }
        void other_control_view()
        {
            other_descrip.Visibility = System.Windows.Visibility.Visible;
            other_bl1.Visibility = System.Windows.Visibility.Visible;
            other_quantity.Visibility = System.Windows.Visibility.Visible;
            other_bl2.Visibility = System.Windows.Visibility.Visible;
            other_rate.Visibility = System.Windows.Visibility.Visible;
            other_bl3.Visibility = System.Windows.Visibility.Visible;
            other_price.Visibility = System.Windows.Visibility.Visible;
            other_bl4.Visibility = System.Windows.Visibility.Visible;
            other_bill_date.Visibility = System.Windows.Visibility.Hidden;
            other_bill_no.Visibility = System.Windows.Visibility.Hidden;
            other_bill_num.Visibility = System.Windows.Visibility.Hidden;
            other_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            other_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
        }


        void gsize1()
        {
            other_sample.Columns[0].Width = 72;
            other_sample.Columns[1].Width = 250;
            other_sample.Columns[2].Width = 140;
            other_sample.Columns[3].Width = 140;
            other_sample.Columns[4].Width = 140;
        }
        void other_array_clear()
        {
            Array.Clear(others_description, 0, others_description.Length);
            Array.Clear(others_quantity, 0, others_quantity.Length);
            Array.Clear(others_b_rate, 0, others_b_rate.Length);
            Array.Clear(others_price, 0, others_price.Length);
            Array.Clear(others_s_no, 0, others_s_no.Length);
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
        void Other_Rate_Textchanged(object sender, TextChangedEventArgs e)
        {
            int len = 0;
            string s = other_rate.Text;
            if(!string.IsNullOrWhiteSpace(other_rate.Text))
            {
                len = other_rate.Text.Length;
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
        void Other_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(other_vehicle_num.Text)) 
            {

                len = other_vehicle_num.Text.Length;
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
        void Other_Bill_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(other_view_bill_number.Text))
            {

                len = other_view_bill_number.Text.Length;
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
                other_vehicle_num.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    other_vehicle_num.Items.Add(dt.Rows[i]["vehicle_number"]);
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
           
        }
    }
}
