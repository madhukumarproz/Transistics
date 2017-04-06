using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Load_Payment.xaml
    /// </summary>
    public partial class Load_Payment : UserControl
    {
        public Load_Payment()
        {
            InitializeComponent();
        }
        List<string> trip_num = new List<string>();
        private void Driver_Id_GotFocus(object sender, RoutedEventArgs e) 
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select driverid from load_trip_details where tripstatus=0 group by driverid",con.conn);
            OdbcDataReader dr = cmd.ExecuteReader();
            Driver_Id.Items.Clear();
            while (dr.Read())
            {
                Driver_Id.Items.Add(dr[0]);
            }
            con.close_connection();
        }

        private void Get_Details(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select tripnumber,payment,round((((tripfrieght-frieghtreduction)-driverbalance)*payment/100)) amount from load_trip_details where driverid='"+Driver_Id.Text+"' and tripstatus=0 AND paymentid is null", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            { int amnt = 0;          
                Payment_Grid.ItemsSource=dt.DefaultView;
                for(int I=0;I<dt.Rows.Count;I++)
                {
                   amnt  += Convert.ToInt32(dt.Rows[I]["amount"]);
                }
                Pending_Amnt.Text = amnt.ToString();
                Payable.Text = "0";
            }
            con.close_connection();
        }

        private void Payment_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView DR = (DataRowView)Payment_Grid.SelectedItem;
                if (!string.IsNullOrWhiteSpace(DR["amount"].ToString()))
                {
                    if(trip_num.Count==0)
                    {
                        Total_Trip.Text = (Convert.ToInt32(Total_Trip.Text) + 1).ToString();
                        Payable.Text = (Convert.ToInt32(Payable.Text) + Convert.ToInt32(DR["amount"])).ToString();
                        trip_num.Add(DR["tripnumber"].ToString());
                    }
                    else if(!trip_num.Contains(DR["tripnumber"].ToString()))
                    {
                        Total_Trip.Text = (Convert.ToInt32(Total_Trip.Text) + 1).ToString();
                        Payable.Text = (Convert.ToInt32(Payable.Text) + Convert.ToInt32(DR["amount"])).ToString();
                        trip_num.Add(DR["tripnumber"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Trip Number Already Selected");
                    }
                    
                }
                else
                {
                    MessageBox.Show("You Selected Empty Row");
                }
            }
            catch
            {
                MessageBox.Show("You Selected Empty Row");
            }
           
            
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Pending_Amnt.Text = "0"; Remarks.Text = ""; Remarks_Amnt.Text = "0"; Total_Trip.Text = "0"; Payable.Text = "0"; Payment_Id.Text = ""; Driver_Id.Text = "";
        }

        private void Payment_Add_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(Pending_Amnt.Text) &&!string.IsNullOrWhiteSpace(Remarks.Text) && !string.IsNullOrWhiteSpace(Remarks_Amnt.Text) && !string.IsNullOrWhiteSpace(Total_Trip.Text) && !string.IsNullOrWhiteSpace(Payable.Text))
            {
                if(trip_num.Count()>0)
                {
                    MessageBoxResult mr = MessageBox.Show("Are you Sure, Want to Add Payment", "Add Payment", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.Yes)
                    {
                        string d = Convert.ToDateTime(DateTime.Now).ToString("dd");
                        string m = Convert.ToDateTime(DateTime.Now).ToString("MM");
                        string y = Convert.ToDateTime(DateTime.Now).ToString("yy");
                        string h = Convert.ToDateTime(DateTime.Now).ToString("hh");
                        string min = Convert.ToDateTime(DateTime.Now).ToString("mm");
                        string sec = Convert.ToDateTime(DateTime.Now).ToString("ss");
                        Payment_Id.Text = d + m + y + h + min + sec;
                        try
                        {
                            Connection con = new Connection();
                            con.open_connection();
                            OdbcCommand cmd = new OdbcCommand("insert into load_payment(paymentid,totaltrip,remarks,remarksamount,paidamount)values('" + Payment_Id.Text + "','" + Total_Trip.Text + "','" + Remarks.Text + "','" + Remarks_Amnt.Text + "','" + Payable.Text + "')", con.conn);
                            cmd.ExecuteNonQuery();
                            for (int i = 0; i < trip_num.Count(); i++)
                            {
                                OdbcCommand cmd1 = new OdbcCommand("update load_trip_details set paymentid='" + Payment_Id.Text + "' where tripnumber='" + trip_num[i] + "'", con.conn);
                                cmd1.ExecuteNonQuery();
                            }
                            Pending_Amnt.Text = "0"; Remarks.Text = ""; Remarks_Amnt.Text = "0"; Total_Trip.Text = "0"; Payable.Text = "0"; Driver_Id.Text = "";
                            Payment_Grid.ItemsSource = null;
                            con.close_connection();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    else if(mr == MessageBoxResult.No)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Trip Number is Empty");
                }
               
               
            }
            else
            {
                MessageBox.Show("Please Fill All Text Field");
            }
        }

        private void Remarks_Amnt_GotFocus(object sender, RoutedEventArgs e)
        {
            Remarks_Amnt.Text = "";
        }

        private void Remarks_Amnt_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Remarks_Amnt.Text))
            {
                Remarks_Amnt.Text = "0";
            }
            try
            {
                Payable.Text = (Convert.ToInt32(Payable.Text) - Convert.ToInt32(Remarks_Amnt.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("Only Enter Round of Value in Remarks Amount");
            }
           
        }

        private void Remarks_Amnt_TextChanged(object sender, TextChangedEventArgs e)
        {
            int LEN = Remarks_Amnt.Text.Length;
            for(int I=0;I< LEN;I++)
            {
                bool isdigit = char.IsDigit(Remarks_Amnt.Text[I]);
                if(!isdigit)
                {
                    MessageBox.Show("Enter Number Only");
                    Remarks_Amnt.Text = string.Empty;
                }
            }
        }
    }
}
