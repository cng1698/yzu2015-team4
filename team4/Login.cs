using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace team4
{
    class Login
    {
        public static string Check(string account, string password)
        {
            user account_data = database.getUserByAccount(account);
            if(account == "" || password == "")
            {
                return "帳號及密碼不得為空";
            }
            else if(password == account_data.pwd)
            {
                return "登入成功";
            }
            else
            {
                return "帳號或密碼錯誤";
            }
        }

    }
}