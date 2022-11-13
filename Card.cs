using System;
using System.Collections.Generic;
using System.Text;


namespace NEA_PROJECT
{
    class Card
    {
        public enum CardSuit
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        }

        CardSuit cardsuit;

        public CardSuit Suit
        {
            get { return cardsuit; }
            set { cardsuit = value; }
        }

        int cardvalue;// 1 = Ace, 2 = Two ... 13 = King

        public int Value
        {
            get { return cardvalue; }
            set { cardvalue = value; }
        }

        public string GetDisplayString()
        {
            //"1 Heart"
            string cardPrint = Value.ToString() + " of " + Suit.ToString();
            return cardPrint;
        }
    }
}
