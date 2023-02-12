using System;
using System.Collections.Generic;
using System.Text;


namespace NEA_PROJECT
{
    public class Deck
    {
        int deckPlace = 0;
        public const int DeckSize = 52;
        public const int SuitSize = 13;

        public static Card[] deck = new Card[DeckSize];

        Random RandomGenerator = new Random();

        public Deck()
        {
            for (int i = 0; i < DeckSize; ++i)
            {
                deck[i] = new Card();
            }
            CreateDefault();
        }
        public void ArrayDisplay() // Displays all elements in the deck array
        {
            for (int i = 1; i <= DeckSize; ++i)
            {
                Console.WriteLine(deck[i]);
            }
        }

        public void CreateDefault() // Creates a standard, unshuffled deck of cards
        {
            Card.CardSuit suit = Card.CardSuit.Hearts;
            int value = 0;
            foreach (Card card in deck)
            {
                value++;
                card.Value = value;
                card.Suit = suit;
                if (value == SuitSize)
                {
                    value = 0;
                    suit = suit + 1;
                }
            }
        }
        public void Shuffle() // Creates a Shuffled deck of Cards
        {
            CreateDefault();
            for(int i = 0;i<DeckSize;++i)
            {
                int randomCardVal = RandomGenerator.Next(0, DeckSize);
                Card holdCard = deck[i];
                deck[i] = deck[randomCardVal];
                deck[randomCardVal] = holdCard;
            }
        }
        public Card DealAndDisplayCard()
        {
            Card CurrentCard = deck[deckPlace];
            CurrentCard.DisplayCard();
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
        int GetRandomVal() // Gets a random value for a Card
        {
            int cardValue = RandomGenerator.Next(1, SuitSize + 1);
            return cardValue;
            
        }
        int GetRandomSuit() // Gets a random suit for a card
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
