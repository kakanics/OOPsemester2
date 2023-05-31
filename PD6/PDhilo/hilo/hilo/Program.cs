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

            bool guess = true;
            int[] score = new int[5];
            string userGuess = "";
            string torturingMyself = "";
            for (int i = 0; i < 5; i++)
            {
                Deck deck = new Deck();
                deck.shuffle();

                Console.Clear();
                var card = deck.dealCard();
                Console.WriteLine("The current card is " + card.getCardValue());
                int currentValue = int.Parse(card.getValue());
                torturingMyself = Console.ReadLine();
                userGuess = torturingFunction(torturingMyself);
                while (guess)
                {
                    var next = deck.dealCard();
                    int newVal = int.Parse(next.getValue());
                    if (newVal > currentValue && userGuess.ToLower() == "high") { score[i]++; Console.WriteLine("Correct Guess"); }
                    else if (newVal < currentValue && userGuess.ToLower() == "low") { score[i]++; Console.WriteLine("Correct Guess"); }
                    else { break; }
                    Console.WriteLine("The current card is " + next.getCardValue() + "        Remaning cards: " + deck.remainingCards());
                    currentValue = newVal;
                    torturingMyself = Console.ReadLine();
                    userGuess = torturingFunction(torturingMyself);
                }
            }
            Console.WriteLine("Your scores are: " + score[0] + " " + score[1] + " " + score[2] + " " + score[3] + " " + score[4]);
            Console.WriteLine("The average is " + ((score[0] + score[1] + score[2] + score[3] + score[4] )/ 5.0f));
            Console.ReadKey();
        }
        public static string torturingFunction(string tortureVariable)
        {
            string guess = "";
            tortureVariable = tortureVariable.ToLower();
            for(int i = 0; i < tortureVariable.Length-2;i++)
            {
                if (tortureVariable[i]=='h'&& tortureVariable[i+1] == 'i'&& tortureVariable[i+2] == 'g')
                {
                    guess = "high";
                }
                if (tortureVariable[i] == 'l' && tortureVariable[i+1] == 'o' && tortureVariable[i+2] == 'w')
                {
                    guess = "low";
                }
            }
            return guess;
        }
    }
}
