using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class Hand
    {
        public Card[] playerHand = new Card[2];

        public Hand()
        {
            InitialiseHand(playerHand);
            
        }

        public static void InitialiseHand(Card[] hand)
        {
            for (int i = 0; i < hand.Length; ++i)
            {
                hand[i] = new Card();
            }
        }        
    }
}
