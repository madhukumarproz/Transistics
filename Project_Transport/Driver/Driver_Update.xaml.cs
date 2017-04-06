using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Driver_Update.xaml
    /// </summary>
    public partial class Driver_Update : UserControl
    {
        string s=null,S1=null,S2=null,S3=null;
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
       
        public Driver_Update()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            driver_detail_update_img2.Visibility = System.Windows.Visibility.Hidden;
            driver_detail_update_img2.Visibility = System.Windows.Visibility.Hidden;
        }
        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {               
                    driver_detail_update_img1.Visibility = System.Windows.Visibility.Visible;
                    driver_detail_update_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
            }
            ii++;
        }
      
        void Vehicle_number_Previewkeydown(object sender,KeyEventArgs e)
        {
            int len = 0;
            string s = d_v_number.Text;
            if (!string.IsNullOrWhiteSpace(d_v_number.Text))
            {

                len = d_v_number.Text.Length;
            }
            else
            {
                len = 0;
            }
            if (len >= 10)
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
            else if (len <= 2)
            {
                for (int i = 0; i < len; i++)
                {
                    bool isletter = char.IsLetter(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter First Two Letter Character");
                        d_v_number.Text = "";
                    }
                }
            }
            else if (len > 2 && len <= 4)
            {
                for (int i = 2; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter Number");
                        d_v_number.Text = "";
                    }
                }
            }
            else if (len == 5)
            {
                bool isletter = char.IsLetter(s[4]);
                bool isdigit = char.IsLetter(s[4]);
                if (isletter == true)
                {
                }
                else if (isdigit == true)
                {

                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Should Enter Character");
                    d_v_number.Text = "";
                }
            }
            else if (len == 6)
            {
                bool isletter = char.IsLetter(s[5]);
                bool isdigit = char.IsLetter(s[5]);
                if (isletter == true)
                {
                }
                else if(isdigit==true)
                {

                }
                else
                {

                }
            }
            else if (len > 6)
            {
                for (int i = 6; i < len; i++)
                {
                    bool isletter = char.IsDigit(s[i]);
                    if (isletter == true)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Should Enter Number");
                        d_v_number.Text = "";
                    }
                }
            }
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }
        }


        private void lpg_licence_Checked(object sender, RoutedEventArgs e)
        {
            S1 = "LPG";

        }

        private void trailer_licence_Checked(object sender, RoutedEventArgs e)
        {
            S2 = "TRAILER";

        }

        private void line_licence_Checked(object sender, RoutedEventArgs e)
        {
            S3 = "LINE";

        }
       
        void Driver_Name_Textchanged(object sender, TextChangedEventArgs e)
        {
            string s = driver_name.Text;
            int len = s.Length;
            if (len > 0)
            {
               
                for (int i = 0; i < len; i++)
                {
                    bool isdigit = char.IsDigit(s[i]);
                    if (isdigit)
                    {                     
                            System.Media.SystemSounds.Beep.Play();
                            e.Handled = true;
                        MessageBox.Show("Allow Character Only");
                            driver_name.Text = "";                      
                    }
                }

            }


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
        void driver_detail_update_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER")
            {
                if (S1 != null)
                {
                    s = S1;
                }
                if (S2 != null)
                {
                    s = s + "," + S2;
                }
                if (S3 != null)
                {
                    s = s + "," + S3;
                }
                if (!string.IsNullOrWhiteSpace(s))
                {

                    if (!string.IsNullOrWhiteSpace(licence_no.Text) & !string.IsNullOrWhiteSpace(d_v_number.Text))
                    {
                        MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Replace Existing Data", "Update Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (mr == MessageBoxResult.OK)
                        {
                            try
                            {
                                Connection con = new Connection();
                                con.open_connection();
                                OdbcCommand cmd = new OdbcCommand("update driver_details set licence_number='" + licence_no.Text + "',driver_name='" + driver_name.Text + "',expiry='" + Convert.ToDateTime(expiry.Text).ToString("yyyy/MM/dd") + "',address='" + address.Text + "',contact='" + contact.Text + "',referer_name='" + driver_referer_name.Text + "',licence_type='" + s + "',bank_name='" + bank_name.Text + "',account_no='" + account_no.Text + "',branch='" + branch.Text + "',ifsc_code='" + ifsc_code.Text + "',join_date='" + Convert.ToDateTime(join_date.Text).ToString("yyyy/MM/dd") + "',update_date=now() where vehicle_number='" + d_v_number.Text + "'", con.conn);
                                cmd.ExecuteNonQuery();
                                //OdbcCommand cmd2 = new OdbcCommand("update vechicle_details set driver_name='" + driver_name.Text + "',status='CLOSED' WHERE vehicle_number='" + d_v_number.Text + "'", con.conn);
                                //cmd2.ExecuteNonQuery();
                                OdbcCommand cmd1 = new OdbcCommand("select VEHICLE_NUMBER,DRIVER_NAME,LICENCE_NUMBER,DATE_FORMAT(expiry,'%d/%m/%Y')AS EXPIRY FROM driver_details WHERE bool=0", con.conn);
                                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                driver_detail_view.ItemsSource = dt.DefaultView;
                                driver_detail_view.Columns[0].Width = 110;
                                driver_detail_view.Columns[1].Width = 130;
                                driver_detail_view.Columns[2].Width = 130;
                                driver_detail_view.Columns[3].Width = 120;
                                con.close_connection();
                                driver_detail_update_img1.Visibility = System.Windows.Visibility.Hidden;
                                driver_detail_update_img2.Visibility = System.Windows.Visibility.Visible;
                                time1.Start();
                                text_clear();

                            }
                            catch (OdbcException ex)
                            {
                                MessageBox.Show("Error :" + ex);
                            }
                        }
                        else if(mr==MessageBoxResult.Cancel)
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("select row from table view");

                    }

                }

                else
                {
                    MessageBox.Show("Should Select Licence Type and Fill Empty Text Field ");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

            //numbers_clear.IsEnabled = false;
           

        }
        void text_clear()
        {
            d_v_number.Text = ""; join_date.Text = ""; driver_name.Text = ""; licence_no.Text = ""; expiry.Text = ""; address.Text = ""; contact.Text = ""; driver_referer_name.Text = ""; bank_name.Text = ""; account_no.Text = ""; branch.Text = ""; ifsc_code.Text = "";
            lpg_licence.IsChecked = false; trailer_licence.IsChecked = false; line_licence.IsChecked = false; s = ""; native_selection.IsChecked = false; reference_selection.IsChecked = false;s = null;S1 = null;S2 = null;S3 = null;
        }
        private void driver_detail_view_SelectionChanged(object sender, RoutedEventArgs e)
        {

            DataRowView dr = (DataRowView)driver_detail_view.SelectedItem;           
            if ((dr["licence_number"]).ToString() != "")
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select vehicle_number,driver_name,licence_number,DATE_FORMAT(expiry,'%d/%m/%Y')AS expiry,address,contact,referer_name,bank_name,account_no,branch,ifsc_code,DATE_FORMAT(join_date,'%d/%m/%Y')AS join_date from driver_details where licence_number='" + (dr["licence_number"]).ToString() + "'", con.conn);
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
                    MessageBox.Show("Error :" + ex);
                }
               
            }
            else
            {
                MessageBox.Show("Data Grid is Empty");
            }

        }

        private void licence_no_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(licence_no.Text))
            {
                int len = licence_no.Text.Length;
                for (int i = 0; i < len; i++)
                {
                    bool isdigit = char.IsDigit(licence_no.Text[i]);
                    bool isletter = char.IsLetter(licence_no.Text[i]);
                    if (isdigit)
                    {

                    }
                    else if (isletter)
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
            else if (e.Text == "/")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
            else if (IsNumber(e.Text) == true)
            {

            }
            else if (IsNumber(e.Text) == false)
            {

            }
        }
        bool IsNumber(string txt)
        {
            int output;
            return int.TryParse(txt, out output);
        }

        private void contact_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int j = 0; j < contact.Text.Length; j++)
            {
                bool isletter = char.IsLetter(contact.Text[j]);
                if (isletter)
                {
                    contact.Text = "";
                    MessageBox.Show("Allow Only Numbers ");
                }
            }
        }

        private void lpg_licence_Unchecked(object sender, RoutedEventArgs e)
        {
            S1 = "";
        }

        private void trailer_licence_Unchecked(object sender, RoutedEventArgs e)
        {
            S2 = "";
        }

        private void line_licence_Unchecked(object sender, RoutedEventArgs e)
        {
            S3 = "";
        }

      

        private void driver_detail_view_Selected(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select VEHICLE_NUMBER,DRIVER_NAME,LICENCE_NUMBER,DATE_FORMAT(expiry,'%d/%m/%Y')AS EXPIRY FROM driver_details WHERE bool=0", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    driver_detail_view.ItemsSource = dt.DefaultView;
                    driver_detail_view.Columns[0].Width = 110;
                    driver_detail_view.Columns[1].Width = 130;
                    driver_detail_view.Columns[2].Width = 130;
                    driver_detail_view.Columns[3].Width = 120;
                    driver_detail_view.IsEnabled = true;
                }
                else
                {
                    //MessageBox.Show("Driver Details Not Exist");
                    // driver_detail_view.IsEnabled = false;
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

       
        void number_clear(object sender, RoutedEventArgs e)
        {                      
            //numbers_clear.IsEnabled = false;
            text_clear();
        }
        void driver_details_closed(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN")
            {
                if(!string.IsNullOrWhiteSpace(d_v_number.Text))
                {
                    MessageBoxResult mr = MessageBox.Show("Are Sure Given Driver Closed", "Closed", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (mr == MessageBoxResult.OK)
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("update vechicle_details set driver_name='',status='OPEN'  where vehicle_number='" + d_v_number.Text + "'", con.conn);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("update driver_details set bool=1 where vehicle_number='" + d_v_number.Text + "'", con.conn);
                            cmd1.ExecuteNonQuery();
                            con.close_connection();
                            text_clear();
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
                    MessageBox.Show("Enter Vehicle Number");
                }
               
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
          

        }
    }
}
