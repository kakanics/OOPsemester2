using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete
{
    internal class reader
    {
        public string username;
        public string password;
        public int blackListed = 0;
        public reader(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public reader(admin _user)
        {
            this.username = _user.username;
            this.password = _user.password;
        }
        public reader() { }
        public bool compareUser(string _name, string _password)
        {
            if (username == _name && password == _password)
            {
                return true;
            }
            return false;
        }
    }
}
