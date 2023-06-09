using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete.UI
{
    internal class genericUI
    {
        public static int getChoice()
        {
            string option;
            Console.WriteLine("Option 1: SignIn\nOption 2: SignUp\nEnter Option: ");
            option = Console.ReadLine();
            if (genericFunctions.validateStringAsInt(option))
                return int.Parse(option);
            return 0;
        }
        public static string getField()
        {
            Console.WriteLine("Enter relevant info:");
            return Console.ReadLine();
        }
        public static string getField(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
    }
}
