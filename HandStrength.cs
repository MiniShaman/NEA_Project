using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class HandStrength
    {
        public static int bestHandChoiceLimit = 7;

        //HandEvaluation.PokerHand HandType = HandEvaluation.PokerHand.HighCard;
        public Card[] EvaluationHand = new Card[bestHandChoiceLimit];
        public int bestHandCounter = 0;
        //int handTypeHigh1 = 0;
        //int handTypeHigh2 = 0;
        //int playerCardVal1 = 0;
        //int playerCardVal2 = 0;
        public void BestHandChoice(Card CurrentCard)
        {
            EvaluationHand[bestHandCounter] = CurrentCard;
            ++bestHandCounter;
        }
        

    }
}
