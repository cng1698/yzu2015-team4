using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_good
{
    class good
    {
        static public string add_good(string user, string name, string contract){
            string data = user + "\t" + name + "\t" + contract;
            try
            {
                System.IO.File.WriteAllText(@"..\..\..\dummy_db", data);
            }
            catch{
                return "Fail";
            }
            return "Success";
        
        }
        public int aa()
        {
            return 1;
        }
    }
}
