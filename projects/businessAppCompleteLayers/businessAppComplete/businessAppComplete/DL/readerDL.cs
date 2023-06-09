using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete.DL
{
    internal class readerDL
    {
        public static List<reader> readers = new List<reader>();
        public static reader SignInReader(string name, string password)
        {
            reader reader = null;
            foreach (reader i in readers)
            {
                if (i.compareUser(name, password))
                {
                    reader = i;
                }
            }
            return reader;
        }
        public static void readReadersDataFromFile(string path)
        {
            readers.Clear();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    reader temp = new reader(genericFunctions.parseData(record, 1), genericFunctions.parseData(record, 2));
                    readers.Add(temp);
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
        public static void removeReaderFromFile(string path)
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
