using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class Email_Varify
    {
        internal static bool verify( int input  , string name ="" )
        {
            user user_data = database.getUserByAccount(name);

            //string input = Console.ReadLine();
 
            if( if_same(user_data.role , input))
                return true ;
            else
                return false ;
        }

        internal static bool if_same( int role_num , int checknum )
        {
            if (role_num == checknum)
                return true ;
            else 
                return false;
        }
    }
}
