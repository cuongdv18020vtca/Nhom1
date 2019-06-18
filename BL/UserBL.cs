using System;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL
{
    public class UserBL
    {
        UserDAL userdal = new UserDAL() ;
        
        public Manager GetUser(string UserName, string Password)
        {
            // if ((UserName == null) || (Password == null))
            // {
            //     return null;
            // }
            
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionUsername = regex.Matches(UserName);
            MatchCollection matchCollectionPassword = regex.Matches(Password);
            if (matchCollectionUsername.Count < UserName.Length || matchCollectionPassword.Count < Password.Length)
            {
                return null;
            }
           return userdal.GetUser(UserName, Password);
        }
        
    }
}
