using System;
using System.Collections.Generic;
using System.Text;


namespace NEA_PROJECT
{
    public class Card
    {
        public enum CardSuit
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        }

        CardSuit cardsuit;

        public void SetCard(CardSuit cardsuit, int cardvalue)
        {
            Suit = cardsuit;
            Value = cardvalue;
        }
        
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

        public void DisplayCard()
        {
            string cardString = GetDisplayString();
            switch (Suit)
            {
                case CardSuit.Hearts:
                case CardSuit.Diamonds:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.Write(cardString);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public string GetDisplayString()
        {
            //"1 of Hearts"
            //string cardPrint = Value.ToString() + " of " + Suit.ToString();
            //return cardPrint;

            /*string cardPrint;
            if (Value == 1)
                cardPrint = "A";
            else
                cardPrint = Value.ToString();
            cardPrint += Suit.ToString();
            return cardPrint;*/

            string cardPrint;
            string SuitSymbol = "\u2665";
            switch (Suit)
            {
                case CardSuit.Hearts:
                    SuitSymbol = "\u2665";
                    break;
                case CardSuit.Diamonds:
                    SuitSymbol = "\u2666";
                    break;
                case CardSuit.Spades:
                    SuitSymbol = "\u2660";
                    break;
                case CardSuit.Clubs:
                    SuitSymbol = "\u2663";
                    break;
            }
            switch(Value)
            {
                case 1:
                    cardPrint = "A" + SuitSymbol;
                break;
                case 11:
                    cardPrint = "J" + SuitSymbol;
                break;
                case 12:
                    cardPrint = "Q" + SuitSymbol;
                    break;
                case 13:
                    cardPrint = "K" + SuitSymbol;
                    break;
                default:
                    cardPrint = Value.ToString() + SuitSymbol;
                    break;
            }
            return cardPrint;
        }
    }
}
