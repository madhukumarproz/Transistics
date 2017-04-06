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
    /// Interaction logic for Vehicle_Update.xaml
    /// </summary>
    public partial class Vehicle_Update : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        string chr = null;
        public Vehicle_Update()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            trailer_panel.Visibility = System.Windows.Visibility.Hidden;
            load_panel.Visibility = System.Windows.Visibility.Hidden;
            lpg_update_img2.Visibility = System.Windows.Visibility.Hidden;
            trailer_update_img2.Visibility = System.Windows.Visibility.Hidden;
            load_update_img2.Visibility = System.Windows.Visibility.Hidden;
        }
        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {
               
                if (chr == "u")
                {
                    lpg_update_img1.Visibility = System.Windows.Visibility.Visible;
                    lpg_update_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }                
                else if (chr == "tu")
                {
                    trailer_update_img1.Visibility = System.Windows.Visibility.Visible;
                    trailer_update_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }               
                else if (chr == "lu")
                {
                    load_update_img1.Visibility = System.Windows.Visibility.Visible;
                    load_update_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }


            }
            ii++;
        }
        void ioc_checked(object sender, RoutedEventArgs e)
        {
            lpg_panel.Visibility = Visibility.Visible;
            trailer_panel.Visibility = Visibility.Hidden;
            load_panel.Visibility = Visibility.Hidden;
            contractor_txt.Text = ""; vehicle_number.Text = ""; transport_name.Text = ""; vendor_code.Text = "";
            load_vehicle_no.Text = ""; load_trans_name.Text = "";
            trailer_vehicle_no.Text = ""; trailer_trans_name.Text = "";
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where CORPORATION='IOC'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                    vehicle_number.Items.Clear();
                    for (int i=0;i<dt.Rows.Count;i++)
                    {
                        vehicle_number.Items.Add(dt.Rows[i]["vehicle_number"]);
                    }
                }
                else
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                }
                con.close_connection();
                contractor_txt.Text = "IOC";
                Add_Transport_Name();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }


        }
        void bpc_checked(object sender, RoutedEventArgs e)
        {

            lpg_panel.Visibility = Visibility.Visible;
            trailer_panel.Visibility = Visibility.Hidden;
            load_panel.Visibility = Visibility.Hidden;
            contractor_txt.Text = ""; vehicle_number.Text = ""; transport_name.Text = ""; vendor_code.Text = "";
            load_vehicle_no.Text = ""; load_trans_name.Text = "";
            trailer_vehicle_no.Text = ""; trailer_trans_name.Text = "";
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where CORPORATION='BPC'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                    vehicle_number.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vehicle_number.Items.Add(dt.Rows[i]["vehicle_number"]);
                    }

                }
                else
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                }
                con.close_connection();
                contractor_txt.Text = "BPC";
                Add_Transport_Name();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }


        }
        void hpc_checked(object sender, RoutedEventArgs e)
        {

            lpg_panel.Visibility = Visibility.Visible;
            trailer_panel.Visibility = Visibility.Hidden;
            load_panel.Visibility = Visibility.Hidden;
            contractor_txt.Text = ""; vehicle_number.Text = ""; transport_name.Text = ""; vendor_code.Text = "";
            load_vehicle_no.Text = ""; load_trans_name.Text = "";
            trailer_vehicle_no.Text = ""; trailer_trans_name.Text = "";
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where CORPORATION='HPC'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                    vehicle_number.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vehicle_number.Items.Add(dt.Rows[i]["vehicle_number"]);
                    }
                }
                else
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                }
                contractor_txt.Text = "HPC";
                con.close_connection();
                Add_Transport_Name();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }


        }
        void trailer_checked(object sender, RoutedEventArgs e)
        {
            lpg_panel.Visibility = Visibility.Hidden;
            trailer_panel.Visibility = Visibility.Visible;
            load_panel.Visibility = Visibility.Hidden;
            trailer_vehicle_no.Text = ""; trailer_trans_name.Text = "";tlr_model.Text = ""; trl_vehicle_type.Text = "";
            load_vehicle_no.Text = ""; load_trans_name.Text = "";
            contractor_txt.Text = ""; vehicle_number.Text = ""; transport_name.Text = ""; vendor_code.Text = "";
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TYPE from vechicle_details where CORPORATION='TLR'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                    //trailer_vehicle_no.Items.Clear();
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    trailer_vehicle_no.Items.Add(dt.Rows[i]["vehicle_number"]);
                    //}
                }
                else
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                }
                con.close_connection();
                Add_Transport_Name();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error:"+ex);
            }


        }
        void load_truck_checked(object sender, RoutedEventArgs e)
        {
            lpg_panel.Visibility = Visibility.Hidden;
            trailer_panel.Visibility = Visibility.Hidden;
            load_panel.Visibility = Visibility.Visible;
            load_vehicle_no.Text = ""; load_trans_name.Text = ""; lod_model.Text = ""; vehicle_type.Text = "";
            trailer_vehicle_no.Text = ""; trailer_trans_name.Text = "";
            contractor_txt.Text = ""; vehicle_number.Text = ""; transport_name.Text = ""; vendor_code.Text = "";
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TYPE from vechicle_details where CORPORATION='LOD'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                    //load_vehicle_no.Items.Clear();
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    load_vehicle_no.Items.Add(dt.Rows[i]["vehicle_number"]);
                    //}
                }
                else
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                }
                con.close_connection();
                Add_Transport_Name();
            }
            catch(OdbcException ex )
            {
                MessageBox.Show("Error :"+ex);
            }


        }

        private void transport_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
               if(!string.IsNullOrWhiteSpace(transport_name.Text))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select vendor_code from transports_name where transport_name='" + transport_name.Text + "'", con.conn);
                        OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                        DataTable DT = new DataTable();
                        DA.Fill(DT);
                        if (DT.Rows.Count > 0)
                        {
                            vendor_code.Text = DT.Rows[0]["vendor_code"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MUST ADD VENDOR CODE IN TRANSPORT NAME LIST");
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

                }
            }

        }
        void Vechicle_Update_Click(object sender, RoutedEventArgs e)
        {
            string s = Properties.Settings.Default.User;
            if (s == "ADMIN" || s == "MANAGER")
            {
                if (!string.IsNullOrWhiteSpace(contractor_txt.Text) & !string.IsNullOrWhiteSpace(vehicle_number.Text) & !string.IsNullOrWhiteSpace(transport_name.Text) & !string.IsNullOrWhiteSpace(vehicle_model.Text))
                {
                    string l = vehicle_number.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_number.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Want Update Data", "Update Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("update vechicle_details set corporation='" + contractor_txt.Text + "',transport_name='" + transport_name.Text + "',vendor_code='" + vendor_code.Text + "',fc_expiry='" + Convert.ToDateTime(fc_exp.Text).ToString("yyyy/MM/dd") + "',insurance_expiry='" + Convert.ToDateTime(insurance_exp.Text).ToString("yyyy/MM/dd") + "',national_expiry='" + Convert.ToDateTime(national_exp.Text).ToString("yyyy/MM/dd") + "',permit_expiry='" + Convert.ToDateTime(permit_exp.Text).ToString("yyyy/MM/dd") + "',explosive_expiry='" + Convert.ToDateTime(explosive_exp.Text).ToString("yyyy/MM/dd") + "',yearly_expiry='" + Convert.ToDateTime(yearly_exp.Text).ToString("yyyy/MM/dd") + "',half_yearly_expiry='" + Convert.ToDateTime(half_year_exp.Text).ToString("yyyy/MM/dd") + "',hydro_expiry='" + Convert.ToDateTime(hydro_exp.Text).ToString("yyyy/MM/dd") + "',cll_policy='" + Convert.ToDateTime(cll_policy.Text).ToString("yyyy/MM/dd") + "',pli='" + Convert.ToDateTime(pli_exp.Text).ToString("yyyy/MM/dd") + "',tax_expiry='" + Convert.ToDateTime(tax_exp.Text).ToString("yyyy/MM/dd") + "',model='" + Convert.ToInt32(vehicle_model.Text) + "' where vehicle_number='" + vehicle_number.Text + "'", con.conn);
                                cmd.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where corporation='IOC' or corporation='BPC' or corporation='HPC' ", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                table_view.ItemsSource = dt.DefaultView;
                                table_view.Columns[0].Width = 250;
                                table_view.Columns[1].Width = 250;
                                con.close_connection();
                                lpg_update_img1.Visibility = Visibility.Hidden;
                                lpg_update_img2.Visibility = Visibility.Visible;
                                time1.Start();
                                chr = "u";
                                contractor_txt.Text = ""; transport_name.Text = ""; vehicle_number.Text = ""; vendor_code.Text = ""; vehicle_model.Text = "";
                                fc_exp.Text = DateTime.Now.ToShortDateString(); insurance_exp.Text = DateTime.Now.ToShortDateString(); national_exp.Text = DateTime.Now.ToShortDateString();
                                permit_exp.Text = DateTime.Now.ToShortDateString(); half_year_exp.Text = DateTime.Now.ToShortDateString(); yearly_exp.Text = DateTime.Now.ToShortDateString(); hydro_exp.Text = DateTime.Now.ToShortDateString();
                                pli_exp.Text = DateTime.Now.ToShortDateString(); cll_policy.Text = DateTime.Now.ToShortDateString(); tax_exp.Text = DateTime.Now.ToShortDateString();
                            }
                            else if(mr==MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show(" Vehicle Data Updation Error:" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Vehicle Number Format");
                    }
                  

                }
                else
                {
                    MessageBox.Show("Please Fill Empty Text Field");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }
        void table_view_selectionchanged(object sender, RoutedEventArgs e)
        {

            DataRowView dr = (DataRowView)table_view.SelectedItem;
            string s = (dr["corporation"]).ToString();
            string ss = (dr["vehicle_number"]).ToString();
            if (s.Equals("IOC") | s.Equals("BPC") | s.Equals("HPC")&&!string.IsNullOrWhiteSpace(ss))
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select transport_name,corporation,vendor_code,model,DATE_FORMAT(fc_expiry,'%d/%m/%y')as fc,DATE_FORMAT(insurance_expiry,'%d/%m/%y')as ins,DATE_FORMAT(national_expiry,'%d/%m/%y')as national,DATE_FORMAT(permit_expiry,'%d/%m/%y')as permit,DATE_FORMAT(explosive_expiry,'%d/%m/%y')as explo,DATE_FORMAT(yearly_expiry,'%d/%m/%y')as yearly,DATE_FORMAT(half_yearly_expiry,'%d/%m/%y')as half,DATE_FORMAT(hydro_expiry,'%d/%m/%y')as hydro,DATE_FORMAT(cll_policy,'%d/%m/%y')as cll,DATE_FORMAT(pli,'%d/%m/%y')as pli,DATE_FORMAT(tax_expiry,'%d/%m/%y')as tax from vechicle_details where vehicle_number='" + ss + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        contractor_txt.Text = dt.Rows[0]["corporation"].ToString();
                        vehicle_number.Text = ss;
                        //transport_name.Items.Clear();
                        //transport_name.Items.Add(dt.Rows[0]["transport_name"].ToString());
                        transport_name.Text = dt.Rows[0]["transport_name"].ToString();
                        vendor_code.Text = dt.Rows[0]["vendor_code"].ToString();
                        fc_exp.Text = dt.Rows[0]["fc"].ToString();
                        insurance_exp.Text = dt.Rows[0]["ins"].ToString();
                        national_exp.Text = dt.Rows[0]["national"].ToString();
                        permit_exp.Text = dt.Rows[0]["permit"].ToString();
                        explosive_exp.Text = dt.Rows[0]["explo"].ToString();
                        yearly_exp.Text = dt.Rows[0]["yearly"].ToString();
                        half_year_exp.Text = dt.Rows[0]["half"].ToString();
                        hydro_exp.Text = dt.Rows[0]["hydro"].ToString();
                        cll_policy.Text = dt.Rows[0]["cll"].ToString();
                        pli_exp.Text = dt.Rows[0]["pli"].ToString();
                        tax_exp.Text = dt.Rows[0]["tax"].ToString();
                        vehicle_model.Text = dt.Rows[0]["model"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Does Not Exist");
                    }
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
               
            }
            else if (s.Equals("TLR") && !string.IsNullOrWhiteSpace(ss))
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select transport_name,vehicle_number,MODEL,TYPE,DATE_FORMAT(fc_expiry, '%d/%m/%y') AS FC,DATE_FORMAT(insurance_expiry , '%d/%m/%y')AS INS,DATE_FORMAT(national_expiry , '%d/%m/%y')AS NAT,DATE_FORMAT(permit_expiry , '%d/%m/%y')AS PER,DATE_FORMAT(tax_expiry, '%d/%m/%y')AS TAX from vechicle_details where vehicle_number='" + ss + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        trailer_trans_name.Text = dt.Rows[0]["transport_name"].ToString();
                        trailer_vehicle_no.Text = dt.Rows[0]["vehicle_number"].ToString();
                        trailer_fc.Text = dt.Rows[0]["FC"].ToString();
                        trailer_insurance.Text = dt.Rows[0]["INS"].ToString();
                        trailer_np.Text = dt.Rows[0]["NAT"].ToString();
                        trailer_permit.Text = dt.Rows[0]["PER"].ToString();
                        trailer_quater_tax.Text = dt.Rows[0]["TAX"].ToString();
                        tlr_model.Text = dt.Rows[0]["MODEL"].ToString();
                        trl_vehicle_type.Text = dt.Rows[0]["TYPE"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Does Not Exist");
                    }
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
               
            }
            else if (s.Equals("LOD") && !string.IsNullOrWhiteSpace(ss))
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select transport_name,vehicle_number,MODEL,TYPE,DATE_FORMAT(fc_expiry, '%d/%m/%y') AS FC,DATE_FORMAT(insurance_expiry , '%d/%m/%y')AS INS,DATE_FORMAT(national_expiry , '%d/%m/%y')AS NAT,DATE_FORMAT(permit_expiry , '%d/%m/%y')AS PER,DATE_FORMAT(tax_expiry, '%d/%m/%y')AS TAX from vechicle_details where vehicle_number='" + ss + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        load_trans_name.Text = dt.Rows[0]["transport_name"].ToString();
                        load_vehicle_no.Text = dt.Rows[0]["vehicle_number"].ToString();
                        load_fc.Text = dt.Rows[0]["FC"].ToString();
                        load_insurance.Text = dt.Rows[0]["INS"].ToString();
                        load_np.Text = dt.Rows[0]["NAT"].ToString();
                        load_permit.Text = dt.Rows[0]["PER"].ToString();
                        load_quater_tax.Text = dt.Rows[0]["TAX"].ToString();
                        lod_model.Text= dt.Rows[0]["MODEL"].ToString();
                        vehicle_type.Text = dt.Rows[0]["TYPE"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Does Not Exist");
                    }
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
               
            }

        }
        void trailer_update_click(object sender, RoutedEventArgs e)
        {
            string s = Properties.Settings.Default.User;
            if (s == "ADMIN" || s == "MANAGER")
            {
                if (!string.IsNullOrWhiteSpace(trailer_vehicle_no.Text) & !string.IsNullOrWhiteSpace(trailer_fc.Text) & !string.IsNullOrWhiteSpace(trailer_np.Text) & !string.IsNullOrWhiteSpace(trailer_permit.Text) & !string.IsNullOrWhiteSpace(trailer_quater_tax.Text) & !string.IsNullOrWhiteSpace(trailer_trans_name.Text) & !string.IsNullOrWhiteSpace(tlr_model.Text))
                {
                    string l = trailer_vehicle_no.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_number.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Want Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("update vechicle_details set transport_name='" + trailer_trans_name.Text + "', fc_expiry='" + Convert.ToDateTime(trailer_fc.Text).ToString("yyyy/MM/dd") + "',insurance_expiry='" + Convert.ToDateTime(trailer_insurance.Text).ToString("yyyy/MM/dd") + "',national_expiry='" + Convert.ToDateTime(trailer_np.Text).ToString("yyyy/MM/dd") + "',permit_expiry='" + Convert.ToDateTime(trailer_permit.Text).ToString("yyyy/MM/dd") + "',tax_expiry='" + Convert.ToDateTime(trailer_quater_tax.Text).ToString("yyyy/MM/dd") + "',model='"+tlr_model.Text+ "',type='" + trl_vehicle_type.Text + "' where vehicle_number='" + trailer_vehicle_no.Text + "'", con.conn);
                                cmd.ExecuteNonQuery();
                                con.close_connection();
                                trailer_update_img1.Visibility = Visibility.Hidden;
                                trailer_update_img2.Visibility = Visibility.Visible;
                                time1.Start();
                                chr = "tu";
                                OdbcCommand cmd1 = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where corporation='TLR'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                table_view.ItemsSource = dt.DefaultView;
                                table_view.Columns[0].Width = 250;
                                table_view.Columns[1].Width = 250;
                                tlr_model.Text = ""; trl_vehicle_type.Text = "";
                                trailer_vehicle_no.Text = ""; trailer_fc.Text = DateTime.Now.ToShortDateString(); trailer_np.Text = DateTime.Now.ToShortDateString(); trailer_permit.Text = DateTime.Now.ToShortDateString(); trailer_quater_tax.Text = DateTime.Now.ToShortDateString(); trailer_insurance.Text = DateTime.Now.ToShortDateString(); trailer_trans_name.Text = "";
                            }
                            else if(mr==MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show(" Trailer Vehicle Data Update Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Vehicle Number Format");
                    }
                 

                }
                else
                {
                    MessageBox.Show("Please Fill Empty Text Field");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }
        void load_update_click(object sender, RoutedEventArgs e)
        {
            string s = Properties.Settings.Default.User;
            if(s=="ADMIN"||s=="MANAGER")
            {
                if (!string.IsNullOrWhiteSpace(load_vehicle_no.Text) & !string.IsNullOrWhiteSpace(load_fc.Text) & !string.IsNullOrWhiteSpace(load_np.Text) & !string.IsNullOrWhiteSpace(load_permit.Text) & !string.IsNullOrWhiteSpace(load_quater_tax.Text) & !string.IsNullOrWhiteSpace(load_trans_name.Text) & !string.IsNullOrWhiteSpace(lod_model.Text))
                {
                    string l = load_vehicle_no.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_number.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Want Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("update vechicle_details set transport_name='" + load_trans_name.Text + "', fc_expiry='" + Convert.ToDateTime(load_fc.Text).ToString("yyyy/MM/dd") + "',insurance_expiry='" + Convert.ToDateTime(load_insurance.Text).ToString("yyyy/MM/dd") + "',national_expiry='" + Convert.ToDateTime(load_np.Text).ToString("yyyy/MM/dd") + "',permit_expiry='" + Convert.ToDateTime(load_permit.Text).ToString("yyyy/MM/dd") + "',tax_expiry='" + Convert.ToDateTime(load_quater_tax.Text).ToString("yyyy/MM/dd") + "',model='"+lod_model.Text+"',type='"+ vehicle_type.Text + "' where vehicle_number='" + load_vehicle_no.Text + "'", con.conn);
                                cmd.ExecuteNonQuery();
                                con.close_connection();
                                load_update_img1.Visibility = Visibility.Hidden;
                                load_update_img2.Visibility = Visibility.Visible;
                                time1.Start();
                                chr = "lu";
                                OdbcCommand cmd1 = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where corporation='LOD'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                table_view.ItemsSource = dt.DefaultView;
                                table_view.Columns[0].Width = 250;
                                table_view.Columns[1].Width = 250;
                                lod_model.Text = ""; vehicle_type.Text = "";
                                load_vehicle_no.Text = ""; load_fc.Text = DateTime.Now.ToShortDateString(); load_np.Text = DateTime.Now.ToShortDateString(); load_permit.Text = DateTime.Now.ToShortDateString(); load_quater_tax.Text = DateTime.Now.ToShortDateString(); load_insurance.Text = DateTime.Now.ToShortDateString(); load_trans_name.Text = "";
                            }
                            else if(mr==MessageBoxResult.Cancel)
                            {

                            }

                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show(" Trailer Vehicle Data Update Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Vehicle Number Format");
                    }
                   

                }
                else
                {
                    MessageBox.Show("Please Fill Empty Text Field");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }
        public void Add_Transport_Name()
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select transport_name from transports_name", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    transport_name.Items.Clear();
                    //trailer_trans_name.Items.Clear();
                    //load_trans_name.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        transport_name.Items.Add(dt.Rows[i]["transport_name"]);
                        //trailer_trans_name.Items.Add(dt.Rows[i]["transport_name"]);
                        //load_trans_name.Items.Add(dt.Rows[i]["transport_name"]);
                    }

                }
                con.close_connection();

            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
        }
        void Lpg_Update_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            
        }
        void Trailer_Update_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            string s = trailer_vehicle_no.Text;
            if (!string.IsNullOrWhiteSpace(trailer_vehicle_no.Text))
            {

                len = trailer_vehicle_no.Text.Length;
            }
            else
            {
                len = 0;
            }
            if (len > 10)
            {               
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
            }
            else if (len <= 2)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isletter = char.IsLetter(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter First Two Letter Character");
                        trailer_vehicle_no.Text = "";
                    }
                }
            }
            else if (len > 2 && len <= 4)
            {
                for (int i = 2; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter Number");
                        trailer_vehicle_no.Text = "";
                    }
                }
            }
            else if (len == 5)
            {
                bool isletter = char.IsLetter(s[4]);
                bool isdigit = char.IsDigit(s[4]);
                if (isletter == true)
                {
                }
                else if(isdigit==true)
                {

                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Should Enter Character");
                    trailer_vehicle_no.Text = "";
                }
            }
            else if (len == 6)
            {
                bool isletter = char.IsLetter(s[5]);
                bool isdigit = char.IsDigit(s[5]);
                if (isletter == true)
                {
                }
                else if (isdigit==true)
                {

                }
                else if (isdigit)
                {

                }
                else
                {

                }
            }
            else if (len > 6)
            {
                for (int i = 6; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter Number");
                        trailer_vehicle_no.Text = "";
                    }
                }
            }
            if(e.Key==Key.Back)
            {
                e.Handled = false;
            }

        }
        void Load_Update_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            string s = load_vehicle_no.Text;
            if (!string.IsNullOrWhiteSpace(load_vehicle_no.Text))
            {

                len = load_vehicle_no.Text.Length;
            }
            else
            {
                len = 0;
            }
            if (len > 10)
            {              
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;                
            }
            else if (len <= 2)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isletter = char.IsLetter(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter First Two Letter Character");
                        load_vehicle_no.Text = "";
                    }
                }
            }
            else if (len > 2 && len <= 4)
            {
                for (int i = 2; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter Number");
                        load_vehicle_no.Text = "";
                    }
                }
            }
            else if (len == 5)
            {
                bool isletter = char.IsLetter(s[4]);
                bool isdigit = char.IsDigit(s[4]);
                if (isletter == true)
                {
                }
                else if (isdigit==true)
                {

                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Should Enter Character");
                    load_vehicle_no.Text = "";
                }
            }
            else if (len == 6)
            {
                bool isletter = char.IsLetter(s[5]);
                bool isdigit = char.IsDigit(s[5]);
                if (isletter == true)
                {
                }
                else if (isdigit==true)
                {

                }
                else
                {

                }
            }
            else if (len > 6)
            {
                for (int i = 6; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter Number");
                        load_vehicle_no.Text = "";
                    }
                }
            }
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }
        }

        private void vehicle_number_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    string l = vehicle_number.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number");
                        e.Handled = true;
                        vehicle_number.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select * from Vechicle_details where vehicle_number='" + vehicle_number.Text + "'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                transport_name.Text = dt.Rows[0]["transport_name"].ToString();
                                vendor_code.Text = dt.Rows[0]["vendor_code"].ToString();
                                contractor_txt.Text = dt.Rows[0]["corporation"].ToString();
                                fc_exp.Text = dt.Rows[0]["fc_expiry"].ToString();
                                insurance_exp.Text = dt.Rows[0]["insurance_expiry"].ToString();
                                national_exp.Text = dt.Rows[0]["national_expiry"].ToString();
                                permit_exp.Text = dt.Rows[0]["permit_expiry"].ToString();
                                explosive_exp.Text = dt.Rows[0]["explosive_expiry"].ToString();
                                yearly_exp.Text = dt.Rows[0]["yearly_expiry"].ToString();
                                half_year_exp.Text = dt.Rows[0]["half_yearly_expiry"].ToString();
                                hydro_exp.Text = dt.Rows[0]["hydro_expiry"].ToString();
                                cll_policy.Text = dt.Rows[0]["cll_policy"].ToString();
                                pli_exp.Text = dt.Rows[0]["pli"].ToString();
                                tax_exp.Text = dt.Rows[0]["tax_expiry"].ToString();
                                vehicle_model.Text = dt.Rows[0]["model"].ToString();
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Invalid");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
            }
 
        }

        private void transport_name_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int len=transport_name.Text.Length;
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }
            else if (len >= 20)           
            {
                MessageBox.Show("Allow 20 Characters Only");
                e.Handled = true;
               // vendor_code.Text = "";
            }
            
        }

        private void trl_vehicle_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ind = trl_vehicle_type.SelectedIndex;
            if (ind == 0)
            {
                trl_vehi_type.Content = "Single Crown - Double Axial";
            }
            else if (ind == 1)
            {
                trl_vehi_type.Content = "Single Crown - Triple Axial";
            }
            else if (ind == 2)
            {
                trl_vehi_type.Content = "Double Crown - Double Axial";
            }
            else if (ind == 3)
            {
                trl_vehi_type.Content = "Double Crown - Triple Axial";
            }
        }

        private void vehicle_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ind = vehicle_type.SelectedIndex;
            if (ind == 0)
            {
                vehi_type.Content = "Commet";
            }
            else if (ind == 1)
            {
                vehi_type.Content = "Taurus";
            }
            else if (ind == 2)
            {
                vehi_type.Content = "Single Axial Taurus";
            }
            else if (ind == 3)
            {
                vehi_type.Content = "Double Axial Taurus";
            }
        }

       
    }
}
