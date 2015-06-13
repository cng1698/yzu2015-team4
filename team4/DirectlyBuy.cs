using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class DirectlyBuy
    {
        public static string Buy(good want,string buyer,int NumberOfgood)
        {
            if(want.amount < 1)
            {
                return "已售完";
            }
            else if(want.amount < NumberOfgood)
            {
                return "庫存不足";
            }
            else
            {
                good NewWant = want;
                NewWant.buyer = buyer;
                NewWant.amount -= NumberOfgood;
                database.editGood(want, NewWant);
                return "購買成功";
            }
        }
    }
}
