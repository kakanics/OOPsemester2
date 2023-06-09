using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete.UI
{
    internal class readerUL
    {
        public static string readerMenu()
        {
            Console.Clear();
            Console.WriteLine("1. issue book\n2. return book\n3. donate book\n4. appeal blacklist\n5. view book\n6. rate a book\n7. delete your account\n8. exit");
            return Console.ReadLine();
        }
    }
}
