using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    internal class StudentDL
    {
        public static List<Student> studentList = new List<Student>();

        public static void addStudentIntoList(Student s)
        {
            studentList.Add(s);
        }
        public static Student present(string name)
        {
            foreach(var i in studentList)
            {
                if(name == i.name && i.regDegree!=null)
                {
                    return i;
                }
            }
            return null;
        }
        public static List<Student> sort()
        {
            List<Student> sortedStudentList = new List<Student>();
            foreach(var student in studentList)
            {
                student.calculateMerit();
            }
            sortedStudentList=studentList.OrderByDescending(s => s.merit).ToList();
            return sortedStudentList;
        }
        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach(Student s in sortedStudentList) 
            {
                foreach(DegreeProgram d in s.preferences)
                {
                    if(d.seats>0&&s.regDegree==null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        public static void storeIntoFile(string path, Student s)
        {
            StreamWriter sw = new StreamWriter(path);
            string degreeName = "";
            for(int i = 0; i < s.preferences.Count-1; i++) 
            {
                degreeName += s.preferences[i]+";";
            }
            degreeName += s.preferences[s.preferences.Count-1];
            sw.WriteLine(s.name + "," + s.age + "," + s.fscMarks + "," + s.ecatMarks + "," + degreeName);
            sw.Flush();
            sw.Close();
        }
        public static bool loadFromFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string line;
            if (File.Exists(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] split = line.Split(',');
                    string Name = split[0];
                    int age = int.Parse(split[1]);
                    double fscMarks = double.Parse(split[2]);
                    double ecatMarks = double.Parse(split[3]);
                    string[] furtherSplit = split[4].Split(';');
                    List<DegreeProgram> preferences = new List<DegreeProgram>();
                    for (int i = 0; i < furtherSplit.Length; i++)
                    {
                        DegreeProgram d = DegreeProgramDL.isSubjectExists(furtherSplit[i]);
                        if (d != null)
                        {
                            preferences.Add(d);
                        }
                    }
                    Student s = new Student(Name, age, fscMarks, ecatMarks, preferences);
                    studentList.Add(s);
                }
                sr.Close();
                return true;
            }
            return false;
        }
    }
}
