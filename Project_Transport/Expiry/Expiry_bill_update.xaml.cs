using System.Data;
using System.Data.Odbc;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for Expiry_bill_update.xaml
    /// </summary>
    public partial class Expiry_bill_update : UserControl
    {
        public Expiry_bill_update()
        {
            InitializeComponent();
        }
        Expiry_update eu = new Expiry_update();
        private void click(object sender, MouseButtonEventArgs e)
        {
            DataRowView dv = (DataRowView)datagrid.SelectedItem;
            vehicleno.Text = dv["Vehicle_no"].ToString();
            type.Text = dv["Expiry_type"].ToString();
            from.Text = dv["From_date"].ToString();
            to.Text = dv["To_date"].ToString();
            amount.Text = dv["Paid_amount"].ToString();
            paiddate.Text = dv["Paid_date"].ToString();
            no.Text = dv["Number"].ToString();
        }
        string[] s = new string[1];
        private void delete_Click(object sender, RoutedEventArgs e)
        {
           
            eu.delete(vehicleno.Text);
        }
       
        private void vhlno_GotFocus(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd = new OdbcCommand("select vehicle_Number from vechicle_details ", con.conn);
            OdbcDataAdapter da1 = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            vhlno.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    vhlno.Items.Add(dt.Rows[i]["Vehicle_Number"].ToString());
                    con.close_connection();
                }
            }
        }

        private void vhlno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(vhlno.Text))
                {
                    Connection con = new Connection();
                    con.open_connection();
                    OdbcCommand cmd = new OdbcCommand("select vehicle_no,Expiry_type, From_date,To_date,Paid_amount,Paid_date,Number from bill where vehicle_no='" + vhlno.Text + "' ", con.conn);
                    OdbcDataAdapter da1 = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {
                        datagrid.ItemsSource = dt.DefaultView;
                        con.close_connection();
                    }


                    else
                    {
                        MessageBox.Show("data not found");
                    }
                }

            }
            else
            {
                MessageBox.Show("Please choose the vehicle number");
            }
        }
        string[] k = new string[7];
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            k[0] = vehicleno.Text;
            k[1] = type.Text;
            k[2] = from.Text;
            k[3] = to.Text;
            k[4] = amount.Text;
            k[5] = paiddate.Text;
            k[6] = no.Text;
            eu.update(k);
           
            string[] f = new string[2];
            f[0] = to.Text;
            f[1] = vehicleno.Text;
            if (type.Text=="Fc_Expiry")
            {
                eu.fc(f);
                MessageBox.Show("Details updated");
            }
           
            else if (type.Text=="Insurance_Expiry")
            {
               eu.inc(f);
                MessageBox.Show("Details updated");
            }
           
            else if (type.Text=="National_Expiry")
            {
                eu.nat(f);
                MessageBox.Show("Details updated");
            }
           
            else if (type.Text=="Permit_Expiry")
            {
                eu.per(f);
                MessageBox.Show("Details updated");
            }
           
           else if (type.Text=="Explosive_Expiry")
            {
                eu.exp(f);
                MessageBox.Show("Details updated");
            }
           
            else if (type.Text=="Yearly_Expiry")
            {
                eu.yer(f);
                MessageBox.Show("Details updated");
            }
            else if(type.Text=="Half_Yearly_Expiry")
            {
                eu.hal(f);
                MessageBox.Show("Details updated");
            }
            else if(type.Text=="Hydro_Expiry")
            {
                eu.hyr(f);
                MessageBox.Show("Details updated");
            }
            else if(type.Text=="Cll_Expiry")
            {
                eu.cll(f);
                MessageBox.Show("Details updated");
            }
            else if(type.Text=="Pli_Expiry")
            {
                eu.pli(f);
                MessageBox.Show("Details updated");

            }
            else if(type.Text=="Tax_Expiry")
            {
                eu.tax(f);
                MessageBox.Show("Details updated");
            }
            vehicleno.Text = "";
            type.Text = "";
            from.Text = "";
            to.Text = "";
            amount.Text = "";
            paiddate.Text = "";
            no.Text = "";
           
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
           
        }

    }

}




