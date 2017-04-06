using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Project_Transport
{
   public partial class Trip_Load: Load_Trailer
    {
       
        
        double bal = 0;
        double balance = 0;
        List<string> vehiclenumber = new List<string>();
        string msg = "NO";
        public Trip_Load()
        {
            
        }
       
       
        public List<string> Trip_Load_Checked(string S)
        {
           
            Connection CON = new Connection();
            CON.open_connection();
           
            if (S == "L")
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("select vehicle_number from vechicle_details where corporation='LOD'", CON.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    vehiclenumber.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string s = dt.Rows[i]["Vehicle_Number"].ToString();
                            vehiclenumber.Add(s); 
                            
                        }
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }

            }
            else if (S == "T")
            {
                try
                {
                    OdbcCommand cmd1 = new OdbcCommand("select vehicle_number from vechicle_details where corporation='TLR'", CON.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    vehiclenumber.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string s = dt.Rows[i]["Vehicle_Number"].ToString();
                            vehiclenumber.Add(s);
                            
                        }
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }


            }

            else
            {
                MessageBox.Show("Select Load or Trailer");
            }
            return vehiclenumber;
        }
        public List<string> Trip_Unload_Checked(string S)
        {
            
            Connection CON = new Connection();
            CON.open_connection();
            if (S=="L")
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("select vehiclenumber from load_trip_details where tripstatus=1 && vehicletype='L' ", CON.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    vehiclenumber.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string s = dt.Rows[i]["VehicleNumber"].ToString();
                            vehiclenumber.Add(s);
                            
                        }
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }

            }
            else if (S == "T")
            {
                try
                {
                    OdbcCommand cmd1 = new OdbcCommand("select vehiclenumber from load_trip_details where tripstatus=1 && vehicletype='T' ", CON.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    vehiclenumber.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string s = dt.Rows[i]["VehicleNumber"].ToString();
                            vehiclenumber.Add(s);
                           
                            
                        }
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }


            }

            else
            {
                MessageBox.Show("Select Load or Trailer");
            }
            CON.close_connection();
            return vehiclenumber;
        }
        public List<string> Trip_Closed_Checked(string S)
        {
           
            Connection CON = new Connection();
            CON.open_connection();
            if (S == "L")
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("select tripnumber from load_trip_details where tripstatus=2 && vehicletype='L' ", CON.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    vehiclenumber.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string s = dt.Rows[i]["tripnumber"].ToString();
                            vehiclenumber.Add(s);
                           
                        }
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }

            }
            else if (S == "T")
            {
                try
                {
                    OdbcCommand cmd1 = new OdbcCommand("select tripnumber from load_trip_details where tripstatus=2 && vehicletype='T' ", CON.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    vehiclenumber.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string s = dt.Rows[i]["tripnumber"].ToString();
                            vehiclenumber.Add(s);
                            
                        }
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                }


            }

            else
            {
                MessageBox.Show("Select Load or Trailer");
            }
            CON.close_connection();
            return vehiclenumber;
        }
        public string Load_Date_KeyDown(string s1,string s2)
        {           
            string d, m, y;           
            d = Convert.ToDateTime(s2).ToString("dd");
            m = Convert.ToDateTime(s2).ToString("MM");
            y = Convert.ToDateTime(s2).ToString("yy");
            string trpnum = d + m + y + s1;
            return trpnum;
        }
        public List<string> Driver_Name_GotFocus()
        {
            try
            {            
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select driver_id from driver_details where (licence_type like '%TRAILER' OR licence_type like '%LINE') AND  bool=0", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                vehiclenumber.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string s = dt.Rows[i]["driver_id"].ToString();
                        vehiclenumber.Add(s);
                    }
                }
                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("" + ex);
            }
            return vehiclenumber;
        }
        public string Get_Driver_Id(string s1)
        {
            string s = null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd = new OdbcCommand("select driver_id from driver_details where vehicle_number='"+s1+"' AND  bool=0", con.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);                
                if (dt.Rows.Count > 0)
                {                    
                         s = dt.Rows[0]["driver_id"].ToString();                                          
                }
                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("" + ex);
            }
            return s;
        }
        public string Startingkm_Textchanged(string s)
        {
            
            if (s.Contains("-") && s.Length > 1)
            {
                try
                {
                    int val = Convert.ToInt32(s.Substring(1, s.Length - 1));
                    if (val > 1)
                    {
                       MessageBox.Show("Allow -1 or 6 Numbers only");
                        msg = "";
                    }
                }
                catch
                {
                    MessageBox.Show("Starting km Format Error");
                    msg = "";
                }


            }
            return msg;
        }
        public string Startingkm_KeyDown(string s,string S1)
        {
            
               
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select endingkm as km from load_trip_details where  vehiclenumber='" + S1 + "' order by unloaddate desc", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            int mkm = 0;
                            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["km"].ToString()))
                            {
                                mkm = Convert.ToInt32(dt.Rows[0]["km"]);
                            }
                            int ckm = Convert.ToInt32(s);
                            if (mkm == -1)
                            {
                                //stkm.Text = "-1";
                            }
                            else if (mkm == 0)
                            {
                                //MessageBox.Show("Ending km Not Exist");
                            }
                            else if (ckm > mkm)
                            {

                            }
                            else if (ckm < mkm&&ckm!=-1)
                            {
                                MessageBoxResult mr = MessageBox.Show("Trip Starting Km is Below the Previous Ending Km", "Enter Km Correctly", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                if (mr == MessageBoxResult.OK || mr == MessageBoxResult.Cancel)
                                {
                                    msg = "";
                                    
                                }
                            }
                    else if (ckm ==-1)
                    {
                        msg = "0";
                    }
                    else
                            {

                            }
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("" + ex);
                    }

            return msg;


        }
      
        public string Load_Weight_Textchanged(string s)
        {
            try
            {

            }
            catch
            {
                MessageBox.Show("C");
            }
            if (s.Contains(".") && s.Length == 1)
            {
                msg ="";
            }
            else if (!s.Contains("."))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    bool digit = char.IsDigit(s[i]);
                    if (!digit)
                    {
                        MessageBox.Show("Enter Number Only");
                        msg = "";
                    }
                    else if (digit)
                    {
                        try
                        {
                            if(Convert.ToInt32(s) > 25)
                            {
                                MessageBox.Show("Enter Value Below 25");
                                msg = "";
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Conversion Error");
                        }
                       
                    }
                }
            }
            else if (s.Contains(".") && s.Length > 1)
            {
                String sub = s.Substring(0, s.Length - 1);
                try
                {
                    double val = Convert.ToDouble(sub);
                    if (val > 25)
                    {
                        MessageBox.Show("Enter Value Below 25");
                    }
                }
                catch
                {
                    msg = "";
                }
            }
            else
            {
                msg = "";
            }
            return msg;
        }
        public string Load_Weight_KeyDown(string s)
        {          
            try
            {
                double d = Convert.ToDouble(s);
                if (d > 25)
                {
                    MessageBox.Show("Enter Below 25");
                   msg = "";
                    
                }
            }
            catch
            {
                msg = "";
            }
            return msg;
        }
        public string Endingkm_KeyDown(String S1,String S2)
        {           
                if (!string.IsNullOrWhiteSpace(S1) && !string.IsNullOrWhiteSpace(S2))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select startingkm from load_trip_details where vehiclenumber='" + S1 + "' and tripstatus=1", con.conn);
                        OdbcDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            int w = Convert.ToInt32(dr[0]);
                            if (w == -1)
                            {
                                msg = S2;
                                //endkms.Text = "-1";
                            }
                            else if (Convert.ToInt32(S2) > w)
                            {
                                msg = (Convert.ToInt32(S2) - Convert.ToInt32(w)).ToString();
                            }
                            else
                            {
                                MessageBoxResult mbr = MessageBox.Show("Trip Ending Km is Less Then Starting Km", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                if (mbr == MessageBoxResult.OK)
                                {
                                    msg = "";
                                    
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Starting km is Empty");
                            msg = "";
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("" + ex);
                    }


                }
                else
                {
                    MessageBox.Show("Select Vehicle Number and Enter Ending Km");
                    msg = "";
                }
            return msg;
        }
        public string Unload_Weight_Textchanged(string s1)
        {
            
            if (s1.Contains(".") && s1.Length == 1)
            {
                msg = "";
            }
            else if (!s1.Contains(".")&&s1.Length > 0)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    bool digit = char.IsDigit(s1[i]);
                    if (!digit)
                    {
                        MessageBox.Show("Enter Number Only");
                        msg = "";
                    }
                   else if (digit)
                    {
                        try
                        {
                            if(Convert.ToInt32(s1) > 25)
                            {
                                MessageBox.Show("Enter Value Below 25");
                                msg = "";
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Incorrect Input");
                        }
                        
                    }
                }
               
            }
            else if (s1.Contains(".") && s1.Length > 1)
            {
                String sub = s1.Substring(0, s1.Length - 1);
                try
                {
                    double val = Convert.ToDouble(sub);
                    if (val > 25)
                    {
                        MessageBox.Show("Enter Value Below 25");
                        msg = "";
                    }
                }
                catch
                {
                    msg = "";
                }
            }
            else
            {
                msg = "";
            }
            return msg;
        }
        public string Unload_Weight_KeyDown(string s1, string s2)
        {
            if (!string.IsNullOrWhiteSpace(s2) )
            {
                try
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select loadweight from load_trip_details where vehiclenumber='" + s1 + "' and tripstatus=1",con.conn);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        try
                        {
                            double d = Convert.ToDouble(s2);
                            double dou = Convert.ToDouble(dr[0]);
                            if (d > dou)
                            {
                                MessageBox.Show("UnLoad Weight is Greater than Load Weight");
                                msg = "";
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Starting and Ending km is Invalid Format");
                            msg = "";
                            
                        }

                    }
                    else
                    {
                        MessageBox.Show("Load Weight is Empty");
                        msg = "";
                    }
                    con.close_connection();
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" + ex);
                    msg = "";
                   
                }

            }
            return msg;
        }
        public int Payment_Ok_btn_Click(int v)
        {
            int val = 0;
            try
            {                
                if (v > 15)
                {
                    MessageBoxResult mr = MessageBox.Show("Payment is greater than 15%", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (mr == MessageBoxResult.Yes)
                    {
                        val = v;
                       
                    }
                    else if (mr == MessageBoxResult.No)
                    {
                        val = 0;
                    }
                }
                else
                {
                    val = v;                  
                }
            }
            catch
            {
                MessageBox.Show("Number Format Error");
            }
            return val;
        }
        public string[] TripNumber_Keydown(String S1)
        {
            string[] VAL = new string[11];
                if (!string.IsNullOrWhiteSpace(S1))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select vehiclenumber,DATE_FORMAT(loaddate,'%d-%m-%Y') as date,driverid,loadname,loadadvance,driveradvance,tripfrieght,totalkm,payment,origin,destination from load_trip_details where tripnumber='" + S1 + "' and tripstatus=2", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            VAL[0] = dt.Rows[0]["vehiclenumber"].ToString();
                            VAL[1] = dt.Rows[0]["date"].ToString();
                            VAL[2] = dt.Rows[0]["driverid"].ToString();
                            VAL[3] = dt.Rows[0]["loadname"].ToString();
                            VAL[4] = (dt.Rows[0]["loadadvance"]).ToString();
                            VAL[5] = (dt.Rows[0]["driveradvance"]).ToString();
                            VAL[6] = (dt.Rows[0]["tripfrieght"]).ToString();
                            VAL[7] = (dt.Rows[0]["totalkm"]).ToString();
                            VAL[8] = (dt.Rows[0]["payment"]).ToString();
                            VAL[9] = dt.Rows[0]["origin"].ToString();
                            VAL[10] = dt.Rows[0]["destination"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Trip Details Doesnot Exist");
                        }
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Select Trip Number");
                }
            return VAL;
        }
        public string[] Card_Checked(string s1)
        {
            string[] VAL = new string[2];
            Connection con = new Connection();
            con.open_connection();
            if(!string.IsNullOrWhiteSpace(s1))
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand("select card_id from vechicle_details where vehicle_number='" + s1 + "'", con.conn);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string s = dt.Rows[0]["card_id"].ToString();
                        if (s.Equals(""))
                        {
                            MessageBox.Show("Please Insert Card number to this Vehicle or Select Card Id from List");
                        }
                        else
                        {
                            msg = s;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        OdbcCommand cmd1 = new OdbcCommand("select sum(credit_amount)as tot from credit_details where card_id='" + msg + "' and bool=0", con.conn);
                        OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            string ctda = dt1.Rows[0]["tot"].ToString();

                            if (ctda != "")
                            {
                                bal = Convert.ToDouble(dt1.Rows[0]["tot"]);
                                OdbcCommand cmd3 = new OdbcCommand("select sum(total_cost)as tot_cost from diesel_balance_sheet where card_id='" + msg + "'", con.conn);
                                OdbcDataAdapter da2 = new OdbcDataAdapter(cmd3);
                                DataTable dt2 = new DataTable();
                                da2.Fill(dt2);
                                if (dt2.Rows.Count > 0)
                                {
                                    string zxc = dt2.Rows[0]["tot_cost"].ToString();
                                    if (zxc == "")
                                    {
                                        balance = 0;
                                    }
                                    else
                                    {
                                        balance = Convert.ToDouble(dt2.Rows[0]["tot_cost"]);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Card Doesn't Exist");
                                }
                            }
                            else
                            {
                                bal = 0;
                            }
                            VAL[0] = msg.ToString();
                            if (bal == 0)
                            {
                                VAL[1] = (bal).ToString();
                            }
                            else
                            {
                                VAL[1] = (bal - balance).ToString();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Card Doesn't Exist For This Vehicle");
                        }
                        con.close_connection();
                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
            }
           
            return VAL;
        }
      
       
       
        public void Diesel_Calculation_Back_btn_Click()
        {
            bal = 0;
            balance = 0;
        }
 
       
        public string Load_Trailer_Insert_btn_Click(string s1,string[] s2,int[] count,string[] type,string[] place,double[] litter,double[] price,string[] date,double[] tot_price,string[] card_id,int[] no_of_time,string[] tollplace,string[] rtoplace,string[] otherreason,double[] tollamount,double[] rtoamount,double[] otheramount,double[] total)  
        {
            Connection con = new Connection();
            con.open_connection();
            string user = Properties.Settings.Default.User;
            if (user == "ADMIN" || user == "MANAGER" || user == "USER")
            {
                if (s1 == "L")
                {                   
                    if (!string.IsNullOrWhiteSpace(s2[0].ToString()) && !string.IsNullOrWhiteSpace(s2[1].ToString()) && !string.IsNullOrWhiteSpace(s2[2].ToString()) && !string.IsNullOrWhiteSpace(s2[3].ToString()) && !string.IsNullOrWhiteSpace(s2[4].ToString()) && !string.IsNullOrWhiteSpace(s2[5].ToString()) && !string.IsNullOrWhiteSpace(s2[6].ToString()) && !string.IsNullOrWhiteSpace(s2[7].ToString()) && !string.IsNullOrWhiteSpace(s2[8].ToString()) && !string.IsNullOrWhiteSpace(s2[9].ToString()) && !string.IsNullOrWhiteSpace(s2[10].ToString()) && !string.IsNullOrWhiteSpace(s2[11].ToString()) && !string.IsNullOrWhiteSpace(s2[12].ToString()) && !string.IsNullOrWhiteSpace(s2[13].ToString())&&!string.IsNullOrWhiteSpace(s2[14].ToString()))
                    {
                        string l = s2[0].ToString();
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Sure, Want to Insert Data", "Insert", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                try
                                {
                                    OdbcCommand cmd = new OdbcCommand("insert into load_trip_details(vehiclenumber,loaddate,tripnumber,driverid,loadname,origin,destination,startingkm,challonno,loadadvance,driveradvance,tripfrieght,clinername,loadtype,loadweight,vehicletype,tripstatus,lastupdated)values('" + s2[0].ToString() + "','" + Convert.ToDateTime(s2[1].ToString()).ToString("yyyy-MM-dd") + "','" + s2[2].ToString() + "','" + s2[3].ToString() + "','" + s2[4].ToString() + "','" + s2[5].ToString() + "','" + s2[6].ToString() + "','" + s2[7].ToString() + "','" + s2[8].ToString() + "','" + s2[9].ToString() + "','" + s2[10].ToString() + "','" + s2[11].ToString() + "','" + s2[12].ToString() + "','" + s2[14].ToString() + "','" + s2[13].ToString() + "','" + s2[15].ToString() + "',1,now())", con.conn);
                                    cmd.ExecuteNonQuery();                                                                       
                                    msg = "Success1";
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
                            MessageBox.Show("Vehicle Number Invalid Format");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Should Fill All Text Field");
                    }
                }
                else if (s1 == "U")
                {
                    if (!string.IsNullOrWhiteSpace(s2[0].ToString()) && !string.IsNullOrWhiteSpace(s2[1].ToString()) && !string.IsNullOrWhiteSpace(s2[2].ToString()) && !string.IsNullOrWhiteSpace(s2[3].ToString()) && !string.IsNullOrWhiteSpace(s2[4].ToString()) && !string.IsNullOrWhiteSpace(s2[5].ToString()) && !string.IsNullOrWhiteSpace(s2[6].ToString()) )
                    {
                        string l = s2[0].ToString();
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Sure, Want to Insert Data", "Insert", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                try
                                {
                                    OdbcCommand cmd = new OdbcCommand("update load_trip_details set unloaddate='" + Convert.ToDateTime(s2[2].ToString()).ToString("yyyy-MM-dd") + "',endingkm='" + s2[3].ToString() + "',totalkm='" + s2[4].ToString() + "',unloadweight='" + Convert.ToDouble(s2[5].ToString()) + "',payment='" + s2[6].ToString() + "',tripstatus=2,lastupdated=now() where tripnumber='" + s2[1].ToString() + "' and tripstatus=1", con.conn);
                                    cmd.ExecuteNonQuery();                                   
                                    msg = "Success2";                                    
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
                            MessageBox.Show("Vehicle Number Invalid Format");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Should Fill All Text Field");
                    }
                }
                else if (s1 == "C")
                {
                    if (!string.IsNullOrWhiteSpace(s2[0].ToString()) && !string.IsNullOrWhiteSpace(s2[1].ToString()) && !string.IsNullOrWhiteSpace(s2[2].ToString()) && !string.IsNullOrWhiteSpace(s2[3].ToString()) && !string.IsNullOrWhiteSpace(s2[4].ToString()))
                    {
                        string l = s2[0].ToString();
                        if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                        {
                            MessageBoxResult mr = MessageBox.Show("Are You Sure, Want to Insert Data", "Insert", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                            if (mr == MessageBoxResult.OK)
                            {
                                try
                                {                                    
                                    string cor = null;
                                    if (s2[4].ToString()=="L")
                                    {
                                        cor = "LOD";
                                    }
                                    else if (s2[4].ToString() == "T")
                                    {
                                        cor = "TLR";
                                    }
                                    int i =Convert.ToInt32( count[3]);int t = Convert.ToInt32(count[0]);int r = Convert.ToInt32(count[1]);int o = Convert.ToInt32(count[2]);
                                    for (int k = 0; k < i; k++)
                                    {
                                        OdbcCommand cmd = new OdbcCommand("insert into diesel_balance_sheet(trip_number,corporation,card_id,vehicle_number,origin,destination,place,fill_date,noof_times,litters,price_per,total_cost,withdraw,entry_date)values('" + s2[1].ToString() + "','" + cor + "','" + card_id[k] + "','" + s2[0].ToString() + "','" + s2[2].ToString() + "','" + s2[3].ToString() + "','" + place[k] + "','" + Convert.ToDateTime(date[k]).ToString("yyyy/MM/dd") + "','" + no_of_time[k] + "','" + Convert.ToDouble(litter[k]) + "','" + Convert.ToDouble(price[k]) + "','" + tot_price[k] + "','" + type[k] + "','" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy/MM/dd") + "')", con.conn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    for (int k = 0; k < t-1; k++)
                                    {
                                        OdbcCommand cmd3 = new OdbcCommand("insert into toll_spend(trip_number,place,amount,count)values('" + s2[1].ToString() + "','" + tollplace[k] + "','" + tollamount[k] + "'," + k + 1 + ")", con.conn);
                                        cmd3.ExecuteNonQuery();
                                    }
                                    for (int k = 0; k < r-1; k++)
                                    {
                                        OdbcCommand cmd4 = new OdbcCommand("insert into rto_pc(trip_number,place,amount,count)values('" + s2[1].ToString() + "','" + rtoplace[k] + "','" + rtoamount[k] + "'," + k + 1 + ")", con.conn);
                                        cmd4.ExecuteNonQuery();
                                    }
                                    for (int k = 0; k < o-1; k++)
                                    {
                                        OdbcCommand cmd5 = new OdbcCommand("insert into other_spend(trip_number,reason,amount,count)values('" + s2[1].ToString() + "','" + otherreason[k] + "','" + otheramount[k] + "'," + k + 1 + ")", con.conn);
                                        cmd5.ExecuteNonQuery();
                                    }
                                    
                                    OdbcCommand cmd2 = new OdbcCommand("insert into lpg_trip_expense(vehicle_number,trip_number,load_wages,unload_wages,phone,spares,driver,cliner,toll_spend,rto_pc_gas,others)values('" + s2[0].ToString() + "','" + s2[1].ToString() + "','" + total[10] + "','" + total[11] + "','" + total[12] + "','" + total[13] + "','" + total[14] + "','" + total[15] + "','" + total[0] + "','" + total[1] + "','" + total[2] + "')", con.conn);
                                    cmd2.ExecuteNonQuery();
                                    OdbcCommand cmd6 = new OdbcCommand("update load_trip_details set tripdiesel='" + total[3] + "',dieselamount='" + total[4] + "',tripmileage='" + total[5] + "',frieghtreduction='" + total[6] + "',tripexpense='" + total[7] + "',tripprofit='" + total[8] + "',driverbalance='" + total[9] + "',tripstatus=0,lastupdated=now() where tripnumber='" + s2[1].ToString() + "' and tripstatus=2", con.conn);
                                    cmd6.ExecuteNonQuery();                                    
                                    msg = "Success3";                                                                                                                                         
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
                            MessageBox.Show("Vehicle Number Invalid Format");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Should Fill All Text Field");
                    }
                }
                else
                {
                    MessageBox.Show("Select Which Operation You Want Perform");
                }
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
            con.close_connection();
            return msg;
        }
        public string Vehicle_Number_Previewtextinput(string num)
        {
            string NO = num;
            int LEN = num.Length;
            if (LEN <= 2)
            {
                for (int I = 0; I < LEN; I++)
                {
                    bool ISLETTER = Char.IsLetter(NO[I]);
                    if (!ISLETTER)
                    {
                        MessageBox.Show("Enter Character");
                        msg = "";
                    }
                }

            }
            else if (LEN <= 4)
            {
                for (int I = 2; I < LEN; I++)
                {
                    bool ISDIGIT = Char.IsDigit(NO[I]);
                    if (!ISDIGIT)
                    {
                        MessageBox.Show("Enter Digit");
                        msg = "";
                    }
                }
            }
            return msg;
        }
       public string[] Vehicle_Number_Keydown(string s1,string s2)
        { string[] v1=new string[4];
            if (!String.IsNullOrWhiteSpace(s1) && s2 == "L")
            {
                string l = s1;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select tripstatus from load_trip_details where tripstatus=1 and VehicleNumber like '" + s1 + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            if ((dt.Rows[0]["tripstatus"].ToString()) == "1")
                            {
                                MessageBox.Show("Selected Vehicle is ON-Trip Stage");
                                v1[0] = "";
                               
                            }

                        }
                        else
                        {
                            v1[0] = s1.ToString();
                        }
                        con.close_connection();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("" + ex);
                    }

                }
                else
                {
                    MessageBox.Show("Vehicle Number Invalid Format");
                }

            }
            else if (!String.IsNullOrWhiteSpace(s1) && s2=="U")
            {
                string l = s1;
                if (Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{2}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{4}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{2}[A-Za-z]{1}[0-9]{3}") || Regex.IsMatch(l, "^[A-Za-z]{2}[0-9]{6}"))
                {
                    try
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        OdbcCommand cmd = new OdbcCommand("select tripnumber,driverid,loadname,DATE_FORMAT(loaddate,'%d-%m-%Y')AS date from load_trip_details where tripstatus=1 and VehicleNumber like '" + s1 + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            v1[0] = dt.Rows[0]["tripnumber"].ToString();
                            v1[1] = dt.Rows[0]["driverid"].ToString();
                            v1[2] = dt.Rows[0]["loadname"].ToString();
                            v1[3] = dt.Rows[0]["date"].ToString();
                            
                        }
                        else
                        {
                            //maxkm =Convert.ToInt32(dt.Rows[0]["ekm"]);
                        }
                        con.close_connection();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("" + ex);
                    }

                }
                else
                {
                    MessageBox.Show("Vehicle Number Invalid Format");
                }
            }
            return v1;
        }
        public List<string> Cardid_Gotfocus()
        {
            List<string> str = new List<string>();
               Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select card_id from diesel_card_details where bool=0", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s = dt.Rows[i]["card_id"].ToString();
                    if (s.Equals(""))
                    {
                        MessageBox.Show("Card Details Not Exist");
                    }
                    else
                    {                        
                            str.Add(s);
                    }
                }
               
            }
            con.close_connection();
            return str;
            
        }
        public string CardId_Keydown(string s)
        {
            Connection con = new Connection();
            con.open_connection();
            string val = string.Empty;
            if (!string.IsNullOrWhiteSpace(s))
            {
                OdbcCommand cmd1 = new OdbcCommand("select sum(credit_amount)as tot from credit_details where card_id='" + s + "' and bool=0", con.conn);
                OdbcDataAdapter da1 = new OdbcDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    string ctda = dt1.Rows[0]["tot"].ToString();

                    if (ctda != "")
                    {
                        bal = Convert.ToDouble(dt1.Rows[0]["tot"]);
                        OdbcCommand cmd3 = new OdbcCommand("select sum(total_cost)as tot_cost from diesel_balance_sheet where card_id='" + s + "'", con.conn);
                        OdbcDataAdapter da2 = new OdbcDataAdapter(cmd3);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            string zxc = dt2.Rows[0]["tot_cost"].ToString();
                            if (zxc == "")
                            {
                                balance = 0;
                            }
                            else
                            {
                                balance = Convert.ToDouble(dt2.Rows[0]["tot_cost"]);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Card Doesn't Exist");
                        }
                    }
                    else
                    {
                        bal = 0;
                    }
                    
                    if (bal == 0)
                    {
                        val = (bal).ToString();
                    }
                    else
                    {
                        val = (bal - balance).ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Card Doesn't Exist For This Vehicle");
                }
                con.close_connection();
            }
            return val;
        }

    }
}
