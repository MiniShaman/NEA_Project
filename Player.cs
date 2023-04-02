using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class Player
    {
        public Chips myChips = new Chips();
        public HandEvaluation myBestHand = new HandEvaluation(); // This is the best possible hand you can make from all the cards
        public Hand myHand = new Hand();
        //public HandStrength myBestHand = new HandStrength();

        public Player()
        {
        }
        public int AIBetAmount()
        {
            bool goodHand = false;
            for(int i = 0; i < myHand.playerHand.Length;++i)
            {
                Card currentCard = myHand.playerHand[i];
                if (currentCard.Value > 8)
                {
                    goodHand = true;
                }
                
            }
            if (goodHand)
            {
                return 10;
            }
            return 5;

        }
    }
}
