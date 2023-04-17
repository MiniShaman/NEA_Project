using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    /// <summary>
    /// Holds all info on the Round Phases
    /// All player and table cards are dealt here
    /// 
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Store all community(non player) cards displayed on the table
        /// which is then used later when evaluating player hands 
        public static Card[] tableCards = new Card[5];
        public Table()
        {
        }
        /// <summary>
        /// Enum for each round phase in a game
        /// </summary>
        public enum RoundPhases
        {
            Pre_Flop,
            Flop,
            Turn,
            River,
            Finish_Round
           
        }
        /// <summary>
        /// Takes the round phase as a parameter then displays and stores the table cards
        /// </summary>
        /// <param name="Round"></param>
        public void DisplayTableCards(RoundPhases Round)
        {
            switch (Round)
            {
                case RoundPhases.Flop:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop1);
                    tableCards[0] = Program.myDeck.DealAndDisplayCard();
                    
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop2);
                    tableCards[1] = Program.myDeck.DealAndDisplayCard();
                    
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop3);
                    tableCards[2] = Program.myDeck.DealAndDisplayCard();

                    break;

                case RoundPhases.Turn:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Turn);
                    tableCards[3] = Program.myDeck.DealAndDisplayCard();

                    break;

                case RoundPhases.River:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.River);
                    tableCards[4] = Program.myDeck.DealAndDisplayCard();

                    break;
            }
        }

        /// <summary>
        /// Takes 4 parameters - player, Card Position 1 and 2 and show cards bool
        /// sets the 2 cards to their position and deals and displays that card out to the player/AI
        /// </summary>
        public void DealPlayerCards(Player player, DisplayManager.DisplayPosition cardPosition1, DisplayManager.DisplayPosition cardPosition2, bool showCards = true)
        {
            Program.myDisplay.SetCursorPosition(cardPosition1);
            player.myHand.playerHand[0] = Program.myDeck.DealAndDisplayCard(showCards);
            Program.myDisplay.SetCursorPosition(cardPosition2);
            player.myHand.playerHand[1] = Program.myDeck.DealAndDisplayCard(showCards);
        }

        /// <summary>
        /// Takes 4 parameters - player, Card Position 1 and 2 and show cards bool
        /// Displays the player/AI's cards out to them and hides the cards if the show cards is set to false
        /// </summary>
        public void DisplayPlayerCards(Player player, DisplayManager.DisplayPosition cardPosition1, DisplayManager.DisplayPosition cardPosition2, bool showCards = true)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            Program.myDisplay.SetCursorPosition(cardPosition1);
            Program.myDisplay.ClearText(3);
            Program.myDisplay.SetCursorPosition(cardPosition2);
            Program.myDisplay.ClearText(3);

            if (showCards)
            {
                Program.myDisplay.SetCursorPosition(cardPosition1);
                player.myHand.playerHand[0].DisplayCard();
                Program.myDisplay.SetCursorPosition(cardPosition2);
                player.myHand.playerHand[1].DisplayCard();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Program.myDisplay.SetCursorPosition(cardPosition1);
                Console.Write("XX");
                Program.myDisplay.SetCursorPosition(cardPosition2);
                Console.Write("XX");
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(left, top);
        }


        /// <summary>
        /// Takes 4 parameters - two players and their bets 
        /// Checks to see if its the first bet in the round 
        /// otherwise the function check to see if (the players bet is greater than AI bet or if the player is all in -> ai needs to bet = true) and vice versa
        /// returns false if the player needs to bet and is there turn and vice versa
        /// otherwise returns true
        /// </summary>


        public bool CheckTableBetsAreValid(Player player, Player AI, int playerBet, int aiBet)
        { 
            if (Program.firstBet)
            {
                return true;
            }

            bool playerNeedsToBet = false;
            bool aiNeedsToBet = false;

            if (player.playerAllInState || playerBet > aiBet)
                aiNeedsToBet = true;
            if (AI.playerAllInState || aiBet > playerBet)
                playerNeedsToBet = true;

            if ((aiNeedsToBet && !Program.playersTurn) || (playerNeedsToBet && Program.playersTurn))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Takes boths players as parameters
        /// If either player is all in or boths bets are equal it will return true and advance the game round 
        /// otherwise it will return false

        public bool AdvanceRound(Player player, Player AI)
        {
            if(!Program.firstBet)
            {
                bool playerBetLimit = false;
                bool aiBetLimit = false;

                // if the player is all in and they've at least bet as much as the AI they are at their limit
                if (player.playerAllInState || player.myChips.roundBetTotal == AI.myChips.roundBetTotal)
                    playerBetLimit = true;

                // if the AI is all in and they've at least bet as much as the player they are at their limit                
                if (AI.playerAllInState || AI.myChips.roundBetTotal == player.myChips.roundBetTotal)
                    aiBetLimit = true;
                
                if (aiBetLimit && playerBetLimit)
                    return true;
                else
                    return false;
            }
            return false;
        }
        /// <summary>
        /// Takes both players as parameters
        /// and resets all factors so that the game can be replayed
        public void TableReset(Player player, Player AI) // Sets up Table so the game can be replayed
        {
            Console.Clear();
            Program.TableTotal = 0;
            Array.Clear(player.myBestHand.playersBestHand, 0, player.myBestHand.playersBestHand.Length);
            Array.Clear(player.myBestHand.playersBestHand, 0, player.myBestHand.playersBestHand.Length);
            player.playerFolded = false;
            AI.playerFolded = false;
            player.playerAllInState = false;
            AI.playerAllInState = false;
            Program.myDisplay.InitialiseDisplay();
            Program.myDisplay.SetupDisplay(Program.player.myChips.PlayerChipCount, Program.aiPlayer.myChips.PlayerChipCount);
            Program.myDeck.Shuffle();
        }
        /// <summary>
        /// Takes both players as parameters aswell as a winner val
        /// if either player has folded the winner is the opposition 
        /// else the winner is displayed and the chips are added to their total and if their hands are drawn the chips are split
        /// if either players chip counts are at 0 the opposing player wins the game
        /// </summary>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <param name="winner"></param>
        public void CheckForWin(Player player, Player AI, int winner)
        {
            if(player.playerFolded)
            {
                winner = -1;
            }
            else if(AI.playerFolded)
            {
                winner = 1;
            }
            switch (winner)
            {
                case 1:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.End_Game_Text);
                    Console.WriteLine("The player wins the round." + (AI.playerFolded ? " AI Folded." : ""));
                    player.myChips.PlayerChipCount += Program.TableTotal;
                    Program.myDisplay.UpdateDisplay(player, AI);
                    break;
                case -1:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.End_Game_Text);
                    Console.WriteLine("The AI wins the round." + (player.playerFolded ? " Player Folded." : ""));
                    AI.myChips.PlayerChipCount += Program.TableTotal;
                    Program.myDisplay.UpdateDisplay(player, AI);
                    break;
                case 0:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.End_Game_Text);
                    Console.WriteLine("The round is a draw");
                    int splitWinning = Program.TableTotal / 2;
                    player.myChips.PlayerChipCount += splitWinning;
                    AI.myChips.PlayerChipCount += splitWinning;
                    Program.myDisplay.UpdateDisplay(player, AI);
                    break;
            }
            if(player.myChips.PlayerChipCount == 0)
            {
                Console.WriteLine("AI wins the game");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if(AI.myChips.PlayerChipCount == 0)
            {
                Console.WriteLine("Player wins the game");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Randomly assigns the first player position
        /// returns true if the user is the first player
        /// returns false if the ai goes first
        /// </summary>
        /// <returns></returns>
        public bool IsUserFirstPlayer()
        {
            Random playerChoice = new Random();
            int startPlayer =  playerChoice.Next(0, 2);
            switch(startPlayer)
            {
                case 0:
                    return false;
                case 1:
                    return true;
            }
            return true;
        }
    }
}
