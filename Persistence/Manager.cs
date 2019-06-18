using System;

namespace Persistence
{
    public class Manager
    {
        public int ManagerID{get;set;}
        public string UserName{get;set;}
        public string Password{get; set;}
        public string ManagerName{get;set;}
        public Manager()
        {

        }
        public Manager(int ManagerID, string UserName, string Password, string ManagerName){
            this.ManagerID =ManagerID;
            this.UserName = UserName;
            this.Password =Password;
            this.ManagerName =ManagerName;
        }
    }
}
