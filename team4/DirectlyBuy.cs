using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class DirectlyBuy
    {
        public static string Buy(good want,string buyer)
        {
            if(want.amount < 1)
            {
                return "已售完";
            }
            else
            {
                want.buyer = buyer;
                want.amount--;
                return "購買成功";
                //save to db
            }
        }
    }
}
