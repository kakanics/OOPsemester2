using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<DegreeProgram> degreeProgram = new List<DegreeProgram>();
            char option = '0';
            while (option != '8')
            {
                menu();
                option = Console.ReadLine()[0];
                Console.WriteLine();
                if (option == '1')
                {
                    addStudents(students);
                }
                if (option == '2')
                {
                    addDegree(degreeProgram);
                }
                if (option == '3')
                {
                    sortStudents(students);
                    registerStudents(students, degreeProgram);
                }
                if (option == '4')
                {
                    showAdmission(degreeProgram);
                }
                if (option == '5')
                {
                    showAdmissionsOfSpecificProgram(degreeProgram);
                }
                if (option == '6')
                {
                    addSubject(students, degreeProgram);
                }
                if (option == '7')
                {
                    taxCalculator(students);
                }
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void menu()
        {
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Add Degree");
            Console.WriteLine("3. Generate merit");
            Console.WriteLine("4. View registered students");
            Console.WriteLine("5. View Students of a specific subject");
            Console.WriteLine("6. Register subjects");
            Console.WriteLine("7. Calculate fees for all students");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Enter option");
        }

        static void addStudents(List<Student> students)
        {
            string name;
            int age, fscMarks, ecatMarks, numberOfpreferences;
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fsc marks: ");
            fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ecat marks: ");
            ecatMarks = int.Parse(Console.ReadLine());
            Student studentToAdd = new Student(name, age, fscMarks, ecatMarks);
            Console.WriteLine("Enter number of preferences");
            numberOfpreferences = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfpreferences; i++)
            {
                string s = Console.ReadLine();
                studentToAdd.addPreference(s);
            }
            students.Add(studentToAdd);
        }
        static void addDegree(List<DegreeProgram> degreeProgram)
        {
            string degreeTitle;
            int duration, numberOfSubjects, creditHours, price, seats; ;
            string subjectCode, subjectType;
            Console.WriteLine("Enter degree title");
            degreeTitle = Console.ReadLine();
            Console.WriteLine("Enter duration of degree");
            duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of subjects to enter");
            numberOfSubjects = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of seats");
            seats = int.Parse(Console.ReadLine());
            DegreeProgram degreeToAdd = new DegreeProgram(degreeTitle, duration, seats);
            for (int i = 0; i < numberOfSubjects; i++)
            {
                Console.WriteLine("Enter Subject Code");
                subjectCode = Console.ReadLine();
                Console.WriteLine("Enter credit hours");
                creditHours = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter subject type");
                subjectType = Console.ReadLine();
                Console.WriteLine("Enter price");
                price = int.Parse(Console.ReadLine());
                degreeToAdd.addSubject(subjectCode, creditHours, subjectType, price);
            }
            degreeProgram.Add(degreeToAdd);
        }
        static void showAdmission(List<DegreeProgram> degreePrograms)
        {
            foreach (DegreeProgram degree in degreePrograms)
            {
                degree.displayEnrolledStudents();
            }
        }
        static void showAdmissionsOfSpecificProgram(List<DegreeProgram> programs)
        {
            string name;
            Console.WriteLine("Enter name of degree");
            name = Console.ReadLine();
            foreach (DegreeProgram degree in programs)
            {
                if (degree.degreeTitle == name)
                {
                    degree.displayEnrolledStudents();
                }
                break;
            }
            Console.ReadKey();
        }
        static void sortStudents(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                if (students[i].calculateMerit() < students[i + 1].calculateMerit())
                {
                    Student temp = students[i];
                    students[i] = students[i + 1];
                    students[i + 1] = temp;
                }
            }
        }
        public static void addSubject(List<Student> students, List<DegreeProgram> degrees)
        {
            string student;
            string subject;
            Console.WriteLine("Enter name of student:");
            student = Console.ReadLine();
            Console.WriteLine("Enter subject code:");
            subject = Console.ReadLine();

            foreach (Student studentObj in students)
            {
                foreach (DegreeProgram degreeObj in degrees)
                {
                    foreach (Subject subjectObj in degreeObj.subjects)
                    {
                        if (studentObj.name == student)
                        {
                            if (degreeObj.degreeTitle == studentObj.degree)
                            {
                                if (subjectObj.subjectCode == subject)
                                {
                                    studentObj.subjects.Add(subjectObj);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
        static void taxCalculator(List<Student> students)
        {
            Console.WriteLine("name\t\tprice");
            foreach (Student stu in students)
            {
                if (stu.isEnrolled)
                {
                    Console.WriteLine("{0}\t\t{1}", stu.name, stu.totalPrice());
                }
            }
        }
        //test upper function
        //implement tax function
        //fix book class
        static void registerStudents(List<Student> students, List<DegreeProgram> degrees)
        {
            foreach (Student student in students)
            {
                foreach (string preference in student.preferences)
                {
                    foreach (DegreeProgram degreesProgram in degrees)
                    {
                        if (!student.isEnrolled)
                        {
                            if (degreesProgram.freeSeats > 0)
                            {
                                if (preference == degreesProgram.degreeTitle)
                                {
                                    degreesProgram.enrolledStudents.Add(student);
                                    degreesProgram.freeSeats--;
                                    student.degree = degreesProgram.degreeTitle;
                                    student.isEnrolled = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
