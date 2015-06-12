using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace team4
{
    public struct user
    {
        public string name;
        public string account;
        public string pwd;
        public int role;
        public string email;
        
		//public int id;
		
		public user(string name_in, string account_in, string pwd_in, int role_in, string email_in)//id should be auto assigned by database
		{
				name = name_in;
				account = account_in;
				pwd = pwd_in;
				role = role_in;
				email = email_in;
		}
        public static bool operator ==(user usr1, user usr2)
        {
            if (usr1.Equals(usr2))
                return true;
            else
                return false;
        }
        public static bool operator !=(user usr1, user usr2)
        {
            if (usr1.Equals(usr2))
                return false;
            else
                return true;
        }
    }

    public struct good
    {
        public string name;
        public string content;
        public int amount;
        public int price;
        public string picture;
        public int bid;
        public string buyer;
        public string seller;
		
		public good(string name_in, string content_in, int amount_in, int price_in, string picture_in, int bid_in, string buyer_in, string seller_in)
		{
			name = name_in;
			content = content_in;
			amount = amount_in;
			price = price_in;
			picture = picture_in;
			bid = bid_in;
			buyer = buyer_in;
			seller = seller_in;
		}
        public static bool operator ==(good good1, good good2)
        {
            if (good1.Equals(good2))
                return true;
            else
                return false;
        }
        public static bool operator !=(good good1, good good2)
        {
            if (good1.Equals(good2))
                return false;
            else
                return true;
        }
    }

    class database
    {
        public static string account_path = @"..\..\..\database\account_db_dummy";
        public static string good_path = @"..\..\..\database\good_db_dummy";
		public static char[] split_delim = { '\t' };

        static public void dbInit()
        {
            File.Delete(account_path);
            File.Delete(good_path);
        }

        static public bool addUser(user new_user)
        {
			string data = new_user.name + "\t" + new_user.account + "\t" + new_user.pwd + "\t" + new_user.role.ToString() + "\t" + new_user.email + "\n";

            try
            {
                System.IO.File.AppendAllText(account_path, data);
            }
            catch{
                return false;
            }
            
            return true;
		}
		
        static public user getUserByAccount(string account)//get user by account, return it, if not exist, return a user with all filds are initialized
        {
			System.IO.StreamReader file = new System.IO.StreamReader(@account_path);
            string line;
			while((line = file.ReadLine()) != null)
			{
				string[] data_set = line.Split(split_delim);
				if(data_set[1] == account)
				{
                    user res = new user(data_set[0], data_set[1], data_set[2], Convert.ToInt32(data_set[3]), data_set[4]);
                    file.Close();
                    return res;
				}
			}
            file.Close();
            user temp = new user();//empty user
            return temp;
        }

        static public List<user> getAllUser()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@account_path);
            string line;
            List<user> userList = new List<user>{};
            while ((line = file.ReadLine()) != null)
            {
                string[] data_set = line.Split(split_delim);
                user res = new user(data_set[0], data_set[1], data_set[2], Convert.ToInt32(data_set[3]), data_set[4]);
                userList.Add(res);
            }
            file.Close();
            return userList;
        }

        static public bool writeBackUser(List<user> userList)
        {
            foreach (user usr in userList)
            {
                string data = usr.name + "\t" + usr.account + "\t" + usr.pwd + "\t" + usr.role.ToString() + "\t" + usr.email + "\n";

                try
                {
                    System.IO.File.AppendAllText(account_path, data);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        static public bool editUser(user ori, user res)//the origin user -> the result user
        {
            List<user> userList = getAllUser();
            foreach (user usr in userList)
            {
                if (usr == ori)
                {
                    userList.Remove(usr);
                    userList.Add(res);
                    writeBackUser(userList);
                    return true;
                }
            }
            return false;
        }

        static public bool addGood(good new_good)
        {
            string data = new_good.name + "\t" + new_good.content + "\t" + new_good.amount.ToString() + "\t" + new_good.price.ToString() + "\t"
                    + new_good.picture + "\t" + new_good.bid.ToString() + "\t" + new_good.buyer + "\t" + new_good.seller + "\n";

            try
            {
                System.IO.File.AppendAllText(good_path, data);
            }
            catch
            {
                return false;
            }

            return true;
        }

        static public good getGoodByName(string name)//get user by account, return it, if not exist, return a user with all filds are initialized
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@good_path);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] data_set = line.Split(split_delim);
                if (data_set[0] == name)
                {
                    good res = new good(data_set[0], data_set[1], Convert.ToInt32(data_set[2]), Convert.ToInt32(data_set[3]), data_set[4], Convert.ToInt32(data_set[5]), data_set[6], data_set[7]);
                    file.Close();
                    return res;
                }
            }
            file.Close();
            good temp = new good();//empty good
            return temp;
        }

        static public List<good> getAllGood()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@good_path);
            string line;
            List<good> goodList = new List<good> { };
            while ((line = file.ReadLine()) != null)
            {
                string[] data_set = line.Split(split_delim);
                good res = new good(data_set[0], data_set[1], Convert.ToInt32(data_set[2]), Convert.ToInt32(data_set[3]), data_set[4], Convert.ToInt32(data_set[5]), data_set[6], data_set[7]);
                goodList.Add(res);
            }
            file.Close();
            return goodList;
        }
    }
}
