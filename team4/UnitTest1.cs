using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace team4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void dbtest()
        {
            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com");
            Assert.IsTrue(team4.database.addUser(temp_user));
            //Assert.IsTrue(true);

        }

    }
}
