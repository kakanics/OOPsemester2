using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Lab2OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            Task6();
            Console.ReadKey();
        }
        static void Task1()
        {
            Student student = new Student();
            student.name = "Affan";
            student.rollNumber = 1;
            student.cgpa = 2.2f;
            Console.WriteLine("Name:{0}\nRoll#{1}\nCGPA:{2}", student.name, student.rollNumber, student.cgpa);
        }
        static void Task2()
        {
            Student student1 = new Student();
            Student student2 = new Student();

            student1.name = "Affan";
            student1.rollNumber = 1;
            student1.cgpa = 3.8f;

            student2.name = "Ahmar";
            student2.rollNumber = 2;
            student2.cgpa = 4.1f;

            DisplayData(student1);
            DisplayData(student2);
        }
        static void Task3()
        {
            Student student1 = new Student();

            Console.Write("Enter name: ");
            student1.name = Console.ReadLine();
            Console.Write("Enter Roll number: ");
            student1.rollNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter cgpa: ");
            student1.cgpa = float.Parse(Console.ReadLine());

            DisplayData(student1);
        }
        static void Task4()
        {
            int studentCount = 0;
            StudentTask4[] students = new StudentTask4[50];
            char choice = '0';

            while (choice != '4')
            {
                choice = menu();
                if (choice == '1')
                {
                    students[studentCount] = addStudent();
                    studentCount++;
                }
                if (choice == '2')
                {
                    viewStudents(students, studentCount);
                    Console.ReadKey();
                }
                if (choice == '3')
                {
                    showTopStudents(students, studentCount);
                    Console.ReadKey();
                }
            }
        }

        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("1: Add student");
            Console.WriteLine("2: View student");
            Console.WriteLine("3: Top 3 student");
            Console.WriteLine("4: Exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static StudentTask4 addStudent()
        {
            Console.Clear();
            StudentTask4 student = new StudentTask4();
            Console.WriteLine("Enter name: ");
            student.name = Console.ReadLine();
            Console.WriteLine("Enter Roll number: ");
            student.rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter GPA: ");
            student.GPA = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter if is hostellite: ");
            student.isHostellite = bool.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department: ");
            student.Department = Console.ReadLine();

            return student;
        }

        static void viewStudents(StudentTask4[] students, int studentCount)
        {
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("Name: {0}\nRoll number: {1}\nGPA: {2}\nisHostellite: {3}\nDepartment: {4}\n",
                    students[i].name, students[i].rollNo, students[i].GPA, students[i].isHostellite, students[i].Department);
            }
        }

        static void showTopStudents(StudentTask4[] students, int studentCount)
        {
            if (studentCount < 3)
            {
                return;
            }
            for (int i = 0; i < studentCount; i++)
            {
                for (int j = i + 1; i + j < studentCount; j++)
                {
                    if (students[i].GPA < students[j].GPA)
                    {
                        string _name;
                        int _rollNumber;
                        float _GPA;
                        bool _isHostellite;
                        string _Department;

                        _name = students[i].name;
                        _rollNumber = students[i].rollNo;
                        _GPA = students[i].GPA;
                        _isHostellite = students[i].isHostellite;
                        _Department = students[i].Department;

                        students[i].name = students[j].name;
                        students[i].rollNo = students[j].rollNo;
                        students[i].GPA = students[j].GPA;
                        students[i].isHostellite = students[j].isHostellite;
                        students[i].Department = students[j].Department;

                        students[j].name = students[i].name;
                        students[j].rollNo = students[i].rollNo;
                        students[j].GPA = students[i].GPA;
                        students[j].isHostellite = students[i].isHostellite;
                        students[j].Department = students[i].Department;
                    }
                }
            }
            viewStudentsData(students[0]);
            viewStudentsData(students[1]);
            viewStudentsData(students[2]);
        }
        static void viewStudentsData(StudentTask4 student)
        {
            Console.WriteLine("Name: {0}\nRoll number: {1}\nGPA: {2}\nisHostellite: {3}\nDepartment: {4}\n",
                student.name, student.rollNo, student.GPA, student.isHostellite, student.Department);
        }

        static void DisplayData(Student student)
        {
            Console.WriteLine("Name:{0}\nRoll#{1}\nCGPA:{2}\n", student.name, student.rollNumber, student.cgpa);
        }

        static void Task5()
        {
            int productsCount = 0;
            Product[] products = new Product[50];
            char choice = '0';

            while (choice != '4')
            {
                choice = productMenu();
                if (choice == '1')
                {
                    products[productsCount] = addProduct();
                    productsCount++;
                }
                if (choice == '2')
                {
                    viewProduct(products, productsCount);
                    Console.ReadKey();
                }
                if (choice == '3')
                {
                    showSumOfProducts(products, productsCount);
                    Console.ReadKey();
                }
            }
        }

        static char productMenu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("1: Add Product");
            Console.WriteLine("2: View Product");
            Console.WriteLine("3: show net value");
            Console.WriteLine("4: Exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static Product addProduct()
        {
            Console.Clear();
            Product product = new Product();

            Console.WriteLine("Enter name: ");
            product.name = Console.ReadLine();
            Console.WriteLine("Enter ID: ");
            product.ID = Console.ReadLine();
            Console.WriteLine("Enter Price: ");
            product.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Category: ");
            product.category = Console.ReadLine();
            Console.WriteLine("Enter brand: ");
            product.brand = Console.ReadLine();
            Console.WriteLine("Enter country: ");
            product.country = Console.ReadLine();

            return product;
        }
        static void viewProduct(Product[] products, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name: {0}\nID: {1}\nprice: {2}\nCategory: {3}\nBrand: {4}\nCountry: {5}\n",
                    products[i].name, products[i].ID, products[i].price, products[i].category, products[i].brand, products[i].country);
            }
        }
        static void showSumOfProducts(Product[] products, int count)
        {
            int totalSum = 0;
            for (int i = 0; i < count; i++)
            {
                totalSum += products[i].price;
            }
            Console.WriteLine("The store is worth {0}$", totalSum);
        }

        static void Task6()
        {
            int userCount = 0;
            User[] users = new User[50];
            char choice = '0';

            loadData(users, ref userCount);
            while (choice != '3')
            {
                choice = userMenu();
                if (choice == '1')
                {
                    Console.Clear();
                    users[userCount] = addUser();
                    userCount++;
                }
                if (choice == '2')
                {
                    Console.Clear();
                    if(signIn(users, userCount))
                    {
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("False");
                    }
                    Console.ReadKey();
                }
                saveData(users, userCount);
            }
        }

        static char userMenu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("1: Sign up");
            Console.WriteLine("2: sign in");
            Console.WriteLine("3: Exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static User addUser()
        {
            User user = new User();
            Console.Write("Enter name: ");
            user.name = Console.ReadLine();
            Console.Write("Enter password: ");
            user.password = Console.ReadLine();

            return user;
        }
        static bool signIn(User[] users, int count)
        {
            bool result = false;

            Console.Write("Enter name: ");
            string _name = Console.ReadLine();
            Console.Write("Enter password: ");
            string _password = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (users[i].name == _name && users[i].password == _password)
                {
                    result = true;
                }
            }
            return result;
        }
        static void saveData(User[] users, int count)
        {
            string path = "E:\\userData.txt";
            StreamWriter sw = new StreamWriter(path);
            {
                for (int i = 0; i < count; i++)
                {
                        sw.WriteLine("{0},{1}", users[i].name, users[i].password);
                }
            }
            sw.Close();
        }
        static void loadData(User[] users, ref int count)
        {
            count = 0;
            string path = "E:\\userData.txt";
            string line;
            StreamReader sr = new StreamReader(path);

            while ((line = sr.ReadLine()) != null)
            {
                if (line == "") break;
                users[count] = new User();
                users[count].name = parseData(line, 1);
                users[count].password = parseData(line, 2);
                count++;
            }
            sr.Close();
        }
        static string parseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[i];
                }
            }
            return item;
        }
    }
}
