using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete
{
    internal class book
    {
        public string name;
        public string genre;
        public string author;
        public string issuer = "";
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
        public book(string name, string genre, string author, int pageNumbers, string issuer)
        {
            this.name = name;
            this.genre = genre;
            this.author = author;
            this.pageNumbers = pageNumbers;
            this.issuer = issuer;
        }
        public book(book _book)
        {
            this.name = _book.name;
            this.genre = _book.genre;
            this.author = _book.author;
            this.pageNumbers = _book.pageNumbers;
        }
        public void updateBook(string name, string genre, string author, int pageNumbers)
        {
            this.name = name;
            this.genre = genre;
            this.author = author;
            this.pageNumbers = pageNumbers;
        }
    }
}
