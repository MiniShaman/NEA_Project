using System;
using System.Collections.Generic;
using System.Text;


namespace NEA_PROJECT
{
    public class Deck
    {
        public const int DeckSize = 52;
        public const int SuitSize = 13;

        Card[] deck = new Card[DeckSize];

        Random RandomGenerator = new Random();

        public Deck()
        {
            for (int i = 0; i < DeckSize; ++i)
            {
                deck[i] = new Card();
            }
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
            int count = 1;
            foreach (Card card in deck)
            {
                int suitStore = GetRandomSuit(); // random value 0 - 3
                int valueStore = GetRandomVal(); // random value 1 - 13
                do
                {
                    suitStore = GetRandomSuit();
                    valueStore = GetRandomVal();
                }
                while(CheckCardRep(suitStore, valueStore, count) == true);             
                Card.CardSuit suit = new Card.CardSuit();
                suit = suit + suitStore;
                card.Value = valueStore;
                card.Suit = suit;
                ++count;
            }

        }
        
        // function which runs through each element in the deck array
        // and checks to see if it already exists. 
        // If so (does exist) return true
        // else false.
        bool CheckCardRep(int sval, int vval, int count)
        {
            for (int i = 0; i < DeckSize; ++i)
            {
                Card card = deck[i];
                 if((int)card.Suit == sval && card.Value == vval)
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
