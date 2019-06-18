using System;
using Persistence;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace DAL
{
    public class UserDAL
    {
        private string query;
        private MySqlDataReader reader;
        private MySqlConnection connection;
        public UserDAL()
        {
           connection = DBHelper.OpenConnection();
        }

        public Manager GetUser(string UserName, string Password)
        {
            if (UserName == null || Password == null)
            {
                return null;
            }
            Regex regex = new Regex("[a-zA-Z0-9]");
            MatchCollection matchUser = regex.Matches(UserName);
            MatchCollection matchPassword = regex.Matches(Password);
            if (matchUser.Count < UserName.Length || matchPassword.Count < Password.Length)
            {
                return null;
            }

            query = @"select * from Users where UserName ='" + UserName + "' and Passwords ='" + Password + "';";
            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();

            Manager manager = null;
            if (reader.Read())
            {
                manager = GetUserInfo(reader);
            }
            reader.Close();
            DBHelper.CloseConnection();
            return manager;

        }
        private Manager GetUserInfo(MySqlDataReader reader)
        {
            Manager manager = new Manager();
            manager.UserName = reader.GetString("UserName");
            manager.Password = reader.GetString("Passwords");
            return manager;

        }


    }
}