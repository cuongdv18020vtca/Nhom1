using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class MotorDAL
    {

        private string query;
        private MySqlDataReader reader;
        private MySqlConnection connection;
        public MotorDAL()
        {
            connection = DBHelper.OpenConnection();
        }

        public bool AddMotor(Motor motor)
        {

            bool result = false;
            if (motor == null)
            {
                return result;
            }

            query = @"insert into Motor(LicensePlate,Motor_TypeID,Producer,Type_Name,PriceOfMotor,Motor_Status)
                    value('" + motor.LicensePlate + "'," + motor.Motor_typeID + ",'" + motor.Producer + "','" + motor.Type_Name + "'," + motor.PriceOfMotor + ",'" + motor.Motor_Status + "');";
            //DBHelper.OpenConnection();
            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            motor = null;
            if (reader.Read())
            {
                motor = GetMotorInfo(reader);
            }
            reader.Close();
            result = true;
            DBHelper.CloseConnection();


            return result;

        }
        public Motor GetMotorByLicensePlate(string LicensePlate)
        {
           

            query = @"select * from Motor where LicensePlate = '" + LicensePlate + "';";
            //DBHelper.OpenConnection();
             MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
             Motor motor = null;
            if (reader.Read())
            {
                motor = GetLicensePlateInfo(reader);
            }
            reader.Close();
            DBHelper.CloseConnection();

            return motor;
        }
        private Motor GetLicensePlateInfo(MySqlDataReader reader)
        {
            Motor motor = new Motor();
            motor.LicensePlate = reader.GetString("LicensePlate");
            return motor;
        }
        public List<Motor> GetMotorByTypeMotor(string Motor_typeID)
        {
            query = @"select * from Motor where Motor_TypeID = '" + Motor_typeID + "';";
            //DBHelper.OpenConnection();
            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();

            List<Motor> listmotor = null;
            if (reader != null)
            {
                listmotor = GetListMotor(command);
            }
            reader.Close();
            DBHelper.CloseConnection();

            return listmotor;
        }
        private List<Motor> GetListMotor(MySqlCommand command)
        {
            List<Motor> listmotor = new List<Motor>();
            while (reader.Read())
            {
                Motor motor = GetMotorInfo(reader);
                listmotor.Add(motor);
            }
            return listmotor;
        }
        private Motor GetMotorInfo(MySqlDataReader reader)
        {
            Motor motor = new Motor();
            motor.LicensePlate = reader.GetString("LicensePlate");
            motor.Motor_typeID = reader.GetString("Motor_TypeID");
            motor.Producer = reader.GetString("Producer");
            motor.Type_Name = reader.GetString("Type_Name");
            motor.PriceOfMotor = reader.GetString("PriceOfMotor");
            motor.Motor_Status = reader.GetString("Motor_Status");
            return motor;
        }


        public bool UpdateMotor(Motor motor)
        {
            bool result = false;
            if (motor == null)
            {
                return result;
            }

            query = @"Update ignore Motor set PriceOfMotor = " + @motor.PriceOfMotor + " , Motor_Status = '" + @motor.Motor_Status + "' where Motor_TypeID = " + @motor.Motor_typeID + ";";
            //DBHelper.OpenConnection();query);
             MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            List<Motor> listmotor = null;
            motor = null;
            if (reader.Read())
            {
                listmotor = GetListMotor_TypeID(command);
            }
            reader.Close();
            DBHelper.CloseConnection();

            
            result = true;

            return result;
        }



        public List<Motor> GetMotorByTypeID(string Motor_typeID)
        {
            query = @"select Motor_TypeID from Motor where Motor_TypeID = " + Motor_typeID + ";";
            //DBHelper.OpenConnection();

            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            List<Motor> listmotor = null;
            if (reader.Read())
            {
                listmotor = GetListMotor_TypeID(command);
            }
            reader.Close();
            DBHelper.CloseConnection();

            return listmotor;
        }
        private Motor GetMotor_TypeIDInfo(MySqlDataReader reader)
        {
            Motor motor = new Motor();
            // motor.LicensePlate = reader.GetString("LicensePlate");
            motor.Motor_typeID = reader.GetString("Motor_TypeID");

            return motor;
        }

        // public List<Motor> GetListMotor(MySqlDataReader reader)
        // {
        //     List<Motor> listmotor = new List<Motor>();
        //     while (reader.Read())
        //     {
        //         Motor motor = GetMotorInfo(reader);
        //         listmotor.Add(motor);
        //     }
        //     return listmotor;
        // }

        public List<Motor> GetTypeID(string Motor_TypeID)
        {
            query = @" select Motor_TypeID from Motor where Motor_TypeID  = " + Motor_TypeID + ";";
            //DBHelper.OpenConnection();
             MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            List<Motor> listmotor = null;
            if (reader != null)
            {
                listmotor = GetTypeIDInfo(command);
            }
            reader.Close();
            DBHelper.CloseConnection();

            return listmotor;
        }
        public List<Motor> GetTypeIDInfo(MySqlCommand command)
        {

            List<Motor> listmotor = new List<Motor>();
            while (reader.Read())
            {
                Motor motor = GetMotorInfo(reader);
                listmotor.Add(motor);
            }

            Console.WriteLine(listmotor.Count);
            return listmotor;
        }



        public List<Motor> GetMotorByLicensePlates(string LicensePlate)
        {
            query = @"select * from Motor where LicensePlate = '" + LicensePlate + "';";
            //DBHelper.OpenConnection();
             MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
           
            List<Motor> listmotor = null;
            if (reader != null)
            {
                listmotor = GetListMotor(command);
            }
            reader.Close();
            DBHelper.CloseConnection();


            return listmotor;
        }

        private List<Motor> GetListMotor_TypeID(MySqlCommand command)
        {
            List<Motor> listmotor = new List<Motor>();
            while (reader.Read())
            {
                Motor motor = GetMotor_TypeIDInfo(reader);
                listmotor.Add(motor);
            }
            return listmotor;
        }


        // lay list motor theo tye_name
        public List<Motor> GetMotorByType_Name(string Type_Name)
        {
            query = @"select * from Motor where Type_Name = '" +Type_Name+ "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            List<Motor> ListMotors = null;
            if (reader != null)
            {
                ListMotors = GetListMotorByType_Name(command);
            }
            reader.Close();
            DBHelper.CloseConnection();
            return ListMotors;
        }

         private Motor GetMotorByType_NameInfo(MySqlDataReader reader)
        {
            Motor motor = new Motor();
            motor.LicensePlate = reader.GetString("LicensePlate");
            motor.Motor_typeID = reader.GetString("Motor_TypeID");
            motor.Type_Name = reader.GetString("Type_Name");
            motor.Producer = reader.GetString("Producer");
            motor.PriceOfMotor = reader.GetString("PriceOfMotor");
            motor.Motor_Status = reader.GetString("Motor_Status");

            return motor;
        }
        private List<Motor> GetListMotorByType_Name(MySqlCommand command)
        {
            List<Motor> ListMotors =  new List<Motor>();
            while (reader.Read())
            {
                Motor motor = GetMotorByType_NameInfo(reader);
                ListMotors.Add(motor);
            }
            return ListMotors;
        }
        public List<Motor> GetMotorByProducer(string Producer,string Type_Name)
        {
            query = @"select * from Motor where Producer = '" +Producer+ "' and Type_Name = '" +Type_Name+ "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            List<Motor> ListMotors = null;
            if (reader != null)
            {
                ListMotors = GetListMotorByProducer(command);
            }
            reader.Close();
            DBHelper.CloseConnection();
            return ListMotors;
        }
        
        private List<Motor> GetListMotorByProducer(MySqlCommand command)
        {
            List<Motor> ListMotors = new List<Motor>();
            while (reader.Read())
            {
                Motor motor = GetMotorByType_NameInfo(reader);
                ListMotors.Add(motor);
            }
            return ListMotors;
        }
        public Motor GetMotorRental()
        {
            query = @"select * from Motor where Motor_Status = 'CHUA THUE';";
            MySqlCommand command = new MySqlCommand(query,connection);
             reader = command.ExecuteReader();
             Motor motor = null;
             if (reader.Read())
            {
                motor = GetMotorInfo(reader);
            }
            reader.Close();
            DBHelper.CloseConnection();

            return motor;


        }
        
    }
}       