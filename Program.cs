using System;

namespace NEA_PROJECT
{
    class Program
    {
        //public static int bestHandCombo = 7;
        //public static Card [] handStatus = new Card[bestHandCombo];
        //public static Card myCard = new Card();
        //public static int TableCount = 1;
        //public static HandEvaluation playerHand = new HandEvaluation();
        //public static Chips myChips = new Chips(); //Chips need to go to each player

        public static Deck myDeck = new Deck();       
        public static DisplayManager myDisplay = new DisplayManager();
        public static Table communityTable = new Table();      
        public static InputHandling gameInputs = new InputHandling();
        public static HandTest handTest = new HandTest();
        public static Player player = new Player();
        public static Player aiPlayer = new Player();
        public static int TableTotal = 0;
        static void Main(string[] args)
        {
            handTest.DoTests(player);

            myDeck.Shuffle();

            myDisplay.InitialiseDisplay();
            myDisplay.SetupDisplay(100);                

            communityTable.DealPlayerCards(player, DisplayManager.DisplayPosition.Player_Card1, DisplayManager.DisplayPosition.Player_Card2);
            communityTable.DealPlayerCards(aiPlayer, DisplayManager.DisplayPosition.AI_Card1, DisplayManager.DisplayPosition.AI_Card2);

            player.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
            myDisplay.UpdateDisplay(player, aiPlayer);

            aiPlayer.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount());
            myDisplay.UpdateDisplay(player, aiPlayer);

            communityTable.DisplayTableCards(Table.TableCards.Flop, player);
            
            player.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
            myDisplay.UpdateDisplay(player, aiPlayer);

            aiPlayer.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount());
            myDisplay.UpdateDisplay(player, aiPlayer);

            communityTable.DisplayTableCards(Table.TableCards.Turn, player);

            player.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
            myDisplay.UpdateDisplay(player, aiPlayer);

            aiPlayer.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount());
            myDisplay.UpdateDisplay(player, aiPlayer);

            communityTable.DisplayTableCards(Table.TableCards.River, player);

            player.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
            myDisplay.UpdateDisplay(player, aiPlayer);

            aiPlayer.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount());
            myDisplay.UpdateDisplay(player, aiPlayer);
        }  
        

    }
}

