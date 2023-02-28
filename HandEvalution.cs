using System;

namespace NEA_PROJECT
{
    class HandEvalution
    {
        public static int handCardCheckpoint = 2;
        public static int flopCardCheckpoint = 5;
        public static int turnCardCheckpoint = 6;
        public static int riverCardCheckpoint = 7;

        public static int minHandSize = 5;

        public static int duplicateCardValue = 0; // To store a card value when checking for card value matches
        public static int firstValueCheck = 0;

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
        public PokerHand GetBestHand(Card[] cards, int NumOfCards)
        {
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandName);
            firstValueCheck = 0;
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

        public bool IsHandAPoker(Card[] cards, int NumOfCards)
        {
            duplicateCardValue = 0;
            int pokerPoint = 4;
            if (DuplicateValueCheck(cards, NumOfCards, pokerPoint))
            {
                return true;
            }
            return false;
        }
        public bool IsHandAFullHouse(Card[] cards, int NumOfCards)
        {
            duplicateCardValue = 0;
            int valueTriple = 3;
            int valuePair = 2;
            if(DuplicateValueCheck(cards,NumOfCards,valueTriple))
            {
                if(DuplicateValueCheck(cards, NumOfCards, valuePair))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsHandAFlush(Card[] cards, int NumOfCards)
        {
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
                   
                    switch (CompareCardValues(inputVal, compareVal))
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
        public bool IsHandAThreeOfAKind(Card []cards, int NumOfCards)
        {
            duplicateCardValue = 0;
            int ThreeOfAKindPoint = 3;
            if(DuplicateValueCheck(cards,NumOfCards,ThreeOfAKindPoint))
            {
                return true;
            }
            return false; 
        }
        public bool IsHandATwoPair(Card[]cards,int NumOfCards)
        {
            duplicateCardValue = 0;
            int twoPairPoint = 2;
            if(DuplicateValueCheck(cards,NumOfCards,twoPairPoint))
            {
                if(DuplicateValueCheck(cards,NumOfCards,twoPairPoint))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsHandAPair(Card[]cards,int NumOfCards)
        {
            duplicateCardValue = 0;
            int pairPoint = 2;
            if(DuplicateValueCheck(cards,NumOfCards,pairPoint))
            {
                return true;
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
        public CardComparison CompareCardValues(int cardVal1, int cardVal2)
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
        // Checks through all cards in your hand to see if there are duplicate values
        //Returns true if it matches the limit entered else it returns false
        public bool DuplicateValueCheck(Card[] cards, int NumOfCards, int ValueMatchLimit) 
        {
            bool firstMatch = true;
            int duplicateValueCounter = 0;
            for (int i = 0; i < NumOfCards - 1; ++i)
            {
                if (cards[i].Value != duplicateCardValue)
                {
                    int initialVal = cards[i].Value;
                    int compareVal = cards[i + 1].Value;
                    switch (CompareCardValues(initialVal, compareVal))
                    {
                        //case CardComparison.AdjacentVal:
                        //    break;
                        case CardComparison.SameVal:
                            ++duplicateValueCounter;
                            if (firstMatch)
                            {
                                ++duplicateValueCounter;
                                firstMatch = false;
                            }
                            break;
                        //case CardComparison.NonAdjacentVal:
                        //    break;
                        default: // because cards are sorted when we don't find a match - reset.
                            firstMatch = true;
                            duplicateValueCounter = 0;
                            break;
                    }
                    if (duplicateValueCounter == ValueMatchLimit)
                    {
                        duplicateCardValue = cards[i].Value;
                        ++firstValueCheck;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
