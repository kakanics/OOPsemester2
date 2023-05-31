using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1;
class main
{
    static void Main()
    {
        Console.WriteLine("Note: all inputs are hardcoded");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Task 1: ");
        Task1();
        Console.Clear();
        Console.WriteLine("Task 2: ");
        Task2();
        Console.Clear();
        Console.WriteLine("Task 3: ");
        Task3();
        Console.Clear();
    }
    static void Task1()
    {
        Student student = new Student("Affan", 25, 3.7f, 998, 995, 190, "Dera Ghazi Khan", true, false);
        if (student.isEligibleForScholarship(50.0f))
        {
            Console.WriteLine("is eligible for scholarship");
        }
        else
        {
            Console.WriteLine("not eligible for scholarship");
        }
        Console.ReadKey();
    }
    static void Task2()
    {
        List<string> chapter = new List<string>();
        chapter.Add("world");
        chapter.Add("of");
        chapter.Add("nobody");
        Book book = new Book("Death", 200, chapter, 2, 100);
        Console.WriteLine("Before setting bookMark " + book.getBookMark());
        book.setBookMark(6);
        Console.WriteLine("After setting bookMark " + book.getBookMark());
        Console.WriteLine("Price before setting " + book.getPrice());
        book.setPrice(500);
        Console.WriteLine("Price after setting " + book.getPrice());
        Console.WriteLine("Price before setting " + book.getPrice());
        Console.ReadKey();
    }
    static void Task3()
    {
        List<Product> products = new List<Product>();
        Product _product = new Product("egg", "food", 25);
        products.Add(_product);
        _product = new Product("bread", "food", 35);
        products.Add(_product);

        Customer customer = new Customer("Affan", "Edhi hall, room XYZ","+92 312 4910729", products);
        Console.WriteLine("Total price of stuff bought "+customer.getTotalPrice());
        Console.WriteLine("Total tax of stuff bought "+ customer.CalculateTotalTax());
        Console.ReadKey();
    }
}