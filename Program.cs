using System;

namespace NEA_PROJECT
{
    class Program
    {
        //public static int bestHandCombo = 7;
        //public static Card [] handStatus = new Card[bestHandCombo];
        //public static Card myCard = new Card();
        //public static int TableCount = 1;

        public static Deck myDeck = new Deck();
        //public static Chips myChips = new Chips(); //Chips need to go to each player
        public static DisplayManager myDisplay = new DisplayManager();
        public static Table communityTable = new Table();
        //public static HandEvaluation playerHand = new HandEvaluation();
        public static InputHandling gameInputs = new InputHandling();
        public static HandTest handTest = new HandTest();

        public static Player player = new Player();

        static void Main(string[] args)
        {


            myDisplay.SetupDisplay();

            handTest.DoTests(player);

            //Menu myMenu = new Menu();
            //int choice = myMenu.StartMenu();
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("**                      JOSH'S POKER!                          **");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("*****************************************************************");

            myDeck.Shuffle();
            //if(choice == 1)
           //{
                myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Player);
                Console.WriteLine("Chips: " + player.myChips.PlayerChipCount);

                myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Table_Total);
                Console.WriteLine("Table Total: " + player.myChips.TableTotal);

                communityTable.DisplayHand(player);
                player.myChips.BetAmount();
                communityTable.DisplayTableCards(Table.TableCards.Flop, player);
                player.myChips.BetAmount();
                communityTable.DisplayTableCards(Table.TableCards.Turn, player);
                player.myChips.BetAmount();
                communityTable.DisplayTableCards(Table.TableCards.River, player);
                player.myChips.BetAmount();
                Console.SetCursorPosition(30, 30);

            //}
        }              
    }
}

