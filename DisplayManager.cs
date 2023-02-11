using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class DisplayManager
    {

        public DisplayManager()
        {
        }
        public enum DisplayPosition
        {
            Card1,
            Card2,
            Flop1,
            Flop2,
            Flop3,
            Turn,
            River,
            Chips_Player,
            Chips_Table_Total,
            Chips_Table_Player,
            BetTextDisplay
        }

        public void SetupDisplay()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        public void SetCursorPosition(DisplayPosition Position) // Holds all cursor positions for each item/text being displayed
        {
            switch(Position)
            {
                case DisplayPosition.Card1:
                    Console.SetCursorPosition(0, 15);
                    break;
                case DisplayPosition.Card2:
                    Console.SetCursorPosition(5, 15);
                    break;
                case DisplayPosition.Flop1:
                    Console.SetCursorPosition(0, 10);
                    break;
                case DisplayPosition.Flop2:
                    Console.SetCursorPosition(5, 10);
                    break;
                case DisplayPosition.Flop3:
                    Console.SetCursorPosition(10, 10);
                    break;
                case DisplayPosition.Turn:
                    Console.SetCursorPosition(15, 10);
                    break;
                case DisplayPosition.River:
                    Console.SetCursorPosition(20, 10);
                    break;
                case DisplayPosition.Chips_Player:
                    Console.SetCursorPosition(10, 15);
                    break;
                case DisplayPosition.Chips_Table_Total:
                    Console.SetCursorPosition(15, 7);
                    break;
                case DisplayPosition.Chips_Table_Player: 

                    break;
                case DisplayPosition.BetTextDisplay:
                    Console.SetCursorPosition(0, 20);
                    break;
                default: 

                    break;
            }
        }
        public void ClearLine(int xCursorPos, int yCursorPos, int lineClearLength) // Clear any Text in a specific position
        {
            Console.SetCursorPosition(xCursorPos, yCursorPos);
            Console.ForegroundColor = ConsoleColor.Gray;
            string[] clearText = new string[lineClearLength];
            foreach(string arraySlot in clearText)
            {
                Console.Write("i");
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void GetStringLength()
        {
            Console.Read();
        }
    }
}
