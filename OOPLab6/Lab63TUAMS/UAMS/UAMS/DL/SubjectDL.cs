using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    internal class SubjectDL
    {
        public static List<Subject> subjectList = new List<Subject>();
        public static void addIntoList(Subject s)
        {
            subjectList.Add(s);
        }
        public static bool readFromFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string record;
            if(File.Exists(path))
            {
                while((record = sr.ReadLine()) != null)
                {
                    string[] split = record.Split(',');
                    addIntoList(new Subject(split[0], split[1], int.Parse(split[2]), int.Parse(split[3])));
                }
                sr.Close();
                return true;
            }
            return false;
        }
        public static void StoreIntoFile(string path, Subject s)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(s.code + "," + s.type + "," + s.creditHours + "," + s.subjectFees);
            sw.Flush();
            sw.Close();
        }
        public static Subject isSubjectExists(string type)
        {
            foreach (Subject s2 in subjectList)
            {
                if (type == s2.type)
                {
                    return s2;
                }
            }
            return null;
        }

    }
}
