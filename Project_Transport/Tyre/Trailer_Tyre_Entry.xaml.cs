using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Trailer_Tyre_Entry.xaml
    /// </summary>
    public partial class Trailer_Tyre_Entry : UserControl
    {
        public Trailer_Tyre_Entry()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
        }
        string p1 = null;string p2 = null;
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        //int ii = 0;
        //string chr = null;
        Trailer_Tyre_View ttv = new Trailer_Tyre_View();
        void time_tick1(object sender, EventArgs e)
        {
            //if (ii == 10)
            //{
            //    if (chr == "i")
            //    {
            //        tyre_insert_img1.Visibility = System.Windows.Visibility.Visible;
            //        tyre_insert_img2.Visibility = System.Windows.Visibility.Hidden;
            //        time1.Stop();
            //        chr = "";
            //    }
            //    else if (chr == "u")
            //    {
            //        tyre_update_img1.Visibility = System.Windows.Visibility.Visible;
            //        tyre_update_img2.Visibility = System.Windows.Visibility.Hidden;
            //        time1.Stop();
            //        chr = "";
            //    }
            //}
            //ii++;
        }
        private void tyre_vehicle_number_GotFocus(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select vehicle_no from trailer", con.str);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            tyre_vehicle_numbers.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tyre_vehicle_numbers.Items.Add(dt.Rows[i]["vehicle_no"]);
                }
            }
            con.close_string();
        }
      

       

        void tank_back_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "acol_id";p2 = "acol_date";
            ttv.Get_Details(p1,p2,tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void tank_back_left_inner_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "acil_id"; p2 = "acil_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }


        void tank_front_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "afol_id"; p2 = "afol_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void tank_front_left_inner_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "afil_id"; p2 = "afil_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_back_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "cbol_id"; p2 = "cbol_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_back_left_inner_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "cbil_id"; p2 = "cbil_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_center_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "cfol_id"; p2 = "ccol_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_center_left_inner_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "cfil_id"; p2 = "ccil_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_front_left_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "fl_id"; p2 = "fl_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void tank_back_right_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "acor_id"; p2 = "acor_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void tank_back_right_inner_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "acir_id"; p2 = "acir_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void tank_front_right_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "afor_id"; p2 = "afor_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void tank_front_right_inner_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "afir_id"; p2 = "afir_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_back_right_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "cbor_id"; p2 = "cbor_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_back_right_inner_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "cbir_id"; p2 = "cbir_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_center_right_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "cfor_id"; p2 = "ccor_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_center_right_inner_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "cfir_id"; p2 = "ccir_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        void zeep_front_right(object sender, RoutedEventArgs e)
        {
            p1 = "fr_id"; p2 = "fr_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        private void tank_back1_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "abol_id"; p2 = "abol_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        private void tank_back2_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "abil_id"; p2 = "abil_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        private void tank_back3_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "abor_id"; p2 = "abor_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        private void tank_back4_left_outer_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "abir_id"; p2 = "abir_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }

        private void stepny_clicked(object sender, RoutedEventArgs e)
        {
            p1 = "adt_id"; p2 = "adt_date";
            ttv.Get_Details(p1, p2, tyre_vehicle_numbers.Text);
            ttv.ShowDialog();
        }
        


        void tyre_print_panel_open(object sender, RoutedEventArgs e)
        {
            tyre_print_panel.Visibility = Visibility.Visible;
            if (!string.IsNullOrWhiteSpace(tyre_vehicle_numbers.Text))
            {
                print_data();
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }

        }

        void Tyre_Report_Back_Click(object sender, RoutedEventArgs e)
        {
            tyre_print_panel.Visibility = Visibility.Hidden;
            Report_Viewer.Clear();
        }
        void print_data()
        {
            ReportParameter[] param = new ReportParameter[111];
            try
            {
                List<string> date = new List<string>();
                Connection con = new Connection();
                con.connection_string();
                OdbcCommand cmd1 = new OdbcCommand("select fl_date,fr_date,cfol_date,cfil_date,cfor_date,cfir_date,ccol_date,ccil_date,ccor_date,ccir_date,cbol_date,cbil_date,cbor_date,cbir_date,afol_date,afil_date,afor_date,afir_date,acol_date,acil_date,acor_date,acir_date,abol_date,abil_date,abor_date,abir_date,adt_date from trailer where vehicle_no='" + tyre_vehicle_numbers.Text + "'", con.str);
                OdbcDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    for(int j=0;j<27;j++)
                    {
                        date.Add(dr1[j].ToString());
                    }
                }
                OdbcCommand cmd = new OdbcCommand("SELECT fl_id,fr_id,cfol_id,cfil_id,cfor_id,cfir_id,ccol_id,ccil_id,ccor_id,ccir_id,cbol_id,cbil_id,cbor_id,cbir_id,afol_id,afil_id,afor_id,afir_id,acol_id,acil_id,acor_id,acir_id,abol_id,abil_id,abor_id,abir_id,adt_id from trailer where vehicle_no='" + tyre_vehicle_numbers.Text + "'", con.str);
                OdbcDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    
                    int p = 0, q = 1, r = 2, s = 3;
                    for (int i=0;i<27;i++)
                    {
                        int A = p + 1, B = q + 1, C = r + 1, D = s + 1;                        
                        string id = dr[i].ToString();
                        if(!string.IsNullOrWhiteSpace(id))
                        {
                            OdbcCommand cmd2 = new OdbcCommand("select no,starting_km,company from trailer_tyre_details where id="+id+"",con.str);
                            OdbcDataReader dr2 = cmd2.ExecuteReader();
                            while(dr2.Read()) 
                            {
                                param[p] = new ReportParameter("Param" + A + "", dr2[0].ToString());
                                param[q] = new ReportParameter("Param" + B + "", dr2[1].ToString());
                                param[r] = new ReportParameter("Param" + C + "", dr2[2].ToString());
                                param[s] = new ReportParameter("Param" + D + "", Convert.ToDateTime(date[i]).ToString("dd/MM/yyyy"));
                            }                            
                        }
                        else
                        {
                            param[p] = new ReportParameter("Param" + A + "", " ");
                            param[q] = new ReportParameter("Param" + B + "", " ");
                            param[r] = new ReportParameter("Param" + C + "", " ");
                            param[s] = new ReportParameter("Param" + D + "", " ");
                        }
                        p += 4; q += 4; r += 4; s += 4;
                    }                    
                }
                Report_Viewer.Clear();
                Report_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Trailer_Tyre_Report.rdlc";
                param[108] = new ReportParameter("Param109", Properties.Settings.Default.Title.ToString());
                param[109] = new ReportParameter("Param110", (tyre_vehicle_numbers.Text).ToString());
                param[110] = new ReportParameter("Param111", Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"));
                Report_Viewer.LocalReport.SetParameters(param);
                Report_Viewer.RefreshReport();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
           
            
        }
        void Tyre_Vehicle_Number_PreviewKeydown(object sender, KeyEventArgs e) 
        {
            int len = 0;
            string s = tyre_vehicle_numbers.Text;
            if (!string.IsNullOrWhiteSpace(tyre_vehicle_numbers.Text))
            {
                len = tyre_vehicle_numbers.Text.Length;
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
                        tyre_vehicle_numbers.Text = "";
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

       

       

       

       
       
        List<string> t_no = new List<string>();
        List<string> s_km = new List<string>();
        private void View_Click(object sender, RoutedEventArgs e)
        {
            
            if(!string.IsNullOrWhiteSpace( tyre_vehicle_numbers.Text))
            {
                Connection con = new Connection();
                con.connection_string();
                OdbcCommand cmd = new OdbcCommand("select fl_id,fr_id,cfol_id,cfil_id,cfor_id,cfir_id,ccol_id,ccil_id,ccor_id,ccir_id,cbol_id,cbil_id,cbor_id,cbir_id,afol_id,afil_id,afor_id,afir_id,acol_id,acil_id,acor_id,acir_id,abol_id,abil_id,abor_id,abir_id,adt_id from trailer where vehicle_no='"+tyre_vehicle_numbers.Text+"'",con.str);
                OdbcDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    for(int i=0;i<27;i++)
                    {                     
                        string DR = dr[i].ToString();
                        if (!string.IsNullOrWhiteSpace(DR))
                        {
                            OdbcCommand cmd1 = new OdbcCommand("select no,starting_km from trailer_tyre_details where id='" + DR + "'", con.str);
                            OdbcDataReader dr1 = cmd1.ExecuteReader();
                            while (dr1.Read())
                            {
                                t_no.Add(dr1[0].ToString());
                                s_km.Add(dr1[1].ToString());                                
                            }
                        }
                        else
                        {
                            t_no.Add("");
                            s_km.Add("");                            
                        }
                    }
                    view_content();
                }
               
                con.close_string();
                
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }
            tyre_view.Visibility = Visibility.Visible;
        }
        void view_content()
        {
            zl1.Content = t_no[0]; zr1.Content = t_no[1];
            zl2.Content = s_km[0]; zr2.Content = s_km[1];
            zl3.Content = t_no[6]; zr5.Content = t_no[8];
            zl4.Content = s_km[6]; zr6.Content = s_km[8];
            zl5.Content = t_no[7]; zr3.Content = t_no[9];
            zl6.Content = s_km[7]; zr4.Content = s_km[9];
            zl7.Content = t_no[10]; zr9.Content = t_no[12];
            zl8.Content = s_km[10]; zr10.Content = t_no[12];
            zl9.Content = t_no[11]; zr7.Content = t_no[13];
            zl10.Content = s_km[11]; zr8.Content = t_no[13];

            tl1.Content = t_no[14]; tr3.Content = t_no[16];
            tl2.Content = s_km[14]; tr4.Content = s_km[16];
            tl3.Content = t_no[15]; tr1.Content = t_no[17];
            tl4.Content = s_km[15]; tr2.Content = s_km[17];
            tl5.Content = t_no[18]; tr7.Content = t_no[20];
            tl6.Content = s_km[18]; tr8.Content = s_km[20];
            tl7.Content = t_no[19]; tr5.Content = t_no[21];
            tl8.Content = s_km[19]; tr6.Content = s_km[21];
            tl9.Content = t_no[22]; tr11.Content = t_no[24];
            tl10.Content = s_km[22]; tr12.Content = s_km[24];
            tl11.Content = t_no[23]; tr9.Content = t_no[25];
            tl12.Content = s_km[23]; tr10.Content = s_km[25];
            adno.Content = t_no[26];adkm.Content = s_km[26];
        }
        private void View_Back_Click(object sender, RoutedEventArgs e)
        {
            tyre_view.Visibility = Visibility.Hidden;
            t_no.Clear();
            s_km.Clear();
            zl1.Content = ""; zr1.Content = "";
            zl2.Content = ""; zr2.Content = "";
            zl3.Content = ""; zr5.Content = "";
            zl4.Content = ""; zr6.Content = "";
            zl5.Content = ""; zr3.Content = "";
            zl6.Content = ""; zr4.Content = "";
            zl7.Content = ""; zr9.Content = "";
            zl8.Content = ""; zr10.Content = "";
            zl9.Content = ""; zr7.Content = "";
            zl10.Content = ""; zr8.Content = "";

            tl1.Content = ""; tr3.Content = "";
            tl2.Content = ""; tr4.Content = "";
            tl3.Content = ""; tr1.Content = "";
            tl4.Content = ""; tr2.Content = "";
            tl5.Content = ""; tr7.Content = "";
            tl6.Content = ""; tr8.Content = "";
            tl7.Content = ""; tr5.Content = "";
            tl8.Content = ""; tr6.Content = "";
            tl9.Content = ""; tr11.Content = "";
            tl10.Content = ""; tr12.Content = "";
            tl11.Content = ""; tr9.Content = "";
            tl12.Content = ""; tr10.Content ="";
        }

     

        private void tyre_vehicle_numbers_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(tyre_vehicle_numbers.Text))
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select type from vechicle_details where vehicle_number='" + tyre_vehicle_numbers.Text + "'", con.conn);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string no = dr[0].ToString();
                        string ctn=null;
                        string btn=null;
                        if (no != null)
                        {
                            if(no.Length==5)
                            {
                                 ctn = no.Substring(0, 2);
                                 btn = no.Substring(3, 2);
                            }
                            else if(no.Length==4)
                            {
                                 ctn = Regex.Replace(no.Substring(0, 2), "[^0-9]+", string.Empty);                                
                                 btn = Regex.Replace(no.Substring(-2, 2), "[^0-9]+", string.Empty);
                            }
                            else if(no.Length==3)
                            {
                                ctn = no.Substring(0, 1);
                                btn = no.Substring(-1, 1);
                            }
                            button_visible();
                            
                            if (ctn == "6" && btn == "8")
                            {
                                but1.Visibility = Visibility.Hidden; but2.Visibility = Visibility.Hidden; but14.Visibility = Visibility.Hidden; but15.Visibility = Visibility.Hidden;
                                but3.Visibility = Visibility.Hidden; but5.Visibility = Visibility.Hidden; but12.Visibility = Visibility.Hidden; but13.Visibility = Visibility.Hidden;
                            }
                            else if (ctn == "6" && btn == "12")
                            {
                                but4.Visibility = Visibility.Hidden; but6.Visibility = Visibility.Hidden; but14.Visibility = Visibility.Hidden; but15.Visibility = Visibility.Hidden;                               
                            }
                            else if (ctn == "10" && btn == "8")
                            {                                
                                but3.Visibility = Visibility.Hidden; but5.Visibility = Visibility.Hidden; but12.Visibility = Visibility.Hidden; but13.Visibility = Visibility.Hidden;
                            }
                            else if (ctn == "10" && btn == "12")
                            {
                                button_visible();
                            }
                        }
                        else
                        {
                            tyre_vehicle_numbers.Text = string.Empty;
                            MessageBox.Show("Vehicle Type Not Exist");
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Please Select Vehicle Number");
                }
            }
           
        }
        void button_visible()
        {
            but1.Visibility = Visibility.Visible; but2.Visibility = Visibility.Visible; but3.Visibility = Visibility.Visible; but4.Visibility = Visibility.Visible;
            but5.Visibility = Visibility.Visible; but6.Visibility = Visibility.Visible; but7.Visibility = Visibility.Visible; but8.Visibility = Visibility.Visible;
            but9.Visibility = Visibility.Visible; but10.Visibility = Visibility.Visible; but11.Visibility = Visibility.Visible; but12.Visibility = Visibility.Visible;
            but13.Visibility = Visibility.Visible; but14.Visibility = Visibility.Visible; but15.Visibility = Visibility.Visible; but16.Visibility = Visibility.Visible;
            but17.Visibility = Visibility.Visible; but18.Visibility = Visibility.Visible; but19.Visibility = Visibility.Visible; but20.Visibility = Visibility.Visible;
            but21.Visibility = Visibility.Visible; bu22.Visibility = Visibility.Visible;addtional.Visibility = Visibility.Visible;
            Veh_img.Visibility = Visibility.Visible;
            ad_img.Visibility = Visibility.Visible;
            ad_line.Visibility = Visibility.Visible;
        }

        
    }
}
