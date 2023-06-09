using businessAppComplete.DL;
using businessAppComplete.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Library Management System:>";
            int option = 0;
            reader currentReader = null;
            admin currentAdmin = null;
            string input;
            string path = "F:\\study\\sem2\\books.txt";
            string pathRequestBooks = "F:\\study\\sem2\\Rbooks.txt";
            string pathAdmins = "F:\\study\\sem2\\admin.txt";
            string pathReaders = "F:\\study\\sem2\\readers.txt";
            int SignInSignUpChoice = 0;
            booksDL.readBookDataFromFile(path, booksDL.books);
            booksDL.readBookDataFromFile(pathRequestBooks, booksDL.donatedBooks);
            adminDL.readAdminsDataFromFile(pathAdmins);
            readerDL.readReadersDataFromFile(pathReaders);
            while (SignInSignUpChoice != 3)
            {
                Console.Clear();
                SignInSignUpChoice = genericUI.getChoice();
                if (SignInSignUpChoice == 1)
                {
                    Console.WriteLine("Enter you name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();
                    currentAdmin = adminDL.SignInAdmin(name, password);
                    currentReader = readerDL.SignInReader(name, password);
                }
                if (SignInSignUpChoice == 2)
                {
                    Console.WriteLine("Enter you name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter your role: ");
                    string role = Console.ReadLine();
                    if (role.ToLower() == "admin")
                    {
                        adminDL.SignUp(pathAdmins, name, password);
                    }
                    else if (role.ToLower() == "reader")
                    {
                        readerDL.SignUp(pathReaders, name, password);
                    }
                    adminDL.readAdminsDataFromFile(pathAdmins);
                    readerDL.readReadersDataFromFile(pathReaders);
                }
                Console.ReadKey();
                while (option != 8 && currentAdmin != null)
                {
                    option = 0;
                    Console.Clear();
                    input = adminUL.adminMenu();
                    if (input != "")
                        if (input[0] > '0' && input[0] <= '8')
                            option = int.Parse(input);
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.ReadKey();
                        }
                    if (option == 1)
                    {
                        booksDL.add(bookUI.getBook(), booksDL.books);
                        booksDL.saveAll(path, booksDL.books);
                    }
                    if (option == 2)
                    {
                        bookUI.listAll();
                        Console.ReadKey();
                    }
                    if (option == 3)
                    {
                        string bookInput = genericUI.getField();
                        booksDL.delete(bookInput);
                        booksDL.saveAll(path, booksDL.books);
                    }
                    if (option == 4)
                    {
                        booksDL.update(Console.ReadLine(), bookUI.getBook());
                        booksDL.saveAll(path, booksDL.books);
                    }
                    if (option == 5)
                    {
                        adminDL.blackListUser(genericUI.getField());
                    }
                    if (option == 6)
                    {
                        bookUI.listAllDonations();
                    }
                    if (option == 7)
                    {
                        bookUI.listAllDonations();
                        adminDL.approveDonation(genericUI.getField());
                        booksDL.saveAll(pathRequestBooks, booksDL.donatedBooks);
                        booksDL.saveAll(path, booksDL.books);
                    }
                    if (option == 8)
                    {
                        option = 0;
                        currentAdmin = null;
                    }
                    Console.ReadKey();
                    booksDL.readBookDataFromFile(path, booksDL.books);
                    booksDL.readBookDataFromFile(pathRequestBooks, booksDL.donatedBooks);
                    booksDL.saveAll(path, booksDL.books);
                }
                while (option != 8 && currentReader != null)
                {
                    option = 0;
                    Console.Clear();
                    input = readerUL.readerMenu();
                    if (input != "")
                        if (input[0] > '0' && input[0] <= '8')
                            option = int.Parse(input);
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.ReadKey();
                        }
                    if (option == 1 && currentReader.blackListed != 1)
                    {
                        booksDL.issueBook(genericUI.getField(), currentReader.username);
                        booksDL.saveAll(path, booksDL.books);
                    }
                    if (option == 2 && currentReader.blackListed != 1)
                    {
                        booksDL.returnBook(currentReader.username);
                        booksDL.saveAll(path, booksDL.books);
                    }
                    if (option == 3 && currentReader.blackListed != 1)
                    {
                        booksDL.add(bookUI.getBook(), booksDL.donatedBooks);
                        booksDL.saveAll(pathRequestBooks, booksDL.donatedBooks);
                    }
                    if (option == 4)
                    {
                        if (currentReader.blackListed == 1)
                            Console.WriteLine("You blacklisting has been lifted");
                        currentReader.blackListed = 0;
                    }
                    if (option == 5 && currentReader.blackListed != 1)
                    {
                        bookUI.listAll();
                    }
                    if (option == 6 && currentReader.blackListed != 1)
                    {
                        bookUI.listAllDonations();
                    }
                    if (option == 7 && currentReader.blackListed != 1)
                    {
                        readerDL.readers.Remove(currentReader);
                        readerDL.removeReaderFromFile(pathReaders);
                        option = 8;
                    }
                    if (option == 8)
                    {
                        option = 0;
                        currentReader = null;
                    }
                    booksDL.readBookDataFromFile(path, booksDL.books);
                    booksDL.readBookDataFromFile(pathRequestBooks, booksDL.donatedBooks);
                    Console.ReadKey();
                }
            }
        }
    }
}
