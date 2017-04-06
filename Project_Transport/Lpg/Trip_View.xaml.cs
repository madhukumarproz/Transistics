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
    /// Interaction logic for Trip_View.xaml
    /// </summary>
    public partial class Trip_View : UserControl
    {
        public Trip_View()
        {
            InitializeComponent();
           
            l1.Visibility = System.Windows.Visibility.Hidden;
            l2.Visibility = System.Windows.Visibility.Hidden;
            lpg_from.Visibility = System.Windows.Visibility.Hidden;
            lpg_to.Visibility = System.Windows.Visibility.Hidden;
            b1.Visibility = System.Windows.Visibility.Hidden;
           
            Okay_btn.Visibility= System.Windows.Visibility.Hidden;
            viewcmb.Visibility = System.Windows.Visibility.Hidden;
            lpg_trip_expense.Visibility= System.Windows.Visibility.Hidden;
            int y = Convert.ToInt32(Convert.ToDateTime(DateTime.Now).ToString("yyyy"));
            for(int i=0;i<5;i++)
            {
                lpg_to.Items.Add(y);
                y -= 1;
            }
        }

       
        
       
        void on_trip_checked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Trip_Vehicle_Number = "";            
            this.DataContext = g;
            Trip_Viewer.Clear();
            Load.Visibility = System.Windows.Visibility.Visible;
            //Unload.Visibility = System.Windows.Visibility.Hidden;
            //Closed.Visibility = System.Windows.Visibility.Hidden;
            
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select vehicle_number from lpg_trip_details where trip_status='RUNNING'", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                viewcmb.Items.Clear();
                viewcmb.Items.Add("ALL");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    viewcmb.Items.Add(dt.Rows[i]["vehicle_number"]);
                }

               
                l1.Visibility = System.Windows.Visibility.Hidden;
                l2.Visibility = System.Windows.Visibility.Hidden;
                lpg_from.Visibility = System.Windows.Visibility.Hidden;
                lpg_to.Visibility = System.Windows.Visibility.Hidden;
                b1.Visibility = System.Windows.Visibility.Hidden;
                
                Okay_btn.Visibility = System.Windows.Visibility.Visible;
                viewcmb.Visibility = System.Windows.Visibility.Visible;
                lpg_trip_expense.Visibility = System.Windows.Visibility.Hidden;
                lpg_trip_expense.Text = "";
               
            }
            else
            {
                lpg_load_details_view.ItemsSource = null;
                lpg_load_details_view.Items.Refresh();
                MessageBox.Show("Record Not Found");
                viewcmb.Items.Clear();
                
            }

        }
        void unloaded_cheched(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Trip_View_Number = "";
            this.DataContext = g;
            //Trip_Viewer1.Clear();
            Load.Visibility = System.Windows.Visibility.Visible;
           // Unload.Visibility = System.Windows.Visibility.Visible;
            //Closed.Visibility = System.Windows.Visibility.Hidden;
           
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select vehicle_number from lpg_trip_details  where trip_status='UNLOAD'", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                viewcmb.Items.Clear();
                viewcmb.Items.Add("ALL");
                for (int i=0;i< dt.Rows.Count;i++)
                {
                    viewcmb.Items.Add(dt.Rows[i]["vehicle_number"]);
                }
              
                l1.Visibility = System.Windows.Visibility.Hidden;
                l2.Visibility = System.Windows.Visibility.Hidden;
                lpg_from.Visibility = System.Windows.Visibility.Hidden;
                lpg_to.Visibility = System.Windows.Visibility.Hidden;
                b1.Visibility = System.Windows.Visibility.Hidden;
                
                Okay_btn.Visibility = System.Windows.Visibility.Visible;
                viewcmb.Visibility = System.Windows.Visibility.Visible;
                lpg_trip_expense.Visibility = System.Windows.Visibility.Hidden;
                lpg_trip_expense.Text = "";
              
            }
            else
            {
                lpg_load_details_view.ItemsSource = null;
                lpg_load_details_view.Items.Refresh();
                MessageBox.Show("Record Not Found");
                viewcmb.Items.Clear();
                
            }
        }
        void closed_checked(object sender, RoutedEventArgs e)
        {
            Get_String g = new Get_String();
            g.Trip_View_Number = "";
            g.Trip_View_Year = "";
            g.Trip_View_Month = "";
            this.DataContext = g;
            //Trip_Viewer2.Clear();
            Load.Visibility = System.Windows.Visibility.Visible;
            //Unload.Visibility = System.Windows.Visibility.Hidden;
            //Closed.Visibility = System.Windows.Visibility.Visible;
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select CORPORATION,TRIP_NUMBER,DRIVER_NAME,ORIGIN,DESTINATION,DATE_FORMAT(load_date,'%d/%m/%Y') AS LOAD_DATE,DATE_FORMAT(unload_date,'%d/%m/%Y')AS UNLOAD_DATE,LOAD_WEIGHT,UNLOAD_WEIGHT,STARTING_KM,ENDING_KM,TOTAL_KM,TRIP_DIESEL,DIESEL_AMOUNT,TRIP_MILEAGE,TRIP_ADVANCE,TRIP_FRIEGHT,TRIP_EXPENSE,TRIP_BALANCE,TRIP_PROFIT,PAYMENT_TYPE from lpg_trip_details  where trip_status='CLOSED'", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                
               
                l1.Visibility = System.Windows.Visibility.Visible;
                l2.Visibility = System.Windows.Visibility.Visible;
                lpg_from.Visibility = System.Windows.Visibility.Visible;
                lpg_to.Visibility = System.Windows.Visibility.Visible;
                b1.Visibility = System.Windows.Visibility.Visible;
                
                Okay_btn.Visibility = System.Windows.Visibility.Hidden;
                viewcmb.Visibility = System.Windows.Visibility.Hidden;
                lpg_trip_expense.Visibility = System.Windows.Visibility.Visible;
                lpg_trip_expense.Text = "";
                
            }
            else
            {
                lpg_load_details_view.ItemsSource = null;
                lpg_load_details_view.Items.Refresh();
                MessageBox.Show("Record Not Found");
                
            }

        }

        void Trip_View_Okay_Button_Click(object sender,RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                if (on_trip_check.IsChecked == true & viewcmb.Text.Equals("ALL"))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select TRIP_NUMBER,DRIVER_NAME,ORIGIN,DESTINATION,LOAD_WEIGHT,DATE_FORMAT(load_date,'%d/%m/%Y')AS LOAD_DATE,STARTING_KM from lpg_trip_details where  trip_status='RUNNING'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {


                            Trip_Viewer.LocalReport.DataSources.Clear();
                            ReportDataSource ds = new ReportDataSource("Trip_Load_Dataset", dt);
                            Trip_Viewer.LocalReport.DataSources.Add(ds);
                            Trip_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Trip_Report1.rdlc";
                            Trip_Viewer.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("No One Vehicle is Running Stage");

                        }

                        con.close_connection();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }

                }
                else if (on_trip_check.IsChecked == true & !string.IsNullOrWhiteSpace(viewcmb.Text))
                {
                    string l = viewcmb.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        viewcmb.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select TRIP_NUMBER,DRIVER_NAME,ORIGIN,DESTINATION,LOAD_WEIGHT,DATE_FORMAT(load_date,'%d/%m/%Y')AS LOAD_DATE,STARTING_KM from lpg_trip_details where vehicle_number='" + viewcmb.Text + "' and trip_status='RUNNING'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {

                                Trip_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Trip_Load_Dataset", dt);
                                Trip_Viewer.LocalReport.DataSources.Add(ds);
                                Trip_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Trip_Report1.rdlc";
                                Trip_Viewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("The Vehicle Number is not in Running Stage");

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
                        MessageBox.Show("Invalid Vehicle Number Format");
                    }



                }
                else if (unloaded_check.IsChecked == true & viewcmb.Text.Equals("ALL"))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select TRIP_NUMBER,DRIVER_NAME,ORIGIN,DESTINATION,UNLOAD_WEIGHT,DATE_FORMAT(unload_date,'%d/%m/%Y')AS UNLOAD_DATE,TOTAL_KM,TRIP_DIESEL,DIESEL_AMOUNT,TRIP_MILEAGE from lpg_trip_details where  trip_status='UNLOADED'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Trip_Viewer.Reset();
                            Trip_Viewer.Clear();
                            Trip_Viewer.LocalReport.DataSources.Clear();
                            ReportDataSource ds = new ReportDataSource("Trip_Unload_DataSet", dt);
                            Trip_Viewer.LocalReport.DataSources.Add(ds);
                            Trip_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Trip_Report2.rdlc";
                            Trip_Viewer.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("No one Vehicle is Unload Stage");

                        }

                        con.close_connection();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }

                }
                else if (unloaded_check.IsChecked == true & !string.IsNullOrWhiteSpace(viewcmb.Text))
                {
                    string l = viewcmb.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        viewcmb.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select TRIP_NUMBER,DRIVER_NAME,ORIGIN,DESTINATION,UNLOAD_WEIGHT,DATE_FORMAT(unload_date,'%d/%m/%Y')AS UNLOAD_DATE,TOTAL_KM,TRIP_DIESEL,DIESEL_AMOUNT,TRIP_MILEAGE from lpg_trip_details where vehicle_number='" + viewcmb.Text + "' and trip_status='UNLOADED'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Trip_Viewer.Reset();
                                Trip_Viewer.Clear();
                                Trip_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("Trip_Unload_DataSet", dt);
                                Trip_Viewer.LocalReport.DataSources.Add(ds);
                                Trip_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Trip_Report2.rdlc";
                                Trip_Viewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("The Vehicle Number is not Unload Stage");

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
                        MessageBox.Show("Invalid Vehicle Number Format");
                    }


                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

           
        }
        void lpg_trip_expense_keydown(object sender, KeyEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                if (closed_check.IsChecked == true)
                {
                    if (e.Key == Key.Tab | e.Key == Key.Enter)
                    {
                        string l = lpg_trip_expense.Text;
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                        {
                            MessageBox.Show("Incorrect Number Format");
                            e.Handled = true;
                            viewcmb.Text = "";
                        }
                        else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("select TRIP_NUMBER,DRIVER_NAME,ORIGIN,DESTINATION,LOAD_WEIGHT,UNLOAD_WEIGHT,DATE_FORMAT(unload_date,'%d/%m/%Y')AS UNLOAD_DATE,TOTAL_KM,TRIP_DIESEL,DIESEL_AMOUNT,TRIP_MILEAGE AS MILEAGE_KMPL,TRIP_ADVANCE,TRIP_FRIEGHT,TRIP_EXPENSE,TRIP_BALANCE,TRIP_PROFIT from lpg_trip_details where vehicle_number='" + lpg_trip_expense.Text + "' and trip_status='CLOSED'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    Trip_Viewer.Reset();
                                    Trip_Viewer.Clear();
                                    Trip_Viewer.LocalReport.DataSources.Clear();
                                    ReportDataSource ds = new ReportDataSource("OnTrip_Dataset", dt);
                                    Trip_Viewer.LocalReport.DataSources.Add(ds);
                                    Trip_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Trip_Report.rdlc";
                                    Trip_Viewer.RefreshReport();



                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found");
                                    e.Handled = true;
                                }
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show("Data Getting Error" + ex.Message);
                            }

                        }
                        else if (Regex.IsMatch(l, "^[0-9]{6}[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[0-9]{6}[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[0-9]{6}[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[0-9]{6}[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("select TRIP_NUMBER,DRIVER_NAME,ORIGIN,DESTINATION,LOAD_WEIGHT,UNLOAD_WEIGHT,DATE_FORMAT(unload_date,'%d/%m/%Y')AS UNLOAD_DATE,TOTAL_KM,TRIP_DIESEL,DIESEL_AMOUNT,TRIP_MILEAGE AS MILEAGE_KMPL,TRIP_ADVANCE,TRIP_FRIEGHT,TRIP_EXPENSE,TRIP_BALANCE,TRIP_PROFIT from lpg_trip_details where trip_number='" + lpg_trip_expense.Text + "' and trip_status='CLOSED'", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    Trip_Viewer.Reset();
                                    Trip_Viewer.Clear();
                                    Trip_Viewer.LocalReport.DataSources.Clear();
                                    ReportDataSource ds = new ReportDataSource("OnTrip_Dataset", dt);
                                    Trip_Viewer.LocalReport.DataSources.Add(ds);
                                    Trip_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Trip_Report.rdlc";
                                    Trip_Viewer.RefreshReport();

                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found");
                                    e.Handled = true;
                                }
                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Incorrect Trip or Vehicle Number");
                        }
                    }


                }
                else
                {
                    //MessageBox.Show("Check whether the entered detail is correct");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

           
        }


        void lpg_datewise_view_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                if (!string.IsNullOrWhiteSpace(lpg_from.Text) & !string.IsNullOrWhiteSpace(lpg_to.Text) & !string.IsNullOrWhiteSpace(lpg_trip_expense.Text))
                {
                    string l = lpg_trip_expense.Text;
                    if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{8}"))
                    {
                        MessageBox.Show("Incorrect Number Format");
                        e.Handled = true;
                        viewcmb.Text = "";
                    }
                    else if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}")|| Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            String s = lpg_from.Text.Substring(0, 2);

                            OdbcCommand cmd = new OdbcCommand("select TRIP_NUMBER,DRIVER_NAME,ORIGIN,DESTINATION,LOAD_WEIGHT,UNLOAD_WEIGHT,DATE_FORMAT(unload_date,'%d/%m/%Y')AS UNLOAD_DATE,TOTAL_KM,TRIP_DIESEL,DIESEL_AMOUNT,TRIP_MILEAGE AS MILEAGE_KMPL,TRIP_ADVANCE,TRIP_FRIEGHT,TRIP_EXPENSE,TRIP_BALANCE,TRIP_PROFIT from lpg_trip_details  where vehicle_number='" + lpg_trip_expense.Text + "' and year(load_date)='" + lpg_to.Text + "' and month(load_date)='" + s + "' and trip_status='CLOSED' ", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                Trip_Viewer.Reset();
                                Trip_Viewer.Clear();
                                Trip_Viewer.LocalReport.DataSources.Clear();
                                ReportDataSource ds = new ReportDataSource("OnTrip_Dataset", dt);
                                Trip_Viewer.LocalReport.DataSources.Add(ds);
                                Trip_Viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Lpg_Trip_Report.rdlc";
                                Trip_Viewer.RefreshReport();
                            }
                            else
                            {
                                MessageBox.Show("Validation Errors Found");

                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Incorrect Vehicle Number");
                    }



                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

           
        }

      
        void Trip_View_Month_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(lpg_from.Text))
            {

                len = lpg_from.Text.Length;
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
        void Trip_View_Year_PreviewKeydown(object sender, KeyEventArgs e)
        {
            int len = 0;
            if (!string.IsNullOrWhiteSpace(lpg_to.Text))
            {

                len = lpg_to.Text.Length; 
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

        private void lpg_from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                string s = lpg_from.Text;
                if (Regex.IsMatch(s, "^[0-9]{2}[-]{1}[A-Za-z]{3}"))
                {
                    //MessageBox.Show("String Not Matched");
                }
                else
                {
                    MessageBox.Show("Incorrect Month Format");
                    e.Handled = true;
                    lpg_from.Text = "";
                }
            }
        }

        private void lpg_to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                string s = lpg_to.Text;
                if (Regex.IsMatch(s, "^[0-9]{4}"))
                {
                    int year1 = DateTime.Now.Year;
                    int cur = Convert.ToInt32(lpg_to.Text);
                    if (cur > year1)
                    {
                        MessageBox.Show("Year Value is Greater then Current Year");
                        lpg_to.Text = "";
                        e.Handled = true;
                    }
                    else if (cur < year1 - 5)
                    {
                        MessageBox.Show("Year Value is Below the Before Five Year");
                        lpg_to.Text = "";
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Year Format");
                    e.Handled = true;
                    lpg_to.Text = "";
                }
            }
        }

        private void viewcmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                string s = viewcmb.Text;
                if (Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{5}") || Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{7}") || Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{8}"))
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    viewcmb.Text = "";
                }
                else if (Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}"))
                {
                    //MessageBox.Show("String Not Matched");
                }
                else if(Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}"))
                {

                }
                else if(Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}"))
                {

                }
                else if(Regex.IsMatch(s, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}"))
                {

                }
                else
                {
                    MessageBox.Show("Incorrect Number Format");
                    e.Handled = true;
                    viewcmb.Text = "";
                }
            }
        }
    }
}
