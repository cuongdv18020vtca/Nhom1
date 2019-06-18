using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class CustomerDAL
    {
        private string query;
        private MySqlDataReader reader ;
        private MySqlConnection connection;
        public CustomerDAL()
        {
            connection = DBHelper.OpenConnection();
        }
        public Customers GetCustomerByID(int? CustomerID)
        {
            query = @"Select * from Customers where CustomerID = " +CustomerID+ ";";
            // DBHelper.OpenConnection();
            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            Customers cus =  null;
            if(reader.Read())
            {
                cus = GetCustomerInfo(reader);
            }
            reader.Close();
            DBHelper.CloseConnection();
            return cus;

        }
        private Customers GetCustomerInfo(MySqlDataReader reader)
        {
            Customers cus = new Customers();
             cus.CustomerID = reader.GetInt32("CustomerID");
            cus.Customer_Name = reader.GetString("Customer_Name");
            cus.Customer_Address = reader.GetString("Customer_Address");
            cus.IdentityCard = reader.GetString("IdentityCard");
            cus.Customer_PhoneNumber = reader.GetString("Customer_PhoneNumber");
            return cus;
        }
        public Customers GetCustomerByIdentityCard(string IdentityCard)
        {
            query = @"select * from Customers where IdentityCard = '" +IdentityCard+ "';";
            // DBHelper.OpenConnection();
            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            Customers cus = null;
            if (reader.Read())
            {
                cus = GetCustomerInfo(reader);
            }
            reader.Close();
            DBHelper.CloseConnection();
            return cus;
        }
        private Customers GetIndentityInfo(MySqlDataReader reader)
        {
            Customers cus = new Customers();
            cus.IdentityCard = reader.GetString("IdentityCard");
            return cus;
        }
    }
}