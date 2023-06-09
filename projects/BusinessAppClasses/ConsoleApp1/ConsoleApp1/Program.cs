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
        const int arraySize = 50;
        static void Main(string[] args)
        {
            int option = 0;
            string[] books = new string[arraySize];
            string[] authors = new string[arraySize];
            string[] genre = new string[arraySize];
            int[] pageNumbers = new int[arraySize];
            string bookInput, authorInput, genreInput, pageNumbersInput, newBookName;
            int bookCount = 0;
            string input;
            string path = "F:\\study\\sem2\\projectConversion\\userData.txt";
            string pathUsers = "F:\\study\\sem2\\projectConversion\\users.txt";
            string[] passwords = new string[arraySize];
            string[] names = new string[arraySize];
            string name, password;
            int SignInSignUpChoice = 0;
            bool signedIn = false;
            readDataFromFile(path, books, authors, genre, pageNumbers, ref bookCount);
            while (SignInSignUpChoice != 3)
            {
                Console.Clear();
                readUserDataFromFile(pathUsers, names, passwords);
                SignInSignUpChoice = getChoice();
                if (SignInSignUpChoice == 1)
                {
                    Console.WriteLine("Enter you name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    password = Console.ReadLine();
                    if (SignIn(name, password, names, passwords))
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
                        if (bookCount >= arraySize)
                            break;
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
                            saveData(path, bookInput, authorInput, genreInput, int.Parse(pageNumbersInput));
                            add(books, authors, genre, pageNumbers, bookInput, authorInput, genreInput, int.Parse(pageNumbersInput), ref bookCount);
                        }
                        else
                        {
                            Console.Write("FAILED");
                            Console.ReadKey();
                        }
                    }
                    if (option == 2)
                    {
                        listAll(books, authors, genre, pageNumbers, bookCount);
                        Console.ReadKey();
                    }
                    if (option == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter name");
                        bookInput = Console.ReadLine();
                        delete(books, authors, genre, pageNumbers, bookInput, ref bookCount);
                        saveAll(path, books, authors, genre, pageNumbers, bookCount);
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
                            update(books, authors, genre, pageNumbers, bookInput, newBookName, authorInput, genreInput, int.Parse(pageNumbersInput), bookCount);
                            saveAll(path, books, authors, genre, pageNumbers, bookCount);
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
        static void add(string[] books, string[] authors, string[] genre, int[] pages, string _book, string _author, string _genre, int _page, ref int count)
        {
            if (!(count >= arraySize))
            {
                books[count] = _book;
                authors[count] = _author;
                genre[count] = _genre;
                pages[count] = _page;
                count++;
            }
        }
        static void listAll(string[] books, string[] authors, string[] genre, int[] pages, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(books[i]);
                Console.WriteLine(authors[i]);
                Console.WriteLine(genre[i]);
                Console.WriteLine(pages[i]);
                Console.WriteLine();
            }
        }
        static void delete(string[] books, string[] authors, string[] genre, int[] pages, string _book, ref int count)
        {
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                if (books[i] == _book)
                {
                    index = i;
                    Console.WriteLine("Success");
                    break;
                }
            }
            for (int i = index; i < count; i++)
            {
                books[i] = books[i + 1];
                authors[i] = authors[i + 1];
                genre[i] = genre[i + 1];
                pages[i] = pages[i + 1];
            }
            count--;
            Console.ReadKey();
        }
        static void update(string[] books, string[] authors, string[] genre, int[] pages, string _book, string _newBook, string _author, string _genre, int _page, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (books[i] == _book)
                {
                    books[i] = _newBook;
                    authors[i] = _author;
                    genre[i] = _genre;
                    pages[i] = _page;
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
        static void readDataFromFile(string path, string[] books, string[] authors, string[] genre, int[] pageNums, ref int count)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    books[x] = parseData(record, 1);
                    authors[x] = parseData(record, 2);
                    genre[x] = parseData(record, 3);
                    pageNums[x] = int.Parse(parseData(record, 4));
                    x++;
                    if (x >= arraySize)
                    {
                        break;
                    }
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("Does not exist");
            }
            count = x;
        }
        static void saveData(string path, string _book, string _author, string _genre, int _pageNums)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine();
            streamWriter.Write("{0},{1},{2},{3}", _book, _author, _genre, _pageNums);
            streamWriter.Flush();
            streamWriter.Close();
        }

        static void saveAll(string path, string[] books, string[] author, string[] genre, int[] pageNums, int count)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            for (int i = 0; i < count; i++)
            {
                if (i != 0)
                    streamWriter.WriteLine();
                streamWriter.Write("{0},{1},{2},{3}", books[i], author[i], genre[i], pageNums[i]);
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
        static void readUserDataFromFile(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 50)
                    {
                        break;
                    }
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("Does not exist");
            }
        }
        static bool SignIn(string name, string password, string[] names, string[] passwords)
        {
            bool flag = false;
            for (int i = 0; i < 50; i++)
            {
                if (name == names[i] && password == passwords[i])
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
