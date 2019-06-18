using System;
using System.Collections.Generic;

namespace Persistence
{
    public class Contract
    {
        public int? ContractID{get;set;}
       
       
        public string Contract_Status{get;set;}
       
        public string DateRental{get;set;}
        public string DateReturn{get;set;}
        public string Type_Transaction{get;set;}
       
        //public string PriceOfMotor{get;set;}
        //public Customers cus{get;set;}
        public Motor motor{get;set;}
        public Customers customer{get;set;}
        // public Motor motor{get;set;}
      
      
        public Contract(Customers customer,Motor motor,string Contract_Status,string DateRental, string DateReturn,string IdentityCard){
            customer = new Customers();
            motor = new Motor();
            this.ContractID = ContractID;
          
           
            this. Contract_Status = Contract_Status;
            
            this.DateRental = DateRental;
            this.DateReturn = DateReturn;

            this.Type_Transaction = Type_Transaction;
           
        }
        public Contract()
        {
            customer = new Customers();
            motor = new Motor();
        }
    }
}