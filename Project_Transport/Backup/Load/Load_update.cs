using System;
using System.Data;
using System.Data.Odbc;
using System.Text.RegularExpressions;
using System.Windows;
using System.Linq;

namespace Project_Transport 
{
    class Load_update
    {
        public string loadupdate(string[] k,string tripnum)
        {
            string l = null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd1 = new OdbcCommand("update load_trip_details set DriverId='" + k[0].ToString() + "',LoadName='" + k[1].ToString() + "', Origin='" + k[2].ToString() + "',Destination='" + k[3].ToString() + "',StartingKm='" + k[4].ToString() + "',ChallonNo='" + k[5].ToString() + "',DriverAdvance='" + k[6].ToString() + "',LoadAdvance='" + k[7].ToString() + "',TripFrieght='" + k[8].ToString() + "',ClinerName='" + k[9].ToString() + "',LoadType='" + k[10].ToString() + "',LoadWeight='" + k[11].ToString() + "' where TripNumber='" + tripnum + "'", con.conn);
                cmd1.ExecuteNonQuery();
                l = "Y";
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Datas not updated" + ex);
            }
            return l;

        }
       public string unloadupdate(string[] k,string tripnum)
        {
            string u = null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd1 = new OdbcCommand("update load_trip_details set DriverId='" + k[0].ToString() + "',LoadName='" + k[1].ToString() + "', Origin='" + k[2].ToString() + "',Destination='" + k[3].ToString() + "',StartingKm='" + k[4].ToString() + "',ChallonNo='" + k[5].ToString() + "',DriverAdvance='" + k[6].ToString() + "',LoadAdvance='" + k[7].ToString() + "',TripFrieght='" + k[8].ToString() + "',ClinerName='" + k[9].ToString() + "',LoadType ='" + k[10].ToString() + "',LoadWeight='" + k[11].ToString() + "',EndingKm='" + k[13].ToString() + "',TotalKm='" + k[14].ToString() + "',UnloadWeight='" + k[15].ToString() + "',PaymentType='" + k[16].ToString() + "' where TripNumber='" + tripnum + "'",con. conn);
                cmd1.ExecuteNonQuery();
                u = "Y";

            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return u;
        }
        public string closeupdate(string[] k,string tripnum)
        {
            string c=null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd1 = new OdbcCommand("update load_trip_details set DriverId='" + k[0].ToString() + "',LoadName='" + k[1].ToString() + "', Origin='" + k[2].ToString() + "',Destination='" + k[3].ToString() + "',StartingKm='" + k[4].ToString() + "',ChallonNo='" + k[5].ToString() + "',DriverAdvance='" + k[6].ToString() + "',LoadAdvance='" + k[7].ToString() + "',TripFrieght='" + k[8].ToString() + "',ClinerName='" + k[9].ToString() + "',LoadType ='" + k[10].ToString() + "',LoadWeight='" + k[11].ToString() + "',EndingKm='" + k[13].ToString() + "',TotalKm='" + k[14].ToString() + "',UnloadWeight='" + k[15].ToString() + "',Payment='" + k[16].ToString() + "',TripExpense='" + k[17].ToString() + "',TripDiesel='" + k[18].ToString() + "',DieselAmount='" + k[19].ToString() + "',TripMileage='" + k[20].ToString() + "',FrieghtReduction='" + k[21].ToString() + "',TripProfit='" + k[22].ToString() + "',DriverBalance='" + k[23].ToString() + "' where TripNumber='" + tripnum + "'",con. conn);
                cmd1.ExecuteNonQuery();
                c = "Y";
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return c;

        }
         public string delete(string tripnum)
        {
            string s = null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand CMD = new OdbcCommand("DELETE FROM diesel_balance_sheet where trip_number='"+tripnum +"'",con.conn);
                CMD.ExecuteNonQuery();
                OdbcCommand CMD1 = new OdbcCommand("DELETE FROM toll_spend where trip_number='" + tripnum + "'", con.conn);
                CMD1.ExecuteNonQuery();
                OdbcCommand CMD2 = new OdbcCommand("DELETE FROM rto_pc where trip_number='" + tripnum + "'", con.conn);
                CMD2.ExecuteNonQuery();
                OdbcCommand CMD3 = new OdbcCommand("DELETE FROM other_spend where trip_number='" + tripnum + "'", con.conn);
                CMD3.ExecuteNonQuery();
                OdbcCommand CMD4 = new OdbcCommand("DELETE FROM lpg_trip_expense where trip_number='" + tripnum + "'", con.conn);
                CMD4.ExecuteNonQuery();
                OdbcCommand cmd1 = new OdbcCommand("delete from  load_trip_details where TripNumber='" + tripnum + "' ",con. conn);
                cmd1.ExecuteNonQuery();
                con.close_connection(); 
                s = "y";
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Details cannot be deleted" + ex);
            }
            return s;
        }
        public void startingkm(string stkm,string vhlno)
        {

            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd1 = new OdbcCommand("SELECT EndingKM FROM load_trip_details WHERE VehicleNumber='" + vhlno + "' ORDER BY UnloadDate DESC ",con. conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (stkm == "-1")
                {

                }
                else if (Convert.ToInt32(stkm) < Convert.ToInt32(dt.Rows[0]["EndingKm"]))
                {
                    MessageBox.Show("StartingKm is less than EndingKm");
                    stkm = "";
                }
            }
        }
        public void endingkm(string stkm,string endkms)
        {
            int sk = Convert.ToInt32(stkm);
            int ek = Convert.ToInt32(endkms);
            if (ek < sk)
            {
                MessageBox.Show("EndingKm is lesser than StartingKm");
            }
        }
        public string wght(string wgt)
        {
            string w = null;
            string s = wgt;
            if (Regex.IsMatch(s, "^[0-9]{2}[.]{1}[0-9]{2}") || Regex.IsMatch(s, "^[0-9]{1}[.]{1}[0-9]{2}") || Regex.IsMatch(s, "^[0-9]{2}[.]{1}[0-9]{1}") || Regex.IsMatch(s, "^[0-9]{1}[.]{1}[0-9]{1}") || Regex.IsMatch(s, "^[0-9]{1}") || Regex.IsMatch(s, "^[0-9]{2}"))
            {
                decimal d = Convert.ToDecimal(wgt);
                if (d > 25)
                {
                    MessageBox.Show("Enter Below 25");
                    w = "";
                }
            }
            else
            {
                MessageBox.Show("Patten does not match");
                w = "";
            }
            return w;
        }
        public string unloadwght(string unlodwgt,string wgt)
        {
            string uw = null;
            decimal d = Convert.ToDecimal(unlodwgt);
            if (d < 25)
            {
                double doub = Convert.ToDouble(unlodwgt);
                double dou = Convert.ToDouble(wgt);
                if (doub <= dou)
                {

                }
                else
                {
                    MessageBox.Show("UnLoad Weight is Greater than Load Weight");
                    uw = "";
                }

            }
            else
            {
                MessageBox.Show("Enter Below 25");
                uw = "";
            }
            return uw;
        }
       
        public string dieselupdate(int[] l,double[] p,double[] a,int[] c,string[] d, string tripnum,int row)
        {
            string v = null;
            try
            { 
                Connection con = new Connection();
                con.open_connection();
                for(int i=0;i<row;i++)
                {
                    OdbcCommand cmd1 = new OdbcCommand("update diesel_balance_sheet set fill_date='" +Convert.ToDateTime( d[i].ToString()).ToString("yyyy/MM/dd") + "',litters='" +Convert.ToInt32( l[i]) + "', price_per='" +Convert.ToDouble( p[i].ToString()) + "',total_cost='" +Convert.ToDouble( a[i].ToString()) + "' where Trip_Number='" + tripnum + "' and noof_times='"+Convert.ToInt32(c[i])+"'", con.conn);
                    cmd1.ExecuteNonQuery();
                    v = "Y";
                }

                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return v;

        }
        public string expenseupdate(string[] k, string tripnum)
        {
            string e = null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                OdbcCommand cmd1 = new OdbcCommand("update lpg_trip_expense set load_wages='" + k[0].ToString() + "',unload_wages='" +  k[1].ToString() + "', phone='" + k[2].ToString() + "',spares='" + k[3].ToString() + "',driver='" + k[4].ToString() + "',cliner='" + k[5].ToString() + "',toll_spend='"+ k[6].ToString() + "',rto_pc_gas='"+ k[7].ToString() + "',others='"+ k[8].ToString() + "' where Trip_Number='" + tripnum + "'",con. conn);
                cmd1.ExecuteNonQuery();
                e = "Y";
                con.close_connection();
                
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return e;

        }
        public string tollwagesupdate(string[] p,int[] c,double[] a, string tripnum,int row)
        {
            string t = null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                for(int i=0;i< row;i++)
                {
                    OdbcCommand cmd1 = new OdbcCommand("update toll_spend set place='" + p[i].ToString() + "',amount='" +Convert.ToDouble( a[i]) + "'  where Trip_Number='" + tripnum + "' and count='" + c[i].ToString() + "'", con.conn);
                    cmd1.ExecuteNonQuery();
                    t = "Y";
                }             
                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return t;

        }
        public string rtoupdate(string[] p, int[] c, double[] a, string tripnum, int row)
        {
            string r = null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                for(int i=0;i< row;i++)
                {
                    OdbcCommand cmd1 = new OdbcCommand("update rto_pc set place='" + p[i].ToString() + "',amount='" + a[i].ToString() + "'  where Trip_Number='" + tripnum + "' and count='" + c[i].ToString() + "'", con.conn);
                    cmd1.ExecuteNonQuery();
                    r = "Y";
                }
                
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return r;

        }
        public string otherwagesupdate(string[] p, int[] c, double[] a, string tripnum, int row)
        {
            string o = null;
            try
            {
                Connection con = new Connection();
                con.open_connection();
                for(int i=0;i<row;i++)
                {
                    OdbcCommand cmd1 = new OdbcCommand("update other_spend set reason='" + p[i].ToString() + "',amount='" + a[i].ToString() + "'  where Trip_Number='" + tripnum + "' and count='" + c[i].ToString() + "'", con.conn);
                    cmd1.ExecuteNonQuery();
                    o = "Y";
                     
                }
                con.close_connection();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return o;

        }
    }

}

