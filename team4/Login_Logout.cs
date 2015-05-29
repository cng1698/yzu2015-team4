using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class Login_Logout
    {
        static void Login()
        {
            string username;
            string password;
            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = loadpassword();
            Console.WriteLine(password);
            Console.ReadLine();
        }
        static string loadpassword()
        {
            string password = "";
            ConsoleKeyInfo input = Console.ReadKey(true);
            while (input.Key != ConsoleKey.Enter)
            {
                if(input.Key != ConsoleKey.Backspace)
                {
                    Console.WriteLine("*");
                    password += input.KeyChar;
                }
                else
                {
                    password = password.Substring(0, password.Length - 1);
                }
            }
            return password;
        }
    }
}
