using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    /// <summary>
    /// Holds info on a players hand strength
    /// </summary>
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

        /// <summary>
        /// Compares both players hand and returns 
        /// '1' if player wins 
        /// '-1' if ai wins
        /// or '0' if drawn (very rare)
        /// </summary>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <returns></returns>
        static public int CompareHands(Player player, Player AI)
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
        /// <summary>
        /// Assigns hand strength values from players best hand
        /// and catchs if any value set was null 
        /// if that occurs an error message pops up
        /// </summary>
        /// <param name="player"></param>
        static public void AssignHandStrengthVals (Player player)
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
        /// <summary>
        /// Checks to see if the cards in combined hand exist in a seperate array of cards
        /// allowing me to make sure there was no error when copying over an array
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
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
                        Debug.Assert(combinedHand[j] != null);

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
