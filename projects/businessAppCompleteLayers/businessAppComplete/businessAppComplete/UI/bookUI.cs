using businessAppComplete.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete
{
    internal class bookUI
    {
        public static book getBook()
        {
            Console.WriteLine("Enter name");
            string bookInput = Console.ReadLine();
            Console.WriteLine("Enter author");
            string authorInput = Console.ReadLine();
            Console.WriteLine("Enter genre");
            string genreInput = Console.ReadLine();
            Console.WriteLine("Enter pages");
            string pageNumbersInput = Console.ReadLine();

            if (genericFunctions.validateStringAsInt(pageNumbersInput))
            {
                return new book(bookInput, authorInput, genreInput, int.Parse(pageNumbersInput));
                //add(books, bookInput, authorInput, genreInput, int.Parse(pageNumbersInput));
                //saveAll(path, books);
            }
            else
            {
                Console.Write("FAILED");
                Console.ReadKey();
                return null;
            }
                }
        public static void updateBook()
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

            if (genericFunctions.validateStringAsInt(pageNumbersInput))
            {
                booksDL.update(bookInput, bookUI.getBook());
            }
            else
            {
                Console.Write("FAILED");
                Console.ReadKey();
            }
        }
        public static void listAll()
            {
                Console.Clear();
                foreach (book i in booksDL.books)
                {
                    Console.WriteLine(i.name);
                    Console.WriteLine(i.author);
                    Console.WriteLine(i.genre);
                    Console.WriteLine(i.pageNumbers);
                    if (i.issuer != "") Console.WriteLine(i.issuer); else Console.WriteLine("not issued");
                    Console.WriteLine();
            }
        }
        public static void listAllDonations()
        {
            Console.Clear();
            foreach (book i in booksDL.donatedBooks)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.author);
                Console.WriteLine(i.genre);
                Console.WriteLine(i.pageNumbers);
                Console.WriteLine();
            }
        }
    }
}
