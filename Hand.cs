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
        public void CombineHandAndTableCards(Player player)
        {
            int handcounter = 0;
            for (int i = 0; i < Table.tableCards.Length; ++i)
            {
                player.myBestHand.bestHand[handcounter] = Table.tableCards[handcounter];
                ++handcounter;
            }            
            for(int j = 0; j<playerHand.Length;++j)
            {
                player.myBestHand.bestHand[handcounter] = playerHand[j];
                ++handcounter;
            }
        }
    }
}
