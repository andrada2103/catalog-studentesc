using System;
using MySql.Data.MySqlClient;

namespace catalog_sutedntesc
{
    class DBconnect
    {
        MySqlConnection connect = new MySqlConnection("Server=sql7.freesqldatabase.com; Database=sql7627550; Uid=sql7627550; Pwd=xJfICE3bHL;");

        public MySqlConnection GetConnection
        {
            get
            {
                return connect;
            }
        }

        public void openConnect()
        {
            try
            {
                if (connect.State == System.Data.ConnectionState.Closed)
                {
                    connect.Open();
                    Console.WriteLine("Connection opened successfully.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }
        }

        public void closeConnect()
        {
            try
            {
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    connect.Close();
                    Console.WriteLine("Connection closed successfully.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }
        }

        public void executeQuery(string query)
        {
            try
            {
                openConnect();
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("Connection must be valid and open.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }
            finally
            {
                closeConnect();
            }
        }
    }
}
