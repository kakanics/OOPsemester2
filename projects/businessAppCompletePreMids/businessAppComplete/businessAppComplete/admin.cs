using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete
{
    internal class admin
    {
        public string username;
        public string password;
        public admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public admin(admin _user)
        {
            this.username = _user.username;
            this.password = _user.password;
        }
        public admin() { }
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
