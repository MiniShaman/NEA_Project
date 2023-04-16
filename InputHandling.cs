using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    /// <summary>
    /// Handles all inputs that occur in the game and mediate them
    /// </summary>
    public class InputHandling
    {
        public InputHandling()
        {

        }
        /// <summary>
        /// gets the player decision in the game
        /// </summary>
        /// <param name="hasFolded"></param>
        /// <returns></returns>
        public int GetGameDecision(out bool hasFolded)
        {
            bool inputValid = false;
            int betAmount = 0;
            hasFolded = false;
            while (inputValid == false)
            {
                string gameDecision = StringInput();
                gameDecision.ToLower();
                if(gameDecision == "show" || gameDecision == "s")
                {
                    Program.DisplayAllPlayerCards(true);
                }
                else if(gameDecision == "hide" || gameDecision =="h")
                {
                    Program.DisplayAllPlayerCards(false);
                }
                else if (gameDecision == "fold" || gameDecision == "f")
                {
                    if (Program.roundPosition != Table.RoundPhases.Pre_Flop)
                    {
                        hasFolded = true;
                        inputValid = true;
                    }
                }
                else if (int.TryParse(gameDecision, out betAmount))
                {
                    inputValid = true;
                }
            }
            return betAmount;
        }
        /// <summary>
        /// Checks to see what value has been returned from get game decision and makes sure it is valid
        /// then returns the bet amount if it is
        /// </summary>
        /// <param name="PlayerChips"></param>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <param name="isAnAI"></param>
        /// <returns></returns>
        public int BetValueCheck(int PlayerChips, Player player, Player AI, bool isAnAI)
        {
            int betAmount;
            bool betInvalid = false;
            bool hasFolded;
            do
            {
                int playerBet = player.myChips.roundBetTotal;
                if (AI.playerAllInState && player.myChips.roundBetTotal >= AI.myChips.roundBetTotal)
                {
                    betAmount = 0;
                    break;
                }
                else
                {
                    betAmount = GetGameDecision(out hasFolded);
                }
                if (hasFolded)
                {
                    player.playerFolded = true;
                    break;
                }
                else
                {
                    if (PlayersAllIn(player, betAmount))
                    {
                        return betAmount;
                    }
                    else if (betAmount == 0)
                    {
                        if (PlayerChecks(player, AI, isAnAI))
                        {
                            return betAmount;
                        }
                    }

                    playerBet += betAmount;
                }

                betInvalid = IsBetInvalid(player, AI, PlayerChips, betAmount, playerBet);
                if (betInvalid)
                {
                    Debug.Assert(player.playerFolded == false);
                    Debug.Assert(AI.playerFolded == false);
                    playerBet = 0;
                }
            }
            while (betInvalid); // keep doing this if the bet is not valid
            
            return betAmount;
        }
        /// <summary>
        /// Checks if the bet is invalid e.g. too much, a negative number, less than the AI bet(when not folding)
        ///  and returns true if it is invalid
        ///  else false
        /// </summary>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <param name="PlayerChips"></param>
        /// <param name="betAmount"></param>
        /// <param name="totalBetAmount"></param>
        /// <returns></returns>
        public bool IsBetInvalid(Player player, Player AI, int PlayerChips, int betAmount, int totalBetAmount)
        {
            return
                betAmount > PlayerChips ||          // bet more than you've got
                betAmount < Chips.MinBetAmount ||   // bet can't be negative
                !Program.communityTable.CheckTableBetsAreValid(player, AI, totalBetAmount, AI.myChips.roundBetTotal);
                //|| AllInBetMatch(player,AI,betAmount);
        }
        /// <summary>
        /// Checks if the AI is all in if true 
        /// then player has to either match the bet 
        /// or be all in themselves to return true
        /// else false
        /// </summary>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <param name="betAmount"></param>
        /// <returns></returns>
        public bool AllInBetMatch(Player player, Player AI,int betAmount)
        {
            if(AI.playerAllInState)
            {
                // player bet is not equal to the ai's all in bet
                // OR
                // player is also all in.
                if(betAmount != AI.myChips.roundBetTotal || player.playerAllInState)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Checks if player is trying to check if they are and there bets is equal to the AI's bet  and it's not the first bet
        /// then they return true 
        /// else returns false
        /// </summary>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <param name="isAnAI"></param>
        /// <returns></returns>
        public bool PlayerChecks(Player player, Player AI, bool isAnAI) // Determines whether a player can check and if they are choosing to do so
        {
            if (!isAnAI)
            {
                Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Player_Check_Or_All_In_Text);
                Console.WriteLine("Are you trying  to check?");                
                string answer = StringInput();
                Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Player_Check_Or_All_In_Text);
                Program.myDisplay.ClearText("Are you trying  to check?");
                if (!CheckConfirmation(answer))
                {
                    return false;
                }
            }
                if (!Program.firstBet)
                {
                    if (player.myChips.roundBetTotal == AI.myChips.roundBetTotal || AI.myChips.roundBetTotal == player.myChips.roundBetTotal)
                    {
                        int left = Console.CursorLeft;
                        int top = Console.CursorTop;
                        Console.WriteLine("Player Checks");
                        Program.myDisplay.ClearText(left, top, "Player Checks");
                        return true;
                    }
                }
            return false;
        }
        /// <summary>
        /// Checks if the players all in if true
        /// sets player all in to true and returns true
        /// else returns false
        /// </summary>
        /// <param name="player"></param>
        /// <param name="betAmount"></param>
        /// <returns></returns>
        public bool PlayersAllIn(Player player,int betAmount)
        {
            if (player.myChips.PlayerChipCount == betAmount)
            {
                Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Player_Check_Or_All_In_Text);
                Console.WriteLine("Player is all in");
                player.playerAllInState = true;
                return true;
            }
            return false;
            
        }
        /// <summary>
        /// Checks if the input is an int 
        /// returns the int value once an int is registered
        /// </summary>
        /// <returns></returns>
        public int IntInput()
        {
            bool foundInt = false;
            int intFound = 0;

            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;
            string readlineString = "";

            while (!foundInt)
            {
                readlineString = StringInput();
                foundInt = int.TryParse(readlineString, out intFound);
            }

            Program.myDisplay.ClearText(cursorLeft, cursorTop, readlineString);

            return intFound;
        }
        /// <summary>
        /// Sets cursor position and returns a string which is cleared immediately
        /// </summary>
        /// <returns></returns>
        public string StringInput()
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            string text = Console.ReadLine();
            Program.myDisplay.ClearText(left, top, text);
            return text;
        }
        /// <summary>
        /// Checks to see if a player is confirming or rejecting a decision
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public bool CheckConfirmation(string response)
        {
            int validResult = -1;
            
            while (validResult == -1)
            {
                response.ToLower();
                if (response == "yes" || response == "y")
                    validResult = 1;
                else if (response == "no" || response == "n")
                    validResult = 0;
                else
                {
                    response = Console.ReadLine();
                }
            }

            return validResult == 1;
        }
    }
}
