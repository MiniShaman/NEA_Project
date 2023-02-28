using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class HandTest
    {
        Card[] straight_test_0 = new Card[fullHandSize];
        Card[] straight_test_1 = new Card[fullHandSize];
        Card[] straight_test_2 = new Card[fullHandSize];

        Card[] flush_test_0 = new Card[fullHandSize];
        Card[] flush_test_1 = new Card[fullHandSize];

        Card[] poker_test_0 = new Card[fullHandSize];

        Card[] full_house_test_0 = new Card[fullHandSize];
        Card[] full_house_test_1 = new Card[fullHandSize];


        Card[] pair_test_0 = new Card[fullHandSize];
        public static int fullHandSize = 7;
        public HandTest()
        {
            InitialiseHand(straight_test_0);
            InitialiseHand(straight_test_1);
            InitialiseHand(straight_test_2);

            InitialiseHand(flush_test_0);
            InitialiseHand(flush_test_1);

            InitialiseHand(poker_test_0);

            InitialiseHand(full_house_test_0);
            InitialiseHand(full_house_test_1);

            InitialiseHand(pair_test_0);

            straight_test_0[0].SetCard(Card.CardSuit.Hearts, 7);
            straight_test_0[1].SetCard(Card.CardSuit.Hearts, 6);
            straight_test_0[2].SetCard(Card.CardSuit.Hearts, 6);
            straight_test_0[3].SetCard(Card.CardSuit.Hearts, 5);
            straight_test_0[4].SetCard(Card.CardSuit.Hearts, 4);
            straight_test_0[5].SetCard(Card.CardSuit.Hearts, 3);
            straight_test_0[6].SetCard(Card.CardSuit.Hearts, 2);

            straight_test_1[0].SetCard(Card.CardSuit.Hearts, 7);
            straight_test_1[1].SetCard(Card.CardSuit.Hearts, 6);
            straight_test_1[2].SetCard(Card.CardSuit.Hearts, 6);
            straight_test_1[3].SetCard(Card.CardSuit.Hearts, 5);
            straight_test_1[4].SetCard(Card.CardSuit.Hearts, 5);
            straight_test_1[5].SetCard(Card.CardSuit.Hearts, 4);
            straight_test_1[6].SetCard(Card.CardSuit.Hearts, 4);

            straight_test_2[0].SetCard(Card.CardSuit.Hearts, 13);
            straight_test_2[1].SetCard(Card.CardSuit.Hearts, 12);
            straight_test_2[2].SetCard(Card.CardSuit.Hearts, 11);
            straight_test_2[3].SetCard(Card.CardSuit.Hearts, 10);
            straight_test_2[4].SetCard(Card.CardSuit.Hearts, 4);
            straight_test_2[5].SetCard(Card.CardSuit.Hearts, 3);
            straight_test_2[6].SetCard(Card.CardSuit.Hearts, 1);

            flush_test_0[0].SetCard(Card.CardSuit.Clubs, 13);
            flush_test_0[1].SetCard(Card.CardSuit.Clubs, 12);
            flush_test_0[2].SetCard(Card.CardSuit.Hearts, 11);
            flush_test_0[3].SetCard(Card.CardSuit.Clubs, 10);
            flush_test_0[4].SetCard(Card.CardSuit.Clubs, 4);
            flush_test_0[5].SetCard(Card.CardSuit.Clubs, 3);
            flush_test_0[6].SetCard(Card.CardSuit.Hearts, 1);

            flush_test_1[0].SetCard(Card.CardSuit.Diamonds, 13);
            flush_test_1[1].SetCard(Card.CardSuit.Hearts, 12);
            flush_test_1[2].SetCard(Card.CardSuit.Diamonds, 11);
            flush_test_1[3].SetCard(Card.CardSuit.Diamonds, 10);
            flush_test_1[4].SetCard(Card.CardSuit.Clubs, 4);
            flush_test_1[5].SetCard(Card.CardSuit.Hearts, 3);
            flush_test_1[6].SetCard(Card.CardSuit.Diamonds, 1);

            poker_test_0[0].SetCard(Card.CardSuit.Clubs, 11);
            poker_test_0[1].SetCard(Card.CardSuit.Clubs, 12);
            poker_test_0[2].SetCard(Card.CardSuit.Hearts, 11);
            poker_test_0[3].SetCard(Card.CardSuit.Clubs, 10);
            poker_test_0[4].SetCard(Card.CardSuit.Diamonds, 11);
            poker_test_0[5].SetCard(Card.CardSuit.Spades, 11);
            poker_test_0[6].SetCard(Card.CardSuit.Hearts, 1);

            full_house_test_0[0].SetCard(Card.CardSuit.Clubs, 13);
            full_house_test_0[1].SetCard(Card.CardSuit.Clubs, 12);
            full_house_test_0[2].SetCard(Card.CardSuit.Hearts, 13);
            full_house_test_0[3].SetCard(Card.CardSuit.Clubs, 10);
            full_house_test_0[4].SetCard(Card.CardSuit.Diamonds, 12);
            full_house_test_0[5].SetCard(Card.CardSuit.Spades, 13);
            full_house_test_0[6].SetCard(Card.CardSuit.Hearts, 12);

            full_house_test_1[0].SetCard(Card.CardSuit.Clubs, 13);
            full_house_test_1[1].SetCard(Card.CardSuit.Clubs, 12);
            full_house_test_1[2].SetCard(Card.CardSuit.Hearts, 13);
            full_house_test_1[3].SetCard(Card.CardSuit.Clubs, 10);
            full_house_test_1[4].SetCard(Card.CardSuit.Diamonds, 1);
            full_house_test_1[5].SetCard(Card.CardSuit.Spades, 10);
            full_house_test_1[6].SetCard(Card.CardSuit.Hearts, 12);

            pair_test_0[0].SetCard(Card.CardSuit.Clubs, 11);
            pair_test_0[1].SetCard(Card.CardSuit.Clubs, 9);
            pair_test_0[2].SetCard(Card.CardSuit.Hearts, 11);
            pair_test_0[3].SetCard(Card.CardSuit.Clubs, 2);
            pair_test_0[4].SetCard(Card.CardSuit.Diamonds, 4);
            pair_test_0[5].SetCard(Card.CardSuit.Spades, 7);
            pair_test_0[6].SetCard(Card.CardSuit.Hearts, 1);
        }

        void InitialiseHand(Card[] hand)
        {
            for (int i = 0; i < fullHandSize; ++i)
            {
                hand[i] = new Card();
            }
        }
        /*public Card[] PrintStraightHand()
        {
            bool repeatCase;
            Card[] handTypeStraight = new Card[fullHandSize];
            Console.WriteLine("Pick a Straight Hand:" +
                    "\n1.Ace, King option" +
                    "\n2. Pair in Straight option" +
                    "\n3.Default Staight");
            do
            {
                repeatCase = true;                
                int pickHand = Program.gameInputs.IntInput();
                Program.myDisplay.SetCursorPosition(DisplayManager.DisplayPosition.BestHandCombo);
                switch (pickHand)
                {
                    case 1:
                        Card oneCard = new Card();
                        oneCard.Value = 13;
                        for(int i = 0; i<fullHandSize;++i)
                        {

                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        repeatCase = false;
                        break;
                }
            }
            while (repeatCase == false);
        }*/

        public void DoStraightTests()
        {
            if(Program.playerHand.IsHandAStraight(straight_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Straight - basic detection failed.");
            }

            if (Program.playerHand.IsHandAStraight(straight_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Straight - false positive (duplication).");
            }

            if(Program.playerHand.IsHandAStraight(straight_test_2, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Straight - High Ace not found.");
            }
        }

        public void DoFlushTests()
        {
            if (Program.playerHand.IsHandAFlush(flush_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Flush - basic detection failed.");
            }

            if (Program.playerHand.IsHandAFlush(flush_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Flush - false positive.");
            }
        }
        public void DoPokerTests()
        { 
            Program.playerHand.SortCardValues(poker_test_0, fullHandSize);
            if (Program.playerHand.IsHandAPoker(poker_test_0,fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Poker - basic detection failed");
            }
        }
        public void DoFullHouseTests()
        {
            Program.playerHand.SortCardValues(full_house_test_0, fullHandSize);
            Program.playerHand.SortCardValues(full_house_test_1, fullHandSize);
            if (Program.playerHand.IsHandAFullHouse(full_house_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Full House - basic detection failed");
            }
            if (Program.playerHand.IsHandAFullHouse(full_house_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Full House - false positive");
            }
        }
        public void DoPairTest()
        {
            Program.playerHand.IsHandAPair(pair_test_0, fullHandSize);
            if (Program.playerHand.IsHandAPair(pair_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Pair - basic detection failed");
            }
        }
        public void DoTests()
        {
            DoStraightTests();
            DoFlushTests();
            DoPokerTests();
            DoFullHouseTests();
        }
    }
}
