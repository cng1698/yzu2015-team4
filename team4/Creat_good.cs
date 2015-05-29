using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team4
{
    class Creat_good
    {
        public static void Creat()
        {
            string name,content,temp;
            int price, amount, tempx;

            Console.Write("新增商品");
            Console.Write("商品名稱: ");
            temp = Console.ReadLine();
            while( temp== "")
            {
                Console.Write("商品名稱不得為空，請再輸入一次!");
                temp = Console.ReadLine();
            }
            name = temp;
            Console.Write("商品描述: ");
            content = Console.ReadLine();
            Console.Write("商品價格: ");
            tempx = Console.Read();
            while (temp == "")
            {
                Console.Write("商品價格不得為空，請再輸入一次!");
                tempx = Console.Read();
            }
            price = tempx;
            Console.Write("商品數量: ");
            tempx = Console.Read();
            while (temp == "")
            {
                Console.Write("商品數量不得為空，請再輸入一次!");
                tempx = Console.Read();
            }
            amount = tempx;
            Creatset(name, content, price, amount);
        }
        public static void Creatset(string name, string content, int price, int amount)
        {
            //string seller;
            int select;

            Console.Write("(1)確定  (2)重製  (3)取消");
            select = Console.Read();
            if (select == 1)
            {

            }
            else if (select == 2)
            {
                Creat();
            }
            else if (select == 3)
            {

            }
        }
    }
}
