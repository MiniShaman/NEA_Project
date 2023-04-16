using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    /// <summary>
    /// Holds all info on the display setup for the game
    /// </summary>
    public class DisplayManager
    {

        public DisplayManager()
        {
        }
        /// <summary>
        /// Enum of every position in the display
        /// </summary>
        public enum DisplayPosition
        {
            Player_Card1,
            Player_Card2,
            AI_Card1,
            AI_Card2,
            Flop1,
            Flop2,
            Flop3,
            Turn,
            River,
            Chips_Player,
            Chips_Table_Total,
            Chips_AI_Player,
            Player_Round_Bet_Total,
            AI_Player_Round_Bet_Total,
            Bet_Text_Display,
            Player_Best_Hand_Combo,
            Player_Best_Hand_Name,
            AI_Best_Hand_Combo,
            AI_Best_Hand_Name,
            Replay_Game_Text,
            Round_Point_Text,
            End_Game_Text,
            Player_Check_Or_All_In_Text,
            Bet_Or_Fold_Text,
            Error_Text
        }
        /// <summary>
        /// Sets ups the initial display
        /// </summary>
        public void InitialiseDisplay()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        /// <summary>
        /// Set up game and displays both players chips and bets in the round so far
        /// also displays the table chips
        /// </summary>
        /// <param name="playerChips"></param>
        /// <param name="aiChips"></param>
        public void SetupDisplay(int playerChips, int aiChips)
        {
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("**                      JOSH'S POKER!                          **");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("*****************************************************************");

            SetCursorPosition(DisplayPosition.Chips_Player);
            Console.WriteLine("Chips: " + playerChips);

            SetCursorPosition(DisplayPosition.Chips_AI_Player);
            Console.WriteLine("Chips: " + aiChips);

            SetCursorPosition(DisplayPosition.Player_Round_Bet_Total);
            Console.WriteLine("Total Bet in Round: 0");

            SetCursorPosition(DisplayPosition.AI_Player_Round_Bet_Total);
            Console.WriteLine("Total Bet in Round: 0");

            SetCursorPosition(DisplayPosition.Chips_Table_Total);
            Console.WriteLine("Table Total: 0");

            SetCursorPosition(DisplayPosition.Round_Point_Text);
            Console.WriteLine("Round Place: " + Program.roundPosition);
        }
        /// <summary>
        /// Updates the display to match the changing chips and round
        /// </summary>
        /// <param name="player"></param>
        /// <param name="aiPlayer"></param>
        public void UpdateDisplay(Player player, Player aiPlayer)
        {
            UpdateDisplayLine("Chips: " + player.myChips.PlayerChipCount, DisplayPosition.Chips_Player);

            UpdateDisplayLine("Chips: " + aiPlayer.myChips.PlayerChipCount, DisplayPosition.Chips_AI_Player);

            UpdateDisplayLine("Total Bet in Round: " + player.myChips.roundBetTotal, DisplayPosition.Player_Round_Bet_Total);

            UpdateDisplayLine("Total Bet in Round: " + aiPlayer.myChips.roundBetTotal, DisplayPosition.AI_Player_Round_Bet_Total);

            UpdateDisplayLine("Table Total: " + Program.TableTotal, DisplayPosition.Chips_Table_Total);

            UpdateDisplayLine("Round Place: " + Program.roundPosition, DisplayPosition.Round_Point_Text,5);

        }
        /// <summary>
        /// Rewrites in new text over an existing line of text when wanting to update info
        /// </summary>
        /// <param name="text"></param>
        /// <param name="displayPosition"></param>
        /// <param name="errorAmount"></param>
        public void UpdateDisplayLine(string text, DisplayPosition displayPosition, int errorAmount = 2)
        {
            SetCursorPosition(displayPosition);
            ClearText(text.Length + errorAmount);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Holds all cursor positions for the enums of display position 
        /// </summary>
        /// <param name="Position"></param>
        public void SetCursorPosition(DisplayPosition Position) // Holds all cursor positions for each item/text being displayed
        {
            switch(Position)
            {
                case DisplayPosition.Player_Card1:
                    Console.SetCursorPosition(18, 18);
                    break;
                case DisplayPosition.Player_Card2:
                    Console.SetCursorPosition(24, 18);
                    break;
                case DisplayPosition.AI_Card1:
                    Console.SetCursorPosition(37, 14);
                    break;
                case DisplayPosition.AI_Card2:
                    Console.SetCursorPosition(43, 14);
                    break;
                case DisplayPosition.Flop1:
                    Console.SetCursorPosition(11, 10);
                    break;
                case DisplayPosition.Flop2:
                    Console.SetCursorPosition(16, 10);
                    break;
                case DisplayPosition.Flop3:
                    Console.SetCursorPosition(21, 10);
                    break;
                case DisplayPosition.Turn:
                    Console.SetCursorPosition(26, 10);
                    break;
                case DisplayPosition.River:
                    Console.SetCursorPosition(31, 10);
                    break;
                case DisplayPosition.Chips_Player:
                    Console.SetCursorPosition(18, 20);
                    break;
                case DisplayPosition.Chips_Table_Total:
                    Console.SetCursorPosition(15, 7);
                    break;
                case DisplayPosition.Chips_AI_Player:
                    Console.SetCursorPosition(37, 16);
                    break;
                case DisplayPosition.AI_Player_Round_Bet_Total:
                    Console.SetCursorPosition(34, 18);
                    break;
                case DisplayPosition.Player_Round_Bet_Total:
                    Console.SetCursorPosition(14, 22);
                    break;
                case DisplayPosition.Bet_Text_Display:
                    Console.SetCursorPosition(0, 26);
                    break;
                case DisplayPosition.Player_Best_Hand_Combo:
                    Console.SetCursorPosition(0, 31);
                    break;
                case DisplayPosition.Player_Best_Hand_Name:
                    Console.SetCursorPosition(3, 33);
                    break;
                case DisplayPosition.AI_Best_Hand_Combo:
                    Console.SetCursorPosition(34, 20);
                    break;
                case DisplayPosition.AI_Best_Hand_Name:
                    Console.SetCursorPosition(37, 22);
                    break;
                case DisplayPosition.Replay_Game_Text:
                    Console.SetCursorPosition(0, 35);
                    break;
                case DisplayPosition.End_Game_Text:
                    Console.SetCursorPosition(0, 32);
                    break;
                case DisplayPosition.Round_Point_Text:
                    Console.SetCursorPosition(55, 7);
                    break;
                case DisplayPosition.Player_Check_Or_All_In_Text:
                    Console.SetCursorPosition(0,32);
                    break;
                case DisplayPosition.Bet_Or_Fold_Text:
                    Console.SetCursorPosition(0, 29);
                    break;
                case DisplayPosition.Error_Text:
                    Console.SetCursorPosition(30, 5);
                    break;
                default: 

                    break;
            }
        }
        /// <summary>
        /// Clears the text from a specific cursor position and resets the cursor to that position post clearing
        /// for lengths of text
        /// </summary>
        /// <param name="cursorLeft"></param>
        /// <param name="cursorTop"></param>
        /// <param name="clearLength"></param>
        public void ClearText(int cursorLeft, int cursorTop, int clearLength)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            ClearText(clearLength);
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }
        /// <summary>
        /// Clears the text from a specific cursor position and resets the cursor to that position post clearing
        /// for text
        /// </summary>
        /// <param name="cursorLeft"></param>
        /// <param name="cursorTop"></param>
        /// <param name="clearLength"></param>
        public void ClearText(int cursorLeft, int cursorTop, string clearText)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            ClearText(clearText);
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }
        /// <summary>
        /// The clear function which sets the cursor position and writes over any text with grey X's as they are hidden on the display
        /// for length
        /// </summary>
        /// <param name="clearLength"></param>
        public void ClearText(int clearLength) // Clear any Text need to have set cursor pos before
        {
            int left = Console.CursorLeft;
            int top  = Console.CursorTop;

            Console.ForegroundColor = ConsoleColor.Gray;
            for(int i=0; i<clearLength; ++i)
            {
                Console.Write("X");
            }
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(left, top);
        }
        /// <summary>
        /// The clear function which sets the cursor position and writes over any text with grey X's as they are hidden on the display
        /// for text
        /// </summary>
        /// <param name="clearLength"></param>
        public void ClearText(string clearText) // Clear any Text need to have set cursor pos before
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(clearText);
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(left, top);
        }
        /// <summary>
        /// Displays all cards in a cards list from up to a the round position e.g 2,5,6,7
        /// </summary>
        /// <param name="cardList"></param>
        /// <param name="roundPosCounter"></param>
        public void DisplayAllCards( Card [] cardList, int roundPosCounter)
        {
            for(int i =0;i< roundPosCounter;++i )
            {
                if(cardList[i] != null)
                {
                    cardList[i].DisplayCard();
                }
            }
        }
    }
}
