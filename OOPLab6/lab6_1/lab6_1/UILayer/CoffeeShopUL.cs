using lab6_1.businessLayer;
using lab6_1.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_1.UILayer
{
    internal class CoffeeShopUL
    {
        static string coffeeShopName = "Affan's Coffee Shop";
        public static char menu(CoffeeShop shop)
        {
            char c = '0';
            Console.WriteLine("Welcome to "+shop.name);
            Console.WriteLine("1. Add a menu item");
            Console.WriteLine("2. Chose the cheapest item in menu");
            Console.WriteLine("3. view Drink's menu");
            Console.WriteLine("4. view food's menu");
            Console.WriteLine("5. Add order");
            Console.WriteLine("6. Fulfill order");
            Console.WriteLine("7. view order's list");
            Console.WriteLine("8. Total payable amount");
            Console.WriteLine("9. exit");
            c = Console.ReadLine()[0];
            return c;
        }
        public static MenuItem makeMenuItem()
        {
            string name, type;
            int price;
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter type: ");
            type = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            price= int.Parse(Console.ReadLine());
            return new MenuItem(name, type, price);
        }
        public static void showCheapestItem()
        {
            Console.WriteLine(CoffeeShopDL.cheapestItem(coffeeShopName));
        }
        public static void viewAllFood()
        {
            List<string> itemsToShow = CoffeeShopDL.foodOnly(coffeeShopName);
            foreach (string item in itemsToShow)
            {
                Console.WriteLine(item);
            }
        }
        public static void viewAllDrinks()
        {
            List<string> itemsToShow = CoffeeShopDL.drinksOnly(coffeeShopName);
            foreach (string item in itemsToShow)
            {
                Console.WriteLine(item);
            }
        }
        public static string addOrder()
        {
            Console.WriteLine("Enter what you want to order");
            string order = Console.ReadLine();
            return order;
        }
        public static void orderList()
        {
            foreach(var i in CoffeeShopDL.shopGetter(coffeeShopName).orders)
            {
                Console.WriteLine(i);
            }
        }
        public static void totalPayableAmount()
        {
            Console.WriteLine(CoffeeShopDL.dueAmount(coffeeShopName));
        }
        public static void fulfilOrder()
        {
            Console.WriteLine(CoffeeShopDL.fulfilOrder(coffeeShopName));
        }
    }
}
