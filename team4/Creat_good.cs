using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace team4
{
    class Creat_good
    {
        public static bool CheckName(string name)
        {
            if (name == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckContent(string content)
        {
            if (content == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckPrice(int price)
        {
            if (price < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckAmount(int amount)
        {
            if (amount < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckPicture(string picture)
        {
            if (picture == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool SetGood(string name, string content, int price, int amount, string picture, string seller)
        {

            //good temp_good = new good("iPhone", "bank_transfer", 20, 25000, "iPhone.jpg", 50, "\0", "Tim");
            //Assert.IsTrue(team4.database.addGood(temp_good));

            good temp_good = new good(name, content, amount, price, picture, 0, "\0", seller);

            return team4.database.addGood(temp_good);
        }
    }
}
