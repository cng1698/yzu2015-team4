using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class ChangeAccountInfomation
    {

        static public void ModifyEmailByAccount(string account , string new_email = "")
        {
            List<user> alluser = database.getAllUser();
            for (int i = 0; i < alluser.Count; i++)
            {
                if (alluser[i].account == account)
                {
                    alluser[i] = new user(alluser[i].name, alluser[i].account, alluser[i].pwd,
                        alluser[i].role, new_email, alluser[i].varify_code);
                    break;
                }
            }

            database.dbInit();
            for (int i = 0; i < alluser.Count; i++)
                database.addUser(alluser[i]);

        }

        static public void ModifyPasswordByAccount(string account, string new_pwd = "")
        {
            List<user> alluser = database.getAllUser();
            for (int i = 0; i < alluser.Count; i++)
            {
                if (alluser[i].account == account)
                {
                    alluser[i] = new user(alluser[i].name, alluser[i].account, new_pwd,
                        alluser[i].role, alluser[i].email, alluser[i].varify_code);
                    break;
                }
            }

            database.dbInit();
            for (int i = 0; i < alluser.Count; i++)
                database.addUser(alluser[i]);
        }





    }
}
