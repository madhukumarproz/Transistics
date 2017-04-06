using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Expiry_bill.xaml
    /// </summary>
    public partial class Expiry_bill : UserControl
    {
        public Expiry_bill()
        {
            InitializeComponent();
            Expiry_string gs = new Expiry_string();
            gs.paidamnt = string.Empty;
            gs.no = string.Empty;
            this.DataContext = gs;
        }

        private void vehicleno_GotFocus(object sender, RoutedEventArgs e)
        {
            fc_expiry();
            insurance_expiry();
            national_expiry();
            permit_expiry();
            explosive_expiry();
            yearly_expiry();
            halfyearly_expiry();
            hydro_expiry();
            cll_expiry();
            pli_expiry();
            tax_expiry();

            vehicleno.ItemsSource = expiry;
            //MessageBox.Show(expiry[0]);

        }
        List<string> load = new List<string>();
        List<string> lpg = new List<string>();


        private void vehicleno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(vehicleno.Text))
                {

                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd1 = new OdbcCommand("select corporation from vechicle_details where vehicle_Number='" + vehicleno.Text + "' ",con. conn);
                    OdbcDataReader da = cmd1.ExecuteReader();
                    type.Items.Clear();

                    while (da.Read())
                    {
                        string s = da[0].ToString();
                        if (s == "LOD" || s == "TLR")
                        {
                            load.Add("FC_Expiry");
                            load.Add("Insurance_Expiry");
                            load.Add("National_Expiry");
                            load.Add("Permit_Expiry");
                            load.Add("Tax_Expiry");
                            type.ItemsSource = load;


                        }
                        else
                        {
                            lpg.Add("FC_Expiry");
                            lpg.Add("Insurance_Expiry");
                            lpg.Add("National_Expiry");
                            lpg.Add("Permit_Expiry");
                            lpg.Add("Explosive_Expiry");
                            lpg.Add("Yearly_Expiry");
                            lpg.Add("Half_Yearly_Expiry");
                            lpg.Add("Hydro_Expiry");
                            lpg.Add("CLL_Policy");
                            lpg.Add("PLI");
                            lpg.Add("Tax_Expiry");
                            type.ItemsSource = lpg;

                        }
                    }
                }
            }
        }
        List<string> s1 = new List<string>();
        string s2;
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            s1.Add("FC_Expiry");
            s1.Add("Insurance_Expiry");
            s1.Add("National_Expiry");
            s1.Add("Permit_Expiry");
            s1.Add("Explosive_Expiry");
            s1.Add("Yearly_Expiry");
            s1.Add("Half_Yearly_Expiry");
            s1.Add("Hydro_Expiry");
            s1.Add("CLL_Policy");
            s1.Add("PLI");
            s1.Add("Tax_Expiry");
            if (!string.IsNullOrWhiteSpace(vehicleno.Text) && !string.IsNullOrWhiteSpace(type.Text) && !string.IsNullOrWhiteSpace(from.Text) && !string.IsNullOrWhiteSpace(to.Text) && !string.IsNullOrWhiteSpace(amount.Text) && !string.IsNullOrWhiteSpace(paiddate.Text) && !string.IsNullOrWhiteSpace(no.Text))
            {
                try
                {



                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("insert into bill (vehicle_no,Expiry_type,From_date,To_date,Paid_amount,Paid_date,Number) values('" + vehicleno.Text + "','" + type.Text + "','" + Convert.ToDateTime( from.Text).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime( to.Text).ToString("yyyy-MM-dd") + "','" + amount.Text + "','" + Convert.ToDateTime( paiddate.Text).ToString("yyyy-MM-dd") + "','" + no.Text + "')", con.conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Details inserted");
                    vehicleno.Text = "";
                    type.Text = "";
                    from.Text = "";
                    to.Text = "";
                    amount.Text = "";
                    paiddate.Text = "";
                    no.Text = "";
                    con.close_connection();
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("" +ex);
                }
            }
            else
            {
                MessageBox.Show("Please enter all the details");
            }


        }

        private void back_Click(object sender, RoutedEventArgs e)
        {

        }
        List<string> expiry = new List<string>();
        string DT = Convert.ToDateTime(DateTime.Now.AddDays(31)).ToString("yyyy-MM-dd");


        public void fc_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,fc_expiry from vechicle_details where FC_EXPIRY<'"+DT+"'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());
                        MessageBox.Show(dt.Rows[0]["vehicle_number"].ToString());
                        i++;
                        
                    }

                }
                dbcon.close_connection();
            }
            catch
            {
                MessageBox.Show("fc expiry");
            }

        }
        public void insurance_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,insurance_expiry from vechicle_details where INSURANCE_EXPIRY<'" + DT + "'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());


                        i++;
                        dbcon.close_connection();
                    }

                }
            }
            catch
            {
                MessageBox.Show("insurance expiry");
            }

        }

        public void national_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,national_expiry from vechicle_details where NATIONAL_EXPIRY<'" + DT + "'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());

                        i++;
                        dbcon.close_connection();
                    }

                }
            }
            catch
            {
                MessageBox.Show("national expiry");
            }

        }




        public void permit_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,permit_expiry from vechicle_details where PERMIT_EXPIRY<'" + DT + "'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());
                        i++;
                        dbcon.close_connection();

                    }


                }
            }
            catch
            {
                MessageBox.Show("permit expiry");
            }

        }

        public void explosive_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,explosive_expiry from vechicle_details where EXPLOSIVE_EXPIRY<'" + DT + "'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());
                        i++;
                        dbcon.close_connection();
                    }


                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("explosive expiry" + ex);
            }

        }
        public void yearly_expiry()
        {
            
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,yearly_expiry from vechicle_details where YEARLY_EXPIRY<'" + DT + "'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());
                        i++;
                        dbcon.close_connection();

                    }


                }
            }
            catch
            {
                MessageBox.Show("yearly expiry");
            }

        }
        public void halfyearly_expiry()
        {
            
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,half_yearly_expiry from vechicle_details where HALF_YEARLY_EXPIRY<'" + DT + "'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());
                        i++;
                        dbcon.close_connection();

                    }


                }
            }
            catch
            {
                MessageBox.Show("halfyearly expiry");
            }
        }
        public void hydro_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,hydro_expiry from vechicle_details where HYDRO_EXPIRY<'" + DT + "'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());
                        i++;
                        dbcon.close_connection();
                    }


                }
            }
            catch
            {
                MessageBox.Show("hydro expiry");
            }

        }
        public void cll_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,cll_policy from vechicle_details where CLL_POLICY<'" + DT + "'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());
                        i++;
                        dbcon.close_connection();
                    }


                }
            }
            catch
            {
                MessageBox.Show("cll policy expiry");
            }

        }
        public void pli_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,pli from vechicle_details where PLI<'"+DT+"'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        expiry.Add(dt.Rows[i]["vehicle_number"].ToString());
                        i++;
                        dbcon.close_connection();
                    }


                }
            }
            catch
            {
                MessageBox.Show("pli expiry");
            }

        }
        public void tax_expiry()
        {
           
            try
            {
                Connection dbcon = new Connection();
                dbcon.open_connection();
                OdbcCommand cmd = new OdbcCommand("select vehicle_number,tax_expiry from vechicle_details where TAX_EXPIRY<'"+DT+"'", dbcon.conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int n = dt.Rows.Count;
                    for (int i = 0; i < n;)
                    {
                        string s1 = dt.Rows[i]["vehicle_number"].ToString();
                        i++;
                        dbcon.close_connection();
                    }


                }
            }
            catch
            {
                MessageBox.Show("tax expiry");
            }

        }


    }
}
