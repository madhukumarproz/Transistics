using System;
using System.Collections.Generic;
using System.Windows;
using System.Data;
using System.Windows.Documents;
using System.Data.Odbc;
using System.Windows.Media;
using System.IO;
using System.Windows.Controls;

namespace Project_Transport 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        //OdbcConnection con = new OdbcConnection();
        List<string> veh = new List<string>();
        List<string> name = new List<string>();
        List<string> date = new List<string>();
        List<string> dname = new List<string>();
        List<string> ddate = new List<string>(); 
        public Dashboard()
        {
            InitializeComponent();
            //con.ConnectionString = "Dsn=Trans_App;" +
            //                  "Uid=root;" +
            //                  "Pwd=root;";
            showColumnChart();
            bar_chart();
           
            
        }
        private void showColumnChart()
        {
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            int cnt = 0, cnt1 = 0, cnt2 = 0,cnt3 = 0;
            Connection con = new Connection();       
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select count(*) from load_trip_details where tripstatus=1", con.conn);
            OdbcDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cnt = Convert.ToInt32(dr[0]);
            }
            OdbcCommand cmd1 = new OdbcCommand("select count(*) from lpg_trip_details where trip_status='RUNNING'", con.conn);
            OdbcDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                cnt1 = Convert.ToInt32(dr1[0]);
            }
            OdbcCommand cmd2 = new OdbcCommand("select count(*) from load_trip_details where tripstatus=2", con.conn);
            OdbcDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cnt2 = Convert.ToInt32(dr2[0]);
            }
            OdbcCommand cmd3 = new OdbcCommand("select count(*) from lpg_trip_details where trip_status='UNLOADED'", con.conn);
            OdbcDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                cnt3 = Convert.ToInt32(dr3[0]);
            }
            //OdbcCommand cmd1 = new OdbcCommand("select count(*) from load_trip_details where tripstatus=0", con);
            //OdbcDataReader dr1 = cmd1.ExecuteReader();
            //while (dr1.Read())
            //{
            //    cnt1 = Convert.ToInt32(dr1[0]);
            //}
            valueList.Add(new KeyValuePair<string, int>("On-Trip", cnt+cnt1));
            valueList.Add(new KeyValuePair<string, int>("Unload", cnt2+cnt3));
            //valueList.Add(new KeyValuePair<string, int>("Closed", cnt1));
            //valueList.Add(new KeyValuePair<string, int>("QA", 30));
            //valueList.Add(new KeyValuePair<string, int>("Project Manager", 40));

            //Setting data for column chart
            columnChart.DataContext = valueList;

            // Setting data for pie chart
            //pieChart.DataContext = valueList;

            //Setting data for area chart
            //pieChart.DataContext = valueList;

            //Setting data for bar chart
            // barChart.DataContext = valueList;

            //Setting data for line chart
            // lineChart.DataContext = valueList;
            con.close_connection();
        }
        void bar_chart()
        {
            Connection con = new Connection();
            con.open_connection();
            List<KeyValuePair<string, int>> List = new List<KeyValuePair<string, int>>();
            int cnt = 0,cnt1=0;int m = DateTime.Now.Month;int y = DateTime.Now.Year;
          for(int j=0;j<5;j++)
            {
                if(m==0)
                {
                    m = 12;y -= 1;
                }
                OdbcCommand cmd = new OdbcCommand("select count(*) from load_trip_details where month(loaddate)="+m+" and year(loaddate)="+y+"", con.conn);
                OdbcDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string v = dr[0].ToString();
                    if(v==null)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(dr[0]);
                    }
                   
                }
                OdbcCommand cmd2 = new OdbcCommand("select count(*) from lpg_trip_details where month(load_date)=" + m + " and year(load_date)=" + y + "", con.conn);
                OdbcDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    string v = dr2[0].ToString();
                    if (v == null)
                    {
                        cnt1 = 0;
                    }
                    else
                    {
                        cnt1 = Convert.ToInt32(dr2[0]);
                    }

                }
                List.Add(new KeyValuePair<string, int>(m.ToString(), cnt+cnt1));
                m -=1;
            }
            //List.Add(new KeyValuePair<string, int>("2", cnt));
            //List.Add(new KeyValuePair<string, int>("3", cnt));
            //List.Add(new KeyValuePair<string, int>("4", cnt));
            //List.Add(new KeyValuePair<string, int>("5", cnt));
            List.Reverse();
            areaChart.DataContext = List;
            con.close_connection();
        }


        // FC Expiry Checking 
        string day = Convert.ToDateTime(DateTime.Now.AddDays(31)).ToString("yyyy-MM-dd");
        public void fc_expiry()
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(fc_expiry,'%d-%m-%Y') as fc from vechicle_details where fc_expiry<'"+day+"'",con.conn);
                //OdbcCommand cmd = new OdbcCommand("select vehicle_number,fc_expiry from vechicle_details where fc_expiry-date()<=30 and fc_expiry-date()>0", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add( dt.Rows[i]["vehicle_number"].ToString());
                        date.Add( dt.Rows[i]["fc"].ToString());
                        name.Add("FC");                       
                        i++;
                    }
                   
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("fc expiry");
            }

        }


        // Insurance Expiry Checking

        public void insurance_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(insurance_expiry,'%d-%m-%Y') as ins from vechicle_details where insurance_expiry<'"+day+"'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["ins"].ToString());
                        name.Add("INSURANCE");                        
                        i++;
                    }
                    
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("insurance expiry");
            }

        }

        // National Expiry Checking

        public void national_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(national_expiry,'%d-%m-%Y')as nat from vechicle_details where national_expiry<'"+day+"'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["nat"].ToString());
                        name.Add("NATIONAL");                      
                        i++;
                    }                   
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("national expiry");
            }

        }

        // Permit Expiry Checking

        public void permit_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(permit_expiry,'%d-%m-%Y') as per from vechicle_details where permit_expiry<'"+day+"'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["per"].ToString());
                        name.Add("PERMIT");                       
                        i++;
                    }
                    
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("permit expiry");
            }

        }
        // Explosive Expiry Checking

        public void explosive_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                //con.Open();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(explosive_expiry,'%d-%m-%Y') as exp from vechicle_details where explosive_expiry<'"+day+"'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["exp"].ToString());
                        name.Add("EXPLOSIVE");                       
                        i++;
                    }                   
                }
                con.close_connection();
                //con.Close();
            }
            catch
            {
                MessageBox.Show("explosive expiry");
            }

        }


        // Yearly Expiry Checking

        public void yearly_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(yearly_expiry,'%d-%m-%Y') as yer from vechicle_details where yearly_expiry<'"+day+"'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["yer"].ToString());
                        name.Add("YEARLY");                       
                        i++;
                    }                  
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("yearly expiry");
            }

        }


        //  Half-Yearly Expiry Checking

        public void half_yearly_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(half_yearly_expiry,'%d-%m-%Y') as hlf from vechicle_details where half_yearly_expiry<'" + day + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["hlf"].ToString());
                        name.Add("HALF YEARLY");                        
                        i++;
                    }                 
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("half year expiry");
            }

        }


        // Hydro Expiry Checking

        public void hydro_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(hydro_expiry,'%d-%m-%Y')as hyd from vechicle_details where hydro_expiry<'" + day + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["hyd"].ToString());
                        name.Add("HYDRO");                      
                        i++;
                    }
                   
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("hydro expiry");
            }

        }


        // CLL Expiry Checking

        public void cll_policy1()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(cll_policy,'%d-%m-%Y')as cll from vechicle_details where cll_policy<'" + day + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["cll"].ToString());
                        name.Add("CLL");                       
                        i++;
                    }                  
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("cll expiry");
            }

        }


        //  PLI Expiry Checking

        public void pli()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(pli,'%d-%m-%Y')as pli from vechicle_details where pli<'" + day + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["pli"].ToString());
                        name.Add("PLI");                        
                        i++;
                    }                 
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("pli expiry");
            }

        }


        //  Tax Expiry Checking

        public void tax_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,Date_Format(tax_expiry,'%d-%m-%Y')as tax from vechicle_details where tax_expiry<'" + day + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        veh.Add(dt.Rows[i]["vehicle_number"].ToString());
                        date.Add(dt.Rows[i]["tax"].ToString());
                        name.Add("TAX");                       
                        i++;
                    }                  
                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("Tax expiry");
            }

        }


        // Driver Licence Expiry Checking


       // int inc = 0;
        //internal object time;

        public void driving_licence_expiry()
        {
            try
            {

                Connection con = new Connection();
                con.open_connection();
                //con.Open();
                OdbcCommand cmd = new OdbcCommand("select driver_name,Date_Format(expiry,'%d-%m-%Y')as exp from driver_details where expiry<'" + day + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dname.Add( dt.Rows[i]["driver_name"].ToString());
                        ddate.Add( dt.Rows[i]["exp"].ToString());                        
                        //inc++;
                    }                   
                }
                con.close_connection();
                //con.Close();
            }
            catch
            {
                MessageBox.Show("from driver expiry checking");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                fc_expiry();
                insurance_expiry();
                national_expiry();
                permit_expiry();
                explosive_expiry();
                yearly_expiry();
                half_yearly_expiry();
                hydro_expiry();
                cll_policy1();
                pli();
                tax_expiry();
                driving_licence_expiry();
                expiry();
                driver();
            }
            catch
            {
                MessageBox.Show("Table Does Not Exist in Transport");
            }
                       
        }
        void expiry()
        {
            Table t = new Table();
            for (int i = 0; i < 4; i++)
            {
                t.Columns.Add(new TableColumn());
            }

            t.RowGroups.Add(new TableRowGroup());
            t.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow = t.RowGroups[0].Rows[0];
            currentRow.Background = Brushes.Beige;
            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("S No"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Vehicle"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Expiry"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Date"))));
            for (int i = 0; i < veh.Count; i++)
            {
                int s = i;
                t.RowGroups[0].Rows.Add(new TableRow());
                currentRow = t.RowGroups[0].Rows[i + 1];
                currentRow.Background = Brushes.Transparent;
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run((s + 1).ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(veh[i]))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(name[i]))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(date[i]))));
                //row.Cells[0].ColumnSpan = 6;
                //list.Items.Add(valueList[i]);
            }
            tableView.Blocks.Add(t);
        }
        void driver()
        {
            Table t1 = new Table();
            for (int i = 0; i < 3; i++)
            {
                t1.Columns.Add(new TableColumn());
            }
            t1.Columns[0].Width = new GridLength(40);
            t1.Columns[1].Width = new GridLength(150);
            t1.Columns[2].Width = new GridLength(80);
            t1.RowGroups.Add(new TableRowGroup());
            t1.RowGroups[0].Rows.Add(new TableRow());
            TableRow cRow = t1.RowGroups[0].Rows[0];
            cRow.Background = Brushes.Beige;
            cRow.FontSize = 12;
            cRow.FontWeight = FontWeights.Bold;            
            cRow.Cells.Add(new TableCell(new Paragraph(new Run("S No"))));
            cRow.Cells.Add(new TableCell(new Paragraph(new Run("Name"))));
            cRow.Cells.Add(new TableCell(new Paragraph(new Run("Date"))));

            for (int i = 0; i < dname.Count; i++)
            {
                int s = i;
                t1.RowGroups[0].Rows.Add(new TableRow());
                cRow = t1.RowGroups[0].Rows[i + 1];
                cRow.Background = Brushes.Transparent;
                cRow.FontSize = 12;
                cRow.FontWeight = FontWeights.Bold;
                cRow.Cells.Add(new TableCell(new Paragraph(new Run((s + 1).ToString()))));
                cRow.Cells.Add(new TableCell(new Paragraph(new Run(dname[i]))));
                cRow.Cells.Add(new TableCell(new Paragraph(new Run(ddate[i]))));

                //row.Cells[0].ColumnSpan = 6;
                //list.Items.Add(valueList[i]);
            }
            tableView1.Blocks.Add(t1);
        }

        private void rtbox_LostFocus(object sender, RoutedEventArgs e)
        {
            string text = new TextRange(rtbox.Document.ContentStart, rtbox.Document.ContentEnd).Text;
            File.WriteAllText(@"../../Text/TextFile1.txt",text);           // write a line of text to the file
            //tw.WriteLine(rtbox.Text);
            rtbox.SelectAll();
            rtbox.Selection.Text = "";
        }

        private void rtbox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextRange text = new TextRange(rtbox.Document.ContentStart, rtbox.Document.ContentEnd);
            string tex = @"../../Text/TextFile1.txt";
            FileStream file = new FileStream(tex,FileMode.Open);
            text.Load(file,System.Windows.DataFormats.Text);              // Load the text file
            //rtbox.LoadFile
        }

        private void Diesel_Payment_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Contact Admin");            
            ((MainWindow)System.Windows.Application.Current.MainWindow).dashboard.Visibility = Visibility.Hidden;
            ((MainWindow)System.Windows.Application.Current.MainWindow).diesel_card_deposit.Visibility = Visibility.Visible;
        }

        private void Lpg_trip_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).dashboard.Visibility = Visibility.Hidden;
            ((MainWindow)System.Windows.Application.Current.MainWindow).trip_entry_panel.Visibility = Visibility.Visible;
           
        }

        private void Load_Trailer_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).dashboard.Visibility = Visibility.Hidden;
            ((MainWindow)System.Windows.Application.Current.MainWindow).load_trailer.Visibility = Visibility.Visible;
            
        }

        private void Lpg_Payment_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).dashboard.Visibility = Visibility.Hidden;
            ((MainWindow)System.Windows.Application.Current.MainWindow).driver_salary.Visibility = Visibility.Visible;
           
        }

        private void Load_Payment_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).dashboard.Visibility = Visibility.Hidden;
            ((MainWindow)System.Windows.Application.Current.MainWindow).load_pay.Visibility = Visibility.Visible;
           
        }

        private void Poweredby_Clicked(object sender, RoutedEventArgs e)
        {
           
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                System.Diagnostics.Process.Start("http://www.pro-z.in/");
            }
            else
            {
                MessageBox.Show("No Internet Connection");
            }
            
        }

        private void Profit_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).dashboard.Visibility = Visibility.Hidden;
            ((MainWindow)System.Windows.Application.Current.MainWindow).profit_viewer.Visibility = Visibility.Visible;
        }
    }
}
