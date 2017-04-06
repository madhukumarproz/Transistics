using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Settings_Panel.xaml
    /// </summary>
    public partial class transport_list_Panel : UserControl
    {
       
        public transport_list_Panel()
        {
            InitializeComponent();
            vv_code.Visibility = System.Windows.Visibility.Hidden;
            transport_name_insert.IsChecked = true;
        }


        void transport_name_insert_checked(object sender, RoutedEventArgs e)
        {
            vv_code.Visibility = System.Windows.Visibility.Hidden;
        }


        void transport_name_edit_checked(object sender, RoutedEventArgs e)
        {
            try
            {
                vv_code.Visibility = System.Windows.Visibility.Visible;
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vendor_code from transports_name", con.conn);
                OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                DataTable dty = new DataTable();
                DA.Fill(dty);
                if (dty.Rows.Count > 0)
                {
                    vv_code.Items.Clear();
                    for (int i = 0; i < dty.Rows.Count; i++)
                    {
                        vv_code.Items.Add(dty.Rows[i]["vendor_code"]);
                    }

                }
                con.close_connection();
            }
            catch
            {
                MessageBox.Show("Error Loading Veodor Code");
            }
            
        }



        void vv_code_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter&!string.IsNullOrWhiteSpace(vv_code.Text))
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select transport_name,owner_name from transports_name where vendor_code='" + vv_code.Text + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        trans_name.Text = dt.Rows[0]["transport_name"].ToString();
                        o_name.Text = dt.Rows[0]["owner_name"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid vendor code");
                    }
                    con.close_connection();
                }
                catch
                {
                    MessageBox.Show("Data Getting Error");
                }

            }
            else
            {
                MessageBox.Show("Please Select Vendor Code");
            }


        }

        void owner_name_PreviewKeydown(object sender,KeyEventArgs e)
        {
            int len = 0;
            len = o_name.Text.Length;
            if(e.Key==Key.Back)
            {
                e.Handled = false;
            }
            else if(len>20)
            {
                e.Handled = true;
                MessageBox.Show("Allow 20 Characters Only");
            }
        }

        void transport_name_entry_click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                Connection con = new Connection();
                con.open_connection();
                MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Add Transport Details", "Insert Data", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (mr == MessageBoxResult.OK)
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(trans_name.Text) & !string.IsNullOrWhiteSpace(v_code.Text) & !string.IsNullOrWhiteSpace(o_name.Text) & transport_name_insert.IsChecked == true)
                        {
                            OdbcCommand cmd = new OdbcCommand("insert into transports_name(transport_name,vendor_code,owner_name)values('" + trans_name.Text + "','" + v_code.Text + "','" + o_name.Text + "')", con.conn);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select transport_name,vendor_code,owner_name from transports_name",con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            translistgrid.ItemsSource = dt.DefaultView;
                            trans_name.Text = ""; v_code.Text = ""; o_name.Text = "";
                        }
                        else if (!string.IsNullOrWhiteSpace(trans_name.Text) & !string.IsNullOrWhiteSpace(vv_code.Text) & !string.IsNullOrWhiteSpace(o_name.Text) & transport_name_edit.IsChecked == true)
                        {
                            OdbcCommand cmd = new OdbcCommand("update transports_name set transport_name='" + trans_name.Text + "',owner_name='" + o_name.Text + "' where vendor_code='" + vv_code.Text + "'", con.conn);
                            cmd.ExecuteNonQuery();
                            OdbcCommand cmd1 = new OdbcCommand("select transport_name,vendor_code,owner_name from transports_name", con.conn);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            translistgrid.ItemsSource = dt.DefaultView;
                            trans_name.Text = ""; vv_code.Text = ""; o_name.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Should fill all text field");
                        }
                    }
                    catch(OdbcException ex)
                    {
                        MessageBox.Show("Error :"+ex);
                    }
                }
                else if (mr == MessageBoxResult.Cancel)
                {

                }
                con.close_connection();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
           
        }

        void transport_list_back_click(object sender,RoutedEventArgs e)
        {
            trans_name.Text = ""; vv_code.Text = ""; o_name.Text = "";
            ((MainWindow)System.Windows.Application.Current.MainWindow).transport_list.Visibility = Visibility.Hidden;
        }

        private void trans_name_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int len = 0;
            len = trans_name.Text.Length;
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }            
            else if (len > 20)
            {
                e.Handled = true;
                MessageBox.Show("Allow 20 Characters Only");
            }
        }
        void vendor_code_PreviewKeyDown(object sender,KeyEventArgs e)
        {
            int len = 0;
            len = v_code.Text.Length;
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }
            else if (len > 20)
            {
                e.Handled = true;
                MessageBox.Show("Allow 20 Characters Only");
            }
        }
        

       
        void vendor_code_Textchanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(v_code.Text))
            {
                int len = v_code.Text.Length;
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        bool digit = char.IsLetter(v_code.Text[i]);
                        bool letter = char.IsDigit(v_code.Text[i]);
                        if (digit)
                        {

                        }
                        else if (letter)
                        {
                        }
                        else
                        {
                            MessageBox.Show("Allow Characters and Numbers only");
                            v_code.Text = "";
                            //e.Handled = true;
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show("Fill Vendor Code");
            }
           
        }

        private void trans_name_TextChanged(object sender, TextCompositionEventArgs e)
        {
            if(e.Text==".")
            {

            }
            else if(e.Text==" ")
            {

            }
            else if(ISNUMBER(e.Text)==true)
            {

            }
            else if(e.Text!=null)
            {
                String S = e.Text;
                bool ISLETTER = char.IsLetter(S[0]);
                if(!ISLETTER)
                {
                    MessageBox.Show("Allow Character, Number, Space and Dot");
                    e.Handled = true;
                }
            }
           
        }
        private bool ISNUMBER(String S)
        {
            int OUT;
            return int.TryParse(S, out OUT);
        }

        private void owner_name_Textchanged(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {

            }
            else if (e.Text == " ")
            {

            }           
            else if (e.Text != null)
            {
                String S = e.Text;
                bool ISLETTER = char.IsLetter(S[0]);
                if (!ISLETTER)
                {
                    MessageBox.Show("Allow Character, Space and Dot");
                    e.Handled = true;
                }
            }
        }

        private void translistgrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd1 = new OdbcCommand("select transport_name,vendor_code,owner_name from transports_name", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                translistgrid.ItemsSource = dt.DefaultView;
                con.close_connection();
            }
            catch(OdbcException ex)
            {
                MessageBox.Show(""+ex);
            }           
        }
    }
}
