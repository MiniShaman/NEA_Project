using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class InputHandling
    {
        public InputHandling()
        {

        }
        public int GetBetAmountOrFold(out bool hasFolded)
        {
            bool inputValid = false;
            int betAmount = 0;
            hasFolded = false;
                while (inputValid == false)
                {
                    string gameDecision = StringInput();
                    gameDecision.ToLower();
                    if (gameDecision == "fold" || gameDecision == "f")
                    {
                        hasFolded = true;
                        inputValid = true;
                    }
                    else if (int.TryParse(gameDecision, out betAmount))
                    {
                        inputValid = true;
                    }
                }
            return betAmount;
        }
        public int BetValueCheck(int PlayerChips, Player player, Player AI, bool isAnAI)
        {
            int playerBet = player.myChips.roundBetTotal;
            int betAmount = 0;
            bool hasFolded;
            do
            {
                betAmount = GetBetAmountOrFold(out hasFolded);
                if (hasFolded)
                {
                    player.playerFolded = true;
                    break;
                }
                else
                {
                    //betAmount = Program.gameInputs.IntInput();
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
            }
            while ( /* keep doing this if the bet is not valid*/
            IsBetInvalid(player, AI, PlayerChips, betAmount, playerBet));

            return betAmount;
        }
        public bool IsBetInvalid(Player player, Player AI, int PlayerChips, int betAmount, int totalBetAmount)
        {
            return betAmount > PlayerChips ||
            betAmount < Chips.MinBetAmount ||
            !Program.communityTable.TableBetsCheck(player, AI, totalBetAmount, AI.myChips.roundBetTotal)
            || AllInBetMatch(player,AI,betAmount);
        }
        public bool AllInBetMatch(Player player, Player AI,int betAmount)
        {
            if(AI.playerAllIn)
            {
                if(betAmount != AI.myChips.roundBetTotal || player.playerAllIn)
                {
                    return true;
                }
            }
            return false;
        }
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
        public bool PlayersAllIn(Player player,int betAmount)
        {
            if (player.myChips.PlayerChipCount == betAmount)
            {
                Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.Player_Check_Or_All_In_Text);
                Console.WriteLine("Player is all in");
                player.playerAllIn = true;
                return true;
            }
            return false;
            
        }
          public bool DoesPlayerBet(Player player,string gameChoice)
          {
              int returnChoice = -1;
              do
              {
                gameChoice.ToLower();
                if (gameChoice == "fold" || gameChoice == "f")
                {
                    player.playerFolded = true;
                    return false;
                }
                else if (gameChoice == "bet" || gameChoice == "b")
                {
                    return true;
                }
                else
                {
                    gameChoice = StringInput();
                }
              }   
              while (returnChoice == -1);
            return true;

          }

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
                //Program.myDisplay.ClearText(cursorLeft, cursorTop, readlineString);
            }

            Program.myDisplay.ClearText(cursorLeft, cursorTop, readlineString);

            return intFound;
        }
        public string StringInput()
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            string text = Console.ReadLine();
            Program.myDisplay.ClearText(left, top, text);
            return text;
        }
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
