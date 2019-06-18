using System;
namespace Persistence
{
    public class Customers
    {
        public int CustomerID{get;set;}
        public string Customer_Name{get;set;}
        public string Customer_Address{get;set;}
        public string IdentityCard{get;set;}
        public string Customer_PhoneNumber{get;set;}
        
        public Customers()
        {
            
        }
        public Customers(int CustomerID, string Customer_Name, string Customer_Address,string IdentityCard, string Customer_PhoneNumber)
        {
            this.CustomerID = CustomerID;
            this.Customer_Name = Customer_Name;
            this.Customer_Address= Customer_Address;
            this.Customer_PhoneNumber = Customer_PhoneNumber;
            this.IdentityCard = IdentityCard;
        }
      

    }
}