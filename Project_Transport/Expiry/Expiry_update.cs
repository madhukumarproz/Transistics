using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Transport 
{
    class Expiry_update
    {
       public void delete(string s)
        {
            Connection con = new Connection();
            con.open_connection();

            OdbcCommand cmd1 = new OdbcCommand("delete from bill where vehicle_no='" +s.ToString() + "'", con.conn);
            cmd1.ExecuteNonQuery();
            con.close_connection();
        }
       public void update(string[] k)
        {
            Connection con = new Connection();
            con.open_connection();

            OdbcCommand cmd1 = new OdbcCommand("update bill set Vehicle_no='" + k[0].ToString()+ "',Expiry_type='" + k[1].ToString() + "', From_date='" + Convert.ToDateTime(k[2]).ToString("yyyy-MM-dd") + "',To_date='" + Convert.ToDateTime(k[3]).ToString("yyyy-MM-dd") + "',Paid_amount='" + k[4].ToString()+ "',Paid_date='" + Convert.ToDateTime(k[5]).ToString("yyyy-MM-dd") + "',Number='" + k[6].ToString() + "'", con.conn);
            cmd1.ExecuteNonQuery();
            con.close_connection();
        }
        public void fc(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set Fc_Expiry='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
        public void inc(string[] f)
            {
             Connection con = new Connection();
             con.open_connection();
             OdbcCommand cmd = new OdbcCommand("update vechicle_details set Insurance_Expiry='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
             cmd.ExecuteNonQuery();
            con.close_connection();
        }
       
        public void nat(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set National_Expiry='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
        public void per(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set Permit_Expiry='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }

        public void exp(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set Explosive_Expiry='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
        public void yer(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set Yearly_Expiry='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
        public void hal(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set Half_Yearly_Expiry='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
        public void hyr(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set Hydro_Expiry ='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
        public void cll(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set CLL ='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
        public void pli(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set PLI ='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
        public void tax(string[] f)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("update vechicle_details set Tax_Expiry ='" + Convert.ToDateTime(f[0]).ToString("yyyy-MM-dd") + "'where vehicle_number='" + f[1].ToString() + "'", con.conn);
            cmd.ExecuteNonQuery();
            con.close_connection();
        }
    }
}
