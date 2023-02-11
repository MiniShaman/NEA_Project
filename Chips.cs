using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class Chips
    {
        DisplayManager chipsDisplay = new DisplayManager();
        public int PlayerChipCount = 100;
        public int TableTotal = 0;
        public Chips()
        {

        }    
        public void BetAmount()
        {
            chipsDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BetTextDisplay);
            Console.WriteLine("How much would you like to bet?");
            int betPlaced = int.Parse(Console.ReadLine());
            int chipBet = BetValueCheck(betPlaced, PlayerChipCount);
            chipsDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Player);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Chips: " + PlayerChipCount);
            PlayerChipCount -= chipBet;
            TableTotal += chipBet;
            chipsDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Player);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Chips: " + PlayerChipCount);
            chipsDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Chips_Table_Total);
            Console.WriteLine("Table Total: " + TableTotal);

        }
        public int BetValueCheck(int betAmount, int PlayerChips)
        {
            while(PlayerChips < betAmount)
            {
                BetAmount();
            }
            return betAmount;
        }
    }
}
