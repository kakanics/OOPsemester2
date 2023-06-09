using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete.UI
{
    internal class adminUL
    {
        public static string adminMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add book\n2. List all books\n3. delete book\n4. Update book\n5. Blacklist User\n6. View Donations\n7. Approve book\n8. exit");
            return Console.ReadLine();
        }
    }
}
