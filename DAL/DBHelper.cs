using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBHelper
    {
        private static MySqlConnection connection;

        private static string CONNECTION_STRING = "server = localhost; user id =root; port = 3306; password = 0124578;database = MotorRental;SslMode=None;";

        public static MySqlConnection OpenDefaultConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = CONNECTION_STRING
                };
                connection.Open();

                return connection;
            }
            catch
            {
                return null;
            }
        }

        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection
                {
                    ConnectionString = @"server = localhost; user id =root; port = 3306; password = 0124578;database = MotorRental"
                };

            }
            return connection;
        }
        // public static MySqlConnection OpenConnection()
        // {
        //     if(connection == null)
        //     {
        //         GetConnection();
        //     }
        //     connection.Open();
        //     return connection;
        // }
        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
        public static MySqlDataReader ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
        public static MySqlConnection OpenConnection()
        {
            try
            {
                string connectionString;

                FileStream fileStream = File.OpenRead("ConnectionString.txt");
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    connectionString = reader.ReadLine();
                }
                fileStream.Close();

                return OpenConnection(connectionString);
            }
            catch
            {
                return null;
            }
        }

        public static MySqlConnection OpenConnection(string connectionString)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();
                return connection;
            }
            catch
            {
                return null;
            }
        }
    }
}
