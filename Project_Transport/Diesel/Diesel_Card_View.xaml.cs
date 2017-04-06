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
    /// Interaction logic for Diesel_Card_View.xaml
    /// </summary>
    public partial class Diesel_Card_View : UserControl
    {
        
       
        public Diesel_Card_View()
        {
            InitializeComponent();         
        }
       
        void unique_card_view(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER" || user == "USER")
                {
                    if (!string.IsNullOrWhiteSpace(card_view.Text))
                    {
                        if (card_view.Text.Length <= 17)
                        {
                            try
                            {
                                double bal = 0;
                                double balance = 0;
                                Connection con1 = new Connection();
                                con1.open_connection();
                                OdbcCommand cmd2 = new OdbcCommand("select credit_amount from credit_details where card_id='" + card_view.Text + "'", con1.conn);
                                OdbcDataAdapter daa = new OdbcDataAdapter(cmd2);
                                DataTable dtt = new DataTable();
                                daa.Fill(dtt);
                                if (dtt.Rows.Count > 0)
                                {
                                    OdbcCommand cmd = new OdbcCommand("select sum(credit_amount) from credit_details where card_id='" + card_view.Text + "'", con1.conn);
                                    OdbcDataReader dr = cmd.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        bal = Convert.ToDouble(dr[0]);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Records does not Exist");
                                }
                                OdbcCommand cmd4 = new OdbcCommand("select total_cost from diesel_balance_sheet where card_id='" + card_view.Text + "'", con1.conn);
                                OdbcDataAdapter daa1 = new OdbcDataAdapter(cmd2);
                                DataTable dtt1 = new DataTable();
                                daa1.Fill(dtt1);
                                if (dtt1.Rows.Count > 0)
                                {
                                    OdbcCommand cmd3 = new OdbcCommand("select sum(total_cost) from diesel_balance_sheet where card_id='" + card_view.Text + "'", con1.conn);
                                    OdbcDataReader dr1 = cmd3.ExecuteReader();
                                    while (dr1.Read())
                                    {
                                        balance = Convert.ToDouble(dr1[0]);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Records does not Exist");
                                }
                                double d = bal - balance;
                                diesel_balance.Content = Math.Round(d, 2);
                                con1.close_connection();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Allow Combination of 17 Characters and Numbers");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Card Id");
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied");
                }

                
            }
        }

        void trip_diesel_balance_keydown(object sender, KeyEventArgs e)
        {
            
            
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                
                if (trip_diesel_balance.Text.Length >= 13 && trip_diesel_balance.Text.Length <=16)
                {
                    string l = trip_diesel_balance.Text;
                    if(Regex.IsMatch(l,"^[0-9]{6}[A-Za-z]{2}[0-9]{2}"))
                    {
                        try
                        {
                            Connection CON = new Connection();
                            CON.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select CARD_ID,ORIGIN,DESTINATION,PLACE,DATE_FORMAT(fill_date,'%d/%m/%Y') as FILL_DATE,LITTERS,PRICE_PER,TOTAL_COST from diesel_balance_sheet where trip_number='" + trip_diesel_balance.Text + "'", CON.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Report_Viewer.Reset();
                                Report_Viewer.Clear();
                                MainWindow m = new MainWindow();
                                Report_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Trip_Diesel_DataSet", dt);
                                Report_Viewer.LocalReport.DataSources.Add(ds);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Trip_Diesel_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[4];
                                param[0] = new ReportParameter("Title", m.Title_Name.Content.ToString());
                                param[1] = new ReportParameter("TripNumber", trip_diesel_balance.Text);
                                param[2] = new ReportParameter("Origin", dt.Rows[0]["origin"].ToString());
                                param[3] = new ReportParameter("Destination", dt.Rows[0]["destination"].ToString());
                                Report_Viewer.LocalReport.SetParameters(param);
                                Report_Viewer.RefreshReport();
                                trip_diesel_balance.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("TRIP NUMBER Not Exist");
                                trip_diesel_balance.Text = "";
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Trip Number Format");
                    }
                   

                }
                else
                {
                    MessageBox.Show("INCORRECT TRIP NUMBER");
                    trip_diesel_balance.Text = "";
                }
            }
        }


        void card_details_view_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                Connection con = new Connection();
                con.open_connection();
                if (!string.IsNullOrWhiteSpace(card_view.Text))
                {
                    if (card_view.Text.Length <= 17)
                    {
                        try
                        {
                            OdbcCommand cmd1 = new OdbcCommand("select corporation,customer_id,card_id,vehicle_number from diesel_card_details where card_id='" + card_view.Text + "'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Report_Viewer.Reset();
                                Report_Viewer.Clear();
                                Report_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Card_Details_DataSet", dt);
                                Report_Viewer.LocalReport.DataSources.Add(ds);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Card_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[1];
                                param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                                Report_Viewer.LocalReport.SetParameters(param);
                                Report_Viewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Record Doesnot Exist");
                            }
                            // diesel_details_view.ItemsSource = dt.DefaultView;
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Allow Combination of 17 Characters and Numbers");
                        card_view.Text = "";
                    }

                }
                else if (string.IsNullOrWhiteSpace(card_view.Text) || card_view.Text.Equals("ALL"))
                {
                    try
                    {
                        OdbcCommand cmd1 = new OdbcCommand("select corporation,customer_id,card_id,vehicle_number from diesel_card_details", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Report_Viewer.Reset();
                            Report_Viewer.Clear();
                            Report_Viewer.LocalReport.DataSources.Clear();
                            ReportDataSource ds = new ReportDataSource("Card_Details_DataSet", dt);
                            Report_Viewer.LocalReport.DataSources.Add(ds);
                            Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Diesel.Card_Report.rdlc";
                            ReportParameter[] param = new ReportParameter[1];
                            param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                            Report_Viewer.LocalReport.SetParameters(param);
                            Report_Viewer.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("Record Doesnot Exist");
                        }
                        // diesel_details_view.ItemsSource = dt.DefaultView;
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                con.close_connection();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

                             
        }


        void deposit_view_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                Connection con = new Connection();
                con.open_connection();
                if (!string.IsNullOrWhiteSpace(card_view.Text) && !string.IsNullOrWhiteSpace(From.Text) && !string.IsNullOrWhiteSpace(To.Text))
                {
                    if (card_view.Text.Length <= 17)
                    {
                        try
                        {
                            string d1 = Convert.ToDateTime(From.Text).ToString("yyyy/MM/dd");
                            string d2 = Convert.ToDateTime(To.Text).ToString("yyyy/MM/dd");
                            string d3 = Convert.ToDateTime(From.Text).ToString("dd/MM/yyyy");
                            string d4 = Convert.ToDateTime(To.Text).ToString("dd/MM/yyyy");
                            OdbcCommand cmd1 = new OdbcCommand("select corporation,customer_id,card_id,credit_amount,DATE_FORMAT(credit_date,'%d/%m/%Y')as credit_date from credit_details where card_id='" + card_view.Text + "' and credit_date BETWEEN '" + d1 + "' AND '" + d2 + "' and bool=0", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Report_Viewer.Reset();
                                Report_Viewer.Clear();
                                Report_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Card_Deposit_DataSet", dt);
                                Report_Viewer.LocalReport.DataSources.Add(ds);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Deposit_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[3];
                                param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                                param[1] = new ReportParameter("Card", card_view.Text);
                                param[2] = new ReportParameter("Details", "Deposit Details " + d3 + " To " + d4);
                                Report_Viewer.LocalReport.SetParameters(param);
                                Report_Viewer.RefreshReport();
                                To.Text = DateTime.Now.ToShortDateString(); From.Text = "Select Date";
                            }
                            else
                            {
                                MessageBox.Show("Record Doesnot Exist");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Allow Combination of 17 Characters and Numbers");
                        card_view.Text = "";
                    }

                    // diesel_details_view.ItemsSource = dt.DefaultView;
                }
                else if (!string.IsNullOrWhiteSpace(card_view.Text))
                {
                    if (card_view.Text.Length <= 17)
                    {
                        try
                        {
                            OdbcCommand cmd1 = new OdbcCommand("select corporation,customer_id,card_id,credit_amount,DATE_FORMAT(credit_date,'%d/%m/%Y')as credit_date from credit_details where card_id='" + card_view.Text + "' and bool=0 ", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Report_Viewer.Reset();
                                Report_Viewer.Clear();
                                Report_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Card_Deposit_DataSet", dt);
                                Report_Viewer.LocalReport.DataSources.Add(ds);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Deposit_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[3];
                                param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                                param[1] = new ReportParameter("Card", card_view.Text);
                                param[2] = new ReportParameter("Details", "Deposit Details");
                                Report_Viewer.LocalReport.SetParameters(param);
                                Report_Viewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Record Doesnot Exist");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Allow Combination of 17 Characters and Numbers");
                        card_view.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Date Or Card Id");
                }

                con.close_connection();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
        }


        void diesel_entry_view_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                Connection con = new Connection();
                con.open_connection();
                if (!string.IsNullOrWhiteSpace(card_view.Text) && !string.IsNullOrWhiteSpace(From.Text) && !string.IsNullOrWhiteSpace(To.Text))
                {
                    if (card_view.Text.Length <= 17)
                    {
                        try
                        {
                            string d1 = Convert.ToDateTime(From.Text).ToString("yyyy/MM/dd");
                            string d2 = Convert.ToDateTime(To.Text).ToString("yyyy/MM/dd");
                            string d3 = Convert.ToDateTime(From.Text).ToString("dd/MM/yyyy");
                            string d4 = Convert.ToDateTime(To.Text).ToString("dd/MM/yyyy");
                            OdbcCommand cmd1 = new OdbcCommand("select TRIP_NUMBER,CARD_ID,ORIGIN,DESTINATION,PLACE,DATE_FORMAT(fill_date,'%d/%m/%Y') as FILL_DATE,LITTERS,PRICE_PER,TOTAL_COST from diesel_balance_sheet where card_id='" + card_view.Text + "' and fill_date BETWEEN '" + d1 + "' AND '" + d2 + "'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Report_Viewer.Reset();
                                Report_Viewer.Clear();
                                Report_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Diesel_Entry_DataSet", dt);
                                Report_Viewer.LocalReport.DataSources.Add(ds);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Diesel_Entry_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[3];
                                param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                                param[1] = new ReportParameter("CardNumber", card_view.Text);
                                param[2] = new ReportParameter("Details", "Diesel Entry " + d3 + " To " + d4);
                                Report_Viewer.LocalReport.SetParameters(param);
                                Report_Viewer.RefreshReport();
                                To.Text = DateTime.Now.ToShortDateString(); From.Text = "Select Date";
                            }
                            else
                            {
                                MessageBox.Show("Record Doesnot Exist");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Allow Combination of 17 Characters and Numbers");
                        card_view.Text = "";
                    }

                    //diesel_details_view.ItemsSource = dt.DefaultView;
                }
                else if (!string.IsNullOrWhiteSpace(card_view.Text))
                {
                    if (card_view.Text.Length <= 17)
                    {
                        try
                        {
                            OdbcCommand cmd1 = new OdbcCommand("select TRIP_NUMBER,CARD_ID,ORIGIN,DESTINATION,PLACE,DATE_FORMAT(fill_date,'%d/%m/%Y') as FILL_DATE,LITTERS,PRICE_PER,TOTAL_COST from diesel_balance_sheet where card_id='" + card_view.Text + "' ", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Report_Viewer.Reset();
                                Report_Viewer.Clear();
                                Report_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Diesel_Entry_DataSet", dt);
                                Report_Viewer.LocalReport.DataSources.Add(ds);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Diesel_Entry_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[3];
                                param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                                param[1] = new ReportParameter("CardNumber", card_view.Text);
                                param[2] = new ReportParameter("Details", "Diesel Entry Details");
                                Report_Viewer.LocalReport.SetParameters(param);
                                Report_Viewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Record Doesnot Exist");
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Allow Combination of 17 Characters and Numbers");
                        card_view.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Date Or Card Id");
                }

                con.close_connection();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }                  
        }


        void deposit_diesel_entry_view_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    if (!string.IsNullOrWhiteSpace(card_view.Text) && !string.IsNullOrWhiteSpace(From.Text) && !string.IsNullOrWhiteSpace(To.Text))
                    {
                        if (card_view.Text.Length <= 17)
                        {
                            try
                            {
                                string d1 = Convert.ToDateTime(From.Text).ToString("yyyy/MM/dd");
                                string d2 = Convert.ToDateTime(To.Text).ToString("yyyy/MM/dd");
                                string d3 = Convert.ToDateTime(From.Text).ToString("dd/MM/yyyy");
                                string d4 = Convert.ToDateTime(To.Text).ToString("dd/MM/yyyy");
                                OdbcCommand cmd1 = new OdbcCommand("select card_id,credit_amount,DATE_FORMAT(credit_date,'%d/%m/%Y')as credit_date from credit_details  where card_id='" + card_view.Text + "' and credit_date BETWEEN '" + d1 + "' AND '" + d2 + "' and bool=0", con.conn);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataSet dt1 = new DataSet();
                                da1.Fill(dt1);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Deposit_Diesel_Report.rdlc";
                                OdbcCommand cmd = new OdbcCommand("select ORIGIN,DESTINATION,PLACE,DATE_FORMAT(fill_date,'%d/%m/%Y') as FILL_DATE,LITTERS,PRICE_PER,TOTAL_COST from diesel_balance_sheet  where card_id='" + card_view.Text + "' and fill_date BETWEEN '" + d1 + "' AND '" + d2 + "'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataSet dt = new DataSet();
                                da.Fill(dt);
                                Report_Viewer.Reset();
                                Report_Viewer.Clear();
                                Report_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds1 = new ReportDataSource("Diesel_Deposit_DataSet", dt1.Tables[0]);
                                ReportDataSource ds2 = new ReportDataSource("Diesel_DataSet", dt.Tables[0]);
                                Report_Viewer.LocalReport.DataSources.Add(ds1);
                                Report_Viewer.LocalReport.DataSources.Add(ds2);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Diesel_Deposit_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[3];
                                param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                                param[1] = new ReportParameter("Id", card_view.Text);
                                param[2] = new ReportParameter("Date", "Deposit & Withdraw " + d3 + " To " + d4);
                                Report_Viewer.LocalReport.SetParameters(param);
                                Report_Viewer.RefreshReport();
                                To.Text = DateTime.Now.ToShortDateString(); From.Text = "Select Date";
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Allow Combination of 17 Characters and Numbers");
                            card_view.Text = "";
                        }


                    }
                    else if (!string.IsNullOrWhiteSpace(card_view.Text))
                    {
                        if (card_view.Text.Length <= 17)
                        {
                            try
                            {
                                OdbcCommand cmd1 = new OdbcCommand("select credit_amount,DATE_FORMAT(credit_date,'%d/%m/%Y')as credit_date from credit_details  where card_id='" + card_view.Text + "' and bool=0", con.conn);
                                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                                DataSet dt1 = new DataSet();
                                da1.Fill(dt1);
                                //int i = dt1.Rows.Count;
                                //Report_Viewer.Reset();                          
                                OdbcCommand cmd = new OdbcCommand("select ORIGIN,DESTINATION,PLACE,DATE_FORMAT(fill_date,'%d/%m/%Y') as FILL_DATE,LITTERS,PRICE_PER,TOTAL_COST from diesel_balance_sheet  where card_id='" + card_view.Text + "'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataSet dt = new DataSet();
                                da.Fill(dt);
                                Report_Viewer.Reset();
                                Report_Viewer.Clear();
                                Report_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds1 = new ReportDataSource("Diesel_Deposit_DataSet", dt1.Tables[0]);
                                //Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Diesel_Deposit_Report.rdlc";                           
                                ReportDataSource ds2 = new ReportDataSource("Diesel_DataSet", dt.Tables[0]);
                                Report_Viewer.LocalReport.DataSources.Add(ds1);
                                Report_Viewer.LocalReport.DataSources.Add(ds2);
                                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Diesel_Deposit_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[3];
                                param[0] = new ReportParameter("Title", Properties.Settings.Default.Title);
                                param[1] = new ReportParameter("Id", card_view.Text);
                                param[2] = new ReportParameter("Date", "Card Deposit & Withdraw Details");
                                Report_Viewer.LocalReport.SetParameters(param);
                                Report_Viewer.RefreshReport();
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Allow Combination of 17 Characters and Numbers");
                            card_view.Text = "";
                        }

                    }
                    else
                    {
                        MessageBox.Show("Invalid Date Or Card Id");
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

        private void card_view_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select card_id from diesel_card_details where bool=0", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    card_view.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        card_view.Items.Add(dt.Rows[i]["card_id"]);
                    }
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }
    }
}
 