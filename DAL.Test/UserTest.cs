using System;
using Xunit;
using DAL;
using Persistence;

namespace CTS_DAL_XUnit
{
    public class UserUnitTest
    {
        private UserDAL userDAL = new UserDAL();

        [Theory]
        [InlineData("dangcuong572", "123456")]
        [InlineData("dangngoc1010", "456123")]
        public void LoginTest1(string username, string password)
        {
            Manager manager = userDAL.GetUser(username, password);

            Assert.NotNull(manager);
            Assert.Equal(username, manager.UserName);
        }

        [Theory]
        [InlineData("dangcuong572", "123456789")]
        [InlineData("'?^%'", "'.:=='")]
        [InlineData("'?^%'",null)]
        [InlineData(null, "'.:=='")]
        public void LoginTest3(string username, string password)
        {
            Assert.Null(userDAL.GetUser(username, password));
        }
    }
}