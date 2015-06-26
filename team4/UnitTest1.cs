using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com" , "663" );
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
        public void 檢查註冊名稱格式()
        {
            //Name
            Assert.AreEqual(false, team4.Register.CheckName(""));
        }
        
        [TestMethod]
        public void 檢查註冊帳號格式()
        {
            team4.database.dbInit();
            
            //Account
            Assert.AreEqual(false, team4.Register.CheckAccount(""));
            Assert.AreEqual(true, team4.Register.CheckAccount("kkendsss"));

            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com" , "663");
            team4.database.addUser(temp_user);

            Assert.AreEqual(true, team4.Register.CheckAccountExist("1234"));
            Assert.AreEqual(false, team4.Register.CheckAccountExist("account_for_tim"));
        }

        [TestMethod]
        public void 檢查註冊密碼格式()
        {
            //Password
            Assert.AreEqual(false, team4.Register.CheckPassword(""));
        }

        [TestMethod]
        public void 檢查註冊角色格式()
        {
            //Role
            Assert.AreEqual(false, team4.Register.CheckRole(3));
            Assert.AreEqual(true, team4.Register.CheckRole(1));
            Assert.AreEqual(true, team4.Register.CheckRole(2));
        }

        [TestMethod]
        public void 檢查註冊信箱格式()
        {
            //Email
            Assert.AreEqual(true, team4.Register.CheckEmail("1234@4567"));
            Assert.AreEqual(false, team4.Register.CheckEmail(""));
            Assert.AreEqual(false, team4.Register.CheckEmail("12345"));
        }
        
        [TestMethod]
        public void 檢查註冊成功()
        {
            team4.database.dbInit();
            user new_user = new user("Annie", "annie0000", "12345678", 1, "1234@4567" , "663");
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

            user temp_user = new user("Tim", "account_for_tim", "Password", 1, "tim@mail.com" ,"663");
            Assert.IsTrue(team4.database.addUser(temp_user));
            
            //Success
            Assert.AreEqual("登入成功", Login.Check(temp_user.account, temp_user.pwd));

            //空白帳密
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("", ""));
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("", temp_user.pwd));
            Assert.AreEqual("帳號及密碼不得為空", Login.Check(temp_user.account, ""));
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("023545", ""));
            Assert.AreEqual("帳號及密碼不得為空", Login.Check("", "15654561"));

            //帳號密碼錯誤
            Assert.AreEqual("帳號或密碼錯誤", Login.Check(temp_user.account, "12456156"));
            Assert.AreEqual("帳號或密碼錯誤", Login.Check("asds15156156", temp_user.pwd));
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
           
        }

        // SearchGood 
        [TestMethod]
        public void SearchGood()
        {
            team4.database.dbInit();

            Assert.AreEqual(true, team4.Creat_good.SetGood("HTC", "M8", 20000, 10, "M8.jpg", "Tim"));
           
            Assert.AreEqual("HTC", team4.search.SearchName("HTC"));
            Assert.AreEqual("M8", team4.search.SearchContent("HTC"));
        }

        //delet/edit good
        [TestMethod]
        public void EditDeletGood()
        {
            team4.database.dbInit();

            Assert.AreEqual(true, team4.Creat_good.SetGood("HTC", "M8", 20000, 10, "M8.jpg", "Tim"));

            Assert.AreEqual(true, team4.EditDeletGood.EditContent("HTC", "Z3"));
            Assert.AreEqual(true, team4.EditDeletGood.EditAmount("HTC", 30));
            Assert.AreEqual(true, team4.EditDeletGood.EditPrice("HTC", 30000));
            Assert.AreEqual(true, team4.EditDeletGood.EditPicture("HTC", "Z3.jpg"));
            Assert.AreEqual(true, team4.EditDeletGood.EditName("HTC", "SONY"));

            Assert.AreEqual(true, team4.EditDeletGood.Delet("SONY"));
        }

        [TestMethod]
        public void DirectlyBuy_test()
        {
            team4.database.dbInit();

            good TestGood = new good("Apple", "an apple", 10, 100, "Apple.jpg", 0, "", "yan");
            database.addGood(TestGood);
            good want = database.getGoodByName("Apple");

            Assert.AreEqual("庫存不足", DirectlyBuy.Buy(want, "ASD", 11));

            Assert.AreEqual("購買成功", DirectlyBuy.Buy(want, "ASD", 5));
            want = database.getGoodByName("Apple");
            Assert.AreEqual("ASD", want.buyer);
            Assert.AreEqual(5, want.amount);

            want = database.getGoodByName("Apple");
            Assert.AreEqual("購買成功", DirectlyBuy.Buy(want, "ASD", 5));
            want = database.getGoodByName("Apple");
            Assert.AreEqual("已售完", DirectlyBuy.Buy(want, "ASD", 5));
        }

        [TestMethod]
        public void Varify_test()
        {
            team4.database.dbInit();
            user new_user = new user("Jerry", "Jerry_account", "12345678", 1, "1234@4567", "556");
            database.addUser(new_user);

            Assert.IsTrue(Email_Varify.verify(556, "1234@4567"));
            //Assert.AreEqual( "Tim" , Email_Varify.try_() ) ;
        }

        [TestMethod]
        public void modify_test()
        {
            team4.database.dbInit();
            user new_user = new user("Jerry", "Jerry_account", "12345678", 1, "1234@4567", "556");
            database.addUser(new_user);
            new_user = new user("Ann", "Ann_account", "12345678", 1, "aaaa@4567", "556");
            database.addUser(new_user);
            new_user = new user("Joyce", "Joyce_account", "12345678", 1, "bbbb@4567", "556");
            database.addUser(new_user);

            ChangeAccountInfomation.ModifyEmailByAccount( "Joyce_account" , "cccc@2252") ;
            ChangeAccountInfomation.ModifyEmailByAccount("Ann_account", "ggg@2252");
            ChangeAccountInfomation.ModifyPasswordByAccount("Joyce_account", "aabbc"); 



            List<user> alluser = database.getAllUser() ;

            Assert.AreEqual( "cccc@2252" , alluser[2].email) ;
            Assert.AreEqual("ggg@2252", alluser[1].email);
            Assert.AreEqual("aabbc", alluser[2].pwd);
            //Assert.AreEqual( "Tim" , Email_Varify.try_() ) ;
        }
        [TestMethod]
        public void Bid_test()
        {
            team4.database.dbInit();

            good TestGood = new good("Apple", "an apple", 10, 100, "Apple.jpg", 0, "", "yan");
            database.addGood(TestGood);
            good want = database.getGoodByName("Apple");

            Assert.AreEqual("出價金額過低", bid.Bid(want, 50, "yan"));
            Assert.AreEqual("出價成功", bid.Bid(want, 100, "yan"));
            want = database.getGoodByName("Apple");
            Assert.AreEqual(100, want.bid);
            Assert.AreEqual("yan", want.buyer);
            Assert.AreEqual("出價成功", bid.Bid(want, 110, "yan"));
            want = database.getGoodByName("Apple");
            Assert.AreEqual(110, want.bid);
            Assert.AreEqual("yan", want.buyer);

            Assert.AreEqual("出價金額未超過目前出價,請重新出價", bid.Bid(want, 105, "abab"));
            want = database.getGoodByName("Apple");
            Assert.AreEqual(110, want.bid);
            Assert.AreEqual("yan", want.buyer);

            Assert.AreEqual("出價成功", bid.Bid(want, 200, "abab"));
            want = database.getGoodByName("Apple");
            Assert.AreEqual(200, want.bid);
            Assert.AreEqual("abab", want.buyer);
        }
        [TestMethod]
        public void 價格排序測試()
        {
            team4.database.dbInit();

            good TestGood1 = new good("Apple", "an apple", 10, 200, "Apple.jpg", 0, "", "yan");
            good TestGood2 = new good("HTC", "help_this_company", 10, 100, "HTC.jpg", 0, "", "yan");
            good TestGood3 = new good("Samsong", "Copying_apple_like_a_boss_hue", 10, 50, "3*.jpg", 0, "", "yan");
            
            database.addGood(TestGood2); //HTC was add first
            database.addGood(TestGood3);
            database.addGood(TestGood1);

            List<good> testList = database.getAllGoodByPrice();

            Assert.AreEqual(TestGood1, testList[0]);
            Assert.AreEqual(TestGood2, testList[1]);
            Assert.AreEqual(TestGood3, testList[2]);
        }
    
    }
}
