using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Project_Transport 
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : UserControl
    {
        int array_size = 0;
        string[] date=new string[50];
        int[] litter=new int[50];
        double[] price=new double[50];
        double[] amount=new double[50];
        int[] count = new int[50];       
        string[] t_place = new string[50];
        double[] t_amnt = new double[50];
        int[] t_count=new int[50];
        int t_inc = 0;
        string[] r_place=new string[50];
        double[] r_amnt=new double[50];
        int[] r_count=new int[50];
        int r_inc = 0;
        string[] o_place=new string[50];
        double[] o_amoun=new double[50];
        int[] o_count=new int[50];
        int o_inc = 0;
        int no_of_row = 0;
        int t_row = 0;
        int r_row = 0;
        int o_row = 0;
        Load_update lu = new Load_update();
        int s_index;
        public Update()
        {
            InitializeComponent();
        }
        int i = 0;
        void get_trip_number(int k)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd1 = new OdbcCommand("select TripNumber from load_trip_details where TripStatus=" + k + " and paymentid is null", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                tripnum.Items.Clear();
                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    tripnum.Items.Add(dt.Rows[j]["TripNumber"].ToString());
                }

            }
            else
            {
                MessageBox.Show("No Trips in Slected Stage");
            }
        }
        void load()
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd1 = new OdbcCommand("select VehicleNumber,DATE_FORMAT(LoadDate,'%d-%m-%Y')LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight from load_trip_details where TripNumber='" + tripnum.Text + "' ",con. conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vhlno.Text = dt.Rows[0]["VehicleNumber"].ToString();
                loaddate.Text = dt.Rows[0]["LoadDate"].ToString();
                driname.Text = dt.Rows[0]["DriverId"].ToString();
                ldna.Text = dt.Rows[0]["LoadName"].ToString();
                form.Text = dt.Rows[0]["Origin"].ToString();
                too.Text = dt.Rows[0]["Destination"].ToString();
                stkm.Text = dt.Rows[0]["StartingKm"].ToString();
                chln.Text = dt.Rows[0]["ChallonNo"].ToString();
                driadv.Text = dt.Rows[0]["DriverAdvance"].ToString();
                tripadv.Text = dt.Rows[0]["LoadAdvance"].ToString();
                frgt.Text = dt.Rows[0]["TripFrieght"].ToString();
                clname.Text = dt.Rows[0]["ClinerName"].ToString();
                String s = dt.Rows[0]["LoadType"].ToString();
                if (s == "1")
                {
                    time.IsChecked = true;
                }
                else if (s == "0")
                {
                    untime.IsChecked = true;
                }
                wgt.Text = dt.Rows[0]["LoadWeight"].ToString();
            }
            else
            {
                MessageBox.Show("Load Details does not exists");
            }
        }
        void unload()
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd1 = new OdbcCommand("select VehicleNumber,DATE_FORMAT(LoadDate,'%d-%m-%Y')LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight,DATE_FORMAT(UnloadDate,'%d-%m-%Y')UnloadDate,EndingKm,TotalKm,UnloadWeight,Payment from load_trip_details where TripNumber='" + tripnum.Text + "' ",con. conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vhlno.Text = dt.Rows[0]["VehicleNumber"].ToString();
                loaddate.Text = dt.Rows[0]["LoadDate"].ToString();
                driname.Text = dt.Rows[0]["DriverId"].ToString();
                ldna.Text = dt.Rows[0]["LoadName"].ToString();
                form.Text = dt.Rows[0]["Origin"].ToString();
                too.Text = dt.Rows[0]["Destination"].ToString();
                stkm.Text = dt.Rows[0]["StartingKm"].ToString();
                chln.Text = dt.Rows[0]["ChallonNo"].ToString();
                driadv.Text = dt.Rows[0]["DriverAdvance"].ToString();
                tripadv.Text = dt.Rows[0]["LoadAdvance"].ToString();
                frgt.Text = dt.Rows[0]["TripFrieght"].ToString();
                clname.Text = dt.Rows[0]["ClinerName"].ToString();
                String s = dt.Rows[0]["LoadType"].ToString();
                if (s == "1")
                {
                    time.IsChecked = true;
                }
                else if (s == "0")
                {
                    untime.IsChecked = true;
                }
                wgt.Text = dt.Rows[0]["LoadWeight"].ToString();
                undt.Text = dt.Rows[0]["UnloadDate"].ToString();
                endkms.Text = dt.Rows[0]["EndingKm"].ToString();
                totalkm.Text = dt.Rows[0]["TotalKm"].ToString();
                unlodwgt.Text = dt.Rows[0]["UnloadWeight"].ToString();
                paymt.Text = dt.Rows[0]["Payment"].ToString();
            }
            else
            {
                MessageBox.Show("Unload Details does not exists");
            }
        }
        void close()
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd1 = new OdbcCommand("select VehicleNumber,DATE_FORMAT(LoadDate,'%d-%m-%Y')LoadDate,DriverId,LoadName,Origin,Destination,StartingKm,ChallonNo,DriverAdvance,LoadAdvance,TripFrieght,ClinerName,LoadType,LoadWeight,DATE_FORMAT(UnloadDate,'%d-%m-%Y')UnloadDate,EndingKm,TotalKm,UnloadWeight,Payment,TripExpense,TripDiesel,DieselAmount,TripMileage,FrieghtReduction,TripProfit,DriverBalance from load_trip_details where TripNumber='" + tripnum.Text + "' ",con. conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                vhlno.Text = dt.Rows[0]["VehicleNumber"].ToString();
                loaddate.Text = dt.Rows[0]["LoadDate"].ToString();
                driname.Text = dt.Rows[0]["DriverId"].ToString();
                ldna.Text = dt.Rows[0]["LoadName"].ToString();
                form.Text = dt.Rows[0]["Origin"].ToString();
                too.Text = dt.Rows[0]["Destination"].ToString();
                stkm.Text = dt.Rows[0]["StartingKm"].ToString();
                chln.Text = dt.Rows[0]["ChallonNo"].ToString();
                driadv.Text = dt.Rows[0]["DriverAdvance"].ToString();
                tripadv.Text = dt.Rows[0]["LoadAdvance"].ToString();
                frgt.Text = dt.Rows[0]["TripFrieght"].ToString();
                clname.Text = dt.Rows[0]["ClinerName"].ToString();
                String s = dt.Rows[0]["LoadType"].ToString();
                if (s == "1")
                {
                    time.IsChecked = true;
                }
                else if (s == "0")
                {
                    untime.IsChecked = true;
                }
                wgt.Text = dt.Rows[0]["LoadWeight"].ToString();
                undt.Text = dt.Rows[0]["UnloadDate"].ToString();
                endkms.Text = dt.Rows[0]["EndingKm"].ToString();
                totalkm.Text = dt.Rows[0]["TotalKm"].ToString();
                unlodwgt.Text = dt.Rows[0]["UnloadWeight"].ToString();
                paymt.Text = dt.Rows[0]["Payment"].ToString();
                tripexpe.Text = dt.Rows[0]["TripExpense"].ToString();
                tripdese.Text = dt.Rows[0]["TripDiesel"].ToString();
                dieselamnt.Text = dt.Rows[0]["DieselAmount"].ToString();
                tripmilg.Text = dt.Rows[0]["TripMileage"].ToString();
                frtpty.Text = dt.Rows[0]["FrieghtReduction"].ToString();
                profit.Text = dt.Rows[0]["TripProfit"].ToString();
                dribal.Text = dt.Rows[0]["DriverBalance"].ToString();
            }
            else
            {
                MessageBox.Show("Close Details does not exists");
            }
        }
        private void tripload_Checked(object sender, RoutedEventArgs e)
        {
            Thickness mgn = update.Margin;
            mgn.Left = -1000;mgn.Right = 0;mgn.Top = 300;mgn.Bottom = 0;
            update.Margin = mgn;
            Thickness mgns = delete.Margin;
            mgns.Left = -750;mgns.Right = 0;mgns.Top = 300;mgns.Bottom = 0;
            delete.Margin = mgns;
            i = 1;
            get_trip_number(i);
            load_trailer_String s = new load_trailer_String();
            s.venum = "";
            s.tripnum = "";
            s.driid = "";
            s.frm = "";
            s.too = "";
            s.startkm = "";
            s.chaln = "";
            s.ldadv = "";
            s.driadv = "";
            s.tripadv = "";
            s.frght = "";
            s.clname = "";
            s.ldname = "";
            s.wght = "";           
            this.DataContext = s;

        }

        private void tripunload_Checked(object sender, RoutedEventArgs e)
        {
            Thickness mgn = update.Margin;
            mgn.Left = -1000; mgn.Right = 0; mgn.Top = 300; mgn.Bottom = 0;
            update.Margin = mgn;
            Thickness mgns = delete.Margin;
            mgns.Left = -750; mgns.Right = 0; mgns.Top = 300; mgns.Bottom = 0;
            delete.Margin = mgns;
            i = 2;
            get_trip_number(i);
            load_trailer_String s = new load_trailer_String();
            s.venum = "";
            s.tripnum = "";
            s.driid = "";
            s.frm = "";
            s.too = "";
            s.startkm = "";
            s.chaln = "";
            s.ldadv = "";
            s.driadv = "";
            s.tripadv = "";
            s.frght = "";
            s.clname = "";
            s.ldname = "";
            s.wght = "";
            s.endkm = "";
            s.unloadwght = "";
            s.pay = "";
            s.dripay = "";
            s.clipay = "";
            s.commi = "";           
            this.DataContext = s;
        }

        private void tripclose_Checked(object sender, RoutedEventArgs e)
        {
            Thickness mgn = update.Margin;
            mgn.Left = 0; mgn.Right = 0; mgn.Top = 300; mgn.Bottom = 0;
            update.Margin = mgn;
            Thickness mgns = delete.Margin;
            mgns.Left = 200; mgns.Right = 0; mgns.Top = 300; mgns.Bottom = 0;
            delete.Margin = mgns;
            i = 0;
            get_trip_number(i);
            load_trailer_String s = new load_trailer_String();
            s.venum = "";
            s.tripnum = "";
            s.driid = "";
            s.frm = "";
            s.too = "";
            s.startkm = "";
            s.chaln = "";
            s.ldadv = "";
            s.driadv = "";
            s.tripadv = "";
            s.frght = "";
            s.clname = "";
            s.ldname = "";
            s.wght = "";
            s.endkm = "";
            s.unloadwght = "";
            s.pay = "";
            s.dripay = "";
            s.clipay = "";
            s.commi = "";
            s.frghtred = "0";            
            s.Load_Update_Litter = "";
            s.Load_Update_Price = "";
            s.Load_Update_Amount = "";          
            s.Driver_Balance = "";
            s.Load_Update_Lwages = "0";
            s.Load_Update_Uwages = "0";
            s.Load_Update_Phone = "0";
            s.Load_Update_Spare = "0";
            s.Load_Update_Driver = "0";
            s.Load_Update_Cliner = "0";
            s.Load_Update_Tplace = "";
            s.Load_Update_Tamnt = "0";
            s.Load_Update_Rplace = "";
            s.Load_Update_Ramnt = "0";
            s.Load_Update_Oplace = "";
            s.Load_Update_Oamnt = "0";
            this.DataContext = s;

        }

        private void loaddate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void driname_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        public void stkm_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                
                if (!string.IsNullOrWhiteSpace(stkm.Text))
                {
                   
                    lu.startingkm(stkm.Text, vhlno.Text);
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Please Enter Starting Km");
                }
            }
            


        }
        private void endkms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(stkm.Text)&&!string.IsNullOrWhiteSpace(endkms.Text))
                {
                    lu.endingkm(stkm.Text, endkms.Text);
                }
               
               
            }
        }
        private void time_Checked(object sender, RoutedEventArgs e)
        {
            k = 1;
        }

        private void untime_Checked(object sender, RoutedEventArgs e)
        {
            k = 0;
        }

        private void wgt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(wgt.Text))
                {
                    string wg = lu.wght(wgt.Text);
                    if(wg=="")
                    {
                        wgt.Text = "";
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Enter Load Weight");
                    wgt.Text = "";
                    e.Handled = true;
                }

            }

            else if(e.Key==Key.Back)
            {
                unlodwgt.Text = "";
            }
        }

        private void unlodwgt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(unlodwgt.Text))
                {
                    string s = unlodwgt.Text;
                    if (Regex.IsMatch(s, "^[0-9]{2}[.]{1}[0-9]{2}") || Regex.IsMatch(s, "^[0-9]{1}[.]{1}[0-9]{2}") || Regex.IsMatch(s, "^[0-9]{2}[.]{1}[0-9]{1}") || Regex.IsMatch(s, "^[0-9]{1}[.]{1}[0-9]{1}") || Regex.IsMatch(s, "^[0-9]{1}") || Regex.IsMatch(s, "^[0-9]{2}"))
                    {
                       string uw= lu.unloadwght(unlodwgt.Text,wgt.Text);
                        if(uw=="")
                        {
                            unlodwgt.Text = "";
                            e.Handled = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Patten does not match");
                        unlodwgt.Text = "";
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Enter UnLoad Weight");
                    unlodwgt.Text = "";
                    e.Handled = true;
                }

            }



        }

        private void pymt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            payment.Visibility = Visibility.Visible;
            tripexpe.Text = "";
            profit.Text = "";
            dribal.Text = "";
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
            if (string.IsNullOrWhiteSpace(clinerpymt.Text))
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
            if (string.IsNullOrWhiteSpace(commis.Text))
            {
                commis.Text = "0";
            }
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            paymt.Text = (Convert.ToInt32(dripaymt.Text) + Convert.ToInt32(clinerpymt.Text) + Convert.ToInt32(commis.Text)).ToString();
            payment.Visibility = Visibility.Hidden; commis.Text = "0"; clinerpymt.Text = "0"; dripaymt.Text = "0";
        }

        private void tripexp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            trip_expense_update_panel.Visibility = Visibility.Visible;
            tripexpe.Text = "";
            profit.Text = "";
            dribal.Text = "";
            Connection con = new Connection();
            con.open_connection();
            try
            {
                OdbcCommand cmd = new OdbcCommand("select load_wages,unload_wages,phone,spares,driver,cliner from lpg_trip_expense where trip_number='" + tripnum.Text + "'", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {                   
                    val1.Text = dt.Rows[0]["load_wages"].ToString();
                    val2.Text = dt.Rows[0]["unload_wages"].ToString();
                    val3.Text = dt.Rows[0]["phone"].ToString();
                    val4.Text = dt.Rows[0]["spares"].ToString();
                    val5.Text = dt.Rows[0]["driver"].ToString();
                    val6.Text = dt.Rows[0]["cliner"].ToString();

                }
                else
                {
                    MessageBox.Show("Trip Expense Records not Found");
                }
                try
                {
                    OdbcCommand cmd1 = new OdbcCommand("select place,amount,count from toll_spend where trip_number='" + tripnum.Text + "'", con.conn);
                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                       
                       
                        double val = 0;
                        toll_spend.ItemsSource = dt1.DefaultView;
                        toll_spend.Columns[0].Width = 100;
                        toll_spend.Columns[1].Width = 70;
                        toll_spend.Columns[2].Width = 70;
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            val += Convert.ToDouble(dt1.Rows[i]["amount"]);
                            t_place[i] = dt1.Rows[i]["place"].ToString();
                            t_amnt[i] = Convert.ToDouble( dt1.Rows[i]["amount"]);
                            t_count[i] = Convert.ToInt32( dt1.Rows[i]["count"]);
                        }
                        toll_totals.Text = val.ToString();
                       
                        t_row = dt1.Rows.Count;
                    }
                    else
                    {
                        // MessageBox.Show("Toll details records not found");
                        toll_spend.ItemsSource = dt1.DefaultView;
                    }
                    try
                    {
                        OdbcCommand cmd2 = new OdbcCommand("select place,amount,count from rto_pc where trip_number='" + tripnum.Text + "'", con.conn);
                        OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                           
                            double val = 0;
                            rto_pc_spend.ItemsSource = dt2.DefaultView;

                            rto_pc_spend.Columns[0].Width = 100;
                            rto_pc_spend.Columns[1].Width = 70;
                            rto_pc_spend.Columns[2].Width = 70;
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                val += Convert.ToDouble(dt2.Rows[i]["amount"]);
                                r_place[i] = dt2.Rows[i]["place"].ToString();
                                r_amnt[i] = Convert.ToDouble(dt2.Rows[i]["amount"]);
                                r_count[i] = Convert.ToInt32(dt2.Rows[i]["count"]);
                            }
                            rto_totals.Text = val.ToString();
                            
                            r_row = dt2.Rows.Count;
                        }
                        else
                        {
                            //MessageBox.Show("Rto and Pc records not found");
                            rto_pc_spend.ItemsSource = dt2.DefaultView;
                        }
                        try
                        {
                            OdbcCommand cmd3 = new OdbcCommand("select reason,amount,count from other_spend where trip_number='" + tripnum.Text + "'", con.conn);
                            OdbcDataAdapter da3 = new OdbcDataAdapter(cmd3);
                            DataTable dt3 = new DataTable();
                            da3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                              
                               
                                double val = 0;
                                other_spend.ItemsSource = dt3.DefaultView;
                                other_spend.Columns[0].Width = 100;
                                other_spend.Columns[1].Width = 70;
                                other_spend.Columns[2].Width = 70;
                                for (int i = 0; i < dt3.Rows.Count; i++)
                                {
                                    val += Convert.ToDouble(dt3.Rows[i]["amount"]);
                                    o_place[i] = dt3.Rows[i]["reason"].ToString();
                                    o_amoun[i] = Convert.ToDouble(dt3.Rows[i]["amount"]);
                                    o_count[i] = Convert.ToInt32(dt3.Rows[i]["count"]);
                                }
                                other_totals.Text = val.ToString();
                              
                                o_row = dt3.Rows.Count;
                                //all_panel_hide();
                                trip_expense_update_panel.Visibility = System.Windows.Visibility.Visible;
                            }
                            else
                            {
                                //MessageBox.Show("Others spend records not found");
                                other_spend.ItemsSource = dt3.DefaultView;
                            }
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show("Error :" + ex);
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("Error :" + ex);
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }
        private void tripdes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lpg_diesel_update_panel.Visibility = Visibility.Visible;
            tripexpe.Text = "";
            profit.Text = "";
            dribal.Text = "";
            dieselamnt.Text = "";
            tripmilg.Text = "";
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd1 = new OdbcCommand("SELECT DATE_FORMAT(Fill_date,'%d-%m-%Y')Fill_date,noof_times,total_cost,litters,price_per,withdraw from diesel_balance_sheet where trip_number='" + tripnum.Text + "' ",con. conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                no_of_row = dt.Rows.Count;
                balance_sheet_view.ItemsSource = dt.DefaultView;
                balance_sheet_view.Columns[0].Width = 70;
                balance_sheet_view.Columns[1].Width = 70;
                balance_sheet_view.Columns[2].Width = 70;
                balance_sheet_view.Columns[3].Width = 70;
                balance_sheet_view.Columns[4].Width = 70;
                balance_sheet_view.Columns[5].Width = 70;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    amount[i] =Convert.ToDouble( dt.Rows[i]["total_cost"]);
                    litter[i] = Convert.ToInt32(dt.Rows[i]["litters"]);
                    price[i] = Convert.ToDouble(dt.Rows[i]["price_per"]);
                    count[i] = Convert.ToInt32(dt.Rows[i]["noof_times"]);
                    date[i] = dt.Rows[i]["Fill_date"].ToString();
                }
            }
        }

        private void dieselamt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }           
        private void Update_Balance_Sheet_Close_Click(object sender, RoutedEventArgs e)
        {
            lpg_diesel_update_panel.Visibility = Visibility.Hidden;
        }
        string type;
        int no;
        private void select_grid_row_data(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr = (DataRowView)balance_sheet_view.SelectedItem;
            if (dr["noof_times"].Equals(""))
            {
                MessageBox.Show("no of times column is null, should fill first");
            }
            else
            {
                t_number.Content = tripnum.Text;
                f_date.Text = (dr["fill_date"]).ToString();
                d_litter.Text = (dr["litters"]).ToString();
                d_price.Text = (dr["price_per"]).ToString();
                d_amount.Text = (dr["total_cost"]).ToString(); 
                no = Convert.ToInt32(dr["noof_times"]);
                type = (dr["withdraw"]).ToString();               
            }
        }

        private void other_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(other_reasons.Text) && !string.IsNullOrWhiteSpace(other_wages.Text))
                {
                    if (o_count.Count() > 0)
                    {
                        
                            if (o_count.Contains(array_size))
                            {
                                o_amoun[s_index] = Convert.ToDouble(other_wages.Text);
                                o_place[s_index] = other_reasons.Text;
                                o_count[s_index] = array_size;
                                double d1=0, d2=0, d3=0;
                                d1 =Convert.ToDouble( o_amoun[0]);
                                d2 = Convert.ToDouble(o_amoun[1]);
                                d3 = Convert.ToDouble(o_amoun[2]);
                            }
                        
                        o_inc++;
                        other_totals.Text = o_amoun.Sum().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Edit a Row One Time Only");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Empty Textbox");
                }
            }
        }
        private void rto_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(rto_places.Text) && !string.IsNullOrWhiteSpace(rto_amounts.Text))
                {
                    if (r_count.Count() > 0)
                    {
                       
                            if (r_count.Contains(array_size))
                            {
                                r_amnt[s_index] = Convert.ToDouble(rto_amounts.Text);
                                r_place[s_index] = rto_places.Text;
                                r_count[s_index] = array_size;

                            }
                        

                        r_inc++;
                        rto_totals.Text = r_amnt.Sum().ToString();

                    }
                    else
                    {
                        MessageBox.Show("Edit a Row One Time Only");
                    }
                        }
             
                else
                {
                    MessageBox.Show("Please Fill Empty Textbox");
                }
            }
        }

        private void toll_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(toll_wages.Text) && !string.IsNullOrWhiteSpace(toll_places.Text))
                {
                    if (t_count.Count()>0)
                    {
                       
                            if(t_count.Contains(array_size))
                            {
                                t_amnt[s_index] = Convert.ToDouble(toll_wages.Text);
                                t_place[s_index] = toll_places.Text;
                                t_count[s_index] = array_size;
                            }
                        
                       
                        t_inc++;

                        toll_totals.Text = t_amnt.Sum().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Edit a Row One Time Only");
                    }

                }
                else
                {
                    MessageBox.Show("Please Fill Empty TextBox");
                }
            }
        }
        private void trip_expens_update_back_click(object sender, RoutedEventArgs e)
        {
            trip_expense_update_panel.Visibility = Visibility.Hidden;
        }
        string[] e = new string[9];
        string[] expenseupdate()
        {
            if (!string.IsNullOrWhiteSpace(val1.Text) && !string.IsNullOrWhiteSpace(val2.Text) && !string.IsNullOrWhiteSpace(val3.Text) && !string.IsNullOrWhiteSpace(val4.Text) && !string.IsNullOrWhiteSpace(val5.Text)&& !string.IsNullOrWhiteSpace(val6.Text) && !string.IsNullOrWhiteSpace(toll_totals.Text) && !string.IsNullOrWhiteSpace(rto_totals.Text) && !string.IsNullOrWhiteSpace(other_totals.Text))
            {
                e[0] = val1.Text;
                e[1] = val2.Text;
                e[2] = val3.Text;
                e[3] = val4.Text;
                e[4] = val5.Text;
                e[5] = val6.Text;
                e[6] = toll_totals.Text;
                e[7] = rto_totals.Text;
                e[8] = other_totals.Text;
            }
            else
            {
                MessageBox.Show("Please fill empty text fields");
            }

            return e;
        }

        private void trip_expense_update_done_click(object sender, RoutedEventArgs e)
        {
           // trip_update_panel.Visibility = System.Windows.Visibility.Visible;
            trip_expense_update_panel.Visibility = System.Windows.Visibility.Hidden;
            Connection con = new Connection();
            con.open_connection();
            double d1 = Convert.ToDouble(toll_totals.Text);
            double d2 = Convert.ToDouble(rto_totals.Text);
            double d3 = Convert.ToDouble(other_totals.Text);
            double A1 = 0; /*double C1 = 0;*/
            if (!string.IsNullOrWhiteSpace(toll_totals.Text) && !string.IsNullOrWhiteSpace(rto_totals.Text) && !string.IsNullOrWhiteSpace(other_totals.Text) && !string.IsNullOrWhiteSpace(val1.Text) && !string.IsNullOrWhiteSpace(val2.Text) && !string.IsNullOrWhiteSpace(val3.Text) && !string.IsNullOrWhiteSpace(val4.Text) && !string.IsNullOrWhiteSpace(val5.Text) && !string.IsNullOrWhiteSpace(val6.Text))
            {
              double d=t_amnt[0];
               
                try
                {
                    double val_total = Convert.ToDouble(val1.Text) + Convert.ToDouble(val2.Text) + Convert.ToDouble(val3.Text) + Convert.ToDouble(val4.Text) + Convert.ToDouble(val5.Text) + Convert.ToDouble(val6.Text);
                    tripexpe.Text = (val_total + d1 + d2 + d3).ToString();

                    OdbcCommand cmd1 = new OdbcCommand("select sum(total_cost) as amount from diesel_balance_sheet where trip_number='" + tripnum.Text + "' and withdraw='ADVANCE'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string val = dt.Rows[0]["amount"].ToString();
                        if (val == "")
                        {
                            A1 = 0;
                        }
                        else
                        {
                            A1 = Convert.ToDouble(dt.Rows[0]["amount"]);
                        }
                    }
                    //else
                    //{
                    //    //MessageBox.Show("Doesnot Get Withdraw Type");
                    //}
                    ////OdbcCommand cmd2 = new OdbcCommand("select sum(total_cost) as amount from diesel_balance_sheet where trip_number='" + update_trip_numbers.Text + "' and withdraw='CARD'", con.conn);
                    ////OdbcDataAdapter da2 = new OdbcDataAdapter(cmd2);
                    ////DataTable dt2 = new DataTable();
                    ////da2.Fill(dt2);
                    ////if (dt2.Rows.Count > 0)
                    ////{

                    ////    string val = dt.Rows[0]["amount"].ToString();
                    ////    if (val == "")
                    ////    {
                    ////        C1 = 0;
                    ////    }
                    ////    else
                    ////    {
                    ////        C1 = Convert.ToDouble(dt.Rows[0]["amount"]);
                    ////    }
                    ////}
                    ////else
                    ////{
                    ////    //MessageBox.Show("Doesnot Get Withdraw Type");
                    ////}
                    //OdbcCommand cmd = new OdbcCommand("update lpg_trip_expense set load_wages=" + Convert.ToDouble(val1.Text) + ",unload_wages=" + Convert.ToDouble(val2.Text) + ",phone=" + Convert.ToDouble(val3.Text) + ",spares=" + Convert.ToDouble(val4.Text) + ",driver=" + Convert.ToDouble(val5.Text) + ",cliner=" + Convert.ToDouble(val6.Text) + ", toll_spend=" + d1 + ",rto_pc_gas=" + d2 + ",others=" + d3 + " where trip_number='" + tripnum.Text + "'", con.conn);
                    //cmd.ExecuteNonQuery();
                    //con.close_connection();
                    profit.Text = (Convert.ToDouble(frgt.Text) - Convert.ToDouble(tripexpe.Text)- Convert.ToDouble(frtpty.Text) - Convert.ToDouble(dieselamnt.Text)).ToString();
                    dribal.Text = (Convert.ToDouble(tripadv.Text) - Convert.ToDouble(tripexpe.Text) - A1).ToString();

                    //toll_wages.Text = "0"; rto_amounts.Text = "0"; other_wages.Text = "0";
                }
                catch
                {
                    MessageBox.Show("Conversion Error");
                }

            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields");

            }

        }

        private void vhlno_LostFocus(object sender, RoutedEventArgs e)
        {

        }
      
        
        private void balance_sheet_update(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(d_amount.Text) && !string.IsNullOrWhiteSpace(d_litter.Text) & !string.IsNullOrWhiteSpace(d_price.Text) & !string.IsNullOrWhiteSpace(f_date.Text))
            {
               
                   
                       for (int i = 0; i < no_of_row; i++)
                       {
                    if (count[i]==no)
                    {
                        if (!string.IsNullOrWhiteSpace(d_litter.Text) & !string.IsNullOrWhiteSpace(d_price.Text) & !string.IsNullOrWhiteSpace(f_date.Text))
                        {
                            d_amount.Text = (Convert.ToDouble(d_litter.Text) * Convert.ToDouble(d_price.Text)).ToString();
                            litter[i] = Convert.ToInt32(d_litter.Text);
                            price[i] = Convert.ToDouble(d_price.Text);
                            amount[i] = Convert.ToDouble(d_amount.Text);
                            count[i] = no;
                            date[i] = Convert.ToDateTime(f_date.Text).ToString("yyyy/MM/dd");
                                              
                        }
                    }
                       }                                
            }
            else if (string.IsNullOrWhiteSpace(d_litter.Text) && !string.IsNullOrWhiteSpace(d_amount.Text) & !string.IsNullOrWhiteSpace(d_price.Text) & !string.IsNullOrWhiteSpace(f_date.Text))
            {
                for (int i = 0; i < count.Count(); i++)
                {
                    if (count.Contains(no))
                    {
                        if (!string.IsNullOrWhiteSpace(d_amount.Text) & !string.IsNullOrWhiteSpace(d_price.Text) & !string.IsNullOrWhiteSpace(f_date.Text))
                        {
                            d_litter.Text = (Convert.ToDouble(d_amount.Text) / Convert.ToDouble(d_price.Text)).ToString();
                            litter[i] = Convert.ToInt32(Math.Round(Convert.ToDouble(d_litter.Text)));
                            price[i] = Convert.ToDouble(d_price.Text);
                            amount[i] = Convert.ToDouble(d_amount.Text);
                            count[i] = no;
                            date[i] = Convert.ToDateTime(f_date.Text).ToString("yyyy/MM/dd");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Edit a Row One Time Only");
                    }
                }                                  
            }
            else if (string.IsNullOrWhiteSpace(d_price.Text) && !string.IsNullOrWhiteSpace(d_amount.Text) & !string.IsNullOrWhiteSpace(d_litter.Text) & !string.IsNullOrWhiteSpace(f_date.Text))
            {
               
                  
                    for (int i = 0; i < count.Count(); i++)
                    {
                    if (count.Contains(no))
                    {
                        if (!string.IsNullOrWhiteSpace(d_amount.Text) & !string.IsNullOrWhiteSpace(d_litter.Text) & !string.IsNullOrWhiteSpace(f_date.Text))
                        {
                            d_price.Text = (Convert.ToDouble(d_amount.Text) / Convert.ToDouble(d_litter.Text)).ToString();
                            litter[i] = Convert.ToInt32(d_litter.Text);
                            price[i] = Convert.ToDouble(d_price.Text);
                            amount[i] = Convert.ToDouble(d_amount.Text);
                            count[i] = no;
                            date[i] = Convert.ToDateTime(f_date.Text).ToString("yyyy/MM/dd");                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Edit a Row One Time Only");
                    }
                }
            }
            else
            {
                MessageBox.Show("Give any Two Values And Select Date");
            }
            tripdese.Text = litter.Sum().ToString();
            dieselamnt.Text = amount.Sum().ToString();
            tripmilg.Text =Math.Round( (Convert.ToDouble(totalkm.Text) / litter.Sum()),2).ToString();
        }
        
        private void toll_wages_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dr = (DataRowView)toll_spend.SelectedItem;
                s_index = toll_spend.SelectedIndex;
                array_size = Convert.ToInt32(dr["count"]);
                toll_places.Text = (dr["place"]).ToString();
                toll_wages.Text = (dr["amount"]).ToString();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }

        }
       
        private void rto_pc_click(object sender, MouseButtonEventArgs e)
        {

            try
            {
                DataRowView dr = (DataRowView)rto_pc_spend.SelectedItem;
                s_index = rto_pc_spend.SelectedIndex;
                array_size = Convert.ToInt32(dr["count"]);
                rto_places.Text = (dr["place"]).ToString();
                rto_amounts.Text = (dr["amount"]).ToString();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }
       
        private void other_wages_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dr = (DataRowView)other_spend.SelectedItem;
                s_index = other_spend.SelectedIndex;
                array_size = Convert.ToInt32(dr["count"]);
                other_reasons.Text = (dr["reason"]).ToString();
                other_wages.Text = (dr["amount"]).ToString();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

        private void tripnum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (tripload.IsChecked == true && (!string.IsNullOrWhiteSpace(tripnum.Text)))
                {

                    loadpanel.Visibility = Visibility.Visible;
                    unloadpanel.Visibility = Visibility.Hidden;
                    closepanel.Visibility = Visibility.Hidden;


                    load();
                }
                else if (tripunload.IsChecked == true && (!string.IsNullOrWhiteSpace(tripnum.Text)))
                {

                    loadpanel.Visibility = Visibility.Visible;
                    unloadpanel.Visibility = Visibility.Visible;
                    closepanel.Visibility = Visibility.Hidden;
                    unload();
                }
                else if (tripclose.IsChecked == true && (!string.IsNullOrWhiteSpace(tripnum.Text)))
                {

                    loadpanel.Visibility = Visibility.Visible;
                    unloadpanel.Visibility = Visibility.Visible;
                    closepanel.Visibility = Visibility.Visible;
                    close();
                }
            }

        }
      void  loadclear()
        {
            tripnum.Text= "";
            vhlno.Text = "";
            driname.Text = "";
            ldna.Text = "";
            loaddate.Text = DateTime.Now.ToShortDateString();
            form.Text = "";
            too.Text = "";
            stkm.Text = "";
            chln.Text = "";
            driadv.Text = "";
            tripadv.Text = "";
            frgt.Text = "";
            clname.Text = "";
              k = 2;
            wgt.Text = "";


        }
        void unloadclear()
        {
            
            endkms.Text = "";
            totalkm.Text = "";
            undt.Text = "";
            unlodwgt.Text = DateTime.Now.ToShortDateString();
            paymt.Text = "";


        }
        void closeclear()
        {
            tripexpe.Text = "";
            tripdese.Text = "";
            dieselamnt.Text = "";
            tripmilg.Text = "";
            frtpty.Text = "";
            profit.Text = "";
            dribal.Text = "";
            other_reasons.Text = "";
            other_wages.Text = "0";
            other_totals.Text = "0";
            rto_places.Text = "";
            rto_amounts.Text = "0";
            rto_totals.Text = "0";
            toll_places.Text = "";
            toll_wages.Text = "0";
            toll_totals.Text = "0";
            val1.Text = "0";val2.Text = "0";val3.Text = "0";val4.Text = "0";val5.Text = "0";val6.Text = "0";
        }

        string[] s = new string[24];
        int k = 2;
        string[] updateload()
        {
            if (!string.IsNullOrWhiteSpace(driname.Text) && !string.IsNullOrWhiteSpace(ldna.Text) && !string.IsNullOrWhiteSpace(form.Text) && !string.IsNullOrWhiteSpace(too.Text) && !string.IsNullOrWhiteSpace(stkm.Text) && !string.IsNullOrWhiteSpace(chln.Text) && !string.IsNullOrWhiteSpace(driadv.Text) && !string.IsNullOrWhiteSpace(tripadv.Text) && !string.IsNullOrWhiteSpace(frgt.Text) && !string.IsNullOrWhiteSpace(clname.Text) && k != 2 && !string.IsNullOrWhiteSpace(wgt.Text))
            {

                s[0] = driname.Text;
                s[1] = ldna.Text;
                s[2] = form.Text;
                s[3] = too.Text;
                s[4] = stkm.Text;
                s[5] = chln.Text;
                s[6] = driadv.Text;
                s[7] = tripadv.Text;
                s[8] = frgt.Text;
                s[9] = clname.Text;
                s[10] = k.ToString();
                s[11] = wgt.Text;
            }
            else
            {
                MessageBox.Show("Please fill empty text fields");
            }

            return s;
        }
        string[] updateunload()
        {
            if (!string.IsNullOrWhiteSpace(driname.Text) && !string.IsNullOrWhiteSpace(ldna.Text) && !string.IsNullOrWhiteSpace(form.Text) && !string.IsNullOrWhiteSpace(too.Text) && !string.IsNullOrWhiteSpace(stkm.Text) && !string.IsNullOrWhiteSpace(chln.Text) && !string.IsNullOrWhiteSpace(driadv.Text) && !string.IsNullOrWhiteSpace(tripadv.Text) && !string.IsNullOrWhiteSpace(frgt.Text) && !string.IsNullOrWhiteSpace(clname.Text) && k != 2 && !string.IsNullOrWhiteSpace(wgt.Text) && !string.IsNullOrWhiteSpace(endkms.Text) && !string.IsNullOrWhiteSpace(totalkm.Text) && !string.IsNullOrWhiteSpace(unlodwgt.Text) && !string.IsNullOrWhiteSpace(paymt.Text))
            {
                s[0] = driname.Text;
                s[1] = ldna.Text;
                s[2] = form.Text;
                s[3] = too.Text;
                s[4] = stkm.Text;
                s[5] = chln.Text;
                s[6] = driadv.Text;
                s[7] = tripadv.Text;
                s[8] = frgt.Text;
                s[9] = clname.Text;
                s[10] = k.ToString();
                s[11] = wgt.Text;
                s[13] = endkms.Text;
                s[14] = totalkm.Text;
                s[15] = unlodwgt.Text;
                s[16] = paymt.Text;
            }
            else
            {
                MessageBox.Show("Please fill empty text fields");
            }
            return s;
        }
        string[] updateclose()
        {
            if (!string.IsNullOrWhiteSpace(driname.Text) && !string.IsNullOrWhiteSpace(ldna.Text) && !string.IsNullOrWhiteSpace(form.Text) && !string.IsNullOrWhiteSpace(too.Text) && !string.IsNullOrWhiteSpace(stkm.Text) && !string.IsNullOrWhiteSpace(chln.Text) && !string.IsNullOrWhiteSpace(driadv.Text) && !string.IsNullOrWhiteSpace(tripadv.Text) && !string.IsNullOrWhiteSpace(frgt.Text) && !string.IsNullOrWhiteSpace(clname.Text) && k != 2 && !string.IsNullOrWhiteSpace(wgt.Text) && !string.IsNullOrWhiteSpace(endkms.Text) && !string.IsNullOrWhiteSpace(totalkm.Text) && !string.IsNullOrWhiteSpace(unlodwgt.Text) && !string.IsNullOrWhiteSpace(paymt.Text) && !string.IsNullOrWhiteSpace(tripexpe.Text) && !string.IsNullOrWhiteSpace(tripdese.Text) && !string.IsNullOrWhiteSpace(dieselamnt.Text) && !string.IsNullOrWhiteSpace(tripmilg.Text) && !string.IsNullOrWhiteSpace(frtpty.Text) && !string.IsNullOrWhiteSpace(profit.Text) && !string.IsNullOrWhiteSpace(dribal.Text))
            {
                s[0] = driname.Text;
                s[1] = ldna.Text;
                s[2] = form.Text;
                s[3] = too.Text;
                s[4] = stkm.Text;
                s[5] = chln.Text;
                s[6] = driadv.Text;
                s[7] = tripadv.Text;
                s[8] = frgt.Text;
                s[9] = clname.Text;
                s[10] = k.ToString();
                s[11] = wgt.Text;
                s[13] = endkms.Text;
                s[14] = totalkm.Text;
                s[15] = unlodwgt.Text;
                s[16] = paymt.Text;
                s[17] = tripexpe.Text;
                s[18] = tripdese.Text;
                s[19] = dieselamnt.Text;
                s[20] = tripmilg.Text;
                s[21] = frtpty.Text;
                s[22] = profit.Text;
                s[23] = dribal.Text;
            }
            else
            {
                MessageBox.Show("Please fill empty text fields");
            }
            return s;
        }
        public void update_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER")
            {
                try
                {
                    if(!string.IsNullOrWhiteSpace( stkm.Text)&& !string.IsNullOrWhiteSpace(driadv.Text) && !string.IsNullOrWhiteSpace(frgt.Text) && !string.IsNullOrWhiteSpace(wgt.Text) && !string.IsNullOrWhiteSpace(stkm.Text) && !string.IsNullOrWhiteSpace(endkms.Text) && !string.IsNullOrWhiteSpace(totalkm.Text) && !string.IsNullOrWhiteSpace(unlodwgt.Text) && !string.IsNullOrWhiteSpace(dieselamnt.Text) && !string.IsNullOrWhiteSpace(tripmilg.Text) && !string.IsNullOrWhiteSpace(tripexpe.Text) && !string.IsNullOrWhiteSpace(profit.Text) && !string.IsNullOrWhiteSpace(dribal.Text))
                    {
                        if (Convert.ToInt32(stkm.Text) < Convert.ToInt32(endkms.Text) && Convert.ToDouble(unlodwgt.Text) <= Convert.ToDouble(wgt.Text) && Convert.ToDouble(wgt.Text) < 25 && Convert.ToDouble(unlodwgt.Text) < 25)
                        {

                            MessageBoxResult mr = MessageBox.Show("DO you want to update", "Conformation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                            if (mr == MessageBoxResult.OK)
                            {

                                if (tripload.IsChecked == true)
                                {
                                    string[] l = updateload();
                                    string ln = lu.loadupdate(l, tripnum.Text);
                                    if (ln == "Y")
                                    {
                                        loadclear();
                                    }

                                }
                                else if (tripunload.IsChecked == true)
                                {
                                    string[] u = updateunload();
                                    string un = lu.unloadupdate(u, tripnum.Text);
                                    if (un == "Y")
                                    {
                                        loadclear();
                                        unload();
                                    }

                                }
                                else if (tripclose.IsChecked == true)
                                {
                                    string ds = lu.dieselupdate(litter, price, amount, count, date, tripnum.Text, no_of_row);
                                    string[] ex = expenseupdate();
                                    string exs = lu.expenseupdate(ex, tripnum.Text);
                                    string ts = lu.tollwagesupdate(t_place, t_count, t_amnt, tripnum.Text, t_row);
                                    string rs = lu.rtoupdate(r_place, r_count, r_amnt, tripnum.Text, r_row);
                                    string os = lu.otherwagesupdate(o_place, o_count, o_amoun, tripnum.Text, o_row);
                                    string[] c = updateclose();
                                    string cl = lu.closeupdate(c, tripnum.Text);

                                    if (cl == "Y" && ds == "Y" && exs == "Y" && ts == "Y" && rs == "Y" && os == "Y")
                                    {
                                        loadclear();
                                        unloadclear();
                                        closeclear();
                                    }

                                }
                            }
                            else if (mr == MessageBoxResult.Cancel)
                            {

                            }
                        }

                        else
                        {
                            MessageBox.Show("Please check entered Kms and Weight");
                            unlodwgt.Text = "";
                            wgt.Text = "";
                            stkm.Text = "";
                            endkms.Text = "";
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Should Fill All Text Field");
                    }
                    

                }
                catch
                {
                    MessageBox.Show("Please check Kms and Weight");
                }

            }
            else
            {
                MessageBox.Show("Access Denied");
            }

        }
 
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tripnum.Text))
            {
                string s = lu.delete(tripnum.Text);
                if (s == "y")
                {
                    loadclear();
                    unloadclear();
                    closeclear();
                }
            }
            else
            {
                MessageBox.Show("Please Select Trip Number");
            }
           
        }

        private void stkm_TextChanged(object sender, TextChangedEventArgs e)
        {
            string res = startkm(stkm.Text);
            if (res != "")
            {
                stkm.Text = "";
            }

         }
      public string startkm(string s)
        {
            string k = "";
            if(s.Contains("-") && s.Length>1 )
            {
                try
                {
                    int val = Convert.ToInt32(s.Substring(1, s.Length - 1));
                    if(val>1)
                    {
                        MessageBox.Show("Allow -1 or 6 Numbers only");
                        s = "r";
                    }
                }
                catch
                {
                    MessageBox.Show("Format is incorrect");
                    s = "r";
                }
            }
            return k;
        }

        

        private void tripadv_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.Key == Key.Back)
            {
                tripexpe.Text = "";
                profit.Text = "";
                frtpty.Text = "";
            }
        }

       

        private void Reduction_Unchecked(object sender, RoutedEventArgs e)
        {
            frtpty.IsEnabled = false;
        }

        private void Reduction_Checked(object sender, RoutedEventArgs e)
        {
            frtpty.IsEnabled = true;
            tripexpe.Text = "";
            profit.Text = "";
            dribal.Text = "";
        }

        private void stkm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Back)
            {
                stkm.Text = "";
                endkms.Text = "";
                totalkm.Text = "";
            }
        }

        private void driadv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                tripexpe.Text = "";
                profit.Text = "";
                dribal.Text = "";

            }
        }

        

        private void frgt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                tripexpe.Text = "";
                profit.Text = "";
                dribal.Text = "";
            }
        }

        private void wgt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Back)
            {
                wgt.Text = "";
                unlodwgt.Text = "";
            }
        }

       
    }
    }

