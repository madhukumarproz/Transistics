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
    /// Interaction logic for Maintenance_view.xaml
    /// </summary>
    public partial class Maintenance_view : UserControl
    {
        public Maintenance_view()
        {
            InitializeComponent();
           
            year_txt.Items.Clear();
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            for (int i = 1; i < 6; i++)
            {
                year_txt.Items.Add(year);
                year -= 1;
            }
           
        }

        //DataTable dtable = new DataTable();      
       // DataTable dt = new DataTable();
      
       
        
        void maintenance_view_vehicle_number_keydown(object sender, KeyEventArgs e)
        {           
            if (e.Key == Key.Tab | e.Key == Key.Enter&!string.IsNullOrWhiteSpace(maintenance_view_vehicle_number.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    try
                    {
                        string l = maintenance_view_vehicle_number.Text;
                        if (maintenance_view_vehicle_number.Text.Equals("ALL"))
                        {
                            DataTable dtable = new DataTable();
                            dtable.Rows.Clear();
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select BILL_NO,EXPENSE_TYPE,DATE_FORMAT(bill_date,'%d/%m/%Y') as BILL_DATE,VEHICLE,SUB_TOTAL,DISCOUNT,GND_TOTAL from expense_bill  ", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            da.Fill(dtable);
                            if (dtable.Rows.Count > 0)
                            {
                                reportViewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Maintenance_DataSet", dtable);
                                reportViewer.LocalReport.DataSources.Add(ds);
                                reportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Maintenance_Report.rdlc";
                                reportViewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show(" Record Not Found");
                                //expense_bill.IsEnabled = false;
                            }
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            DataTable dtable = new DataTable();
                            dtable.Rows.Clear();
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select BILL_NO,EXPENSE_TYPE,DATE_FORMAT(bill_date,'%d/%m/%Y') as BILL_DATE,VEHICLE,SUB_TOTAL,DISCOUNT,GND_TOTAL from expense_bill where vehicle='" + maintenance_view_vehicle_number.Text + "' ", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            da.Fill(dtable);
                            if (dtable.Rows.Count > 0)
                            {

                                reportViewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Maintenance_DataSet1", dtable);
                                reportViewer.LocalReport.DataSources.Add(ds);
                                reportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Maintenance_Report1.rdlc";
                                ReportParameter[] param = new ReportParameter[1];
                                param[0] = new ReportParameter("ReportParam1", maintenance_view_vehicle_number.Text);
                                reportViewer.LocalReport.SetParameters(param);
                                reportViewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Selected Vehicle Record Not Found");
                                //expense_bill.IsEnabled = false;
                            }
                            con.close_string();
                        }
                        else
                        {
                            MessageBox.Show("Vehicle Number is Invalid Format or Empty ");
                        }
                    }
                    catch(OdbcException ex)
                    {
                        MessageBox.Show("Error :"+ex);
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


        void maintenance_view_month_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter&!string.IsNullOrWhiteSpace(maintenance_view_month.Text) & !string.IsNullOrWhiteSpace(maintenance_view_vehicle_number.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string year = DateTime.Now.ToString();
                    string year1 = Convert.ToDateTime(year).ToString("yyyy");
                    int yy = Convert.ToInt32(year1);
                    string l = maintenance_view_vehicle_number.Text;
                    string mon = maintenance_view_month.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            DataTable dtable = new DataTable();
                            string MONTH = maintenance_view_month.Text.Substring(0, 2);
                            dtable.Rows.Clear();
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select BILL_NO,EXPENSE_TYPE,DATE_FORMAT(bill_date,'%d/%m/%Y') as BILL_DATE,VEHICLE,SUB_TOTAL,DISCOUNT,GND_TOTAL from expense_bill where vehicle='" + maintenance_view_vehicle_number.Text + "' and year(bill_date)=" + yy + " and month(bill_date)=" + MONTH + "", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);

                            da.Fill(dtable);

                            if (dtable.Rows.Count > 0)
                            {

                                reportViewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Maintenance_DataSet1", dtable);
                                reportViewer.LocalReport.DataSources.Add(ds);
                                reportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Maintenance_Report1.rdlc";
                                ReportParameter[] param = new ReportParameter[1];
                                param[0] = new ReportParameter("ReportParam1", maintenance_view_vehicle_number.Text);
                                reportViewer.LocalReport.SetParameters(param);
                                reportViewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Selected Month Record Not Found For '" + maintenance_view_vehicle_number.Text + "' Vehicle");
                                //expense_bill.IsEnabled = false;
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
                        MessageBox.Show("Please Select Vehicle Number and Month");
                    }

                }
                else
                {
                    MessageBox.Show("Access Denied");
                }

                              
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number and Month");
            }
        }


        void maintenance_year_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter&!string.IsNullOrWhiteSpace(year_txt.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    string MONTH = null;
                    int yy = Convert.ToInt32(year_txt.Text);
                    if (!string.IsNullOrWhiteSpace(maintenance_view_month.Text))
                    {
                        MONTH = maintenance_view_month.Text.Substring(0, 2);
                    }
                    try
                    {
                        string l = maintenance_view_vehicle_number.Text; string mon = maintenance_view_month.Text; string year = year_txt.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}") && Regex.IsMatch(mon, "^[0-9]{2}[-]{1}[a-zA-Z]{3}") && Regex.IsMatch(year, "^[0-9]{4}"))
                        {
                            DataTable dtable = new DataTable();
                            //expense_bill.ItemsSource = null;
                            //expense_bill.Items.Refresh();
                            dtable.Rows.Clear();
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select BILL_NO,EXPENSE_TYPE,DATE_FORMAT(bill_date,'%d/%m/%Y') as BILL_DATE,VEHICLE,SUB_TOTAL,DISCOUNT,GND_TOTAL from expense_bill where  vehicle='" + maintenance_view_vehicle_number.Text + "' and year(bill_date)=" + yy + " and month(bill_date)=" + MONTH + "", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);

                            da.Fill(dtable);

                            if (dtable.Rows.Count > 0)
                            {

                                reportViewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Maintenance_DataSet1", dtable);
                                reportViewer.LocalReport.DataSources.Add(ds);
                                reportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Maintenance_Report1.rdlc";
                                ReportParameter[] param = new ReportParameter[1];
                                param[0] = new ReportParameter("ReportParam1", maintenance_view_vehicle_number.Text);
                                reportViewer.LocalReport.SetParameters(param);
                                reportViewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Selected Month and Year Record Not Found For '" + maintenance_view_vehicle_number.Text + "' Vehicle");
                                //expense_bill.IsEnabled = false;
                            }
                            con.close_string();
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}") && Regex.IsMatch(year, "^[0-9]{4}"))
                        {
                            DataTable dtable = new DataTable();
                            dtable.Rows.Clear();
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select BILL_NO,EXPENSE_TYPE,DATE_FORMAT(bill_date,'%d/%m/%Y') as BILL_DATE,VEHICLE,SUB_TOTAL,DISCOUNT,GND_TOTAL from expense_bill where  vehicle='" + maintenance_view_vehicle_number.Text + "' and year(bill_date)=" + yy + "", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);

                            da.Fill(dtable);

                            if (dtable.Rows.Count > 0)
                            {

                                reportViewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Maintenance_DataSet1", dtable);
                                reportViewer.LocalReport.DataSources.Add(ds);
                                reportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Maintenance_Report1.rdlc";
                                ReportParameter[] param = new ReportParameter[1];
                                param[0] = new ReportParameter("ReportParam1", maintenance_view_vehicle_number.Text);
                                reportViewer.LocalReport.SetParameters(param);
                                reportViewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Selected Year Record Not Found For '" + maintenance_view_vehicle_number.Text + "' Vehicle");
                                //expense_bill.IsEnabled = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Vehicle Number,Month and Year");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Record Getting problem");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }
               
                
            }
            else
            {
                MessageBox.Show("Please Select Year");
            }
        }


        void all_expense_bill_view(object sender, RoutedEventArgs e)
        {
            chkbox.IsChecked = false;
            if(!string.IsNullOrWhiteSpace(maintenance_view_vehicle_number.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    try
                    {
                        string l = maintenance_view_vehicle_number.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            DataTable dtable = new DataTable();
                            dtable.Rows.Clear();
                            Connection con = new Connection();
                            con.connection_string();
                            OdbcCommand cmd = new OdbcCommand("select BILL_NO,EXPENSE_TYPE,DATE_FORMAT(bill_date,'%d/%m/%Y') as BILL_DATE,VEHICLE,SUB_TOTAL,DISCOUNT,GND_TOTAL from expense_bill where vehicle='" + maintenance_view_vehicle_number.Text + "' ", con.str);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);

                            da.Fill(dtable);

                            if (dtable.Rows.Count > 0)
                            {
                                reportViewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Maintenance_DataSet1", dtable);
                                reportViewer.LocalReport.DataSources.Add(ds);
                                reportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Maintenance_Report1.rdlc";
                                ReportParameter[] param = new ReportParameter[1];
                                param[0] = new ReportParameter("ReportParam1", maintenance_view_vehicle_number.Text);
                                reportViewer.LocalReport.SetParameters(param);
                                reportViewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Selected Vehicle Record Not Found");
                                //expense_bill.IsEnabled = false;
                            }
                            con.close_string();
                            chkbox.IsChecked = false;
                        }
                        else
                        {
                            MessageBox.Show("Please Select Vehicle Number or Enter");
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
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }
           
            
        }


       
        void Maintenance_View_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            string s = maintenance_view_vehicle_number.Text;
            if (!string.IsNullOrWhiteSpace(maintenance_view_vehicle_number.Text))
            {

                len = maintenance_view_vehicle_number.Text.Length;
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
                        maintenance_view_vehicle_number.Text = "";
                    }
                }
            }
            if (len >= 10)
            {
                if (e.Key != Key.Back)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }

            }
        }
        void Maintenance_Month_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(maintenance_view_month.Text)) 
            {

                len = maintenance_view_month.Text.Length;
            }
            else
            {
                len = 0;
            }

            if (len > 6)
            {
                if (e.Key != Key.Back)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }

            }
        }
        void Maintenance_Year_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(year_txt.Text))
            {

                len = year_txt.Text.Length;
            }
            else
            {
                len = 0;
            }

            if (len > 4)
            {
                if (e.Key != Key.Back)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }

            }
        }

        private void maintenance_view_vehicle_number_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        maintenance_view_vehicle_number.Items.Add(dt.Rows[i]["vehicle_number"]);
                    }
                }
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
            
        }
    }
}
