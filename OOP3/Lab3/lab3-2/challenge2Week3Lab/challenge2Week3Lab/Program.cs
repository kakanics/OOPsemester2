using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace challenge2Week3Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<string> ThingsToBuy;
            int x = 0;

            while (x!=6)
            {
                Console.Clear();
                x = menu();
                if (x == 1)
                {
                    Console.Clear();
                    products.Add(AddProduct());
                }
                if(x==2)
                {
                    Console.Clear();
                    ListAll(products);
                }
                if (x == 3)
                {
                    Console.Clear();
                    Console.WriteLine(findMostExpensiveProduct(products));
                }
                if (x == 4)
                {
                    Console.Clear();
                    ListTax(products);
                }
                if (x == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Enter threshold value: ");
                    int threshold = int.Parse(Console.ReadLine());
                    ThingsToBuy = ProductToBuy(products, threshold);
                    ListProductsToBuy(ThingsToBuy);
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        static int menu()
        {
            Console.WriteLine("1: Add product");
            Console.WriteLine("2: List product");
            Console.WriteLine("3: Most expensive product");
            Console.WriteLine("4: Show all taxes");
            Console.WriteLine("5: Show products to buy");
            Console.WriteLine("6: Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static Product AddProduct()
        {
            string name;
            string category;
            int price;
            int quantity;
            int minquanity;

            Console.WriteLine("Enter the name of product");
            name = Console.ReadLine();
            Console.WriteLine("Enter the category of product");
            category = Console.ReadLine();
            Console.WriteLine("Enter the price of product");
            price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the quanity of product");
            quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter min quantity of product");
            minquanity = int.Parse(Console.ReadLine());

            Product result = new Product(name, category, price, quantity, minquanity);
            return result;

        }
        static void ListAll(List<Product> products)
        {
            foreach (Product i in products)
            {
                Console.WriteLine("Name: {0}", i.name);
                Console.WriteLine("Category: {0}", i.category);
                Console.WriteLine("Price: {0}", i.price);
                Console.WriteLine("Quantity: {0}", i.quantity);
                Console.WriteLine("Minimum Quantity: {0}", i.minQuantity);
                Console.WriteLine();
            }
        }
        static string findMostExpensiveProduct(List<Product> products)
        {
            string name = products[0].name;
            int max = products[0].price;
            foreach(Product i in products) 
            {
                if(i.price > max)
                {
                    name = i.name;
                    max = i.price;
                }
            }
            return name;
        }

        static void ListTax(List<Product> products)
        {
            foreach (Product i in products)
            {
                Console.WriteLine("Name: {0}", i.name);
                if(i.category=="grocery")
                {
                    Console.WriteLine("10% Tax");
                }
                else if (i.category == "fruit")
                {
                    Console.WriteLine("5% Tax");
                }
                else
                {
                    Console.WriteLine("15% Tax");
                }
                Console.WriteLine();
            }
        }
        static List<string> ProductToBuy(List<Product> products, int thresholdValue)
        {
            List<string> list = new List<string>();
            foreach(Product i in products)
            {
                float price= i.price;
                if(i.category=="fruit")
                {
                    price *= 1.05f;
                }
                else if (i.category == "grocery")
                {
                    price *= 1.1f;
                }
                else 
                {
                    price *= 1.15f;
                }
                if(price < thresholdValue)
                {  
                    list.Add(i.name); 
                }
            }
            return list;
        }
        static void ListProductsToBuy(List<string> names)
        {
            foreach(string i in names)
            {
                Console.WriteLine(i);
            }
        }
    }
}
