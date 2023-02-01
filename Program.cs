using System;

namespace NEA_PROJECT
{
    class Program
    {
        static Deck myDeck = new Deck();
        static Chips myChips = new Chips();
        static DisplayManager myDisplay = new DisplayManager();
        static int TableCount = 1;
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Menu myMenu = new Menu();
            int choice = myMenu.StartMenu();
            myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Player);
            Console.WriteLine("Chips: " + myChips.PlayerChipCount);
            myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Table_Total);
            Console.WriteLine("Table Total: " + myChips.TableTotal);
            myDeck.Shuffle();
            if(choice == 1)
            {
                DisplayHand();
                myChips.BetAmount();
                DisplayTableCards();
                myChips.BetAmount();
                DisplayTableCards();
                myChips.BetAmount();
                DisplayTableCards();
                myChips.BetAmount();
                Console.SetCursorPosition(30, 30);

            }
        }

        static void DisplayHand()
        {
            //my cards
            myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Card1);
            myDeck.DealCard();
            myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Card2);
            myDeck.DealCard();
        }
        static void DisplayTableCards()
        {
            switch(TableCount)
            {
                case 1:
                    myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop1);
                    myDeck.DealCard();
                    myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop2);
                    myDeck.DealCard();
                    myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop3);
                    myDeck.DealCard();
                    break;
                case 2:
                    myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Turn);
                    myDeck.DealCard();
                    break;
                case 3:
                    myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.River);
                    myDeck.DealCard();
                    break;
            }
            ++TableCount;
        }
    }
}

