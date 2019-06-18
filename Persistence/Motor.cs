using System;
namespace Persistence
{
    public class Motor
    {
        public string LicensePlate { get; set; }
        public string Motor_typeID { get; set; }
        public string Type_Name { get; set; }
        public string Producer { get; set; }
        public string PriceOfMotor { get; set; }
        public string Motor_Status { get; set; }

        public Motor()
        {

        }
        public Motor(string LicensePlate, string Motor_typeID, string Type_Name, string Producer, string PriceOfMotor,string Motor_Status)
        {
            this.LicensePlate = LicensePlate;
            this.Type_Name = Type_Name;
            this.Producer = Producer;
            this.PriceOfMotor = PriceOfMotor;
            this.Motor_Status = Motor_Status;
            this.Motor_typeID = Motor_typeID;
        }
    }
}