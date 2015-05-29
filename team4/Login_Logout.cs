using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace team4
{
    class Login_Logout
    {
        public static void Login()
        {
            bool correct = false;
            string username = "";
            string password = "";
            do
            {
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = loadpassword();
                Console.WriteLine("");
                if (username == "" || password == "")
                {
                    Console.WriteLine("帳號密碼不能空白，請重新輸入");
                }
                else
                {
                    correct = check(username, password);
                    if (!correct)
                    {
                        Console.WriteLine("登入失敗，請重新輸入");
                    }
                    else
                    {
                        Console.WriteLine("登入成功");
                    }
                }
            } while (username == "" || password == "" || !correct);

            Console.ReadLine();
        }
        public static string loadpassword()
        {
            string password = "";
            ConsoleKeyInfo input = Console.ReadKey(true);
            while (input.Key != ConsoleKey.Enter)
            {
                if (input.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += input.KeyChar;
                }
                else
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                input = Console.ReadKey(true);
            }
            return password;
        }
        public static bool check(string username, string password)
        {
            StreamReader sr = new StreamReader("account_dummy_db");
            string srtemp = "";
            string[] account;
            while (srtemp != null)
            {
                srtemp = sr.ReadLine();
                if (srtemp == null)
                {
                    break;
                }
                account = srtemp.Split('\t');
                if (username == account[0])
                {
                    if (password == account[1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    
}
