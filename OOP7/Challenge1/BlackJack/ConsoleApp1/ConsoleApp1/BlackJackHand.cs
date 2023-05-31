using hilo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BlackJackHand : Hand
    {
        public int calculateValueOfHand()
        {
            int value = 0;
            foreach (Card card in cards)
            {
                if (card.getValueAsInt() > 10)
                {
                    value += 10;
                }
                else if (card.getValueAsInt() > 1)
                {
                    value += card.getValueAsInt();
                }
                else
                {
                    if (value + 11 <= 21)
                    {
                        value += 11;
                    }
                    else
                    {
                        value++;
                    }
                }
            }
            return value;
        }
    }
}
