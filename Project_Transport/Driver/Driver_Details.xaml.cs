using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Driver_Details.xaml
    /// </summary>
    
    public partial class Driver_Details : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        string chr = null;
        string s1=null,s2=null,s3=null,s=null;
        
       
       
        public Driver_Details()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            driver_detail_insert_img2.Visibility = System.Windows.Visibility.Hidden;
            

        }


        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {
                if (chr == "i")
                {
                    driver_detail_insert_img1.Visibility = System.Windows.Visibility.Visible;
                    driver_detail_insert_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
               
               
               
            }
            ii++;
        }
        void driver_lpg_checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details WHERE (status='OPEN' OR status IS NULL) AND (corporation='IOC' or corporation='BPC' or corporation='HPC')", con.conn);
                OdbcDataAdapter dr = new OdbcDataAdapter(cmd);
                DataTable dtt = new DataTable();
                dr.Fill(dtt);
                d_v_number.Items.Clear();
                if (dtt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtt.Rows.Count; i++)
                    {

                        d_v_number.Items.Add(dtt.Rows[i]["vehicle_number"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("There is no Empty Vehicle to Assign");
                }


                con.close_connection();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
           
            //d_v_number.IsEditable = false;
            //numbers_clear.IsEnabled = true;
        }


        void driver_trailer_checked(Object SENDER, RoutedEventArgs E)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details WHERE (status='OPEN' OR status IS NULL) AND corporation='TLR'", con.conn);
                OdbcDataAdapter dr = new OdbcDataAdapter(cmd);
                DataTable dtt = new DataTable();
                dr.Fill(dtt);
                d_v_number.Items.Clear();
                if (dtt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtt.Rows.Count; i++)
                    {

                        d_v_number.Items.Add(dtt.Rows[i]["vehicle_number"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("There is no Empty Vehicle to Assign");
                }
                con.close_connection();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
           
            //d_v_number.IsEditable = false;
            // numbers_clear.IsEnabled = true;
        }


        void driver_load_checked(Object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details WHERE (status='OPEN' OR status IS NULL) AND corporation='LOD'", con.conn);
                OdbcDataAdapter dr = new OdbcDataAdapter(cmd);
                DataTable dtt = new DataTable();
                dr.Fill(dtt);
                d_v_number.Items.Clear();
                if (dtt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtt.Rows.Count; i++)
                    {

                        d_v_number.Items.Add(dtt.Rows[i]["vehicle_number"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("There is no Empty Vehicle to Assign");
                }
                con.close_connection();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
           
            //d_v_number.IsEditable = false;
            //numbers_clear.IsEnabled = true;
        }


        private void lpg_licence_Checked(object sender, RoutedEventArgs e)
        {
            s1 = "LPG";

        }

        private void trailer_licence_Checked(object sender, RoutedEventArgs e)
        {
            s2 = "TRAILER";

        }

        private void line_licence_Checked(object sender, RoutedEventArgs e)
        {
            s3 = "LINE";

        }

        private void driver_name_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void native_selection_Checked(object sender, RoutedEventArgs e)
        {
            driver_referer_name.Text = "RELATIVE:";
            driver_referer_name.IsEnabled = true;
        }

        private void reference_selection_Checked(object sender, RoutedEventArgs e)
        {
            driver_referer_name.Text = "REFERENCE:";
            driver_referer_name.IsEnabled = true;
        }


      


        void driver_detail_insert_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                if (s1 != null)
                {
                    s = s1;
                }
                if (s2 != null)
                {
                    s = s + "," + s2;
                }
                if (s3 != null)
                {
                    s = s + "," + s3;
                }
                // numbers_clear.IsEnabled = false;           
                if (!string.IsNullOrWhiteSpace(s))
                {

                    if (!string.IsNullOrWhiteSpace(licence_no.Text) & !string.IsNullOrWhiteSpace(driver_name.Text) & !string.IsNullOrWhiteSpace(expiry.Text) & !string.IsNullOrWhiteSpace(d_v_number.Text))
                    {
                        MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (mr == MessageBoxResult.OK)
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                string sub = d_v_number.Text.Substring(d_v_number.Text.Length - 4, 4);
                                string rx = Regex.Match(sub, @"\d+").Value;
                                string str = driver_name.Text + rx;
                                //int d = Int32.Parse("a123");
                                OdbcCommand cm = new OdbcCommand("select vehicle_number from driver_details where vehicle_number like '" + d_v_number.Text + "' and bool=0", con.conn);
                                OdbcDataAdapter d = new OdbcDataAdapter(cm);
                                DataTable t = new DataTable();
                                d.Fill(t);
                                if (t.Rows.Count > 0)
                                {
                                    MessageBox.Show("Already Assigned Driver to this Vehicle");
                                }
                                else
                                {
                                    int max = 0;
                                    OdbcCommand cmd3 = new OdbcCommand("select max(s_no) as maxx from driver_details", con.conn);
                                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                                    DataTable dt1 = new DataTable();
                                    da1.Fill(dt1);
                                    if (dt1.Rows.Count > 0)
                                    {
                                        if (string.IsNullOrWhiteSpace(dt1.Rows[0]["maxx"].ToString()))
                                        {
                                            max = 0;
                                        }
                                        else
                                        {
                                            max = Convert.ToInt32(dt1.Rows[0]["maxx"]);
                                        }
                                    }
                                    max += 1;
                                    if (max <= 9)
                                    {
                                        str = "000" + max + str;
                                    }
                                    else if (max > 9 && max <= 99)
                                    {
                                        str = "00" + max + str;
                                    }
                                    else if (max > 99 && max <= 999)
                                    {
                                        str = "0" + max + str;
                                    }
                                    OdbcCommand cmd = new OdbcCommand("insert into driver_details(vehicle_number,driver_name,licence_number,expiry,address,contact,referer_name,licence_type,bank_name,account_no,branch,ifsc_code,join_date,driver_id)values('" + d_v_number.Text + "','" + driver_name.Text + "','" + licence_no.Text + "','" + Convert.ToDateTime(expiry.Text).ToString("yyyy/MM/dd") + "','" + address.Text + "','" + contact.Text + "','" + driver_referer_name.Text + "','" + s + "','" + bank_name.Text + "','" + account_no.Text + "','" + branch.Text + "','" + ifsc_code.Text + "','" + Convert.ToDateTime(join_date.Text).ToString("yyyy/MM/dd") + "','" + str + "')", con.conn);
                                    cmd.ExecuteNonQuery();
                                    OdbcCommand cmd2 = new OdbcCommand("update vechicle_details set driver_name='" + str + "', status='CLOSED' WHERE vehicle_number='" + d_v_number.Text + "'", con.conn);
                                    cmd2.ExecuteNonQuery();
                                    OdbcCommand cmd1 = new OdbcCommand("select DRIVER_NAME,LICENCE_NUMBER,DATE_FORMAT(expiry,'%d/%m/%Y')AS EXPIRY,LICENCE_TYPE,CONTACT from driver_details", con.conn);
                                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    driver_detail_view.ItemsSource = dt.DefaultView;
                                    driver_detail_view.Columns[0].Width = 110;
                                    driver_detail_view.Columns[1].Width = 110;
                                    driver_detail_view.Columns[3].Width = 90;
                                    driver_detail_view.Columns[4].Width = 90;
                                    con.close_connection();
                                    driver_detail_insert_img1.Visibility = System.Windows.Visibility.Hidden;
                                    driver_detail_insert_img2.Visibility = System.Windows.Visibility.Visible;
                                    time1.Start();
                                    chr = "i";
                                    text_clear();
                                    d_v_number.Items.Clear();
                                    driver_trailer_check.IsChecked = false;
                                    driver_lpg_check.IsChecked = false;
                                    driver_load_check.IsChecked = false;

                                }

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
                        MessageBox.Show("fill all text field");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Licence Type");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

           
        }


        void number_clear(object sender, RoutedEventArgs e)
        {
            d_v_number.Items.Clear();
            lpg_licence.IsChecked = false;
            trailer_licence.IsChecked = false;
            line_licence.IsChecked = false;
            //numbers_clear.IsEnabled = false;
        }
      

        private void driver_detail_view_SelectionChanged(object sender, RoutedEventArgs e)
        {

            DataRowView dr = (DataRowView)driver_detail_view.SelectedItem;
            string s = (dr["licence_number"]).ToString();
            if (s != "")
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select vehicle_number,driver_name,licence_number,DATE_FORMAT(expiry,'%d/%m/%Y')AS expiry,address,contact,referer_name,bank_name,account_no,branch,ifsc_code,DATE_FORMAT(join_date,'%d/%m/%Y')AS join_date from driver_details where licence_number='" + s + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    d_v_number.Text = dt.Rows[0]["vehicle_number"].ToString();
                    driver_name.Text = dt.Rows[0]["driver_name"].ToString();
                    licence_no.Text = dt.Rows[0]["licence_number"].ToString();
                    expiry.Text = dt.Rows[0]["expiry"].ToString();
                    address.Text = dt.Rows[0]["address"].ToString();
                    contact.Text = dt.Rows[0]["contact"].ToString();
                    driver_referer_name.Text = dt.Rows[0]["referer_name"].ToString();
                    bank_name.Text = dt.Rows[0]["bank_name"].ToString();
                    account_no.Text = dt.Rows[0]["account_no"].ToString();
                    branch.Text = dt.Rows[0]["branch"].ToString();
                    ifsc_code.Text = dt.Rows[0]["ifsc_code"].ToString();
                    join_date.Text = dt.Rows[0]["join_date"].ToString();
                    con.close_connection();
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error :"+ex);
                }
               
            }
            else
            {
                MessageBox.Show("Data Grid is Empty");
            }

        }

        private void licence_no_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(licence_no.Text))
            {
                int len = licence_no.Text.Length;
                for(int i=0;i< len;i++)
                {
                    bool isdigit = char.IsDigit(licence_no.Text[i]);
                    bool isletter = char.IsLetter(licence_no.Text[i]);
                    if(isdigit)
                    {

                    }
                    else if(isletter)
                    {

                    }
                    else
                    {
                        e.Handled = true;
                        licence_no.Text = "";
                    }
                }
            }
        }

        private void address_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
             if (e.Text == ".")
            {

                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
             else if(e.Text=="/")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
            else if (IsNumber(e.Text) == true)
            {
                
            }
            else if(IsNumber(e.Text)==false)
            {

            }
            
        }
        bool IsNumber(string txt)
        {
            int output;
            return int.TryParse(txt, out output);
        }

        private void lpg_licence_Unchecked(object sender, RoutedEventArgs e)
        {
            s1 = "";
        }

        private void trailer_licence_Unchecked(object sender, RoutedEventArgs e)
        {
            s2 = "";
        }

        private void line_licence_Unchecked(object sender, RoutedEventArgs e)
        {
            s3 = "";
        }

        private void contact_TextChanged(object sender, TextChangedEventArgs e)
        {            
            for (int j=0;j< contact.Text.Length;j++ )
            {
                bool isletter = char.IsLetter(contact.Text[j]);
                if (isletter)
                {
                    contact.Text = "";
                    MessageBox.Show("Allow Only Numbers ");
                }
            }
        }

        void text_clear()
        {
            d_v_number.Text = ""; driver_name.Text = ""; licence_no.Text = ""; expiry.Text =DateTime.Now.ToShortDateString(); address.Text = ""; contact.Text = ""; driver_referer_name.Text = ""; bank_name.Text = ""; account_no.Text = ""; branch.Text = ""; ifsc_code.Text = "";
            lpg_licence.IsChecked = false; trailer_licence.IsChecked = false; line_licence.IsChecked = false; s = "";s1 = "";s2 = "";s3 = ""; native_selection.IsChecked = false; reference_selection.IsChecked = false; join_date.Text = DateTime.Now.ToShortDateString();
        }

       
        void Driver_Name_Textchanged(object sender, TextCompositionEventArgs e)
        {
            string s = driver_name.Text;
            int len = s.Length;
            if (len >0)
            {
                for(int i=0;i<len;i++)
                {
                    bool isletter = char.IsLetter(s[i]);
                    if (isletter)
                    {
                        
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                        e.Handled = true;
                        MessageBox.Show("Enter Only Characters");
                        driver_name.Text = "";
                    }
                }
            }


        }
       
    }
}
