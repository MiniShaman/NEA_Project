using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class Menu
    {
        Deck holdDeck = new Deck();
        char menuReturn;
        public Menu()
        { }
        public void StartMenu() // Displays a menu of your possible starting options
        {
            Console.WriteLine("Select one of the Options:" +
                "\n1.Start" +
                "\n2.Options" +
                "\n3.Rules" +
                "\n");
            int optionPick = int.Parse(Console.ReadLine());
            MenuChoice(optionPick);
        }
        /* produces the result based on the value of the int optionPick such as starting the game, ...
         Also gives the option to return back to menu whenever */
        public void MenuChoice(int choiceVal) 
        {
            char menuReturn;
            if (choiceVal == 1)
            {
                Console.WriteLine("\nThe game has started");
                Console.WriteLine("");
                holdDeck.Shuffle();
                holdDeck.DisplayAll();
                    
            }
            else if (choiceVal == 2)
            {
                Console.WriteLine("Options List:" +
                    "\nIf you want to go back to menu press 'M' ");
            }
            else if (choiceVal == 3)
            {
                Console.WriteLine("Rules:" +
                    "\n1. ...");

            }
            else
            {
                Console.WriteLine("Enter another value as this one won't work");
            }

            menuReturn = char.ToUpper(char.Parse(Console.ReadLine()));

            if(menuReturn == 'M')
            {
                StartMenu();
            }
        }
    }
}
