using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{

    public struct account_varify
    {
        public string account, verification_code;

        public account_varify(string a, string b)
        {
            account = a;
            verification_code = b;
        }
    }


    class Email_Varify
    {

        internal static bool verify()
        {
            account_varify user = new account_varify();
            user.account = "Jerry";
            user.verification_code = produce_code();

            string input = Console.ReadLine();


            if( if_same(user.verification_code , input))
                return true ;
            else
                return false ;

        }

        internal static string produce_code()
        {
            string code = "abcd";

            /*int i = 0 ;
            while (i < 4)
            {
                code += 
                i++;
            }*/
            return code;
        }

        internal static bool if_same( string a , string b )
        {
            if( a== b )
                return true ;
            else 
                return false;
        }
    }
}
