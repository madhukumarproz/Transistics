using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Diesel_Card_Edit.xaml
    /// </summary>
    public partial class Diesel_Card_Edit : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        public Diesel_Card_Edit()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            diesel_card_img2.Visibility = System.Windows.Visibility.Hidden;
            diesel_details.IsEnabled = false;
        }


        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {               
                    diesel_card_img1.Visibility = System.Windows.Visibility.Visible;
                    diesel_card_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();                                   
            }
            ii++;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            
        }
        void diesel_update_customerid_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(diesel_update_customerid.Text))
                {
                    if(diesel_update_customerid.Text.Length<=17)
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("select corporation,customer_id,vehicle_number from diesel_card_details where card_id='" + diesel_update_customerid.Text + "'", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                update_corp.Text = dt.Rows[0]["corporation"].ToString();
                                cards_id.Text = dt.Rows[0]["customer_id"].ToString();
                                card_vehicle_number.Text = dt.Rows[0]["vehicle_number"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Record Doesn't Exist for This Customer Id");
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
                        e.Handled = true;
                        MessageBox.Show("Allow Combination 17 Characters and Numbers");
                        diesel_update_customerid.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Card Id");
                }
               
               
            }
        }

        private void diesel_card_details_insert_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER")
            {
                MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Update", "Update", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (mr == MessageBoxResult.OK && !string.IsNullOrWhiteSpace(diesel_update_customerid.Text) && !string.IsNullOrWhiteSpace(cards_id.Text) && !string.IsNullOrWhiteSpace(update_corp.Text))
                {

                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd1 = new OdbcCommand("update diesel_card_details set corporation='" + update_corp.Text + "',customer_id='" + cards_id.Text + "' where  card_id='" + diesel_update_customerid.Text + "'", con.conn);
                        cmd1.ExecuteNonQuery();
                        OdbcCommand cmd3 = new OdbcCommand("update credit_details set corporation='" + update_corp.Text + "',customer_id='" + cards_id.Text + "' where  card_id='" + diesel_update_customerid.Text + "'", con.conn);
                        cmd3.ExecuteNonQuery();
                        diesel_card_img1.Visibility = System.Windows.Visibility.Hidden;
                        diesel_card_img2.Visibility = System.Windows.Visibility.Visible;
                        time1.Start();
                        update_corp.Text = ""; diesel_update_customerid.Text = ""; cards_id.Text = ""; card_vehicle_number.Text = "";
                        OdbcCommand cmd2 = new OdbcCommand("select CORPORATION,CUSTOMER_ID,CARD_ID,VEHICLE_NUMBER from diesel_card_details where bool=0", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        diesel_details.ItemsSource = dt.DefaultView;
                        diesel_details.Columns[1].Width = 150;
                        diesel_details.Columns[2].Width = 150;
                        con.close_connection();
                        // diesel_update_customerid.IsEditable = true;
                        diesel_details.IsEnabled = true;
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                else if(mr==MessageBoxResult.Cancel)
                {

                }
                else
                {
                    MessageBox.Show("Please Fill Empty Text Field");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }

       void diesel_card_details_remove_click(object sender,RoutedEventArgs e)
        { string user = Properties.Settings.Default.User;
           if(user=="ADMIN")
            {
                if (!string.IsNullOrWhiteSpace(diesel_update_customerid.Text) && !string.IsNullOrWhiteSpace(card_vehicle_number.Text))
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Delete", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.OK)
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd1 = new OdbcCommand("update diesel_card_details set BOOL=1 where  card_id='" + diesel_update_customerid.Text + "'", con.conn);
                            cmd1.ExecuteNonQuery();
                            OdbcCommand cmd3 = new OdbcCommand("UPDATE vechicle_details SET card_id='NOTASSIGNED' where vehicle_number='" + card_vehicle_number.Text + "'", con.conn);
                            cmd3.ExecuteNonQuery();
                            OdbcCommand cmd2 = new OdbcCommand("select CORPORATION,CUSTOMER_ID,CARD_ID,VEHICLE_NUMBER from diesel_card_details where bool=0", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd2);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            diesel_details.ItemsSource = dt.DefaultView;
                            diesel_details.Columns[1].Width = 150;
                            diesel_details.Columns[2].Width = 150;
                            con.close_connection();
                            diesel_update_customerid.Text = ""; card_vehicle_number.Text = ""; cards_id.Text = ""; update_corp.Text = "";
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                  else if(mr == MessageBoxResult.Cancel)
                    {

                    }

                }
                else
                {
                    MessageBox.Show("Please Select Card Id and Vehicle Number");
                }
            }
           else
            {
                MessageBox.Show("Access Denied");
            }
           
            
        }
        private void diesel_details_SelectionChanged(object sender, RoutedEventArgs e)
        {

            //DataRowView dr = (DataRowView)diesel_details.SelectedItem;
            //string s = (dr["entry_date"]).ToString();
            //Connection con = new Connection();
            //con.open_connection();
            //OdbcCommand cmd1 = new OdbcCommand("select * from diesel_balance_sheet where entry_date='" + s + "'", con.conn);
            //OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //string corporation = dt.Rows[0]["corporation"].ToString();
            //if (corporation.Equals("IOC"))
            //{
            //    // rb2.IsChecked = true;
            //}
            //else if (corporation.Equals("BPC"))
            //{
            //    // rb1.IsChecked = true;
            //}


            //con.close_connection();

        }

        private void diesel_update_customerid_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand CMD = new OdbcCommand("select card_id from diesel_card_details where bool=0", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(CMD);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    diesel_update_customerid.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        diesel_update_customerid.Items.Add(dt.Rows[i]["card_id"]);
                    }
                    //diesel_update_customerid.IsEditable = false;
                }
                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        private void diesel_update_customerid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int len = diesel_update_customerid.Text.Length;
            if(len==18)
            {
                e.Handled = true;
                MessageBox.Show("Allow Combination 17 Characters and Numbers");
                diesel_update_customerid.Text = "";
            }
        }
    }
}
