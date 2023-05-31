using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hilo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "hit";
            string torturingMyself = "";
            Deck deck = new Deck();
            deck.shuffle();

            BlackJackHand dealer = new BlackJackHand();
            BlackJackHand player = new BlackJackHand();
            initializeHands(deck, player);
            initializeHands(deck, player);
            initializeHands(deck, dealer);
            while(dealer.calculateValueOfHand()<50 || userInput == "hit")
            {
                if(dealer.calculateValueOfHand()<50)
                {
                    dealer.cards.Add(deck.dealCard());
                }
                Console.WriteLine("The dealer dealt: " + dealer.cards.ElementAt(dealer.cards.Count-1).getCardValue() + "\n");
                
                Console.Clear();
                printAllCards(player);
                torturingMyself = Console.ReadLine();
                userInput = torturingFunction(torturingMyself);
                if(userInput=="hit")
                {
                    player.cards.Add(deck.dealCard());
                }
            }
            if (player.calculateValueOfHand()==54)
            {
                Console.WriteLine("you win by blackjack!!!");
            }
            if (player.calculateValueOfHand()>dealer.calculateValueOfHand() && player.calculateValueOfHand()<21)
            {
                Console.WriteLine("Player scored: " + player.calculateValueOfHand());
                Console.WriteLine("Dealer scored: " + dealer.calculateValueOfHand());
                Console.WriteLine("You win");
            }
            else if (dealer.calculateValueOfHand() > 54)
            {
                Console.WriteLine("Player scored: " + player.calculateValueOfHand());
                Console.WriteLine("Dealer scored: " + dealer.calculateValueOfHand());
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine("Player scored: "+ player.calculateValueOfHand());
                Console.WriteLine("Dealer scored: " + dealer.calculateValueOfHand());
                Console.WriteLine("You Lose");
            }
            Console.ReadKey();
        }
        public static string torturingFunction(string tortureVariable)
        {
            string guess = "";
            tortureVariable = tortureVariable.ToLower();
            for (int i = 0; i < tortureVariable.Length - 2; i++)
            {
                if (tortureVariable[i] == 'h' && tortureVariable[i + 1] == 'i' && tortureVariable[i + 2] == 't')
                {
                    guess = "hit";
                }
                if (tortureVariable[i] == 's' && tortureVariable[i + 1] == 't' && tortureVariable[i + 2] == 'a')
                {
                    guess = "stand";
                }
            }
            return guess;
        }
        public static void initializeHands(Deck deck, BlackJackHand hand)
        {
            hand.cards.Add(deck.dealCard());
        }
        public static void printAllCards(Hand player)
        {

            Console.WriteLine("You current hand is: ");
            foreach (Card card in player.cards)
            {
                Console.WriteLine(card.getCardValue());
            }
        }
    }
}
