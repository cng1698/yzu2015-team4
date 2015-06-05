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

        //Register part
        [TestMethod]
        public void CheckRegisterInputFormatName()
        {
            //Name
            Assert.AreEqual(false, team4.Register.CheckName(""));
        }
        [TestMethod]
        public void CheckRegisterInputFormatAccount()
        {
            //Account
            Assert.AreEqual(false, team4.Register.CheckAccount(""));
            Assert.AreEqual(true, team4.Register.CheckAccount("kkendsss"));

            Assert.AreEqual(false, team4.Register.CheckAccountNotExist("1234"));
            Assert.AreEqual(true, team4.Register.CheckAccountNotExist("account_for_tim"));
        }

        [TestMethod]
        public void CheckRegisterInputFormatPassword()
        {
            //Password
            Assert.AreEqual(false, team4.Register.CheckPassword(""));
        }

        [TestMethod]
        public void CheckRegisterInputFormatRole()
        {
            //Role
            Assert.AreEqual(false, team4.Register.CheckRole(3));
            Assert.AreEqual(true, team4.Register.CheckRole(1));
            Assert.AreEqual(true, team4.Register.CheckRole(2));
        }

        [TestMethod]
        public void CheckRegisterInputFormatEmail()
        {
            //Email
            Assert.AreEqual(true, team4.Register.CheckEmail("1234@4567"));
            Assert.AreEqual(false, team4.Register.CheckEmail(""));
            Assert.AreEqual(false, team4.Register.CheckEmail("12345"));
        }

        // logout
        [TestMethod]
        //1:登出
        //2:不登出
        //3:選擇登出但問題出在後者選項
        //4:前者選項有誤
        public void logoutinput()
        {
            //正常情況

            Assert.AreEqual(1, team4.logoutinput.logout(1, "Y"));//選擇登出並確定
            Assert.AreEqual(2, team4.logoutinput.logout(1, "N"));//選擇登出卻反悔
            Assert.AreEqual(2, team4.logoutinput.logout(2, ""));//沒選擇登出
            Assert.AreEqual(2, team4.logoutinput.logout(2, "Y"));//沒選擇登出，後者選項不跳出
            Assert.AreEqual(2, team4.logoutinput.logout(2, "N"));//沒選擇登出，後者選項不跳出

            //非正常情況

            Assert.AreEqual(3, team4.logoutinput.logout(1, ""));//選擇登出但未確定
            Assert.AreEqual(3, team4.logoutinput.logout(1, "YFSDFSD"));//選擇登出，但後者選項不正確
            Assert.AreEqual(4, team4.logoutinput.logout(123, "Y"));//無法判斷是否有按下登出
            Assert.AreEqual(4, team4.logoutinput.logout(123, "FSDF"));//無法判斷是否有按下登出


        }
        [TestMethod]
        public void Login_test()
        {
            //Success
            Assert.AreEqual("登入成功", Login.Check("account_for_tim", "Password"));

            //空白帳密
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("", ""));
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("", "Password"));
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("account_for_tim", ""));
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("023545", ""));
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("", "15654561"));

            //帳號密碼錯誤
            Assert.AreEqual("帳號或密碼錯誤", Login.Check("account_for_tim", "12456156"));
            Assert.AreEqual("帳號或密碼錯誤", Login.Check("asds15156156", "Password"));
        }
    }
}
