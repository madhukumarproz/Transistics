using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Mechanical_Expense.xaml
    /// </summary>
    public partial class Mechanical_Expense : UserControl
    {
        public Mechanical_Expense()
        {
            InitializeComponent();
            mechanical_view_bill_number.Visibility = Visibility.Hidden;
            mechanical_add_all_bill_number.Visibility = Visibility.Hidden;
            mechanical_done_bttn.Visibility = Visibility.Hidden;
        }


        int mechanical_btn_val = 0;
        string mechanical_btn_char = null;
        string[] mechanical_des = new string[50];
        int[] mechanical_qnty = new int[50];
        double[] mechanical_qnt_rate = new double[50];
        double[] mechanical_qnt_price = new double[50];
        double[] km = new double[50];
        int[] mechanical_snos = new int[50];
        int mechanical_s_val = 0;
        void lathe_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            lathe_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 1;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();

        }
        void tailer_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            tailer_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 2;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void grown_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            grown_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 3;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void cledge_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            cledge_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 4;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void spring_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            spring_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 5;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void pump_nosil_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            pump_nosil_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 6;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void radiator_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            radiator_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 7;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void gearbox_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            gearbox_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 8;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void oil_service_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            oil_service_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 9;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void turbo_expense_click(object sender, RoutedEventArgs e)
        {
            mechanical_button();
            turbo_expense.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn();
            mechanical_new_bill.IsEnabled = true; mechanical_edit_bill.IsEnabled = true; mechanical_view_bill.IsEnabled = true;
            mechanical_btn_val = 10;
            mechanical_btn_char = "";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
        }
        void mechanical_new_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Mech_Vehicle_Number = "";
            g.Mech_Description = "";
            g.Mech_Quantity = "1";
            g.Mech_Rate = "";
            g.Mech_Bill_No = "";
            g.Mech_Discount = "";
            g.Mech_Bill_Num = "";
            g.KM = "";
            this.DataContext = g;
            mechanical_btn();
            mechanical_new_bill.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn_char = "N";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            mechanical_S_NO.Text = "1";
            mechanical_clear_array();
            visible();
            mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true;
            mechanical_datagrid1.ItemsSource = null;
            mechanical_datagrid1.Items.Refresh();
            mechanical_bill_num.IsEnabled = true;
            mechanical_descrip.Focus();
        }
        void mechanical_edit_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Mech_Vehicle_Number = "";
            g.Mech_Description = "";
            g.Mech_Quantity = "1";
            g.Mech_Rate = "";
            g.Mech_Bill_No = "";
            g.Mech_Discount = "";
            g.Mech_Bill_Num = "";
            g.KM = "";
            this.DataContext = g;
            mechanical_btn();
            mechanical_edit_bill.Background = System.Windows.Media.Brushes.Green;

            mechanical_btn_char = "E";

            visible();
            mechanical_bill_date.Visibility = System.Windows.Visibility.Hidden;
            mechanical_bill_no.Visibility = System.Windows.Visibility.Hidden;
            mechanical_bill_num.Visibility = System.Windows.Visibility.Hidden;
            mechanical_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            mechanical_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
            mechanical_datagrid1.ItemsSource = null;
            mechanical_datagrid1.Items.Refresh();
            mechanical_bill_num.IsEnabled = false;

            mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0";
        }
        void mechanical_view_bill_click(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Mech_Vehicle_Number = "";
            g.Mech_Bill_Num = "";
            this.DataContext = g;
            mechanical_btn();
            mechanical_view_bill.Background = System.Windows.Media.Brushes.Green;
            mechanical_btn_char = "V";
            mechanical_descrip.Visibility = System.Windows.Visibility.Hidden;
            mechanical_quantity.Visibility = System.Windows.Visibility.Hidden;
            mechanical_rate.Visibility = System.Windows.Visibility.Hidden;
            mechanical_price.Visibility = System.Windows.Visibility.Hidden;
            mechanical_km.Visibility = System.Windows.Visibility.Hidden;
            mechanical_lbl1.Visibility = System.Windows.Visibility.Hidden;
            mechanical_lbl2.Visibility = System.Windows.Visibility.Hidden;
            mechanical_lbl3.Visibility = System.Windows.Visibility.Hidden;
            mechanical_lbl4.Visibility = System.Windows.Visibility.Hidden;
            mechanical_lbl5.Visibility = System.Windows.Visibility.Hidden;
            mechanical_bill_date.Visibility = System.Windows.Visibility.Hidden;
            mechanical_bill_no.Visibility = System.Windows.Visibility.Hidden;
            mechanical_bill_num.Visibility = System.Windows.Visibility.Hidden;
            mechanical_view_bill_number.Visibility = System.Windows.Visibility.Visible;
            mechanical_add_all_bill_number.Visibility = System.Windows.Visibility.Visible;
            mechanical_datagrid1.ItemsSource = null;
            mechanical_datagrid1.Items.Refresh();
            mechanical_bill_num.IsEnabled = false;
            mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0";
        }
        void visible()
        {
            mechanical_descrip.Visibility = System.Windows.Visibility.Visible;
            mechanical_quantity.Visibility = System.Windows.Visibility.Visible;
            mechanical_rate.Visibility = System.Windows.Visibility.Visible;
            mechanical_price.Visibility = System.Windows.Visibility.Visible;

            mechanical_lbl1.Visibility = System.Windows.Visibility.Visible;
            mechanical_lbl2.Visibility = System.Windows.Visibility.Visible;
            mechanical_lbl3.Visibility = System.Windows.Visibility.Visible;
            mechanical_lbl4.Visibility = System.Windows.Visibility.Visible;
            mechanical_bill_date.Visibility = System.Windows.Visibility.Visible;
            mechanical_bill_no.Visibility = System.Windows.Visibility.Visible;
            mechanical_bill_num.Visibility = System.Windows.Visibility.Visible;
            mechanical_view_bill_number.Visibility = System.Windows.Visibility.Hidden;
            mechanical_add_all_bill_number.Visibility = System.Windows.Visibility.Hidden;
            if (mechanical_btn_val > 5)
            {
                mechanical_km.Visibility = System.Windows.Visibility.Visible;
                mechanical_lbl5.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                mechanical_km.Visibility = System.Windows.Visibility.Hidden;
                mechanical_lbl5.Visibility = System.Windows.Visibility.Hidden;
            }
        }


      public  void mechanical_button()
        {
            lathe_expense.Background = System.Windows.Media.Brushes.Yellow;
            tailer_expense.Background = System.Windows.Media.Brushes.Yellow;
            grown_expense.Background = System.Windows.Media.Brushes.Yellow;
            cledge_expense.Background = System.Windows.Media.Brushes.Yellow;
            spring_expense.Background = System.Windows.Media.Brushes.Yellow;
            pump_nosil_expense.Background = System.Windows.Media.Brushes.Yellow;
            radiator_expense.Background = System.Windows.Media.Brushes.Yellow;
            gearbox_expense.Background = System.Windows.Media.Brushes.Yellow;
            oil_service_expense.Background = System.Windows.Media.Brushes.Yellow;
            turbo_expense.Background = System.Windows.Media.Brushes.Yellow;

        }
      public  void mechanical_btn()
        {
            mechanical_new_bill.Background = System.Windows.Media.Brushes.Yellow;
            mechanical_edit_bill.Background = System.Windows.Media.Brushes.Yellow;
            mechanical_view_bill.Background = System.Windows.Media.Brushes.Yellow;
        }


        void mechanical_quantity_rate_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                mechanical_price.Text = (Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text)).ToString();
            }
        }


        void mechanical_vehicle_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter&&!string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (mechanical_btn_val == 1 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='LATHE' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 2 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='TAILER' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 3 && mechanical_btn_char == "E" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {

                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='GROWN' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 4 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {

                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='CLEDGE' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 5 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {

                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='SPRING' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 6 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {

                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='PUMP-NOSIL' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 7 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='RADIATOR' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 8 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {

                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='GEARBOX' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 9 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='OIL-SERVICE' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                       else if (mechanical_btn_val == 10 && mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.connection_string();
                                OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='TURBO' order by bill_no DESC", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_view_bill_number.Items.Clear();
                                if (dt.Rows.Count > 0)
                                {
                                    //dt.AsEnumerable().Take(10);
                                    if (dt.Rows.Count > 10)
                                    {
                                        for (int c = 0; c < 10; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
                                        }
                                    }
                                    else
                                    {
                                        for (int c = 0; c < dt.Rows.Count; c++)
                                        {
                                            mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                        else if (mechanical_btn_char == "N")
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
                MessageBox.Show("Select Vehicle Number");
            }
        }


        void mechanical_add_all_bill_number_checked(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
                
            if (user == "ADMIN" || user == "MANAGER" || user == "USER"&&!string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string l = mechanical_vehicle_num.Text;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    mechanical_vehicle_num.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    if (mechanical_btn_val == 1 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='LATHE' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                   else if (mechanical_btn_val == 2 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='TAILER' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                   else if (mechanical_btn_val == 3 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='GROWN' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                   else if (mechanical_btn_val == 4 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='CLEDGE' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {


                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                   else if (mechanical_btn_val == 5 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='SPRING' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                  else  if (mechanical_btn_val == 6 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='PUMP-NOSIL' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                   else if (mechanical_btn_val == 7 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='RADIATOR' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                  else  if (mechanical_btn_val == 8 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='GEARBOX' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                   else if (mechanical_btn_val == 9 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='OIL-SERVICE' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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
                   else if (mechanical_btn_val == 10 & mechanical_btn_char == "V" & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select bill_no from expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and expense_type='TURBO' order by bill_no DESC", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_view_bill_number.Items.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                //dt.AsEnumerable().Take(10);

                                for (int c = 0; c < dt.Rows.Count; c++)
                                {
                                    mechanical_view_bill_number.Items.Add(dt.Rows[c]["bill_no"]);
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


        void mechanical_bill_num_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (mechanical_bill_num.Text.Length >= 6)
                {
                    MessageBoxResult mr = MessageBox.Show("Length Should be Less-than 6 Digit", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (mr == MessageBoxResult.OK)
                    {
                        mechanical_bill_num.Focus();
                        mechanical_bill_num.Text = "";
                    }
                    else if(mr==MessageBoxResult.No)
                    {

                    }
                }
                else if (mechanical_btn_char == "N" & string.IsNullOrWhiteSpace(mechanical_bill_num.Text))
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
                                mechanical_bill_num.Text = (Convert.ToInt32(dt1.Rows[0]["bill_nos"]) + 1).ToString();
                                mechanical_bill_num.IsEnabled = false;
                            }
                            catch
                            {
                                mechanical_bill_num.Text = "0001";
                                mechanical_bill_num.IsEnabled = false;
                            }

                        }
                        else
                        {
                            mechanical_bill_num.Text = "0001";
                            mechanical_bill_num.IsEnabled = false;
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
                    mechanical_bill_num.IsEnabled = false;
                }

            }
        }


        void mechanical_add_new_row(object sender, RoutedEventArgs e)
        {
            if (mechanical_btn_val == 1 & mechanical_btn_char == "N"&&!string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text))
                        {
                            try
                            {

                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);
                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 2 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text))
                        {
                            try
                            {

                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);

                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("selEct S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 3 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text))
                        {
                            try
                            {

                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);

                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("selEct S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 4 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text))
                        {
                            try
                            {

                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);

                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("selEct S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 5 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text))
                        {
                            try
                            {

                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);

                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("selEct S_NO,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 6 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text) & !string.IsNullOrWhiteSpace(mechanical_km.Text))
                        {
                            try
                            {

                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);
                                km[count] = Convert.ToDouble(mechanical_km.Text);
                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price,km)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToDouble(mechanical_km.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 7 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text) & !string.IsNullOrWhiteSpace(mechanical_km.Text))
                        {
                            try
                            {

                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);
                                km[count] = Convert.ToDouble(mechanical_km.Text);
                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price,km)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToDouble(mechanical_km.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 8 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text) & !string.IsNullOrWhiteSpace(mechanical_km.Text))
                        {
                            try
                            {
                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);
                                km[count] = Convert.ToDouble(mechanical_km.Text);
                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price,km)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToDouble(mechanical_km.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 9 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text) & !string.IsNullOrWhiteSpace(mechanical_km.Text))
                        {
                            try
                            {

                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);
                                km[count] = Convert.ToDouble(mechanical_km.Text);
                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price,km)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToDouble(mechanical_km.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 10 & mechanical_btn_char == "N" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_date.Text) & !string.IsNullOrWhiteSpace(mechanical_km.Text))
                        {
                            try
                            {
                                int count = Convert.ToInt32(mechanical_S_NO.Text) - 1;
                                mechanical_snos[count] = Convert.ToInt32(mechanical_S_NO.Text);
                                km[count] = Convert.ToDouble(mechanical_km.Text);
                                mechanical_des[count] = mechanical_descrip.Text;
                                mechanical_qnty[count] = Convert.ToInt32(mechanical_quantity.Text);
                                mechanical_qnt_rate[count] = Convert.ToDouble(mechanical_rate.Text);
                                mechanical_qnt_price[count] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);

                                Connection CON = new Connection();
                                CON.connection_string();
                                OdbcCommand cmd = new OdbcCommand("insert into lpg_tank(s_no,description,quantity,rate,price,km)values(" + Convert.ToInt32(mechanical_S_NO.Text) + ",'" + mechanical_descrip.Text + "'," + Convert.ToInt32(mechanical_quantity.Text) + "," + Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + "," + Convert.ToDouble(mechanical_km.Text) + ")", CON.str);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,PRICE FROM lpg_tank", CON.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                double v = 0;
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text); i++)
                                {
                                    v += Convert.ToDouble(mechanical_qnt_price[i]);
                                    mechanical_total_amount.Text = v.ToString();
                                }
                                mechanical_S_NO.Text = (Convert.ToInt32(mechanical_S_NO.Text) + 1).ToString();
                                CON.close_string();
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Visible;
                                mechanical_descrip.Focus();
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
            else if (mechanical_btn_val == 1 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mechanical_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 2 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            Connection con = new Connection();

                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mechanical_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 3 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mechanical_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 4 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mechanical_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 5 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mechanical_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 6 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            km[mechanical_s_val - 1] = Convert.ToDouble(mechanical_km.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ",km=" + Convert.ToDouble(mechanical_km.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mech_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 7 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            km[mechanical_s_val - 1] = Convert.ToDouble(mechanical_km.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ",km=" + Convert.ToDouble(mechanical_km.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mech_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 8 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            km[mechanical_s_val - 1] = Convert.ToDouble(mechanical_km.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ",km=" + Convert.ToDouble(mechanical_km.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mech_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 9 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            km[mechanical_s_val - 1] = Convert.ToDouble(mechanical_km.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ",km=" + Convert.ToDouble(mechanical_km.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mech_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 10 & mechanical_btn_char == "NE" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {

                        try
                        {

                            mechanical_des[mechanical_s_val - 1] = mechanical_descrip.Text;
                            mechanical_qnty[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text);
                            mechanical_qnt_rate[mechanical_s_val - 1] = Convert.ToDouble(mechanical_rate.Text);
                            mechanical_qnt_price[mechanical_s_val - 1] = Convert.ToInt32(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text);
                            km[mechanical_s_val - 1] = Convert.ToDouble(mechanical_km.Text);
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("update lpg_tank set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",rate=" + Convert.ToDouble(mechanical_rate.Text) + ",price=" + Convert.ToDouble(mechanical_quantity.Text) * Convert.ToDouble(mechanical_rate.Text) + ",km=" + Convert.ToDouble(mechanical_km.Text) + " where s_no=" + mechanical_s_val + "", con.str);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,RATE,QUANTITY*RATE as PRICE FROM lpg_tank", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            mechanical_datagrid1.ItemsSource = dt.DefaultView;
                            mech_gridsize();
                            con.close_string();
                            double dv = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dv += Convert.ToDouble(dt.Rows[i]["PRICE"]);
                                mechanical_total_amount.Text = dv.ToString();
                            }
                            mechanical_btn_char = "N"; mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 1 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='LATHE'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='LATHE'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 2 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TAILER'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TAILER'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 3 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GROWN'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GROWN'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 4 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='CLEDGE'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='CLEDGE'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 5 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='SPRING'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='SPRING'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 6 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='PUMP-NOSIL'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='PUMP-NOSIL'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 7 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {

                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='RADIATOR'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='RADIATOR'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 8 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GEARBOX'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GEARBOX'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 9 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='OIL-SERVICE'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='OIL-SERVICE'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 10 & mechanical_btn_char == "E" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TURBO'", con.str);
                            OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                            DataTable DT = new DataTable();
                            DA.Fill(DT);
                            if (DT.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = DT.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TURBO'", con.str);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 1 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='LATHE'  and s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='LATHE' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='LATHE' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='LATHE' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mechanical_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 2 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TAILER' and s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select quantity*quantity_rate as price from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TAILER' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TAILER' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where  vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TAILER' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);


                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mechanical_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 3 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GROWN'  and s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GROWN' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and  and expense_type='GROWN' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GROWN' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mechanical_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 4 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='CLEDGE' and s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='CLEDGE' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='CLEDGE' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='CLEDGE' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mechanical_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 5 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='SPRING' and  s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='SPRING' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='SPRING' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='SPRING' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mechanical_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 6 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + ",KM=" + Convert.ToDouble(mechanical_km.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and  and expense_type='PUMP-NOSIL' and  s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='PUMP-NOSIL' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='PUMP-NOSIL' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='PUMP-NOSIL' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mech_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 7 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + ",KM=" + Convert.ToDouble(mechanical_km.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='RADIATOR'  and s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='RADIATOR' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='RADIATOR' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='RADIATOR' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mech_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 8 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + ",KM=" + Convert.ToDouble(mechanical_km.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GEARBOX'  and s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GEARBOX' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GEARBOX' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GEARBOX' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mech_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";

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
            else if (mechanical_btn_val == 9 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + ",KM=" + Convert.ToDouble(mechanical_km.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='OIL-SERVICE'  and s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='OIL-SERVICE' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='OIL-SERVICE' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='OIL-SERVICE' and ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mech_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
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
            else if (mechanical_btn_val == 10 & mechanical_btn_char == "ED" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        if (!string.IsNullOrWhiteSpace(mechanical_descrip.Text) & !string.IsNullOrWhiteSpace(mechanical_quantity.Text) & !string.IsNullOrWhiteSpace(mechanical_rate.Text) & !string.IsNullOrWhiteSpace(mechanical_bill_num.Text) & !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text) & !string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
                        {
                            try
                            {
                                Connection con1 = new Connection();
                                con1.connection_string();
                                OdbcCommand cmd = new OdbcCommand("update mechanical_expense set description='" + mechanical_descrip.Text + "',quantity=" + Convert.ToInt32(mechanical_quantity.Text) + ",quantity_rate=" + Convert.ToDouble(mechanical_rate.Text) + ",KM=" + Convert.ToDouble(mechanical_km.Text) + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TURBO'  and s_no=" + mechanical_s_val + "", con1.str);
                                cmd.ExecuteNonQuery();
                                con1.close_string();
                                Connection con = new Connection();
                                con.connection_string();

                                OdbcCommand cmd1 = new OdbcCommand("select QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TURBO' ", con.str);
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
                                mechanical_total_amount.Text = p_tot.ToString();
                                mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                                OdbcCommand cmd2 = new OdbcCommand("update expense_bill set sub_total=" + Convert.ToDouble(mechanical_total_amount.Text) + ",discount=" + Convert.ToDouble(mechanical_discount_amount.Text) + ",gnd_total=" + mechanical_grand_total.Text + " where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TURBO' ", con.str);
                                cmd2.ExecuteNonQuery();
                                OdbcCommand cmd3 = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE FROM mechanical_EXPENSE where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TURBO' ", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                mechanical_datagrid1.ItemsSource = dt1.DefaultView;
                                mech_gridsize();
                                con.close_string();
                                mechanical_btn_char = "E";
                                mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";

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
            else if (mechanical_btn_val == 1 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='LATHE'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='LATHE'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 2 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TRAILER'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TRAILER'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 3 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GROWN'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GROWN'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 4 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='CLEDGE'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='CLEDGE'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 5 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='SPRING'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mechanical_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='SPRING'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 6 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='PUMP-NOSIL'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='PUMP-NOSIL'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 7 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='RADIATOR'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select bill_no,sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='RADIATOR'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();
                                    mechanical_bill_num.Text = dt1.Rows[0]["bill_no"].ToString();
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
            else if (mechanical_btn_val == 8 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GEARBOX'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='GEARBOX'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 9 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='OIL-SERVICE'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='OIL-SERVICE'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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
            else if (mechanical_btn_val == 10 & mechanical_btn_char == "V" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string l = mechanical_vehicle_num.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        mechanical_vehicle_num.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select S_NO,KM,DESCRIPTION,QUANTITY,QUANTITY_RATE,QUANTITY*QUANTITY_RATE AS PRICE from mechanical_expense where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TURBO'", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                mechanical_datagrid1.ItemsSource = dt.DefaultView;
                                mech_gridsize();
                                OdbcCommand cmd1 = new OdbcCommand("select sub_total,discount,gnd_total FROM expense_bill where vehicle='" + mechanical_vehicle_num.Text + "' and bill_no='" + mechanical_view_bill_number.Text + "' and expense_type='TURBO'", con.str);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                if (dt.Rows.Count > 0)
                                {
                                    mechanical_total_amount.Text = dt1.Rows[0]["sub_total"].ToString();
                                    mechanical_discount_amount.Text = dt1.Rows[0]["discount"].ToString();
                                    mechanical_grand_total.Text = dt1.Rows[0]["gnd_total"].ToString();

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



        void mechanical_datagrid1_mouseclick(object sender, MouseButtonEventArgs e)
        {
            if (mechanical_btn_val == 1 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 2 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 3 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 4 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 5 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 6 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 7 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 8 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 9 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 10 & mechanical_btn_char.Equals("N"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "NE";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 1 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 2 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 3 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 4 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 5 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 6 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 7 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 8 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 9 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
                }
                catch
                {
                    MessageBox.Show("Datagrid is Empty");
                }
            }
            else if (mechanical_btn_val == 10 & mechanical_btn_char.Equals("E"))
            {
                try
                {
                    DataRowView dr = (DataRowView)mechanical_datagrid1.SelectedItem;
                    mechanical_descrip.Text = (dr["description"]).ToString();
                    mechanical_s_val = Convert.ToInt32(dr["s_no"]);
                    mechanical_quantity.Text = (dr["quantity"]).ToString();
                    mechanical_rate.Text = (dr["quantity_rate"]).ToString();
                    mechanical_price.Text = (dr["price"]).ToString();
                    mechanical_km.Text = (dr["km"]).ToString();
                    mechanical_btn_char = "ED";
                    mechanical_descrip.Focus();
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



        void mechanical_discount_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
               if(string.IsNullOrWhiteSpace(mechanical_discount_amount.Text))
                {
                    mechanical_discount_amount.Text = "0";
                }
                if (mechanical_btn_char == "E")
                {
                    mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                    mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    mechanical_grand_total.Text = (Convert.ToDouble(mechanical_total_amount.Text) - Convert.ToDouble(mechanical_discount_amount.Text)).ToString();
                    mechanical_done_bttn.Visibility = System.Windows.Visibility.Visible;
                }

            }
        }


        void mechanical_bill_details_done_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER" && !string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {
                string l = mechanical_vehicle_num.Text;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    mechanical_vehicle_num.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    if (mechanical_btn_val == 1 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "','" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','LATHE')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'LATHE')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
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
                    else if (mechanical_btn_val == 2 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "','" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','TAILER')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'TAILER')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if(mbr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (mechanical_btn_val == 3 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "','" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','GROWN')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'GROWN')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if (mbr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (mechanical_btn_val == 4 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "','" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','CLEDGE')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'CLEDGE')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if (mbr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (mechanical_btn_val == 5 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "','" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','SPRING')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'SPRING')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if (mbr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (mechanical_btn_val == 6 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,km,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "'," + Convert.ToDouble(mechanical_km.Text) + ",'" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','PUMP-NOSIL')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'PUMP-NOSIL')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0"; mechanical_km.Text = "";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if(mbr == MessageBoxResult.Cancel)  
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (mechanical_btn_val == 7 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,km,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "'," + Convert.ToDouble(mechanical_km.Text) + ",'" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','RADIATOR')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'RADIATOR')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if (mbr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (mechanical_btn_val == 8 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,km,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "'," + Convert.ToDouble(mechanical_km.Text) + ",'" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','GEARBOX')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'GEARBOX')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0"; mechanical_km.Text = "";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if (mbr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (mechanical_btn_val == 9 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,km,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "'," + Convert.ToDouble(mechanical_km.Text) + ",'" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','OIL-SERVICE')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'OIL-SERVICE')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0"; mechanical_km.Text = "";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if (mbr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else if (mechanical_btn_val == 10 & mechanical_btn_char == "N")
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.connection_string();
                            MessageBoxResult mbr = MessageBox.Show("Are you Sure Want to Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mbr == MessageBoxResult.OK)
                            {
                                for (int i = 0; i < Convert.ToInt32(mechanical_S_NO.Text) - 1; i++)
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into mechanical_expense(s_no,bill_no,km,vehicle,description,quantity,quantity_rate,bill_date,expense_type)values(" + Convert.ToInt32(mechanical_snos[i]) + ",'" + mechanical_bill_num.Text + "'," + Convert.ToDouble(mechanical_km.Text) + ",'" + mechanical_vehicle_num.Text + "','" + mechanical_des[i] + "'," + mechanical_qnty[i] + "," + mechanical_qnt_rate[i] + ",'" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','TURBO')", con.str);
                                    cmd.ExecuteNonQuery();
                                }

                                OdbcCommand cmd1 = new OdbcCommand("insert into expense_bill(bill_no,bill_date,vehicle,sub_total,discount,gnd_total,expense_type)values('" + mechanical_bill_num.Text + "','" + Convert.ToDateTime(mechanical_bill_date.Text).ToString("yyyy/MM/dd") + "','" + mechanical_vehicle_num.Text + "'," + mechanical_total_amount.Text + "," + mechanical_discount_amount.Text + "," + mechanical_grand_total.Text + ",'TURBO')", con.str);
                                cmd1.ExecuteNonQuery();
                                mechanical_clear_array();
                                mechanical_datagrid1.ItemsSource = null;
                                mechanical_datagrid1.Items.Refresh();
                                mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_bill_num.IsEnabled = true; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0"; mechanical_km.Text = "";
                                mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
                                mechanical_descrip.Focus();
                            }
                            else if (mbr == MessageBoxResult.Cancel)
                            {

                            }
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


        void mechanical_clear_click(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("delete from lpg_tank", con.str);
            cmd.ExecuteNonQuery();
            con.close_string();
            mechanical_clear_array();
            mechanical_datagrid1.ItemsSource = null;
            mechanical_datagrid1.Items.Refresh();
            mechanical_done_bttn.Visibility = System.Windows.Visibility.Hidden;
            mechanical_clear_bttn.Visibility = System.Windows.Visibility.Hidden;
            mechanical_descrip.Text = ""; mechanical_quantity.Text = "1"; mechanical_rate.Text = "0"; mechanical_price.Text = "0";
            mechanical_vehicle_num.Text = ""; mechanical_bill_date.Text = ""; mechanical_bill_num.Text = ""; mechanical_S_NO.Text = "1"; mechanical_total_amount.Text = "0"; mechanical_discount_amount.Text = "0"; mechanical_grand_total.Text = "0"; mechanical_km.Text = "";
        }

        void mechanical_clear_array()
        {
            Array.Clear(mechanical_des, 0, mechanical_des.Length);
            Array.Clear(mechanical_qnty, 0, mechanical_qnty.Length);
            Array.Clear(mechanical_qnt_rate, 0, mechanical_qnt_rate.Length);
            Array.Clear(mechanical_qnt_price, 0, mechanical_qnt_price.Length);
            Array.Clear(mechanical_snos, 0, mechanical_snos.Length);
            Array.Clear(km, 0, km.Length);

        }


        void mechanical_gridsize()
        {
            mechanical_datagrid1.Columns[0].Width = 72;
            mechanical_datagrid1.Columns[1].Width = 250;
            mechanical_datagrid1.Columns[2].Width = 120;
            mechanical_datagrid1.Columns[3].Width = 120;
            mechanical_datagrid1.Columns[4].Width = 120;

        }
        void mech_gridsize()
        {
            mechanical_datagrid1.Columns[0].Width = 52;
            mechanical_datagrid1.Columns[1].Width = 100;
            mechanical_datagrid1.Columns[2].Width = 230;
            mechanical_datagrid1.Columns[3].Width = 100;
            mechanical_datagrid1.Columns[4].Width = 100;
            mechanical_datagrid1.Columns[5].Width = 100;
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
        void Mech_Rate_Textchanged(object sender, TextChangedEventArgs e)
        {
            int len = 0;
            string s = mechanical_rate.Text;
            if (!string.IsNullOrWhiteSpace(mechanical_rate.Text))
            {
                len = mechanical_rate.Text.Length;
                if (len > 0 && len <= 6)
                {
                    for (int i = 0; i < len; i++)
                    {
                        bool isdigit = char.IsDigit(s[i]);
                        if (isdigit)
                        {

                        }
                        else
                        {
                            //mechanical_rate.Text = mechanical_rate.Text.Substring(0, 4);
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
        void Mech_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(mechanical_vehicle_num.Text))
            {

                len = mechanical_vehicle_num.Text.Length;
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
        void Mech_Bill_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(mechanical_view_bill_number.Text))
            {

                len = mechanical_view_bill_number.Text.Length;
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
            if(dt.Rows.Count>0)
            {
                mechanical_vehicle_num.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mechanical_vehicle_num.Items.Add(dt.Rows[i]["vehicle_number"]);
                }
            }
          
        }
    }
}
