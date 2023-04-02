using System;
using System.Diagnostics;

namespace NEA_PROJECT
{
    public class HandEvaluation
    {
        //public static int handCardCheckpoint = 2;
        //public static int flopCardCheckpoint = 5;
        //public static int turnCardCheckpoint = 6;
        //public static int riverCardCheckpoint = 7;

        public static int minHandSize = 5;

        public static Card[] bestHand = new Card[7];

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

        public int GetNumberOfValidCards(Card[] cards)
        {
            int count = 0;
            for(int i = 0; i < cards.Length; ++i)
            {
                if (cards[i] == null)
                    break;
                ++count;
            }
            return count;
        }

        // rearrange cards to make best hand at start of array
        // return the best enum PokerHand
        //
        public PokerHand GetBestHand(Card[] cards, int NumOfCards)
        {
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandName);
            if (NumOfCards >= minHandSize)
            {
                //if (IsHandAStraightFlush()) return PokerHand.StraightFlush;
                if (IsHandAPoker(cards, NumOfCards))
                    return PokerHand.Poker;
                else if (IsHandAFullHouse(cards, NumOfCards))
                    return PokerHand.FullHouse;
                else if (IsHandAFlush(cards, NumOfCards))
                    return PokerHand.Flush;
                else if (IsHandAStraight(cards, NumOfCards))
                    return PokerHand.Straight;
                else if (IsHandAThreeOfAKind(cards, NumOfCards))
                    return PokerHand.ThreeOfAKind;
                else if (IsHandATwoPair(cards, NumOfCards))
                    return PokerHand.TwoPair;         
            }
            if(IsHandAPair(cards,NumOfCards))
            {
                return PokerHand.Pair;
            }
            return PokerHand.HighCard;
        }

