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
    /// Interaction logic for Maintenance.xaml
    /// </summary>
    public partial class Body_Maintenance : UserControl
    {
        public Body_Maintenance() 
        {
            InitializeComponent();
            view_bill_number.Visibility = Visibility.Hidden;
            add_all_bill_number.Visibility = Visibility.Hidden;
            done_bttn.Visibility = Visibility.Hidden;
        }

       
        string btnval = null;
        int control = 0;
        int j = 0;
        int k = 0;
        string[] description = new string[50];
        int[] quantity = new int[50];
        double[] b_rate = new double[50];
        double[] price = new double[50];
        int[] s_no = new int[50];
        void body_build_expense_insert(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Body_Vehicle_Number = "";
            g.Description = "";
            g.Quantity = "1";
            g.Rate = "";
            g.Bill_No = "";
            g.Discount = "";
            this.DataContext = g;
            btn1.Background = System.Windows.Media.Brushes.Green;
            btn2.Background = System.Windows.Media.Brushes.Yellow;
            btn3.Background = System.Windows.Media.Brushes.Yellow;
            sample.Visibility = Visibility.Visible;
            btnval = "N";
            control_view();
            bill_date.Visibility = Visibility.Visible;
            bill_no.Visibility = Visibility.Visible;
            bill_num.Visibility = Visibility.Visible;
            view_bill_number.Visibility = Visibility.Hidden;
            add_all_bill_number.Visibility = Visibility.Hidden;
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from electrical", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            bill_num.IsEnabled = true;
            bill_num.Text = "";
            body_array_clear();
            sample.ItemsSource = null;
            sample.Items.Refresh();
            body_descrip.Focus();
        }
        void body_build_expense_update(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Body_Vehicle_Number = "";
            g.Description = "";
            g.Quantity = "1";
            g.Rate = "";
            g.Bill_No = "";
            g.Discount = "";
            this.DataContext = g;
            btn1.Background = System.Windows.Media.Brushes.Yellow;
            btn2.Background = System.Windows.Media.Brushes.Green;
            btn3.Background = System.Windows.Media.Brushes.Yellow;
            sample.Visibility = Visibility.Visible;
            btnval = "E";
            control_view();
            sample.ItemsSource = null;
            sample.Items.Refresh();
        }
        void body_build_expense_view(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Body_Vehicle_Number = "";           
            g.Bill_Num = "";
            this.DataContext = g;
            btn1.Background = System.Windows.Media.Brushes.Yellow;
            btn2.Background = System.Windows.Media.Brushes.Yellow;
            btn3.Background = System.Windows.Media.Brushes.Green;
            sample.Visibility = Visibility.Visible;
            btnval = "V";
            control_hide();
            sample.ItemsSource = null;
            sample.Items.Refresh();
        }

        
        void body_rate_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                body_price.Text = (Convert.ToDouble(body_quantity.Text) * Convert.ToDouble(body_rate.Text)).ToString();
                if (control == 1)
                {
                    body_add.Focus();
                }
            }
        }

        void vehicle_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER" & !string.IsNullOrWhiteSpace(vehicle_num.Text))
                {
                    string l = vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (btnval == "V" || btnval == "E")
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select  bill_no from expense_bill  where vehicle='" + vehicle_num.Text + "' and expense_type='BODY' ORDER BY bill_no DESC ", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       
                        else if (btnval == "N")
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


        void add_all_bill_number_checked(object sender, RoutedEventArgs e)
        {
            add_all_bill_number.IsChecked = false;
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER" & !string.IsNullOrWhiteSpace(vehicle_num.Text))
            {
                string l = vehicle_num.Text;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    vehicle_num.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    if (btnval == "V"||btnval=="E")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select  bill_no from expense_bill  where vehicle='" + vehicle_num.Text + "' and expense_type='BODY' ORDER BY bill_no DESC ", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);
                                if (dt.Rows.Count > 10)
                                {
                                    for (int c = 0; c < 10; c++)
                                    {
                                        view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                    }
                                }
                                else
                                {
                                    for (int c = 0; c < dt.Rows.Count; c++)
                                    {
                                        view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                   
                    else if (btnval == "N")
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


        void bill_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (bill_num.Text.Length >= 6)
                {
                    MessageBoxResult mr = MessageBox.Show("Length Should be Less-than 6 Digit", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (mr == MessageBoxResult.OK)
                    {
                        bill_num.Focus();
                        bill_num.Text = "";
                    }
                    else if(mr==MessageBoxResult.No)
                    {

                    }
                }
                else if (btnval == "N" & string.IsNullOrWhiteSpace(bill_num.Text))
                {
                    try
                    {
                        Connection con1 = new Connection();
                        con1.connection_string();
                        OdbcCommand cmd1 = new OdbcCommand("select max(BILL_NO)as bill_nos from expense_bill", con1.str);
                        OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            try
                            {
                                bill_num.Text = (Convert.ToInt32(dt.Rows[0]["bill_nos"].ToString()) + 1).ToString();
                                bill_num.IsEnabled = false;
                            }
                            catch
                            {
                                bill_num.Text = "0001";
                                bill_num.IsEnabled = false;
                            }

                        }
                        else
                        {
                            bill_num.Text = "0001";
                            bill_num.IsEnabled = false;
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
                    bill_num.IsEnabled = false;
                }
            }

        }



        void add_new_row(object sender, RoutedEventArgs e)
        {
            if (btnval == "N" & !string.IsNullOrWhiteSpace(vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {

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
                if (!string.IsNullOrWhiteSpace(body_descrip.Text) & !string.IsNullOrWhiteSpace(body_quantity.Text) & !string.IsNullOrWhiteSpace(body_rate.Text) & !string.IsNullOrWhiteSpace(bill_num.Text) & !string.IsNullOrWhiteSpace(vehicle_num.Text) & !string.IsNullOrWhiteSpace(bill_date.Text))
                {
                    try
                    {
                        int val = Convert.ToInt32(S_NO.Text);
                        description[val - 1] = body_descrip.Text;
                        quantity[val - 1] = Convert.ToInt32(body_quantity.Text);
                        b_rate[val - 1] = Convert.ToDouble(body_rate.Text);
                        price[val - 1] = Convert.ToDouble(body_price.Text);
                        s_no[val - 1] = val;
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd = new OdbcCommand("insert into electrical(s_no,description,quantity,quantity_rate,price)values(" + Convert.ToInt32(S_NO.Text) + ",'" + body_descrip.Text + "'," + Convert.ToInt32(body_quantity.Text) + "," + Convert.ToDouble(body_rate.Text) + "," + Convert.ToDouble(body_rate.Text) * Convert.ToInt32(body_quantity.Text) + ")", con.str);
                        cmd.ExecuteNonQuery();
                        OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE FROM electrical", con.str);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da.Fill(dt);                        
                        sample.ItemsSource = null;
                        sample.Items.Refresh();
                        sample.ItemsSource = dt.DefaultView;
                        gsize();
                        S_NO.Text = (Convert.ToInt32(S_NO.Text) + 1).ToString();
                        double cb = 0;
                        for (int i = 0; i < val; i++)
                        {

                            cb += Convert.ToDouble(price[i]);

                        }
                        total_amount.Text = cb.ToString();
                        body_descrip.Text = ""; body_quantity.Text = "1"; body_price.Text = "0"; body_rate.Text = "0";
                        body_descrip.Focus();
                        clear_bttn.Visibility = Visibility.Visible;
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
            else if (btnval == "NE" & !string.IsNullOrWhiteSpace(vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            description[j - 1] = body_descrip.Text;
                            quantity[j - 1] = Convert.ToInt32(body_quantity.Text);
                            b_rate[j - 1] = Convert.ToDouble(body_rate.Text);
                            price[j - 1] = Convert.ToDouble(body_price.Text);
                            s_no[j - 1] = j;
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update electrical set description='" + body_descrip.Text + "',quantity=" + Convert.ToInt32(body_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(body_rate.Text) + ",price=" + Convert.ToDouble(body_rate.Text) * Convert.ToDouble(body_quantity.Text) + " where s_no=" + j + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,PRICE FROM electrical", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            sample.ItemsSource = null;
                            sample.Items.Refresh();
                            sample.ItemsSource = dt.DefaultView;
                            gsize();
                            double cv = 0;
                            for (int i = 0; i < Convert.ToInt32(S_NO.Text) - 1; i++)
                            {
                                cv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                            }
                            total_amount.Text = cv.ToString();
                            btnval = "N";
                            body_descrip.Text = ""; body_quantity.Text = "1"; body_price.Text = "0"; body_rate.Text = "0";
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
            else if (btnval == "E" & !string.IsNullOrWhiteSpace(vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(vehicle_num.Text) & !string.IsNullOrWhiteSpace(view_bill_number.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE as PRICE FROM body_build_expense where vehicle='" + vehicle_num.Text + "' and bill_no='" + view_bill_number.Text + "' and expense_type='BODY'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da1.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    sample.ItemsSource = dt.DefaultView;
                                    gsize();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }
                                OdbcCommand cmd2 = new OdbcCommand("select sub_total,discount,gnd_total from expense_bill where vehicle='" + vehicle_num.Text + "' and bill_no='" + view_bill_number.Text + "' and expense_type='BODY'", con.str);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    total_amount.Text = dt2.Rows[0]["sub_total"].ToString();
                                    body_discount.Text = dt2.Rows[0]["discount"].ToString();
                                    gnd_total_amount.Text = dt2.Rows[0]["gnd_total"].ToString();
                                }
                                else
                                {
                                    // MessageBox.Show("Vehicle Bill Doesn't Exist on Mentioned Date");
                                }

                                con.close_string();
                                body_descrip.Text = ""; body_quantity.Text = "1"; body_price.Text = "0"; body_rate.Text = "0";
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
            else if (btnval == "ED" & !string.IsNullOrWhiteSpace(vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(body_descrip.Text) & !string.IsNullOrWhiteSpace(body_quantity.Text) & !string.IsNullOrWhiteSpace(body_rate.Text) & !string.IsNullOrWhiteSpace(view_bill_number.Text) & !string.IsNullOrWhiteSpace(vehicle_num.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update body_build_expense set description='" + body_descrip.Text + "',quantity=" + Convert.ToInt32(body_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(body_rate.Text) + " where vehicle='" + vehicle_num.Text + "' and bill_no='" + view_bill_number.Text + "' and expense_type='BODY'  and s_no=" + j + "", con1.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM BODY_BUILD_EXPENSE where vehicle='" + vehicle_num.Text + "' and bill_no='" + view_bill_number.Text + "' and expense_type='BODY' ", con1.str);
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
                                total_amount.Text = p_tot.ToString();
                                gnd_total_amount.Text = (Convert.ToDouble(total_amount.Text) - Convert.ToDouble(body_discount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(total_amount.Text) + ",discount=" + Convert.ToDouble(body_discount.Text) + ",gnd_total=" + gnd_total_amount.Text + " where vehicle='" + vehicle_num.Text + "' and bill_no='" + view_bill_number.Text + "' and expense_type='BODY' ", con1.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM BODY_BUILD_EXPENSE where vehicle='" + vehicle_num.Text + "' and bill_no='" + view_bill_number.Text + "' and expense_type='BODY' ", con1.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                sample.ItemsSource = dt1.DefaultView;
                                gsize();
                                con1.close_string();
                                btnval = "E";
                                body_descrip.Text = ""; body_quantity.Text = "1"; body_rate.Text = "0"; body_price.Text = "0";
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
            else if (btnval == "V" & !string.IsNullOrWhiteSpace(vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from body_build_expense where vehicle='" + vehicle_num.Text + "' and bill_no='" + view_bill_number.Text + "' and expense_type='BODY'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                sample.ItemsSource = dt.DefaultView;
                                gsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + vehicle_num.Text + "' and bill_no='" + view_bill_number.Text + "' and expense_type='BODY'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    body_discount.Text = dt1.Rows[0]["discount"].ToString();
                                    gnd_total_amount.Text = dt1.Rows[0]["gnd_total"].ToString();
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


        void body_build_sample_mouseclick(object sender, MouseButtonEventArgs e)
        {
            if (btnval == "N")
            {
                try
                {
                    DataRowView dr = (DataRowView)sample.SelectedItem;
                    j = k = Convert.ToInt32(dr["S_NO"]);
                    body_descrip.Text = (dr["DESCRIPTION"]).ToString();
                    body_quantity.Text = (dr["QUANTITY"]).ToString();
                    body_rate.Text = (dr["QUANTITY_RATE"]).ToString();
                    body_price.Text = (dr["PRICE"]).ToString();
                    btnval = "NE";
                    body_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Please Insert Atleast One Bill");
                }

            }
            else if (btnval == "E")
            {
                try
                {
                    DataRowView dr = (DataRowView)sample.SelectedItem;
                    j = k = Convert.ToInt32(dr["S_NO"]);
                    body_descrip.Text = (dr["DESCRIPTION"]).ToString();
                    body_quantity.Text = (dr["QUANTITY"]).ToString();
                    body_rate.Text = (dr["QUANTITY_RATE"]).ToString();
                    body_price.Text = (dr["PRICE"]).ToString();
                    btnval = "ED";
                    body_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Please Insert Atleast One Bill");
                }

            }
            else if (btnval == "V")
            {
                MessageBox.Show("You Could Not Edit in View Mode");
            }
            else
            {
                MessageBox.Show("Grid Is Empty");
            }

        }


        void body_discount_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(string.IsNullOrWhiteSpace(body_discount.Text))
                {
                    body_discount.Text = "0";
                }
                if (btnval == "N")
                {
                    gnd_total_amount.Text = (Convert.ToDouble(total_amount.Text) - Convert.ToDouble(body_discount.Text)).ToString();
                    done_bttn.Visibility = Visibility.Visible;
                }
                else
                {
                    gnd_total_amount.Text = (Convert.ToDouble(total_amount.Text) - Convert.ToDouble(body_discount.Text)).ToString();
                    done_bttn.Visibility = Visibility.Hidden;
                }
            }
        }


        void insert_body_builder_details(object sender, RoutedEventArgs e)
        {
            if (btnval == "N" & !string.IsNullOrWhiteSpace(vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection CON = new Connection();
                            CON.connection_string();
                            string SS = Convert.ToDateTime(bill_date.Text).ToString("yyyy/MM/dd");
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int I = 0; I < Convert.ToInt32(S_NO.Text) - 1; I++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into body_build_expense(s_no,bill_no,description,quantity,quantity_rate,vehicle,bill_date,expense_type)values(" + s_no[I] + ",'" + bill_num.Text + "','" + description[I] + "','" + quantity[I] + "','" + b_rate[I] + "','" + vehicle_num.Text + "','" + SS + "','BODY')", CON.str);
                                    cmd.ExecuteNonQuery();

                                }
                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + bill_num.Text + "','" + SS + "','" + vehicle_num.Text + "','" + Convert.ToDouble(total_amount.Text) + "','" + Convert.ToDouble(body_discount.Text) + "','" + Convert.ToDouble(gnd_total_amount.Text) + "','BODY')", CON.str);
                                cmd1.ExecuteNonQuery();
                                bill_num.Text = ""; bill_num.IsEnabled = true;
                                total_amount.Text = "0"; vehicle_num.Text = ""; bill_date.Text = DateTime.Now.ToShortDateString(); S_NO.Text = "1"; body_discount.Text = "0"; gnd_total_amount.Text = "0";
                                done_bttn.Visibility = Visibility.Hidden;
                                clear_bttn.Visibility = Visibility.Hidden;
                                body_array_clear();
                                sample.ItemsSource = null;
                                sample.Items.Refresh();
                                control = 0;
                                body_descrip.Focus();
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


        void body_build_details_clear(object sender, RoutedEventArgs e)
        {

            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from electrical", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            sample.ItemsSource = null;
            sample.Items.Refresh();
            body_array_clear();
            bill_num.Text = ""; total_amount.Text = "0"; vehicle_num.Text = ""; bill_date.Text = DateTime.Now.ToShortDateString(); S_NO.Text = "1"; body_discount.Text = "0"; gnd_total_amount.Text = "0";
            body_descrip.Text = ""; body_quantity.Text = "1"; body_rate.Text = "0"; body_price.Text = "0";
        }


        void control_hide()
        {
            body_descrip.Visibility = Visibility.Hidden;
            bl1.Visibility = Visibility.Hidden;
            body_quantity.Visibility = Visibility.Hidden;
            bl2.Visibility = Visibility.Hidden;
            body_rate.Visibility = Visibility.Hidden;
            bl3.Visibility = Visibility.Hidden;
            body_price.Visibility = Visibility.Hidden;
            bl4.Visibility = Visibility.Hidden;
            bill_date.Visibility = Visibility.Hidden;
            bill_no.Visibility = Visibility.Hidden;
            bill_num.Visibility = Visibility.Hidden;
            view_bill_number.Visibility = Visibility.Visible;
            add_all_bill_number.Visibility = Visibility.Visible;
        }
        void control_view()
        {
            body_descrip.Visibility = Visibility.Visible;
            bl1.Visibility = Visibility.Visible;
            body_quantity.Visibility = Visibility.Visible;
            bl2.Visibility = Visibility.Visible;
            body_rate.Visibility = Visibility.Visible;
            bl3.Visibility = Visibility.Visible;
            body_price.Visibility = Visibility.Visible;
            bl4.Visibility = Visibility.Visible;
            bill_date.Visibility = Visibility.Hidden;
            bill_no.Visibility = Visibility.Hidden;
            bill_num.Visibility = Visibility.Hidden;
            view_bill_number.Visibility = Visibility.Visible;
            add_all_bill_number.Visibility = Visibility.Visible;
        }



        void gsize()
        {
            sample.Columns[0].Width = 72;
            sample.Columns[1].Width = 250;
            sample.Columns[2].Width = 140;
            sample.Columns[3].Width = 140;
            sample.Columns[4].Width = 140;
        }
        void body_array_clear()
        {
            Array.Clear(description, 0, description.Length);
            Array.Clear(quantity, 0, quantity.Length);
            Array.Clear(b_rate, 0, b_rate.Length);
            Array.Clear(price, 0, price.Length);
            Array.Clear(s_no, 0, s_no.Length);
        }

        void Rate_PreViewTextInput(object sender,TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender,e); 
        }

        void Discount_PreViewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }

        void Body_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(vehicle_num.Text))
            {

                len = vehicle_num.Text.Length;
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
        void Body_Bill_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(view_bill_number.Text))
            {

                len = view_bill_number.Text.Length;
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
        void Body_Rate_Textchanged(object sender,TextChangedEventArgs e)
        {
            int len = 0;            
            if(!string.IsNullOrWhiteSpace(body_rate.Text))
            {
                len = body_rate.Text.Length;
            }
            
            
            if (len<=6)
            {
                for(int i=0;i<len;i++)
                {
                    bool isdigit = char.IsDigit(body_rate.Text[i]);
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
                vehicle_num.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vehicle_num.Items.Add(dt.Rows[i]["vehicle_number"]);
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
           
           
        }
    }
}
