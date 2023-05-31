using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.DL;

namespace UAMS.BL
{
    internal class Student
    {
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;
        public List<DegreeProgram> preferences;
        public List<Subject> regSubjects;
        public DegreeProgram regDegree;

        public Student(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
        }
        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100) * 0.45f + ((ecatMarks / 400) * 0.55f)) * 100);
        }
        public bool regSubject(Subject s)
        {
            int ch = getCreditHours();
            if(regDegree!=null&&regDegree.isSubjectExists(s)&&ch+s.creditHours<=9)
            {
                regSubjects.Add(s);
                return true;
            }
            return false;
        }
        public int getCreditHours()
        {
            int count = 0;
            foreach(Subject s in regSubjects)
            {
                count += s.creditHours;
            }
            return count;
        }
        public float calculateFee()
        {
            float fee = 0;
            if(regDegree!=null)
            {
                foreach(Subject s in regSubjects)
                {
                    fee += s.subjectFees;
                }
            }
            return fee;
        }
            
    }
}