        public bool IsHandAStraightFlush(Card[] cards, int NumOfCards)
        {
            if (IsHandAFlush(cards, NumOfCards))
            {
                Card[] BestFlushHand = new Card[GetNumberOfValidCards(bestHand)];
                Array.Copy(bestHand, BestFlushHand, BestFlushHand.Length);
                if (IsHandAStraight(BestFlushHand, BestFlushHand.Length))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsHandAPoker(Card[] cards, int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(bestHand, 0, bestHand.Length);
            int pokerPoint = 4;
            int duplicateMatch = DuplicateValueCheck(cards, NumOfCards, pokerPoint);
            if (duplicateMatch != 0)
            {
                CopyDuplicatesToBestHand(cards, NumOfCards, duplicateMatch, pokerPoint);
                return true;
            }
            return false;
        }
        public bool IsHandAFullHouse(Card[] cards, int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            
            Array.Clear(bestHand, 0, bestHand.Length);

            int valueTriple = 3;
            int valuePair = 2;
            int DuplicateMatch = DuplicateValueCheck(cards, NumOfCards, valueTriple);
            if (DuplicateMatch != 0)
            {
                CopyDuplicatesToBestHand(cards, NumOfCards, DuplicateMatch, valueTriple);
                DuplicateMatch = DuplicateValueCheck(cards, NumOfCards, valuePair, DuplicateMatch);
                if (DuplicateMatch != 0)
                {
                    CopyDuplicatesToBestHand(cards, NumOfCards, DuplicateMatch, valueTriple, valueTriple);
                    return true;
                }
            }
            return false;
        }
        public bool IsHandAFlush(Card[] cards, int NumOfCards) // Checks Cards to see if your hand is a flush
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(bestHand, 0, bestHand.Length);

            int heartSuitCounter = 0;
            int clubSuitCounter = 0;
            int diamondSuitCounter = 0;
            int spadeSuitCounter = 0;
            for (int i = 0; i < NumOfCards; ++i)
            {
                Card.CardSuit suitCheck = cards[i].Suit;
                switch (suitCheck)
                {
                    case Card.CardSuit.Hearts:
                        ++heartSuitCounter;
                        if(heartSuitCounter == minHandSize)
                        {
                            CopySuitToBestHand(cards, NumOfCards, Card.CardSuit.Hearts);
                            return true;
                        }
                        break;
                    case Card.CardSuit.Diamonds:
                        ++diamondSuitCounter;
                        if (diamondSuitCounter == minHandSize)
                        {
                            CopySuitToBestHand(cards, NumOfCards, Card.CardSuit.Diamonds);
                            return true;
                        }
                        break;
                    case Card.CardSuit.Spades:
                        ++spadeSuitCounter;
                        if (spadeSuitCounter == minHandSize)
                        {
                            CopySuitToBestHand(cards, NumOfCards, Card.CardSuit.Spades);
                            return true;
                        }
                        break;
                    case Card.CardSuit.Clubs:
                        ++clubSuitCounter;
                        if (clubSuitCounter == minHandSize)
                        {
                            CopySuitToBestHand(cards, NumOfCards, Card.CardSuit.Clubs);
                            return true;
                        }
                        break;
                }
            }
            return false;           
        }

        public bool IsHandAStraight(Card[] cards, int NumOfCards)
        {
            Array.Clear(bestHand, 0, bestHand.Length);

            Debug.Assert(NumOfCards > 0);
            Debug.Assert(CheckCardsDescend(cards, GetNumberOfValidCards(cards)));

            bool aceFound = cards[0].Value == Card.Ace;

            int matchesFound = 0; // remember first match counts twice
            bool firstEntry = true;
            int straightHigh = 0;
            int bestHandIndex = 0;

            for (int i = 0; i < NumOfCards - 1; ++i)
            {
                Card inputCard = cards[i];
                Card compareCard = cards[i + 1];

                switch (CompareCardValues(inputCard, compareCard))
                {
                    case CardComparison.AdjacentVal:
                        if (firstEntry)
                        {
                            straightHigh = inputCard.Value;
                            bestHand[bestHandIndex] = inputCard;
                            ++bestHandIndex;
                            bestHand[bestHandIndex] = compareCard;
                            ++bestHandIndex;
                            firstEntry = false;
                            ++matchesFound;
                        }
                        else
                        {
                            bestHand[bestHandIndex] = compareCard;
                            ++bestHandIndex;
                            ++matchesFound;
                        }
                        break;
                    case CardComparison.NonAdjacentVal:
                        Array.Clear(bestHand, 0, bestHand.Length);
                        straightHigh = 0;
                        matchesFound = 0;
                        bestHandIndex = 0;
                
                        firstEntry = true;
                        break;
                    default:
                        break;
                }
                if(straightHigh == 5 && matchesFound == 3 && aceFound)
                {
                    bestHand[bestHandIndex] = cards[0];
                    return true;
                }
                if (matchesFound >= minHandSize - 1)
                {
                    return true;
                }
                
            }
            return false;
        }    
       
        public bool IsHandAThreeOfAKind(Card []cards, int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(bestHand, 0, bestHand.Length);

            int threeOfAKindPoint = 3;
            int duplicateMatch = DuplicateValueCheck(cards, NumOfCards, threeOfAKindPoint);
            if (duplicateMatch != 0)
            {
                CopyDuplicatesToBestHand(cards, NumOfCards, duplicateMatch, threeOfAKindPoint);
                return true;
            }
            return false; 
        }
        public bool IsHandATwoPair(Card[]cards,int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(bestHand, 0, bestHand.Length);

            int twoPairPoint = 2;
            int duplicateMatch = DuplicateValueCheck(cards, NumOfCards, twoPairPoint);
            if (duplicateMatch != 0)
            {
                CopyDuplicatesToBestHand(cards, NumOfCards, duplicateMatch, twoPairPoint);
                duplicateMatch = DuplicateValueCheck(cards, NumOfCards, twoPairPoint, duplicateMatch);
                if (duplicateMatch != 0)
                {
                    CopyDuplicatesToBestHand(cards, NumOfCards, duplicateMatch, twoPairPoint, twoPairPoint);
                    return true;
                }
            }
            return false;
        }
        public bool IsHandAPair(Card[]cards,int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(bestHand, 0, bestHand.Length);

            int pairPoint = 2;
            int duplicateMatch = DuplicateValueCheck(cards, NumOfCards, pairPoint);
            if (duplicateMatch != 0)
            {
                CopyDuplicatesToBestHand(cards, NumOfCards, duplicateMatch, pairPoint);
                return true;
            }
            return false;
        }
        public Card[] SortCardValues(Card[] cards, int NumOfCards) // Sorts Card values from highest to lowest
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
             while(CheckCardsDescend(cards,NumOfCards) == false);
            return cards;
        }
        public bool CheckCardsDescend(Card [] cardList, int NumOfCards)
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
        public CardComparison CompareCardValues(Card cardVal1, Card cardVal2)
        {
            int diff = cardVal1.Value - cardVal2.Value;

            if(diff == 0)
            {
                return CardComparison.SameVal;
            }
            else if(Math.Abs(diff) == 1)
            {
                return CardComparison.AdjacentVal;
            }

            return CardComparison.NonAdjacentVal;
        }
        public bool CheckForAceAndTwo(Card[] cards, int NumOfCards)
        {
            bool aceCheck = false;
            bool twoCheck = false;
            for(int i = 0;i<NumOfCards;++i)
            {
                if (cards[i].Value == 14)
                {
                    aceCheck = true;
                }
                else if (cards[i].Value == 2)
                {
                    twoCheck = true;
                }
            }
            if (twoCheck && aceCheck)
            {
                return true;
            }
            else return false;
        }
        // Checks through all cards in your hand to see if there are duplicate values
        // Returns true if it matches the limit entered else it returns false
        // ValueMatchLimit is the number of cards we are looking for
        public int DuplicateValueCheck(Card[] cards, int NumOfCards, int ValueMatchLimit, int ignoreValue = 0) 
        {
            bool firstMatch = true;
            int duplicateValueCounter = 0;
            for (int i = 0; i < NumOfCards - 1; ++i)
            {
                if (cards[i].Value != ignoreValue)
                {
                    switch (CompareCardValues(cards[i], cards[i + 1]))
                    {
                        case CardComparison.SameVal:
                            ++duplicateValueCounter;
                            if (firstMatch)
                            {
                                ++duplicateValueCounter;
                                firstMatch = false;
                            }
                            break;
                        default: // because cards are sorted when we don't find a match - reset.
                            firstMatch = true;
                            duplicateValueCounter = 0;
                            break;
                    }
                    if (duplicateValueCounter == ValueMatchLimit)
                    {
                        return cards[i].Value;
                    }
                }
            }
            return 0;
        }
        public void CopySuitToBestHand(Card [] cards, int NumOfCards, Card.CardSuit SuitChoice)
        {
            Array.Clear(bestHand, 0, bestHand.Length);

            int bestHandIndex = 0;
            for(int i = 0;i < NumOfCards; ++i)
            {
                if (cards[i].Suit == SuitChoice)
                {
                    bestHand[bestHandIndex] = cards[i];
                    ++bestHandIndex;
                }
            }
        }
        public void CopyDuplicatesToBestHand(Card[] cards, int NumOfCards,int cardMatchVal, int valueAddLimit, int bestHandIndex = 0)
        {
            valueAddLimit += bestHandIndex;
            for (int i = 0; i < NumOfCards; ++i)
            {
                if (cards[i].Value == cardMatchVal)
                {
                    bestHand[bestHandIndex] = cards[i];
                    ++bestHandIndex;
                }

                if (bestHandIndex == valueAddLimit)
                {
                    break;
                }
            }
        }
    }
}
