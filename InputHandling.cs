﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class InputHandling
    {
        public InputHandling()
        {

        }
        public int BetValueCheck(int betAmount, int PlayerChips)
        {
            while (PlayerChips < betAmount || betAmount < Chips.MinBetAmount)
            {
                Program.myChips.BetAmount();
            }
            return betAmount;
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
                readlineString = Console.ReadLine();
                foundInt = int.TryParse(readlineString, out intFound);

                Program.myDisplay.ClearText(cursorLeft, cursorTop, readlineString);
            }

            Program.myDisplay.ClearText(cursorLeft, cursorTop, readlineString);

            return intFound;

            /*string intReturn = Console.ReadLine();
            bool checkInput = int.TryParse(intReturn, out int returnVal);
            while (checkInput == false)
            {
                IntInput();                
            }
            return (returnVal);*/
        }
    }
}