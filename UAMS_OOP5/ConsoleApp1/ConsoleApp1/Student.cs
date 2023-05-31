using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {
        public string name;
        public int age;
        public int fscMarks;
        public int ecatMarks;
        public string degree;
        public bool isEnrolled = false;
        public List<String> preferences = new List<string>();
        public List<Subject> subjects = new List<Subject>();

        public Student(string name, int age, int fscMarks, int ecatMarks)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
        }
        public int totalPrice()
        {
            int total = 0;
            if (isEnrolled)
            {
                foreach (Subject subject in subjects)
                {
                    total += subject.price;
                }
            }
            return total;
        }
        public float calculateMerit()
        {
            return ecatMarks * 0.4f + fscMarks * 0.6f;
        }
        public void addPreference(string preference)
        {
            preferences.Add(preference);
        }
    }
}
