using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student:Person
    {
        string program;
        int year;
        double fee;

        public Student(string program, int year, double fee, string name, string address) : base(name, address)
        {
            this.program = program;
            this.year = year;
            this.fee = fee;
        }
        public string getProgram()
        {
            return program;
        }
        public int getYear()
        {
            return year;
        }
        public double getFee()
        {
            return fee;
        }
        public void setProgram(string program)
        {
            this.program = program;
        }
        public void setYear(int year)
        { 
            this.year = year; 
        }
        public void setFee(double fee)
        {
            this.fee= fee;
        }
        public override string ToString()
        {
            string s = "Student[";
            s += base.ToString();
            s += ", Program:" + program + ", year: " + year + ", fee: " + fee + "]";
            return s;
        }
    }
}
