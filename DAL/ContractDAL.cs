using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class ContractDAL
    {
        private string query;
        private MySqlConnection connection;
        // public ContractDAL()
        // {
        //     connection = DBHelper.OpenConnection();
        // }

        public bool CreateContract(Contract contract, Customers cus)
        {
            if (contract == null)
            {
                return false;
            }
            bool result = false;

            MySqlConnection connection = DBHelper.OpenConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.Connection = connection;


            cmd.CommandText = "lock tables Customers write, Contract_Motor write, Contract write,Motor write;";
            cmd.ExecuteNonQuery();
            MySqlTransaction trans = connection.BeginTransaction();
            cmd.Transaction = trans;
            MySqlDataReader reader = null;
            CustomerDAL cusdal = new CustomerDAL();
            if (cus == null || cus.Customer_Name == null || cus.Customer_Name == "")
            {
                cus = new Customers() { CustomerID = 1 };

            }

            try
            {

                if (cusdal.GetCustomerByIdentityCard(cus.IdentityCard) == null)
                {

                    cmd.CommandText = @"insert into Customers(Customer_Name,Customer_Address,IdentityCard,Customer_PhoneNumber)
                 
                    values(@Customer_Name,@Customer_Address,@IdentityCard,@Customer_PhoneNumber);";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Customer_Name", cus.Customer_Name);
                    cmd.Parameters.AddWithValue("@Customer_Address", cus.Customer_Address);
                    cmd.Parameters.AddWithValue("@IdentityCard", cus.IdentityCard);
                    cmd.Parameters.AddWithValue("@Customer_PhoneNumber", cus.Customer_PhoneNumber);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select CustomerID from Customers order by CustomerID desc limit 1;";
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        cus.CustomerID = reader.GetInt32("CustomerID");
                    }
                    reader.Close();
                }
                else
                {
                    cusdal = new CustomerDAL();
                    cus = cusdal.GetCustomerByIdentityCard(cus.IdentityCard);



                }

                // insert Contract;
                cmd.CommandText = @"insert into Contract(CustomerID,IdentityCard,Type_Transaction,Contract_Status,Contract_DateRental,Contract_DateReturn)
                 values(@CustomerID,@IdentityCard,@Type_Transaction,@Contract_Status,@Contract_DateRental, @Contract_DateReturn);";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CustomerID", cus.CustomerID);
                cmd.Parameters.AddWithValue("@IdentityCard", cus.IdentityCard);
                cmd.Parameters.AddWithValue("@Type_Transaction", contract.Type_Transaction);
                cmd.Parameters.AddWithValue("@Contract_Status", contract.Contract_Status);
             
                cmd.Parameters.AddWithValue("@Contract_DateRental", contract.DateRental);
                cmd.Parameters.AddWithValue("@Contract_DateReturn", contract.DateReturn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select LAST_INSERT_ID() as ContractID";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    contract.customer.CustomerID = reader.GetInt32("ContractID");
                }
                reader.Close();

                if (contract.motor.LicensePlate == null)
                {
                    throw new Exception("Khong tim thay xe");
                }

                cmd.CommandText = "select PriceOfMotor from Motor where LicensePlate = @LicensePlate";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@LicensePlate", contract.motor.LicensePlate);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    contract.motor.PriceOfMotor = reader.GetString("PriceOfMotor");

                }
                // if (contract.PriceOfMotor == null)
                // {
                //     throw new Exception("Khong ton tai xe");

                // }

                reader.Close();

                //insert Contract_Motor
                cmd.CommandText = "insert into Contract_Motor(LicensePlate,ContractID) values(@LicensePlate,@ContractID);";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@LicensePlate", contract.motor.LicensePlate);
                cmd.Parameters.AddWithValue("@ContractID", contract.customer.CustomerID);

                cmd.ExecuteNonQuery();

                //Update status in Motor

                // if (contract.deposit <= 50000)
                // {
                //     throw new Exception("Ban chua dat coc");
                // }

                cmd.CommandText = "update Motor set Motor_Status = @Motor_Status where LicensePlate = '" + contract.motor.LicensePlate + "';";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Motor_Status", contract.Type_Transaction);
                cmd.ExecuteNonQuery();

                trans.Commit();
                result = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                result = false;
                try
                {
                    trans.Rollback();
                }
                catch
                {

                }
            }
            finally
            {
                cmd.CommandText = "unlock tables;";
                cmd.ExecuteNonQuery();
                DBHelper.CloseConnection();

            }
            return result;

        }
        public bool ReturnMotor(Customers customer, Motor motor,Contract contract)
        {
            bool result = false;
            CustomerDAL cusdal = new CustomerDAL();
            MotorDAL mtdal = new MotorDAL();
            MySqlConnection connection = DBHelper.OpenConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.Connection = connection;


            cmd.CommandText = "lock tables  Contract write,Motor write;";
            cmd.ExecuteNonQuery();
            MySqlTransaction trans = connection.BeginTransaction();
            cmd.Transaction = trans;
            MySqlDataReader reader = null;
            try
            {
                if (cusdal.GetCustomerByID(customer.CustomerID) != null && mtdal.GetMotorByLicensePlate(motor.LicensePlate) != null)
                {
                    cmd.CommandText = @"select ct.ContractID,ct.CustomerID,mt.LicensePlate,ct.Contract_DateRental,ct.Contract_DateReturn,datediff(ct.Contract_DateReturn,ct.Contract_DateRental) as TongNgayThue,
                    (mt.PriceOfMotor * datediff(ct.Contract_DateReturn,ct.Contract_DateRental)) as TongTien from Contract ct
                    inner join Contract_Motor cm on ct.ContractID = cm.ContractID
                    inner join	Motor mt on  mt.LicensePlate = cm.LicensePlate where ct.CustomerID = '" + customer.CustomerID + "' and mt.LicensePlate = '" + motor.LicensePlate + "';";
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        contract.ContractID = reader.GetInt32("ContractID");
                    }
                    reader.Close();

                    // Update status contract

                    cmd.CommandText = "update Contract set Contract_Status = 'DA THANH TOAN' where ContractID = '" +contract.ContractID+ "';";
                    // cmd.Parameters.Clear();
                    // cmd.Parameters.AddWithValue("@LicensePlate",motor.LicensePlate);
                    cmd.ExecuteNonQuery();

                    // Update status Motor
                    cmd.CommandText = "update Motor set Motor_Status = 'CHUA THUE' where LicensePlate = '" +motor.LicensePlate+ "'";
                    // cmd.Parameters.Clear();
                    // cmd.Parameters.AddWithValue("@LicensePlate",motor.LicensePlate);
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    return true;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                result = false;
                try
                {
                    trans.Rollback();
                }
                catch
                {

                }
            }
            finally
            {
                cmd.CommandText = "unlock tables;";
                cmd.ExecuteNonQuery();
                DBHelper.CloseConnection();

            }
            return result;


        }


    }
    
}