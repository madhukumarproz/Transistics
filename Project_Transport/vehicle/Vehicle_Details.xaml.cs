using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;
using System;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Drawing;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Vehicle_Details.xaml
    /// </summary>
    public partial class Vehicle_Details : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        string chr = null;
        public Vehicle_Details()
        {
            InitializeComponent(); 
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            lpg_insert_img2.Visibility = Visibility.Hidden;            
            trailer_insert_img2.Visibility =Visibility.Hidden;            
            load_insert_img2.Visibility = Visibility.Hidden;            
            load_insert.Visibility = Visibility.Visible;           
            trailer_insert.Visibility = Visibility.Visible;           
            insert_btn.Visibility = Visibility.Visible;
            trailer_panel.Visibility = Visibility.Hidden;
            load_panel.Visibility = Visibility.Hidden;

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
                    trailer_trans_name.Items.Clear();
                    load_trans_name.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        transport_name.Items.Add(dt.Rows[i]["transport_name"]);
                        trailer_trans_name.Items.Add(dt.Rows[i]["transport_name"]);
                        load_trans_name.Items.Add(dt.Rows[i]["transport_name"]);
                    }

                }
                else
                {
                    MessageBox.Show("Please Add Transports Details");
                    contractor_txt.Text = "";
                }
                con.close_connection();
                
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
        }

        void time_tick1(object sender, EventArgs e)
        {            
             if (ii == 10)
            {
               if(chr=="i"|chr=="b"|chr=="h")
                {
                    lpg_insert_img1.Visibility = Visibility.Visible;
                    lpg_insert_img2.Visibility = Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }              
               else if(chr=="ti")
                {
                    trailer_insert_img1.Visibility = System.Windows.Visibility.Visible;
                    trailer_insert_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }               
               else if(chr=="li")
                {
                    load_insert_img1.Visibility = System.Windows.Visibility.Visible;
                    load_insert_img2.Visibility = System.Windows.Visibility.Hidden;
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
                MessageBox.Show("Connection Error :"+ex);
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
                MessageBox.Show("Connection Error :"+ex);
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
                MessageBox.Show("Connection Error :"+ex);
            }


        }
        void trailer_checked(object sender, RoutedEventArgs e)
        {
            lpg_panel.Visibility = Visibility.Hidden;
            trailer_panel.Visibility = Visibility.Visible;
            load_panel.Visibility = Visibility.Hidden;
            trailer_vehicle_no.Text = ""; trailer_trans_name.Text = "";
            load_vehicle_no.Text = ""; load_trans_name.Text = "";
            contractor_txt.Text = ""; vehicle_number.Text = ""; transport_name.Text = ""; vendor_code.Text = "";
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where CORPORATION='TLR'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                    
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
            catch
            {
                MessageBox.Show("Connection Error :"+explosive_exp);
            }


        }
        void load_truck_checked(object sender, RoutedEventArgs e)
        {
            lpg_panel.Visibility = Visibility.Hidden;
            trailer_panel.Visibility = Visibility.Hidden;
            load_panel.Visibility = Visibility.Visible;
            load_vehicle_no.Text = ""; load_trans_name.Text = "";
            trailer_vehicle_no.Text = ""; trailer_trans_name.Text = "";
            contractor_txt.Text = ""; vehicle_number.Text = ""; transport_name.Text = ""; vendor_code.Text = "";
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where CORPORATION='LOD'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    table_view.ItemsSource = dt.DefaultView;
                    table_view.Columns[0].Width = 250;
                    table_view.Columns[1].Width = 250;
                   
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
                MessageBox.Show("Connection Error :"+ex);
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
                    MessageBox.Show("Transport Name Is Empty");
                }
               
               
            }

        }

        void Vechicle_Insert_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if(user=="ADMIN"||user=="MANAGER"||user=="USER")
            {
                //string vc = vendor_code.Content.ToString();
                if (!string.IsNullOrWhiteSpace(contractor_txt.Text) & !string.IsNullOrWhiteSpace(vehicle_number.Text) & !string.IsNullOrWhiteSpace(transport_name.Text) & !string.IsNullOrWhiteSpace(vendor_code.Text) & !string.IsNullOrWhiteSpace(vehicle_model.Text))
                {
                    string l = vehicle_number.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        vehicle_number.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}")||Regex.IsMatch(l,"^[A-Za-z]{2}[0-9]{6}"))
                    {
                        Connection con = new Connection();
                        con.open_connection();

                        if (contractor_txt.Text == "IOC" || contractor_txt.Text == "BPC" || contractor_txt.Text == "HPC")
                        {
                            try
                            {
                                MessageBoxResult mr = MessageBox.Show("Are You Want Insert Vehicle Details", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                                if (mr == MessageBoxResult.OK)
                                {
                                    OdbcCommand CMD3 = new OdbcCommand("SELECT vehicle_number from vechicle_details where vehicle_number like '" + vehicle_number.Text + "'", con.conn);
                                    OdbcDataAdapter da = new OdbcDataAdapter(CMD3);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {
                                        MessageBox.Show("This Number Already Exist");
                                    }
                                    else
                                    {
                                        OdbcCommand cmd = new OdbcCommand("insert into vechicle_details(corporation,vehicle_number,transport_name,vendor_code,card_id,fc_expiry,insurance_expiry,national_expiry,permit_expiry,explosive_expiry,yearly_expiry,half_yearly_expiry,hydro_expiry,cll_policy,pli,tax_expiry,model,status,added_date)values('" + contractor_txt.Text + "','" + vehicle_number.Text + "','" + transport_name.Text + "','" + vendor_code.Text + "','NOTASSIGNED','" + Convert.ToDateTime(fc_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(insurance_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(national_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(permit_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(explosive_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(yearly_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(half_year_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(hydro_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(cll_policy.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(pli_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(tax_exp.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToInt32(vehicle_model.Text) + "','OPEN',now())", con.conn);
                                        cmd.ExecuteNonQuery();

                                        lpg_insert_img1.Visibility = Visibility.Hidden;
                                        lpg_insert_img2.Visibility = Visibility.Visible;
                                        time1.Start();
                                        chr = "i";
                                        vehicle_number.Text = "";
                                        ioc_check.IsChecked = false; bpc_check.IsChecked = false; hpc_check.IsChecked = false; trailer_check.IsChecked = false; load_check.IsChecked = false;
                                        OdbcCommand cmd1 = new OdbcCommand("select CORPORATION,VEHICLE_NUMBER from vechicle_details where CORPORATION='IOC' or CORPORATION='BPC' or CORPORATION='HPC'", con.conn);
                                        OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                        DataTable dt1 = new DataTable();
                                        da1.Fill(dt1);
                                        table_view.ItemsSource = dt1.DefaultView;
                                        table_view.Columns[0].Width = 250;
                                        table_view.Columns[1].Width = 250;
                                        contractor_txt.Text = "";
                                        transport_name.Text = "";
                                        vendor_code.Text = ""; vehicle_model.Text = ""; fc_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); insurance_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); national_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); ;
                                        permit_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); half_year_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); yearly_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); hydro_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
                                        pli_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); cll_policy.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); tax_exp.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
                                    }
                                   
                                }
                                else if(mr==MessageBoxResult.Cancel)
                                {

                                }

                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("LPG Data Insert Error :" + ex);
                            }

                        }                 
                        else
                        {

                        }
                        con.close_connection();
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


        


        void trailer_insert_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if(user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                if (!string.IsNullOrWhiteSpace(trailer_vehicle_no.Text) & !string.IsNullOrWhiteSpace(trailer_fc.Text) & !string.IsNullOrWhiteSpace(trailer_np.Text) & !string.IsNullOrWhiteSpace(trailer_permit.Text) & !string.IsNullOrWhiteSpace(trailer_quater_tax.Text) & !string.IsNullOrWhiteSpace(trailer_insurance.Text) & !string.IsNullOrWhiteSpace(trailer_trans_name.Text) && !string.IsNullOrWhiteSpace(tlr_model.Text))
                {
                    string l = trailer_vehicle_no.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Vehicle Number");
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
                                con.connection_string();
                                OdbcCommand CMD3 = new OdbcCommand("SELECT vehicle_number from vechicle_details where vehicle_number like '" + trailer_vehicle_no.Text + "'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(CMD3);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("This Number Already Exist");
                                }
                                else
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into vechicle_details(corporation,vehicle_number,transport_name,fc_expiry,insurance_expiry,national_expiry,permit_expiry,tax_expiry,model,status,type,added_date)values('TLR','" + trailer_vehicle_no.Text + "','" + trailer_trans_name.Text + "','" + Convert.ToDateTime(trailer_fc.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(trailer_insurance.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(trailer_np.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(trailer_permit.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(trailer_quater_tax.Text).ToString("yyyy/MM/dd") + "','" + tlr_model.Text + "','OPEN','" + trl_vehicle_type.Text + "',now())", con.conn);
                                    cmd.ExecuteNonQuery();
                                    OdbcCommand cmd2 = new OdbcCommand("insert into trailer(vehicle_no)values('" + trailer_vehicle_no.Text + "')", con.str);
                                    cmd2.ExecuteNonQuery();
                                    trailer_insert_img1.Visibility = Visibility.Hidden;
                                    trailer_insert_img2.Visibility = Visibility.Visible;
                                    time1.Start();
                                    chr = "ti";
                                    OdbcCommand cmd1 = new OdbcCommand("select VEHICLE_NUMBER,TYPE from vechicle_details where CORPORATION='TLR'", con.conn);
                                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                    DataTable dt1 = new DataTable();
                                    da1.Fill(dt1);
                                    table_view.ItemsSource = dt1.DefaultView;
                                    table_view.Columns[0].Width = 250;
                                    table_view.Columns[1].Width = 250;
                                    con.close_connection();
                                    con.close_string();
                                    tlr_model.Text = "";
                                    trailer_vehicle_no.Text = ""; trailer_fc.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); trailer_np.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); trailer_permit.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); trailer_quater_tax.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); trailer_insurance.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); trailer_trans_name.Text = "";
                                }
                              
                            }
                            else if(mr==MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Trailer Vehicle Data Insert Error :" + ex);
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


       


        void load_insert_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                if (!string.IsNullOrWhiteSpace(load_vehicle_no.Text) & !string.IsNullOrWhiteSpace(load_fc.Text) & !string.IsNullOrWhiteSpace(load_np.Text) & !string.IsNullOrWhiteSpace(load_permit.Text) & !string.IsNullOrWhiteSpace(load_quater_tax.Text) & !string.IsNullOrWhiteSpace(load_trans_name.Text)&&!string.IsNullOrWhiteSpace(lod_model.Text))
                {
                    string l = load_vehicle_no.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Vehicle Number");
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
                                con.connection_string();
                                OdbcCommand CMD3 = new OdbcCommand("SELECT vehicle_number from vechicle_details where vehicle_number like '"+ load_vehicle_no.Text + "'",con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(CMD3);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if(dt.Rows.Count>0)
                                {
                                    MessageBox.Show("This Number Already Exist");
                                }
                                else
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into vechicle_details(corporation,vehicle_number,transport_name,fc_expiry,insurance_expiry,national_expiry,permit_expiry,tax_expiry,model,status,type,added_date)values('LOD','" + load_vehicle_no.Text + "','" + load_trans_name.Text + "','" + Convert.ToDateTime(load_fc.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(load_insurance.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(load_np.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(load_permit.Text).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(load_quater_tax.Text).ToString("yyyy/MM/dd") + "','" + lod_model.Text + "','OPEN','" + vehicle_type.Text + "',now())", con.conn);
                                    cmd.ExecuteNonQuery();
                                    OdbcCommand cmd2 = new OdbcCommand("insert into load_tyre(vechile_no)values('" + load_vehicle_no.Text + "')", con.str);
                                    cmd2.ExecuteNonQuery();
                                    load_insert_img1.Visibility = Visibility.Hidden;
                                    load_insert_img2.Visibility = Visibility.Visible;
                                    time1.Start();
                                    chr = "li";
                                    OdbcCommand cmd1 = new OdbcCommand("select VEHICLE_NUMBER,TYPE from vechicle_details where CORPORATION='LOD'", con.conn);
                                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                    DataTable dt1 = new DataTable();
                                    da1.Fill(dt1);
                                    table_view.ItemsSource = dt1.DefaultView;
                                    table_view.Columns[0].Width = 250;
                                    table_view.Columns[1].Width = 250;
                                    con.close_connection();
                                    con.close_string();
                                    lod_model.Text = "";
                                    load_vehicle_no.Text = ""; load_fc.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); load_np.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); load_permit.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); load_quater_tax.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); load_insurance.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"); load_trans_name.Text = "";
                                }
                               
                            }
                            else if (mr == MessageBoxResult.Cancel)
                            {

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show(" Load Vehicle Data Insert Error :" + ex);
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
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error"+ex);
                }
               
            }
            else if (s.Equals("TLR") && !string.IsNullOrWhiteSpace(ss))
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select transport_name,vehicle_number,MODEL,DATE_FORMAT(fc_expiry, '%d/%m/%y') AS FC,DATE_FORMAT(insurance_expiry , '%d/%m/%y')AS INS,DATE_FORMAT(national_expiry , '%d/%m/%y')AS NAT,DATE_FORMAT(permit_expiry , '%d/%m/%y')AS PER,DATE_FORMAT(tax_expiry, '%d/%m/%y')AS TAX from vechicle_details where vehicle_number='" + ss + "'", con.conn);
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
                    OdbcCommand cmd = new OdbcCommand("select transport_name,vehicle_number,MODEL,DATE_FORMAT(fc_expiry, '%d/%m/%y') AS FC,DATE_FORMAT(insurance_expiry , '%d/%m/%y')AS INS,DATE_FORMAT(national_expiry , '%d/%m/%y')AS NAT,DATE_FORMAT(permit_expiry , '%d/%m/%y')AS PER,DATE_FORMAT(tax_expiry, '%d/%m/%y')AS TAX from vechicle_details where vehicle_number='" + ss + "'", con.conn);
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
                        lod_model.Text = dt.Rows[0]["MODEL"].ToString();
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

      
        void Vehicle_Number_keydown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter&&!string.IsNullOrWhiteSpace(vehicle_number.Text))
            {
                string l = vehicle_number.Text;
                if(Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}")|| Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    vehicle_number.Text = "";
                }
                else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l,"^[a-zA-Z]{2}[0-9]{6}"))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details where vehicle_number LIKE '" + vehicle_number.Text + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show(" This Number Already Exist");
                            e.Handled = true;
                            vehicle_number.Text = "";
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    vehicle_number.Text = "";
                }                            
            }            
        }

     
        
        private void Vehicle_Number_KeyDown(object sender, TextChangedEventArgs e)
        {
            string s = vehicle_number.Text;
            int len = s.Length;
            if(len<=2)
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
                        vehicle_number.Text = "";
                    }
                }
            }
           else if(len>2 && len<=4)
            {
                for (int i = 2; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Should Enter Number");
                        vehicle_number.Text = "";
                    }
                }
            }
           else if(len==5)
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
                    MessageBox.Show("Should Enter Character");
                    vehicle_number.Text = "";
                }
            }
            else if(len==6)
            {
                bool isletter = char.IsLetter(s[5]);
                bool isdigit = char.IsDigit(s[5]);
                if (isletter == true)
                {
                }
                else if (isdigit == true)
                {

                }
                else
                {
                    
                }
            }
            else if(len>6)
            {
                for (int i = 6; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Should Enter Number");
                        vehicle_number.Text = "";
                    }
                }
            }

        }
      void   Vehicle_Number_Preview_Keydown(object sender,KeyEventArgs e)
        {
            int len = 0;
            len = vehicle_number.Text.Length;
            len = trailer_vehicle_no.Text.Length;
            len = load_vehicle_no.Text.Length;
            if (len>10)
            {
                e.Handled = true;
                trailer_vehicle_no.Text = string.Empty;
                load_vehicle_no.Text = string.Empty;
                System.Media.SystemSounds.Beep.Play();
            }
             
           

        }
        private void Load_Vehicle_Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = load_vehicle_no.Text;
            int len = s.Length;
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
                else if (isdigit == true)
                {

                }
                else
                {
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
                else if (isdigit == true)
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
                        MessageBox.Show("Should Enter Number");
                        load_vehicle_no.Text = "";
                    }
                }
            }

        }
        private void Trailer_Vehicle_Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = trailer_vehicle_no.Text;
            int len = s.Length;
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
                else if (isdigit == true)
                {

                }
                else
                {
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
                else if (isdigit == true)
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
                        MessageBox.Show("Should Enter Number");
                        trailer_vehicle_no.Text = "";
                    }
                }
            }

        }

        private void transport_name_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
           int  len=transport_name.Text.Length;
            int len1 = load_trans_name.Text.Length;
           int  len2 = trailer_trans_name.Text.Length;
            if (len>20)
            {
                transport_name.Text = "";
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
            if (len1 > 20)
            {
                load_trans_name.Text = "";
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
            if (len2 > 20)
            {
                trailer_trans_name.Text = "";
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }
        private void trailer_vehicle_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if(!String.IsNullOrWhiteSpace(trailer_vehicle_no.Text))
                {
                    string msg = vehicle_number_check(trailer_vehicle_no.Text, e);
                    if (msg == "")
                    {
                        trailer_vehicle_no.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Enter Vehicle Number");
                }
            }
           
        }

        private void load_vehicle_no_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                if (!String.IsNullOrWhiteSpace(load_vehicle_no.Text))
                {
                   string msg= vehicle_number_check(load_vehicle_no.Text, e);
                    if(msg=="")
                    {
                        load_vehicle_no.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Enter Vehicle Number");
                }
            }
           
        }
        public string vehicle_number_check(string s,KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                if (Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details where vehicle_number='" + s + "'", con.conn);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        MessageBox.Show("Vehicle Number Already Exist");
                        e.Handled = true;
                        s = "";
                    }
                    con.close_connection();
                }
                else
                {
                    MessageBox.Show("Incorrect Vehicle Number");
                    e.Handled = true;
                    s = "";
                }
            }
            return s;
           
        }

        private void vehicle_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ind=vehicle_type.SelectedIndex;
            if(ind==0)
            {
                vehi_type.Content = "Commet";
            }
            else if(ind==1)
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
    }
}
