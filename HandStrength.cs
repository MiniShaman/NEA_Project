using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class HandStrength
    {
        public static int bestHandChoiceLimit = 7;        
        public Card[] EvaluationHand = new Card[bestHandChoiceLimit];
        public int bestHandCounter = 0;       

        public void BestHandChoice(Card CurrentCard)
        {
            EvaluationHand[bestHandCounter] = CurrentCard;
            ++bestHandCounter;
        }
        public int CompareHands(Player player, Player AI)
        {
            AssignHandStrengthVals(player);
            AssignHandStrengthVals(AI);
            for(int i = 0; i < player.myBestHand.playerBestCardVals.Length;++i)
            {
                if (player.myBestHand.playerBestCardVals[i] > AI.myBestHand.playerBestCardVals[i])
                    return 1;
                else if(player.myBestHand.playerBestCardVals[i] < AI.myBestHand.playerBestCardVals[i])
                    return -1;
            }
            return 0;
        }
        public void AssignHandStrengthVals (Player player)
        {
            player.myBestHand.SortCardValues(player.myHand.playerHand, player.myHand.playerHand.Length);
            player.myBestHand.playerBestCardVals[0] = (int)player.myBestHand.GetBestHand(EvaluationHand,7);
            player.myBestHand.playerBestCardVals[1] = player.myBestHand.bestHand[0].Value; 
            player.myBestHand.playerBestCardVals[2] = player.myBestHand.DuplicateValueCheck(EvaluationHand, 7, 2, player.myBestHand.playerBestCardVals[1]);
            player.myBestHand.playerBestCardVals[3] = player.myHand.playerHand[0].Value;
            player.myBestHand.playerBestCardVals[4] = player.myHand.playerHand[1].Value;
        }
    }
}
