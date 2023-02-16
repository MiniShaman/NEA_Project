using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class Table
    {
        public static int bestHandChoiceLimit = 7;
        public static int bestHandCounter = 0;
        public static Card[] BestHand = new Card[bestHandChoiceLimit];
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
        public void DisplayTableCards(TableCards Round)
        {
            switch (Round)
            {
                case TableCards.Flop:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop1);
                    BestHandChoice (Program.myDeck.DealAndDisplayCard());
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop2);
                    BestHandChoice(Program.myDeck.DealAndDisplayCard());
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop3);
                    BestHandChoice(Program.myDeck.DealAndDisplayCard());
                    Program.playerHand.SortCardValues(BestHand, HandEvalution.flopCardCheckpoint);
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    Program.myDisplay.DisplayAllCards(BestHand, HandEvalution.flopCardCheckpoint);
                    break;
                case TableCards.Turn:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Turn);
                    BestHandChoice(Program.myDeck.DealAndDisplayCard());
                    Program.playerHand.SortCardValues(BestHand, HandEvalution.turnCardCheckpoint);
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    Program.myDisplay.DisplayAllCards(BestHand, HandEvalution.turnCardCheckpoint);
                    break;
                case TableCards.River:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.River);
                    BestHandChoice(Program.myDeck.DealAndDisplayCard());
                    Program.playerHand.SortCardValues(BestHand, HandEvalution.riverCardCheckpoint);
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                    Program.myDisplay.DisplayAllCards(BestHand, HandEvalution.riverCardCheckpoint);
                   HandEvalution.PokerHand displayBestHand = Program.playerHand.GetBestHand(BestHand, HandEvalution.riverCardCheckpoint);
                    Console.WriteLine(displayBestHand.ToString());

                    break;
            }
        }
        public void DisplayHand()
        {
            //my cards
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Card1);
            BestHandChoice(Program.myDeck.DealAndDisplayCard());
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Card2);
            BestHandChoice(Program.myDeck.DealAndDisplayCard());
            Program.playerHand.SortCardValues(BestHand,HandEvalution.handCardCheckpoint);
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
            Program.myDisplay.DisplayAllCards(BestHand, HandEvalution.handCardCheckpoint);
        }
        public void BestHandChoice(Card CurrentCard)
        {
            BestHand[bestHandCounter] = CurrentCard;
            ++bestHandCounter;
        }
    }
}
