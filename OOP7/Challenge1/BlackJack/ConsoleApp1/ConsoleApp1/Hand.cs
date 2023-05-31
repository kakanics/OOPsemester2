using hilo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Hand
    {
        public List<Card> cards;
        public Hand()
        {
            cards = new List<Card>();
        }
        public void clearHand()
        {
            cards.Clear();
        }
        public void addCard(Card card)
        {
            cards.Add(card);
        }
        public void removeCard(string suit, string value)
        {
            foreach (Card card in cards)
            {
                if (card.getSuit() == suit && card.getValue() == value)
                {
                    cards.Remove(card);
                    break;
                }
            }
            Console.WriteLine("This card was not in list");
        }
        public void removeCard(int position)
        {
            if (cards.Count <= position)
            {
                Console.WriteLine("Invalid");
                return;
            }
            cards.RemoveAt(position);
        }
        public int getCardCount()
        {
            return cards.Count;
        }
        public Card GetCard(int position)
        {
            if (cards.Count <= position)
            {
                Console.WriteLine("Invalid");
                return null;
            }
            return cards[position];
        }
        public void sortByValue()
        {
            cards = cards.OrderBy(o=>o.getValueAsInt()).ToList();
        }
        public void sortBySuit()
        {
            cards = cards.OrderBy(o => o.getSuitAsInt()).ToList();
        }
    }
}
