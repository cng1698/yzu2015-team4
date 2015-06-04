using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace team4
{
    class Register
    {
        internal static bool CheckName(string name)
        {
            if (name.Length > 0)
                return true;

            return false;
        }

        
        internal static bool CheckAccount(string account)
        {
            if (account.Length > 0 )
                return true;

            return false;
        }

        internal static bool CheckAccountNotExist(string account)
        {

            if (database.getUserByAccount(account).account != null)
                return true;

            return false;
        }

        internal static bool CheckPassword(string password)
        {
            if (password.Length > 0)
                return true;

            return false;
        }

        internal static bool CheckRole(int rolenumber)
        {
            if (rolenumber == 1 || rolenumber == 2)
                return true;

            return false;
        }

        internal static bool CheckEmail(string email)
        {
            bool checkLength = false;
            if (email.Length > 0)
                checkLength = true;

            bool checkType = false;

            char[] splitEmail = email.ToCharArray(); 
            for (int i = 0; i < email.Length; i++)
            {
                if (splitEmail[i] == '@'){
                    checkType = true;
                    break;
                }
            }

            if (checkLength && checkType)
                return true;
            else
                return false;
        }
    }
}
