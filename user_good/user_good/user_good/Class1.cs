using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_good
{
    class good
    {
        static public string add_good(string user, string name)
        {
            string data = user + "\t" + name;
            try
            {
                System.IO.File.WriteAllText(@"..\..\..\goods_dummy_db", data);
            }
            catch{
                return "Fail";
            }
            return "Success";
        
        }
        static public string add_account(string account, string passwd, string email)
        {
            string data = account + "\t" + passwd + "\t" + email;
            try
            {
                System.IO.File.WriteAllText(@"..\..\..\account_dummy_db", data);
            }
            catch
            {
                return "Fail";
            }
            return "Success";
        }
    }
}
