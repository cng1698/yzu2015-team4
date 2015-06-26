using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class bid
    {
        public static string Bid(good want , int price , string buyer)
        {
            if (price < want.price)
            {
                return "出價金額過低";
            }
            else if (price > want.bid)
            {
                good NewWant = want;
                NewWant.bid = price;
                NewWant.buyer = buyer;
                database.editGood(want, NewWant);
                return "出價成功";
            }
            else
            {
                return "出價金額未超過目前出價,請重新出價";
            }
        }
    }
}
