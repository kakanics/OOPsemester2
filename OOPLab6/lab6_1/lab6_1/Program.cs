using lab6_1.businessLayer;
using lab6_1.DL;
using lab6_1.UILayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char choice = '0';
            string coffeeShopName = "Affan's Coffee Shop";          //multiple shops are supported, but only this one is used as per requirement in the manual
            CoffeeShop shop = new CoffeeShop("Affan's Coffee Shop");
            CoffeeShopDL.cs.Add(shop);
            CoffeeShopDL.readItems(coffeeShopName);
            CoffeeShopDL.readOrders(coffeeShopName);
            while (choice != '9')
            {
                Console.Clear();
                choice = CoffeeShopUL.menu(shop);
                if(choice == '1')
                {
                    CoffeeShopDL.shopGetter(coffeeShopName).items.Add(CoffeeShopUL.makeMenuItem());
                }
                if (choice == '2')
                {
                    CoffeeShopUL.showCheapestItem();
                }
                if (choice == '3')
                {
                    CoffeeShopUL.viewAllDrinks();
                }
                if (choice == '4')
                {
                    CoffeeShopUL.viewAllFood();
                }
                if (choice == '5')
                {
                    CoffeeShopDL.shopGetter(coffeeShopName).orders.Add(CoffeeShopUL.addOrder());
                }
                if (choice == '6')
                {
                    CoffeeShopUL.fulfilOrder();
                }
                if (choice == '7')
                {
                    CoffeeShopUL.orderList();
                }
                if (choice == '8')
                {
                    CoffeeShopUL.totalPayableAmount();
                }
        //        CoffeeShopDL.writeItems(coffeeShopName);
        //        CoffeeShopDL.writeOrders(coffeeShopName);
                Console.ReadKey();
            }    
        }
    }
}
