using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class DisplayManager
    {

        public DisplayManager()
        {
        }
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
            BetTextDisplay,
            BestHandCombo,
            BestHandName
        }

        public void InitialiseDisplay()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public void SetupDisplay(int startChips)
        {
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("**                      JOSH'S POKER!                          **");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("*****************************************************************");

            SetCursorPosition(DisplayManager.DisplayPosition.Chips_Player);
            Console.WriteLine("Chips: " + startChips);

            SetCursorPosition(DisplayManager.DisplayPosition.Chips_AI_Player);
            Console.WriteLine("Chips: " + startChips);

            SetCursorPosition(DisplayManager.DisplayPosition.Player_Round_Bet_Total);
            Console.WriteLine("Total Bet in Round: 0");

            SetCursorPosition(DisplayManager.DisplayPosition.AI_Player_Round_Bet_Total);
            Console.WriteLine("Total Bet in Round: ");

            SetCursorPosition(DisplayManager.DisplayPosition.Chips_Table_Total);
            Console.WriteLine("Table Total: 0");
        }

        public void UpdateDisplay(Player player, Player aiPlayer)
        {
            SetCursorPosition(DisplayPosition.Chips_Player);
            ClearText("Chips: " + player.myChips.PlayerChipCount);
            Console.WriteLine("Chips: " + player.myChips.PlayerChipCount);

            SetCursorPosition(DisplayPosition.Chips_AI_Player);
            ClearText("Chips: " + aiPlayer.myChips.PlayerChipCount);
            Console.WriteLine("Chips: " + aiPlayer.myChips.PlayerChipCount);

            SetCursorPosition(DisplayPosition.Player_Round_Bet_Total);
            ClearText("Total Bet in Round: " + player.myChips.roundBetTotal);
            Console.WriteLine("Total Bet in Round: " + player.myChips.roundBetTotal);

            SetCursorPosition(DisplayPosition.AI_Player_Round_Bet_Total);
            ClearText("Total Bet in Round: " + aiPlayer.myChips.roundBetTotal);
            Console.WriteLine("Total Bet in Round: " + aiPlayer.myChips.roundBetTotal);

            SetCursorPosition(DisplayPosition.Chips_Table_Total);
            ClearText("Table Total: " + Program.TableTotal);
            Console.WriteLine("Table Total: " + Program.TableTotal);
        }


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
                case DisplayPosition.BetTextDisplay:
                    Console.SetCursorPosition(0, 26);
                    break;
                case DisplayPosition.BestHandCombo:
                    Console.SetCursorPosition(0, 31);
                    break;
                case DisplayPosition.BestHandName:
                    Console.SetCursorPosition(3, 33);
                    break;
                default: 

                    break;
            }
        }
        /*public void ClearLine(int xCursorPos, int yCursorPos, int lineClearLength) // Clear any Text in a specific position
        {
            Console.SetCursorPosition(xCursorPos, yCursorPos);
            Console.ForegroundColor = ConsoleColor.Gray;
            string[] clearText = new string[lineClearLength];
            foreach(string arraySlot in clearText)
            {
                Console.Write("i");
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }*/

        public void ClearText(int cursorLeft, int cursorTop, int clearLength)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            ClearText(clearLength);
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        public void ClearText(int cursorLeft, int cursorTop, string clearText)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            ClearText(clearText);
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

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
        public void ClearText(string clearText) // Clear any Text need to have set cursor pos before
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(clearText);
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(left, top);
        }

        public void GetStringLength()
        {
            Console.Read();
        }
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
