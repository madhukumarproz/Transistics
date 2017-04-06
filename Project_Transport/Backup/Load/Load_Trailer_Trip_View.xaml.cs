using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows;
using System.Windows.Controls;


namespace Project_Transport 
{
    /// <summary>
    /// Interaction logic for Load_Trailer_Trip_View.xaml
    /// </summary>
    public partial class Load_Trailer_Trip_View : UserControl
    {
        public Load_Trailer_Trip_View()
        {
            InitializeComponent();
        }
        int n = 0;
        private void show_Click(object sender, RoutedEventArgs e)
        {
            if (tripload.IsChecked == true && (!String.IsNullOrWhiteSpace(vhlno.Text)))
            {

                host.Visibility = Visibility.Visible;
                ReportViewer.Reset();
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select DATE_FORMAT(loaddate,'%d-%m-%Y')AS LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight from load_trip_details WHERE vehiclenumber='" + vhlno.Text + "' and tripstatus=1", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Load_Viewrdlc.rdlc";

                        ReportParameter[] parameter = new ReportParameter[16];
                        parameter[0] = new ReportParameter("Vehicle_Number", vhlno.Text);
                        parameter[1] = new ReportParameter("Date", DateTime.Now.ToShortDateString());
                        parameter[2] = new ReportParameter("from", dt.Rows[0]["Origin"].ToString());
                        parameter[3] = new ReportParameter("to", dt.Rows[0]["Destination"].ToString());
                        parameter[4] = new ReportParameter("Starting_km", dt.Rows[0]["Startingkm"].ToString());
                        parameter[5] = new ReportParameter("challon_no", dt.Rows[0]["ChallonNo"].ToString());
                        parameter[6] = new ReportParameter("driver_advance", dt.Rows[0]["DriverAdvance"].ToString());
                        parameter[7] = new ReportParameter("load_advance", dt.Rows[0]["LoadAdvance"].ToString());
                        parameter[8] = new ReportParameter("freight", dt.Rows[0]["TripFrieght"].ToString());
                        parameter[9] = new ReportParameter("cliner_name", dt.Rows[0]["ClinerName"].ToString());
                        parameter[10] = new ReportParameter("load_type", dt.Rows[0]["LoadType"].ToString());
                        parameter[11] = new ReportParameter("load_weight", dt.Rows[0]["LoadWeight"].ToString());
                        parameter[12] = new ReportParameter("Title", Properties.Settings.Default.Title);
                        parameter[13] = new ReportParameter("Load_Date", dt.Rows[0]["LoadDate"].ToString());
                        parameter[14] = new ReportParameter("driver_id", dt.Rows[0]["DriverId"].ToString());
                        parameter[15] = new ReportParameter("load_name", dt.Rows[0]["LoadName"].ToString());
                        this.ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Record Doesnot Exist");
                    }
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }
               
            }
            else if (tripunload.IsChecked == true && (!String.IsNullOrWhiteSpace(vhlno.Text)) && (!string.IsNullOrWhiteSpace(startdate.Text)) && (!string.IsNullOrWhiteSpace(enddate.Text)))
            {
                host.Visibility = Visibility.Visible;
                ReportViewer.Reset();
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select TripNumber,DATE_FORMAT(loaddate,'%d-%m-%Y')AS LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight,DATE_FORMAT(unloaddate,'%d-%m-%Y')AS UnloadDate,EndingKm,TotalKm,UnloadWeight,Payment from load_trip_details where UnloadDate between '" + Convert.ToDateTime(startdate.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(enddate.Text).ToString("yyyy-MM-dd") + "' and vehiclenumber='" + vhlno.Text + "' and tripstatus=2", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportDataSource ds = new ReportDataSource("Unload", dt);
                        ReportViewer.LocalReport.DataSources.Add(ds);
                        ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Unload.rdlc";
                        ReportParameter[] parameter = new ReportParameter[3];
                        parameter[0] = new ReportParameter("vehicle_number", vhlno.Text);
                        parameter[1] = new ReportParameter("date", DateTime.Now.ToShortDateString());
                        parameter[2] = new ReportParameter("title", Properties.Settings.Default.Title);
                        this.ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Record Doesnot Exist");
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }
                startdate.Text = "";
            }
            else if (tripunload.IsChecked == true && (!String.IsNullOrWhiteSpace(vhlno.Text)))

            {
                host.Visibility = Visibility.Visible;              
                ReportViewer.Reset();
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select TripNumber,DATE_FORMAT(loaddate,'%d-%m-%Y')AS LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight,DATE_FORMAT(unloaddate,'%d-%m-%Y')AS UnloadDate,EndingKm,TotalKm,UnloadWeight,Payment from load_trip_details WHERE vehiclenumber='" + vhlno.Text + "' and tripstatus=2", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportDataSource ds = new ReportDataSource("Unload", dt);
                        ReportViewer.LocalReport.DataSources.Add(ds);
                        ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Unload.rdlc";
                        ReportParameter[] parameter = new ReportParameter[3];
                        parameter[0] = new ReportParameter("vehicle_number", vhlno.Text);
                        parameter[1] = new ReportParameter("date", DateTime.Now.ToShortDateString());
                        parameter[2] = new ReportParameter("title", Properties.Settings.Default.Title);
                        this.ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Record Doesnot Exist");
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }
                
            }
           
            else if (tripunload.IsChecked == true && (!String.IsNullOrWhiteSpace(tripnum.Text)))
            {
                host.Visibility = Visibility.Visible;
                ReportViewer.Reset();
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select DATE_FORMAT(loaddate,'%d-%m-%Y')AS LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight,DATE_FORMAT(unloaddate,'%d-%m-%Y')AS UnloadDate,EndingKm,TotalKm,UnloadWeight,Payment from load_trip_details WHERE tripnumber='" + tripnum.Text + "' and tripstatus=2", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Unload_View.rdlc";
                        ReportParameter[] parameter = new ReportParameter[21];
                        parameter[0] = new ReportParameter("trip_number", tripnum.Text);
                        parameter[1] = new ReportParameter("date", DateTime.Now.ToShortDateString());
                        parameter[2] = new ReportParameter("unload_date", dt.Rows[0]["UnLoadDate"].ToString());
                        parameter[3] = new ReportParameter("ending_km", dt.Rows[0]["EndingKm"].ToString());
                        parameter[4] = new ReportParameter("total_km", dt.Rows[0]["TotalKm"].ToString());
                        parameter[5] = new ReportParameter("unload_weight", dt.Rows[0]["UnloadWeight"].ToString());
                        parameter[6] = new ReportParameter("payment", dt.Rows[0]["Payment"].ToString());
                        parameter[7] = new ReportParameter("title", Properties.Settings.Default.Title);
                        parameter[8] = new ReportParameter("origin", dt.Rows[0]["Origin"].ToString());
                        parameter[9] = new ReportParameter("destination", dt.Rows[0]["Destination"].ToString());
                        parameter[10] = new ReportParameter("starting_km", dt.Rows[0]["Startingkm"].ToString());
                        parameter[11] = new ReportParameter("challon_no", dt.Rows[0]["ChallonNo"].ToString());
                        parameter[12] = new ReportParameter("driver_advance", dt.Rows[0]["DriverAdvance"].ToString());
                        parameter[13] = new ReportParameter("load_advance", dt.Rows[0]["LoadAdvance"].ToString());
                        parameter[14] = new ReportParameter("freight", dt.Rows[0]["TripFrieght"].ToString());
                        parameter[15] = new ReportParameter("cliner_name", dt.Rows[0]["ClinerName"].ToString());
                        parameter[16] = new ReportParameter("load_type", dt.Rows[0]["LoadType"].ToString());
                        parameter[17] = new ReportParameter("load_weight", dt.Rows[0]["LoadWeight"].ToString());
                        parameter[18] = new ReportParameter("load_date", dt.Rows[0]["LoadDate"].ToString());
                        parameter[19] = new ReportParameter("driver_id", dt.Rows[0]["DriverId"].ToString());
                        parameter[20] = new ReportParameter("load_name", dt.Rows[0]["LoadName"].ToString());
                        this.ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Record Doesnot Exist");
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }
                
            }
            else if (tripclose.IsChecked == true && (!String.IsNullOrWhiteSpace(vhlno.Text)) && (!string.IsNullOrWhiteSpace(startdate.Text)) && (!string.IsNullOrWhiteSpace(enddate.Text)))
            {
                host.Visibility = Visibility.Visible;
                ReportViewer.Reset();
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select DATE_FORMAT(loaddate,'%d-%m-%Y')AS LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight,DATE_FORMAT(unloaddate,'%d-%m-%Y')AS UnloadDate,EndingKm,TotalKm,UnloadWeight,Payment,TripExpense,TripDiesel,DieselAmount,TripMileage,FrieghtReduction,TripProfit from load_trip_details where LastUpdated between '" +Convert.ToDateTime( startdate.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(enddate.Text).ToString("yyyy-MM-dd") + "' and vehiclenumber='" + vhlno.Text + "' and tripstatus=0", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportDataSource ds = new ReportDataSource("Close_View", dt);
                        ReportViewer.LocalReport.DataSources.Add(ds);
                        ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Close_View.rdlc";
                        ReportParameter[] parameter = new ReportParameter[4];
                        parameter[0] = new ReportParameter("vehicle_number", vhlno.Text);
                        parameter[1] = new ReportParameter("vhnum", "Vehicle Number");
                        parameter[2] = new ReportParameter("date", DateTime.Now.ToShortDateString());
                        parameter[3] = new ReportParameter("title", Properties.Settings.Default.Title);
                        this.ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Record Doesnot Exist");
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }
                startdate.Text = "";
            }
            else if (tripclose.IsChecked == true && (!String.IsNullOrWhiteSpace(vhlno.Text)))
            {
                host.Visibility = Visibility.Visible;
                ReportViewer.Reset();
                try
                {
                    Connection CON = new Connection();
                    CON.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select DATE_FORMAT(loaddate,'%d-%m-%Y')AS LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight,DATE_FORMAT(unloaddate,'%d-%m-%Y')AS UnloadDate,EndingKm,TotalKm,UnloadWeight,Payment,TripExpense,TripDiesel,DieselAmount,TripMileage,FrieghtReduction,TripProfit from load_trip_details WHERE vehiclenumber='" + vhlno.Text + "' and tripstatus=0", CON.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportDataSource ds = new ReportDataSource("Close_View", dt);
                        ReportViewer.LocalReport.DataSources.Add(ds);
                        ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Close_View.rdlc";
                        ReportParameter[] parameter = new ReportParameter[4];
                        parameter[0] = new ReportParameter("vhnum", "Vehicle Number");
                        parameter[1] = new ReportParameter("vehicle_number", vhlno.Text);
                        parameter[2] = new ReportParameter("date", DateTime.Now.ToShortDateString());
                        parameter[3] = new ReportParameter("title", Properties.Settings.Default.Title);
                        this.ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Record Doesnot Exist");
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }
               
            }
            else if(tripclose.IsChecked == true && (!String.IsNullOrWhiteSpace(tripnum.Text)))
            {
                host.Visibility = Visibility.Visible;
                ReportViewer.Reset();
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select DATE_FORMAT(loaddate,'%d-%m-%Y')AS LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight,DATE_FORMAT(unloaddate,'%d-%m-%Y')AS UnloadDate,EndingKm,TotalKm,UnloadWeight,Payment,TripExpense,TripDiesel,DieselAmount,TripMileage,FrieghtReduction,TripProfit from load_trip_details WHERE tripnumber='" + tripnum.Text + "' and tripstatus=0", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportDataSource ds = new ReportDataSource("Close_View", dt);
                        ReportViewer.LocalReport.DataSources.Add(ds);
                        ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Close_View.rdlc";
                        ReportParameter[] parameter = new ReportParameter[4];
                        parameter[0] = new ReportParameter("vhnum", "Trip Number");
                        parameter[1] = new ReportParameter("vehicle_number", tripnum.Text);
                        parameter[2] = new ReportParameter("date", DateTime.Now.ToShortDateString());
                        parameter[3] = new ReportParameter("title", Properties.Settings.Default.Title);
                        this.ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Record Doesnot Exist");
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show(""+ex);
                }
               
            }           
            else
            {
                MessageBox.Show("Please Enter the Values");
            }
        }

        private void tripload_Checked(object sender, RoutedEventArgs e)
        {
            vhlno.Visibility = Visibility.Visible;
            tripnum.Visibility = Visibility.Hidden;
            tripno.Visibility = Visibility.Hidden;
            fromdate.Visibility = Visibility.Hidden;
            startdate.Visibility = Visibility.Hidden;
            todate.Visibility = Visibility.Hidden;
            enddate.Visibility = Visibility.Hidden;
            Thickness margin = show.Margin;
            margin.Left = -590;
            margin.Top = 0;
            margin.Right = 0;
            margin.Bottom = 0;
            show.Margin = margin;
            n = 1;
            get_vehicle_number(n);
        }
        public void get_vehicle_number(int i)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehiclenumber from load_trip_details where tripstatus="+i+"", con.conn);
                OdbcDataReader dr = cmd.ExecuteReader();
                vhlno.Items.Clear();
                while (dr.Read())
                {
                    vhlno.Items.Add(dr[0]);
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        public void get_trip_number(int i)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select tripnumber from load_trip_details where tripstatus="+i+"", con.conn);
                OdbcDataReader dr = cmd.ExecuteReader();
                tripnum.Items.Clear();
                while (dr.Read())
                {
                    tripnum.Items.Add(dr[0]);
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void tripunload_Checked(object sender, RoutedEventArgs e)
        {
            vhlno.Visibility = Visibility.Visible;
            tripnum.Visibility = Visibility.Visible;
            tripno.Visibility = Visibility.Visible;
            fromdate.Visibility = Visibility.Visible;
            startdate.Visibility = Visibility.Visible;
            todate.Visibility = Visibility.Visible;
            enddate.Visibility = Visibility.Visible;
            Thickness margin = show.Margin;
            margin.Left = 550;
            margin.Top = 0;
            margin.Right = 0;
            margin.Bottom = 0;
            show.Margin = margin;
            n = 2;
            get_vehicle_number(n);
            get_trip_number(n);
        }

        private void tripclose_Checked(object sender, RoutedEventArgs e)
        {
            vhlno.Visibility = Visibility.Visible;
            tripnum.Visibility = Visibility.Visible;
            tripno.Visibility = Visibility.Visible;
            fromdate.Visibility = Visibility.Visible;
            startdate.Visibility = Visibility.Visible;
            todate.Visibility = Visibility.Visible;
            enddate.Visibility = Visibility.Visible;
            Thickness margin = show.Margin;
            margin.Left = 550;
            margin.Top = 0;
            margin.Right = 0;
            margin.Bottom = 0;
            show.Margin = margin;
            n = 0;
            get_vehicle_number(n);
            get_trip_number(n);
        }

        private void vhlno_GotFocus(object sender, RoutedEventArgs e)
        {
            tripnum.Text = string.Empty;
        }

        private void tripnum_GotFocus(object sender, RoutedEventArgs e)
        {
            vhlno.Text = string.Empty;
        }
    }
}
