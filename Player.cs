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
        public HandStrength bestHand = new HandStrength();
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
        public HandEvaluation.PokerHand HandEvaluatorSystem() // Combines a players hand with the table cards, sorts the values and then gets the best hand
        {
            CombineHandAndTableCards();
            myBestHand.SortCardValues(bestHand.EvaluationHand, bestHand.EvaluationHand.Length);
            return myBestHand.GetBestHand(bestHand.EvaluationHand, bestHand.EvaluationHand.Length);
            
        }
        public void CombineHandAndTableCards()
        {
            Hand.InitialiseHand(bestHand.EvaluationHand);
            int handcounter = 0;
            for (int i = 0; i < Table.tableCards.Length; ++i)
            {
                bestHand.EvaluationHand[handcounter] = Table.tableCards[handcounter];
                ++handcounter;
            }
            for (int j = 0; j < myHand.playerHand.Length; ++j)
            {
                bestHand.EvaluationHand[handcounter] = myHand.playerHand[j];
                ++handcounter;
            }
        }
    }
}
