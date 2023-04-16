using System;

namespace NEA_PROJECT
{
    /// <summary>
    /// Where the main game is played and where most classes are instantiated
    /// </summary>
    class Program
    { 

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
        public static bool playersTurn;

        static void Main(string[] args)
        {
            handTest.DoHandTests(player);
            myDisplay.InitialiseDisplay();

            myDeck.Shuffle();
            myDisplay.SetupDisplay(player.myChips.PlayerChipCount, aiPlayer.myChips.PlayerChipCount);                

            //game loop added in
            //Plays a full game and gives the option for the player to replay
            while (playGame)
            {
                player.myChips.roundBetTotal = 0;
                aiPlayer.myChips.roundBetTotal = 0;

                DealAllPlayerCards(false);

                firstBet = true;
                playersTurn = communityTable.IsUserFirstPlayer();

                roundPosition = Table.RoundPhases.Pre_Flop;

                while (roundPosition != Table.RoundPhases.Finish_Round)
                {
                    myDisplay.UpdateDisplay(player, aiPlayer);
                    firstBet = true;
                    try
                    {
                        while (!communityTable.AdvanceRound(player, aiPlayer))
                        {

                            if (playersTurn && !player.playerAllInState)
                            {
                                player.myChips.BetAmount(player, aiPlayer, DisplayManager.DisplayPosition.Chips_Player, DisplayManager.DisplayPosition.Player_Round_Bet_Total, false);
                                if (player.playerFolded)
                                {
                                    break;
                                }
                            }
                            else if (!playersTurn && !aiPlayer.playerAllInState)
                            {
                                aiPlayer.myChips.BetAmount(player, aiPlayer, DisplayManager.DisplayPosition.Chips_AI_Player, DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total, true, aiPlayer.AIBetAmount(aiPlayer, player, roundPosition));
                                if (aiPlayer.playerFolded)
                                {
                                    break;
                                }
                            }
                            if (player.playerFolded || aiPlayer.playerFolded || (player.playerAllInState && aiPlayer.playerAllInState))
                            {
                                break;
                            }

                            playersTurn = !playersTurn;
                            firstBet = false;
                            myDisplay.UpdateDisplay(player, aiPlayer);
                        }
                    }
                    catch (StackOverflowException)
                    {
                        Console.WriteLine("Error - Insufficient Memory, Game looped for to long");
                    }
                    player.HandEvaluatorSystem(player);
                    aiPlayer.HandEvaluatorSystem(aiPlayer);
                    if (player.playerAllInState && aiPlayer.playerAllInState && roundPosition == Table.RoundPhases.River)
                    {
                        break;
                    }

                    if (player.playerFolded || aiPlayer.playerFolded)
                    {
                        break;
                    }
                    //player.HandEvaluatorSystem();
                    //aiPlayer.HandEvaluatorSystem();
                    ++roundPosition;
                    communityTable.DisplayTableCards(roundPosition);
                }
                // Game has ended here
                DisplayAllPlayerCards(true);

                communityTable.CheckForWin(player,aiPlayer, player.handStrength.CompareHands(player, aiPlayer));
                Console.ReadLine();
                communityTable.TableReset(player, aiPlayer);
                myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Replay_Game_Text);
                Console.WriteLine("Would you like to play again? (yes/no)");
                string gameContinue = gameInputs.StringInput();
                playGame = gameInputs.CheckConfirmation(gameContinue);
                
            }

        }
        /// <summary>
        ///  A parameter - to see if AI shows cards
        ///  Deals and Displays All cards to players
        /// </summary>

        static public void DealAllPlayerCards(bool showAICards)
        {
            communityTable.DealPlayerCards(player, DisplayManager.DisplayPosition.Player_Card1, DisplayManager.DisplayPosition.Player_Card2);
            communityTable.DealPlayerCards(aiPlayer, DisplayManager.DisplayPosition.AI_Card1, DisplayManager.DisplayPosition.AI_Card2, showAICards);
        }
        /// <summary>
        ///  A parameter - to see if AI shows cards
        ///  Displays All cards to players
        /// </summary>
        static public void DisplayAllPlayerCards(bool showAICards)
        {
            communityTable.DisplayPlayerCards(player, DisplayManager.DisplayPosition.Player_Card1, DisplayManager.DisplayPosition.Player_Card2);
            communityTable.DisplayPlayerCards(aiPlayer, DisplayManager.DisplayPosition.AI_Card1, DisplayManager.DisplayPosition.AI_Card2, showAICards);
        }
    }
}

