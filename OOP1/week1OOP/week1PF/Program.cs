using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1PF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Task10();
            Task11();
            Task12("F:\\study\\sem2\\lab1\\Data.txt", 5, 20);
        }
        static void Task1()
        {
            float length;
            float area;
            Console.WriteLine("Enter length of square");
            length = float.Parse(Console.ReadLine());
            area = length * length;
            Console.WriteLine("Area is {0}", area);
            Console.ReadKey();
        }
        static void Task2()
        {
            float marks;
            Console.WriteLine("Enter the marks: ");
            marks = float.Parse(Console.ReadLine());
            if (marks > 50)
            {
                Console.WriteLine("You have passed");
            }
            else
            {
                Console.WriteLine("You have failed");
            }
            Console.ReadKey();
        }
        static void Task3()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Welcome myself");
            }
            Console.ReadKey();
        }
        static void Task4()
        {
            int input = 0;
            while (input != -1)
            {
                Console.WriteLine("Enter a number");
                input = int.Parse(Console.ReadLine());
            }
            Console.ReadKey();
        }
        static void Task5()
        {
            int input;
            int sum = 0;
            do
            {
                Console.WriteLine("Enter a number");
                input = int.Parse(Console.ReadLine());
                sum += input;
            }
            while (input != -1);
            sum++;
            Console.Write("sum of these numbers is {0}", sum);
            Console.ReadKey();
        }
        static void Task6()
        {
            int[] inputArray = new int[3];
            int largestNum;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter a number: ");
                inputArray[i] = int.Parse(Console.ReadLine());
            }
            largestNum = inputArray[0];
            for (int i = 0; i < 3; i++)
            {
                if (largestNum < inputArray[i])
                {
                    largestNum = inputArray[i];
                }
            }
            Console.WriteLine("Largest number is {0}", largestNum);
            Console.ReadKey();
        }
        static void Task7()
        {
            int LillyAge;
            int WashingMachinePrice;
            int ToyPrice;
            int DollarSum = 0;
            int ExtraDollar = 10;
            int DollarToy = 0;
            int TotalDollars = 0;

            Console.WriteLine("Enter lilly's Age: ");
            LillyAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Washing Machine price: ");
            WashingMachinePrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Toy Price: ");
            ToyPrice = int.Parse(Console.ReadLine());

            for (int i = 1; i <= LillyAge; i += 2)
            {
                DollarToy += ToyPrice;
            }
            for (int i = 2; i <= LillyAge; i += 2)
            {
                DollarSum += ExtraDollar;
                ExtraDollar += 10;
                DollarSum -= 1;
            }
            TotalDollars = DollarSum + DollarToy;
            if (TotalDollars > WashingMachinePrice)
            {
                Console.WriteLine("She can buy the washing machine, she will be left with {0}$", TotalDollars - WashingMachinePrice);
            }
            else
            {
                Console.WriteLine("Nope, not happening, she is too poor and needs to work on her maths skill, she needs {0} more $s", -TotalDollars + WashingMachinePrice);
            }
            Console.ReadKey();
        }
        static void Task8()
        {
            int num1, num2;
            Console.WriteLine("Enter number 1: ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number 2: ");
            num2 = int.Parse(Console.ReadLine());
            Console.Write("Sum is {0}", Task8Adder(num1, num2));
            Console.Read();
        }
        static int Task8Adder(int x, int y)
        {
            return x + y;
        }
        static void Task9()
        {
            string path = "F:\\study\\sem2\\lab1\\randomFile.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            else { Console.WriteLine("file not found"); }
            Console.Read();
        }
        static void Task10()
        {
            string path = "F:\\study\\sem2\\lab1\\randomFile.txt";
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine("Hello there");
            streamWriter.Flush();
            streamWriter.Close();
        }
        static void Task11()
        {
            string path = "F:\\study\\sem2\\lab1\\userData.txt";
            string[] passwords = new string[5];
            string[] names = new string[5];
            string name, password;
            int option = 0;
            while (option < 3)
            {
                readDataFromFile(path, names, passwords);
                Console.Clear();
                option = getChoice();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter you name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    password = Console.ReadLine();
                    if (SignIn(name, password, names, passwords))
                    {
                        Console.Write("Successful");
                    }
                    else
                    {
                        Console.Write("Failed");
                    }
                }
                if (option == 2)
                {
                    Console.WriteLine("Enter you name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    password = Console.ReadLine();
                    SignUp(path, name, password);
                }
                Console.ReadKey();
            }
        }

        static int getChoice()
        {
            int option;
            Console.WriteLine("Option 1: SignIn\nOption 2: SignUp\nEnter Option: ");
            option = int.Parse(Console.ReadLine());
            return option;
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
        static void readDataFromFile(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("Does not exist");
            }
        }
        static bool SignIn(string name, string password, string[] names, string[] passwords)
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                if (name == names[i] && password == passwords[i])
                    flag = true;
            }
            return flag;
        }
        static void SignUp(string path, string name, string password)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(name + "," + password);
            streamWriter.Flush();
            streamWriter.Close();
        }

        static void Task12(string path, int count, int price)
        {
            readData11(path, count, price);
        }
        static void readData11(string path, int count, int price)
        {
            string name = "";
            int num;
            string nums;
            string line;
            int counter = 0;
            if (File.Exists(path))
            {
                StreamReader streamReader = new StreamReader(path);
                while ((line = streamReader.ReadLine()) != null)
                {
                    name = complexParseData(line, 1);
                    num = int.Parse(complexParseData(line, 2));
                    nums = numsParser(line);
                    for (int i = 1; i < num; i++)
                    {
                        if (int.Parse(parseData(nums, i)) > price)
                        {
                            counter++;
                        }
                    }
                    if (counter > count)
                    {
                        Console.WriteLine(name);
                    }
                }
            }
            Console.ReadKey();

        }
        static string complexParseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
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
        static string numsParser(string record)
        {
            bool flag = false;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ']')
                {
                    break;
                }
                if (flag)
                {
                    item += record[i];
                }
                if (record[i] == '[')
                {
                    flag = true;
                }
            }
            return item;
        }
    }
}
