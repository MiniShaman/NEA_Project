using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class HandStrength
    {
        public static int combinedHandLimit = 7;        
        public Card[] combinedHand = new Card[combinedHandLimit];
        //public int bestHandCounter = 0;

        //public void besthandchoice(card currentcard)
        //{
        //    combinedhand[besthandcounter] = currentcard;
        //    ++besthandcounter;
        //}
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
            try
            {
                player.myBestHand.SortCardValues(player.myHand.playerHand, player.myBestHand.GetNumberOfValidCards(player.myHand.playerHand));

                // Hand Type pair, flush etc
                player.myBestHand.playerBestCardVals[0] = (int)player.myBestHand.GetBestHand(player, player.handStrength.combinedHand, player.myBestHand.GetNumberOfValidCards(player.handStrength.combinedHand));

                // Strength of the hand type
                player.myBestHand.playerBestCardVals[1] = player.myBestHand.playersBestHand[0].Value;

                // Secondary strength : two pair, full house
                player.myBestHand.playerBestCardVals[2] = player.myBestHand.DuplicateValueCheck(player.handStrength.combinedHand, player.myBestHand.GetNumberOfValidCards(player.handStrength.combinedHand), 2, player.myBestHand.playerBestCardVals[1]);

                // Players highest card
                player.myBestHand.playerBestCardVals[3] = player.myHand.playerHand[0].Value;

                // Players other card
                player.myBestHand.playerBestCardVals[4] = player.myHand.playerHand[1].Value;
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Error - Null value cannot be set to an element of playerBestCardVals");
            }
        }

        public bool CheckCardsExistInCombinedHand(Card [] cards)
        {
            for(int i = 0; i < cards.Length; ++i)
            {
                Card card = cards[i];
                bool cardFound = false;

                if (card != null)
                {
                    for (int j = 0; j < combinedHand.Length; ++j)
                    {
                        if (card == combinedHand[j])
                        {
                            cardFound = true;
                            break;
                        }
                    }
                    if(cardFound == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
