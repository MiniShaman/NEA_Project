using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class Table
    {
        //public static int bestHandChoiceLimit = 7;
        //public static int bestHandCounter = 0;
        //public static Card[] EvaluationHand = new Card[bestHandChoiceLimit];
        public Table()
        {

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
        public enum TableCards
        {
            Flop,
            Turn,
            River
        }
        public void DisplayTableCards(TableCards Round, Player player)
        {
            switch (Round)
            {
                case TableCards.Flop:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop1);
                    Program.myDeck.DealAndDisplayCard();
                    
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop2);
                    Program.myDeck.DealAndDisplayCard();
                    
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop3);
                    Program.myDeck.DealAndDisplayCard();

                    // displays the best current hand
                    //player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.flopCardCheckpoint);
                    //Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    //Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.flopCardCheckpoint);
                    break;
                case TableCards.Turn:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Turn);
                    Program.myDeck.DealAndDisplayCard();

                    // displays the best current hand
                    //player.myHand.SortCardValues(player.myBestHand.EvaluationHand, HandEvaluation.turnCardCheckpoint);
                    //Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    //Program.myDisplay.DisplayAllCards(player.myBestHand.EvaluationHand, HandEvaluation.turnCardCheckpoint);
                    break;
                case TableCards.River:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.River);
                    Program.myDeck.DealAndDisplayCard();

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
        public void RoundEnd()
        {

        }
    }
}
