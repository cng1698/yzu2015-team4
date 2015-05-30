using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Yzu2015team4
{
    class Register
    {
        internal static bool CheckUsernameNotExist(string username)
        {
            StreamReader sr = new StreamReader("member.txt", Encoding.Default);

            string line;
            string[] splitMember;
            while ((line = sr.ReadLine()) != null)
            {
                splitMember = line.Split(new Char[] { ' ' });

                if (splitMember[0] == username)
                {
                    Console.WriteLine("This username exist!");
                    return false;
                }
            }

            return true;
        }

        internal static bool CheckUsername(string username)
        {
            if (username.Length > 0)
                return true;
            else
                Console.WriteLine("You didnt input anything!");

            return false;
        }

        internal static bool CheckPassword(string password)
        {
            if (password.Length > 0)
                return true;
            else
                Console.WriteLine("You didnt input anything!");


            return false;
        }

        internal static void StreamWriteTxt(string username, string password)
        {
            //StreamWriter userDataBase = new StreamWriter(@"C:\secret_plan.txt");
            string currentFolder = Directory.GetCurrentDirectory();

            //FileStream fs = new FileStream(currentFolder + "\\member.txt", FileMode.Create);

            StreamWriter sw = new StreamWriter("member.txt", true, Encoding.Unicode);

            sw.WriteLine(username + " " + password);

            sw.Close();
        }
    }
}
