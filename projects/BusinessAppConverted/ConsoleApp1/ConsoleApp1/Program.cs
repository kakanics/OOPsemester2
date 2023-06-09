using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            List<book> books = new List<book>();
            List<user> users = new List<user>();
            string bookInput, authorInput, genreInput, pageNumbersInput, newBookName;
            string input;
            string path = "F:\\study\\sem2\\books.txt";
            string pathUsers = "F:\\study\\sem2\\users.txt";
            string name, password;
            int SignInSignUpChoice = 0;
            bool signedIn = false;
            readBookDataFromFile(path, books);
            while (SignInSignUpChoice != 3)
            {
                Console.Clear();
                readUserDataFromFile(pathUsers, users);
                SignInSignUpChoice = getChoice();
                if (SignInSignUpChoice == 1)
                {
                    Console.WriteLine("Enter you name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    password = Console.ReadLine();
                    if (SignIn(name, password, users))
                    {
                        Console.Write("Successful");
                        signedIn = true;
                    }
                    else
                    {
                        Console.Write("Failed");
                    }
                }
                if (SignInSignUpChoice == 2)
                {
                    Console.WriteLine("Enter you name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    password = Console.ReadLine();
                    SignUp(pathUsers, name, password);
                }
                Console.ReadKey();
                while (option != 5 && signedIn)
                {
                    option = 0;
                    menu();
                    input = Console.ReadLine();
                    if (input != "")
                        if (input[0] > '0' && input[0] <= '5')
                            option = int.Parse(input);
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.ReadKey();
                        }
                    if (option == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter name");
                        bookInput = Console.ReadLine();
                        Console.WriteLine("Enter author");
                        authorInput = Console.ReadLine();
                        Console.WriteLine("Enter genre");
                        genreInput = Console.ReadLine();
                        Console.WriteLine("Enter pages");
                        pageNumbersInput = Console.ReadLine();

                        if (validateStringAsInt(pageNumbersInput))
                        {
                            saveAll(path, books);
                            add(books, bookInput, authorInput, genreInput, int.Parse(pageNumbersInput));
                        }
                        else
                        {
                            Console.Write("FAILED");
                            Console.ReadKey();
                        }
                    }
                    if (option == 2)
                    {
                        listAll(books);
                        Console.ReadKey();
                    }
                    if (option == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter name");
                        bookInput = Console.ReadLine();
                        delete(books, bookInput );
                        saveAll(path, books);
                    }
                    if (option == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter name");
                        bookInput = Console.ReadLine();
                        Console.WriteLine("Enter new name");
                        newBookName = Console.ReadLine();
                        Console.WriteLine("Enter author");
                        authorInput = Console.ReadLine();
                        Console.WriteLine("Enter genre");
                        genreInput = Console.ReadLine();
                        Console.WriteLine("Enter pages");
                        pageNumbersInput = Console.ReadLine();

                        if (validateStringAsInt(pageNumbersInput))
                        {
                            update(books, bookInput, newBookName, authorInput, genreInput, int.Parse(pageNumbersInput));
                            saveAll(path, books);
                        }
                        else
                        {
                            Console.Write("FAILED");
                            Console.ReadKey();
                        }
                    }
                    if (option == 5)
                    {
                        option = 0;
                        signedIn = false;
                    }
                }
            }
        }
        static void menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add book\n2. List all books\n3. delete book\n4. Update book\n5. Exit");
        }
        static void add(List<book> books, string _book, string _author, string _genre, int _page)
        {
            book temp = new book();
            temp.name = _book;
            temp.author = _author;
            temp.genre = _genre;
            temp.pageNumbers = _page;
            books.Add(temp);
        }
        static void listAll(List<book> books)
        {
            Console.Clear();
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books[i].name);
                Console.WriteLine(books[i].author);
                Console.WriteLine(books[i].genre);
                Console.WriteLine(books[i].pageNumbers);
                Console.WriteLine();
            }
        }
        static void delete(List<book> book, string _book)
        {
            for (int i = 0; i < book.Count; i++)
            {
                if (book[i].name == _book)
                {
                    book.RemoveAt(i);
                    Console.WriteLine("Success");
                    break;
                }
            }
            Console.ReadKey();
        }
        static void update(List<book> books, string _book, string _newBook, string _author, string _genre, int _page)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].name == _book)
                {
                    books[i].name = _newBook;
                    books[i].author = _author;
                    books[i].genre = _genre;
                    books[i].pageNumbers = _page;
                    Console.WriteLine("sucess");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("failed");
            Console.ReadKey();
        }
        static string parseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[i];
                }
            }
            return item;
        }

        static void saveAll(string path, List<book> books)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            for (int i = 0; i < books.Count; i++)
            {
                if (i != 0)
                    streamWriter.WriteLine();
                streamWriter.Write("{0},{1},{2},{3}", books[i].name, books[i].author, books[i].genre, books[i].pageNumbers);
            }
            streamWriter.Flush();
            streamWriter.Close();
        }
        static bool validateStringAsInt(string pages)
        {
            bool flag = true;
            int length = pages.Length;
            for (int i = 0; i < length; i++)
            {
                if (!(pages[i] >= '0') || !(pages[i] <= '9'))
                    flag = false;
            }
            return flag;
        }
        static int getChoice()
        {
            string option;
            Console.WriteLine("Option 1: SignIn\nOption 2: SignUp\nEnter Option: ");
            option = Console.ReadLine();
            if (validateStringAsInt(option))
                return int.Parse(option);
            return 0;
        }
        static void readUserDataFromFile(string path,  List<user> users)
        {
            user temp = new user();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    temp.username = parseData(record, 1);
                    temp.password = parseData(record, 2);
                    users.Add(temp);
                }
                sr.Close();
            }
        }
        static void readBookDataFromFile(string path, List<book> books)
        {
            book temp = new book();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    temp.name = parseData(record, 1);
                    temp.genre = parseData(record, 2);
                    temp.author = parseData(record, 3);
                    temp.pageNumbers = int.Parse(parseData(record, 4));
                    books.Add(temp);
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("Does not exist");
            }
        }
        static bool SignIn(string name, string password, List<user> users)
        {
            bool flag = false;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].username == name && password == users[i].password)
                    flag = true;
            }
            return flag;
        }
        static void SignUp(string path, string name, string password)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(name + "," + password);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}