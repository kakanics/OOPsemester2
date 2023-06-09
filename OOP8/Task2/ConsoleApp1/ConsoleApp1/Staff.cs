using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Staff:Person
    {
        private string school;
        private double pay;
        public Staff(string school, double pay, string name, string address) : base(name, address)
        {
            this.school = school;
            this.pay = pay;
        }
        public string getSchool()
        {
            return school;
        }
        public double getPay()
        {
            return pay;
        }
        public void setPay(double pay)
        { 
            this.pay = pay; 
        }
        public void setSchool(string school)
        {
            this.school=school;
        }
        public override string ToString()
        {
            string s = "Student[";
            s += base.ToString();
            s += ", School:" + school+ ", Pay: " + pay+ "]";
            return s;
        }
    }
}
