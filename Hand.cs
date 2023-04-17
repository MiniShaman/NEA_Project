using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    /// <summary>
    /// Holds a players Hand and Initialises it inside the class 
    /// Also contains to functions and a constructor
    public class Hand
    {
        public static int playerHandSize = 2;
        public Card[] playerHand = new Card[playerHandSize];

        /// Hands constructor, just initialises a players hand when an object is instanciated

        public Hand() 
        {
            InitialiseHand(playerHand);
            
        }
        
        /// Initialises a players hand  
        /// Takes an array of cards ("hand") and runs through a for loop of that array length to initialise them
        public static void InitialiseHand(Card[] hand)
        {
            for (int i = 0; i < hand.Length; ++i)
            {
                hand[i] = new Card();
            }
        }
        /// Takes an array of Card values(Suit and Number) and initialises all null values inside that array to prevent an exception being thrown
        /// returns the array after
        public static Card [] InitialiseNullCards(Card[] cards)
        {
            for(int i = 0; i < cards.Length;++i)
            {
                if(cards[i] == null)
                {
                    cards[i] = new Card();
                }
            }
            return cards;
        }
    }
}
