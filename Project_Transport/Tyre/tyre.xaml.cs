using Microsoft.Reporting.WinForms;
using System.Data;
using System.Data.Odbc;
using System.Windows;
using System.Windows.Controls;
using System;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for tyre.xaml
    /// </summary>
    public partial class tyre : UserControl
    {
        public tyre()
        {
            InitializeComponent();
            int year = DateTime.Now.Year;
            for(int i=year;i>year-5;i--)
            {
                combo.Items.Add(i);
            }
        }      
        private void Tyre_Report_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(text.Text)&&combo.Text!="SELECT")
            {
                try
                {
                    host.Visibility = Visibility.Visible;
                    ReportViewer.Reset();
                    Connection conn = new Connection();
                    conn.connection_string();
                    OdbcCommand cmd1 = new OdbcCommand("select tyre_number,company,price,type,DATE_FORMAT(date,'%d-%m-%Y') as date from tyre_price where vehicle_number='" + text.Text + "' and year(date)='" + combo.Text + "'", conn.str);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        ReportViewer.LocalReport.DataSources.Add(ds);
                        ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Report2.rdlc";
                        ReportParameter[] parameter = new ReportParameter[3];
                        parameter[0] = new ReportParameter("Vehicle_Number", text.Text);
                        parameter[1] = new ReportParameter("Year", combo.Text);
                        parameter[2] = new ReportParameter("Title", Properties.Settings.Default.Title.ToString());
                        this.ReportViewer.LocalReport.SetParameters(parameter);
                        ReportViewer.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Records Not Exist");
                    }

                    conn.close_string();
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
               
            }
            else
            {
                MessageBox.Show("Select Vehicle Number and Year");
            }
           
        }

        private void text_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection CON = new Connection();
                CON.open_connection();
                OdbcCommand CMD = new OdbcCommand("SELECT vehicle_number from vechicle_details where corporation='IOC' OR CORPORATION='BPC' OR CORPORATION='HPC'",CON.conn);
                OdbcDataReader dr = CMD.ExecuteReader();
                text.Items.Clear();
                while (dr.Read())
                {
                    text.Items.Add(dr[0]);
                }
            }
            catch(OdbcException EX)
            {
                MessageBox.Show(""+EX);
            }
        }
    }
}
