using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hilo
{
    internal class Card
    {
        int suit;
        int number;
        public Card(int suit, int number)
        {
            this.suit = suit;
            this.number = number;
        }
        public string getCardValue()
        {
            string s = "";
            s += number;
            s += " of ";
            if (suit == 1) s += "clubs";
            if (suit == 2) s += "diamonds";
            if (suit == 3) s += "spades";
            if (suit == 4) s += "hearts";
            return s;
        }
        public string getSuit()
        {
            string s = "";
            if (suit == 1) s += "clubs";
            if (suit == 2) s += "diamonds";
            if (suit == 3) s += "spades";
            if (suit == 4) s += "hearts";
            return s;
        }
        public string getValue()
        {
            return number.ToString();
        }
    }
}
