using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows;
using System.Windows.Controls;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Expiry_view.xaml
    /// </summary>
    public partial class Expiry_view : UserControl
    {
        public Expiry_view()
        {
            InitializeComponent();
            int year = DateTime.Now.Year;          
            for (int i = year; i > year - 5; i--)
            {
                combo.Items.Add(i);
            }        
        }
        private void text_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand CMD = new OdbcCommand("SELECT vehicle_no from bill", con.conn);
                OdbcDataReader dr = CMD.ExecuteReader();
                text.Items.Clear();
                while (dr.Read())
                {
                    text.Items.Add(dr[0]);
                }
            }
            catch (OdbcException EX)
            {
                MessageBox.Show("" + EX);
            }
        }
        private void Tyre_Report_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(text.Text) && combo.Text != "SELECT" && combo1.Text!="SELECT")
            {
                try
                {
                    host.Visibility = Visibility.Visible;
                    ReportViewer.Reset();
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select Expiry_type,From_date,To_date,paid_amount,paid_date,number from bill where vehicle_no='" + text.Text + "' and year(To_date)='"+combo.Text+"' and month(To_date)='"+combo1.Text+"'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportParameter[] parameter = new ReportParameter[4];
                        parameter[0] = new ReportParameter("Vehicle_Number", text.Text);
                        parameter[1] = new ReportParameter("Year", combo.Text);
                        parameter[2] = new ReportParameter("Month", combo1.Text);
                        parameter[3] = new ReportParameter("Title", Properties.Settings.Default.Title.ToString());
                        ReportDataSource ds = new ReportDataSource("Expiry", dt);
                        ReportViewer.LocalReport.DataSources.Add(ds);
                        ReportViewer.LocalReport.ReportEmbeddedResource = "transport.Expiry_view.rdlc";
                        ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Records Not Exist");
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
                MessageBox.Show("Select Vehicle Number and Year and Month");
            }

        }
    }
}
