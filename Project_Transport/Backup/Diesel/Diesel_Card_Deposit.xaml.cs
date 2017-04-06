using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Diesel_Card_Deposit.xaml
    /// </summary>
    public partial class Diesel_Card_Deposit : UserControl
    {
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        string chr = null;
        public Diesel_Card_Deposit()
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
            deposit_insert_img2.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Hidden;
            delete.Visibility = Visibility.Hidden;
            diesel_details.IsEnabled = false;
        }


        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {
                if (chr == "d")
                {
                    deposit_insert_img1.Visibility = System.Windows.Visibility.Visible;
                    deposit_insert_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }

            }
            ii++;
        }
       
        private void customer_id_SelectionChanged(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(cardes_id.Text))
                {
                    if(cardes_id.Text.Length<=17)
                    {
                        try
                        {
                            //string S = cardes_id.Text;
                            Connection CON = new Connection();
                            CON.open_connection();
                            OdbcCommand CMD = new OdbcCommand("select corporation,customer_id from diesel_card_details where card_id='" + cardes_id.Text + "' and bool=0", CON.conn);
                            OdbcDataAdapter dr = new OdbcDataAdapter(CMD);
                            DataTable DT = new DataTable();
                            dr.Fill(DT);

                            corporation.Text = DT.Rows[0]["corporation"].ToString();
                            customer_id.Text = DT.Rows[0]["customer_id"].ToString();
                            OdbcCommand cmd3 = new OdbcCommand("select  S_NO,CUSTOMER_ID,CARD_ID,CREDIT_AMOUNT,DATE_FORMAT(CREDIT_DATE,'%d/%m/%Y') as CREDIT_DATE from credit_details where card_id='" + cardes_id.Text + "' and bool=0", CON.conn);
                            OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            diesel_details.ItemsSource = dt1.DefaultView;
                            diesel_details.Columns[0].Width = 30;
                            diesel_details.Columns[1].Width = 120;
                            diesel_details.Columns[2].Width = 120;
                            diesel_details.Columns[3].Width = 120;
                            diesel_details.Columns[4].Width = 120;
                            CON.close_connection();
                            diesel_details.IsEnabled = true;
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
                        cardes_id.Text = "";
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please Select Card Id");
                }                            
            }         
        }


        void diesel_card_deposit_insert_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(corporation.Text) & !string.IsNullOrWhiteSpace(customer_id.Text) & !string.IsNullOrWhiteSpace(credit.Text)&& !string.IsNullOrWhiteSpace(date.Text))
            {
                string user = Properties.Settings.Default.User; 
                if(user=="ADMIN"||user=="MANAGER"||user=="USER")
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Insert Data", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.OK)
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();

                            OdbcCommand cmd2 = new OdbcCommand("insert into credit_details(corporation,customer_id,card_id,credit_amount,credit_date)values('" + corporation.Text + "','" + customer_id.Text + "','" + cardes_id.Text + "','" + Convert.ToInt32(credit.Text) + "','" + Convert.ToDateTime(date.Text).ToString("yyyy/MM/dd") + "')", con.conn);
                            cmd2.ExecuteNonQuery();
                            deposit_insert_img1.Visibility = System.Windows.Visibility.Hidden;
                            deposit_insert_img2.Visibility = System.Windows.Visibility.Visible;
                            time1.Start();
                            chr = "d";
                            OdbcCommand cmd3 = new OdbcCommand("select  S_NO,CUSTOMER_ID,CARD_ID,CREDIT_AMOUNT,DATE_FORMAT(CREDIT_DATE,'%d/%m/%Y') as CREDIT_DATE from credit_details where card_id='" + cardes_id.Text + "' and bool=0", con.conn);
                            OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            diesel_details.ItemsSource = dt1.DefaultView;
                            diesel_details.Columns[0].Width = 30;
                            diesel_details.Columns[1].Width = 120;
                            diesel_details.Columns[2].Width = 120;
                            diesel_details.Columns[3].Width = 120;
                            diesel_details.Columns[4].Width = 120;
                            con.close_connection();
                            corporation.Text = ""; customer_id.Text = ""; credit.Text = ""; cardes_id.Text = ""; date.Text = DateTime.Now.ToShortDateString();
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
                MessageBox.Show("Fill all Text Field");
            }
        }

       

        void Credit_Amount_PreViewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender,e);
        }


        int s_no = 0;
        private void diesel_details_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dr = (DataRowView)diesel_details.SelectedItem;
                 s_no = Convert.ToInt32(dr["s_no"]);
                string S = (dr["card_id"]).ToString();
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd1 = new OdbcCommand("select  CORPORATION,CUSTOMER_ID,CARD_ID,CREDIT_AMOUNT,credit_date from credit_details where card_id='" + S + "' and S_NO='" + s_no + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    corporation.Text = dt.Rows[0]["corporation"].ToString();
                    cardes_id.Text = dt.Rows[0]["card_id"].ToString();
                    customer_id.Text = dt.Rows[0]["customer_id"].ToString();                   
                    credit.Text = (dt.Rows[0]["credit_amount"]).ToString();
                    date.Text = dt.Rows[0]["credit_date"].ToString(); 
                    update.Visibility = Visibility.Visible;
                    delete.Visibility = Visibility.Visible;
                    Deposit_Back.Visibility = Visibility.Visible;
                    insert.Visibility =Visibility.Hidden;
                }
            }
            catch(OdbcException ex)
            {
                MessageBox.Show("Error :"+ex);
            }
           
        }
        void diesel_card_deposit_update_click(object sender,RoutedEventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(cardes_id.Text) && !string.IsNullOrWhiteSpace(date.Text) && !string.IsNullOrWhiteSpace(credit.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN" || user == "MANAGER")
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Update", "Update", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if(mr==MessageBoxResult.OK)
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("update credit_details set credit_amount='" + Convert.ToInt32(credit.Text) + "',credit_date='" + Convert.ToDateTime(date.Text).ToString("yyyy/MM/dd") + "' where card_id='" + cardes_id.Text + "' and S_NO='" + s_no + "'", con.conn);
                            cmd.ExecuteNonQuery();
                            update.Visibility = Visibility.Hidden;
                            delete.Visibility = Visibility.Hidden;
                            insert.Visibility = Visibility.Visible;
                            OdbcCommand cmd3 = new OdbcCommand("select  S_NO,CUSTOMER_ID,CARD_ID,CREDIT_AMOUNT,DATE_FORMAT(CREDIT_DATE,'%d/%m/%Y') as CREDIT_DATE from credit_details where card_id='" + cardes_id.Text + "' and bool=0", con.conn);
                            OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            diesel_details.ItemsSource = dt1.DefaultView;
                            diesel_details.Columns[0].Width = 30;
                            diesel_details.Columns[1].Width = 120;
                            diesel_details.Columns[2].Width = 120;
                            diesel_details.Columns[3].Width = 120;
                            diesel_details.Columns[4].Width = 120;
                            con.close_connection();
                            corporation.Text = ""; customer_id.Text = ""; credit.Text = ""; cardes_id.Text = ""; date.Text = DateTime.Now.ToShortDateString();
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
                MessageBox.Show("Please Fill Empty Text Field");
            }

            
        }
        void diesel_card_deposit_delete_click(object sender,RoutedEventArgs e)
        {
           
            if(!string.IsNullOrWhiteSpace(cardes_id.Text)&&!string.IsNullOrWhiteSpace(date.Text))
            {
                string user = Properties.Settings.Default.User;
                if (user == "ADMIN")
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Delete", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.OK)
                    {
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("update credit_details set bool=1 where card_id='" + cardes_id.Text + "' and s_no='" + s_no + "'", con.conn);
                            cmd.ExecuteNonQuery();
                            update.Visibility = Visibility.Hidden;
                            delete.Visibility = Visibility.Hidden;
                            insert.Visibility = Visibility.Visible;
                            OdbcCommand cmd3 = new OdbcCommand("select  S_NO,CUSTOMER_ID,CARD_ID,CREDIT_AMOUNT,DATE_FORMAT(CREDIT_DATE,'%d/%m/%Y') as CREDIT_DATE from credit_details where card_id='" + cardes_id.Text + "' and bool=0", con.conn);
                            OdbcDataAdapter da1 = new OdbcDataAdapter(cmd3);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            diesel_details.ItemsSource = dt1.DefaultView;
                            diesel_details.Columns[0].Width = 30;
                            diesel_details.Columns[1].Width = 120;
                            diesel_details.Columns[2].Width = 120;
                            diesel_details.Columns[3].Width = 120;
                            diesel_details.Columns[4].Width = 120;
                            con.close_connection();
                            corporation.Text = ""; customer_id.Text = ""; credit.Text = ""; cardes_id.Text = ""; date.Text = DateTime.Now.ToShortDateString();
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
                MessageBox.Show("Select Card Id Date");
            }
           
            
        }

        private void cardes_id_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection CON = new Connection();
                CON.open_connection();
                OdbcCommand CMD = new OdbcCommand("select card_id from diesel_card_details where bool=0 ", CON.conn);
                OdbcDataAdapter dr = new OdbcDataAdapter(CMD);
                DataTable DT = new DataTable();
                dr.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    cardes_id.Items.Clear();
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        cardes_id.Items.Add(DT.Rows[i]["card_id"]);
                    }
                }
                CON.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        private void cardes_id_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int len = cardes_id.Text.Length;
            if (len == 18)
            {
                e.Handled = true;
                MessageBox.Show("Allow Combination 17 Characters and Numbers");
                cardes_id.Text = "";
            }
        }

        private void Deposit_Back_Click(object sender, RoutedEventArgs e)
        {
            update.Visibility = Visibility.Hidden;
            delete.Visibility = Visibility.Hidden;
            insert.Visibility = Visibility.Visible;
            Deposit_Back.Visibility = Visibility.Hidden;
            corporation.Text = ""; customer_id.Text = ""; credit.Text = ""; cardes_id.Text = ""; date.Text = DateTime.Now.ToShortDateString();
        }
    }
}
