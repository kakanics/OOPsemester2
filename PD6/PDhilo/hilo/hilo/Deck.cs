using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hilo
{
    internal class Deck
    {
        public Card[] cards = new Card[52];
        int remCards = 51;
        public Deck()
        {
            int x = 0;
            for(int i = 1; i <= 4;i++)
            {
                for(int j = 1; j <= 13;j++)
                {
                    cards[x] = new Card(i, j);
                    x++;
                }
            }
        }
        public void shuffle()
        {
            Random rnd = new Random();
            for(int i = 0; i < 52;i++)
            {
                int x = rnd.Next(0,52);
                var j = cards[x];
                cards[x] = cards[i];
                cards[i] = j;
            }
        }
        public Card dealCard()
        {
            remCards--;
            return cards[remCards+1];
        }
        public int remainingCards()
        {
            return remCards+2;
        }
    }
}
