using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Odbc;
using Microsoft.Reporting.WinForms;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace Project_Transport
{
    /// <summary>
    /// Interaction logic for UserCreation.xaml
    /// </summary>
    public partial class UserCreation : UserControl
    {
        public UserCreation()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if(user=="ADMIN")
            {
                if (!String.IsNullOrEmpty(text.Text) && !String.IsNullOrEmpty(passtext.Password) && !String.IsNullOrEmpty(passtext1.Password))
                {
                    int i = passtext.Password.Length;
                    int j = passtext1.Password.Length;
                    if (i > 7 && j > 7)
                    {
                        if (passtext1.Password == passtext.Password)
                        {
                            if (combo.Text != "SELECT")
                            {
                                try
                                {
                                    Connection con = new Connection();
                                    con.open_connection();
                                    string s2 = text.Text;
                                    string s1 = passtext.Password;
                                    string name = SecureMessage.Encrupt(s2, true);
                                    string code = SecureMessage.Encrupt(s1, true);
                                    OdbcCommand cmd = new OdbcCommand("insert into log_table (user_name,passcode,designation) values('" + name + "','" + code + "','" + combo.Text + "')", con.conn);
                                    cmd.ExecuteNonQuery();
                                    select();
                                    text.Text = "";
                                    passtext.Password = "";
                                    passtext1.Password = "";
                                    String s = combo.Items.GetItemAt(0).ToString();
                                    combo.Text = s.Substring(s.Length - 6, 6);
                                    con.close_connection();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                            else
                            {
                                MessageBox.Show("please choose the designation");
                            }
                        }
                        else
                        {
                            MessageBox.Show("confirm password not matching with  passsword");
                        }
                    }
                    else
                    {
                        MessageBox.Show("password should contain atleast 7 character");
                    }
                }
                else
                {
                    MessageBox.Show("please enter the details");
                }
            }
            else
            {
                MessageBox.Show("Permission Denied");
            }
           
        }
        public void select()
        {
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd1 = new OdbcCommand("select user_name,designation,last_login from log_table", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                datagrid.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("data not found");
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            host.Visibility = Visibility.Hidden;
            ReportViewer.Clear();          
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            host.Visibility = Visibility.Visible;
            ReportViewer.Reset();
            Connection con = new Connection();
            con.open_connection();
            OdbcCommand cmd1 = new OdbcCommand("select  user_name,designation,last_login from log_table", con.conn);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportViewer.Clear();
            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            ReportViewer.LocalReport.DataSources.Add(ds);
            ReportViewer.LocalReport.ReportEmbeddedResource = "Project_Transport.Report1.rdlc";
            ReportViewer.RefreshReport();
        }
        void click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dv = (DataRowView)datagrid.SelectedItem;
                if (dv["designation"] != null)
                {
                    String i = (dv["designation"]).ToString();
                    combo.Text = i;
                    text.Text = dv["user_name"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Detail is Empty");
            }
           
        }
        private void passtext1_GotFocus(object sender, RoutedEventArgs e)
        {
            passtext1.Password = String.Empty;
        }
        private void passtext_GotFocus(object sender, RoutedEventArgs e)
        {
            passtext.Password = String.Empty;
        }
        private void text_GotFocus(object sender, RoutedEventArgs e)
        {
            text.Text = String.Empty;
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            string user = Properties.Settings.Default.User;
            if(user=="ADMIN")
            {
               
                if ((sender as ToggleButton).IsChecked ?? false)
                {
                    if(!string.IsNullOrWhiteSpace(text.Text))
                    {
                        Connection con = new Connection();
                        con.open_connection();
                        string usr = SecureMessage.Encrupt(text.Text, true);
                        OdbcCommand cmd2 = new OdbcCommand("select designation from log_table where user_name='" + usr + "'", con.conn);
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            combo.Text = dt.Rows[0]["designation"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("User Detail Not Exist");                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter User Name");
                        togglebtn.IsChecked = false;
                    }
                   
                    //select();
                }
                else
                {
                    if (!String.IsNullOrEmpty(text.Text) && !String.IsNullOrEmpty(passtext.Password) && !String.IsNullOrEmpty(passtext1.Password))
                    {
                        int i = passtext.Password.Length;
                        int j = passtext1.Password.Length;
                        if (i > 7 && j > 7)
                        {
                            if (passtext1.Password == passtext.Password)
                            {
                                if (combo.Text != "SELECT")
                                {
                                    try
                                    {
                                        Connection con = new Connection();
                                        con.open_connection();
                                        OdbcCommand cmd2 = new OdbcCommand("update log_table set passcode='" + passtext.Password + "' where user_name='" + text.Text + "' AND designation='" + combo.Text + "'", con.conn);
                                        cmd2.ExecuteNonQuery();
                                        select();
                                        text.Text = "";
                                        passtext.Password = "";
                                        passtext1.Password = "";
                                        String s = combo.Items.GetItemAt(0).ToString();
                                        combo.Text = s.Substring(s.Length - 6, 6);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("please select the designation");
                                    togglebtn.IsChecked = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("password not matching");
                                togglebtn.IsChecked = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("password should contain atleast 7 character");
                            togglebtn.IsChecked = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("please enter the details");
                        togglebtn.IsChecked = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Permission Denied");
            }
           
        }
    }
}
