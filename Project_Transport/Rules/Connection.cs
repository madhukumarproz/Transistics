using System;
using System.Data.Odbc;
using System.Windows;

namespace Project_Transport
{
      
    
    class Connection
    {
       public OdbcConnection conn;
        public OdbcConnection str;
        public void open_connection()
        {
            try
            {

                conn = new OdbcConnection();
                //conn.ConnectionString="DSN=msp;UID=root;PWD=root";
                conn.ConnectionString =
                              "Dsn=Trans_Apps;" +
                              "Uid=root;" +
                              "Pwd=root;"; 
                conn.Open();
            }
            catch
            {
                MessageBoxResult dr = MessageBox.Show("Data source name not found and driver not specified 1", "application close", MessageBoxButton.OK, MessageBoxImage.Warning);

                if (dr == MessageBoxResult.OK)
                {
                    //Application.Current.Shutdown();
                    Environment.Exit(0);
                }
            }

        }
        public void close_connection()
        {
             conn.Close();
        }
        public void connection_string()
        {
            try
            {

                str = new OdbcConnection();
                //conn.ConnectionString="DSN=Transport;UID=;PWD=";
                str.ConnectionString =
                              "Dsn=Maintenance;" +
                              "Uid=root;" +
                              "Pwd=root;";
               str.Open();
            }
            catch
            {
                MessageBoxResult dr = MessageBox.Show("Data source name not found and driver not specified 2", "application close", MessageBoxButton.OK, MessageBoxImage.Warning);

                if (dr == MessageBoxResult.OK)
                {
                    //Application.Current.Shutdown();
                    Environment.Exit(0);
                }
            }
        }
        public void close_string()
        {
            str.Close();
        }
    }
}
