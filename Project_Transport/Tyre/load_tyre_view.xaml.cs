using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_Transport 
{
    /// <summary>
    /// Interaction logic for load_tyre_view.xaml
    /// </summary>
    public partial class load_tyre_view : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        public load_tyre_view()
        {
            InitializeComponent();
            load_string gs = new load_string();
            gs.vehicle_tyre_number = string.Empty;
            gs.vehicle_tyre_km = string.Empty;
            gs.vehicle_tyre_company = string.Empty;
            gs.tyre_price = string.Empty;           
            gs.vehicle_tyre_no = string.Empty;
            gs.vehicle_tyre_stkm = string.Empty;            
            //gs.vehicle_tyre_number_view = string.Empty;
            //gs.vehicle_tyre_km_view = string.Empty;
            //gs.vehicle_tyre_company_view = string.Empty;
            //gs.tyre_price_view = string.Empty;
            //gs.vehicle_tyre_purchase_date_view = string.Empty;
            //gs.vehicle_tyre_add_date_view = string.Empty;
            gs.vehicle_tyre_ekm_view = string.Empty;
            gs.vehicle_tyre_tkm_view = string.Empty;
            this.DataContext = gs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param> 

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        string[] s = new string[6];
        public void View(string[] k,string b1,string b2,string s3)
        {
            s = k;
            vehicle_tyre_number_view.Text = s[0];
            vehicle_tyre_km_view.Text = s[1];
            vehicle_tyre_company_view.Text = s[2];
            tyre_price_view.Text = s[3];
            vehicle_tyre_purchase_date_view.Text = s[4];
            vehicle_tyre_add_date_view.Text = s[5];
            st = s3;
            p1 = b1;
            p2 = b2;
            tyre_details_view_panel.Visibility = Visibility.Visible;
            add_panel.Visibility = Visibility.Hidden;
        }
        string st;
        string p1;
        string p2;
        public void hide(string s3, string b1, string b2)
        {
            st = s3;
            p1 = b1;
            p2 = b2;
            tyre_details_view_panel.Visibility = Visibility.Hidden;
            add_panel.Visibility = Visibility.Visible;

        }
        private void new_tyre_Checked(object sender, RoutedEventArgs e)
        {
            tyre_details_entry_panel.Visibility = Visibility.Visible;
            tyre_detail_exist_panel.Visibility = Visibility.Hidden;

        }
        private void vehicle_tyre_no_GotFocus(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.connection_string();
            OdbcCommand cmd1 = new OdbcCommand("select No from load_tyre_details where Status='RM' ", con.str);
            OdbcDataReader da = cmd1.ExecuteReader();
            vehicle_tyre_no.Items.Clear();
            while (da.Read())
            {
                vehicle_tyre_no.Items.Add(da[0]);

            }
            con.close_string();
        }
        private void exist_tyre_Checked(object sender, RoutedEventArgs e)
        {
            tyre_details_entry_panel.Visibility = Visibility.Hidden;
            tyre_detail_exist_panel.Visibility = Visibility.Visible;

        }
        private void back_tyre_Checked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            tyre_details_entry_panel.Visibility = Visibility.Hidden;
            tyre_detail_exist_panel.Visibility = Visibility.Hidden;
            tyre_price.Text = string.Empty; vehicle_tyre_company.Text = string.Empty; vehicle_tyre_km.Text = string.Empty; vehicle_tyre_number.Text = string.Empty;
            vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString(); vehicle_tyre_purchase_date.Text = DateTime.Now.ToShortDateString();
            vehicle_tyre_no.Text = string.Empty; vehicle_tyre_stkm.Text = string.Empty; vehicle_tyre_added_date.Text = DateTime.Now.ToShortDateString();
        }
        private void tyre_details_ok_clicked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(vehicle_tyre_number.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_km.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_company.Text) && !string.IsNullOrWhiteSpace(tyre_price.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_purchase_date.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_add_date.Text))
            {


                MessageBoxResult mr = MessageBox.Show("DO you want to add", "Conformation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (mr == MessageBoxResult.OK)
                {
                    try
                    {
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd1 = new OdbcCommand("insert into load_tyre_details(No,Starting_KM,Company,Price,Purchase_date,Vehicle_no,Status)values('" + vehicle_tyre_number.Text + "','" + vehicle_tyre_km.Text + "','" + vehicle_tyre_company.Text + "','" + tyre_price.Text + "','" + Convert.ToDateTime(vehicle_tyre_purchase_date.Text).ToString("yyyy-MM-dd") + "','" + st + "','RU') ", con.str);
                        cmd1.ExecuteNonQuery();

                        OdbcCommand cmd = new OdbcCommand("select max(id) from load_tyre_details ", con.str);
                        OdbcDataReader drr = cmd.ExecuteReader();
                        while (drr.Read())
                        {

                            if (!string.IsNullOrWhiteSpace(drr[0].ToString()))
                            {
                                OdbcCommand cmd3 = new OdbcCommand("update load_tyre set " + p1 + " = " + drr[0].ToString() + "," + p2 + "= '" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy-MM-dd") + "' where vechile_no='" + st + "'", con.str);
                                cmd3.ExecuteNonQuery();
                                vehicle_tyre_add_date_view.Text = DateTime.Now.ToShortDateString(); vehicle_tyre_purchase_date_view.Text = DateTime.Now.ToShortDateString(); tyre_price_view.Text = string.Empty;
                                vehicle_tyre_company_view.Text = string.Empty; vehicle_tyre_km_view.Text = string.Empty; vehicle_tyre_number_view.Text = string.Empty;
                                vehicle_tyre_ekm_view.Text = string.Empty;
                                tyre_details_entry_panel.Visibility = Visibility.Hidden;
                                this.Hide();
                            }
                        }
                        con.close_string();
                       
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
                MessageBox.Show("Please Fill All Details");
            }
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(vehicle_tyre_no.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_stkm.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_added_date.Text))
            {
                MessageBoxResult mr = MessageBox.Show("DO you want to add", "Conformation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (mr == MessageBoxResult.OK)
                {
                    try
                    {
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd1 = new OdbcCommand("update load_tyre_details set Starting_KM='" + Convert.ToInt32(vehicle_tyre_stkm.Text) + "',Status='RU' where No='" + vehicle_tyre_no.Text + "'", con.str);
                        cmd1.ExecuteNonQuery();
                        OdbcCommand cmd = new OdbcCommand("select id from load_tyre_details where No='" + vehicle_tyre_no.Text + "'", con.str);
                        OdbcDataReader drr = cmd.ExecuteReader();
                        while (drr.Read())
                        {
                            if (!string.IsNullOrWhiteSpace(drr[0].ToString()))
                            {
                                OdbcCommand cmd3 = new OdbcCommand("update load_tyre set " + p1 + " = " + drr[0].ToString() + "," + p2 + "= '" + Convert.ToDateTime(vehicle_tyre_add_date.Text).ToString("yyyy-MM-dd") + "' where vechile_no='" + st + "'", con.str);
                                cmd3.ExecuteNonQuery();
                                vehicle_tyre_no.Text = string.Empty; vehicle_tyre_stkm.Text = string.Empty; vehicle_tyre_added_date.Text = DateTime.Now.ToShortDateString();
                                tyre_detail_exist_panel.Visibility = Visibility.Hidden;
                                this.Hide();
                            }
                        }
                        con.close_string();
                       
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
                MessageBox.Show("Please Fill All Details");
            }

        }





        private void rmv_Click(object sender, RoutedEventArgs e)
        {
            //vehicle_tyre_add_date_view.Text = string.Empty; vehicle_tyre_purchase_date_view.Text = string.Empty; tyre_price_view.Text = string.Empty;
            //vehicle_tyre_company_view.Text = string.Empty; vehicle_tyre_km_view.Text = string.Empty; vehicle_tyre_number_view.Text = string.Empty;
            //vehicle_tyre_ekm_view.Text = string.Empty;
            remove_panel.Visibility = Visibility.Visible; ;                      
        }
        private void done_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(vehicle_tyre_number_view.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_km_view.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_company_view.Text) && !string.IsNullOrWhiteSpace(tyre_price_view.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_purchase_date_view.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_add_date_view.Text))
            {

                MessageBoxResult mr = MessageBox.Show("DO you want to remove", "Conformation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (mr == MessageBoxResult.OK)
                {
                    try
                    {
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd1 = new OdbcCommand("update  load_tyre_details set Total_KM=Total_KM+('" + Convert.ToInt32(vehicle_tyre_ekm_view.Text) + "' - Starting_KM),Status='RM' where No='" + vehicle_tyre_number_view.Text + "' ", con.str);
                        cmd1.ExecuteNonQuery();
                        OdbcCommand cmd2 = new OdbcCommand("update load_tyre_details set Starting_KM='0' where No= '" + vehicle_tyre_number_view.Text + "' ", con.str);
                        cmd2.ExecuteNonQuery();
                        OdbcCommand cmd = new OdbcCommand("update load_tyre set " + p1 + "='0', " + p2 + "='0000-00-00' where Vechile_No='" + st + "'", con.str);
                        cmd.ExecuteNonQuery();
                        tyre_details_view_panel.Visibility = Visibility.Visible;
                        remove_panel.Visibility = Visibility.Hidden;
                        vehicle_tyre_add_date_view.Text = string.Empty; vehicle_tyre_purchase_date_view.Text = string.Empty; tyre_price_view.Text = string.Empty;
                        vehicle_tyre_company_view.Text = string.Empty; vehicle_tyre_km_view.Text = string.Empty; vehicle_tyre_number_view.Text = string.Empty;
                        vehicle_tyre_ekm_view.Text = string.Empty;
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
            remove_panel.Visibility = Visibility.Hidden;
        }
        private void back_view_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            vehicle_tyre_add_date_view.Text = DateTime.Now.ToShortDateString(); vehicle_tyre_purchase_date_view.Text = DateTime.Now.ToShortDateString(); tyre_price_view.Text = string.Empty;
            vehicle_tyre_company_view.Text = string.Empty; vehicle_tyre_km_view.Text = string.Empty; vehicle_tyre_number_view.Text = string.Empty;
            vehicle_tyre_ekm_view.Text = string.Empty;
        }

     
        private void permanent_Checked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(vehicle_tyre_number_view.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_km_view.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_company_view.Text) && !string.IsNullOrWhiteSpace(tyre_price_view.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_purchase_date_view.Text) && !string.IsNullOrWhiteSpace(vehicle_tyre_add_date_view.Text))
            {

                MessageBoxResult mr = MessageBox.Show("DO you want to remove", "Conformation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (mr == MessageBoxResult.OK)
                {
                    try
                    {
                        Connection con = new Connection();
                        con.connection_string();
                        OdbcCommand cmd1 = new OdbcCommand("update  load_tyre_details set Total_KM=Total_KM+('" + Convert.ToInt32(vehicle_tyre_ekm_view.Text) + "' - Starting_KM),Status='PR' where No='" + vehicle_tyre_number_view.Text + "' ", con.str);
                        cmd1.ExecuteNonQuery();
                        OdbcCommand cmd2 = new OdbcCommand("update load_tyre_details set Starting_KM='0' where No= '" + vehicle_tyre_number_view.Text + "' ", con.str);
                        cmd2.ExecuteNonQuery();
                        OdbcCommand cmd = new OdbcCommand("update load_tyre set " + p1 + "='0', " + p2 + "='0000-00-00' where Vechile_No='" + st + "'", con.str);
                        cmd.ExecuteNonQuery();
                        tyre_details_view_panel.Visibility = Visibility.Visible;
                        remove_panel.Visibility = Visibility.Hidden;
                        vehicle_tyre_add_date_view.Text = string.Empty; vehicle_tyre_purchase_date_view.Text = string.Empty; tyre_price_view.Text = string.Empty;
                        vehicle_tyre_company_view.Text = string.Empty; vehicle_tyre_km_view.Text = string.Empty; vehicle_tyre_number_view.Text = string.Empty;
                        vehicle_tyre_ekm_view.Text = string.Empty;
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
            remove_panel.Visibility = Visibility.Hidden;
        }

        private void tyre_details_back_clicked(object sender, RoutedEventArgs e)
        {
            tyre_details_entry_panel.Visibility = Visibility.Hidden;
            tyre_price.Text = string.Empty; vehicle_tyre_company.Text = string.Empty; vehicle_tyre_km.Text = string.Empty; vehicle_tyre_number.Text = string.Empty;
            vehicle_tyre_add_date.Text = DateTime.Now.ToShortDateString(); vehicle_tyre_purchase_date.Text= DateTime.Now.ToShortDateString();
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            tyre_detail_exist_panel.Visibility = Visibility.Hidden;
            vehicle_tyre_no.Text = string.Empty; vehicle_tyre_stkm.Text = string.Empty; vehicle_tyre_added_date.Text = DateTime.Now.ToShortDateString();
        }

       
    }








}
