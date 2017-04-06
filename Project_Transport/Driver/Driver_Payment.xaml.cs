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
    /// Interaction logic for Driver_Payment.xaml
    /// </summary>
    public partial class Driver_Payment : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        //string chr = null;
        string v_number = null;
        public Driver_Payment()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            print_pay_slip_panel.Visibility = System.Windows.Visibility.Hidden;
            driver_pay_img2.Visibility = System.Windows.Visibility.Hidden;
            driver_pay_update_img2.Visibility = System.Windows.Visibility.Hidden;
            insert.Visibility = System.Windows.Visibility.Hidden;
            update.Visibility = System.Windows.Visibility.Hidden;
           
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Connection con = new Connection();
                //con.open_connection();
                //OdbcCommand cmd = new OdbcCommand("select driver_id from driver_advance  group by driver_id", con.conn);
                //OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        driver_id.Items.Add(dt.Rows[i]["driver_id"]);
                //    }

                //}
                int year1 = DateTime.Now.Year;
                for (int i = 1; i < 6; i++)
                {
                    year.Items.Add(year1);
                    year1 -= 1;
                }
            }
            catch
            {
                MessageBox.Show("Error Load Year in Driver Payment");
            }
           
        }
        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {
                driver_pay_img1.Visibility = System.Windows.Visibility.Visible;
                driver_pay_img2.Visibility = System.Windows.Visibility.Hidden;
                time1.Stop();                                  
            }
            ii++;
        }
       


        void driver_id_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter )
            {
               
                if (!string.IsNullOrWhiteSpace(month.Text)&&!string.IsNullOrWhiteSpace(year.Text) && !string.IsNullOrWhiteSpace(driver_id.Text))
                    {
                    string user = Properties.Settings.Default.User;
                    if (user == "ADMIN" || user == "MANAGER")
                    {
                        string str = driver_id.Text;
                        if (Regex.IsMatch(str, "^[0-9]{4}[A-Za-z].*[0-9]{3}"))
                        {
                            try
                            {
                                double t_km = 0;
                                Connection con = new Connection();
                                con.open_connection();
                                int len = driver_id.Text.Length;
                                string s = driver_id.Text.Substring(0, len - 4);
                                OdbcCommand cmd = new OdbcCommand("select vehicle_number from lpg_trip_details where month(LOAD_DATE)='" + month.Text + "' and year(LOAD_DATE)='" + year.Text + "' and driver_name='" + s + "' and trip_status='UNLOADED'", con.conn);
                                OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                                DataTable DT = new DataTable();
                                DA.Fill(DT);
                                if (DT.Rows.Count > 0)
                                {
                                    MessageBox.Show("One of the Trip is Not Closed, Please Close First");
                                }
                                else
                                {
                                    string m = month.Text.Substring(0, 2);
                                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number,sum(total_km) as total_km,sum(advance) as advance,sum(expense) as expense,sum(balance) as balance  from driver_advance where driver_id='" + driver_id.Text + "' AND year(closed_date)='" + year.Text + "' and month(closed_date)='" + m + "'", con.conn);
                                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["total_km"].ToString()))
                                        {
                                            t_km = Convert.ToDouble(dt.Rows[0]["total_km"]);
                                            total_km.Content = t_km;
                                            driver_advance.Content = Convert.ToDouble(dt.Rows[0]["advance"]);
                                            expense.Content = Convert.ToDouble(dt.Rows[0]["expense"]);
                                            driver_balance.Content = Convert.ToDouble(dt.Rows[0]["balance"]);
                                            v_number = dt.Rows[0]["vehicle_number"].ToString();
                                            if (t_km > 3000)
                                            {
                                                expense_cost.IsEnabled = true;
                                            }
                                            else
                                            {
                                                expense_cost.IsEnabled = false;
                                            }
                                            OdbcCommand cmd3 = new OdbcCommand("SELECT COUNT(vehicle_number) AS nos FROM lpg_trip_details WHERE YEAR(load_date)='" + year.Text + "' AND MONTH(LOAD_DATE)='" + m + "' AND VEHICLE_NUMBER='" + v_number + "' AND TRIP_STATUS='closed'", con.conn);
                                            OdbcDataReader dr = cmd3.ExecuteReader();
                                            while (dr.Read())
                                            {
                                                total_trip.Content = dr[0];
                                            }
                                            OdbcCommand cmd2 = new OdbcCommand("select remarks_reason,allowance,salary,grand_pay,fine_amount from driver_remarks where driver_id='" + driver_id.Text + "' and remarks_month='" + m + "' and remarks_year='" + year.Text + "'", con.conn);
                                            OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                                            DataTable dt2 = new DataTable();
                                            da2.Fill(dt2);
                                            if (dt2.Rows.Count > 0)
                                            {
                                                km_expense.Content = dt2.Rows[0]["allowance"].ToString();
                                                salary.Text = dt2.Rows[0]["salary"].ToString();
                                                remarks.Text = dt2.Rows[0]["remarks_reason"].ToString();
                                                remarks_reason.Text = dt2.Rows[0]["fine_amount"].ToString();
                                                grand_pay.Content = dt2.Rows[0]["grand_pay"];
                                                update.Visibility = System.Windows.Visibility.Visible;
                                                insert.Visibility = System.Windows.Visibility.Hidden;
                                                MessageBox.Show("Records Founded");
                                            }
                                            else
                                            {
                                                insert.Visibility = System.Windows.Visibility.Visible;
                                                km_expense.Content = "0"; salary.Text = "0"; remarks.Text = "NOTHING"; remarks_reason.Text = "0"; grand_pay.Content = "0";
                                                update.Visibility = System.Windows.Visibility.Hidden;
                                            }
                                        }
                                        else
                                        {
                                            total_km.Content = "0"; driver_advance.Content = "0"; expense.Content = "0"; driver_balance.Content = "0";
                                            expense_cost.IsEnabled = false;
                                            MessageBox.Show("Record Not Found");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Driver details not Exist");
                                    }
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
                            MessageBox.Show("Incorrect Driver Id Format");
                            e.Handled = true;
                            driver_id.Text = "";
                        }

                    }
                    else
                    {
                        MessageBox.Show("Access Denied");
                    }
                   
                    }
                    else
                    {
                        MessageBox.Show("Please Select Month,Year and Driver Id");
                        e.Handled = true;
                    }               
            }
            else
            {
               // MessageBox.Show("Must Select Driver Id");
            }
        }


       



        void driver_salary_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                double d = Convert.ToDouble(driver_balance.Content);
                if(string.IsNullOrWhiteSpace(remarks_reason.Text))
                {
                    remarks_reason.Text = "0";
                }
                if (string.IsNullOrWhiteSpace(remarks.Text))
                {
                    remarks.Text = "NOTHING";
                }
                if (string.IsNullOrWhiteSpace(salary.Text))
                {
                    salary.Text = "";
                    MessageBox.Show("Please Enter Salary");
                    e.Handled = true;
                }
                else
                {                   
                        grand_pay.Content = Convert.ToDouble(salary.Text) - d + Convert.ToDouble(km_expense.Content) - Convert.ToDouble(remarks_reason.Text);                   
                }
                
            }

        }

        void expense_cost_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(string.IsNullOrWhiteSpace(expense_cost.Text))
                {
                    expense_cost.Text = "0";
                }
                try
                {
                    double tkm = Convert.ToDouble(total_km.Content) - 3000;
                    km_expense.Content = Convert.ToDouble(expense_cost.Text) * tkm;
                }
                catch
                {
                    MessageBox.Show("Total KM is Empty");
                }

            }
        }


        void driver_salary_done_click(Object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER")
            {
                MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Insert Payment", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (mr == MessageBoxResult.OK)
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        double sa = 0;
                        double re = 0;
                        if (!string.IsNullOrWhiteSpace(salary.Text))
                        {
                            sa = Convert.ToDouble(salary.Text);
                        }
                        if (!string.IsNullOrWhiteSpace(remarks_reason.Text))
                        {
                            re = Convert.ToDouble(remarks_reason.Text);
                        }
                        // double profit = Convert.ToDouble(grand_profit.Content);
                        double payment = Convert.ToDouble(grand_pay.Content);
                        string MONTH = month.Text.Substring(0, 2);
                        if (sa == 0)
                        {
                            MessageBox.Show("Calculate Salary then press DONE Button");
                        }
                        else
                        {
                            driver_pay_img1.Visibility = System.Windows.Visibility.Hidden;
                            driver_pay_img2.Visibility = System.Windows.Visibility.Visible;
                            time1.Start();
                            OdbcCommand cmdd = new OdbcCommand("insert into driver_remarks(driver_id,remarks_reason,fine_amount,allowance,salary,grand_pay,remarks_month,remarks_year,total_trips,total_km,total_advance,total_expense,advance_balance,date)values('" + driver_id.Text + "','" + remarks.Text + "'," + re + "," + Convert.ToDouble(km_expense.Content) + ",'" + sa + "','" + payment + "','" + MONTH + "','" + year.Text + "','" + Convert.ToInt32(total_trip.Content) + "','" + Convert.ToInt32(total_km.Content) + "','" + Convert.ToInt32(driver_advance.Content) + "','" + Convert.ToDouble(expense.Content) + "','" + Convert.ToDouble(driver_balance.Content) + "',now())", con.conn);
                            cmdd.ExecuteNonQuery();
                            insert.Visibility = System.Windows.Visibility.Hidden;                                                                                  
                            MessageBoxResult mrs = MessageBox.Show("Are You Want payment Slip", "Pay Slip", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if(mrs==MessageBoxResult.OK)
                            {
                                print_pay_slip_panel.Visibility = System.Windows.Visibility.Visible;                                
                                Report_viewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Driver_Pay_Report.rdlc";
                                ReportParameter[] param = new ReportParameter[13];
                                param[0] = new ReportParameter("Title", Properties.Settings.Default.Title.ToString());
                                param[1] = new ReportParameter("MonthYear", month.Text.Substring(0, 2) + "/" + year.Text);
                                param[2] = new ReportParameter("Date", Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy"));
                                param[3] = new ReportParameter("Driver_id", driver_id.Text);
                                param[4] = new ReportParameter("Total_trip", total_trip.Content.ToString());
                                param[5] = new ReportParameter("Total_advance", driver_advance.Content.ToString());
                                param[6] = new ReportParameter("Expense", expense.Content.ToString());
                                param[7] = new ReportParameter("Balance", driver_balance.Content.ToString());
                                param[8] = new ReportParameter("Allowance", km_expense.Content.ToString());
                                param[9] = new ReportParameter("Remarks", remarks.Text);
                                param[10] = new ReportParameter("Fine", remarks_reason.Text);
                                param[11] = new ReportParameter("Salary", salary.Text);
                                param[12] = new ReportParameter("Grand_pay", grand_pay.Content.ToString());
                                Report_viewer.LocalReport.SetParameters(param);
                                Report_viewer.RefreshReport();
                            }
                            else if(mrs==MessageBoxResult.Cancel)
                            {

                            }
                            total_trip.Content = "0"; total_km.Content = "0"; driver_advance.Content = "0"; expense.Content = "0"; driver_balance.Content = "0"; expense_cost.Text = ""; expense_cost.IsEnabled = false;
                            km_expense.Content = "0"; salary.Text = "0"; remarks.Text = "NOTHING"; remarks_reason.Text = "0"; grand_pay.Content = "0"; month.Text = ""; year.Text = ""; driver_id.Text = "";
                        }                        
                        con.close_connection();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else if (mr == MessageBoxResult.Cancel)
                {

                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           

        }

        void Payment_Report_Back_Click(object sender,RoutedEventArgs e)
        {
            Report_viewer.Clear();
            //Report_viewer.Reset();           
            print_pay_slip_panel.Visibility = System.Windows.Visibility.Hidden;
        }
       
        

        void driver_salary_update_click(Object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER")
            {
                if (!string.IsNullOrWhiteSpace(driver_id.Text) && !string.IsNullOrWhiteSpace(remarks.Text) && !string.IsNullOrWhiteSpace(remarks_reason.Text) && !string.IsNullOrWhiteSpace(km_expense.Content.ToString()) && !string.IsNullOrWhiteSpace(salary.Text) && !string.IsNullOrWhiteSpace(grand_pay.Content.ToString()) && !string.IsNullOrWhiteSpace(month.Text) && !string.IsNullOrWhiteSpace(year.Text))
                {
                    try
                    {
                        string MONTH = month.Text.Substring(0, 2);
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmdd = new OdbcCommand("update driver_remarks set driver_id='" + driver_id.Text + "',remarks_reason='" + remarks.Text + "',fine_amount='" + remarks_reason.Text + "',allowance='" + km_expense.Content + "',salary='" + salary.Text + "',grand_pay='" + grand_pay.Content + "' where remarks_month='" + MONTH + "' and remarks_year='" + year.Text + "' and driver_id='" + driver_id.Text + "'", con.conn);
                        cmdd.ExecuteNonQuery();
                        driver_pay_update_img1.Visibility = System.Windows.Visibility.Hidden;
                        driver_pay_update_img2.Visibility = System.Windows.Visibility.Visible;
                        time1.Start();
                        con.close_connection();
                        update.Visibility = System.Windows.Visibility.Hidden;
                        total_trip.Content = "0"; total_km.Content = "0"; driver_advance.Content = "0"; expense.Content = "0"; driver_balance.Content = "0"; expense_cost.Text = ""; expense_cost.IsEnabled = false;
                        km_expense.Content = "0"; salary.Text = "0"; remarks.Text = "NOTHING"; remarks_reason.Text = "0"; grand_pay.Content = "0"; month.Text = ""; year.Text = ""; driver_id.Text = "";
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Empty Field");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
           
            
            
        }
        void driver_payment_back_click(Object sender, RoutedEventArgs e)
        {
            total_trip.Content = "0"; total_km.Content = "0"; driver_advance.Content = "0"; expense.Content = "0"; driver_balance.Content = "0"; expense_cost.Text = ""; expense_cost.IsEnabled = false;
            km_expense.Content = "0"; salary.Text = "0"; remarks.Text = "NOTHING"; remarks_reason.Text = "0"; grand_pay.Content = "0"; month.Text = ""; year.Text = ""; driver_id.Text = "";
            MainWindow m = new MainWindow();
            m.driver_salary.Visibility = Visibility.Hidden;
        }

       

        void Payment_Month_PreviewKeydown(object sender, KeyEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(month.Text))
            {
                int len = month.Text.Length;
                string s = month.Text;
                if (e.Key == Key.Back)
                {
                    e.Handled = false;
                }
                else if (len == 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (char.IsLetter(s[i]))
                        {
                            System.Media.SystemSounds.Beep.Play();
                            e.Handled = true;
                            MessageBox.Show("Should Enter Month Value");
                            month.Text = "";

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
                        month.Text = "";
                    }
                }
                else if (len > 6)
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                    month.Text = "";
                }
            }
            else
            {
                //MessageBox.Show("Select Month");
            }
           
        }
        void Payment_Year_PreviewKeydown(object sender, KeyEventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(year.Text))
            {

                int len = year.Text.Length;
                if (e.Key == Key.Back)
                {
                    e.Handled = false;
                }
                else if (len <= 4)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (char.IsDigit(year.Text[i]))
                        {

                        }
                        else
                        {
                            System.Media.SystemSounds.Beep.Play();
                            e.Handled = true;
                            MessageBox.Show("Allowed Numbers Only");
                            year.Text = "";

                        }
                    }
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                    year.Text = "";
                }
            }
           else
            {
                //MessageBox.Show("Select Year");
            }
        }
        void Payment_Id_PreviewKeydown(object sender, KeyEventArgs e)
        {
            //int len = 0;
            //if (!string.IsNullOrWhiteSpace(driver_id.Text))
            //{

            //    len = driver_id.Text.Length;
            //}
            //else
            //{
            //    len = 0;
            //}

            //if (len >= 20)
            //{
            //    if (e.Key != Key.Back)
            //    {
            //        System.Media.SystemSounds.Beep.Play();
            //        e.Handled = true;
            //    }

            //}
        }
        void Extra_Allowance_Textchanged(object sender, TextChangedEventArgs e)
        {
            string s = expense_cost.Text; 
            int len = s.Length;
            if (len == 1)
            {
               
                
                for (int i = 0; i < len; i++)
                {
                    bool isdigit = char.IsDigit(s[i]);
                    if (isdigit)
                    {
                  
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                        e.Handled = true;
                    }
                }

            }
            else if(len==2)
            {
                String SUB = s.Substring(1, 1);
                if( SUB.Equals("."))
                {

                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                    expense_cost.Text = "";
                }
            }
           


        }
        void Expense_Cost_Previewtextinput(object sender,TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }
        void Expense_Cost_Gotfocus(object sender,RoutedEventArgs e)
        {
            expense_cost.Text = "";
        }
        void Remarks_Reason_Gotfocus(object sender, RoutedEventArgs e)
        {
            remarks.Text = "";
        }
        void Remarks_Amount_Gotfocus(object sender, RoutedEventArgs e)
        {
            remarks_reason.Text = "";
        }
        void Salary_Gotfocus(object sender, RoutedEventArgs e)
        {
            salary.Text = "";
        }

        private void driver_id_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select driver_id from driver_advance  group by driver_id", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    driver_id.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        driver_id.Items.Add(dt.Rows[i]["driver_id"]);
                    }

                }
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
           
        }

        private void month_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                string s = month.Text;
                if (Regex.IsMatch(s, "^[0-9]{2}[-]{1}[A-Za-z]{3}"))
                {
                    //MessageBox.Show("String Not Matched");
                }
                else
                {
                    MessageBox.Show("Month Not Matched");
                    e.Handled = true;
                    month.Text = "";
                }
            }
        }

        private void year_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                string s = year.Text;
                if (Regex.IsMatch(s, "^[0-9]{4}"))
                {
                    int year1 = DateTime.Now.Year;
                    int cur = Convert.ToInt32(year.Text);
                    if (cur > year1)
                    {
                        MessageBox.Show("Year Value is Greater then Current Year");
                        year.Text = "";
                        e.Handled = true;
                    }
                    else if (cur < year1 - 5)
                    {
                        MessageBox.Show("Year Value is Below the Before Five Year");
                        year.Text = "";
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Year Not Matched");
                    e.Handled = true;
                    year.Text = "";
                }
            }
        }
    }
}
