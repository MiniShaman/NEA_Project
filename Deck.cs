using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;


namespace NEA_PROJECT
{
    /// <summary>
    /// Stores a deck of cards that are shuffled and used for the game 
    /// <
    public class Deck
    {
        int deckPlace = 0;
        public const int DeckSize = 52;
        public const int SuitSize = 14; // our card values go from 2 - 14

        public static Card[] deck = new Card[DeckSize];

        Random RandomGenerator = new Random();
        
        /// <summary>
        /// Initialises the deck array and creates a default non-shuffled deck of cards
        /// </summary>
        public Deck()
        {
            for (int i = 0; i < DeckSize; ++i)
            {
                deck[i] = new Card();
            }
            CreateDefault();
        }
        /// <summary>
        /// Display all cards in the deck array
        /// 
        public void DeckDisplay() // Displays all elements in the deck array
        {
            for (int i = 1; i <= DeckSize; ++i)
            {
                Console.WriteLine(deck[i]);
            }
        }
        /// <summary>
        /// Tests The Shuffle Function to make sure that all 52 cards are printed out 
        /// and that non repeat
        /// </summary>
        public void TestShuffledDeck()
        {           
            int deckposition = 0;
            Shuffle();
            try
            {
                Card currentCard = new Card();
                Card previousCard = new Card();
                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 0; j < 13; ++j)
                    {
                        currentCard = deck[deckposition];
                        if (currentCard == previousCard)
                        {
                            Console.WriteLine("Error - Repeat Card Detected");
                            Debug.Assert(currentCard != previousCard);
                        }
                        Console.Write(currentCard.GetDisplayString());
                        Console.Write("  ");
                        previousCard = currentCard;
                        ++deckposition;
                    }
                    Console.WriteLine("");
                }
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Error - This is outside of the array range!");
            }
        }

        /// <summary>
        ///  Creates a standard, unshuffled deck of cards
        /// 
        public void CreateDefault() 
        {
            Card.CardSuit suit = Card.CardSuit.Hearts;
            int value = 1; // remember an Ace is 14, so we start at 2
            foreach (Card card in deck)
            {
                value++;
                card.Value = value;
                card.Suit = suit;
                if (value == SuitSize)
                {
                    value = 1;
                    suit = suit + 1;
                }
            }
        }
        /// <summary>
        /// Creates a Shuffled deck of Cards
        /// runs through each position in the deck with a counter
        public void Shuffle()  
        {
            CreateDefault();
            for(int i = 0;i<DeckSize;++i)
            {
                int randomCardPosition = RandomGenerator.Next(0, DeckSize);
                Card holdCard = deck[i];
                deck[i] = deck[randomCardPosition];
                deck[randomCardPosition] = holdCard;
            }
        }
        /// <summary>
        /// Takes a bool to see if cards should be displayed or hidden by X's
        /// Sets Current Card to the place in the deck
        /// Displays current card and will hide it if showcard is false 
        /// it then returns the current card
        public Card DealAndDisplayCard(bool showCard = true)
        {
            Card CurrentCard = deck[deckPlace];
            CurrentCard.DisplayCard(showCard);
            ++deckPlace;
            return CurrentCard;
        }
        
        // function which runs through each element in the deck array
        // and checks to see if it already exists. 
        // If so (does exist) return true
        // else false.
        bool CheckCardRep(int sVal, int vVal, int Vount)
        {
            for (int i = 0; i < DeckSize; ++i)
            {
                Card card = deck[i];
                 if((int)card.Suit == sVal && card.Value == vVal)
                 {
                    return true;
                 }               
            }
            return false;
        }
       public int GetRandomVal() // Gets a random value for a Card
        {
            int cardValue = RandomGenerator.Next(2, SuitSize + 1);
            return cardValue;
            
        }
        public int GetRandomSuit() // Gets a random suit for a card
        {
            int suit = RandomGenerator.Next(0, 4);
            return suit;
        }

        public void DisplayAll() // Displays all elements in the array in clear way ('Value' of 'Suit')
        {
            foreach (Card card in deck)
            {
                Console.WriteLine(card.GetDisplayString());
            }
        }
    }
}
