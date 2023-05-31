using lab6_1.businessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_1.DL
{
    internal class CoffeeShopDL
    {
        public static List<CoffeeShop> cs = new List<CoffeeShop>();

        public static CoffeeShop shopGetter(string s)
        {
            foreach(var i in cs)
            {
                if(s==i.name)
                {
                    return i;
                }
            }
            return null;
        }
        public static  void addMenuItem(MenuItem item, string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            shopToUse.items.Add(item);
        }
        public static void addOrder(string order, string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            shopToUse.orders.Add(order);
        }
        public static string fulfilOrder(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            string s;
            if (shopToUse.orders.Count == 0)
            {
                return "All orders have been fulfilled";
            }
            s = shopToUse.orders[0] + " has been fulfilled";
            shopToUse.orders.RemoveAt(0);
            return s;
        }
        public static List<string> listOrders(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            return shopToUse.orders;
        }
        public static int dueAmount(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            int total = 0;
            foreach (string s in shopToUse.orders)
            {
                foreach (MenuItem item in shopToUse.items)
                {
                    if (s == item.name)
                    {
                        total += item.price;
                    }
                }
            }
            return total;
        }
        public static string cheapestItem(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            int min = shopToUse.items[0].price;
            string s = "";
            foreach (var i in shopToUse.items)
            {
                if (i.price < min)
                {
                    min = i.price;
                    s = i.name;
                }
            }
            return s;
        }
        public static List<string> foodOnly(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            List<string> result = new List<string>();
            foreach (var i in shopToUse.items)
            {
                if (i.type == "food")
                {
                    result.Add(i.name);
                }
            }
            return result;
        }
        public static List<string> drinksOnly(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            List<string> result = new List<string>();
            foreach (var i in shopToUse.items)
            {
                if (i.type == "drink")
                {
                    result.Add(i.name);
                }
            }
            return result;
        }
        public static void writeItems(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            StreamWriter sw = new StreamWriter("items.txt");
            foreach(var i in shopToUse.items)
            {
                sw.WriteLine(i.name+","+i.type+","+i.price);
            }
            sw.Close();
        }
        public static void readItems(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            StreamReader sr = new StreamReader("items.txt");
            string line = "";
            string[] fields;
            while((line = sr.ReadLine())!=null)
            {
                fields = line.Split(',');
                shopToUse.items.Add(new MenuItem(fields[0], fields[1], int.Parse(fields[2])));
            }
            sr.Close();
        }
        public static void writeOrders(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            StreamWriter sw = new StreamWriter("orders.txt");
            foreach (var i in shopToUse.orders)
            {
                sw.WriteLine(i);
            }
            sw.Close();
        }
        public static void readOrders(string shop)
        {
            CoffeeShop shopToUse = shopGetter(shop);
            StreamReader sr = new StreamReader("orders.txt");
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                shopToUse.orders.Add(line);
            }
            sr.Close();
        }
    }
}
