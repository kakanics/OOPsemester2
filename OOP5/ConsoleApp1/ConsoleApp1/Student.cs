using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {
        public string name;
        public int rollNumber;
        public float cGPA;
        public int matricMarks;
        public int fscMarks;
        public int ecatMarks;
        public string homeTown;
        public bool isHostellite;
        public bool isTakingScholarship;

        public Student(string _name, int _rollNumber, float _cGPA, int _matricMarks, int _fscMarks, int _ecatMarks, string _homeTown, bool _isHostellite, bool _isTakingScholarship)
        {
            name = _name;
            rollNumber = _rollNumber;
            cGPA = _cGPA;
            matricMarks = _matricMarks;
            fscMarks = _fscMarks;
            ecatMarks = _ecatMarks;
            homeTown = _homeTown;
            isHostellite = _isHostellite;
            isTakingScholarship = _isTakingScholarship;
        }
        public float calculateMerit()
        {
            return fscMarks * 0.6f + ecatMarks * 0.4f;
        }
        public bool isEligibleForScholarship(float meritPercentage)
        {
            bool result = false;
            if (isHostellite && calculateMerit() > meritPercentage) 
            {
                result = true; 
            }
            return result;
        }
    }
}
