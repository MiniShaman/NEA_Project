using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class Table
    {
        public static Card[] tableCards = new Card[5];
        public Table()
        {
            Hand.InitialiseHand(tableCards);
        }
        public void FullRound()
        {
            /*DisplayHand();
            TableChips.BetAmount();
            DisplayTableCards();
            TableChips.BetAmount();
            DisplayTableCards();
            TableChips.BetAmount();
            DisplayTableCards();
            TableChips.BetAmount();*/
        }
        public enum RoundPhases
        {
            Pre_Flop,
            Flop,
            Turn,
            River,
            Finish_Round
           
        }
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

                    // displays the best current hand
                    //player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.flopCardCheckpoint);
                    //Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    //Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.flopCardCheckpoint);
                    break;
                case RoundPhases.Turn:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Turn);
                    tableCards[3] = Program.myDeck.DealAndDisplayCard();

                    // displays the best current hand
                    //player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.turnCardCheckpoint);
                    //Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    //Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.turnCardCheckpoint);
                    break;
                case RoundPhases.River:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.River);
                    tableCards[4] = Program.myDeck.DealAndDisplayCard();

                    // displays the best hand
                    //player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.riverCardCheckpoint);
                    //Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    //Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.riverCardCheckpoint);
                    //HandEvaluation.PokerHand displayBestHand = player.myHand.GetBestHand(player.myBestHand.EvaluationHand, HandEvaluation.riverCardCheckpoint);
                    //Console.WriteLine(displayBestHand.ToString());
                    //Program.myDisplay.DisplayAllCards(HandEvaluation.bestHand, HandEvaluation.riverCardCheckpoint);
                    break;
            }
        }
        /*
         public void DisplayTableCards(TableCards Round, Player player)
        {
            switch (Round)
            {
                case TableCards.Flop:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop1);
                    player.myBestHand.BestHandChoice (Program.myDeck.DealAndDisplayCard());
                    
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop2);
                    player.myBestHand.BestHandChoice(Program.myDeck.DealAndDisplayCard());
                    
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop3);
                    player.myBestHand.BestHandChoice(Program.myDeck.DealAndDisplayCard());
                    
                    player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.flopCardCheckpoint);
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.flopCardCheckpoint);
                    break;
                case TableCards.Turn:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Turn);
                    player.myBestHand.BestHandChoice(Program.myDeck.DealAndDisplayCard());
                    player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.turnCardCheckpoint);
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.turnCardCheckpoint);
                    break;
                case TableCards.River:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.River);
                    player.myBestHand.BestHandChoice(Program.myDeck.DealAndDisplayCard());
                    player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.riverCardCheckpoint);
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.riverCardCheckpoint);
                    HandEvaluation.PokerHand displayBestHand = player.myHand.GetBestHand(player.myBestHand.EvaluationHand, HandEvaluation.riverCardCheckpoint);
                    Console.WriteLine(displayBestHand.ToString());
                    Program.myDisplay.DisplayAllCards(HandEvaluation.bestHand, HandEvaluation.riverCardCheckpoint);
                    break;
            }
        }
         */
        public void DealPlayerCards(Player player, DisplayManager.DisplayPosition cardPosition1, DisplayManager.DisplayPosition cardPosition2)
        {
            //my cards
            Program.myDisplay.SetCursorPosition(cardPosition1);
            player.myHand.playerHand[0] = Program.myDeck.DealAndDisplayCard();
            Program.myDisplay.SetCursorPosition(cardPosition2);
            player.myHand.playerHand[1] = Program.myDeck.DealAndDisplayCard();
            /*Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.AI_Card1);
            Program.myDeck.DealAndDisplayCard();
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.AI_Card2);
            Program.myDeck.DealAndDisplayCard();*/

            // display best hand
            //player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.handCardCheckpoint);
            //Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
            //Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.handCardCheckpoint);
        }
        /*
         public void DisplayHand(Player player)
        {
            //my cards
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Player_Card1);
            BestHandChoice(Program.myDeck.DealAndDisplayCard());
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Player_Card2);
            BestHandChoice(Program.myDeck.DealAndDisplayCard());
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.AI_Card1);
            Console.WriteLine("**");
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.AI_Card2);
            Console.WriteLine("**");
            player.myHand.SortCardValues(EvaluationHand,HandEvaluation.handCardCheckpoint);
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
            Program.myDisplay.DisplayAllCards(EvaluationHand, HandEvaluation.handCardCheckpoint);
        }
         */

        /*public void BestHandChoice(Card CurrentCard)
        {
            EvaluationHand[bestHandCounter] = CurrentCard;
            ++bestHandCounter;
        }*/
        public bool TableBetsCheck(Player player, Player AI,int playerBet, int aiBet) // Checks all incoming bets to see if they match or a player is all in to allow the game to progress
        {
            bool playerBetLimit = false;
            bool aiBetLimit = false;
            if(player.playerAllIn || playerBet == aiBet)
                playerBetLimit = true;
            if (AI.playerAllIn || aiBet == playerBet)
                aiBetLimit = true;
            if (aiBetLimit && playerBetLimit)
                return true;
            else
                return false;
        }
        public void TableReset(Player player, Player AI) // Sets up Table so the game can be replayed
        {
            Console.Clear();
            Program.TableTotal = 0;
            Array.Clear(player.myBestHand.playersBestHand, 0, player.myBestHand.playersBestHand.Length);
            Array.Clear(player.myBestHand.playersBestHand, 0, player.myBestHand.playersBestHand.Length);
            player.playerFolded = false;
            AI.playerFolded = false;
            player.playerAllIn = false;
            AI.playerAllIn = false;
            Program.myDisplay.InitialiseDisplay();
            Program.myDisplay.SetupDisplay(Program.player.myChips.PlayerChipCount, Program.aiPlayer.myChips.PlayerChipCount);
            Program.myDeck.Shuffle();
        }
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
                    Console.WriteLine("The player wins the round");
                    player.myChips.PlayerChipCount += Program.TableTotal;
                    Program.myDisplay.UpdateDisplay(player, AI);
                    break;
                case -1:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.End_Game_Text);
                    Console.WriteLine("The AI wins the round");
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
                Environment.Exit(0);
            }
            else if(AI.myChips.PlayerChipCount == 0)
            {
                Console.WriteLine("Player wins the game");
                Environment.Exit(0);
            }
        }
    }
}
