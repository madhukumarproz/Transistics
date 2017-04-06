 using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;
using Microsoft.Reporting.WinForms;
using System.Text.RegularExpressions;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Tyre_Maintenance.xaml
    /// </summary>
    public partial class Tyre_Maintenance : UserControl
    {
        string position = null;
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        string chr = null;
        public Tyre_Maintenance() 
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;                                                        
        }

        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {
                if (chr == "i" )
                {
                    tyre_insert_img1.Visibility = System.Windows.Visibility.Visible;
                    tyre_insert_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
                else if (chr == "u")
                {
                    tyre_update_img1.Visibility = System.Windows.Visibility.Visible;
                    tyre_update_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                } 
            }
            ii++;
        }
        private void tyre_vehicle_number_GotFocus(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            tyre_vehicle_number.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tyre_vehicle_number.Items.Add(dt.Rows[i]["vehicle_number"]);
                }
            }
            con.close_connection();
        }
        void vehicle_tyre_view_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter&&!String.IsNullOrWhiteSpace(tyre_vehicle_number.Text))
            {
                string l = tyre_vehicle_number.Text;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    tyre_vehicle_number.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                   
                    //header.Content = tyre_vehicle_number.Text + "      CURRENT TYRE CHART";
                    Connection CON = new Connection();
                    CON.connection_string();
                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "'",CON.str);
                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        but1.IsEnabled = true; but2.IsEnabled = true; but3.IsEnabled = true; but4.IsEnabled = true; but5.IsEnabled = true; but6.IsEnabled = true;
                        but7.IsEnabled = true; but8.IsEnabled = true; but9.IsEnabled = true; but10.IsEnabled = true; but11.IsEnabled = true; but12.IsEnabled = true;
                        but13.IsEnabled = true; but14.IsEnabled = true; but15.IsEnabled = true; but16.IsEnabled = true; but17.IsEnabled = true; but18.IsEnabled = true;addtional.IsEnabled = true;
                       
                        try
                        {
                            OdbcCommand cmd = new OdbcCommand("select cfl_tyre_no,cfl_km,cclin_tyre_no,cclin_km,cclout_tyre_no,cclout_km,cblin_tyre_no,cblin_km,cblout_tyre_no,cblout_km from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string jk = dt.Rows[0]["cfl_tyre_no"].ToString();
                                string jk1 = dt.Rows[0]["cclin_tyre_no"].ToString();
                                string jk2 = dt.Rows[0]["cclout_tyre_no"].ToString();
                                string jk3 = dt.Rows[0]["cblin_tyre_no"].ToString();
                                string jk4 = dt.Rows[0]["cblout_tyre_no"].ToString();
                                if (jk != "")
                                {
                                    zl1.Content = dt.Rows[0]["cfl_tyre_no"];
                                    zl2.Content = dt.Rows[0]["cfl_km"];
                                }
                                if (jk1 != "")
                                {
                                    zl3.Content = dt.Rows[0]["cclin_tyre_no"];
                                    zl4.Content = dt.Rows[0]["cclin_km"];
                                }
                                if (jk2 != "")
                                {
                                    zl5.Content = dt.Rows[0]["cclout_tyre_no"];
                                    zl6.Content = dt.Rows[0]["cclout_km"];
                                }
                                if (jk3 != "")
                                {
                                    zl7.Content = dt.Rows[0]["cblin_tyre_no"];
                                    zl8.Content = dt.Rows[0]["cblin_km"];
                                }
                                if (jk4 != "")
                                {
                                    zl9.Content = dt.Rows[0]["cblout_tyre_no"];
                                    zl10.Content = dt.Rows[0]["cblout_km"];
                                }
                            }
                            else
                            {
                                zl1.Content = "";
                                zl2.Content = "";
                                zl3.Content = "";
                                zl4.Content = "";
                                zl5.Content = "";
                                zl6.Content = "";
                                zl7.Content = "";
                                zl8.Content = "";
                                zl9.Content = "";
                                zl10.Content = "";
                            }
                        }
                        catch(OdbcException ex)
                        {
                            MessageBox.Show("Error Getting Zeep left Side Tyre Details :"+ex);
                        }
                        try
                        {
                            OdbcCommand cmd = new OdbcCommand("select cfr_tyre_no,cfr_km,ccrin_tyre_no,ccrin_km,ccrout_tyre_no,ccrout_km,cbrin_tyre_no,cbrin_km,cbrout_tyre_no,cbrout_km,add_tyre_no,add_km from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string jk = dt.Rows[0]["cfr_tyre_no"].ToString();
                                string jk1 = dt.Rows[0]["ccrin_tyre_no"].ToString();
                                string jk2 = dt.Rows[0]["ccrout_tyre_no"].ToString();
                                string jk3 = dt.Rows[0]["cbrin_tyre_no"].ToString();
                                string jk4 = dt.Rows[0]["cbrout_tyre_no"].ToString();
                                string jk5 = dt.Rows[0]["add_tyre_no"].ToString();
                                if (jk != "")
                                {
                                    zr1.Content = dt.Rows[0]["cfr_tyre_no"];
                                    zr2.Content = dt.Rows[0]["cfr_km"];
                                }
                                if (jk1 != "")
                                {
                                    zr3.Content = dt.Rows[0]["ccrin_tyre_no"];
                                    zr4.Content = dt.Rows[0]["ccrin_km"];
                                }
                                if (jk2 != "")
                                {
                                    zr5.Content = dt.Rows[0]["ccrout_tyre_no"];
                                    zr6.Content = dt.Rows[0]["ccrout_km"];
                                }
                                if (jk3 != "")
                                {
                                    zr7.Content = dt.Rows[0]["cbrin_tyre_no"];
                                    zr8.Content = dt.Rows[0]["cbrin_km"];
                                }
                                if (jk4 != "")
                                {
                                    zr9.Content = dt.Rows[0]["cbrout_tyre_no"];
                                    zr10.Content = dt.Rows[0]["cbrout_km"];
                                }
                                if (jk5 != "")
                                {
                                    adno.Content = dt.Rows[0]["add_tyre_no"];
                                    adkm.Content = dt.Rows[0]["add_km"];
                                }

                            }
                            else
                            {
                                zr1.Content = "";
                                zr2.Content = "";
                                zr3.Content = "";
                                zr4.Content = "";
                                zr5.Content = "";
                                zr6.Content = "";
                                zr7.Content = "";
                                zr8.Content = "";
                                zr9.Content = "";
                                zr10.Content = "";
                                adno.Content = "";
                                adkm.Content = "";
                            }
                        }
                        catch(OdbcException ex)
                        {
                            MessageBox.Show("Error Getting Zeep Right Side Tyre Details :"+ex);
                        }
                        try
                        {
                            OdbcCommand cmd = new OdbcCommand("select tflin_tyre_no,tflin_km,tflout_tyre_no,tflout_km,tblin_tyre_no,tblin_km,tblout_tyre_no,tblout_km from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string jk = dt.Rows[0]["tflin_tyre_no"].ToString();
                                string jk1 = dt.Rows[0]["tflout_tyre_no"].ToString();
                                string jk2 = dt.Rows[0]["tblin_tyre_no"].ToString();
                                string jk3 = dt.Rows[0]["tblout_tyre_no"].ToString();
                                if (jk != "")
                                {
                                    tl1.Content = dt.Rows[0]["tflin_tyre_no"];
                                    tl2.Content = dt.Rows[0]["tflin_km"];
                                }
                                if (jk1 != "")
                                {
                                    tl3.Content = dt.Rows[0]["tflout_tyre_no"];
                                    tl4.Content = dt.Rows[0]["tflout_km"];
                                }
                                if (jk2 != "")
                                {
                                    tl5.Content = dt.Rows[0]["tblin_tyre_no"];
                                    tl6.Content = dt.Rows[0]["tblin_km"];
                                }
                                if (jk3 != "")
                                {
                                    tl7.Content = dt.Rows[0]["tblout_tyre_no"];
                                    tl8.Content = dt.Rows[0]["tblout_km"];
                                }


                            }
                            else
                            {
                                tl1.Content = "";
                                tl2.Content = "";
                                tl3.Content = "";
                                tl4.Content = "";
                                tl5.Content = "";
                                tl6.Content = "";
                                tl7.Content = "";
                                tl8.Content = "";
                            }
                        }
                        catch(OdbcException ex)
                        {
                            MessageBox.Show("Error Getting Tank Left Side Details :"+ex);
                        }
                        try
                        {
                            OdbcCommand cmd = new OdbcCommand("select tfrin_tyre_no,tfrin_km,tfrout_tyre_no,tfrout_km,tbrin_tyre_no,tbrin_km,tbrout_tyre_no,tbrout_km from tank_right where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string jk = dt.Rows[0]["tfrin_tyre_no"].ToString();
                                string jk1 = dt.Rows[0]["tfrout_tyre_no"].ToString();
                                string jk2 = dt.Rows[0]["tbrin_tyre_no"].ToString();
                                string jk3 = dt.Rows[0]["tbrout_tyre_no"].ToString();
                                if (jk != "")
                                {
                                    tr1.Content = dt.Rows[0]["tfrin_tyre_no"];
                                    tr2.Content = dt.Rows[0]["tfrin_km"];
                                }
                                if (jk1 != "")
                                {
                                    tr3.Content = dt.Rows[0]["tfrout_tyre_no"];
                                    tr4.Content = dt.Rows[0]["tfrout_km"];
                                }
                                if (jk2 != "")
                                {
                                    tr5.Content = dt.Rows[0]["tbrin_tyre_no"];
                                    tr6.Content = dt.Rows[0]["tbrin_km"];
                                }
                                if (jk3 != "")
                                {
                                    tr7.Content = dt.Rows[0]["tbrout_tyre_no"];
                                    tr8.Content = dt.Rows[0]["tbrout_km"];
                                }
                            }
                            else
                            {
                                tr1.Content = "";
                                tr2.Content = "";
                                tr3.Content = "";
                                tr4.Content = "";
                                tr5.Content = "";
                                tr6.Content = "";
                                tr7.Content = "";
                                tr8.Content = "";
                            }
                        }
                        catch(OdbcException ex)
                        {
                            MessageBox.Show("Getting Tank Right Side Details :"+ex);
                        }
                        CON.close_string();
                        tyre_detail_insert.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        tyre_detail_insert.Visibility = System.Windows.Visibility.Visible;
                    }
                    CON.close_string();
                }
                else
                {
                    MessageBox.Show("Incorrect Vehicle Number");
                }

            }
            else
            {
                MessageBox.Show("Select Vehicle Number");
            }
        }


       
        void tank_back_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "tblo";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select tblout_company,DATE_FORMAT(tblout_date,'%d/%m/%y') as date,tblout_type from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = tl7.Content.ToString();
                vehicle_tyre_km.Text = tl8.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["tblout_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["tblout_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;

            }
            con.close_string();
        }
        void tank_back_left_inner_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "tbli";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select tblin_company,DATE_FORMAT(tblin_date,'%d/%m/%y') as date,tblin_type from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = tl5.Content.ToString();
                vehicle_tyre_km.Text = tl6.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["tblin_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["tblin_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }


        void tank_front_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "tflo";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select tflout_company,DATE_FORMAT(tflout_date,'%d/%m/%y') as date,tflout_type from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = tl3.Content.ToString();
                vehicle_tyre_km.Text = tl4.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["tflout_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["tflout_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void tank_front_left_inner_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "tfli";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select tflin_company,DATE_FORMAT(tflin_date,'%d/%m/%y') as date,tflin_type from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = tl1.Content.ToString();
                vehicle_tyre_km.Text = tl2.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["tflin_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["tflin_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_back_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zblo";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select cblout_company,DATE_FORMAT(cblout_date,'%d/%m/%y') as date,cblout_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zl9.Content.ToString();
                vehicle_tyre_km.Text = zl10.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["cblout_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["cblout_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_back_left_inner_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zbli";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select cblin_company,DATE_FORMAT(cblin_date,'%d/%m/%y') as date,cblin_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zl7.Content.ToString();
                vehicle_tyre_km.Text = zl8.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["cblin_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["cblin_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_center_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zclo";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select cclout_company,DATE_FORMAT(cclout_date,'%d/%m/%y') as date,cclout_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zl5.Content.ToString();
                vehicle_tyre_km.Text = zl6.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["cclout_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["cclout_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_center_left_inner_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zcli";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select cclin_company,DATE_FORMAT(cclin_date,'%d/%m/%y') as date,cclin_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zl3.Content.ToString();
                vehicle_tyre_km.Text = zl4.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["cclin_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["cclin_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_front_left_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zfl";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select cfl_company,DATE_FORMAT(cfl_date,'%d/%m/%y') as date,cfl_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zl1.Content.ToString();
                vehicle_tyre_km.Text = zl2.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["cfl_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["cfl_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void tank_back_right_outer_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "tbro";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select tbrout_company,DATE_FORMAT(tbrout_date,'%d/%m/%y') as date,tbrout_type from tank_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = tr7.Content.ToString();
                vehicle_tyre_km.Text = tr8.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["tbrout_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["tbrout_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void tank_back_right_inner_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "tbri";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select tbrin_company,DATE_FORMAT(tbrin_date,'%d/%m/%y') as date,tbrin_type from tank_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = tr5.Content.ToString();
                vehicle_tyre_km.Text = tr6.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["tbrin_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["tbrin_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void tank_front_right_outer_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "tfro";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select tfrout_company,DATE_FORMAT(tfrout_date,'%d/%m/%y') as date,tfrout_type from tank_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = tr3.Content.ToString();
                vehicle_tyre_km.Text = tr4.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["tfrout_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["tfrout_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void tank_front_right_inner_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "tfri";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select tfrin_company,DATE_FORMAT(tfrin_date,'%d/%m/%y') as date,tfrin_type from tank_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = tr1.Content.ToString();
                vehicle_tyre_km.Text = tr2.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["tfrin_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["tfrin_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_back_right_outer_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zbro";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select cbrout_company,DATE_FORMAT(cbrout_date,'%d/%m/%y') as date,cbrout_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zr9.Content.ToString();
                vehicle_tyre_km.Text = zr10.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["cbrout_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["cbrout_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_back_right_inner_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zbri";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select cbrin_company,DATE_FORMAT(cbrin_date,'%d/%m/%y') as date,cbrin_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zr7.Content.ToString();
                vehicle_tyre_km.Text = zr8.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["cbrin_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["cbrin_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_center_right_outer_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zcro";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select ccrout_company,DATE_FORMAT(ccrout_date,'%d/%m/%y') as date,ccrout_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zr5.Content.ToString();
                vehicle_tyre_km.Text = zr6.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["ccrout_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["ccrout_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_center_right_inner_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zcri";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select ccrin_company,DATE_FORMAT(ccrin_date,'%d/%m/%y') as date,ccrin_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zr3.Content.ToString();
                vehicle_tyre_km.Text = zr4.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["ccrin_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["ccrin_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void zeep_front_right(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "zfr";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select cfr_company,DATE_FORMAT(cfr_date,'%d/%m/%y') as date,cfr_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = zr1.Content.ToString();
                vehicle_tyre_km.Text = zr2.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["cfr_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["cfr_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }

        private void stepny_clicked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Tyre_Vehicle_Number = tyre_vehicle_number.Text;
            g.Tyre_No = "";
            g.Start_Km = "";
            g.Tyre_Company = "";
            g.Tyre_Price = "";
            this.DataContext = g;
            position = "add";
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select add_company,DATE_FORMAT(add_date,'%d/%m/%y') as date,add_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vehicle_tyre_number.Text = adno.Content.ToString();
                vehicle_tyre_km.Text = adkm.Content.ToString();
                vehicle_tyre_company.Text = dt.Rows[0]["add_company"].ToString();
                vehicle_tyre_add_date.Text = dt.Rows[0]["date"].ToString();
                string ch = dt.Rows[0]["add_type"].ToString();
                if (ch == "N")
                {
                    new_tyre.IsChecked = true;
                }
                else if (ch == "B")
                {
                    build_tyre.IsChecked = true;
                }
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please Add Tyre Details");
                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
            }
            con.close_string();
        }
        void tyre_details_insert_click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(tyre_vehicle_number.Text))
            {
                try
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Sure, Want to Insert Vehicle Number", "Insert", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.OK)
                    {
                        Connection CON = new Connection();
                        CON.connection_string();
                        OdbcCommand cmd = new OdbcCommand("insert into crown_left(vehicle_number)values('" + tyre_vehicle_number.Text + "')", CON.str);
                        cmd.ExecuteNonQuery();
                        OdbcCommand cmd1 = new OdbcCommand("insert into crown_right(vehicle_number)values('" + tyre_vehicle_number.Text + "')", CON.str);
                        cmd1.ExecuteNonQuery();
                        OdbcCommand cmd2 = new OdbcCommand("insert into tank_left(vehicle_number)values('" + tyre_vehicle_number.Text + "')", CON.str);
                        cmd2.ExecuteNonQuery();
                        OdbcCommand cmd3 = new OdbcCommand("insert into tank_right(vehicle_number)values('" + tyre_vehicle_number.Text + "')", CON.str);
                        cmd3.ExecuteNonQuery();
                        tyre_detail_insert.Visibility = System.Windows.Visibility.Hidden;
                        but1.IsEnabled = true; but2.IsEnabled = true; but3.IsEnabled = true; but4.IsEnabled = true; but5.IsEnabled = true; but6.IsEnabled = true;
                        but7.IsEnabled = true; but8.IsEnabled = true; but9.IsEnabled = true; but10.IsEnabled = true; but11.IsEnabled = true; but12.IsEnabled = true;
                        but13.IsEnabled = true; but14.IsEnabled = true; but15.IsEnabled = true; but16.IsEnabled = true; but17.IsEnabled = true; but18.IsEnabled = true; addtional.IsEnabled = true;
                        time1.Start();
                        chr = "i";
                        tyre_insert_img1.Visibility = System.Windows.Visibility.Hidden;
                        tyre_insert_img2.Visibility = System.Windows.Visibility.Visible;
                        CON.close_string();
                    }
                    else if (mr == MessageBoxResult.Cancel)
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
                MessageBox.Show("Select Vehicle Number");
            }
           

        }


        void tyre_details_update_click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(vehicle_tyre_number.Text) &&!string.IsNullOrWhiteSpace(vehicle_tyre_km.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_add_date.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_company.Text) )
            {
                try
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Want Update the Given Data", "Data update", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.OK)
                    {
                        Connection CON = new Connection();
                        CON.connection_string();

                        if (position == "zfl")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cfl_tyre_no='" + vehicle_tyre_number.Text + "',cfl_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cfl_company='" + vehicle_tyre_company.Text + "',cfl_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cfl_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl1.Content = vehicle_tyre_number.Text;
                                zl2.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;

                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cfl_tyre_no='" + vehicle_tyre_number.Text + "',cfl_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cfl_company='" + vehicle_tyre_company.Text + "',cfl_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cfl_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl1.Content = vehicle_tyre_number.Text;
                                zl2.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }


                        }
                        else if (position == "zcli")
                        {
                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cclin_tyre_no='" + vehicle_tyre_number.Text + "',cclin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cclin_company='" + vehicle_tyre_company.Text + "',cclin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cclin_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl3.Content = vehicle_tyre_number.Text;
                                zl4.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cclin_tyre_no='" + vehicle_tyre_number.Text + "',cclin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cclin_company='" + vehicle_tyre_company.Text + "',cclin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cclin_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl3.Content = vehicle_tyre_number.Text;
                                zl4.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "zclo")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cclout_tyre_no='" + vehicle_tyre_number.Text + "',cclout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cclout_company='" + vehicle_tyre_company.Text + "',cclout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cclout_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl5.Content = vehicle_tyre_number.Text;
                                zl6.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cclout_tyre_no='" + vehicle_tyre_number.Text + "',cclout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cclout_company='" + vehicle_tyre_company.Text + "',cclout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cclout_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl5.Content = vehicle_tyre_number.Text;
                                zl6.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "zbli")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cblin_tyre_no='" + vehicle_tyre_number.Text + "',cblin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cblin_company='" + vehicle_tyre_company.Text + "',cblin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cblin_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl7.Content = vehicle_tyre_number.Text;
                                zl8.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cblin_tyre_no='" + vehicle_tyre_number.Text + "',cblin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cblin_company='" + vehicle_tyre_company.Text + "',cblin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cblin_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl7.Content = vehicle_tyre_number.Text;
                                zl8.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "zblo")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cblout_tyre_no='" + vehicle_tyre_number.Text + "',cblout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cblout_company='" + vehicle_tyre_company.Text + "',cblout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cblout_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl9.Content = vehicle_tyre_number.Text;
                                zl10.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_left set cblout_tyre_no='" + vehicle_tyre_number.Text + "',cblout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cblout_company='" + vehicle_tyre_company.Text + "',cblout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cblout_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl9.Content = vehicle_tyre_number.Text;
                                zl10.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "tfli")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update tank_left set tflin_tyre_no='" + vehicle_tyre_number.Text + "',tflin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tflin_company='" + vehicle_tyre_company.Text + "',tflin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tflin_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl1.Content = vehicle_tyre_number.Text;
                                tl2.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update tank_left set tflin_tyre_no='" + vehicle_tyre_number.Text + "',tflin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tflin_company='" + vehicle_tyre_company.Text + "',tflin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tflin_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl1.Content = vehicle_tyre_number.Text;
                                tl2.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "tflo")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update tank_left set tflout_tyre_no='" + vehicle_tyre_number.Text + "',tflout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tflout_company='" + vehicle_tyre_company.Text + "',tflout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tflout_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl3.Content = vehicle_tyre_number.Text;
                                tl4.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update tank_left set tflout_tyre_no='" + vehicle_tyre_number.Text + "',tflout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tflout_company='" + vehicle_tyre_company.Text + "',tflout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tflout_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl3.Content = vehicle_tyre_number.Text;
                                tl4.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "tbli")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update tank_left set tblin_tyre_no='" + vehicle_tyre_number.Text + "',tblin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tblin_company='" + vehicle_tyre_company.Text + "',tblin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tblin_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl5.Content = vehicle_tyre_number.Text;
                                tl6.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update tank_left set tblin_tyre_no='" + vehicle_tyre_number.Text + "',tblin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tblin_company='" + vehicle_tyre_company.Text + "',tblin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tblin_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl5.Content = vehicle_tyre_number.Text;
                                tl6.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "tblo")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update tank_left set tblout_tyre_no='" + vehicle_tyre_number.Text + "',tblout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tblout_company='" + vehicle_tyre_company.Text + "',tblout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tblout_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl7.Content = vehicle_tyre_number.Text;
                                tl8.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update tank_left set tblout_tyre_no='" + vehicle_tyre_number.Text + "',tblout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tblout_company='" + vehicle_tyre_company.Text + "',tblout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tblout_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl7.Content = vehicle_tyre_number.Text;
                                tl8.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "zfr")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set cfr_tyre_no='" + vehicle_tyre_number.Text + "',cfr_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cfr_company='" + vehicle_tyre_company.Text + "',cfr_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cfr_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr1.Content = vehicle_tyre_number.Text;
                                zr2.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set cfr_tyre_no='" + vehicle_tyre_number.Text + "',cfr_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cfr_company='" + vehicle_tyre_company.Text + "',cfr_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cfr_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr1.Content = vehicle_tyre_number.Text;
                                zr2.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "zcri")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set ccrin_tyre_no='" + vehicle_tyre_number.Text + "',ccrin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",ccrin_company='" + vehicle_tyre_company.Text + "',ccrin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',ccrin_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr3.Content = vehicle_tyre_number.Text;
                                zr4.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set ccrin_tyre_no='" + vehicle_tyre_number.Text + "',ccrin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",ccrin_company='" + vehicle_tyre_company.Text + "',ccrin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',ccrin_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr3.Content = vehicle_tyre_number.Text;
                                zr4.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "zcro")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set ccrout_tyre_no='" + vehicle_tyre_number.Text + "',ccrout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",ccrout_company='" + vehicle_tyre_company.Text + "',ccrout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',ccrout_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr5.Content = vehicle_tyre_number.Text;
                                zr6.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set ccrout_tyre_no='" + vehicle_tyre_number.Text + "',ccrout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",ccrout_company='" + vehicle_tyre_company.Text + "',ccrout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',ccrout_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr5.Content = vehicle_tyre_number.Text;
                                zr6.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "zbri")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set cbrin_tyre_no='" + vehicle_tyre_number.Text + "',cbrin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cbrin_company='" + vehicle_tyre_company.Text + "',cbrin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cbrin_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr7.Content = vehicle_tyre_number.Text;
                                zr8.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set cbrin_tyre_no='" + vehicle_tyre_number.Text + "',cbrin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cbrin_company='" + vehicle_tyre_company.Text + "',cbrin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cbrin_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr7.Content = vehicle_tyre_number.Text;
                                zr8.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "zbro")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set cbrout_tyre_no='" + vehicle_tyre_number.Text + "',cbrout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cbrout_company='" + vehicle_tyre_company.Text + "',cbrout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cbrout_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr9.Content = vehicle_tyre_number.Text;
                                zr10.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set cbrout_tyre_no='" + vehicle_tyre_number.Text + "',cbrout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",cbrout_company='" + vehicle_tyre_company.Text + "',cbrout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',cbrout_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr9.Content = vehicle_tyre_number.Text;
                                zr10.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "tfri")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update tank_right set tfrin_tyre_no='" + vehicle_tyre_number.Text + "',tfrin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tfrin_company='" + vehicle_tyre_company.Text + "',tfrin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tfrin_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr1.Content = vehicle_tyre_number.Text;
                                tr2.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update tank_right set tfrin_tyre_no='" + vehicle_tyre_number.Text + "',tfrin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tfrin_company='" + vehicle_tyre_company.Text + "',tfrin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tfrin_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr1.Content = vehicle_tyre_number.Text;
                                tr2.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "tfro")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update tank_right set tfrout_tyre_no='" + vehicle_tyre_number.Text + "',tfrout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tfrout_company='" + vehicle_tyre_company.Text + "',tfrout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tfrout_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr3.Content = vehicle_tyre_number.Text;
                                tr4.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update tank_right set tfrout_tyre_no='" + vehicle_tyre_number.Text + "',tfrout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tfrout_company='" + vehicle_tyre_company.Text + "',tfrout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tfrout_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr3.Content = vehicle_tyre_number.Text;
                                tr4.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "tbri")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update tank_right set tbrin_tyre_no='" + vehicle_tyre_number.Text + "',tbrin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tbrin_company='" + vehicle_tyre_company.Text + "',tbrin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tbrin_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr5.Content = vehicle_tyre_number.Text;
                                tr6.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update tank_right set tbrin_tyre_no='" + vehicle_tyre_number.Text + "',tbrin_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tbrin_company='" + vehicle_tyre_company.Text + "',tbrin_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tbrin_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr5.Content = vehicle_tyre_number.Text;
                                tr6.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "tbro")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update tank_right set tbrout_tyre_no='" + vehicle_tyre_number.Text + "',tbrout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tbrout_company='" + vehicle_tyre_company.Text + "',tbrout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tbrout_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr7.Content = vehicle_tyre_number.Text;
                                tr8.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update tank_right set tbrout_tyre_no='" + vehicle_tyre_number.Text + "',tbrout_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",tbrout_company='" + vehicle_tyre_company.Text + "',tbrout_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',tbrout_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr7.Content = vehicle_tyre_number.Text;
                                tr8.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                        else if (position == "add")
                        {

                            if (new_tyre.IsChecked == true)
                            {
                                New_Tyre_Price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set add_tyre_no='" + vehicle_tyre_number.Text + "',add_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",add_company='" + vehicle_tyre_company.Text + "',add_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',add_type='N' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                adno.Content = vehicle_tyre_number.Text;
                                adkm.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (build_tyre.IsChecked == true)
                            {
                                Build_Tyre_price();
                                OdbcCommand cmd = new OdbcCommand("update crown_right set add_tyre_no='" + vehicle_tyre_number.Text + "',add_km=" + Convert.ToDouble(vehicle_tyre_km.Text) + ",add_company='" + vehicle_tyre_company.Text + "',add_date='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "',add_type='B' where vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                adno.Content = vehicle_tyre_number.Text;
                                adkm.Content = vehicle_tyre_km.Text;
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = ""; tyre_price.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                update_image();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else
                            {
                                MessageBox.Show("Please Select Tyre Type");
                            }

                        }
                    }
                    else if (mr == MessageBoxResult.Cancel)
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
                MessageBox.Show("Please Fill Empty Text Field");
            }
            
        }

        void tyre_details_back_clicked(object sender, RoutedEventArgs e)
        {
            tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
            new_tyre.IsChecked = false; build_tyre.IsChecked = false;
            vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
            vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
            //tyre_detail_insert.IsEnabled = true;
            //tyre_details_update.IsEnabled = true;
        }
        void update_image()
        {
            time1.Start();
            chr = "u";
            tyre_update_img1.Visibility = System.Windows.Visibility.Hidden;
            tyre_update_img2.Visibility = System.Windows.Visibility.Visible;
        }


        void tyre_details_delete_clicked(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN"&&!string.IsNullOrWhiteSpace(tyre_vehicle_number.Text) &&!string.IsNullOrWhiteSpace(vehicle_tyre_number.Text)) 
            {
                string l = tyre_vehicle_number.Text;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    tyre_vehicle_number.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    try
                    {
                        MessageBoxResult mr = MessageBox.Show("Are You Sure Want Delete the Data", "Data delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (mr == MessageBoxResult.OK)
                        {
                            Connection CON = new Connection();
                            CON.connection_string();
                            if (position == "zfl")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete  cfl_tyre_no,cfl_km,cfl_company,cfl_date,cfl_type from  crown_left where vehicle_number='" + tyre_vehicle_number.Text + "' and cfl_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl1.Content = "";
                                zl2.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zcli")
                            {
                                OdbcCommand cmd = new OdbcCommand("Delete  cclin_tyre_no,cclin_km,cclin_company,cclin_date,cclin_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "' and cclin_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl3.Content = "";
                                zl4.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zclo")
                            {
                                OdbcCommand cmd = new OdbcCommand("Delete  cclout_tyre_no,cclout_km,cclout_company,cclout_date,cclout_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "' and cclout_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl5.Content = "";
                                zl6.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zbli")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete cblin_tyre_no,cblin_km,cblin_company,cblin_date,cblin_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "' and cblin_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl7.Content = "";
                                zl8.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zblo")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete cblout_tyre_no,cblout_km,cblout_company,cblout_date,cblout_type from crown_left where vehicle_number='" + tyre_vehicle_number.Text + "' and cblout_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zl9.Content = "";
                                zl10.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "tfli")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete  tflin_tyre_no,tflin_km,tflin_company,tflin_date,tflin_type from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "' and tflin_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl1.Content = "";
                                tl2.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "tflo")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete tflout_tyre_no,tflout_km,tflout_company,tflout_date,tflout_type from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "' and tflout_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl3.Content = "";
                                tl4.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "tbli")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete tblin_tyre_no,tblin_km,tblin_company,tblin_date,tblin_type from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "' and tblin_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl5.Content = "";
                                tl6.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "tblo")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete tblout_tyre_no,tblout_km,tblout_company,tblout_date,tblout_type from tank_left where vehicle_number='" + tyre_vehicle_number.Text + "' and tblout_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tl7.Content = "";
                                tl8.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zfr")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete cfr_tyre_no,cfr_km,cfr_company,cfr_date,cfr_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "' and cfr_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr1.Content = "";
                                zr2.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zcri")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete ccrin_tyre_no,ccrin_km,ccrin_company,ccrin_date,ccrin_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "' ccrin_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr3.Content = "";
                                zr4.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zcro")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete ccrout_tyre_no,ccrout_km,ccrout_company,ccrout_date,ccrout_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "' and ccrout_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr5.Content = "";
                                zr6.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zbri")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete cbrin_tyre_no,cbrin_km,cbrin_company,cbrin_date,cbrin_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "' and cbrin_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr7.Content = "";
                                zr8.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "zbro")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete cbrout_tyre_no,cbrout_km,cbrout_company,cbrout_date,cbrout_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "' and cbrout_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                zr9.Content = "";
                                zr10.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "tfri")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete tfrin_tyre_no,tfrin_km,tfrin_company,tfrin_date,tfrin_type from tank_right where vehicle_number='" + tyre_vehicle_number.Text + "' and tfrin_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr1.Content = "";
                                tr2.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "tfro")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete tfrout_tyre_no,tfrout_km,tfrout_company,tfrout_date,tfrout_type from tank_right where vehicle_number='" + tyre_vehicle_number.Text + "' and tfrout_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr3.Content = "";
                                tr4.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "tbri")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete tbrin_tyre_no,tbrin_km,tbrin_company,tbrin_date,tbrin_type from tank_right  where vehicle_number='" + tyre_vehicle_number.Text + "' and tbrin_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr5.Content = "";
                                tr6.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "tbro")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete  tbrout_tyre_no,tbrout_km,tbrout_company,tbrout_date,tbrout_type from tank_right where vehicle_number='" + tyre_vehicle_number.Text + "' and tbrout_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                tr7.Content = "";
                                tr8.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                            else if (position == "add")
                            {
                                OdbcCommand cmd = new OdbcCommand("delete  add_tyre_no,add_km,add_company,add_date,add_type from crown_right where vehicle_number='" + tyre_vehicle_number.Text + "' and add_tyre_no='" + vehicle_tyre_number.Text + "'", CON.str);
                                cmd.ExecuteNonQuery();
                                adno.Content = "";
                                adkm.Content = "";
                                new_tyre.IsChecked = false; build_tyre.IsChecked = false;
                                vehicle_tyre_number.Text = ""; vehicle_tyre_km.Text = "";
                                vehicle_tyre_company.Text = ""; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
                                tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                            }
                        }
                        else if (mr == MessageBoxResult.Cancel)
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
                    MessageBox.Show("Vehicle Number Invalid Format");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }


        void tyre_print_panel_open(object sender, RoutedEventArgs e)
        {           
            tyre_print_panel.Visibility = Visibility.Visible;   
            if(!string.IsNullOrWhiteSpace( tyre_vehicle_number.Text))
            {
                print_data();
            }   
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }  
                    
        }

        void Tyre_Report_Back_Click(object sender, RoutedEventArgs e)
        {
            tyre_print_panel.Visibility = Visibility.Hidden;
            Report_Viewer.Clear();
        }
        void print_data()
        {
            ReportParameter[] param = new ReportParameter[98];
            try
            {
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("SELECT * FROM crown_left JOIN crown_right ON crown_left.VEHICLE_NUMBER=crown_right.VEHICLE_NUMBER WHERE crown_left.VEHICLE_NUMBER='"+ tyre_vehicle_number.Text + "' ", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            MainWindow m = new MainWindow();
            //Report_Viewer.Clear();
            Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Tyre_Details_Report.rdlc";           
            param[0] = new ReportParameter("Title_Param",m.Title_Name.Content.ToString());
            param[1] = new ReportParameter("Vehicle_Number_Param", (tyre_vehicle_number.Text).ToString());
            param[2] = new ReportParameter("Date_Param",Convert.ToDateTime( DateTime.Now).ToString("dd/MM/yyyy"));
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string r1, r2, r3, r4, r5;
                r1 = dt.Rows[0]["cfl_type"].ToString();
                if (r1 == "N")
                {
                    param[3] = new ReportParameter("Left_Param1","NEW");
                    param[4] = new ReportParameter("Left_Param2", dt.Rows[0]["cfl_tyre_no"].ToString());
                    param[5] = new ReportParameter("Left_Param3", dt.Rows[0]["cfl_km"].ToString());
                    param[6] = new ReportParameter("Left_Param4", dt.Rows[0]["cfl_company"].ToString());
                    param[7] = new ReportParameter("Left_Param5", Convert.ToDateTime(dt.Rows[0]["cfl_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r1 == "B")
                {
                    param[3] = new ReportParameter("Left_Param1", "RE-BUILD");
                    param[4] = new ReportParameter("Left_Param2", dt.Rows[0]["cfl_tyre_no"].ToString());
                    param[5] = new ReportParameter("Left_Param3", dt.Rows[0]["cfl_km"].ToString());
                    param[6] = new ReportParameter("Left_Param4", dt.Rows[0]["cfl_company"].ToString());
                    param[7] = new ReportParameter("Left_Param5", Convert.ToDateTime(dt.Rows[0]["cfl_date"]).ToString("dd/MM/yyyy"));
                }
                else 
                {
                    param[3] = new ReportParameter("Left_Param1", "Nil");
                    param[4] = new ReportParameter("Left_Param2", "Nil");
                    param[5] = new ReportParameter("Left_Param3", "Nil");
                    param[6] = new ReportParameter("Left_Param4", "Nil");
                    param[7] = new ReportParameter("Left_Param5", "Nil");
                }
                r2 = dt.Rows[0]["cclin_type"].ToString();
                if (r2 == "N")
                {
                    param[8] = new ReportParameter("Left_Param11", "NEW");
                    param[9] = new ReportParameter("Left_Param12", dt.Rows[0]["cclin_tyre_no"].ToString());
                    param[10] = new ReportParameter("Left_Param13", dt.Rows[0]["cclin_km"].ToString());
                    param[11] = new ReportParameter("Left_Param14", dt.Rows[0]["cclin_company"].ToString());
                    param[12] = new ReportParameter("Left_Param15", Convert.ToDateTime(dt.Rows[0]["cclin_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r2 == "B")
                {
                    param[8] = new ReportParameter("Left_Param11", "RE-BUILD");
                    param[9] = new ReportParameter("Left_Param12", dt.Rows[0]["cclin_tyre_no"].ToString());
                    param[10] = new ReportParameter("Left_Param13", dt.Rows[0]["cclin_km"].ToString());
                    param[11] = new ReportParameter("Left_Param14", dt.Rows[0]["cclin_company"].ToString());
                    param[12] = new ReportParameter("Left_Param15", Convert.ToDateTime(dt.Rows[0]["cclin_date"]).ToString("dd/MM/yyyy"));
                }
                else 
                {
                    param[8] = new ReportParameter("Left_Param11", "Nil");
                    param[9] = new ReportParameter("Left_Param12", "Nil");
                    param[10] = new ReportParameter("Left_Param13", "Nil");
                    param[11] = new ReportParameter("Left_Param14", "Nil");
                    param[12] = new ReportParameter("Left_Param15", "Nil");
                }
                r3 = dt.Rows[0]["cclout_type"].ToString();
                if (r3 == "N")
                {
                    param[13] = new ReportParameter("Left_Param6", "NEW");
                    param[14] = new ReportParameter("Left_Param7", dt.Rows[0]["cclout_tyre_no"].ToString());
                    param[15] = new ReportParameter("Left_Param8", dt.Rows[0]["cclout_km"].ToString());
                    param[16] = new ReportParameter("Left_Param9", dt.Rows[0]["cclout_company"].ToString());
                    param[17] = new ReportParameter("Left_Param10", Convert.ToDateTime(dt.Rows[0]["cclout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r3 == "B")
                {
                    param[13] = new ReportParameter("Left_Param6", "RE-Build");
                    param[14] = new ReportParameter("Left_Param7", dt.Rows[0]["cclout_tyre_no"].ToString());
                    param[15] = new ReportParameter("Left_Param8", dt.Rows[0]["cclout_km"].ToString());
                    param[16] = new ReportParameter("Left_Param9", dt.Rows[0]["cclout_company"].ToString());
                    param[17] = new ReportParameter("Left_Param10", Convert.ToDateTime(dt.Rows[0]["cclout_date"]).ToString("dd/MM/yyyy"));
                }
                else 
                {
                    param[13] = new ReportParameter("Left_Param6", "Nil");
                    param[14] = new ReportParameter("Left_Param7", "Nil");
                    param[15] = new ReportParameter("Left_Param8", "Nil");
                    param[16] = new ReportParameter("Left_Param9", "Nil");
                    param[17] = new ReportParameter("Left_Param10", "Nil");
                }
                r4 = dt.Rows[0]["cblin_type"].ToString();
                if (r4 == "N")
                {
                    param[18] = new ReportParameter("Left_Param21", "NEW");
                    param[19] = new ReportParameter("Left_Param22", dt.Rows[0]["cblin_tyre_no"].ToString());
                    param[20] = new ReportParameter("Left_Param23", dt.Rows[0]["cblin_km"].ToString());
                    param[21] = new ReportParameter("Left_Param24", dt.Rows[0]["cblin_company"].ToString());
                    param[22] = new ReportParameter("Left_Param25", Convert.ToDateTime(dt.Rows[0]["cblin_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r4 == "B")
                {
                    param[18] = new ReportParameter("Left_Param21", "RE-BUILD");
                    param[19] = new ReportParameter("Left_Param22", dt.Rows[0]["cblin_tyre_no"].ToString());
                    param[20] = new ReportParameter("Left_Param23", dt.Rows[0]["cblin_km"].ToString());
                    param[21] = new ReportParameter("Left_Param24", dt.Rows[0]["cblin_company"].ToString());
                    param[22] = new ReportParameter("Left_Param25", Convert.ToDateTime(dt.Rows[0]["cblin_date"]).ToString("dd/MM/yyyy"));
                }
                else 
                {
                    param[18] = new ReportParameter("Left_Param21", "Nil");
                    param[19] = new ReportParameter("Left_Param22", "Nil");
                    param[20] = new ReportParameter("Left_Param23", "Nil");
                    param[21] = new ReportParameter("Left_Param24", "Nil");
                    param[22] = new ReportParameter("Left_Param25", "Nil");
                }
                r5 = dt.Rows[0]["cblout_type"].ToString();
                if (r5 == "N")
                {
                    param[23] = new ReportParameter("Left_Param16", "NEW");
                    param[24] = new ReportParameter("Left_Param17", dt.Rows[0]["cblout_tyre_no"].ToString());
                    param[25] = new ReportParameter("Left_Param18", dt.Rows[0]["cblout_km"].ToString());
                    param[26] = new ReportParameter("Left_Param19", dt.Rows[0]["cblout_company"].ToString());
                    param[27] = new ReportParameter("Left_Param20", Convert.ToDateTime(dt.Rows[0]["cblout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r5 == "B")
                {
                    param[23] = new ReportParameter("Left_Param16", "RE-BUILD");
                    param[24] = new ReportParameter("Left_Param17", dt.Rows[0]["cblout_tyre_no"].ToString());
                    param[25] = new ReportParameter("Left_Param18", dt.Rows[0]["cblout_km"].ToString());
                    param[26] = new ReportParameter("Left_Param19", dt.Rows[0]["cblout_company"].ToString());
                    param[27] = new ReportParameter("Left_Param20", Convert.ToDateTime(dt.Rows[0]["cblout_date"]).ToString("dd/MM/yyyy"));
                }
                else 
                {
                    param[23] = new ReportParameter("Left_Param16", "Nil");
                    param[24] = new ReportParameter("Left_Param17", "Nil");
                    param[25] = new ReportParameter("Left_Param18", "Nil");
                    param[26] = new ReportParameter("Left_Param19", "Nil");
                    param[27] = new ReportParameter("Left_Param20", "Nil");
                }
                string r6, r7, r8, r9, r10;
                r6 = dt.Rows[0]["cfr_type"].ToString();
                if (r6 == "N")
                {
                    param[28] = new ReportParameter("Right_Param1", "NEW");
                    param[29] = new ReportParameter("Right_Param2", dt.Rows[0]["cfr_tyre_no"].ToString());
                    param[30] = new ReportParameter("Right_Param3", dt.Rows[0]["cfr_km"].ToString());
                    param[31] = new ReportParameter("Right_Param4", dt.Rows[0]["cfr_company"].ToString());
                    param[32] = new ReportParameter("Right_Param5", Convert.ToDateTime(dt.Rows[0]["cfr_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r6 == "B")
                {
                    param[28] = new ReportParameter("Right_Param1", "RE-BUILD");
                    param[29] = new ReportParameter("Right_Param2", dt.Rows[0]["cfr_tyre_no"].ToString());
                    param[30] = new ReportParameter("Right_Param3", dt.Rows[0]["cfr_km"].ToString());
                    param[31] = new ReportParameter("Right_Param4", dt.Rows[0]["cfr_company"].ToString());
                    param[32] = new ReportParameter("Right_Param5", Convert.ToDateTime(dt.Rows[0]["cfr_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[28] = new ReportParameter("Right_Param1", "Nil");
                    param[29] = new ReportParameter("Right_Param2", "Nil");
                    param[30] = new ReportParameter("Right_Param3", "Nil");
                    param[31] = new ReportParameter("Right_Param4", "Nil");
                    param[32] = new ReportParameter("Right_Param5", "Nil");
                }
                r7 = dt.Rows[0]["ccrin_type"].ToString();
                if (r7 == "N")
                {
                    param[33] = new ReportParameter("Right_Param6", "NEW");
                    param[34] = new ReportParameter("Right_Param7", dt.Rows[0]["ccrin_tyre_no"].ToString());
                    param[35] = new ReportParameter("Right_Param8", dt.Rows[0]["ccrin_km"].ToString());
                    param[36] = new ReportParameter("Right_Param9", dt.Rows[0]["ccrin_company"].ToString());
                    param[37] = new ReportParameter("Right_Param10", Convert.ToDateTime(dt.Rows[0]["ccrin_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r7 == "B")
                {
                    param[33] = new ReportParameter("Right_Param6", "RE-BUILD");
                    param[34] = new ReportParameter("Right_Param7", dt.Rows[0]["ccrin_tyre_no"].ToString());
                    param[35] = new ReportParameter("Right_Param8", dt.Rows[0]["ccrin_km"].ToString());
                    param[36] = new ReportParameter("Right_Param9", dt.Rows[0]["ccrin_company"].ToString());
                    param[37] = new ReportParameter("Right_Param10", Convert.ToDateTime(dt.Rows[0]["ccrin_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[33] = new ReportParameter("Right_Param6", "Nil");
                    param[34] = new ReportParameter("Right_Param7", "Nil");
                    param[35] = new ReportParameter("Right_Param8", "Nil");
                    param[36] = new ReportParameter("Right_Param9", "Nil");
                    param[37] = new ReportParameter("Right_Param10", "Nil");
                }
                r8 = dt.Rows[0]["ccrout_type"].ToString();
                if (r8 == "N")
                {
                    param[38] = new ReportParameter("Right_Param11", "NEW");
                    param[39] = new ReportParameter("Right_Param12", dt.Rows[0]["ccrout_tyre_no"].ToString());
                    param[40] = new ReportParameter("Right_Param13", dt.Rows[0]["ccrout_km"].ToString());
                    param[41] = new ReportParameter("Right_Param14", dt.Rows[0]["ccrout_company"].ToString());
                    param[42] = new ReportParameter("Right_Param15", Convert.ToDateTime(dt.Rows[0]["ccrout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r8 == "B")
                {
                    param[38] = new ReportParameter("Right_Param11", "RE-BUILD");
                    param[39] = new ReportParameter("Right_Param12", dt.Rows[0]["ccrout_tyre_no"].ToString());
                    param[40] = new ReportParameter("Right_Param13", dt.Rows[0]["ccrout_km"].ToString());
                    param[41] = new ReportParameter("Right_Param14", dt.Rows[0]["ccrout_company"].ToString());
                    param[42] = new ReportParameter("Right_Param15", Convert.ToDateTime(dt.Rows[0]["ccrout_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[38] = new ReportParameter("Right_Param11", "Nil");
                    param[39] = new ReportParameter("Right_Param12", "Nil");
                    param[40] = new ReportParameter("Right_Param13", "Nil");
                    param[41] = new ReportParameter("Right_Param14", "Nil");
                    param[42] = new ReportParameter("Right_Param15", "Nil");
                }
                r9 = dt.Rows[0]["cbrin_type"].ToString();
                if (r9 == "N")
                {
                    param[43] = new ReportParameter("Right_Param16", "NEW");
                    param[44] = new ReportParameter("Right_Param17", dt.Rows[0]["cbrin_tyre_no"].ToString());
                    param[45] = new ReportParameter("Right_Param18", dt.Rows[0]["cbrin_km"].ToString());
                    param[46] = new ReportParameter("Right_Param19", dt.Rows[0]["cbrin_company"].ToString());
                    param[47] = new ReportParameter("Right_Param20", Convert.ToDateTime(dt.Rows[0]["cbrin_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r9 == "B")
                {
                    param[43] = new ReportParameter("Right_Param16", "RE-BUILD");
                    param[44] = new ReportParameter("Right_Param17", dt.Rows[0]["cbrin_tyre_no"].ToString());
                    param[45] = new ReportParameter("Right_Param18", dt.Rows[0]["cbrin_km"].ToString());
                    param[46] = new ReportParameter("Right_Param19", dt.Rows[0]["cbrin_company"].ToString());
                    param[47] = new ReportParameter("Right_Param20", Convert.ToDateTime(dt.Rows[0]["cbrin_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[43] = new ReportParameter("Right_Param16", "Nil");
                    param[44] = new ReportParameter("Right_Param17", "Nil");
                    param[45] = new ReportParameter("Right_Param18", "Nil");
                    param[46] = new ReportParameter("Right_Param19", "Nil");
                    param[47] = new ReportParameter("Right_Param20", "Nil");
                }
                r10 = dt.Rows[0]["cbrout_type"].ToString();
                if (r10 == "N")
                {
                    param[48] = new ReportParameter("Right_Param21", "NEW");
                    param[49] = new ReportParameter("Right_Param22", dt.Rows[0]["cbrout_tyre_no"].ToString());
                    param[50] = new ReportParameter("Right_Param23", dt.Rows[0]["cbrout_km"].ToString());
                    param[51] = new ReportParameter("Right_Param24", dt.Rows[0]["cbrout_company"].ToString());
                    param[52] = new ReportParameter("Right_Param25", Convert.ToDateTime(dt.Rows[0]["cbrout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r10 == "B")
                {
                    param[48] = new ReportParameter("Right_Param21", "RE-BUILD");
                    param[49] = new ReportParameter("Right_Param22", dt.Rows[0]["cbrout_tyre_no"].ToString());
                    param[50] = new ReportParameter("Right_Param23", dt.Rows[0]["cbrout_km"].ToString());
                    param[51] = new ReportParameter("Right_Param24", dt.Rows[0]["cbrout_company"].ToString());
                    param[52] = new ReportParameter("Right_Param25", Convert.ToDateTime(dt.Rows[0]["cbrout_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[48] = new ReportParameter("Right_Param21", "Nil");
                    param[49] = new ReportParameter("Right_Param22", "Nil");
                    param[50] = new ReportParameter("Right_Param23", "Nil");
                    param[51] = new ReportParameter("Right_Param24", "Nil");
                    param[52] = new ReportParameter("Right_Param25", "Nil");
                }
                string r11= dt.Rows[0]["add_type"].ToString();
                    if (r11 == "N")
                    {
                        param[93] = new ReportParameter("Add_type", "NEW");
                        param[94] = new ReportParameter("Add_tyre_no", dt.Rows[0]["add_tyre_no"].ToString());
                        param[95] = new ReportParameter("Add_km", dt.Rows[0]["add_km"].ToString());
                        param[96] = new ReportParameter("Add_company", dt.Rows[0]["add_company"].ToString());
                        param[97] = new ReportParameter("Add_date", Convert.ToDateTime(dt.Rows[0]["add_date"]).ToString("dd/MM/yyyy"));
                    }
                    else if (r11 == "B")
                    {
                        param[93] = new ReportParameter("Add_type", "RE-BUILD");
                        param[94] = new ReportParameter("Add_tyre_no", dt.Rows[0]["add_tyre_no"].ToString());
                        param[95] = new ReportParameter("Add_km", dt.Rows[0]["add_km"].ToString());
                        param[96] = new ReportParameter("Add_company", dt.Rows[0]["add_company"].ToString());
                        param[97] = new ReportParameter("Add_date", Convert.ToDateTime(dt.Rows[0]["add_date"]).ToString("dd/MM/yyyy"));
                    }
                    else
                    {
                        param[93] = new ReportParameter("Add_type", "Nil");
                        param[94] = new ReportParameter("Add_tyre_no", "Nil");
                        param[95] = new ReportParameter("Add_km", "Nil");
                        param[96] = new ReportParameter("Add_company", "Nil");
                        param[97] = new ReportParameter("Add_date", "Nil");
                    }
                    con.close_string();
            }
            else
            {
                //MessageBox.Show("Record Doesnot Exist");
                param[3] = new ReportParameter("Left_Param1", "Nil");
                param[4] = new ReportParameter("Left_Param2", "Nil");
                param[5] = new ReportParameter("Left_Param3", "Nil");
                param[6] = new ReportParameter("Left_Param4", "Nil");
                param[7] = new ReportParameter("Left_Param5", "Nil");
                param[8] = new ReportParameter("Left_Param11", "Nil");
                param[9] = new ReportParameter("Left_Param12", "Nil");
                param[10] = new ReportParameter("Left_Param13", "Nil");
                param[11] = new ReportParameter("Left_Param14", "Nil");
                param[12] = new ReportParameter("Left_Param15", "Nil");
                param[13] = new ReportParameter("Left_Param6", "Nil");
                param[14] = new ReportParameter("Left_Param7", "Nil");
                param[15] = new ReportParameter("Left_Param8", "Nil");
                param[16] = new ReportParameter("Left_Param9", "Nil");
                param[17] = new ReportParameter("Left_Param10", "Nil");
                param[18] = new ReportParameter("Left_Param21", "Nil");
                param[19] = new ReportParameter("Left_Param22", "Nil");
                param[20] = new ReportParameter("Left_Param23", "Nil");
                param[21] = new ReportParameter("Left_Param24", "Nil");
                param[22] = new ReportParameter("Left_Param25", "Nil");
                param[23] = new ReportParameter("Left_Param16", "Nil");
                param[24] = new ReportParameter("Left_Param17", "Nil");
                param[25] = new ReportParameter("Left_Param18", "Nil");
                param[26] = new ReportParameter("Left_Param19", "Nil");
                param[27] = new ReportParameter("Left_Param20", "Nil");
                param[28] = new ReportParameter("Right_Param1", "Nil");
                param[29] = new ReportParameter("Right_Param2", "Nil");
                param[30] = new ReportParameter("Right_Param3", "Nil");
                param[31] = new ReportParameter("Right_Param4", "Nil");
                param[32] = new ReportParameter("Right_Param5", "Nil");
                param[33] = new ReportParameter("Right_Param6", "Nil");
                param[34] = new ReportParameter("Right_Param7", "Nil");
                param[35] = new ReportParameter("Right_Param8", "Nil");
                param[36] = new ReportParameter("Right_Param9", "Nil");
                param[37] = new ReportParameter("Right_Param10", "Nil");
                param[38] = new ReportParameter("Right_Param11", "Nil");
                param[39] = new ReportParameter("Right_Param12", "Nil");
                param[40] = new ReportParameter("Right_Param13", "Nil");
                param[41] = new ReportParameter("Right_Param14", "Nil");
                param[42] = new ReportParameter("Right_Param15", "Nil");
                param[43] = new ReportParameter("Right_Param16", "Nil");
                param[44] = new ReportParameter("Right_Param17", "Nil");
                param[45] = new ReportParameter("Right_Param18", "Nil");
                param[46] = new ReportParameter("Right_Param19", "Nil");
                param[47] = new ReportParameter("Right_Param20", "Nil");
                param[48] = new ReportParameter("Right_Param21", "Nil");
                param[49] = new ReportParameter("Right_Param22", "Nil");
                param[50] = new ReportParameter("Right_Param23", "Nil");
                param[51] = new ReportParameter("Right_Param24", "Nil");
                param[52] = new ReportParameter("Right_Param25", "Nil");
                param[93] = new ReportParameter("Add_type", "Nil");
                param[94] = new ReportParameter("Add_tyre_no", "Nil");
                param[95] = new ReportParameter("Add_km", "Nil");
                param[96] = new ReportParameter("Add_company", "Nil");
                param[97] = new ReportParameter("Add_date", "Nil");
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }

            try
            {
                Connection con3 = new Connection();
            con3.connection_string();
            OdbcCommand cmd2 = new OdbcCommand("select * from tank_left join tank_right on tank_left.vehicle_number=tank_right.vehicle_number where tank_left.vehicle_number='" + tyre_vehicle_number.Text + "' ", con3.str);
            OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                string r1, r2, r3, r4;
                r1 = dt2.Rows[0]["tflin_type"].ToString();
                if (r1 == "N")
                {
                    param[53] = new ReportParameter("Left_Param31", "NEW");
                    param[54] = new ReportParameter("Left_Param32", dt2.Rows[0]["tflin_tyre_no"].ToString());
                    param[55] = new ReportParameter("Left_Param33", dt2.Rows[0]["tflin_km"].ToString());
                    param[56] = new ReportParameter("Left_Param34", dt2.Rows[0]["tflin_company"].ToString());
                    param[57] = new ReportParameter("Left_Param35", Convert.ToDateTime(dt2.Rows[0]["tflin_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r1 == "B")
                {
                    param[53] = new ReportParameter("Left_Param31", "RE-BUILD");
                    param[54] = new ReportParameter("Left_Param32", dt2.Rows[0]["tflin_tyre_no"].ToString());
                    param[55] = new ReportParameter("Left_Param33", dt2.Rows[0]["tflin_km"].ToString());
                    param[56] = new ReportParameter("Left_Param34", dt2.Rows[0]["tflin_company"].ToString());
                    param[57] = new ReportParameter("Left_Param35", Convert.ToDateTime(dt2.Rows[0]["tflin_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[53] = new ReportParameter("Left_Param31", "Nil");
                    param[54] = new ReportParameter("Left_Param32", "Nil");
                    param[55] = new ReportParameter("Left_Param33", "Nil");
                    param[56] = new ReportParameter("Left_Param34", "Nil");
                    param[57] = new ReportParameter("Left_Param35", "Nil");
                }
                r2 = dt2.Rows[0]["tflout_type"].ToString();
                if (r2 == "N")
                {
                    param[58] = new ReportParameter("Left_Param26", "NEW");
                    param[59] = new ReportParameter("Left_Param27", dt2.Rows[0]["tflout_tyre_no"].ToString());
                    param[60] = new ReportParameter("Left_Param28", dt2.Rows[0]["tflout_km"].ToString());
                    param[61] = new ReportParameter("Left_Param29", dt2.Rows[0]["tflout_company"].ToString());
                    param[62] = new ReportParameter("Left_Param30", Convert.ToDateTime(dt2.Rows[0]["tflout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r2 == "B")
                {
                    param[58] = new ReportParameter("Left_Param26", "RE-BUILD");
                    param[59] = new ReportParameter("Left_Param27", dt2.Rows[0]["tflout_tyre_no"].ToString());
                    param[60] = new ReportParameter("Left_Param28", dt2.Rows[0]["tflout_km"].ToString());
                    param[61] = new ReportParameter("Left_Param29", dt2.Rows[0]["tflout_company"].ToString());
                    param[62] = new ReportParameter("Left_Param30", Convert.ToDateTime(dt2.Rows[0]["tflout_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[58] = new ReportParameter("Left_Param26", "Nil");
                    param[59] = new ReportParameter("Left_Param27", "Nil");
                    param[60] = new ReportParameter("Left_Param28", "Nil");
                    param[61] = new ReportParameter("Left_Param29", "Nil");
                    param[62] = new ReportParameter("Left_Param30", "Nil");
                }
                r3 = dt2.Rows[0]["tblin_type"].ToString();
                if (r3 == "N")
                {
                    param[63] = new ReportParameter("Left_Param41", "NEW");
                    param[64] = new ReportParameter("Left_Param42", dt2.Rows[0]["tblin_tyre_no"].ToString());
                    param[65] = new ReportParameter("Left_Param43", dt2.Rows[0]["tblin_km"].ToString());
                    param[66] = new ReportParameter("Left_Param44", dt2.Rows[0]["tblin_company"].ToString());
                    param[67] = new ReportParameter("Left_Param45", Convert.ToDateTime(dt2.Rows[0]["tblout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r3 == "B")
                {
                    param[63] = new ReportParameter("Left_Param41", "RE-BUILD");
                    param[64] = new ReportParameter("Left_Param42", dt2.Rows[0]["tblin_tyre_no"].ToString());
                    param[65] = new ReportParameter("Left_Param43", dt2.Rows[0]["tblin_km"].ToString());
                    param[66] = new ReportParameter("Left_Param44", dt2.Rows[0]["tblin_company"].ToString());
                    param[67] = new ReportParameter("Left_Param45", Convert.ToDateTime(dt2.Rows[0]["tblout_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[63] = new ReportParameter("Left_Param41", "Nil");
                    param[64] = new ReportParameter("Left_Param42", "Nil");
                    param[65] = new ReportParameter("Left_Param43", "Nil");
                    param[66] = new ReportParameter("Left_Param44", "Nil");
                    param[67] = new ReportParameter("Left_Param45", "Nil");
                }
                r4 = dt2.Rows[0]["tblout_type"].ToString();
                if (r4 == "N")
                {
                    param[68] = new ReportParameter("Left_Param36", "NEW");
                    param[69] = new ReportParameter("Left_Param37", dt2.Rows[0]["tblout_tyre_no"].ToString());
                    param[70] = new ReportParameter("Left_Param38", dt2.Rows[0]["tblout_km"].ToString());
                    param[71] = new ReportParameter("Left_Param39", dt2.Rows[0]["tblout_company"].ToString());
                    param[72] = new ReportParameter("Left_Param40", Convert.ToDateTime(dt2.Rows[0]["tblout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r4 == "B")
                {
                    param[68] = new ReportParameter("Left_Param36", "RE-BUILD");
                    param[69] = new ReportParameter("Left_Param37", dt2.Rows[0]["tblout_tyre_no"].ToString());
                    param[70] = new ReportParameter("Left_Param38", dt2.Rows[0]["tblout_km"].ToString());
                    param[71] = new ReportParameter("Left_Param39", dt2.Rows[0]["tblout_company"].ToString());
                    param[72] = new ReportParameter("Left_Param40", Convert.ToDateTime(dt2.Rows[0]["tblout_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[68] = new ReportParameter("Left_Param36", "Nil");
                    param[69] = new ReportParameter("Left_Param37", "Nil");
                    param[70] = new ReportParameter("Left_Param38", "Nil");
                    param[71] = new ReportParameter("Left_Param39", "Nil");
                    param[72] = new ReportParameter("Left_Param40", "Nil");
                }
                string r5, r6, r7, r8;
                r5 = dt2.Rows[0]["tfrin_type"].ToString();
                if (r5 == "N")
                {
                    param[73] = new ReportParameter("Right_Param26", "NEW");
                    param[74] = new ReportParameter("Right_Param27", dt2.Rows[0]["tfrin_tyre_no"].ToString());
                    param[75] = new ReportParameter("Right_Param28", dt2.Rows[0]["tfrin_km"].ToString());
                    param[76] = new ReportParameter("Right_Param29", dt2.Rows[0]["tfrin_company"].ToString());
                    param[77] = new ReportParameter("Right_Param30", Convert.ToDateTime(dt2.Rows[0]["tfrin_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r5 == "B")
                {
                    param[73] = new ReportParameter("Right_Param26", "RE-BUILD");
                    param[74] = new ReportParameter("Right_Param27", dt2.Rows[0]["tfrin_tyre_no"].ToString());
                    param[75] = new ReportParameter("Right_Param28", dt2.Rows[0]["tfrin_km"].ToString());
                    param[76] = new ReportParameter("Right_Param29", dt2.Rows[0]["tfrin_company"].ToString());
                    param[77] = new ReportParameter("Right_Param30", Convert.ToDateTime(dt2.Rows[0]["tfrin_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[73] = new ReportParameter("Right_Param26", "Nil");
                    param[74] = new ReportParameter("Right_Param27", "Nil");
                    param[75] = new ReportParameter("Right_Param28", "Nil");
                    param[76] = new ReportParameter("Right_Param29", "Nil");
                    param[77] = new ReportParameter("Right_Param30", "Nil");
                }
                r6 = dt2.Rows[0]["tfrout_type"].ToString();
                if (r6 == "N")
                {
                    param[78] = new ReportParameter("Right_Param31", "NEW");
                    param[79] = new ReportParameter("Right_Param32", dt2.Rows[0]["tfrout_tyre_no"].ToString());
                    param[80] = new ReportParameter("Right_Param33", dt2.Rows[0]["tfrout_km"].ToString());
                    param[81] = new ReportParameter("Right_Param34", dt2.Rows[0]["tfrout_company"].ToString());
                    param[82] = new ReportParameter("Right_Param35", Convert.ToDateTime(dt2.Rows[0]["tfrout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r6 == "B")
                {
                    param[78] = new ReportParameter("Right_Param31", "RE-BUILD");
                    param[79] = new ReportParameter("Right_Param32", dt2.Rows[0]["tfrout_tyre_no"].ToString());
                    param[80] = new ReportParameter("Right_Param33", dt2.Rows[0]["tfrout_km"].ToString());
                    param[81] = new ReportParameter("Right_Param34", dt2.Rows[0]["tfrout_company"].ToString());
                    param[82] = new ReportParameter("Right_Param35", Convert.ToDateTime(dt2.Rows[0]["tfrout_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[78] = new ReportParameter("Right_Param31", "Nil");
                    param[79] = new ReportParameter("Right_Param32", "Nil");
                    param[80] = new ReportParameter("Right_Param33", "Nil");
                    param[81] = new ReportParameter("Right_Param34", "Nil");
                    param[82] = new ReportParameter("Right_Param35", "Nil");
                }
                r7 = dt2.Rows[0]["tbrin_type"].ToString();
                if (r7 == "N")
                {
                    param[83] = new ReportParameter("Right_Param36", "NEW");
                    param[84] = new ReportParameter("Right_Param37", dt2.Rows[0]["tbrin_tyre_no"].ToString());
                    param[85] = new ReportParameter("Right_Param38", dt2.Rows[0]["tbrin_km"].ToString());
                    param[86] = new ReportParameter("Right_Param39", dt2.Rows[0]["tbrin_company"].ToString());
                    param[87] = new ReportParameter("Right_Param40", Convert.ToDateTime(dt2.Rows[0]["tbrout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r7 == "B")
                {
                    param[83] = new ReportParameter("Right_Param36", "RE-BUILD");
                    param[84] = new ReportParameter("Right_Param37", dt2.Rows[0]["tbrin_tyre_no"].ToString());
                    param[85] = new ReportParameter("Right_Param38", dt2.Rows[0]["tbrin_km"].ToString());
                    param[86] = new ReportParameter("Right_Param39", dt2.Rows[0]["tbrin_company"].ToString());
                    param[87] = new ReportParameter("Right_Param40", Convert.ToDateTime(dt2.Rows[0]["tbrout_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[83] = new ReportParameter("Right_Param36", "Nil");
                    param[84] = new ReportParameter("Right_Param37", "Nil");
                    param[85] = new ReportParameter("Right_Param38", "Nil");
                    param[86] = new ReportParameter("Right_Param39", "Nil");
                    param[87] = new ReportParameter("Right_Param40", "Nil");
                }
                r8 = dt2.Rows[0]["tbrout_type"].ToString();
                if (r8 == "N")
                {
                    param[88] = new ReportParameter("Right_Param41", "NEW");
                    param[89] = new ReportParameter("Right_Param42", dt2.Rows[0]["tbrout_tyre_no"].ToString());
                    param[90] = new ReportParameter("Right_Param43", dt2.Rows[0]["tbrout_km"].ToString());
                    param[91] = new ReportParameter("Right_Param44", dt2.Rows[0]["tbrout_company"].ToString());
                    param[92] = new ReportParameter("Right_Param45", Convert.ToDateTime(dt2.Rows[0]["tbrout_date"]).ToString("dd/MM/yyyy"));
                }
                else if (r8 == "B")
                {
                    param[88] = new ReportParameter("Right_Param41", "RE-BUILD");
                    param[89] = new ReportParameter("Right_Param42", dt2.Rows[0]["tbrout_tyre_no"].ToString());
                    param[90] = new ReportParameter("Right_Param43", dt2.Rows[0]["tbrout_km"].ToString());
                    param[91] = new ReportParameter("Right_Param44", dt2.Rows[0]["tbrout_company"].ToString());
                    param[92] = new ReportParameter("Right_Param45", Convert.ToDateTime(dt2.Rows[0]["tbrout_date"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    param[88] = new ReportParameter("Right_Param41", "Nil");
                    param[89] = new ReportParameter("Right_Param42", "Nil");
                    param[90] = new ReportParameter("Right_Param43", "Nil");
                    param[91] = new ReportParameter("Right_Param44", "Nil");
                    param[92] = new ReportParameter("Right_Param45", "Nil");
                }
                con3.close_string();
            }
            else
            {
                //MessageBox.Show("Record Doesnot Exist");
                param[53] = new ReportParameter("Left_Param31", "Nil");
                param[54] = new ReportParameter("Left_Param32", "Nil");
                param[55] = new ReportParameter("Left_Param33", "Nil");
                param[56] = new ReportParameter("Left_Param34", "Nil");
                param[57] = new ReportParameter("Left_Param35", "Nil");
                param[58] = new ReportParameter("Left_Param26", "Nil");
                param[59] = new ReportParameter("Left_Param27", "Nil");
                param[60] = new ReportParameter("Left_Param28", "Nil");
                param[61] = new ReportParameter("Left_Param29", "Nil");
                param[62] = new ReportParameter("Left_Param30", "Nil");
                param[63] = new ReportParameter("Left_Param41", "Nil");
                param[64] = new ReportParameter("Left_Param42", "Nil");
                param[65] = new ReportParameter("Left_Param43", "Nil");
                param[66] = new ReportParameter("Left_Param44", "Nil");
                param[67] = new ReportParameter("Left_Param45", "Nil");
                param[68] = new ReportParameter("Left_Param36", "Nil");
                param[69] = new ReportParameter("Left_Param37", "Nil");
                param[70] = new ReportParameter("Left_Param38", "Nil");
                param[71] = new ReportParameter("Left_Param39", "Nil");
                param[72] = new ReportParameter("Left_Param40", "Nil");
                param[73] = new ReportParameter("Right_Param26", "Nil");
                param[74] = new ReportParameter("Right_Param27", "Nil");
                param[75] = new ReportParameter("Right_Param28", "Nil");
                param[76] = new ReportParameter("Right_Param29", "Nil");
                param[77] = new ReportParameter("Right_Param30", "Nil");
                param[78] = new ReportParameter("Right_Param31", "Nil");
                param[79] = new ReportParameter("Right_Param32", "Nil");
                param[80] = new ReportParameter("Right_Param33", "Nil");
                param[81] = new ReportParameter("Right_Param34", "Nil");
                param[82] = new ReportParameter("Right_Param35", "Nil");
                param[83] = new ReportParameter("Right_Param36", "Nil");
                param[84] = new ReportParameter("Right_Param37", "Nil");
                param[85] = new ReportParameter("Right_Param38", "Nil");
                param[86] = new ReportParameter("Right_Param39", "Nil");
                param[87] = new ReportParameter("Right_Param40", "Nil");
                param[88] = new ReportParameter("Right_Param41", "Nil");
                param[89] = new ReportParameter("Right_Param42", "Nil");
                param[90] = new ReportParameter("Right_Param43", "Nil");
                param[91] = new ReportParameter("Right_Param44", "Nil");
                param[92] = new ReportParameter("Right_Param45", "Nil");
            }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }

            Report_Viewer.LocalReport.SetParameters(param);
            Report_Viewer.RefreshReport();
        }

        void New_Tyre_Price()
        {
            try
            {
                Connection CON = new Connection();
                CON.connection_string();
                OdbcCommand cmd = new OdbcCommand("Select tyre_number,type from tyre_price where tyre_number='" + vehicle_tyre_number.Text + "' and type='N' and vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                }
                else
                {
                    OdbcCommand cmd4 = new OdbcCommand("insert into tyre_price(vehicle_number,tyre_number,company,price,type,date)values('" + tyre_vehicle_number.Text + "','" + vehicle_tyre_number.Text + "','" + vehicle_tyre_company.Text + "','" + Convert.ToDouble(tyre_price.Text) + "','N','" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "')", CON.str);
                    cmd4.ExecuteNonQuery();
                }
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
           

        }

        void Build_Tyre_price()
        {
            try
            {
                Connection CON = new Connection();
                CON.connection_string();
                OdbcCommand cmd = new OdbcCommand("Select tyre_number,type from tyre_price where tyre_number='" + vehicle_tyre_number.Text + "' and type='B' and vehicle_number='" + tyre_vehicle_number.Text + "'", CON.str);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                }
                else
                {
                    OdbcCommand cmd5 = new OdbcCommand("insert into tyre_price(vehicle_number,tyre_number,company,price,type,date)values('" + tyre_vehicle_number.Text + "','" + vehicle_tyre_number.Text + "','" + vehicle_tyre_company.Text + "','" + Convert.ToDouble(tyre_price.Text) + "','B','" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy/MM/dd") + "')", CON.str);
                    cmd5.ExecuteNonQuery();
                }
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
           
        }

        void Tyre_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            string s = tyre_vehicle_number.Text;
            if (!string.IsNullOrWhiteSpace(tyre_vehicle_number.Text))
            {

                len = tyre_vehicle_number.Text.Length; 
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
                        tyre_vehicle_number.Text = "";
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

        private void vehicle_tyre_number_Gotfocus(object sender, RoutedEventArgs e)
        {
            vehicle_tyre_number.Text = string.Empty;
        }

        private void vehicle_tyre_km_GotFocus(object sender, RoutedEventArgs e)
        {
            vehicle_tyre_km.Text = string.Empty;
        }
    }
}
