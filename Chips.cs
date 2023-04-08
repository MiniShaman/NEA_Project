using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class Chips
    {
        public int PlayerChipCount = 100;
        public int roundBetTotal = 0;
        public static int MinBetAmount = 0;
        public Chips()
        {

        }    
        public void BetAmount(Player player,Player AI,DisplayManager.DisplayPosition playerChips, DisplayManager.DisplayPosition playerTotalBet, bool isAnAI, int betPlaced = 0 )
        {

                
            if (!isAnAI)
            {
                Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Bet_Or_Fold_Text);
                Console.WriteLine("Bet or Fold?");
                string gameDecision = Program.gameInputs.StringInput();
                Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Bet_Or_Fold_Text);
                Program.myDisplay.ClearText("Bet or Fold?");
                if (Program.gameInputs.DoesPlayerBet(player,gameDecision))
                {
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Bet_Text_Display);

                    Console.WriteLine("How much would you like to bet?");

                    betPlaced = Program.gameInputs.BetValueCheck(PlayerChipCount, player, AI, isAnAI);
                }
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
