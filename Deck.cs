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

        public Deck()
        {
            for (int i = 0; i < DeckSize; ++i)
            {
                deck[i] = new Card();
            }
        }
        public void ArrayDisplay()
        {
            for (int i = 1; i <= DeckSize; ++i)
            {
                Console.WriteLine(deck[i]);
            }
        }

        public void CreateDefault()
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
        public void CreateRandom()
        {
            int count = 1;
            foreach (Card card in deck)
            {
                int suitStore = GetRandomSuit();
                int valueStore = GetRandomVal();
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
        bool CheckCardRep(int sval, int vval, int count)
        {
            for (int i = 1; i < count; ++i)
            {
                if (deck[i].ToString() == sval.ToString() && deck[i].ToString() == vval.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        int GetRandomVal()
        {
            Random cardval = new Random();
            int cardValue = cardval.Next(1, SuitSize + 1);
            return cardValue;
            
        }
        int GetRandomSuit()
        {
            Random suitVal = new Random();
            int suit = suitVal.Next(0, 4);
            return suit;


        }

        public void DisplayAll()
        {
            foreach (Card card in deck)
            {
                Console.WriteLine(card.GetDisplayString());
            }
        }
    }
}
