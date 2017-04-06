using System;
using System.Windows;
using System.Data.Odbc;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Trailer_Tyre_View.xaml
    /// </summary>
    public partial class Trailer_Tyre_View : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        public Trailer_Tyre_View()
        {
            InitializeComponent();
        }
        string p1 = null;string p2 = null;string veh_no = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        public void Get_Details(string s1, string s2,string s3)
        {
            p1 = s1;p2 = s2;veh_no = s3;
            if (!string.IsNullOrWhiteSpace(s3))
            {
                Connection con = new Connection();
                con.connection_string();
                OdbcCommand cmd = new OdbcCommand("select " + s1 + ",DATE_FORMAT(" + s2 + ",'%d-%m-%Y') AS date FROM trailer where vehicle_no='" + s3 + "'", con.str);
                OdbcDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    string DR = dr[0].ToString();
                    if (!string.IsNullOrWhiteSpace(DR))
                    {
                        OdbcCommand cmd1 = new OdbcCommand("select no,starting_km,company from trailer_tyre_details where id='" + DR + "'", con.str);
                        OdbcDataReader dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            rmv_vehicle_tyre_number.Text = dr1[0].ToString();
                            rmv_vehicle_tyre_km.Text = dr1[1].ToString();
                            rmv_vehicle_tyre_company.Text = dr1[2].ToString();
                            rmv_vehicle_tyre_add_date.Text = dr[1].ToString();
                            tyre_details_remove_panel.Visibility = Visibility.Visible;
                            tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
                        }
                    }
                    else
                    {
                        Get_String g = new Get_String();                       
                        g.Tyre_No = "";
                        g.Start_Km = "";
                        g.Tyre_Company = "";
                        g.Tyre_Price = "";
                        this.DataContext = g;
                        tyre_details_entry_panel.Visibility = System.Windows.Visibility.Visible;
                        tyre_details_remove_panel.Visibility = Visibility.Hidden;
                    }


                }

                con.close_string();

            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }
        }
        private void vehicle_tyre_number_Gotfocus(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd = new OdbcCommand("select no from trailer_tyre_details where status='RM'", con.str);
            OdbcDataReader dr = cmd.ExecuteReader();
            ex_vehicle_tyre_number.Items.Clear();
            while (dr.Read())
            {
                ex_vehicle_tyre_number.Items.Add(dr[0]);
            }
            vehicle_tyre_number.Text = string.Empty;
        }
        private void vehicle_tyre_km_GotFocus(object sender, RoutedEventArgs e)
        {
            vehicle_tyre_km.Text = string.Empty;
        }
        void tyre_details_update_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(vehicle_tyre_number.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_km.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_add_date.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_company.Text) && !string.IsNullOrWhiteSpace(tyre_price.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_pur_date.Text))
            {
                try
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Want Insert the Given Data", "Data Insert", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.OK)
                    {
                        Connection CON = new Connection();
                        CON.connection_string();
                       
                            OdbcCommand cmd3 = new OdbcCommand("insert into trailer_tyre_details(vehicle_number,no,company,price,starting_km,purchase_date,status)values('" + veh_no + "','" + vehicle_tyre_number.Text + "','" + vehicle_tyre_company.Text + "','" + Convert.ToDouble(tyre_price.Text) + "','" + vehicle_tyre_km.Text + "','" + Convert.ToDateTime(vehicle_tyre_pur_date.Text).ToString("yyyy-MM-dd") + "','RU')", CON.str);
                            cmd3.ExecuteNonQuery();
                            OdbcCommand cmd4 = new OdbcCommand("select max(id)idno from trailer_tyre_details", CON.str);
                            OdbcDataReader dr = cmd4.ExecuteReader();
                            while (dr.Read())
                            {
                                string ID = dr[0].ToString();
                                if (!string.IsNullOrWhiteSpace(dr[0].ToString()))
                                {
                                    OdbcCommand cmd5 = new OdbcCommand("update trailer set " + p1 + "='" + dr[0].ToString() + "'," + p2 + "='" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy-MM-dd") + "' where vehicle_no='" + veh_no + "'", CON.str);
                                    cmd5.ExecuteNonQuery();
                                    clear();
                                }
                                else
                            {
                                MessageBox.Show("Tyre Id Is Empty");
                            }
                            }
                        

                        CON.close_string();

                    }
                    else if (mr == MessageBoxResult.Cancel)
                    {

                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
            }
            else
            {
                MessageBox.Show("Please Fill Empty Text Field");
            }

        }
        private void Remove_tyre_details_delete_clicked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(rmv_vehicle_tyre_number.Text) && !string.IsNullOrWhiteSpace(rmv_vehicle_tyre_km.Text) && !string.IsNullOrWhiteSpace(rmv_vehicle_tyre_add_date.Text) && !string.IsNullOrWhiteSpace(rmv_vehicle_tyre_company.Text) && !string.IsNullOrWhiteSpace(rmv_vehicle_tyre_endkm.Text))
            {
                MessageBoxResult mr = MessageBox.Show("Are You Sure, Want to Remove this Tyre Permanent", "Remove Tyre", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (mr == MessageBoxResult.OK)
                {
                    try
                    {
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd = new OdbcCommand("update trailer_tyre_details set total_km=total_km+(" + Convert.ToInt32(rmv_vehicle_tyre_endkm.Text) + "-starting_km),status='PR' where no='" + rmv_vehicle_tyre_number.Text + "'", con.str);
                        cmd.ExecuteNonQuery();
                        OdbcCommand cmd2 = new OdbcCommand("update trailer_tyre_details set starting_km='0' where no='" + rmv_vehicle_tyre_number.Text + "'", con.str);
                        cmd2.ExecuteNonQuery();
                        OdbcCommand cmd1 = new OdbcCommand("update trailer set " + p1 + "=''," + p2 + "='0000-00-00' where vehicle_no='" + veh_no + "'", con.str);
                        cmd1.ExecuteNonQuery();
                        con.close_string();
                        tyre_details_remove_panel.Visibility = Visibility.Hidden;
                        rmv_vehicle_tyre_number.Text = string.Empty; rmv_vehicle_tyre_km.Text = string.Empty; rmv_vehicle_tyre_add_date.Text = string.Empty; rmv_vehicle_tyre_company.Text = string.Empty; rmv_vehicle_tyre_endkm.Text = string.Empty;
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
                else if (mr == MessageBoxResult.Cancel)
                {

                }
            }
            else
            {
                MessageBox.Show("Should Fill Ending KM");
            }
        }

        private void tyre_details_remove_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(rmv_vehicle_tyre_number.Text) && !string.IsNullOrWhiteSpace(rmv_vehicle_tyre_km.Text) && !string.IsNullOrWhiteSpace(rmv_vehicle_tyre_add_date.Text) && !string.IsNullOrWhiteSpace(rmv_vehicle_tyre_company.Text) && !string.IsNullOrWhiteSpace(rmv_vehicle_tyre_endkm.Text))
            {
                MessageBoxResult mr = MessageBox.Show("Are You Sure, Want to Remove this Tyre", "Remove Tyre", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (mr == MessageBoxResult.OK)
                {
                    try
                    {
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd = new OdbcCommand("update trailer_tyre_details set total_km=total_km+(" + Convert.ToInt32(rmv_vehicle_tyre_endkm.Text) + "-starting_km),status='RM' where no='" + rmv_vehicle_tyre_number.Text + "'", con.str);
                        cmd.ExecuteNonQuery();
                        OdbcCommand cmd2 = new OdbcCommand("update trailer_tyre_details set starting_km='0' where no='" + rmv_vehicle_tyre_number.Text + "'", con.str);
                        cmd2.ExecuteNonQuery();
                        OdbcCommand cmd1 = new OdbcCommand("update trailer set " + p1 + "=''," + p2 + "='0000-00-00' where vehicle_no='" + veh_no + "'", con.str);
                        cmd1.ExecuteNonQuery();
                        con.close_string();
                        tyre_details_remove_panel.Visibility = Visibility.Hidden;
                        rmv_vehicle_tyre_number.Text = string.Empty; rmv_vehicle_tyre_km.Text = string.Empty; rmv_vehicle_tyre_add_date.Text = string.Empty; rmv_vehicle_tyre_company.Text = string.Empty; rmv_vehicle_tyre_endkm.Text = string.Empty;
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
                else if (mr == MessageBoxResult.Cancel)
                {

                }


            }
            else
            {
                MessageBox.Show("Should Fill Ending KM");
            }

        }
       

        private void vehicle_tyre_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(vehicle_tyre_number.Text))
                {
                    Connection con = new Connection();
                    con.connection_string();
                    OdbcCommand cmd = new OdbcCommand("select company,date_format(purchase_date,'%d-%m-%Y'),price from trailer_tyre_details WHERE no='" + vehicle_tyre_number.Text + "'", con.str);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        vehicle_tyre_company.Text = dr[0].ToString();
                        tyre_price.Text = dr[2].ToString();
                        vehicle_tyre_pur_date.Text = dr[1].ToString();
                        vehicle_tyre_company.IsEnabled = false; tyre_price.IsEnabled = false; vehicle_tyre_pur_date.IsEnabled = false;
                    }
                }
                else
                {
                    vehicle_tyre_company.IsEnabled = true; tyre_price.IsEnabled = true; vehicle_tyre_pur_date.IsEnabled = true;
                }
            }

        }
        private void Remove_Back_Click(object sender, RoutedEventArgs e)
        {
            rmv_vehicle_tyre_number.Text = string.Empty;
            rmv_vehicle_tyre_km.Text = string.Empty;
            rmv_vehicle_tyre_company.Text = string.Empty;
            rmv_vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
            rmv_vehicle_tyre_endkm.Text = string.Empty;
            this.Hide();
        }
        void tyre_details_back_clicked(object sender, RoutedEventArgs e)
        {
            clear();
        }
        void clear()
        {
            tyre_details_entry_panel.Visibility = System.Windows.Visibility.Hidden;
            vehicle_tyre_number.Text = string.Empty; vehicle_tyre_km.Text = string.Empty;
            vehicle_tyre_company.Text = string.Empty; vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString();
            vehicle_tyre_pur_date.Text = DateTime.Now.ToShortDateString(); tyre_price.Text = string.Empty;
        }

        private void rmv_vehicle_tyre_endkm_TextChanged(object sender,TextChangedEventArgs e)
        {
            for (int i = 0; i < rmv_vehicle_tyre_endkm.Text.Length; i++)
            {
                bool isdigit = char.IsDigit(rmv_vehicle_tyre_endkm.Text[i]);
                if (!isdigit)
                {
                    rmv_vehicle_tyre_endkm.Text = "";
                    MessageBox.Show("Enter Number Only");
                }
            }
        }

        private void Add_Existing_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ex_vehicle_tyre_number.Text) && !string.IsNullOrWhiteSpace(ex_vehicle_tyre_km.Text) && !string.IsNullOrWhiteSpace(ex_vehicle_tyre_add_date.Text))
            {
                try
                {
                    MessageBoxResult mr = MessageBox.Show("Are You Sure,Want to Add Tyre", "Add Tyre", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.OK)
                    {
                        Connection CON = new Connection();
                        CON.connection_string();
                        OdbcCommand cmd = new OdbcCommand("select id from trailer_tyre_details where no like '" + ex_vehicle_tyre_number.Text + "'", CON.str);
                        OdbcDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if(!string.IsNullOrWhiteSpace(dr[0].ToString()))
                            {
                                OdbcCommand cmd1 = new OdbcCommand("update trailer_tyre_details set starting_km='" + ex_vehicle_tyre_km.Text + "',status='RU' where id='" + dr[0].ToString() + "' ", CON.str);
                                cmd1.ExecuteNonQuery();
                                OdbcCommand cmd2 = new OdbcCommand("update trailer set " + p1 + "='" + dr[0].ToString() + "'," + p2 + "='" + Convert.ToDateTime(ex_vehicle_tyre_add_date.Text).ToString("yyyy-MM-dd") + "' where vehicle_no='" + veh_no + "'", CON.str);
                                cmd2.ExecuteNonQuery();
                                ex_vehicle_tyre_number.Text = string.Empty; ex_vehicle_tyre_km.Text = string.Empty; ex_vehicle_tyre_add_date.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("Tyre Id Not Exist");
                            }
                           
                        }
                     

                        CON.close_string();

                    }
                    else if (mr == MessageBoxResult.Cancel)
                    {

                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
            }
            else
            {
                MessageBox.Show("Please Fill Empty Text Field");
            }
        }

        private void Existing_Checked(object sender, RoutedEventArgs e)
        {
            Existing_Tyre.Visibility = Visibility.Visible;
            tyre_details_entry_panel.Visibility = Visibility.Hidden;
            tyre_details_remove_panel.Visibility = Visibility.Hidden;            
        }

        private void New_Checked(object sender, RoutedEventArgs e)
        {
            Existing_Tyre.Visibility = Visibility.Hidden;
            tyre_details_entry_panel.Visibility = Visibility.Visible;
            tyre_details_remove_panel.Visibility = Visibility.Hidden;           
        }

        private void Back_Checked(object sender, RoutedEventArgs e)
        {
            Existing_Tyre.Visibility = Visibility.Hidden;
            tyre_details_entry_panel.Visibility = Visibility.Hidden;
            tyre_details_remove_panel.Visibility = Visibility.Hidden;
            clear(); ex_vehicle_tyre_number.Text = string.Empty; ex_vehicle_tyre_km.Text = string.Empty; ex_vehicle_tyre_add_date.Text = string.Empty;           
            this.Hide();
        }
    }
}
