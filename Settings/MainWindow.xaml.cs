using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Settings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window 
    {
        public SettingWindow() 
        {
            InitializeComponent();
        }

        void transport_name_insert_click(Object sender, RoutedEventArgs e)
        {
            //MainWindow mw = new MainWindow();
            //Connection con = new Connection();
           // con.open_connection();
            if (!string.IsNullOrWhiteSpace(t_name.Text))
            {
                try
                {
                    //OdbcCommand cmd = new OdbcCommand("update title_table set title='" + t_name.Text + "' where number=1", con.conn);
                    //cmd.ExecuteNonQuery();
                    //time1.Start();
                    //chr = "t";
                    transport_name_insert_img1.Visibility = System.Windows.Visibility.Hidden;
                    transport_name_insert_img2.Visibility = System.Windows.Visibility.Visible;
                    t_name.Text = "";
                }
                catch
                {
                    MessageBox.Show("Data Insert Error");
                }


            }
            else
            {
                MessageBox.Show("Type transport name and then hit insert button");
            }

            //con.close_connection();
            //mw.GET_NAME1();
        }


        void transport_name_insert_checked(object sender, RoutedEventArgs e)
        {
            vv_code.Visibility = System.Windows.Visibility.Hidden;
        }


        void transport_name_edit_checked(object sender, RoutedEventArgs e)
        {
            vv_code.Visibility = System.Windows.Visibility.Visible;
            //Connection con = new Connection();
            //con.open_connection();
            //OdbcCommand cmd = new OdbcCommand("select vendor_code from transports_name", con.conn);
            //OdbcDataAdapter DA = new OdbcDataAdapter(cmd);
            //DataTable dty = new DataTable();
            //DA.Fill(dty);
            //if (dty.Rows.Count > 0)
            //{
            //    vv_code.Items.Clear();
            //    for (int i = 0; i < dty.Rows.Count; i++)
            //    {
            //        vv_code.Items.Add(dty.Rows[i]["vendor_code"]);
            //    }

            //}
            //con.close_connection();
        }



        void vv_code_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab | e.Key == Key.Enter)
            {
                try
                {
                    //Connection con = new Connection();
                    //con.open_connection();
                    //OdbcCommand cmd = new OdbcCommand("select transport_name,owner_name from transports_name where vendor_code='" + vv_code.Text + "'", con.conn);
                    //OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    trans_name.Text = dt.Rows[0]["transport_name"].ToString();
                    //    o_name.Text = dt.Rows[0]["owner_name"].ToString();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Invalid vendor code");
                    //}
                    //con.close_connection();
                }
                catch
                {
                    MessageBox.Show("Data Getting Error");
                }

            }
            else
            {
                MessageBox.Show("press tab or enter key");
            }


        }



        void transport_name_entry_click(object sender, RoutedEventArgs e)
        {
            //Connection con = new Connection();
            //con.open_connection();
            //MessageBoxResult mr = MessageBox.Show("Are You Sure, Want To Insert Data", "Insert Data", MessageBoxButton.OK, MessageBoxImage.Question);
            //if (mr == MessageBoxResult.OK)
            //{
            //    try
            //    {
            //        if (!string.IsNullOrWhiteSpace(trans_name.Text) & !string.IsNullOrWhiteSpace(v_code.Text) & !string.IsNullOrWhiteSpace(o_name.Text) & transport_name_insert.IsChecked == true)
            //        {
            //            OdbcCommand cmd = new OdbcCommand("insert into transports_name(transport_name,vendor_code,owner_name)values('" + trans_name.Text + "','" + v_code.Text + "','" + o_name.Text + "')", con.conn);
            //            cmd.ExecuteNonQuery();

            //            trans_name.Text = ""; v_code.Text = ""; o_name.Text = "";
            //        }
            //        else if (!string.IsNullOrWhiteSpace(trans_name.Text) & !string.IsNullOrWhiteSpace(vv_code.Text) & !string.IsNullOrWhiteSpace(o_name.Text) & transport_name_edit.IsChecked == true)
            //        {
            //            OdbcCommand cmd = new OdbcCommand("update transports_name set transport_name='" + trans_name.Text + "',owner_name='" + o_name.Text + "' where vendor_code='" + vv_code.Text + "'", con.conn);
            //            cmd.ExecuteNonQuery();
            //            trans_name.Text = ""; vv_code.Text = ""; o_name.Text = "";
            //        }
            //        else
            //        {
            //            MessageBox.Show("Should fill all text field");
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Data Insert Error");
            //    }
            //}

            //con.close_connection();
        }
    }
}
