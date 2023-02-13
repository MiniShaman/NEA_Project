using System;

namespace NEA_PROJECT
{
    class Program
    {
        public static int bestHandCombo = 7;
        public static Card [] handStatus = new Card[bestHandCombo];
        public static Card myCard = new Card();
        public static Deck myDeck = new Deck();
        public static Chips myChips = new Chips();
        public static DisplayManager myDisplay = new DisplayManager();
        public static Table communityTable = new Table();
        public static HandEvalution playerHand = new HandEvalution();
        public static InputHandling gameInputs = new InputHandling();
        public static int TableCount = 1;

        static void Main(string[] args)
        {

            myDisplay.SetupDisplay();

            Menu myMenu = new Menu();
            int choice = myMenu.StartMenu();

            myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Player);
            Console.WriteLine("Chips: " + myChips.PlayerChipCount);

            myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Table_Total);
            Console.WriteLine("Table Total: " + myChips.TableTotal);

            myDeck.Shuffle();
            if(choice == 1)
            {
                communityTable.DisplayHand();
                myChips.BetAmount();
                communityTable.DisplayTableCards(Table.TableCards.Flop);
                myChips.BetAmount();
                communityTable.DisplayTableCards(Table.TableCards.Turn);
                myChips.BetAmount();
                communityTable.DisplayTableCards(Table.TableCards.River);
                myChips.BetAmount();
                Console.SetCursorPosition(30, 30);

            }
        }              
    }
}

