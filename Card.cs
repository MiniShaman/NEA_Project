using System;
using System.Diagnostics;


namespace NEA_PROJECT
{
    /// <summary>
    /// Contains All in info on the Card
    /// which are the suit and card value
    /// </summary>
    public class Card
    {
        /// <summary>
        /// All 4 card suits 
        /// </summary>
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

        /// <summary>
        /// Takes two parameters the card value and suit 
        /// A card is then set with a suit and value
        /// and an assert happens if the value passed in is outside the usual value range
        /// </summary>
        public void SetCard(CardSuit cardsuit, int cardvalue)
        {
            Debug.Assert(cardvalue >= 2 && cardvalue <= Ace);
            Suit = cardsuit;
            Value = cardvalue;
        }
        
        /// <summary>
        /// gets and sets the card suit to the Card
        /// </summary>
        public CardSuit Suit
        {
            get { return cardsuit; }
            set { cardsuit = value; }
        }

        int cardvalue;// 2 = Two, 3 = Three ... 13 = King Ace = 14 (makes sorting higher to lower easier)

        /// <summary>
        /// gets and sets the card value to the Card
        /// </summary>
        public int Value
        {
            get { return cardvalue; }
            set { cardvalue = value; }
        }
        /// <summary>
        /// takes the show card parameter which is preset to true
        /// if show card is false, the cards are hidden
        /// else it displays the card val and suit in the appropriate colour of the suit 
        /// </summary>
        /// <param name="showCard"></param>
        public void DisplayCard(bool showCard = true)
        {
            string cardString = "";
            if (showCard == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                cardString = "XX";
            }
            else
            {
                cardString = GetDisplayString();

                switch (Suit)
                {
                    case CardSuit.Hearts:
                    case CardSuit.Diamonds:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }
            }
            Console.Write(cardString);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// sets a suit symbol with a specific and special character to a string 
        /// then a value is added to that string  or a character if its ace, king, queen or jack
        /// then returns that string
        /// </summary>
        /// <returns></returns>
        public string GetDisplayString()
        {
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
