using System;

namespace NEA_PROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu myMenu = new Menu();
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            int choice = myMenu.StartMenu();
            if(choice == 1)
            {
                myDeck.DealCard();
                myDeck.DealCard();
            }
        }
    }
}

