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
        public static int minHandSize = 5;
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
        public enum CardComparison
        {
            AdjacentVal,
            SameVal,
            NonAdjacentVal
        }
        
        // rearrange cards to make best hand at start of array
        // return the best enum PokerHand
        //
        public PokerHand GetBestHand(Card [] cards, int NumOfCards)
        {
            if (NumOfCards >= minHandSize)
            {
                //if (IsHandAStraightFlush()) return PokerHand.StraightFlush;
                //if (IsHandAPoker()) return PokerHand.Poker;
                if (IsHandAFlush(cards, NumOfCards))
                {
                    return PokerHand.Flush;
                }
                else if (IsHandAStraight(cards, NumOfCards))
                {
                    return PokerHand.Straight;
                }
            } 
            return PokerHand.HighCard;
        }

        /*public bool IsHandAStraightFlush(Card[] cards, int NumOfCards)
        {
            if (NumOfCards < minHandSize)
            {
                return false;
            }
            else if (!IsHandAFlush(cards, NumOfCards) && !IsHandAStraight(cards,NumOfCards))
            {
                return false;
            }
        }*/

        /*public bool IsHandAPoker(Card[] cards, int NumOfCards)
        {
        }*/
        public bool IsHandAFlush(Card[] cards, int NumOfCards)
        {
            int heartSuitCounter = 0;
            int clubSuitCounter = 0;
            int diamondSuitCounter = 0;
            int spadeSuitCounter = 0;
            if (NumOfCards < minHandSize)
            {
                return false;
            }
            for (int i = 0; i < NumOfCards; ++i)
            {
                Card.CardSuit suitCheck = cards[i].Suit;
                switch (suitCheck)
                {
                    case Card.CardSuit.Hearts:
                        ++heartSuitCounter;
                        break;
                    case Card.CardSuit.Diamonds:
                        ++diamondSuitCounter;
                        break;
                    case Card.CardSuit.Spades:
                        ++spadeSuitCounter;
                        break;
                    case Card.CardSuit.Clubs:
                        ++clubSuitCounter;
                        break;
                }
            }
            if (heartSuitCounter >= minHandSize || diamondSuitCounter >= minHandSize || spadeSuitCounter >= minHandSize || clubSuitCounter >= minHandSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsHandAStraight(Card[] cards, int NumOfCards)
        { 
            const int straightHandCutoff = 4;
            int straightChain = 0;
            bool firstEntry = true;
            int[] straightHandRun = new int[NumOfCards];
            if(CheckForAceAndKing(cards, NumOfCards))
            {
                straightChain = 1;
            }
            for(int i = 0;i<NumOfCards-1;++i)
            {
                int inputVal = cards[i].Value;
                int compareVal = cards[i + 1].Value;
                if(i >= straightHandCutoff && straightChain == 0)
                {
                    return false;
                }
                else
                {
                   
                    switch (CheckAdjValues(inputVal, compareVal))
                    {
                        case CardComparison.AdjacentVal:
                            if (firstEntry)
                            {
                                straightHandRun[i] = inputVal;
                                straightHandRun[i + 1] = compareVal;
                                firstEntry = false;
                                ++straightChain;
                            }
                            else
                            {
                                straightHandRun[i + 1] = compareVal;
                                ++straightChain;
                            }
                            break;
                        case CardComparison.SameVal:
                            break;
                        case CardComparison.NonAdjacentVal:
                            Array.Clear(straightHandRun, 0, NumOfCards);
                            straightChain = 0;
                            
                            firstEntry = false;
                            break;
                        default:
                            break;
                    }
                    if (straightChain >= minHandSize-1)
                    {
                        return true;
                    }
                }
            }
                return false;
        }
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
            while(SearchCardArray(cards,NumOfCards) == false);
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
        public CardComparison CheckAdjValues(int cardVal1, int cardVal2)
        {
            if(cardVal1 == cardVal2+1)
            {
                return CardComparison.AdjacentVal;
            }
            else if (cardVal1 == cardVal2)
            {
                return CardComparison.SameVal;
            }
            else
            {
                return CardComparison.NonAdjacentVal;
            }
        }
        public bool CheckForAceAndKing(Card[] cards, int NumOfCards)
        {
            bool aceCheck = false;
            bool kingCheck = false;
            for(int i = 0;i<NumOfCards;++i)
            {
                if (cards[i].Value == 1)
                {
                    aceCheck = true;
                }
                else if (cards[i].Value == 13)
                {
                    kingCheck = true;
                }
            }
            if (kingCheck && aceCheck)
            {
                return true;
            }
            else return false;
        }
    }
}
