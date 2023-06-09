using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete.DL
{
    internal class booksDL
    {
        public static List<book> books = new List<book>();
        public static List<book> donatedBooks = new List<book>();
        public static void update(string bookInput, book newbook)
        {
            foreach(book book in books)
            {
                if(book.name==bookInput)
                {
                    book.updateBook(newbook.name, newbook.genre, newbook.author, newbook.pageNumbers);
                }
            }
        }
        public static void add(book book, List<book> books)
        {
            books.Add(book);
        }
        public static void issueBook(string name, string nameOfreader)
        {
            foreach (var i in books)
            {
                if (name == i.name)
                    if (i.issuer == "")
                        i.issuer = nameOfreader;
                    else Console.WriteLine("book already issued");
            }
        }
        public static void returnBook(string nameOfreader)
        {
            Console.Clear();
            foreach (var i in books)
            {
                if (i.issuer == nameOfreader)
                {
                    i.issuer = "";
                    Console.WriteLine("The book has been returned");
                }
            }
        }
        public static void delete(string _book)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].name == _book)
                {
                    books.RemoveAt(i);
                    Console.WriteLine("Success");
                    break;
                }
            }
            Console.ReadKey();
        }
        public static void saveAll(string path, List<book> books)
        {
            StreamWriter streamWriter = new StreamWriter(path, false);
            for (int i = 0; i < books.Count; i++)
            {
                if (i != 0)
                    streamWriter.WriteLine();
                streamWriter.Write("{0},{1},{2},{3},{4}", books[i].name, books[i].author, books[i].genre, books[i].pageNumbers, books[i].issuer);
            }
            streamWriter.Flush();
            streamWriter.Close();
        }
        public static void readBookDataFromFile(string path, List<book> books)
        {
            books.Clear();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    book temp = new book(genericFunctions.parseData(record, 1), genericFunctions.parseData(record, 2), genericFunctions.parseData(record, 3), int.Parse(genericFunctions.parseData(record, 4)), genericFunctions.parseData(record, 5));
                    books.Add(temp);
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("Does not exist");
            }
        }
    }
}
