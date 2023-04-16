using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    /// <summary>
    /// Chips stores the players chip count, the amount they've bet so far in the round and the minimum bet amount
    /// It is instanciated inside the player class 
    /// </summary>
    public class Chips
    {
        public int PlayerChipCount = 100;
        public int roundBetTotal = 0;
        public static int MinBetAmount = 0;
        public Chips()
        {

        }    
        /// <summary>
        /// Takes 6 parameter Two players ( AI and the user), the display positions for their chips and checks whether an AI is betting and how they've bet if they are
        /// if AI is betting it skips bet value check then *** -> decreases  round bet total and player chip count by the bet placed and the table total increases by it
        /// if Player bet it checks to see if the bet is valid in the table circumstances and once it returns that value then ***
        ///
        /// </summary>
        public void BetAmount(Player player,Player AI,DisplayManager.DisplayPosition playerChips, DisplayManager.DisplayPosition playerTotalBet, bool isAnAI, int betPlaced = 0 )
        {

                
            if (!isAnAI)
            {
                {
                    Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Bet_Text_Display);

                    Console.WriteLine("How much would you like to bet?");

                    betPlaced = Program.gameInputs.BetValueCheck(PlayerChipCount, player, AI, isAnAI);
                }
            }
            roundBetTotal += betPlaced;
            PlayerChipCount -= betPlaced;
            Program.TableTotal += betPlaced;
        }
    }
}
