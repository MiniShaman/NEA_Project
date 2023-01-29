using System;

namespace NEA_PROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu myMenu = new Menu();
            Deck myDeck = new Deck();
            myMenu.StartMenu();
            
        }
        /*static void Main(string[] args)
        {
            DeckofCards myDeck = new DeckofCards();
            Console.WriteLine(myDeck);
        }
        class DeckofCards
        {
            const int deckSize = 52;
            const int cardNumCount = 13;
            const int cardSuitCount = 4;
            public int[] cards = new int[52];
            
            public DeckofCards()
            {
                FullDeck();
                DisplayDeck();
            }
               
            public enum CardSuit 
            {
                Hearts = 1, Diamonds = 2, Spades = 3, Clubs = 4
            }
            public enum CardNumber
            {
                Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13
            }    
            public int[] FullDeck()
            {
                for(int count = 0;count < deckSize;count++)
                {
                    cards[count] = count + 1;
                }
                return cards;
            }
            public void DisplayDeck()
            {
                int[] tempDeck = FullDeck();
               foreach (int val in tempDeck)
               {
                        int Cnum;
                  for (int Csuit = 1; Csuit <= cardSuitCount; Csuit++)
                  {

                        for (Cnum = 1; Cnum <= cardNumCount; Cnum++)
                        {
                            if (val < cardNumCount)
                            {
                                Console.WriteLine("{0} of {1} ", (CardNumber)Cnum, (CardSuit)Csuit);
                            }
                        }
                        for (Cnum = 1; Cnum <= cardNumCount; Cnum++)
                        {
                            if (val > cardNumCount || val < cardNumCount + 13)
                            {
                                Console.WriteLine("{0} of {1} ", (CardNumber)Cnum, (CardSuit)Csuit);
                            }
                        }
                        for (Cnum = 1; Cnum <= cardNumCount; Cnum++)
                        {
                            if (val > cardNumCount + 13 || val < cardNumCount + 26)
                            {
                                Console.WriteLine("{0} of {1} ", (CardNumber)Cnum, (CardSuit)Csuit);
                            }
                        }
                        for (Cnum = 1; Cnum <= cardNumCount; Cnum++)
                        {
                            if (val > cardNumCount + 26 || val < cardNumCount + 39)
                            {
                                Console.WriteLine("{0} of {1} ", (CardNumber)Cnum, (CardSuit)Csuit);
                            }
                        }
                  }                    
               }                
            }
        }*/
    }
}

