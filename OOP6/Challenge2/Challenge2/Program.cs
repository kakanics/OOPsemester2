using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MUser> users = new List<MUser>();
            List<Customer> customers = new List<Customer>();
            List<Product> products = new List<Product>();

            string username = "";
            char choice = '0';
            char innerChoice = '0';
            string role = "";
            while(choice != '3')
            {
                Console.Clear();
                signingMenu();
                choice = Console.ReadLine()[0];
                if(choice == '1')
                {
                    signUp(users, customers);
                }
                if (choice == '2')
                {
                    role = signIn(users, ref username);
                }
                if(role == "A")
                {
                    while(innerChoice!='6')
                    {
                        Console.Clear();
                        adminMenu();
                        innerChoice = Console.ReadLine()[0];
                        if(innerChoice =='1')
                        {
                            AddProduct(products);
                        }
                        if (innerChoice == '2')
                        {
                            viewAll(products);
                        }
                        if (innerChoice == '3')
                        {
                            productWithHighestPrice(products);
                        }
                        if (innerChoice == '4')
                        {
                            viewAllTax(products);
                        }
                        if (innerChoice == '5')
                        {
                            showProductsToOrder(products);
                        }
                        Console.ReadKey();
                    }
                }
                if(role=="C")
                {
                    Customer customer = new Customer(username);
                    while (innerChoice!='4')
                    {
                        Console.Clear();
                        customerMenu();
                        innerChoice = Console.ReadLine()[0];
                        if (innerChoice == '1')
                        {
                            viewAll(products);
                        }
                        if (innerChoice == '2')
                        {
                            buyProduct(customer, products);
                        }
                        if (innerChoice == '3')
                        {
                            Console.WriteLine("Your bill is: "+customer.generateInvoice());
                        }
                        Console.ReadKey();
                    }
                }
            }
        }
        static void signingMenu()
        {
            Console.WriteLine("1. Sign in\n2. Sign up\n3. Exit");
        }
        static void adminMenu()
        {
            Console.WriteLine("1. Add products\n2. view products\n3. find product with highest price\n4. views tax of all products\n5. show products to order\n6. exit");
        }
        static void customerMenu()
        {
            Console.WriteLine("1. view products\n2. buy product\n3. generate invoice\n4. exit");
        }
        static void signUp(List<MUser> users, List<Customer> customers)
        {
            string name, password, role;
            Console.WriteLine("Enter name");
            name = Console.ReadLine();
            Console.WriteLine("Enter password");
            password = Console.ReadLine();
            Console.WriteLine("Enter role (A/C)");
            role = Console.ReadLine();

            if(role=="A"||role=="C")
            {
                MUser user = new MUser(name, password, role);
                users.Add(user);
            }

            if(role == "C")
            {
                customers.Add(new Customer(name));
            }
        }
        static string signIn(List<MUser> users, ref string name)
        {
            string password;
            Console.WriteLine("Enter name");
            name = Console.ReadLine();
            Console.WriteLine("Enter password");
            password = Console.ReadLine();
            string role = "";
            foreach(var i in users)
            {
                if(i.name==name&&i.password==password)
                {
                    role=i.role;
                    break;
                }
            }
            return role;
        }
        static void viewAll(List<Product> list)
        {
            Console.WriteLine("name\tcategory\tprice\tquantity");
            foreach(var item in list)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.name, item.category, item.price, item.quantity);
            }
        }
        static void viewAllTax(List<Product> list)
        {
            Console.WriteLine("name\ttax");
            foreach (var item in list)
            {
                Console.WriteLine("{0}\t{1}", item.name, item.tax());
            }
        }
        static void productWithHighestPrice(List<Product> list)
        {
            int max = 0;
            string name = "";
            foreach (var i in list)
            {
                if (i.price > max)
                {
                    max = i.price;
                    name = i.name;
                }
            }
            Console.WriteLine("The product with max price is: " + name);
        }
        static void showProductsToOrder(List<Product> list)
        {
            Console.WriteLine("name\tcategory\tprice\tquantity");
            foreach (var item in list)
            {
                if(item.buyThis())
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.name, item.category, item.price, item.quantity);
            }
        }
        static void AddProduct(List<Product> list)
        {
            string name, category;
            int price, quantity, threshold;
            Console.WriteLine("Enter name");
            name = Console.ReadLine();
            Console.WriteLine("Enter category");
            category = Console.ReadLine();
            Console.WriteLine("Enter price");
            price =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity");
            quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter threshold");
            threshold = int.Parse(Console.ReadLine());

            Product product = new Product(name, category, price, quantity, threshold);
            list.Add(product);
        }
        static void buyProduct(Customer cust, List<Product> products)
        {
            string name;
            int quantity;
            Console.WriteLine("Enter name");
            name = Console.ReadLine();
            Console.WriteLine("Enter quantity");
            quantity = int.Parse(Console.ReadLine());

            foreach(var i in products)
            {
                if(i.name==name)
                {
                    if(i.quantity>quantity)
                    cust.AddProduct(i, quantity);
                }
            }
        }
    }
}
