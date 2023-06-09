using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete.DL
{
    internal class adminDL
    {
        public static List<admin> admins = new List<admin>();
        public static admin SignInAdmin(string name, string password)
        {
            admin admin = null;
            foreach (admin i in admins)
            {
                if (i.compareUser(name, password))
                {
                    admin = i;
                }
            }
            return admin;
        }
        public static void blackListUser(string name)
        {
            foreach (var i in readerDL.readers)
                if (name == i.username)
                    i.blackListed = 1;
        }

        public static void approveDonation(string name)
        {
            foreach (book i in booksDL.donatedBooks)
            {
                if (name == i.name)
                {
                    book book = new book(i);
                    booksDL.books.Add(book);
                    booksDL.donatedBooks.Remove(i);
                    break;
                }
            }
        }
        public static void readAdminsDataFromFile(string path)
        {
            admins.Clear();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    admin temp = new admin(genericFunctions.parseData(record, 1), genericFunctions.parseData(record, 2));
                    admins.Add(temp);
                }
                sr.Close();
            }
        }

        public static void SignUp(string path, string name, string password)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(name + "," + password);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
