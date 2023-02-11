using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class Table
    {
        Chips TableChips = new Chips();
        
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
                    Program.myDeck.DealCard();
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop2);
                    Program.myDeck.DealCard();
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Flop3);
                    Program.myDeck.DealCard();
                    break;
                case TableCards.Turn:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Turn);
                    Program.myDeck.DealCard();
                    break;
                case TableCards.River:
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.River);
                    Program.myDeck.DealCard();
                    break;
            }
        }
    }
}
