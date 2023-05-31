using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    internal class DegreeProgramDL
    {
        public static List<DegreeProgram> programList = new List<DegreeProgram>();
        public static void addDegreeIntoList(DegreeProgram dp)
        {
            programList.Add(dp);
        }
        public static DegreeProgram isSubjectExists(string degree)
        {
            foreach (DegreeProgram s2 in programList)
            {
                if (degree == s2.degreeName)
                {
                    return s2;
                }
            }
            return null;
        }
        public static void StoreIntoFile(string path, DegreeProgram d)
        {
            StreamWriter sw = new StreamWriter(path, true);
            string subjectNames = "";
            for (int i = 0; i < d.subjects.Count - 1; i++)
            {
                subjectNames += d.subjects[i].type + ';';
            }
            subjectNames += d.subjects[d.subjects.Count - 1].type + ';';
            sw.WriteLine(d.degreeName + "," + d.degreeDuration + "," + d.seats + "," + subjectNames);
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
                    string degreeName = split[0];
                    float degreeDuration = float.Parse(split[1]);
                    int seats = int.Parse(split[2]);
                    string[] furtherSplit = split[3].Split(';');
                    DegreeProgram d = new DegreeProgram(degreeName, degreeDuration, seats);
                    for (int i = 0; i < furtherSplit.Length; i++)
                    {
                        Subject s = SubjectDL.isSubjectExists(furtherSplit[i]);
                        if (s != null)
                        {
                            d.addSubject(s);
                        }
                    }
                    addDegreeIntoList(d);
                }
                sr.Close();
                return true;
            }
            return false;
        }
    }
}
