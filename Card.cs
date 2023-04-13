﻿using System;
using System.Diagnostics;


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

        public static int Ace = 14;
        public static int King = 13;
        public static int Queen = 12;
        public static int Jack = 11;

        CardSuit cardsuit;


        public void SetCard(CardSuit cardsuit, int cardvalue)
        {
            Debug.Assert(cardvalue >= 2 && cardvalue <= Ace);
            Suit = cardsuit;
            Value = cardvalue;
        }
        
        public CardSuit Suit
        {
            get { return cardsuit; }
            set { cardsuit = value; }
        }

        int cardvalue;// 2 = Two, 3 = Three ... 13 = King Ace = 14 (makes sorting higher to lower easier)

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
                case 14:
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
