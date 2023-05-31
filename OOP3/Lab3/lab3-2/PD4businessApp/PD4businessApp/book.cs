using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD4businessApp
{
    internal class book
    {
        public string name;
        public string genre;
        public string author;
        public int pageNumbers;

        public void changeBookname(string _name, string _genre, string _author, int _pageNumbers)
        {
            name = _name;
            genre = _genre;
            author = _author;
            pageNumbers = _pageNumbers;
        }
        public book(string name, string genre, string author, int pageNumbers)
        {
            this.name = name;
            this.genre = genre;
            this.author = author;
            this.pageNumbers = pageNumbers;
        }
        public book(book _book)
        {
            this.name = _book.name;
            this.genre = _book.genre;
            this.author = _book.author;
            this.pageNumbers= _book.pageNumbers;
        }
        public book(){}
    }
    internal class user
    {
        public string username;
        public string password;
        public user(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public user(user _user)
        {
            this.username = _user.username;
            this.password = _user.password;
        }
        public user() { }
        public bool compareUser(string _name, string _password)
        {
            if(username == _name && password == _password)
            {
                return true;
            }
            return false;
        }
    }
}
