using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class HandEvalution
    {
        public static int handCardCheckpoint = 2;
        public static int flopCardCheckpoint = 5;
        public static int turnCardCheckpoint = 6;
        public static int riverCardCheckpoint = 7;

        public enum PokerHand
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            Poker,
            StraightFlush,
        }

        
        // rearrange cards to make best hand at start of array
        // return the best enum PokerHand
        //
        /*public PokerHand GetBestHand(Card [] cards, int NumOfCards)
        {
            if (IsHandAStraightFlush()) return PokerHand.StraightFlush;
            if (IsHandAPoker()) return PokerHand.Poker;

        }

        public bool IsHandAStraightFlush(Card[] cards, int NumOfCards)
        {
            
        }

        public bool IsHandAPoker(Card[] cards, int NumOfCards)
        {
        }*/
        public Card[] SortCardValues(Card[] cards, int NumOfCards)
        {
            do
            {
                for (int i = 0; i < NumOfCards - 1; ++i)
                {
                    Card switchCard;
                    if (cards[i].Value < cards[i + 1].Value)
                    {
                        switchCard = cards[i];
                        cards[i] = cards[i + 1];
                        cards[i + 1] = switchCard;
                    }
                }
            }
            while (SearchCardArray(cards,NumOfCards) == false);
            return cards;
        }
        public bool SearchCardArray(Card [] cardList, int NumOfCards)
        {
            for(int i = 0;i<NumOfCards-1;++i)
            {
               if(cardList[i].Value<cardList[i+1].Value)
               {
                    return false;
               }
            }
            return true;
        }
    }
}
