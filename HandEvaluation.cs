using System;
using System.Diagnostics;

namespace NEA_PROJECT
{
    /// <summary>
    ///  Determins a players best hand Type
    /// </summary>
    public class HandEvaluation
    {

        public static int minHandSize = 5;

        public  Card[] playersBestHand = new Card[7];

        public int[] playerBestCardVals = new int[5];
        /// <summary>
        /// Each type of poker hand
        /// </summary>
        public enum PokerHand
        {
            NoHand,
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
        /// <summary>
        /// takes an array of cards
        /// returns the number of non null cards
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
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
        // takes 3 parameters a player and array of carsds and the number of cards
        public PokerHand GetBestHand(Player player,Card[] cards, int NumOfCards)
        {
            Debug.Assert(player.handStrength.CheckCardsExistInCombinedHand(cards));

            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Player_Best_Hand_Name);
            if (GetNumberOfValidCards(cards) >= minHandSize)
            {
                if (IsHandAStraightFlush(cards,NumOfCards)) 
                    return PokerHand.StraightFlush;
                else if (IsHandAPoker(cards, NumOfCards))
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
            else
            {
                for(int i = 0;i<GetNumberOfValidCards(cards);++i)
                {
                    playersBestHand[i] = cards[i];
                }
                return PokerHand.HighCard;
            }
            
        }
        /// <summary>
        /// Checks to see if the hand is a straight flush 
        /// and copies the values of the straight flush over to  players best hand 
        /// and returns true
        /// else false
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool IsHandAStraightFlush(Card[] cards, int NumOfCards)
        {
            
            if (IsHandAFlush(cards, NumOfCards))
            {
                Card[] BestFlushHand = new Card[GetNumberOfValidCards(playersBestHand)];
                Array.Copy(playersBestHand, BestFlushHand, BestFlushHand.Length);
                if (IsHandAStraight(BestFlushHand, BestFlushHand.Length))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the hand is a poker(4 of a Kind)
        /// and it copies the value of to players best hand
        /// and returns true
        /// else false
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool IsHandAPoker(Card[] cards, int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(playersBestHand, 0, playersBestHand.Length);
            int pokerPoint = 4;
            int duplicateMatch = DuplicateValueCheck(cards, NumOfCards, pokerPoint);
            if (duplicateMatch != 0)
            {
                CopyDuplicatesToBestHand(cards, NumOfCards, duplicateMatch, pokerPoint);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks to see if a players hand is a full house 
        /// if it is it returns true 
        /// else false
        /// copies cards over to players best hand
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool IsHandAFullHouse(Card[] cards, int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            
            Array.Clear(playersBestHand, 0, playersBestHand.Length);

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
        /// <summary>
        /// Checks to see if a players hand is a flush
        /// if it is it returns true 
        /// else false
        /// copies cards over to players best hand
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool IsHandAFlush(Card[] cards, int NumOfCards) // Checks Cards to see if your hand is a flush
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(playersBestHand, 0, playersBestHand.Length);

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

        /// <summary>
        /// Checks to see if a players hand is a flush
        /// if it is it returns true 
        /// else false
        /// copies cards over to players best hand
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool IsHandAStraight(Card[] cards, int NumOfCards)
        {
            Array.Clear(playersBestHand, 0, playersBestHand.Length);

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
                            playersBestHand[bestHandIndex] = inputCard;
                            ++bestHandIndex;
                            playersBestHand[bestHandIndex] = compareCard;
                            ++bestHandIndex;
                            firstEntry = false;
                            ++matchesFound;
                        }
                        else
                        {
                            playersBestHand[bestHandIndex] = compareCard;
                            ++bestHandIndex;
                            ++matchesFound;
                        }
                        break;
                    case CardComparison.NonAdjacentVal:
                        Array.Clear(playersBestHand, 0, playersBestHand.Length);
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
                    playersBestHand[bestHandIndex] = cards[0];
                    return true;
                }
                if (matchesFound >= minHandSize - 1)
                {
                    return true;
                }
                
            }
            return false;
        }
        /// <summary>
        /// Checks to see if a players hand is a straight
        /// if it is it returns true 
        /// else false
        /// copies cards over to players best hand
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool IsHandAThreeOfAKind(Card []cards, int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(playersBestHand, 0, playersBestHand.Length);

            int threeOfAKindPoint = 3;
            int duplicateMatch = DuplicateValueCheck(cards, NumOfCards, threeOfAKindPoint);
            if (duplicateMatch != 0)
            {
                CopyDuplicatesToBestHand(cards, NumOfCards, duplicateMatch, threeOfAKindPoint);
                return true;
            }
            return false; 
        }
        /// <summary>
        /// Checks to see if a players hand is a two pair
        /// if it is it returns true 
        /// else false
        /// copies cards over to players best hand
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool IsHandATwoPair(Card[]cards,int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(playersBestHand, 0, playersBestHand.Length);

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
        /// <summary>
        /// Checks to see if a players hand is a pair
        /// if it is it returns true 
        /// else false
        /// copies cards over to players best hand
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool IsHandAPair(Card[]cards,int NumOfCards)
        {
            Debug.Assert(CheckCardsDescend(cards, NumOfCards));
            Array.Clear(playersBestHand, 0, playersBestHand.Length);

            int pairPoint = 2;
            int duplicateMatch = DuplicateValueCheck(cards, NumOfCards, pairPoint);
            if (duplicateMatch != 0)
            {
                CopyDuplicatesToBestHand(cards, NumOfCards, duplicateMatch, pairPoint);
                return true;
            }
            return false;
        }
        /// <summary>
        /// sorts card values into descending order
        /// returning an array of cards
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public Card[] SortCardValues(Card[] cards, int NumOfCards) // Sorts Card values from highest to lowest
        {
            try
            {
                do
                {
                    for (int i = 0; i < NumOfCards - 1; ++i)
                    {
                        if (cards[i] != null)
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
                }
                while (CheckCardsDescend(cards, NumOfCards) == false);
            }           
            catch(ArgumentNullException)
            {
                Console.WriteLine("Null value passed in");
            }
            return cards;
        }
        /// <summary>
        /// Checking that cards in a card array descend
        /// used mainly when sorting
        ///                          
        /// </summary>
        /// <param name="cardList"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
        public bool CheckCardsDescend(Card [] cardList, int NumOfCards)
        {
            for(int i = 0;i<NumOfCards-1;++i)
            {
                if (cardList[i] != null)
                {
                    if (cardList[i].Value < cardList[i + 1].Value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
       
        /// <summary>
        /// Compares card values to see if they match are adjacent or are non sequential
        /// and returns the an enum value from card comparison
        /// </summary>
        /// <param name="cardVal1"></param>
        /// <param name="cardVal2"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks to see if an ace and two are both present in an array of cards
        /// mainly used when testing for a straight and straight flush
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <returns></returns>
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
        /// <summary>
        /// copies all cards of the correct suit over to player best hand
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <param name="SuitChoice"></param>
        public void CopySuitToBestHand(Card [] cards, int NumOfCards, Card.CardSuit SuitChoice)
        {
            Array.Clear(playersBestHand, 0, playersBestHand.Length);

            int bestHandIndex = 0;
            for(int i = 0;i < NumOfCards; ++i)
            {
                if (cards[i].Suit == SuitChoice)
                {
                    playersBestHand[bestHandIndex] = cards[i];
                    ++bestHandIndex;
                }
            }
        }
        /// <summary>
        /// Copies all values that appear more than once over to best hand 
        /// also checks to see if that value is already in best hand so it can ignore it 
        /// 
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="NumOfCards"></param>
        /// <param name="cardMatchVal"></param>
        /// <param name="valueAddLimit"></param>
        /// <param name="bestHandIndex"></param>
        public void CopyDuplicatesToBestHand(Card[] cards, int NumOfCards, int cardMatchVal, int valueAddLimit, int bestHandIndex = 0)
        {
            valueAddLimit += bestHandIndex;
            for (int i = 0; i < NumOfCards; ++i)
            {
                if (cards[i].Value == cardMatchVal)
                {
                    playersBestHand[bestHandIndex] = cards[i];
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
