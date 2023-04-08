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
        public static Table.RoundPhases roundPosition;
        public static bool playGame = true;
        public static bool firstBet = true;
        static void Main(string[] args)
        {
            handTest.DoTests(player);
            myDisplay.InitialiseDisplay();

            myDeck.Shuffle();
            myDisplay.SetupDisplay(player.myChips.PlayerChipCount, aiPlayer.myChips.PlayerChipCount);                

            /*communityTable.DealPlayerCards(player, DisplayManager.DisplayPosition.Player_Card1, DisplayManager.DisplayPosition.Player_Card2);
            communityTable.DealPlayerCards(aiPlayer, DisplayManager.DisplayPosition.AI_Card1, DisplayManager.DisplayPosition.AI_Card2);

            player.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
            myDisplay.UpdateDisplay(player, aiPlayer);

            aiPlayer.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount());
            myDisplay.UpdateDisplay(player, aiPlayer);

            
            
            player.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
            myDisplay.UpdateDisplay(player, aiPlayer);

            aiPlayer.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount());
            myDisplay.UpdateDisplay(player, aiPlayer);

            communityTable.DisplayTableCards(Table.RoundPhases.Turn);

            player.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
            myDisplay.UpdateDisplay(player, aiPlayer);

            aiPlayer.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount());
            myDisplay.UpdateDisplay(player, aiPlayer);

            communityTable.DisplayTableCards(Table.RoundPhases.River);

            player.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
            myDisplay.UpdateDisplay(player, aiPlayer);

            aiPlayer.myChips.BetAmount(DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount());
            myDisplay.UpdateDisplay(player, aiPlayer);*/
            //game loop added in
            while (playGame)
            {
                player.myChips.roundBetTotal = 0;
                aiPlayer.myChips.roundBetTotal = 0;

                communityTable.DealPlayerCards(player, DisplayManager.DisplayPosition.Player_Card1, DisplayManager.DisplayPosition.Player_Card2);
                communityTable.DealPlayerCards(aiPlayer, DisplayManager.DisplayPosition.AI_Card1, DisplayManager.DisplayPosition.AI_Card2);

                firstBet = true;
                bool playersTurn = true;

                roundPosition = Table.RoundPhases.Pre_Flop;

                while (roundPosition != Table.RoundPhases.Finish_Round)
                {
                    myDisplay.UpdateDisplay(player, aiPlayer);
                    firstBet = true;
                    while (!communityTable.TableBetsCheck(player, aiPlayer,player.myChips.roundBetTotal,aiPlayer.myChips.roundBetTotal) || firstBet)
                    {
                        firstBet = false; 
                        if (playersTurn && !player.playerAllIn)
                        {
                            player.myChips.BetAmount(player,aiPlayer,DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
                            if(player.playerFolded)
                            {
                                break;
                            }
                        }
                        else if (!playersTurn && !aiPlayer.playerAllIn)
                        {
                            aiPlayer.myChips.BetAmount(player, aiPlayer,DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount(aiPlayer,player));
                            if (aiPlayer.playerFolded)
                            {
                                break;
                            }
                        }
                        if (player.playerFolded || aiPlayer.playerFolded || (player.playerAllIn && aiPlayer.playerAllIn))
                        {
                            break;
                        }
                        

                        playersTurn = !playersTurn;
                        myDisplay.UpdateDisplay(player, aiPlayer);
                    }

                    player.HandEvaluatorSystem();
                    aiPlayer.HandEvaluatorSystem();
                    
                    if (player.playerFolded || aiPlayer.playerFolded || (player.playerAllIn && aiPlayer.playerAllIn))
                    {
                        break;
                    }
                    //player.HandEvaluatorSystem();
                    //aiPlayer.HandEvaluatorSystem();
                    ++roundPosition;
                    communityTable.DisplayTableCards(roundPosition);
                }
                communityTable.CheckForWin(player,aiPlayer, player.bestHand.CompareHands(player, aiPlayer));
                Console.ReadLine();
                communityTable.TableReset(player, aiPlayer);
                myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Replay_Game_Text);
                Console.WriteLine("Would you like to play again? (yes/no)");
                string gameContinue = Console.ReadLine();
                playGame = gameInputs.CheckConfirmation(gameContinue);
                
            }

        }  
    }
}

