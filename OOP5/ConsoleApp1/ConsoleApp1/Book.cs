using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {
        public string author;
        public int pages;
        public List<string> chapters;
        public int bookMark;
        public int price;

        public Book(string author, int pages, List<string> chapters, int bookMark, int price)
        {
            this.author = author;
            this.pages = pages;
            this.chapters = chapters;
            this.bookMark = bookMark;
            this.price = price;
        }
        public string getChapter(int chapterNumber)
        {
            return chapters[chapterNumber];
        }
        public int getBookMark()
        {
            return bookMark;
        }
        public void setBookMark(int _bookMark)
        {
            bookMark = _bookMark;
        }
        public int getPrice()
        {
            return price;
        }
        public void setPrice(int _price)
        {
            price = _price;
        }

    }
}
