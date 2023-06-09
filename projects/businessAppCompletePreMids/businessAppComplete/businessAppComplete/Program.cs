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
            int option = 0;
            List<book> books = new List<book>();
            List<book> requestedBooks = new List<book>();
            List<admin> admins = new List<admin>();
            List<reader> readers = new List<reader>();
            reader currentReader = null;
            admin currentAdmin = null;
            string input;
            string path = "F:\\study\\sem2\\books.txt";
            string pathRequestBooks = "F:\\study\\sem2\\Rbooks.txt";
            string pathAdmins= "F:\\study\\sem2\\admin.txt";
            string pathReaders = "F:\\study\\sem2\\readers.txt";
            int SignInSignUpChoice = 0;
            readBookDataFromFile(path, books);
            readBookDataFromFile(pathRequestBooks, requestedBooks);
            readAdminsDataFromFile(pathAdmins, admins);
            readReadersDataFromFile(pathReaders, readers);
            while (SignInSignUpChoice != 3)
            {
                Console.Clear();
                SignInSignUpChoice = getChoice();
                if (SignInSignUpChoice == 1)
                {
                    Console.WriteLine("Enter you name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();
                    currentAdmin = SignInAdmin(name, password, admins);
                    currentReader = SignInReader(name, password, readers);
                }
                if (SignInSignUpChoice == 2)
                {
                    Console.WriteLine("Enter you name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter your role: ");
                    string role = Console.ReadLine();
                    if(role=="admin")
                    {
                        SignUp(pathAdmins, name, password);
                    }
                    else if (role == "reader")
                    {
                        SignUp(pathReaders, name, password);
                    }
                }
                Console.ReadKey();
                while (option != 8 && currentAdmin != null)
                {
                    option = 0;
                    Console.Clear();
                    adminMenu();
                    input = Console.ReadLine();
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
                        addBook(path, books);
                    }
                    if (option == 2)
                    {
                        listAll(books);
                        Console.ReadKey();
                    }
                    if (option == 3)
                    {
                        Console.WriteLine("Enter name");
                        string bookInput = Console.ReadLine();
                        delete(books, bookInput);
                        saveAll(path, books);
                    }
                    if (option == 4)
                    {
                        updateBook(path, books);    
                    }
                    if (option == 5)
                    {
                        blackListUser(readers);
                    }
                    if(option == 6)
                    {
                        listAllDonations(requestedBooks);
                    }
                    if (option == 7)
                    {
                        listAllDonations(requestedBooks);
                        approveDonation(books, requestedBooks);
                        saveAll(path, books);
                    }
                    if (option == 8)
                    {
                        currentAdmin = null;
                        option = 0;
                    }
                } 
                while (option != 8 && currentReader!= null)
                {
                    option = 0;
                    Console.Clear();
                    readerMenu();
                    input = Console.ReadLine();
                    if (input != "")
                        if (input[0] > '0' && input[0] <= '8')
                            option = int.Parse(input);
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.ReadKey();
                        }
                    if (option == 1 && currentReader.blackListed!=1)
                    {
                        issueBook(books, currentReader.username);
                    }
                    if (option == 2 && currentReader.blackListed != 1)
                    {
                        returnBook(books, currentReader.username);
                    }
                    if (option == 3 && currentReader.blackListed != 1)
                    {
                        addBook(pathRequestBooks, requestedBooks);
                    }
                    if (option == 4)
                    {
                        if(currentReader.blackListed == 1)
                        Console.WriteLine("You blacklisting has been lifted");
                        currentReader.blackListed = 0;
                    }
                    if (option == 5 && currentReader.blackListed != 1)
                    {
                        listAll(books);
                    }
                    if (option == 6 && currentReader.blackListed != 1)
                    {
                        listAllDonations(requestedBooks);
                    }
                    if (option == 7 && currentReader.blackListed != 1)
                    {
                        readers.Remove(currentReader);
                        removeReaderFromFile(pathReaders,readers);
                        option = 8;
                    }
                    if(option==8)
                    {
                        currentReader = null;
                    }
                    Console.ReadKey();
                }
            }
        }
        static void adminMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add book\n2. List all books\n3. delete book\n4. Update book\n5. Blacklist User\n6. View Donations\n7. Approve book\n8. exit");
        }
        static void readerMenu()
        {
            Console.Clear();
            Console.WriteLine("1. issue book\n2. return book\n3. donate book\n4. appeal blacklist\n5. view book\n6. rate a book\n7. delete your account\n8. exit");
        }
        static void issueBook(List<book> books, string nameOfreader)
        {
            Console.Clear();
            Console.WriteLine("Enter name of book");
            string name = Console.ReadLine();
            foreach(var i in books)
            {
                if (name == i.name)
                    if (i.issuer == "")
                        i.issuer = nameOfreader;
                    else Console.WriteLine("book already issued");
            }
        }
        static void returnBook(List<book> books, string nameOfreader)
        {
            Console.Clear();
            foreach(var i in books)
            {
                if(i.issuer==nameOfreader)
                {
                    i.issuer=nameOfreader;
                    Console.WriteLine("The book has been returned");
                }
            }
        }

        static void addBook(string path, List<book> books)
        {
            Console.WriteLine("Enter name");
            string bookInput = Console.ReadLine();
            Console.WriteLine("Enter author");
            string authorInput = Console.ReadLine();
            Console.WriteLine("Enter genre");
            string genreInput = Console.ReadLine();
            Console.WriteLine("Enter pages");
            string pageNumbersInput = Console.ReadLine();

            if (validateStringAsInt(pageNumbersInput))
            {
                add(books, bookInput, authorInput, genreInput, int.Parse(pageNumbersInput));
                saveAll(path, books);
            }
            else
            {
                Console.Write("FAILED");
                Console.ReadKey();
            }
        }
        static void add(List<book> books, string _book, string _author, string _genre, int _page)
        {
            book temp = new book(_book, _author, _genre, _page);
            books.Add(temp);
        }
        static void updateBook(string path, List<book> books)
        {
            Console.WriteLine("Enter name");
            string bookInput = Console.ReadLine();
            Console.WriteLine("Enter new name");
            string newBookName = Console.ReadLine();
            Console.WriteLine("Enter author");
            string authorInput = Console.ReadLine();
            Console.WriteLine("Enter genre");
            string genreInput = Console.ReadLine();
            Console.WriteLine("Enter pages");
            string pageNumbersInput = Console.ReadLine();

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
        static void blackListUser(List<reader> readers)
        {
            Console.WriteLine("Enter name of reader to blacklist");
            string name = Console.ReadLine();
            foreach (var i in readers) 
                if (name == i.username) 
                    i.blackListed = 1;
        }
        static void approveDonation(List<book> books, List<book> donatedBook)
        {
            Console.WriteLine("Enter name of book");
            string name = Console.ReadLine();
            foreach(book i in donatedBook)
            {
                if(name == i.name)
                {
                    book book = new book(i);
                    books.Add(book);
                    donatedBook.Remove(i);
                    break;
                }
            }
        }
        static void listAllDonations(List<book> books) 
        {
            Console.Clear();
            foreach (book i in books)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.author);
                Console.WriteLine(i.genre);
                Console.WriteLine(i.pageNumbers);
                Console.WriteLine();
            }
        }
        static void listAll(List<book> books)
        {
            Console.Clear();
            foreach (book i in books)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.author);
                Console.WriteLine(i.genre);
                Console.WriteLine(i.pageNumbers);
                if(i.issuer!="")Console.WriteLine(i.issuer);else Console.WriteLine("not issued");
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
            foreach (book i in books)
            {
                if (i.name == _book)
                {
                    i.changeBookname(_newBook, _author, _genre, _page);
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
                streamWriter.Write("{0},{1},{2},{3},{4}", books[i].name, books[i].author, books[i].genre, books[i].pageNumbers, books[i].issuer);
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
            if (pages == "") return false;
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
        static void readAdminsDataFromFile(string path, List<admin> users)
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    admin temp = new admin(parseData(record, 1), parseData(record, 2));
                    users.Add(temp);
                }
                sr.Close();
            }
        }
        static void readReadersDataFromFile(string path, List<reader> users)
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    reader temp = new reader(parseData(record, 1), parseData(record, 2));
                    users.Add(temp);
                }
                sr.Close();
            }
        }
        static void readBookDataFromFile(string path, List<book> books)
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    book temp = new book(parseData(record, 1), parseData(record, 2), parseData(record, 3), int.Parse(parseData(record, 4)), parseData(record, 5));
                    books.Add(temp);
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("Does not exist");
            }
        }
        static admin SignInAdmin(string name, string password, List<admin> users)
        {
            admin admin = null;
            foreach (admin i in users)
            {
                if (i.compareUser(name, password))
                {
                    admin = i;
                }
            }
            return admin;
        }
        static reader SignInReader(string name, string password, List<reader> users)
        {
            reader reader= null;
            foreach (reader i in users)
            {
                if (i.compareUser(name, password))
                {
                    reader = i;
                }
            }
            return reader;
        }
        static void SignUp(string path, string name, string password)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(name + "," + password);
            streamWriter.Flush();
            streamWriter.Close();
        }
        static void removeReaderFromFile(string path, List<reader> readers)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            for (int i = 0; i < readers.Count; i++)
            {
                if (i != 0)
                    streamWriter.WriteLine();
                streamWriter.Write("{0},{1}", readers[i].username, readers[i].password);
            }
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
