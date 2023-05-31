using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    internal class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subject> subjects;
        public int seats;
        
        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.subjects = new List<Subject>();
            subjects = new List<Subject>();
        }
        public bool isSubjectExists(Subject s)
        {
            foreach (Subject s2 in subjects)
            {
                if(s.code== s2.code)
                {
                    return true;
                }
            }
            return false;
        }
        public bool addSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if(creditHours+s.creditHours <= 20) 
            {
                subjects.Add(s);
                return true;
            }
            return false;
        }
        public int calculateCreditHours()
        {
            int count = 0;
            for(int i = 0; i < subjects.Count;i++)
            {
                count += subjects[i].creditHours;
            }
            return count;
        }

    }
}
