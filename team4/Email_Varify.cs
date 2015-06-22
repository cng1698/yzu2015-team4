using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{

   /* public struct account_varify
    {
        public string account, verification_code;

        public account_varify(string a, string b)
        {
            account = a;
            verification_code = b;
        }
    }
    */

    class Email_Varify
    {
        internal static void send_mail(string account = "")
        {
            user user_data = database.getUserByAccount(account);
            //send mail to user_data.email ;

        }



        internal static bool verify( int input , string email = "")
        {
           /* account_varify user = new account_varify();
            user.account = "Jerry";
            user.verification_code = produce_code();

            string input = Console.ReadLine();


            if( if_same(user.verification_code , input))
                return true ;
            else
                return false ;*/

            user user_data = database.getUserByEmail(email);


            if ( if_same(user_data.varify_code, input.ToString()))
                return true;
            else
                return false;

        }


        /*internal static string produce_code()
        {
            string code = "abcd";

            int i = 0 ;
            while (i < 4)
            {
                code += 
                i++;
            }
            return code;
        }*/

        internal static bool if_same( string varify_code , string input )
        {
            if (varify_code == input)
                return true ;
            else 
                return false;
        }

    }
}
