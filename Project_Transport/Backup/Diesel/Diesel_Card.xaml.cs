using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Diesel_Card.xaml
    /// </summary>
    public partial class Diesel_Card : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        
        public Diesel_Card()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            diesel_card_img2.Visibility = Visibility.Hidden;
            
        }

      public  int bval = 0;
      public  string edit_char = null;
       // DataTable dt = new DataTable();

        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {                
                    diesel_card_img1.Visibility = Visibility.Visible;
                    diesel_card_img2.Visibility = Visibility.Hidden;
                    time1.Stop();                                     
            }
            ii++;
        }
       


        private void cards_id_keydown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    if (!string.IsNullOrWhiteSpace(cards_id.Text))
                    {
                        OdbcCommand cmd = new OdbcCommand("select card_id from diesel_card_details where card_id LIKE '" + cards_id.Text + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Card Id Already Exist");
                            cards_id.Text = "";
                            e.Handled = true;
                            con.close_connection();
                        }
                        else
                        {
                            if (diesel_corporation_name.Text.Equals("IOC"))
                            {

                                OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from vechicle_details where (card_id  IS NULL OR card_id='NOTASSIGNED') and corporation='" + diesel_corporation_name.Text + "'", con.conn);
                                OdbcDataReader DR = cmd1.ExecuteReader();
                                card_vehicle_number.Items.Clear();
                                while (DR.Read())
                                {
                                    card_vehicle_number.Items.Add(DR[0]);
                                }
                                con.close_connection();
                            }
                            else if (diesel_corporation_name.Text.Equals("BPC"))
                            {

                                OdbcCommand cmd2 = new OdbcCommand("select vehicle_number from vechicle_details where (card_id  IS NULL OR card_id='NOTASSIGNED') and corporation='" + diesel_corporation_name.Text + "'", con.conn);
                                OdbcDataReader DR = cmd2.ExecuteReader();
                                card_vehicle_number.Items.Clear();
                                while (DR.Read())
                                {
                                    card_vehicle_number.Items.Add(DR[0]);
                                }
                                con.close_connection();
                            }
                            else if (diesel_corporation_name.Text.Equals("HPC"))
                            {

                                OdbcCommand cmd3 = new OdbcCommand("select vehicle_number from vechicle_details where (card_id  IS NULL OR card_id='NOTASSIGNED') and corporation='" + diesel_corporation_name.Text + "'", con.conn);
                                OdbcDataReader DR = cmd3.ExecuteReader();
                                card_vehicle_number.Items.Clear();
                                while (DR.Read())
                                {
                                    card_vehicle_number.Items.Add(DR[0]);
                                }
                                con.close_connection();
                            }
                            else if (diesel_corporation_name.Text.Equals("LOD"))
                            {

                                OdbcCommand cmd3 = new OdbcCommand("select vehicle_number from vechicle_details where (card_id  IS NULL OR card_id='NOTASSIGNED') and corporation='" + diesel_corporation_name.Text + "'", con.conn);
                                OdbcDataReader DR = cmd3.ExecuteReader();
                                card_vehicle_number.Items.Clear();
                                while (DR.Read())
                                {
                                    card_vehicle_number.Items.Add(DR[0]);
                                }
                                con.close_connection();
                            }
                            else if (diesel_corporation_name.Text.Equals("TLR"))
                            {

                                OdbcCommand cmd3 = new OdbcCommand("select vehicle_number from vechicle_details where (card_id  IS NULL OR card_id='NOTASSIGNED') and corporation='" + diesel_corporation_name.Text + "'", con.conn);
                                OdbcDataReader DR = cmd3.ExecuteReader();
                                card_vehicle_number.Items.Clear();
                                while (DR.Read())
                                {
                                    card_vehicle_number.Items.Add(DR[0]);
                                }
                                con.close_connection();
                            }
                            else
                            {
                                MessageBox.Show("Please Select Corporation");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Card Id");
                    }
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show("Error"+ex);
                }
               
            }          
        }

        


        
        void diesel_card_details_insert_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(diesel_corporation_name.Text) & !string.IsNullOrWhiteSpace(diesel_customerid.Text) & !string.IsNullOrWhiteSpace(cards_id.Text) & !string.IsNullOrWhiteSpace(card_vehicle_number.Text))
            { String user = Properties.Settings.Default.User;
                if(user=="ADMIN"||user=="MANAGER"||user=="USER")
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Add Card Details", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.OK)
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd1 = new OdbcCommand("insert into diesel_card_details(corporation,customer_id,card_id,vehicle_number)values('" + diesel_corporation_name.Text + "','" + diesel_customerid.Text + "','" + cards_id.Text + "','" + card_vehicle_number.Text + "')", con.conn);
                            cmd1.ExecuteNonQuery();
                            OdbcCommand cmd = new OdbcCommand("insert into credit_details(corporation,customer_id,card_id,credit_amount,credit_date)values('" + diesel_corporation_name.Text + "','" + diesel_customerid.Text + "','" + cards_id.Text + "',0,'" + Convert.ToDateTime(DateTime.Now).ToString("yyyy/MM/dd") + "')", con.conn);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd3 = new OdbcCommand("update vechicle_details set card_id='" + cards_id.Text + "' where vehicle_number='" + card_vehicle_number.Text + "'", con.conn);
                            cmd3.ExecuteNonQuery();
                            OdbcCommand CMD4 = new OdbcCommand("insert into diesel_balance_sheet(corporation,card_id,vehicle_number,total_cost)values('" + diesel_corporation_name.Text + "','" + cards_id.Text + "','" + card_vehicle_number.Text + "',0)", con.conn);
                            CMD4.ExecuteNonQuery();
                            diesel_card_img1.Visibility = Visibility.Hidden;
                            diesel_card_img2.Visibility = Visibility.Visible;
                            time1.Start();
                            diesel_corporation_name.Text = ""; diesel_customerid.Text = ""; cards_id.Text = ""; card_vehicle_number.Text = "";
                            OdbcCommand cmd2 = new OdbcCommand("select CORPORATION,CUSTOMER_ID,CARD_ID,VEHICLE_NUMBER from diesel_card_details WHERE BOOL=0", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd2);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            diesel_details.ItemsSource = dt.DefaultView;
                            diesel_details.Columns[1].Width = 150;
                            diesel_details.Columns[2].Width = 150;
                            con.close_connection();
                            card_vehicle_number.Items.Clear();
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
            else
            {
                MessageBox.Show("Fill all text field");
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

       


    }
}
