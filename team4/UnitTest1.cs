using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace team4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void dbtest_addUser()
        {
            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com");
            Assert.IsTrue(team4.database.addUser(temp_user));
            //Assert.IsTrue(true);
            
        }
        [TestMethod]
        public void dbtest_getUser()
        {
            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com");
            Assert.AreEqual(temp_user.role, team4.database.getUserByAccount("account_for_tim").role);
        }
        [TestMethod]
        public void dbtest_addGood()
        {
            good temp_good = new good("iPhone", "bank_transfer", 20, 25000, "iPhone.jpg", 50, "\0", "Tim");
            Assert.IsTrue(team4.database.addGood(temp_good));
        }
        [TestMethod]
        public void dbtest_getGood()
        {
            good temp_good = new good("iPhone", "bank_transfer", 20, 25000, "iPhone.jpg", 50, "\0", "Tim");
            Assert.AreEqual(temp_good.price, team4.database.getGoodByName("iPhone").price);
        }

    }
}
