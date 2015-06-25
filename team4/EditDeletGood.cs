using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class EditDeletGood
    {
        public static bool EditName(string name,string n)
        {
            good temp_good = new good(n, team4.database.getGoodByName(name).content, team4.database.getGoodByName(name).amount, team4.database.getGoodByName(name).price, team4.database.getGoodByName(name).picture, team4.database.getGoodByName(name).bid, team4.database.getGoodByName(name).buyer, team4.database.getGoodByName(name).seller);
            return team4.database.editGood(team4.database.getGoodByName(name), temp_good);
        }

        public static bool EditContent(string name, string c)
        {
            good temp_good = new good( team4.database.getGoodByName(name).name, c, team4.database.getGoodByName(name).amount, team4.database.getGoodByName(name).price, team4.database.getGoodByName(name).picture, team4.database.getGoodByName(name).bid, team4.database.getGoodByName(name).buyer, team4.database.getGoodByName(name).seller);
            return team4.database.editGood(team4.database.getGoodByName(name), temp_good);
        }

        public static bool EditAmount(string name, int a)
        {
            good temp_good = new good(team4.database.getGoodByName(name).name, team4.database.getGoodByName(name).content, a, team4.database.getGoodByName(name).price, team4.database.getGoodByName(name).picture, team4.database.getGoodByName(name).bid, team4.database.getGoodByName(name).buyer, team4.database.getGoodByName(name).seller);
            return team4.database.editGood(team4.database.getGoodByName(name), temp_good);
        }

        public static bool EditPrice(string name, int p)
        {
            good temp_good = new good(team4.database.getGoodByName(name).name, team4.database.getGoodByName(name).content, team4.database.getGoodByName(name).amount, p, team4.database.getGoodByName(name).picture, team4.database.getGoodByName(name).bid, team4.database.getGoodByName(name).buyer, team4.database.getGoodByName(name).seller);
            return team4.database.editGood(team4.database.getGoodByName(name), temp_good);
        }

        public static bool EditPicture(string name, string p)
        {
            good temp_good = new good(team4.database.getGoodByName(name).name, team4.database.getGoodByName(name).content, team4.database.getGoodByName(name).amount, team4.database.getGoodByName(name).price, p, team4.database.getGoodByName(name).bid, team4.database.getGoodByName(name).buyer, team4.database.getGoodByName(name).seller);
            return team4.database.editGood(team4.database.getGoodByName(name), temp_good);
        }

        public static bool Delet(string name)
        {
            return team4.database.deletGood(team4.database.getGoodByName(name));
        }
    }
}
