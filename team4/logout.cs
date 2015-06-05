using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace team4
{
    class logoutinput
    {
        static public int sure_logout(string  choose)
        {
            if (choose == "Y")
                return 1;
            else if (choose == "N")
                return 2;
            else
                return 3;
        }

        static public int logout(int logout,string surelogoutchoose)
        {
            int result = 0;
            if (logout == 1)
            {
                if (sure_logout(surelogoutchoose) == 1)
                    result = 1;
                if (sure_logout(surelogoutchoose) == 2)
                    result = 2;
                if (sure_logout(surelogoutchoose) == 3)
                    result = 3;
            }
            else if (logout == 2)
            {
                result = 2;
            }
            else
                result = 4;

            return result;
        }

    }
}