﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class Chips
    {
        public int PlayerChipCount = 100;
        public int roundBetTotal = 0;
        public static int MinBetAmount = 1;
        public Chips()
        {

        }    
        public void BetAmount(DisplayManager.DisplayPosition playerChips, DisplayManager.DisplayPosition playerTotalBet, bool AI, int betPlaced = 0 )
        {
            if (!AI)
            {
                Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BetTextDisplay);

                Console.WriteLine("How much would you like to bet?");

                betPlaced = Program.gameInputs.BetValueCheck(PlayerChipCount);
            }

            //Program.myDisplay.SetCursorPosition(playerChips);
            //Program.myDisplay.ClearText("Chips: " + PlayerChipCount);

            roundBetTotal += betPlaced;
            PlayerChipCount -= betPlaced;
            Program.TableTotal += betPlaced;

            /*Program.myDisplay.SetCursorPosition(playerChips);
            Console.WriteLine("Chips: " + PlayerChipCount);
            Program.myDisplay.SetCursorPosition(playerTotalBet);
            Console.WriteLine("Total Bet in Round: " + roundBetTotal);
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Table_Total);
            Console.WriteLine("Table Total: " + Program.TableTotal);*/

        }
        /*
         * public void BetAmount()
        {
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BetTextDisplay);

            Console.WriteLine("How much would you like to bet?");
            int betPlaced = Program.gameInputs.IntInput();

            int chipBet = Program.gameInputs.BetValueCheck(betPlaced, PlayerChipCount);

            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Player);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Chips: " + PlayerChipCount);

            PlayerChipCount -= chipBet;
            TableTotal += chipBet;

            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Player);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Chips: " + PlayerChipCount);
            Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Table_Total);
            Console.WriteLine("Table Total: " + TableTotal);

        }
         */

        /*public int BetValueCheck(int betAmount, int PlayerChips)
        {
            while (PlayerChips < betAmount || betAmount < Chips.MinBetAmount)
            {
                Program.myChips.BetAmount();
            }
            return betAmount;
        }*/
    }
}
