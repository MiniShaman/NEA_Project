using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class Chips
    {
        public int PlayerChipCount = 100;
        public int TableTotal = 0;
        public Chips()
        {

        }    
        public void BetAmount()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("How much would you like to bet?");
            int betPlaced = int.Parse(Console.ReadLine());
            
            Console.SetCursorPosition(10, 15);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Chips: " + PlayerChipCount);

            PlayerChipCount -= betPlaced;
            TableTotal += betPlaced;

            Console.SetCursorPosition(10, 15);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Chips: " + PlayerChipCount);
            Console.SetCursorPosition(15,7);
            Console.WriteLine("Table Total: " + TableTotal);

        }
    }
}
