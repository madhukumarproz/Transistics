using System;
using System.Data;
using System.Data.Odbc;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

 
namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class Load_Trailer :UserControl
    {
       public char veh_typ = 'n';
        public int ti = 2;
        System.Windows.Threading.DispatcherTimer time1 = new System.Windows.Threading.DispatcherTimer();
        int ii = 0;
        string chr = null;
        int i = 0;
        double da = 0;
        double tl = 0;
        string[] type = new string[20];
        string[] place = new string[20];
        double[] litter = new double[20];
        double[] price = new double[20];
        string[] date = new string[20];
        double[] tot_price = new double[20];
        string[] card_id = new string[20];
        int[] no_of_time = new int[20];
        double card_tot = 0;
        int t_count = 1;
        int r_count = 1;
        int o_count = 1;
        string[] tollplace = new string[10];
        string[] rtoplace = new string[10];
        string[] others = new string[10];
        double[] tollamount = new double[10];
        double[] rtoamount = new double[10];
        double[] otheramount = new double[10];
        string[] otherreason = new string[10];
        public Load_Trailer() 
        {
            InitializeComponent();
            time1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            time1.Tick += time_tick1;
        }
        List<string> number = new List<string>();

        void time_tick1(object sender, EventArgs e)
        {
            if (ii == 10)
            {
                if (chr == "i")
                {
                    lpg_trip_insert_imgs1.Visibility = System.Windows.Visibility.Visible;
                    lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
                else if (chr == "r")
                {
                    lpg_trip_close_img1.Visibility = System.Windows.Visibility.Visible;
                    lpg_trip_close_img2.Visibility = System.Windows.Visibility.Hidden;
                    time1.Stop();
                    chr = "";
                }
            }
            ii++;
        }
       

        private void tripdes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            diesel_calculation.Visibility = Visibility.Visible;
        }

        private void tripload_Checked(object sender, RoutedEventArgs e)
        {
            Thickness margin = insert.Margin;
            margin.Left = 0; margin.Right = 0; margin.Top = 190; margin.Bottom = 0;
            insert.Margin = margin;
            Thickness margin1 = reset.Margin;
            margin1.Left = 250; margin1.Right = 0; margin1.Top = 190; margin1.Bottom = 0;
            reset.Margin = margin1;
            unloadpanel.Visibility = Visibility.Hidden;
            closepanel.Visibility = Visibility.Hidden;
            tripnumber.IsEnabled = false;
            string S = veh_typ.ToString();
            Trip_Load tl = new Trip_Load();
            number= tl.Trip_Load_Checked(S);
            if(number != null|| number.All(x=>string.IsNullOrWhiteSpace(x)))
            {
                loadpanel.Visibility = Visibility.Visible;                
                vhlno.ItemsSource = number;
            }
            else
            {
                MessageBox.Show("Vehicle Number Not Exist");
            }
            
        }

        private void tripunload_Checked(object sender, RoutedEventArgs e)
        {
            Thickness margin = insert.Margin;
            margin.Left = 0; margin.Right = 0; margin.Top = 190; margin.Bottom = 0;
            insert.Margin = margin;
            Thickness margin1 = reset.Margin;
            margin1.Left = 250; margin1.Right = 0; margin1.Top = 190; margin1.Bottom = 0;
            reset.Margin = margin1;
            string s = veh_typ.ToString();
            loadpanel.Visibility = Visibility.Hidden;
            closepanel.Visibility = Visibility.Hidden;
            tripnumber.IsEnabled = false;
            Trip_Load tl = new Trip_Load();
            number = tl.Trip_Unload_Checked(s);
            vhlno.Text = "";
            if (number != null || number.All(x => string.IsNullOrWhiteSpace(x)))
            {
                //vhlno.Items.Clear();
                unloadpanel.Visibility = Visibility.Visible;                
                vhlno.ItemsSource = number;
            }
            else
            {
                MessageBox.Show("Vehicle Number Not Exist");
            }
        }

        private void tripclose_Checked(object sender, RoutedEventArgs e)
        {
            Thickness margin = insert.Margin;
            margin.Left = 800; margin.Right = 0; margin.Top = 190; margin.Bottom = 0;
            insert.Margin = margin;
            Thickness margin1 = reset.Margin;
            margin1.Left = 1050; margin1.Right = 0; margin1.Top = 190; margin1.Bottom = 0;
            reset.Margin = margin1;
            loadpanel.Visibility = Visibility.Hidden;
            unloadpanel.Visibility = Visibility.Hidden;
            string s = veh_typ.ToString();
            Trip_Load tl = new Trip_Load();
           number= tl.Trip_Closed_Checked(s);
            if (number != null || number.All(x => string.IsNullOrWhiteSpace(x)))
            {
                //tripnumber.Items.Clear();
                tripnumber.IsEditable = true;
                tripnumber.IsEnabled = true;
                closepanel.Visibility = Visibility.Visible;
                tripnumber.ItemsSource = number;
            }
            else
            {
                MessageBox.Show("Vehicle Number Not Exist");
            }
            
        }

        private void pymt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            payment.Visibility = Visibility.Visible;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Trip_Load tl = new Trip_Load();
            int i = Convert.ToInt32(dripaymt.Text) + Convert.ToInt32(clinerpymt.Text) + Convert.ToInt32(commis.Text);
           i= tl.Payment_Ok_btn_Click(i);
            if(i>0)
            {
                paymt.Text = i.ToString();
                dripaymt.Text = "0";
                clinerpymt.Text = "0";
                commis.Text = "0";
                payment.Visibility = Visibility.Hidden;
            }
            else
            {

            }

        }

        private void dripaymt_GotFocus(object sender, RoutedEventArgs e)
        {
            dripaymt.Text = string.Empty;
        }

        private void dripaymt_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(dripaymt.Text))
            {
                dripaymt.Text = "0";
            }
        }

        private void clinerpymt_GotFocus(object sender, RoutedEventArgs e)
        {
            clinerpymt.Text = string.Empty;
        }

        private void clinerpymt_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(clinerpymt.Text))
            {
                clinerpymt.Text = "0";
            }
        }

        private void commis_GotFocus(object sender, RoutedEventArgs e)
        {
            commis.Text = string.Empty;
        }

        private void commis_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(commis.Text))
            {
                commis.Text = "0";
            }
        }
        
        private void time_Checked(object sender, RoutedEventArgs e)
        {
            ti = 1;
        }

        private void untime_Checked(object sender, RoutedEventArgs e)
        {
            ti = 0;
        }

        private void loaddate_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                
                if (tripload.IsChecked == true)
                {
                    if (!string.IsNullOrEmpty(vhlno.Text) && !string.IsNullOrEmpty(loaddate.Text))
                    {
                        try            
                        {
                            tripnumber.IsEditable = true;
                            Trip_Load tl = new Trip_Load();
                            tripnumber.Text= tl.Load_Date_KeyDown(vhlno.Text, loaddate.Text);
                            tripnumber.IsEnabled = false;
                        }
                        catch
                        {
                            MessageBox.Show("Invalid Date");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Select Vehicle Number and Date");
                    }
                }

            }
            
        }

        private void dieselamt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        public void array_clear()
        {
            Array.Clear(type, 0, type.Length);
            Array.Clear(place, 0, place.Length);
            Array.Clear(litter, 0, litter.Length);
            Array.Clear(price, 0, price.Length);
            Array.Clear(date, 0, date.Length);
            Array.Clear(no_of_time, 0, no_of_time.Length);
            Array.Clear(tot_price, 0, tot_price.Length);
            Array.Clear(card_id, 0, card_id.Length);
            i = 0;
        }
        public void diesel_back_click(object sender, RoutedEventArgs e)
        {

            try
            {
                array_clear();
                diesel_calculation.Visibility = Visibility.Hidden;
                diesel_price.Text = "";
                diesel_litter.Text = "";
                diesel_price.Focus();
                da = 0;
                tl = 0;                
                total_price.Text = "";

                Trip_Load t = new Trip_Load();
                t.Diesel_Calculation_Back_btn_Click();
            }
            catch
            {
                MessageBox.Show("Diesel Text Doesn't Clear");
            }
        }

        private void diesel_calculation_done_click(object sender, RoutedEventArgs e)
        {
            if (tl != 0 & da != 0)
            {
                try
                {
                    
                    tripdese.Text = tl.ToString();
                    dieselamnt.Text = da.ToString();
                    tripmilg.Text = Math.Round((Convert.ToDouble(trp_val[7].ToString()) / tl), 2).ToString();
                    tl = 0; da = 0;
                    diesel_calculation.Visibility = Visibility.Hidden;
                    from_card.IsChecked = false;
                    from_advance.IsChecked = false;
                    total_price.Text = ""; diesel_card_id.Text = "";
                }
                catch
                {
                    MessageBox.Show("Deisel Calculation Error");
                }

            }
            else
            {
                MessageBox.Show("Should Fill All Field");
            }
           
            
           
        }

        private void expense_done_Click(object sender, RoutedEventArgs e)
        {
            Double A1 = 0;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select sum(total_cost) as amount from diesel_balance_sheet where trip_number='" + tripnumber.Text + "' and withdraw='ADVANCE'", con.conn);
                OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    string am = DT.Rows[0]["amount"].ToString();
                    if (!string.IsNullOrWhiteSpace(am))
                    {
                        A1 = Convert.ToDouble(am);
                    }
                    else
                    {
                        A1 = 0;
                    }

                }
                else
                {

                }

                con.close_connection();
                if (frtpty.Text != null & dieselamnt.Text != null)
                {
                    double d = Convert.ToDouble(toll_total.Text) + Convert.ToDouble(rto_total.Text) + Convert.ToDouble(other_total.Text) + Convert.ToDouble(val11.Text) + Convert.ToDouble(val12.Text) + Convert.ToDouble(val13.Text) + Convert.ToDouble(val14.Text) + Convert.ToDouble(val15.Text) + Convert.ToDouble(val16.Text);
                    tripexpe.Text = d.ToString();
                    int drvpayment =(Convert.ToInt32 (trp_val[6].ToString()) - Convert.ToInt32(frtpty.Text)) * Convert.ToInt32(trp_val[8].ToString()) / 100;
                    profit.Text = (Convert.ToDouble(trp_val[6].ToString()) - d - Convert.ToDouble(dieselamnt.Text) - Convert.ToDouble(drvpayment) - Convert.ToDouble(frtpty.Text)).ToString();
                    driver_bal.Text = (Convert.ToDouble(trp_val[5].ToString()) - d - A1).ToString();
                    lpg_trip_expense_panel.Visibility = System.Windows.Visibility.Hidden;
                   
                }

                else
                {
                    MessageBox.Show(" ENTER TRIP FRIEGHT AND ADVANCE");
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }
        public void CLEAR()
        {
            Array.Clear(tollamount, 0, tollamount.Length);
            Array.Clear(tollplace, 0, tollplace.Length);
            Array.Clear(rtoamount, 0, rtoamount.Length);
            Array.Clear(rtoplace, 0, rtoplace.Length);
            Array.Clear(otheramount, 0, otheramount.Length);
            Array.Clear(otherreason, 0, otherreason.Length);
            t_count = 1; r_count = 1; o_count = 1;
        }
        private void trip_expense_back_click(object sender, RoutedEventArgs e)
        {
           
            toll_total.Text = ""; rto_total.Text = ""; other_total.Text = ""; val11.Text = ""; val12.Text = ""; val13.Text = ""; val14.Text = ""; val15.Text = ""; val16.Text = "";
            CLEAR();
            lpg_trip_expense_panel.Visibility = System.Windows.Visibility.Hidden;
        }
        
        private void load_Checked(object sender, RoutedEventArgs e)
        {
            veh_typ = 'L';
            paymt.Text = Properties.Settings.Default.LoadPay.ToString();
            trailer.IsChecked = false;
        }

        private void trailer_Checked(object sender, RoutedEventArgs e)
        {
            veh_typ = 'T';
            paymt.Text = Properties.Settings.Default.TrailerPay.ToString();
            load.IsChecked = false;
        }

       
        
       

        private void driname_GotFocus(object sender, RoutedEventArgs e)
        {
            
            Trip_Load tl = new Trip_Load();
           number= tl.Driver_Name_GotFocus();
            string id = tl.Get_Driver_Id(vhlno.Text);
            if (number != null || number.All(x => string.IsNullOrWhiteSpace(x)))
            {                
                driname.ItemsSource = number;
                driname.Text = id;
            }
            else
            {
                MessageBox.Show("Drivers Id Not Exist");
            }

        }

        private void stkm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(vhlno.Text) && !string.IsNullOrWhiteSpace(stkm.Text))
                {
                    Trip_Load tl = new Trip_Load();
                   string msg= tl.Startingkm_KeyDown(stkm.Text,vhlno.Text);
                    if(msg!="NO")
                    {
                        stkm.Text = string.Empty;
                        e.Handled = true;
                    }
                    else if(msg=="0")
                    {
                        stkm.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show("Select Vehicle Number and Enter the Km");
                }
               
            }
            
        }
        private void wgt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(wgt.Text))
                {
                    Trip_Load tl = new Trip_Load();
                   string msg= tl.Load_Weight_KeyDown(wgt.Text);
                    if(msg!="NO")
                    {
                        wgt.Text = string.Empty;
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Enter Weight");
                }
            }
           
        }
        private void unlodwgt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Tab||e.Key==Key.Enter)
            {
                Trip_Load tl = new Trip_Load();
               string msg= tl.Unload_Weight_KeyDown(vhlno.Text, unlodwgt.Text);
                if(msg=="")
                {
                    unlodwgt.Text = string.Empty;
                    e.Handled = true;
                }
            }
           
        }
        private void endkms_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                Trip_Load tl = new Trip_Load();
               string msg= tl.Endingkm_KeyDown(vhlno.Text, endkms.Text);
                if(msg=="")
                {
                    endkms.Text = string.Empty;
                    e.Handled = true;
                }
                else
                {
                    totalkm.Text = msg;
                }
            }
           
        }
        private void from_card_Checked(object sender, RoutedEventArgs e)
        {
            diesel_card_id.IsEnabled = true;
            Trip_Load tl = new Trip_Load();
            if(!string.IsNullOrWhiteSpace(vhlno.Text))
            {
                string[] msg = tl.Card_Checked(vhlno.Text);
                card_balance.Text = msg[1].ToString();
                diesel_card_id.Text = msg[0].ToString();
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
                from_card.IsChecked = false;
            }
          
        }

        private void from_advance_Checked(object sender, RoutedEventArgs e)
        {
            diesel_card_id.IsEnabled = false;
            diesel_card_id.Text = "ADVANCE";
            card_balance.Text = "";
        }

        private void Diesel_litter_Gotfocus(object sender, RoutedEventArgs e)
        {
            diesel_litter.Text = "";           
        }

        private void Diesel_Litter_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(diesel_litter.Text))
                {
                    diesel_litter.Text = "";
                }
            }
        }

        private void diesel_total_calculate(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(diesel_litter.Text) && !string.IsNullOrWhiteSpace(diesel_price.Text))
                {
                    total_price.Text = (Convert.ToDouble(diesel_litter.Text) * Convert.ToDouble(diesel_price.Text)).ToString();
                }
                else if(!string.IsNullOrWhiteSpace(diesel_litter.Text) && !string.IsNullOrWhiteSpace(total_price.Text))
                {
                    diesel_price.Text= ( Convert.ToDouble(total_price.Text)/ Convert.ToDouble(diesel_litter.Text)).ToString();
                }
                else if(!string.IsNullOrWhiteSpace(diesel_price.Text) && !string.IsNullOrWhiteSpace(total_price.Text))
                {
                    Double v = Math.Round(Convert.ToDouble(total_price.Text) / Convert.ToDouble(diesel_price.Text));
                    diesel_litter.Text = v.ToString();
                }
                if (from_card.IsChecked == true && !string.IsNullOrWhiteSpace(fill_place.Text) && !string.IsNullOrWhiteSpace(diesel_litter.Text) && !string.IsNullOrWhiteSpace(diesel_price.Text) && !string.IsNullOrWhiteSpace(fill_date.Text) && !string.IsNullOrWhiteSpace(card_balance.Text) && !string.IsNullOrWhiteSpace(diesel_card_id.Text) && !string.IsNullOrWhiteSpace(total_price.Text))
                {
                    try
                    {

                        //double td = Convert.ToDouble(diesel_litter.Text) * Convert.ToDouble(diesel_price.Text);
                        //total_price.Text = td.ToString();
                        card_tot = Convert.ToDouble(card_balance.Text) - Convert.ToDouble(total_price.Text);
                        if (Convert.ToDouble(card_balance.Text) < Convert.ToDouble(total_price.Text))
                        {
                            MessageBoxResult mbr = MessageBox.Show("Card balance is Below the Amount", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            if (mbr == MessageBoxResult.OK)
                            {
                                //diesel_price.Text = "";
                                //diesel_litter.Text = "";
                                //diesel_price.Focus();
                                //da = 0;
                                //tl = 0;
                                //bal = 0;
                                //balance = 0;
                                //no_of_time = 1;
                                //total_price.Content = "";                              
                            }
                        }
                        else
                        {
                            card_balance.Text = card_tot.ToString();
                            tl += Convert.ToDouble(diesel_litter.Text);
                            da += Convert.ToDouble(total_price.Text);
                            type[i] = "CARD";
                            place[i] = fill_place.Text;
                            litter[i] = Convert.ToDouble(diesel_litter.Text);
                            price[i] = Convert.ToDouble(diesel_price.Text);
                            date[i] = Convert.ToDateTime(fill_date.Text).ToString("yyyy/MM/dd");
                            no_of_time[i] = i + 1;
                            tot_price[i] = Convert.ToDouble(total_price.Text);
                            card_id[i] = diesel_card_id.Text;
                            i += 1;
                            fill_place.Text = ""; fill_date.Text = DateTime.Now.ToShortDateString(); diesel_price.Text = ""; diesel_litter.Text = ""; total_price.Text = "";
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Error from Diesel Total Cost Calculation");
                    }
                }
                else if (from_advance.IsChecked == true && !string.IsNullOrWhiteSpace(fill_place.Text) && !string.IsNullOrWhiteSpace(diesel_litter.Text) && !string.IsNullOrWhiteSpace(diesel_price.Text) && !string.IsNullOrWhiteSpace(fill_date.Text) && !string.IsNullOrWhiteSpace(diesel_card_id.Text) && !string.IsNullOrWhiteSpace(total_price.Text))
                {
                    try
                    {
                        tl += Convert.ToDouble(diesel_litter.Text);
                        //double td = Convert.ToDouble(diesel_litter.Text) * Convert.ToDouble(diesel_price.Text);
                        //total_price.Text = td.ToString();
                        da += Convert.ToDouble(total_price.Text);
                        type[i] = "CARD";
                        place[i] = fill_place.Text;
                        litter[i] = Convert.ToDouble(diesel_litter.Text);
                        price[i] = Convert.ToDouble(diesel_price.Text);
                        date[i] = Convert.ToDateTime(fill_date.Text).ToString("yyyy/MM/dd");
                        no_of_time[i] = i + 1;
                        tot_price[i] = Convert.ToDouble(total_price.Text);
                        card_id[i] = diesel_card_id.Text;
                        i += 1;
                        fill_place.Text = ""; fill_date.Text = DateTime.Now.ToShortDateString(); diesel_price.Text = ""; diesel_litter.Text = ""; total_price.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Check Diesel Litter and Price");
                    }
                }
                else
                {
                    MessageBox.Show("Should Fill All Field And Select Card or Advance");
                }



            }
           
        }

        private void Load_Wages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val11.Text))
                {
                    val11.Text = "0";
                }
            }
        }

        private void Load_Wages_Gotfocus(object sender, RoutedEventArgs e)
        {
            val11.Text = "";
        }
    

        private void Unload_Wages_GotFocus(object sender, RoutedEventArgs e)
        {
            val12.Text = "";
        }

        private void Unload_Wages_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val12.Text))
                {
                    val12.Text = "0";
                }
            }
        }

        private void Phone_Wages_Gotfocus(object sender, RoutedEventArgs e)
        {
            val13.Text = "";
        }

        private void Phone_Wages_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val13.Text))
                {
                    val13.Text = "0";
                }
            }
        }

        private void Spares_Wages_Gotfocus(object sender, RoutedEventArgs e)
        {
            val14.Text = "";
        }

        private void Spares_Wages_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val14.Text))
                {
                    val14.Text = "0";
                }
            }
        }

        private void Driver_Wages_Gotfocus(object sender, RoutedEventArgs e)
        {
            val15.Text = "";
        }

        private void Driver_Wages_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val15.Text))
                {
                    val15.Text = "0";
                }
            }
        }

        private void Clener_Wages_Gotfocus(object sender, RoutedEventArgs e)
        {
            val16.Text = "";
        }

        private void Cleaner_Wages_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(val16.Text))
                {
                    val16.Text = "0";
                }
            }
        }

        private void Toll_Amount_Gotfocus(object sender, RoutedEventArgs e)
        {
            toll_amount.Text = "";
        }

        private void toll_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(toll_amount.Text))
                    {
                        double t = Convert.ToDouble(toll_amount.Text) + Convert.ToDouble(toll_total.Text);
                        toll_total.Text = t.ToString();
                        tollamount[t_count - 1] = Convert.ToDouble(toll_amount.Text);
                        tollplace[t_count - 1] = toll_place.Text;
                        toll_amount.Text = "0"; toll_place.Text = ""; t_count += 1;
                    }
                    else if (string.IsNullOrWhiteSpace(toll_amount.Text))
                    {
                        double t = Convert.ToDouble(toll_total.Text) + 0;
                        toll_total.Text = t.ToString();
                        //tollamount[t_count - 1] = t;
                        //tollplace[t_count - 1] = toll_place.Text;
                        //toll_amount.Text = "0"; toll_place.Text = ""; t_count += 1;
                    }
                    else
                    {
                        MessageBox.Show("Should fill all text field");
                    }
                }
                catch
                {
                    MessageBox.Show("Toll Amount Format Error");
                }


            }
        }

        private void rto_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(rto_amount.Text))
                    {
                        double t = Convert.ToDouble(rto_amount.Text) + Convert.ToDouble(rto_total.Text);
                        rto_total.Text = t.ToString();
                        rtoamount[r_count - 1] = Convert.ToDouble(rto_amount.Text);
                        rtoplace[r_count - 1] = rto_place.Text;
                        rto_amount.Text = "0"; rto_place.Text = ""; r_count += 1;
                    }
                    else if (string.IsNullOrWhiteSpace(rto_amount.Text))
                    {
                        double t = Convert.ToDouble(rto_total.Text) + 0;
                        rto_total.Text = t.ToString();
                        //rtoamount[r_count - 1] = t;
                        //rtoplace[r_count - 1] = rto_place.Text;
                        //rto_amount.Text = "0"; rto_place.Text = ""; r_count += 1;
                    }
                    else
                    {
                        MessageBox.Show("Should fill all text field");
                    }
                }
                catch
                {
                    MessageBox.Show("Rto Amount Format Error");
                }


            }
        }

        private void Rto_Amount_Gotfocus(object sender, RoutedEventArgs e)
        {
            rto_amount.Text = "";
        }

        private void other_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(other_amount.Text))
                    {
                        double t = Convert.ToDouble(other_amount.Text) + Convert.ToDouble(other_total.Text);
                        other_total.Text = t.ToString();
                        otheramount[o_count - 1] = Convert.ToDouble(other_amount.Text);
                        otherreason[o_count - 1] = other_reason.Text;
                        other_amount.Text = "0"; other_reason.Text = ""; o_count += 1;
                    }
                    else if (string.IsNullOrWhiteSpace(other_amount.Text))
                    {
                        double t = Convert.ToDouble(other_total.Text) + 0;
                        other_total.Text = t.ToString();
                        //otheramount[o_count - 1] = t;
                        //otherreason[o_count - 1] = other_reason.Text;
                        //other_amount.Text = "0"; other_reason.Text = ""; o_count += 1;
                    }
                    else
                    {
                        MessageBox.Show("Should fill all text field");
                    }
                }
                catch
                {
                    MessageBox.Show("Other Amount Format Error");
                }

            }
        }

        private void Other_Amount_Gotfocus(object sender, RoutedEventArgs e)
        {
            other_amount.Text = "";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            frtpty.IsEnabled = true;
            freight_reduction.IsChecked = false;
        }

        private void frtpty_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(frtpty.Text))
            {
                frtpty.Text = "0";
            }
        }

        private void wgt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Trip_Load tl = new Trip_Load();
            string msg=tl.Load_Weight_Textchanged(wgt.Text);
            if(msg!="NO")
            {
                wgt.Text = string.Empty;
            }
        }

        private void stkm_TextChanged(object sender, TextChangedEventArgs e)
        {
            Trip_Load tl = new Trip_Load();
            string MSG= tl.Startingkm_Textchanged(stkm.Text);
            if(MSG!="NO")
            {
                stkm.Text = string.Empty;
            }
        }

        private void unlodwgt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Trip_Load tl = new Trip_Load();
          string msg=  tl.Unload_Weight_Textchanged(unlodwgt.Text);
            if(msg=="")
            {
                unlodwgt.Text = "";
            }
        }

        private void frtpty_GotFocus(object sender, RoutedEventArgs e)
        {
            frtpty.Text = string.Empty;
        }
        string[] trp_val;
        private void tripnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                if(tripclose.IsChecked==true&&!string.IsNullOrWhiteSpace(tripnumber.Text))
                {
                   
                    Trip_Load tl = new Trip_Load();
                    trp_val = tl.TripNumber_Keydown(tripnumber.Text);
                    vhlno.Text = trp_val[0].ToString();
                    loaddate.Text = trp_val[1].ToString();
                    driname.Text = trp_val[2].ToString();
                    ldna.Text = trp_val[3].ToString();
                } 
                else
                {
                    MessageBox.Show("Select Trip Number");
                }               
            }            
        }

      

        private void Litter_Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validation v = new Validation();
            v.PreviewTextInput(sender, e);
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            if (tripload.IsChecked == true)
            {
                vhlno.Text = string.Empty; loaddate.Text = DateTime.Now.ToShortDateString(); tripnumber.Text = string.Empty; driname.Text = string.Empty; ldna.Text = string.Empty; form.Text = string.Empty; too.Text = string.Empty; stkm.Text = string.Empty; chln.Text = string.Empty; ldadv.Text = string.Empty; driadv.Text = string.Empty; frgt.Text = string.Empty; clname.Text = string.Empty; wgt.Text = string.Empty; ti = 2;
                load.IsChecked = false; trailer.IsChecked = false; tripload.IsChecked = false;
                lpg_trip_close_img1.Visibility = System.Windows.Visibility.Hidden;
                lpg_trip_close_img2.Visibility = System.Windows.Visibility.Visible;
                time1.Start();
                chr = "r";
            }
            else if (tripunload.IsChecked == true)
            {
                vhlno.Text = string.Empty; undt.Text = DateTime.Now.ToShortDateString(); endkms.Text = string.Empty; totalkm.Text = string.Empty; unlodwgt.Text = string.Empty; tripnumber.Text = string.Empty; driname.Text = string.Empty; ldna.Text = string.Empty; 
                load.IsChecked = false; trailer.IsChecked = false; tripunload.IsChecked = false;
                lpg_trip_close_img1.Visibility = System.Windows.Visibility.Hidden;
                lpg_trip_close_img2.Visibility = System.Windows.Visibility.Visible;
                time1.Start();
                chr = "r";
            }
            else if (tripclose.IsChecked == true)
            {

                Load_Trailer lt = new Load_Trailer();
                lt.diesel_back_click(sender, e);
                lt.CLEAR();
                val11.Text = "0"; val12.Text = "0"; val13.Text = "0"; val14.Text = "0"; val15.Text = "0"; val16.Text = "0";
                tripdese.Text = string.Empty; dieselamnt.Text = string.Empty; tripmilg.Text = string.Empty; frtpty.Text = string.Empty; tripexpe.Text = string.Empty; profit.Text = string.Empty; tripnumber.Text = string.Empty; vhlno.Text = string.Empty; loaddate.Text = DateTime.Now.ToShortDateString(); driname.Text = string.Empty; ldna.Text = string.Empty; driver_bal.Text = string.Empty;
                load.IsChecked = false; trailer.IsChecked = false; tripclose.IsChecked = false;
                lpg_trip_close_img1.Visibility = System.Windows.Visibility.Hidden;
                lpg_trip_close_img2.Visibility = System.Windows.Visibility.Visible;
                time1.Start();
                chr = "r";
            }
        }

        private void Disel_Price_Gotfocus(object sender, RoutedEventArgs e)
        {
            diesel_price.Text = "";
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            string[] val = new string[16];
            int[] count = new int[4];
            double[] total = new double[16];
            Trip_Load tl = new Trip_Load();
            string ch =null;
            if(tripload.IsChecked==true)
            {
                ch = "L";
                val[0] = vhlno.Text; val[1] = loaddate.Text; val[2] = tripnumber.Text; val[3] = driname.Text; val[4] = ldna.Text; val[5] = form.Text;
                val[6] = too.Text; val[7] = stkm.Text; val[8] = chln.Text; val[9] = ldadv.Text; val[10] = driadv.Text; val[11] = frgt.Text;
                val[12] = clname.Text; val[13] = wgt.Text; val[14] = ti.ToString(); val[15] = veh_typ.ToString();
                string msg = tl.Load_Trailer_Insert_btn_Click(ch, val, count, type, place, litter, price, date, tot_price, card_id, no_of_time, tollplace, rtoplace, otherreason, tollamount, rtoamount, otheramount, total);
                if (msg == "Success1")
                {
                    vhlno.Text = string.Empty; loaddate.Text = DateTime.Now.ToShortDateString(); tripnumber.Text = string.Empty; driname.Text = string.Empty; ldna.Text = string.Empty; form.Text = string.Empty; too.Text = string.Empty; stkm.Text = string.Empty; chln.Text = string.Empty; ldadv.Text = string.Empty; driadv.Text = string.Empty; frgt.Text = string.Empty; clname.Text = string.Empty; wgt.Text = string.Empty; ti = 2;
                    load.IsChecked = false; trailer.IsChecked = false; tripload.IsChecked = false; time.IsChecked = false; untime.IsChecked = false;
                    lpg_trip_insert_imgs1.Visibility = System.Windows.Visibility.Hidden;
                    lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Visible;
                    time1.Start();
                    chr = "i";
                }
            }
            else if(tripunload.IsChecked==true)
            {
                ch = "U";
                val[0] = vhlno.Text;  val[1] = tripnumber.Text; val[2] = loaddate.Text; val[3] = endkms.Text; val[4] = totalkm.Text;
                val[5] = unlodwgt.Text; val[6] = paymt.Text;
                string msg = tl.Load_Trailer_Insert_btn_Click(ch, val, count, type, place, litter, price, date, tot_price, card_id, no_of_time, tollplace, rtoplace, otherreason, tollamount, rtoamount, otheramount, total);
                if (msg == "Success2")
                {
                    vhlno.Text = string.Empty; undt.Text = DateTime.Now.ToShortDateString(); endkms.Text = string.Empty; totalkm.Text = string.Empty; unlodwgt.Text = string.Empty; tripnumber.Text = string.Empty; driname.Text = string.Empty; ldna.Text = string.Empty; paymt.Text = string.Empty;
                    load.IsChecked = false; trailer.IsChecked = false; tripunload.IsChecked = false;
                    lpg_trip_insert_imgs1.Visibility = System.Windows.Visibility.Hidden;
                    lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Visible;
                    time1.Start();
                    chr = "i";
                }
            }
            else if(tripclose.IsChecked==true)
            {                
                if ( !string.IsNullOrWhiteSpace(tripdese.Text) && !string.IsNullOrWhiteSpace(tripmilg.Text) && !string.IsNullOrWhiteSpace(dieselamnt.Text) && !string.IsNullOrWhiteSpace(frtpty.Text) && !string.IsNullOrWhiteSpace(tripexpe.Text) && !string.IsNullOrWhiteSpace(profit.Text) && !string.IsNullOrWhiteSpace(driver_bal.Text))
                {
                    ch = "C";
                    val[0] = vhlno.Text; val[1] = tripnumber.Text; val[2] = trp_val[9].ToString(); val[3] = trp_val[10].ToString(); val[4] = veh_typ.ToString();
                    total[0] = Convert.ToDouble(toll_total.Text); total[1] = Convert.ToDouble(rto_total.Text); total[2] = Convert.ToDouble(other_total.Text); total[3] = Convert.ToDouble(tripdese.Text); total[4] = Convert.ToDouble(dieselamnt.Text); total[5] = Convert.ToDouble(tripmilg.Text); total[6] = Convert.ToDouble(frtpty.Text);
                    total[7] = Convert.ToDouble(tripexpe.Text); total[8] = Convert.ToDouble(profit.Text); total[9] = Convert.ToDouble(driver_bal.Text); total[10] = Convert.ToDouble(val11.Text); total[11] = Convert.ToDouble(val12.Text); total[12] = Convert.ToDouble(val13.Text);
                    total[13] = Convert.ToDouble(val14.Text); total[14] = Convert.ToDouble(val15.Text); total[15] = Convert.ToDouble(val16.Text);
                    count[0] = t_count; count[1] = r_count; count[2] = o_count; count[3] = i;
                    string msg = tl.Load_Trailer_Insert_btn_Click(ch, val, count, type, place, litter, price, date, tot_price, card_id, no_of_time, tollplace, rtoplace, otherreason, tollamount, rtoamount, otheramount, total);
                    if (msg == "Success3")
                    {
                        val11.Text = "0"; val12.Text = "0"; val13.Text = "0"; val14.Text = "0"; val15.Text = "0"; val16.Text = "0";
                        toll_total.Text = "0"; rto_total.Text = "0"; other_total.Text = "0";
                        tripdese.Text = string.Empty; dieselamnt.Text = string.Empty; tripmilg.Text = string.Empty; frtpty.Text = string.Empty; tripexpe.Text = string.Empty; profit.Text = string.Empty; tripnumber.Text = string.Empty; vhlno.Text = string.Empty; loaddate.Text = DateTime.Now.ToShortDateString(); driname.Text = string.Empty; ldna.Text = string.Empty; driver_bal.Text = string.Empty;
                        load.IsChecked = false; trailer.IsChecked = false; tripclose.IsChecked = false;
                        array_clear(); CLEAR();
                        lpg_trip_insert_imgs1.Visibility = System.Windows.Visibility.Hidden;
                        lpg_trip_insert_imgs2.Visibility = System.Windows.Visibility.Visible;
                        time1.Start();
                        chr = "i";
                    }
                }
                else
                {
                    MessageBox.Show("Should Fill All Text Field");
                }
            }                                  
        }

        private void vhlno_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(vhlno.Text.Length<10)
            {
                Trip_Load tl = new Trip_Load();
                string msg = tl.Vehicle_Number_Previewtextinput(vhlno.Text);
                if (msg != "NO")
                {
                    vhlno.Text = string.Empty;
                    e.Handled = true;
                }
            }
            else
            {
                MessageBox.Show("Maximum length is 10");
                vhlno.Text = string.Empty;
                e.Handled = true;
            }
            
        }

        private void vhlno_LostFocus(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab||e.Key==Key.Enter)
            {
                string l = vhlno.Text;
                string typ = null;
                string[] VAL;
                Trip_Load tl = new Trip_Load();
                if( vhlno.Text.Length <= 10)
                {
                    if (tripload.IsChecked == true)
                    {

                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            typ = "L";
                            VAL = tl.Vehicle_Number_Keydown(vhlno.Text, typ);
                            if (VAL[0].ToString() == "")
                            {
                                vhlno.Text = string.Empty;
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Vehicle Number");
                            vhlno.Text = string.Empty;
                            e.Handled = true;
                        }

                    }
                    else if (tripunload.IsChecked == true)
                    {
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            typ = "U";
                            tripnumber.IsEditable = true;
                            VAL = tl.Vehicle_Number_Keydown(vhlno.Text, typ);
                            tripnumber.Text = VAL[0].ToString();
                            driname.Text = VAL[1].ToString();
                            ldna.Text = VAL[2].ToString();
                            loaddate.Text = VAL[3].ToString();
                            tripnumber.IsEnabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Vehicle Number");
                            vhlno.Text = string.Empty;
                            e.Handled = true;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Invalid Vehicle Number");
                    vhlno.Text = string.Empty;
                    e.Handled = true;
                }
               
            }  
        }
        private void trip_expense_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {           
            lpg_trip_expense_panel.Visibility = Visibility.Visible;
        }

        private void driname_LostFocus(object sender, RoutedEventArgs e)
        {
            if(driname.Text.Length==0)
            {
                MessageBox.Show("Enter Driver Id");
            }
            else if(driname.Text.Length > 23)
            {
                MessageBox.Show("Invalid Driver Id");
                driname.Text = string.Empty;
            }

        }

        private void tripnumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tripclose.IsChecked==true)
            {
                if (tripnumber.Text.Length == 0)
                {
                   // MessageBox.Show("Enter Trip Number");
                }
                else if (tripnumber.Text.Length > 23)
                {
                    MessageBox.Show("Invalid Trip Number");
                    tripnumber.Text = string.Empty;
                }
            }
           
        }

        

        private void total_price_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(total_price.Text))
            {
                string S = total_price.Text;
                int LEN = total_price.Text.Length;
                for (int I=0;I<LEN;I++)
                {
                    bool isdigit = char.IsDigit(S[I]);
                    if(!isdigit)
                    {
                        MessageBox.Show("Enter Number Only");
                    }
                }
            }
            
        }

        private void diesel_card_id_KeyDown(object sender, KeyEventArgs e)
        {
            Trip_Load tl = new Trip_Load();
            if(!string.IsNullOrWhiteSpace(diesel_card_id.Text))
            {
              string val=  tl.CardId_Keydown(diesel_card_id.Text);
                if(val!=string.Empty)
                {
                    card_balance.Text = val;
                }
            }
        }

        private void diesel_card_id_GotFocus(object sender, RoutedEventArgs e)
        {
            Trip_Load tl = new Trip_Load();
            diesel_card_id.ItemsSource= tl.Cardid_Gotfocus();
        }

        private void INPUT_TEST(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
