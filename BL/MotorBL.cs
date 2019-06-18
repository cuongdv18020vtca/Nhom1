using System;
using System.Collections.Generic;
using DAL;
using Persistence;

namespace BL
{
     public class MotorBL
    {
        MotorDAL mtdal = new MotorDAL();
        public MotorBL()
        {}
        public List<Motor> GetMotorByTypeMotor(string Motor_typeID)
        {
            return  mtdal.GetMotorByTypeMotor(Motor_typeID);
        }
        public List<Motor> GetTypeID(string Motor_typeID)
        {
            return mtdal.GetTypeID(Motor_typeID);
        }
        public List<Motor> GetMotorByLicensePlates(string LicensePlate)
        {
            return mtdal.GetMotorByLicensePlates(LicensePlate);
        }
         public bool AddMotor(Motor motor)
        {
            return mtdal.AddMotor(motor);
        }
        public Motor GetMotorByLicensePlate( string LicensePlate)
        {
            return mtdal.GetMotorByLicensePlate(LicensePlate);
        }
        
        public bool UpdateMotor(Motor motor)
        {
            return mtdal.UpdateMotor(motor);
        }
        public List<Motor> GetMotorByTypeID(string Motor_TypeID)
        {
            return mtdal.GetMotorByTypeID(Motor_TypeID);
        }
        public List<Motor> GetMotorByType_Name(string Type_Name)
        {
            return mtdal.GetMotorByType_Name(Type_Name);
        }
        public List<Motor> GetMotorByProducer(string Producer,string Type_Name)
        {
            return mtdal.GetMotorByProducer(Producer,Type_Name);
        }
        public Motor GetMotorRental()
        {
            return mtdal.GetMotorRental();
        }
        
    }
}