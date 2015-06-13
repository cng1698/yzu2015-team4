﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace team4
{
    [TestClass]
    public class UnitTest1
    {
        /*
        [ClassInitialize()]
        public static void dbreset(TestContext testContext)
        {
            
        }
        */

        [TestMethod]
        public void 檢查使用者新增()
        {
            team4.database.dbInit();

            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com");
            Assert.IsTrue(team4.database.addUser(temp_user));
            Assert.AreEqual(temp_user.role, team4.database.getUserByAccount("account_for_tim").role);

        }
        
        [TestMethod]
        public void 檢查商品新增()
        {
            team4.database.dbInit();

            good temp_good = new good("iPhone", "bank_transfer", 20, 25000, "iPhone.jpg", 50, "\0", "Tim");
            Assert.IsTrue(team4.database.addGood(temp_good));
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
            team4.database.dbInit();
            
            //Account
            Assert.AreEqual(false, team4.Register.CheckAccount(""));
            Assert.AreEqual(true, team4.Register.CheckAccount("kkendsss"));

            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com");
            team4.database.addUser(temp_user);

            Assert.AreEqual(true, team4.Register.CheckAccountExist("1234"));
            Assert.AreEqual(false, team4.Register.CheckAccountExist("account_for_tim"));
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
        
        [TestMethod]
        public void CheckRegisterSuccess()
        {
            team4.database.dbInit();
            user new_user = new user("Annie", "annie0000", "12345678", 1, "1234@4567");
            Assert.AreEqual(true, team4.Register.RegisterSuccess(new_user));
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
            team4.database.dbInit();

            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com");
            Assert.IsTrue(team4.database.addUser(temp_user));
            
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
        //Creat_Good
        
        [TestMethod]
        public void CheckCreatGood()
        {
            Assert.AreEqual(true, team4.Creat_good.CheckName("HTC"));
            Assert.AreEqual(false, team4.Creat_good.CheckName(""));

            Assert.AreEqual(true, team4.Creat_good.CheckContent("M8"));
            Assert.AreEqual(false, team4.Creat_good.CheckContent(""));

            Assert.AreEqual(true, team4.Creat_good.CheckPrice(20000));
            Assert.AreEqual(false, team4.Creat_good.CheckPrice(-200));

            Assert.AreEqual(true, team4.Creat_good.CheckAmount(10));
            Assert.AreEqual(false, team4.Creat_good.CheckAmount(-30));

            Assert.AreEqual(true, team4.Creat_good.CheckPicture("M8.jpg"));
            Assert.AreEqual(false, team4.Creat_good.CheckPicture("M8.txt"));
            Assert.AreEqual(false, team4.Creat_good.CheckPicture(""));
        }
        
        [TestMethod]
        public void CheckSetGood()
        {
            team4.database.dbInit();

            Assert.AreEqual(true, team4.Creat_good.SetGood("HTC", "M8", 20000, 10, "M8.jpg", "Tim"));
            Assert.AreEqual("HTC", team4.search.SearchName("HTC"));
            Assert.AreEqual("M8", team4.search.SearchContent("HTC"));
        }
                   
       /* [TestMethod]
        public void DirectlyBuy_test()
        {
            good TestGood = new good("Apple", "an apple", 10, 100, "Apple.jpg", 0, "", "yan");
            good want = database.getGoodByName("Apple");
            Assert.AreEqual("庫存不足", DirectlyBuy.Buy(want, "ASD", 11));
            DirectlyBuy.Buy(want, "ASD", 5);
            want = database.getGoodByName("Apple");
            
        }*/
      
    }
}
