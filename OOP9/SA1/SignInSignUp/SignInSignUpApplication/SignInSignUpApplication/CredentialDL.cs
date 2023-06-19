using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInSignUpApplication
{
    internal class CredentialDL
    {
        public static List<Credentials> users = new List<Credentials>();
        public static void addIntoList(Credentials credentials)
        {
            users.Add(credentials);
        }
        public static Credentials signIn(Credentials user)
        {
            foreach(Credentials cred in users)
            {
                if(cred.getUsername()==user.getUsername() && user.getPassword()==cred.getPassword())
                {
                    return cred;
                }
            }
            return null;
        }
        public static void readDataFromFile()
        {

            StreamReader sr = new StreamReader("users.txt");
            string record;
            while((record=sr.ReadLine())!=null)
            {
                string[] fields = record.Split(',');
                Credentials user = new Credentials(fields[0], fields[1], fields[2]);
                users.Add(user);
            }
            sr.Close();
        }
        public static void writeToFile(Credentials user)
        {
            StreamWriter sw = new StreamWriter("users.txt");
            sw.WriteLine(user.getUsername() + "," + user.getPassword() + "," + user.getRole());
            sw.Close();
        }
    }
}
