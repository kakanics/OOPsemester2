using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DegreeProgram
    {
        public string degreeTitle;
        public int duration;
        public int seats;
        public int freeSeats;
        public List<Subject> subjects = new List<Subject>();
        public List<Student> enrolledStudents = new List<Student>();

        public DegreeProgram(string degreeTitle, int duration, int seats)
        {
            this.degreeTitle = degreeTitle;
            this.duration = duration;
            this.seats = seats;
            freeSeats = seats;
        }
        public int calculateTotalCredits()
        {
            int result = 0;
            foreach (Subject subject in subjects)
            {
                result += subject.creditHours;
            }
            return result;
        }
        public void addSubject(string subjectCode, int credits, string type, int price)
        {
            int totalcredits = calculateTotalCredits();
            Subject subjectToAdd = new Subject(subjectCode, credits, type, price);
            if (totalcredits + credits < 20)
            {
                subjects.Add(subjectToAdd);
            }
        }
        public void displayEnrolledStudents()
        {
            foreach(Student student in enrolledStudents)
            {
                Console.WriteLine(student.name);
                Console.WriteLine(degreeTitle);
                Console.WriteLine();
            }
        }
    }
}
