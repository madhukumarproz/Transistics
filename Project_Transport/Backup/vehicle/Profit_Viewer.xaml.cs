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
    /// Interaction logic for Profit_Viewer.xaml
    /// </summary>
    public partial class Profit_Viewer : UserControl
    {
        public Profit_Viewer()
        {
            InitializeComponent();
            year_cmbbox.Items.Clear();
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            for (int i = 1; i < 6; i++)
            {
                year_cmbbox.Items.Add(year);
                year -= 1;
            }
            Get_String g = new Get_String();
            g.Report_Month = "";
            g.Report_Year = "";
            this.DataContext = g;
            month_cmbbox.IsEnabled = false;
            year_cmbbox.IsEnabled = false;
            

        }
        void Profit_Viewer_Month_Checked(object sender,RoutedEventArgs e)
        {
            month_cmbbox.IsEnabled = true;
        }
        void Profit_Viewer_Month_Unchecked(object sender, RoutedEventArgs e)
        {
            month_cmbbox.IsEnabled = false;
            month_cmbbox.Text = "";
        }
        void Profit_Viewer_Year_Checked(object sender, RoutedEventArgs e)
        {
            year_cmbbox.IsEnabled = true;
        }
        void Profit_Viewer_Year_Unchecked(object sender, RoutedEventArgs e)
        {
            year_cmbbox.IsEnabled = false;
            year_cmbbox.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.open_connection();
            con.connection_string();
            string d = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy");
            string d1 = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            string month_number = null;
            string month_string = null;
            //string MONTH = null;
            string total_trip = "0";
            string total_km = "0";
            string diesel = "0";
            string total_expense = "0";
            string driver_payment = "0";
            string cliner_payment = "Nil";
            string avg_mileage = "0";           
            string frieght = "0";
            string grand_total = "0";
            string maintenance = "0";
            string tyre = "0";            
            string diesel_total_amount = "0";
            if(!string.IsNullOrWhiteSpace(month_cmbbox.Text))
            {
                 month_number = month_cmbbox.Text.Substring(0, 2);
                 month_string = month_cmbbox.Text.Substring(month_cmbbox.Text.Length - 3, 3);
                 
            }
           
            if (Month_chkbox.IsChecked == true && Year_chkbox.IsChecked == true && !string.IsNullOrWhiteSpace(month_cmbbox.Text) && !string.IsNullOrWhiteSpace(year_cmbbox.Text)&& !string.IsNullOrWhiteSpace(vehicle_cmbbox.Text))
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("select count(*) as nos,sum(total_km) as km,sum(trip_diesel)as diesel,sum(trip_frieght) as frieght,sum(trip_expense) as expense,sum(diesel_amount) as amount,avg(trip_mileage) as mileage from lpg_trip_details where month(load_date)='" + month_number + "' and year(load_date)='" + year_cmbbox.Text + "' and vehicle_number='" + vehicle_cmbbox.Text + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        total_km = dt.Rows[0]["km"].ToString();
                        frieght = dt.Rows[0]["frieght"].ToString();
                        total_expense = dt.Rows[0]["expense"].ToString();
                        diesel = dt.Rows[0]["diesel"].ToString();
                        avg_mileage = dt.Rows[0]["mileage"].ToString();
                        diesel_total_amount = dt.Rows[0]["amount"].ToString();
                        total_trip = dt.Rows[0]["nos"].ToString();
                        if (total_km == "" && diesel == "")
                        {
                            total_km = "0"; total_trip = "0"; frieght = "0"; total_expense = "0"; diesel = "0"; diesel_total_amount = "0";
                            avg_mileage = "0";
                        }


                    }
                    string sub = vehicle_cmbbox.Text.Substring(vehicle_cmbbox.Text.Length - 4, 4);
                    string vnum = Regex.Replace(sub, "[^0-9]", string.Empty);
                    OdbcCommand cmd1 = new OdbcCommand("select  sum(allowance+salary) as driver_pay,sum(fine_amount) as fine  from driver_remarks where remarks_month='" + month_number + "' and remarks_year='" + year_cmbbox.Text + "' and driver_id like '" + '%' + vnum + "'", con.conn);
                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        double s1 = 0;
                        double s2 = 0;
                        if (!string.IsNullOrWhiteSpace(dt1.Rows[0]["driver_pay"].ToString()))
                        {
                            s1 = Convert.ToDouble(dt1.Rows[0]["driver_pay"]);
                        }
                        if (!string.IsNullOrWhiteSpace(dt1.Rows[0]["fine"].ToString()))
                        {
                            s2 = Convert.ToDouble(dt1.Rows[0]["fine"]);
                        }

                        driver_payment = (s1 - s2).ToString();
                        if (driver_payment == "")
                        {
                            driver_payment = "0";
                        }
                    }
                    OdbcCommand cmd2 = new OdbcCommand("select sum(gnd_total) as total from expense_bill  where month(bill_date)='" + month_number + "' and year(bill_date)='" + year_cmbbox.Text + "' and vehicle='" + vehicle_cmbbox.Text + "'", con.str);
                    OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        maintenance = dt2.Rows[0]["total"].ToString();
                        if (maintenance == "")
                        {
                            maintenance = "0";
                        }
                    }
                    OdbcCommand cmd3 = new OdbcCommand("select sum(price) as Price from tyre_price where month(date)='" + month_number + "' and year(date)='" + year_cmbbox.Text + "' and vehicle_number='" + vehicle_cmbbox.Text + "'", con.str);
                    OdbcDataAdapter da3 = new OdbcDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    if (dt3.Rows.Count > 0)
                    {
                        tyre = dt3.Rows[0]["Price"].ToString();
                        if (tyre == "")
                        {
                            tyre = "0";
                        }
                    }
                    grand_total = (Convert.ToDouble(frieght) - Convert.ToDouble(driver_payment) - Convert.ToDouble(maintenance) - Convert.ToDouble(tyre) - Convert.ToDouble(total_expense) - Convert.ToDouble(diesel_total_amount)).ToString();
                   
                    maintenance = (Convert.ToDouble(tyre) + Convert.ToDouble(maintenance)).ToString();
                    if (Convert.ToDouble(grand_total) > 0)
                    {
                        cliner_payment = "Profit Amount";
                    }
                    else if (Convert.ToDouble(grand_total) < 0)
                    {
                        cliner_payment = "Loss Amount";
                    }
                    ReportView.LocalReport.ReportEmbeddedResource = "Project_Transport.Profit_Report.rdlc";
                    ReportParameter[] param = new ReportParameter[14];
                    param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                    param[1] = new ReportParameter("Type", month_string + "/" + year_cmbbox.Text);
                    param[2] = new ReportParameter("Vehicle", vehicle_cmbbox.Text);
                    param[3] = new ReportParameter("TotalTrips", total_trip);
                    param[4] = new ReportParameter("Expense", total_expense);
                    param[5] = new ReportParameter("Driver", driver_payment);
                    param[6] = new ReportParameter("Mileage", avg_mileage);
                    param[7] = new ReportParameter("ProfitLoss", cliner_payment);
                    param[8] = new ReportParameter("Diesel", diesel_total_amount);
                    param[9] = new ReportParameter("Frieght", frieght);
                    param[10] = new ReportParameter("GrandTotal", grand_total);
                    param[11] = new ReportParameter("Date", d1);
                    param[12] = new ReportParameter("TotalKm", total_km);
                    param[13] = new ReportParameter("Maintenance", maintenance);

                    ReportView.LocalReport.SetParameters(param);
                    this.ReportView.RefreshReport();

                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
                           }
            else if (Month_chkbox.IsChecked == true && !string.IsNullOrWhiteSpace(month_cmbbox.Text) && !string.IsNullOrWhiteSpace(vehicle_cmbbox.Text))
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("select count(*) as nos,sum(total_km) as km,sum(trip_diesel)as diesel,sum(trip_frieght) as frieght,sum(trip_expense) as expense,sum(diesel_amount) as amount,avg(trip_mileage) as mileage from lpg_trip_details where month(load_date)='" + month_number + "' and year(load_date)='" + d + "' and vehicle_number='" + vehicle_cmbbox.Text + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        total_km = dt.Rows[0]["km"].ToString();
                        frieght = dt.Rows[0]["frieght"].ToString();
                        total_expense = dt.Rows[0]["expense"].ToString();
                        diesel = dt.Rows[0]["diesel"].ToString();
                        avg_mileage = dt.Rows[0]["mileage"].ToString();
                        diesel_total_amount = dt.Rows[0]["amount"].ToString();
                        total_trip = dt.Rows[0]["nos"].ToString();
                        if (total_km == "" && diesel == "")
                        {
                            total_km = "0"; total_trip = "0"; frieght = "0"; total_expense = "0"; diesel = "0"; diesel_total_amount = "0";
                            avg_mileage = "0";
                        }

                    }
                    string sub = vehicle_cmbbox.Text.Substring(vehicle_cmbbox.Text.Length - 4, 4);
                    string vnum = Regex.Replace(sub, "[^0-9]", string.Empty);
                    OdbcCommand cmd1 = new OdbcCommand("select  sum(allowance+salary) as driver_pay,sum(fine_amount) as fine  from driver_remarks where remarks_month='" + month_number + "' and remarks_year='" + d + "' and driver_id like '" + '%' + vnum + "'", con.conn);
                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        double s1 = 0;
                        double s2 = 0;
                        if (!string.IsNullOrWhiteSpace(dt1.Rows[0]["driver_pay"].ToString()))
                        {
                            s1 = Convert.ToDouble(dt1.Rows[0]["driver_pay"]);
                        }
                        if (!string.IsNullOrWhiteSpace(dt1.Rows[0]["fine"].ToString()))
                        {
                            s2 = Convert.ToDouble(dt1.Rows[0]["fine"]);
                        }

                        driver_payment = (s1 - s2).ToString();
                        if (driver_payment == "")
                        {
                            driver_payment = "0";
                        }
                    }
                    OdbcCommand cmd2 = new OdbcCommand("select sum(gnd_total) as total from expense_bill  where month(bill_date)='" + month_number + "' and year(bill_date)='" + d + "' and vehicle='" + vehicle_cmbbox.Text + "'", con.str);
                    OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        maintenance = dt2.Rows[0]["total"].ToString();
                        if (maintenance == "")
                        {
                            maintenance = "0";
                        }
                    }
                    OdbcCommand cmd3 = new OdbcCommand("select sum(price) as Price from tyre_price where month(date)='" + month_number + "' and year(date)='" + d + "' and vehicle_number='" + vehicle_cmbbox.Text + "'", con.str);
                    OdbcDataAdapter da3 = new OdbcDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    if (dt3.Rows.Count > 0)
                    {
                        tyre = dt3.Rows[0]["Price"].ToString();
                        if (tyre == "")
                        {
                            tyre = "0";
                        }
                    }
                    grand_total = (Convert.ToDouble(frieght) - Convert.ToDouble(total_expense) - Convert.ToDouble(driver_payment) - Convert.ToDouble(maintenance) - Convert.ToDouble(tyre) - Convert.ToDouble(diesel_total_amount)).ToString();
                    
                    maintenance = (Convert.ToDouble(tyre) + Convert.ToDouble(maintenance)).ToString();
                    if (Convert.ToDouble(grand_total) > 0)
                    {
                        cliner_payment = "Profit Amount";
                    }
                    else if (Convert.ToDouble(grand_total) < 0)
                    {
                        cliner_payment = "Loss Amount";
                    }
                    ReportView.LocalReport.ReportEmbeddedResource = "Project_Transport.Profit_Report.rdlc";
                    ReportParameter[] param = new ReportParameter[14];
                    param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                    param[1] = new ReportParameter("Type", month_string + "/" + year_cmbbox.Text);
                    param[2] = new ReportParameter("Vehicle", vehicle_cmbbox.Text);
                    param[3] = new ReportParameter("TotalTrips", total_trip);
                    param[4] = new ReportParameter("Expense", total_expense);
                    param[5] = new ReportParameter("Driver", driver_payment);
                    param[6] = new ReportParameter("Mileage", avg_mileage);
                    param[7] = new ReportParameter("ProfitLoss", cliner_payment);
                    param[8] = new ReportParameter("Diesel", diesel_total_amount);
                    param[9] = new ReportParameter("Frieght", frieght);
                    param[10] = new ReportParameter("GrandTotal", grand_total);
                    param[11] = new ReportParameter("Date", d1);
                    param[12] = new ReportParameter("TotalKm", total_km);
                    param[13] = new ReportParameter("Maintenance", maintenance);
                    ReportView.LocalReport.SetParameters(param);
                    this.ReportView.RefreshReport();
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
                
            }
            else if (Year_chkbox.IsChecked == true && !string.IsNullOrWhiteSpace(year_cmbbox.Text) && !string.IsNullOrWhiteSpace(vehicle_cmbbox.Text))
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("select count(*) as nos,sum(total_km) as km,sum(trip_diesel)as diesel,sum(trip_frieght) as frieght,sum(trip_expense) as expense,sum(diesel_amount) as amount,avg(trip_mileage) as mileage from lpg_trip_details where  year(load_date)='" + year_cmbbox.Text + "' and vehicle_number='" + vehicle_cmbbox.Text + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        total_km = dt.Rows[0]["km"].ToString();
                        frieght = dt.Rows[0]["frieght"].ToString();
                        total_expense = dt.Rows[0]["expense"].ToString();
                        diesel = dt.Rows[0]["diesel"].ToString();
                        avg_mileage = dt.Rows[0]["mileage"].ToString();
                        diesel_total_amount = dt.Rows[0]["amount"].ToString();
                        total_trip = dt.Rows[0]["nos"].ToString();
                        if (total_km == "" && diesel == "")
                        {
                            total_km = "0"; total_trip = "0"; frieght = "0"; total_expense = "0"; diesel = "0"; diesel_total_amount = "0";
                            avg_mileage = "0";
                        }

                    }
                    string sub = vehicle_cmbbox.Text.Substring(vehicle_cmbbox.Text.Length - 4, 4);
                    string vnum = Regex.Replace(sub, "[^0-9]", string.Empty);
                    OdbcCommand cmd1 = new OdbcCommand("select  sum(allowance+salary) as driver_pay,sum(fine_amount) as fine  from driver_remarks where remarks_year='" + year_cmbbox.Text + "' and driver_id like '" + '%' + vnum + "'", con.conn);
                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        double s1 = 0;
                        double s2 = 0;
                        if (!string.IsNullOrWhiteSpace(dt1.Rows[0]["driver_pay"].ToString()))
                        {
                            s1 = Convert.ToDouble(dt1.Rows[0]["driver_pay"]);
                        }
                        if (!string.IsNullOrWhiteSpace(dt1.Rows[0]["fine"].ToString()))
                        {
                            s2 = Convert.ToDouble(dt1.Rows[0]["fine"]);
                        }

                        driver_payment = (s1 - s2).ToString();
                        if (driver_payment == "")
                        {
                            driver_payment = "0";
                        }
                    }
                    OdbcCommand cmd2 = new OdbcCommand("select sum(gnd_total) as total from expense_bill  where  year(bill_date)='" + year_cmbbox.Text + "' and vehicle='" + vehicle_cmbbox.Text + "'", con.str);
                    OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        maintenance = dt2.Rows[0]["total"].ToString();
                        if (maintenance == "")
                        {
                            maintenance = "0";
                        }
                    }
                    OdbcCommand cmd3 = new OdbcCommand("select sum(price) as Price from tyre_price where  year(date)='" + year_cmbbox.Text + "' and vehicle_number='" + vehicle_cmbbox.Text + "'", con.str);
                    OdbcDataAdapter da3 = new OdbcDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    if (dt3.Rows.Count > 0)
                    {
                        tyre = dt3.Rows[0]["Price"].ToString();
                        if (tyre == "")
                        {
                            tyre = "0";
                        }
                    }
                    grand_total = (Convert.ToDouble(frieght) - Convert.ToDouble(total_expense) - Convert.ToDouble(driver_payment) - Convert.ToDouble(maintenance) - Convert.ToDouble(tyre) - Convert.ToDouble(diesel_total_amount)).ToString();
                   
                    maintenance = (Convert.ToDouble(tyre) + Convert.ToDouble(maintenance)).ToString();
                    if (Convert.ToDouble(grand_total) > 0)
                    {
                        cliner_payment = "Profit Amount";
                    }
                    else if (Convert.ToDouble(grand_total) < 0)
                    {
                        cliner_payment = "Loss Amount";
                    }
                    ReportView.LocalReport.ReportEmbeddedResource = "Project_Transport.Profit_Report.rdlc";
                    ReportParameter[] param = new ReportParameter[14];
                    param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                    param[1] = new ReportParameter("Type", month_string + "/" + year_cmbbox.Text);
                    param[2] = new ReportParameter("Vehicle", vehicle_cmbbox.Text);
                    param[3] = new ReportParameter("TotalTrips", total_trip);
                    param[4] = new ReportParameter("Expense", total_expense);
                    param[5] = new ReportParameter("Driver", driver_payment);
                    param[6] = new ReportParameter("Mileage", avg_mileage);
                    param[7] = new ReportParameter("ProfitLoss", cliner_payment);
                    param[8] = new ReportParameter("Diesel", diesel_total_amount);
                    param[9] = new ReportParameter("Frieght", frieght);
                    param[10] = new ReportParameter("GrandTotal", grand_total);
                    param[11] = new ReportParameter("Date", d1);
                    param[12] = new ReportParameter("TotalKm", total_km);
                    param[13] = new ReportParameter("Maintenance", maintenance);
                    ReportView.LocalReport.SetParameters(param);
                    this.ReportView.RefreshReport();
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
               
            }
            else
            {
                MessageBox.Show("Should Fill Empty Text Box");
            }


        }
        void Profit_View_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            string s = vehicle_cmbbox.Text;
            if (!string.IsNullOrWhiteSpace(vehicle_cmbbox.Text))
            {

                len = vehicle_cmbbox.Text.Length;
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
                        vehicle_cmbbox.Text = "";
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
        void Profit_View_Month_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            string s = month_cmbbox.Text;
            if (!string.IsNullOrWhiteSpace(month_cmbbox.Text))
            {

                len = month_cmbbox.Text.Length;
            }
            else
            {
                len = 0;
            }
            if (len <= 2)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isdigit = char.IsDigit(s[i]);
                    if (isdigit == true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Should Enter First Two Letter Character");
                        month_cmbbox.Text = "";
                    }
                }
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
        void Profit_View_Year_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            string s = year_cmbbox.Text;
            if (!string.IsNullOrWhiteSpace(year_cmbbox.Text))
            {

                len = year_cmbbox.Text.Length;
            }
            else
            {
                len = 0;
            }
            if (len <= 4)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Should Enter First Two Letter Character");
                        vehicle_cmbbox.Text = "";
                    }
                }
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

        private void vehicle_cmbbox_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details", con.conn);
                OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        vehicle_cmbbox.Items.Add(DT.Rows[i]["vehicle_number"]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error Load Vehicle Details");
            }
        }
    }
}
