using System;
using DAL;
using MySql.Data.MySqlClient;
using Persistence;

namespace BL
{
    public class CustomerBL
    {
        CustomerDAL cusdal = new CustomerDAL();
        public Customers GetCustomerByID(int CustomerID)
        {
            return cusdal.GetCustomerByID(CustomerID);
        }
    }
}