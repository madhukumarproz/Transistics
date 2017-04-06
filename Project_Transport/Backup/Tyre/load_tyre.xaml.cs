using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for load_tyre.xaml
    /// </summary>
    public partial class load_tyre : UserControl
    {
        load_tyre_view l = new load_tyre_view();
        public load_tyre()
        {
           
            InitializeComponent();
            
        }

        private void tyre_vehicle_number_GotFocus(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd1 = new OdbcCommand("select Vechile_No from load_tyre ", con.str);
            OdbcDataReader da = cmd1.ExecuteReader();
            tyre_vehicle_number.Items.Clear();
            while (da.Read())
            {
                tyre_vehicle_number.Items.Add(da[0]);

            }
            con.close_string();
        }
       
        private void tyre_vehicle_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(tyre_vehicle_number.Text))
                {
                    tyre_view_panel.Visibility = Visibility.Visible;
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select type from vechicle_details where vehicle_Number='" + tyre_vehicle_number.Text + "' ", con.conn);
                    OdbcDataReader da = cmd1.ExecuteReader();
                    while (da.Read())
                    {
                        string s = da[0].ToString();
                        if (s == "6")
                        {
                            tyre_entry_panel.Visibility = Visibility.Visible;
                            //Connection con = new Connection();
                            //con.open_connection();
                            //OdbcCommand cmd1 = new OdbcCommand("select Fl_id,Fr_id,Bbol_id,Bbil_id,Bbor_id,Bbir_id from load where vehicle_Number='" + tyre_vehicle_number.Text + "' ", con.conn);
                            //OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            //DataTable dt = new DataTable();
                            //da.Fill(dt);
                            but1.Visibility = Visibility.Visible;
                            but2.Visibility = Visibility.Visible;
                            but3.Visibility = Visibility.Hidden;
                            but4.Visibility = Visibility.Hidden;
                            but5.Visibility = Visibility.Hidden;
                            but6.Visibility = Visibility.Hidden;
                            but7.Visibility = Visibility.Hidden;
                            but8.Visibility = Visibility.Hidden;
                            but9.Visibility = Visibility.Visible;
                            but10.Visibility = Visibility.Visible;
                            but11.Visibility = Visibility.Visible;
                            but12.Visibility = Visibility.Visible;

                        }
                        else if (s == "10")
                        {
                            tyre_entry_panel.Visibility = Visibility.Visible;

                            but1.Visibility = Visibility.Visible;
                            but2.Visibility = Visibility.Visible;
                            but3.Visibility = Visibility.Hidden;
                            but4.Visibility = Visibility.Hidden;
                            but5.Visibility = Visibility.Visible;
                            but6.Visibility = Visibility.Visible;
                            but7.Visibility = Visibility.Visible;
                            but8.Visibility = Visibility.Visible;
                            but9.Visibility = Visibility.Visible;
                            but10.Visibility = Visibility.Visible;
                            but11.Visibility = Visibility.Visible;
                            but12.Visibility = Visibility.Visible;
                        }
                        else if (s == "12")
                        {
                            tyre_entry_panel.Visibility = Visibility.Visible;
                            but1.Visibility = Visibility.Visible;
                            but2.Visibility = Visibility.Visible;
                            but3.Visibility = Visibility.Visible;
                            but4.Visibility = Visibility.Visible;
                            but5.Visibility = Visibility.Visible;
                            but6.Visibility = Visibility.Visible;
                            but7.Visibility = Visibility.Visible;
                            but8.Visibility = Visibility.Visible;
                            but9.Visibility = Visibility.Visible;
                            but10.Visibility = Visibility.Visible;
                            but11.Visibility = Visibility.Visible;
                            but12.Visibility = Visibility.Visible;
                        }
                        else if (s == "14")
                        {
                            tyre_entry_panel.Visibility = Visibility.Visible;

                        }
                        else
                        {
                            MessageBox.Show("Not a valid type");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Choose the vehicle number");
                }

            }

        }
     
        string[] s = new string[6];
      
        string b1 = null;
        string b2 = null;
        public void get_details(string s1, string s2, string s3)
        {
            if (!string.IsNullOrWhiteSpace(s3))
            {
                Connection con = new Connection();
                con.connection_string();
                OdbcCommand cmd1 = new OdbcCommand("select " + s1 + ",DATE_FORMAT(" + s2 + ",'%d-%m-%Y')Add_date from load_tyre where vechile_No='" + s3 + "' ", con.str);
                OdbcDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    string st = dr[0].ToString();
                    string d = dr[1].ToString();
                    if (st != null)
                    {
                        OdbcCommand cmd = new OdbcCommand("select No,Starting_Km,Company,Price,DATE_FORMAT(Purchase_date,'%d-%m-%Y')Purchase_date from load_tyre_details where id='" + st + "' ", con.str);
                        OdbcDataAdapter daa = new OdbcDataAdapter(cmd);
                        DataTable dtt = new DataTable();
                        daa.Fill(dtt);
                        if (dtt.Rows.Count > 0)
                        {
                            s[0] = dtt.Rows[0]["No"].ToString();
                            s[1] = dtt.Rows[0]["Starting_Km"].ToString();
                            s[2] = dtt.Rows[0]["Company"].ToString();
                            s[3] = dtt.Rows[0]["Price"].ToString();
                           s[4] = dtt.Rows[0]["Purchase_date"].ToString();
                            s[5] = d;
                           
                            l.View(s,b1,b2,s3);
                            l.Show();
                        }
                        else
                        {                          
                        l.hide(s3,b1,b2);

                            l.Show();
                        }
                    }                  
                }
            }
            else
            {
                MessageBox.Show("Please choose vehicle_Number");
            }
        }
        private void but1_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tyre_vehicle_number.Text))
            {
               

                b1 = "Fl_id"; b2 = "Fl_date";
                get_details(b1, b2, tyre_vehicle_number.Text);
               
            }
           else
            {
                MessageBox.Show("Please select vehicle_Number");
            }
        }                 
       
    

        private void but2_Click(object sender, RoutedEventArgs e)
        {
           
            b1 = "Cl_id"; b2 = "Cl_date";
            get_details(b1, b2, tyre_vehicle_number.Text);

        }
            
        

        private void but3_Click(object sender, RoutedEventArgs e)
        {
           
            b1 = "Bfil_id"; b2 = "Bfil_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           
        }

        private void but4_Click(object sender, RoutedEventArgs e)
        {
            
            b1 = "Bfol_id"; b2 = "Bfol_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           
        }

        private void but5_Click(object sender, RoutedEventArgs e)
        {
           
            b1 = "Bbil_id"; b2 = "Bbil_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           
        }

        private void but6_Click(object sender, RoutedEventArgs e)
        {
           
            b1 = "Bbol_id"; b2 = "Bbol_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           
        }

        private void but7_Click(object sender, RoutedEventArgs e)
        {
           
            b1 = "Fr_id"; b2 = "Fr_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           
        }

        private void but8_Click(object sender, RoutedEventArgs e)
        {
            b1 = "Cr_id"; b2 = "Cr_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           
        }

        private void but9_Click(object sender, RoutedEventArgs e)
        {
            b1 = "Bfir_id"; b2 = "Bfir_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           
        }

        private void but10_Click(object sender, RoutedEventArgs e)
        {
            
            b1 = "Bfor_id"; b2 = "Bfor_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           

        }

        private void but11_Click(object sender, RoutedEventArgs e)
        {
            
            b1 = "Bbir_id"; b2 = "Bbir_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           

        }

        private void but12_Click(object sender, RoutedEventArgs e)
        {
           
            b1 = "Bbor_id"; b2 = "Bbor_date";
            get_details(b1, b2, tyre_vehicle_number.Text);
           
        }
        List<string> t_no = new List<string>();
        List<string> s_km = new List<string>();
        private void view_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tyre_vehicle_number.Text))
            {
                Connection con = new Connection();
                con.connection_string();
                OdbcCommand cmd1 = new OdbcCommand("select fl_id,fr_id,fbl_id,fbr_id,cl_id,cr_id,bfol_id,bfil_id,bfor_id,bfir_id,bbol_id,bbil_id,bbor_id,bbir_id,add_id from load_tyre where vehicle_number='" + tyre_vehicle_number.Text + "'", con.str);
                OdbcDataReader da1 = cmd1.ExecuteReader();
                while (da1.Read())
                {
                    for (int i = 0; i < 16; i++)
                    {
                        string DR = da1[i].ToString();
                        if (!string.IsNullOrWhiteSpace(DR))
                        {
                            OdbcCommand cmd = new OdbcCommand("select No,Starting_KM from load_tyre_details where id='" + DR + "'", con.str);
                            OdbcDataReader da = cmd1.ExecuteReader();
                            while (da.Read())
                            {
                                t_no.Add(da[0].ToString());
                                s_km.Add(da[1].ToString());
                              
                            }

                        }
                        else
                        {
                            t_no.Add("");
                            s_km.Add("");
                        }

                    }
                    show();
                }
            }
               
            
        }
       public  void show()
        {
            tl1.Content=t_no[0];        tl13.Content = t_no[1];
            tl2.Content=s_km[0];        tl14.Content = s_km[1];
            tl3.Content = t_no[2];      tl15.Content = t_no[3];
            tl4.Content = s_km[2];      tl16.Content = s_km[3];
            tl5.Content = t_no[4];      tl17.Content = t_no[5];
            tl6.Content = s_km[4];      tl18.Content = s_km[5];
            tl7.Content = t_no[6];      tl19.Content = t_no[7];
            tl8.Content = s_km[6];      tl20.Content = s_km[7];
            tl9.Content = t_no[8];      tl21.Content = t_no[9];
            tl10.Content = s_km[8];     tl22.Content = s_km[9];
            tl11.Content = t_no[10];    tl23.Content = t_no[11];
            tl12.Content = s_km[10];    tl24.Content = s_km[11];

            //tl25.Content = t_no[0]; tl26.Content = s_km[0];



        }

        private void tyre_print_panel_open(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tyre_vehicle_number.Text))
            {
                host.Visibility = Visibility.Visible;
                back.Visibility = Visibility.Visible;
                print_data();
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }
           
        }
       
        private void but13_Click(object sender, RoutedEventArgs e)
        {
            b1 = "Add_id"; b2 = "Add_date";
            get_details(b1, b2, tyre_vehicle_number.Text);

        }
        void print_data()
        {
            ReportParameter[] param = new ReportParameter[63];
            try
            {
                List<string> date = new List<string>();
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd1 = new OdbcCommand("select fl_date,fr_date,fbl_date,fbr_date,cl_date,cr_date,bfol_date,bfil_date,bfor_date,bfir_date,bbol_date,bbil_date,bbor_date,bbir_date,add_date from load_tyre where vechile_no='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                for (int j = 0; j < 15; j++)
                {
                    date.Add(dr1[j].ToString());
                }
            }
            con.close_string();
           
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select fl_id,fr_id,fbl_id,fbr_id,cl_id,cr_id,bfol_id,bfil_id,bfir_id,bfor_id,bbol_id,bbil_id,bbir_id,bbor_id,add_id from load_tyre where vechile_no='" + tyre_vehicle_number.Text + "'", con.str);
            OdbcDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                int p = 0, q = 1, r = 2, s = 3;
                for (int i = 0; i < 15; i++)
                {
                    int A = p + 1, B = q + 1, C = r + 1, D = s + 1;
                    string id = dr[i].ToString();
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        OdbcCommand cmd2 = new OdbcCommand("select no,starting_km,company from load_tyre_details where id=" + id + "", con.str);
                        OdbcDataReader dr2 = cmd2.ExecuteReader();
                        while (dr2.Read())
                        {
                            if (!string.IsNullOrWhiteSpace(dr2[0].ToString()))
                            {
                                param[p] = new ReportParameter("param" + A + "", dr2[0].ToString());
                                param[q] = new ReportParameter("param" + B + "", dr2[1].ToString());
                                param[r] = new ReportParameter("param" + C + "", dr2[2].ToString());
                                param[s] = new ReportParameter("param" + D + "", Convert.ToDateTime(date[i]).ToString("dd/MM/yyyy"));
                            }
                            else
                            {
                                param[p] = new ReportParameter("param" + A + "", " ");
                                param[q] = new ReportParameter("param" + B + "", " ");
                                param[r] = new ReportParameter("param" + C + "", " ");
                                param[s] = new ReportParameter("param" + D + "", " ");
                            }

                        }
                    }
                    else
                    {
                        param[p] = new ReportParameter("param" + A + "", " ");
                        param[q] = new ReportParameter("param" + B + "", " ");
                        param[r] = new ReportParameter("param" + C + "", " ");
                        param[s] = new ReportParameter("param" + D + "", " ");
                    }
                    p += 4; q += 4; r += 4; s += 4;
                }
            }
            ReportViewer.Clear();
            ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.load_tyre.rdlc";
            param[60] = new ReportParameter("param61", Properties.Settings.Default.Title.ToString());
            param[61] = new ReportParameter("param62", (tyre_vehicle_number.Text).ToString());
            param[62] = new ReportParameter("param63", Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"));
            ReportViewer.LocalReport.SetParameters(param);
            ReportViewer.RefreshReport();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
           
        }

        private void Load_Tyre_Back_Click(object sender, RoutedEventArgs e)
        {
            ReportViewer.Clear();
            host.Visibility = Visibility.Hidden;
            back.Visibility = Visibility.Hidden;
        }
    }
}
