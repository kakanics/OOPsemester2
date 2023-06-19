using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInSignUpApplication
{
    internal class Credentials
    {
        string username;
        string password;
        string role = "NA";

        public Credentials(string username, string password)
        {
            this.username = username;   
            this.password = password;
        }
        public Credentials(string username, string password, string role) 
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public string getUsername()
        {
            return username;
        }
        public string getPassword()
        {
            return password;
        }
        public string getRole()
        {
            return role;
        }
        public bool isAdmin()
        {
            if(role=="admin")
            {
                return true;
            }
            return false;
        }
    }
}
