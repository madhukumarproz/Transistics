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
    /// Interaction logic for Vehicle_View.xaml
    /// </summary>
    public partial class Vehicle_View : UserControl
    {
        
       
        public Vehicle_View()
        {
            InitializeComponent();         
        }

        Connection con = new Connection();
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            sp1.Visibility = Visibility.Hidden;
            sp2.Visibility = Visibility.Hidden;
           
        }

        void ioc_keydown(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                string user = Properties.Settings.Default.User;
                if(user=="ADMIN"||user=="MANAGER"||user=="USER")
                {
                    try
                    {
                        if (ioc.Text.Equals("ALL"))
                        {
                            //onnection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,VENDOR_CODE,DRIVER_NAME,CARD_ID,DATE_FORMAT(fc_expiry,'%d/%m/%Y') AS FC_EXPIRY,DATE_FORMAT(insurance_expiry,'%d/%m/%Y') AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y') AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y') AS PERMIT_EXPIRY,DATE_FORMAT(explosive_expiry,'%d/%m/%Y') AS EXPLOSIVE_EXPIRY,DATE_FORMAT(yearly_expiry,'%d/%m/%Y') AS YEARLY_EXPIRY,DATE_FORMAT(half_yearly_expiry,'%d/%m/%Y') AS HALF_YEARLY_EXPIRY,DATE_FORMAT(hydro_expiry,'%d/%m/%Y') AS HYDRO_EXPIRY,DATE_FORMAT(cll_policy,'%d/%m/%Y') AS CLL_POLICY,DATE_FORMAT(pli,'%d/%m/%Y') AS PLI,DATE_FORMAT(tax_expiry,'%d/%m/%Y') AS TAX_EXPIRY from vechicle_details where corporation='IOC'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                sp1.Visibility = Visibility.Hidden;
                                sp2.Visibility = Visibility.Visible;
                                Report_Viewer1.Clear();
                                Report_Viewer1.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Lpg_DataSet", dt);
                                Report_Viewer1.LocalReport.DataSources.Add(ds);
                                Report_Viewer1.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Report.rdlc";
                                Report_Viewer1.RefreshReport();
                                e.Handled = true;
                            }
                            else
                            {
                                MessageBox.Show("Details Not Exist");
                                e.Handled = true;
                            }

                            con.close_connection();
                        }
                        else if (ioc.Text != null)
                        {
                            string l = ioc.Text;
                            if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                            {
                                MessageBox.Show("Incorrect Number Format");
                                e.Handled = true;
                                ioc.Text = "";
                            }
                            else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                            {
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,VENDOR_CODE,DRIVER_NAME,CARD_ID,DATE_FORMAT(fc_expiry,'%d/%m/%Y') AS FC_EXPIRY,DATE_FORMAT(insurance_expiry,'%d/%m/%Y') AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y') AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y') AS PERMIT_EXPIRY,DATE_FORMAT(explosive_expiry,'%d/%m/%Y') AS EXPLOSIVE_EXPIRY,DATE_FORMAT(yearly_expiry,'%d/%m/%Y') AS YEARLY_EXPIRY,DATE_FORMAT(half_yearly_expiry,'%d/%m/%Y') AS HALF_YEARLY_EXPIRY,DATE_FORMAT(hydro_expiry,'%d/%m/%Y') AS HYDRO_EXPIRY,DATE_FORMAT(cll_policy,'%d/%m/%Y') AS CLL_POLICY,DATE_FORMAT(pli,'%d/%m/%Y') AS PLI,DATE_FORMAT(tax_expiry,'%d/%m/%Y') AS TAX_EXPIRY from vechicle_details where vehicle_number='" + ioc.Text + "'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                con.close_connection();
                                if (dt.Rows.Count > 0)
                                {
                                    MainWindow m = new MainWindow();
                                    sp2.Visibility = Visibility.Hidden;
                                    sp1.Visibility = Visibility.Visible;
                                    Report_Viewer.Clear();
                                    Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Single_Vehicle_Report.rdlc";
                                    ReportParameter[] param = new ReportParameter[14];
                                    param[0] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                                    param[1] = new ReportParameter("Vehicle", dt.Rows[0]["vehicle_number"].ToString());
                                    param[2] = new ReportParameter("Transport", dt.Rows[0]["transport_name"].ToString());
                                    param[3] = new ReportParameter("FC", dt.Rows[0]["fc_expiry"].ToString());
                                    param[4] = new ReportParameter("Insurance", dt.Rows[0]["insurance_expiry"].ToString());
                                    param[5] = new ReportParameter("National", dt.Rows[0]["national_expiry"].ToString());
                                    param[6] = new ReportParameter("Permit", dt.Rows[0]["permit_expiry"].ToString());
                                    param[7] = new ReportParameter("Explosive", dt.Rows[0]["explosive_expiry"].ToString());
                                    param[8] = new ReportParameter("Yearly", dt.Rows[0]["yearly_expiry"].ToString());
                                    param[9] = new ReportParameter("HalfYearly", dt.Rows[0]["half_yearly_expiry"].ToString());
                                    param[10] = new ReportParameter("Hydro", dt.Rows[0]["hydro_expiry"].ToString());
                                    param[11] = new ReportParameter("CllPolicy", dt.Rows[0]["cll_policy"].ToString());
                                    param[12] = new ReportParameter("Pli", dt.Rows[0]["pli"].ToString());
                                    param[13] = new ReportParameter("Tax", dt.Rows[0]["tax_expiry"].ToString());
                                    Report_Viewer.LocalReport.SetParameters(param);
                                    Report_Viewer.RefreshReport();
                                    e.Handled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Exist");
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Vehicle Number Format");
                                e.Handled = true;
                            }
                            // Connection con = new Connection();
                           
                        }

                        else
                        {
                            MessageBox.Show("please select number from dropdown list");
                            e.Handled = true;
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
            
               
            }

        }
        void bpc_keydown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    try
                    {
                        if (bpc.Text.Equals("ALL"))
                        {
                            // Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,VENDOR_CODE,DRIVER_NAME,CARD_ID,DATE_FORMAT(fc_expiry,'%d/%m/%Y') AS FC_EXPIRY,DATE_FORMAT(insurance_expiry,'%d/%m/%Y') AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y') AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y') AS PERMIT_EXPIRY,DATE_FORMAT(explosive_expiry,'%d/%m/%Y') AS EXPLOSIVE_EXPIRY,DATE_FORMAT(yearly_expiry,'%d/%m/%Y') AS YEARLY_EXPIRY,DATE_FORMAT(half_yearly_expiry,'%d/%m/%Y') AS HALF_YEARLY_EXPIRY,DATE_FORMAT(hydro_expiry,'%d/%m/%Y') AS HYDRO_EXPIRY,DATE_FORMAT(cll_policy,'%d/%m/%Y') AS CLL_POLICY,DATE_FORMAT(pli,'%d/%m/%Y') AS PLI,DATE_FORMAT(tax_expiry,'%d/%m/%Y') AS TAX_EXPIRY from vechicle_details where corporation='BPC'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                sp1.Visibility = Visibility.Hidden;
                                sp2.Visibility = Visibility.Visible;
                                Report_Viewer1.Clear();
                                Report_Viewer1.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Lpg_DataSet", dt);
                                Report_Viewer1.LocalReport.DataSources.Add(ds);
                                Report_Viewer1.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Report.rdlc";
                                Report_Viewer1.RefreshReport();
                                e.Handled = true;
                            }
                            else
                            {
                                MessageBox.Show("Details Not Exist");
                                e.Handled = true;
                            }

                            con.close_connection();
                        }
                        else if (bpc.Text != null)
                        {
                            string l = bpc.Text;
                            if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                            {
                                MessageBox.Show("Incorrect Number Format");
                                e.Handled = true;
                                bpc.Text = "";
                            }
                            else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                            {
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,VENDOR_CODE,DRIVER_NAME,CARD_ID,DATE_FORMAT(fc_expiry,'%d/%m/%Y') AS FC_EXPIRY,DATE_FORMAT(insurance_expiry,'%d/%m/%Y') AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y') AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y') AS PERMIT_EXPIRY,DATE_FORMAT(explosive_expiry,'%d/%m/%Y') AS EXPLOSIVE_EXPIRY,DATE_FORMAT(yearly_expiry,'%d/%m/%Y') AS YEARLY_EXPIRY,DATE_FORMAT(half_yearly_expiry,'%d/%m/%Y') AS HALF_YEARLY_EXPIRY,DATE_FORMAT(hydro_expiry,'%d/%m/%Y') AS HYDRO_EXPIRY,DATE_FORMAT(cll_policy,'%d/%m/%Y') AS CLL_POLICY,DATE_FORMAT(pli,'%d/%m/%Y') AS PLI,DATE_FORMAT(tax_expiry,'%d/%m/%Y') AS TAX_EXPIRY from vechicle_details where vehicle_number='" + bpc.Text + "'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                con.close_connection();

                                if (dt.Rows.Count > 0)
                                {
                                    MainWindow m = new MainWindow();
                                    sp2.Visibility = Visibility.Hidden;
                                    sp1.Visibility = Visibility.Visible;
                                    Report_Viewer.Clear();
                                    Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Single_Vehicle_Report.rdlc";
                                    ReportParameter[] param = new ReportParameter[14];
                                    param[0] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                                    param[1] = new ReportParameter("Vehicle", dt.Rows[0]["vehicle_number"].ToString());
                                    param[2] = new ReportParameter("Transport", dt.Rows[0]["transport_name"].ToString());
                                    param[3] = new ReportParameter("FC", dt.Rows[0]["fc_expiry"].ToString());
                                    param[4] = new ReportParameter("Insurance", dt.Rows[0]["insurance_expiry"].ToString());
                                    param[5] = new ReportParameter("National", dt.Rows[0]["national_expiry"].ToString());
                                    param[6] = new ReportParameter("Permit", dt.Rows[0]["permit_expiry"].ToString());
                                    param[7] = new ReportParameter("Explosive", dt.Rows[0]["explosive_expiry"].ToString());
                                    param[8] = new ReportParameter("Yearly", dt.Rows[0]["yearly_expiry"].ToString());
                                    param[9] = new ReportParameter("HalfYearly", dt.Rows[0]["half_yearly_expiry"].ToString());
                                    param[10] = new ReportParameter("Hydro", dt.Rows[0]["hydro_expiry"].ToString());
                                    param[11] = new ReportParameter("CllPolicy", dt.Rows[0]["cll_policy"].ToString());
                                    param[12] = new ReportParameter("Pli", dt.Rows[0]["pli"].ToString());
                                    param[13] = new ReportParameter("Tax", dt.Rows[0]["tax_expiry"].ToString());
                                    Report_Viewer.LocalReport.SetParameters(param);
                                    Report_Viewer.RefreshReport();
                                    e.Handled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Exist");
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Vehicle Number Format");
                                e.Handled = true;
                            }
                            //Connection con = new Connection();
                           
                        }

                        else
                        {
                            MessageBox.Show("please select number from dropdown list");
                            e.Handled = true;
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
               
               
            }
        }
        void hpc_keydown(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    try
                    {
                        if (hpc.Text.Equals("ALL"))
                        {
                            // Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,VENDOR_CODE,DRIVER_NAME,CARD_ID,DATE_FORMAT(fc_expiry,'%d/%m/%Y') AS FC_EXPIRY,DATE_FORMAT(insurance_expiry,'%d/%m/%Y') AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y') AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y') AS PERMIT_EXPIRY,DATE_FORMAT(explosive_expiry,'%d/%m/%Y') AS EXPLOSIVE_EXPIRY,DATE_FORMAT(yearly_expiry,'%d/%m/%Y') AS YEARLY_EXPIRY,DATE_FORMAT(half_yearly_expiry,'%d/%m/%Y') AS HALF_YEARLY_EXPIRY,DATE_FORMAT(hydro_expiry,'%d/%m/%Y') AS HYDRO_EXPIRY,DATE_FORMAT(cll_policy,'%d/%m/%Y') AS CLL_POLICY,DATE_FORMAT(pli,'%d/%m/%Y') AS PLI,DATE_FORMAT(tax_expiry,'%d/%m/%Y') AS TAX_EXPIRY from vechicle_details where corporation='HPC'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                sp1.Visibility = Visibility.Hidden;
                                sp2.Visibility = Visibility.Visible;
                                Report_Viewer1.Clear();
                                Report_Viewer1.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Lpg_DataSet", dt);
                                Report_Viewer1.LocalReport.DataSources.Add(ds);
                                Report_Viewer1.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Report.rdlc";
                                Report_Viewer1.RefreshReport();
                                e.Handled = true;
                            }
                            else
                            {
                                MessageBox.Show("Details Not Exist");
                                e.Handled = true;
                            }

                            con.close_connection();
                        }
                        else if (hpc.Text != null)
                        {
                            string l = hpc.Text;
                            if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                            {
                                MessageBox.Show("Incorrect Number Format");
                                e.Handled = true;
                                hpc.Text = "";
                            }
                            else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                            {
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,VENDOR_CODE,DRIVER_NAME,CARD_ID,DATE_FORMAT(fc_expiry,'%d/%m/%Y') AS FC_EXPIRY,DATE_FORMAT(insurance_expiry,'%d/%m/%Y') AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y') AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y') AS PERMIT_EXPIRY,DATE_FORMAT(explosive_expiry,'%d/%m/%Y') AS EXPLOSIVE_EXPIRY,DATE_FORMAT(yearly_expiry,'%d/%m/%Y') AS YEARLY_EXPIRY,DATE_FORMAT(half_yearly_expiry,'%d/%m/%Y') AS HALF_YEARLY_EXPIRY,DATE_FORMAT(hydro_expiry,'%d/%m/%Y') AS HYDRO_EXPIRY,DATE_FORMAT(cll_policy,'%d/%m/%Y') AS CLL_POLICY,DATE_FORMAT(pli,'%d/%m/%Y') AS PLI,DATE_FORMAT(tax_expiry,'%d/%m/%Y') AS TAX_EXPIRY from vechicle_details where vehicle_number='" + hpc.Text + "'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    MainWindow m = new MainWindow();
                                    sp2.Visibility = Visibility.Hidden;
                                    sp1.Visibility = Visibility.Visible;
                                    Report_Viewer.Clear();
                                    Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Single_Vehicle_Report.rdlc";
                                    ReportParameter[] param = new ReportParameter[14];
                                    param[0] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                                    param[1] = new ReportParameter("Vehicle", dt.Rows[0]["vehicle_number"].ToString());
                                    param[2] = new ReportParameter("Transport", dt.Rows[0]["transport_name"].ToString());
                                    param[3] = new ReportParameter("FC", dt.Rows[0]["fc_expiry"].ToString());
                                    param[4] = new ReportParameter("Insurance", dt.Rows[0]["insurance_expiry"].ToString());
                                    param[5] = new ReportParameter("National", dt.Rows[0]["national_expiry"].ToString());
                                    param[6] = new ReportParameter("Permit", dt.Rows[0]["permit_expiry"].ToString());
                                    param[7] = new ReportParameter("Explosive", dt.Rows[0]["explosive_expiry"].ToString());
                                    param[8] = new ReportParameter("Yearly", dt.Rows[0]["yearly_expiry"].ToString());
                                    param[9] = new ReportParameter("HalfYearly", dt.Rows[0]["half_yearly_expiry"].ToString());
                                    param[10] = new ReportParameter("Hydro", dt.Rows[0]["hydro_expiry"].ToString());
                                    param[11] = new ReportParameter("CllPolicy", dt.Rows[0]["cll_policy"].ToString());
                                    param[12] = new ReportParameter("Pli", dt.Rows[0]["pli"].ToString());
                                    param[13] = new ReportParameter("Tax", dt.Rows[0]["tax_expiry"].ToString());
                                    Report_Viewer.LocalReport.SetParameters(param);
                                    Report_Viewer.RefreshReport();
                                    e.Handled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Exist");
                                    e.Handled = true;
                                }
                                con.close_connection();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Vehicle Number Format");
                                e.Handled = true;
                            }
                            //Connection con = new Connection();
                           
                        }

                        else
                        {
                            MessageBox.Show("please select number from dropdown list");
                            e.Handled = true;
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
               
               
            }
        }
        void trailer_keydown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    try
                    {
                        if (trailer.Text.Equals("ALL"))
                        {
                            //  Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,DATE_FORMAT(insurance_expiry,'%d/%m/%Y')AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y')AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y')AS PERMIT_EXPIRY,DATE_FORMAT(tax_expiry,'%d/%m/%Y')AS TAX_EXPIRY from vechicle_details where corporation='TRAILER'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Report_Viewer1.Clear();
                                sp1.Visibility = Visibility.Hidden;
                                sp2.Visibility = Visibility.Visible;
                                Report_Viewer1.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Load_DataSet", dt);
                                Report_Viewer1.LocalReport.DataSources.Add(ds);
                                Report_Viewer1.LocalReport.ReportEmbeddedResource = "Project_Transport.Load_Report.rdlc";
                                Report_Viewer1.RefreshReport();
                                e.Handled = true;
                            }
                            else
                            {
                                MessageBox.Show("Details Not Exist");
                                e.Handled = true;
                            }
                            con.close_connection();
                        }
                        else if (trailer.Text != null)
                        {

                            string l = trailer.Text;
                            if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                            {
                                MessageBox.Show("Incorrect Number Format");
                                e.Handled = true;
                                trailer.Text = "";
                            }
                            else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                            {
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,DATE_FORMAT(insurance_expiry,'%d/%m/%Y') AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y') AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y') AS PERMIT_EXPIRY,DATE_FORMAT(tax_expiry,'%d/%m/%Y') AS TAX_EXPIRY from vechicle_details where vehicle_number='" + trailer.Text + "'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                con.close_connection();
                                Report_Viewer.Clear();
                                sp2.Visibility = Visibility.Hidden;
                                sp1.Visibility = Visibility.Visible;
                                if (dt.Rows.Count > 0)
                                {
                                    Report_Viewer.LocalReport.DataSources.Clear();
                                    ReportDataSource ds = new ReportDataSource("Load_DataSet", dt);
                                    Report_Viewer.LocalReport.DataSources.Add(ds);
                                    Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Load_Report.rdlc";
                                    Report_Viewer.RefreshReport();
                                    e.Handled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Exist");
                                    e.Handled = true;
                                }
                                //con.close_connection();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Vehicle Number Format");
                                e.Handled = true;
                            }
                            //onnection con = new Connection();
                           
                        }

                        else
                        {
                            MessageBox.Show("please select number from dropdown list");
                            e.Handled = true;
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
                
               
            }
        }
        void load_keydown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    try
                    {
                        if (load.Text.Equals("ALL"))
                        {
                            // Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,DATE_FORMAT(insurance_expiry,'%d/%m/%Y')AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y')AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y')AS PERMIT_EXPIRY,DATE_FORMAT(tax_expiry,'%d/%m/%Y')AS TAX_EXPIRY from vechicle_details where CORPORATION='LOAD'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Report_Viewer1.Clear();
                                sp1.Visibility = Visibility.Hidden;
                                sp2.Visibility = Visibility.Visible;
                                Report_Viewer1.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Load_DataSet", dt);
                                Report_Viewer1.LocalReport.DataSources.Add(ds);
                                Report_Viewer1.LocalReport.ReportEmbeddedResource = "Project_Transport.Load_Report.rdlc";
                                Report_Viewer1.RefreshReport();
                                e.Handled = true;
                            }
                            else
                            {
                                MessageBox.Show("Details Not Exist");
                                e.Handled = true;
                            }
                            con.close_connection();
                        }
                        else if (load.Text != null)
                        {
                            string l = load.Text;
                            if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                            {
                                MessageBox.Show("Incorrect Number Format");
                                e.Handled = true;
                                load.Text = "";
                            }
                            else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                            {
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,TRANSPORT_NAME,DATE_FORMAT(insurance_expiry,'%d/%m/%Y')AS INSURANCE_EXPIRY,DATE_FORMAT(national_expiry,'%d/%m/%Y')AS NATIONAL_EXPIRY,DATE_FORMAT(permit_expiry,'%d/%m/%Y')AS PERMIT_EXPIRY,DATE_FORMAT(tax_expiry,'%d/%m/%Y')AS TAX_EXPIRY from vechicle_details where vehicle_number='" + load.Text + "'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                con.close_connection();
                                Report_Viewer.Clear();
                                sp2.Visibility = Visibility.Hidden;
                                sp1.Visibility = Visibility.Visible;
                                if (dt.Rows.Count > 0)
                                {
                                    Report_Viewer.LocalReport.DataSources.Clear();
                                    ReportDataSource ds = new ReportDataSource("Load_DataSet", dt);
                                    Report_Viewer.LocalReport.DataSources.Add(ds);
                                    Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Load_Report.rdlc";
                                    Report_Viewer.RefreshReport();
                                    e.Handled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Exist");
                                    e.Handled = true;
                                }
                                //con.close_connection();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Vehicle Number Format");
                                e.Handled = true;
                            }
                            //  Connection con = new Connection();
                            
                        }

                        else
                        {
                            MessageBox.Show("please select number from dropdown list");
                            e.Handled = true;
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
                
                
            }
        }

        private void ioc_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER from vechicle_details where corporation='IOC'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //vechicle_view.ItemsSource = dt.DefaultView;
                    ioc.Items.Clear();
                    ioc.Items.Add("ALL");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();                        
                            ioc.Items.Add(s1);                                              
                    }
                }
                else
                {
                    // MessageBox.Show("Vehicle Details Doesnot Exist");
                    //vechicle_view.ItemsSource = dt.DefaultView;
                }

                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        private void bpc_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER from vechicle_details WHERE corporation='BPC'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //vechicle_view.ItemsSource = dt.DefaultView;
                    bpc.Items.Clear();
                    bpc.Items.Add("ALL");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();                      
                            bpc.Items.Add(s1);                                             
                    }
                }
                else
                {
                    // MessageBox.Show("Vehicle Details Doesnot Exist");
                    //vechicle_view.ItemsSource = dt.DefaultView;
                }

                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        private void trailer_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER from vechicle_details WHERE corporation='TLR'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //vechicle_view.ItemsSource = dt.DefaultView;
                    trailer.Items.Clear();
                    trailer.Items.Add("ALL");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();                       
                            trailer.Items.Add(s1);                      
                    }
                }
                else
                {
                    // MessageBox.Show("Vehicle Details Doesnot Exist");
                    //vechicle_view.ItemsSource = dt.DefaultView;
                }

                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        private void load_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER from vechicle_details WHERE corporation='LOD'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //vechicle_view.ItemsSource = dt.DefaultView;
                    load.Items.Clear();
                    load.Items.Add("ALL");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();                       
                            load.Items.Add(s1);                       
                    }
                }
                else
                {
                    // MessageBox.Show("Vehicle Details Doesnot Exist");
                    //vechicle_view.ItemsSource = dt.DefaultView;
                }

                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        private void hpc_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER from vechicle_details where corporation='HPC'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //vechicle_view.ItemsSource = dt.DefaultView;
                    hpc.Items.Clear();
                    hpc.Items.Add("ALL");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        hpc.Items.Add(s1);                        
                    }
                }
                else
                {
                    // MessageBox.Show("Vehicle Details Doesnot Exist");
                    //vechicle_view.ItemsSource = dt.DefaultView;
                }

                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        
    }
}
