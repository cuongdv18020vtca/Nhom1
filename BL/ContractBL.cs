using System;
using System.Collections.Generic;
using DAL;
using Persistence;

namespace BL
{
    public class ContractBL
    {
        ContractDAL contractDAL = new ContractDAL();
        public bool CreateContract(Contract contract,Customers cus)
        {
            return contractDAL.CreateContract(contract,cus);
        }
        public bool ReturnMotor( Customers customer, Motor motor,Contract contract)
        {
            return contractDAL.ReturnMotor(customer,motor,contract);
        }
    }
}