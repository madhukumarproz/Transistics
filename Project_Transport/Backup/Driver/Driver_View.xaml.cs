using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Input;
using System.Text.RegularExpressions;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Driver_View.xaml
    /// </summary>
    public partial class Driver_View : UserControl
    {
       
        
        public Driver_View()
        {
            InitializeComponent();
            
        }

       

        void custom_view_Click(object seder, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select DRIVER_NAME,LICENCE_NUMBER,DATE_FORMAT(expiry,'%d/%m/%Y')AS EXPIRY,LICENCE_TYPE,CONTACT,DATE_FORMAT(join_date,'%d/%m/%Y')AS JOIN_DATE from driver_details WHERE bool=0", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MainWindow m = new MainWindow();
                        Custom_Report.Clear();
                        Custom_Report.LocalReport.DataSources.Clear();
                        Custom_Report.Reset();
                        ReportDataSource ds = new ReportDataSource("Driver_Custom_DataSet", dt);
                        Custom_Report.LocalReport.DataSources.Add(ds);
                        Custom_Report.LocalReport.ReportEmbeddedResource = "Project_Transport.Driver_Custom_Report.rdlc";
                        ReportParameter[] param = new ReportParameter[2];
                        param[0] = new ReportParameter("Nos", dt.Rows.Count.ToString());
                        param[1] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                        Custom_Report.LocalReport.SetParameters(param);
                        Custom_Report.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Driver Details Doesnot Exist");
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
                MessageBox.Show("Access Denied");
            }
           
            
        }
        void full_view_Click(object seder, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select DRIVER_NAME,VEHICLE_NUMBER,LICENCE_NUMBER,DATE_FORMAT(expiry,'%d/%m/%Y')AS EXPIRY,LICENCE_TYPE,ADDRESS,BANK_NAME,BRANCH,ACCOUNT_NO,CONTACT,DATE_FORMAT(join_date,'%d/%m/%Y')AS JOIN_DATE from driver_details where bool=0", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MainWindow m = new MainWindow();
                        Custom_Report.Clear();
                        Custom_Report.LocalReport.DataSources.Clear();
                        Custom_Report.Reset();
                        ReportDataSource ds = new ReportDataSource("Driver_Fullview_DataSet", dt);
                        Custom_Report.LocalReport.DataSources.Add(ds);
                        Custom_Report.LocalReport.ReportEmbeddedResource = "Project_Transport.Driver_Full_Report.rdlc";
                        ReportParameter[] param = new ReportParameter[2];
                        param[0] = new ReportParameter("Nos", dt.Rows.Count.ToString());
                        param[1] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                        Custom_Report.LocalReport.SetParameters(param);
                        Custom_Report.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Driver Details Doesnot Exist");
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
                MessageBox.Show("Access Denied");
            }
          
            
        }

       
        void get_driver_details(object sender, RoutedEventArgs e)

        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                Connection con = new Connection();

                if (!String.IsNullOrEmpty(combo.Text) && !String.IsNullOrEmpty(combo1.Text) && !String.IsNullOrEmpty(combo2.Text))
                {
                    try
                    {
                        MainWindow m = new MainWindow();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select total_trips,total_km,total_advance,total_expense,advance_balance,remarks_reason,fine_amount,allowance,salary from driver_remarks where driver_id='" + combo.Text + "' AND remarks_month='" + combo1.Text.Substring(0, 2) + "'  AND remarks_year='" + combo2.Text + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string reason = dt.Rows[0]["remarks_reason"].ToString();
                            string detuct = dt.Rows[0]["fine_amount"].ToString();
                            string allowance = dt.Rows[0]["allowance"].ToString();
                            string salary = dt.Rows[0]["salary"].ToString();
                            string km = dt.Rows[0]["total_km"].ToString();
                            string trip = dt.Rows[0]["total_trips"].ToString();
                            string advance = dt.Rows[0]["total_advance"].ToString();
                            string expense = dt.Rows[0]["total_expense"].ToString();
                            string balance = dt.Rows[0]["advance_balance"].ToString();
                            Custom_Report.Reset();
                            Custom_Report.Clear();
                            ReportParameter[] param = new ReportParameter[13];
                            Custom_Report.LocalReport.ReportEmbeddedResource = "Project_Transport.Driver_Payment_Report.rdlc";
                            param[0] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                            param[1] = new ReportParameter("Id", combo.Text);
                            param[2] = new ReportParameter("Type", combo1.Text.Substring(0, 2) + "/" + combo2.Text);
                            param[3] = new ReportParameter("Date", DateTime.Now.ToShortDateString());
                            param[4] = new ReportParameter("Totalkm", km);
                            param[5] = new ReportParameter("Advance", advance);
                            param[6] = new ReportParameter("Expense", expense);
                            param[7] = new ReportParameter("Balance", balance);
                            param[8] = new ReportParameter("Reason", reason);
                            param[9] = new ReportParameter("Remarks_Amount", detuct);
                            param[10] = new ReportParameter("Allowance", allowance);
                            param[11] = new ReportParameter("Salary", salary);
                            param[12] = new ReportParameter("Trips", trip);
                            Custom_Report.LocalReport.SetParameters(param);
                            Custom_Report.RefreshReport();
                            combo1.Text = ""; combo.Text = ""; combo2.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Payment not Availble");
                            combo1.Text = ""; combo.Text = ""; combo2.Text = "";
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Exception" + ex);
                    }
                }
                else if (!String.IsNullOrEmpty(combo.Text) && !String.IsNullOrEmpty(combo1.Text))
                {
                    try
                    {
                        int year = DateTime.Now.Year;
                        MainWindow m = new MainWindow();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select total_trips,total_km,total_advance,total_expense,advance_balance,remarks_reason,fine_amount,allowance,salary from driver_remarks where driver_id='" + combo.Text + "' AND remarks_month='" + combo1.Text.Substring(0, 2) + "'  AND remarks_year='" + year + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string reason = dt.Rows[0]["remarks_reason"].ToString();
                            string detuct = dt.Rows[0]["fine_amount"].ToString();
                            string allowance = dt.Rows[0]["allowance"].ToString();
                            string salary = dt.Rows[0]["salary"].ToString();
                            string km = dt.Rows[0]["total_km"].ToString();
                            string trip = dt.Rows[0]["total_trips"].ToString();
                            string advance = dt.Rows[0]["total_advance"].ToString();
                            string expense = dt.Rows[0]["total_expense"].ToString();
                            string balance = dt.Rows[0]["advance_balance"].ToString();
                            Custom_Report.Reset();
                            Custom_Report.Clear();
                            ReportParameter[] param = new ReportParameter[13];
                            Custom_Report.LocalReport.ReportEmbeddedResource = "Project_Transport.Driver_Payment_Report.rdlc";
                            param[0] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                            param[1] = new ReportParameter("Id", combo.Text);
                            param[2] = new ReportParameter("Type", combo1.Text.Substring(0, 2) + "/" + year);
                            param[3] = new ReportParameter("Date", DateTime.Now.ToShortDateString());
                            param[4] = new ReportParameter("Totalkm", km);
                            param[5] = new ReportParameter("Advance", advance);
                            param[6] = new ReportParameter("Expense", expense);
                            param[7] = new ReportParameter("Balance", balance);
                            param[8] = new ReportParameter("Reason", reason);
                            param[9] = new ReportParameter("Remarks_Amount", detuct);
                            param[10] = new ReportParameter("Allowance", allowance);
                            param[11] = new ReportParameter("Salary", salary);
                            param[12] = new ReportParameter("Trips", trip);
                            Custom_Report.LocalReport.SetParameters(param);
                            Custom_Report.RefreshReport();
                            combo1.Text = ""; combo.Text = ""; combo2.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Payment not Availble");
                            combo1.Text = ""; combo.Text = ""; combo2.Text = "";
                        }

                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Exception" + ex);
                    }
                }
                else if (!String.IsNullOrEmpty(combo.Text) && !String.IsNullOrEmpty(combo2.Text))
                {
                    try
                    {
                        MainWindow m = new MainWindow();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select remarks_month,total_trips,total_km,allowance,salary,fine_amount,(allowance+salary)-fine_amount as grand_total from driver_remarks where driver_id='" + combo.Text + "'  AND remarks_year='" + combo2.Text + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Custom_Report.Reset();
                            Custom_Report.Clear();
                            Custom_Report.LocalReport.DataSources.Clear();
                            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                            Custom_Report.LocalReport.DataSources.Add(ds);
                            ReportParameter[] param = new ReportParameter[4];
                            Custom_Report.LocalReport.ReportEmbeddedResource = "Project_Transport.Year_Wise_Payment_Report.rdlc";
                            param[0] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                            param[1] = new ReportParameter("Id", combo.Text);
                            param[2] = new ReportParameter("Type", combo2.Text);
                            param[3] = new ReportParameter("Date", DateTime.Now.ToShortDateString());
                            Custom_Report.LocalReport.SetParameters(param);
                            Custom_Report.RefreshReport();
                            combo1.Text = ""; combo.Text = ""; combo2.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Record not Found");
                            combo1.Text = ""; combo.Text = ""; combo2.Text = "";
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Exception" + ex);
                    }
                }
                else if (!String.IsNullOrEmpty(combo.Text))
                {
                    try
                    {
                        MainWindow m = new MainWindow();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select remarks_month,total_trips,total_km,allowance,salary,fine_amount,(allowance+salary)-fine_amount as grand_total from driver_remarks where driver_id='" + combo.Text + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Custom_Report.Reset();
                            Custom_Report.Clear();
                            Custom_Report.LocalReport.DataSources.Clear();
                            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                            Custom_Report.LocalReport.DataSources.Add(ds);
                            ReportParameter[] param = new ReportParameter[4];
                            Custom_Report.LocalReport.ReportEmbeddedResource = "Project_Transport.Year_Wise_Payment_Report.rdlc";
                            param[0] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                            param[1] = new ReportParameter("Id", combo.Text);
                            param[2] = new ReportParameter("Type", "ALL");
                            param[3] = new ReportParameter("Date", DateTime.Now.ToShortDateString());
                            Custom_Report.LocalReport.SetParameters(param);
                            Custom_Report.RefreshReport();
                            combo1.Text = ""; combo.Text = ""; combo2.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Record not Found");
                            combo1.Text = ""; combo.Text = ""; combo2.Text = "";
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Exception" + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }
        
        void Driver_Id_PreviewKeyDown(object sender,KeyEventArgs e)
        {
            //int len = combo.Text.Length;
            //if (e.Key == Key.Back)
            //{
            //    e.Handled = false;
            //}
            //if (len<23)
            //{
            //    for (int i = 0; i < len; i++)
            //    {
            //        if (char.IsDigit(combo.Text[i]) || char.IsLetter(combo.Text[i]))
            //        {

            //        }
            //        else
            //        {
            //            System.Media.SystemSounds.Beep.Play();
            //            e.Handled = true;
            //            MessageBox.Show("Special Character not Allowed");
            //            combo.Text = "";                       
            //        }
            //    }
            //}
            //else
            //{
            //    System.Media.SystemSounds.Beep.Play();
            //    e.Handled = true;
            //}                     
            //var rgex = new Regex("[0-9]{4}");
            //var ok = !rgex.IsMatch(combo.Text);
            //if(Regex.IsMatch(combo.Text,"^[0-9]{4}[A-Za-a]{15}[0-9]{3}$"))
            //{
            //    MessageBox.Show("Driver Id Not Matched");
            //}
        }
        void Month_PreviewKeyDown(object sender,KeyEventArgs e)
        {
            int len = combo1.Text.Length;
            string s = combo1.Text;
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }
           else  if (len == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (char.IsLetter(s[i]))
                    {
                        System.Media.SystemSounds.Beep.Play();
                        e.Handled = true;
                        MessageBox.Show("Should Enter Month Value");
                        combo1.Text = "";
                       
                    }
                    else 
                    {
                        
                    }
                   
                }
                int val = Convert.ToInt32(s);
                if (val > 12)
                {
                    e.Handled = true;
                    MessageBox.Show("Should Enter Month Value 1 to 12");
                    combo1.Text = "";
                }
            }
            else if(len>6)
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
                combo1.Text = "";
            }
        }
        void Year_PreviewKeyDown(object sender,KeyEventArgs e)
        {
            int len = combo2.Text.Length;
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }
            else if (len <= 4)
            {
                for (int i = 0; i < len; i++)
                {
                    if (char.IsDigit(combo2.Text[i]))
                    {

                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                        e.Handled = true;
                        MessageBox.Show("Allowed Numbers Only");
                        combo2.Text = "";

                    }
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
                combo2.Text = "";
            }
        }

        private void combo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(combo.Text))
                {
                    string s = combo.Text;
                    if (Regex.IsMatch(s, "^[0-9]{4}[A-Za-z].*[0-9]{3}"))
                    {
                        //MessageBox.Show("String Not Matched");
                    }
                    else
                    {
                        MessageBox.Show("Driver Id Not in Format");
                        e.Handled = true;
                        combo.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Select Driver Id");
                }
               
            }
           
        }

        private void combo1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(combo1.Text))
                {
                    string s = combo1.Text;
                    if (Regex.IsMatch(s, "^[0-9]{2}[-]{1}[A-Za-z]{3}"))
                    {
                        //MessageBox.Show("String Not Matched");
                    }
                    else
                    {
                        MessageBox.Show("Month Not Matched");
                        e.Handled = true;
                        combo1.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Select Month");
                }
               
            }
        }

        private void combo2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(combo2.Text))
                {
                    string s = combo2.Text;
                    if (Regex.IsMatch(s, "^[0-9]{4}"))
                    {
                        int year = DateTime.Now.Year;
                        int cur = Convert.ToInt32(combo2.Text);
                        if (cur > year)
                        {
                            MessageBox.Show("Year Value is Greater of Current Year");
                            combo2.Text = "";
                            e.Handled = true;
                        }
                        else if (cur < year - 5)
                        {
                            MessageBox.Show("Year Value is Below the Before Five Year");
                            combo2.Text = "";
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Year Not Matched");
                        e.Handled = true;
                        combo2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Select Year");
                }
               
            }
        }

        private void combo_GotFocus(object sender, RoutedEventArgs e)
        {
            int year = DateTime.Now.Year;
            combo2.Items.Clear();
            for (int i = year; i > year - 5; i--)
            {
                combo2.Items.Add(i.ToString());
            }
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("Select distinct driver_id from driver_advance", con.conn);
            OdbcDataReader dr = cmd.ExecuteReader();
            combo.Items.Clear();
            while (dr.Read())
            {
                combo.Items.Add(dr[0]);

            }
            con.close_connection();
        }
    }
}
