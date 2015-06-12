using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class search
    {
        public static string SearchName(string name)
        {
            return team4.database.getGoodByName(name).name;
        }
        public static string SearchContent(string name)
        {
            return team4.database.getGoodByName(name).content;
        }
    }
}
