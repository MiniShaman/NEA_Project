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
        Card[] full_house_test_2 = new Card[fullHandSize];

        Card[] straight_flush_test_0 = new Card[fullHandSize];
        Card[] straight_flush_test_1 = new Card[fullHandSize];


        Card[] pair_test_0 = new Card[fullHandSize];
        Card[] pair_test_1 = new Card[fullHandSize];

        Card[] two_pair_test_0 = new Card[fullHandSize];
        Card[] two_pair_test_1 = new Card[fullHandSize];

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
            InitialiseHand(full_house_test_2);

            InitialiseHand(pair_test_0);
            InitialiseHand(pair_test_1);

            InitialiseHand(two_pair_test_0);
            InitialiseHand(two_pair_test_1);

            InitialiseHand(straight_flush_test_0);
            InitialiseHand(straight_flush_test_1);

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

            straight_test_2[0].SetCard(Card.CardSuit.Hearts, Card.Ace);
            straight_test_2[1].SetCard(Card.CardSuit.Hearts, Card.King);
            straight_test_2[2].SetCard(Card.CardSuit.Hearts, 5);
            straight_test_2[3].SetCard(Card.CardSuit.Hearts, 4);
            straight_test_2[4].SetCard(Card.CardSuit.Hearts, 3);
            straight_test_2[5].SetCard(Card.CardSuit.Hearts, 2);
            straight_test_2[6].SetCard(Card.CardSuit.Hearts, 2);

            flush_test_0[6].SetCard(Card.CardSuit.Hearts, Card.Ace  );
            flush_test_0[0].SetCard(Card.CardSuit.Clubs,  Card.King );
            flush_test_0[1].SetCard(Card.CardSuit.Clubs,  Card.Queen);
            flush_test_0[2].SetCard(Card.CardSuit.Hearts, Card.Jack );
            flush_test_0[3].SetCard(Card.CardSuit.Clubs, 10); 
            flush_test_0[4].SetCard(Card.CardSuit.Clubs, 4);
            flush_test_0[5].SetCard(Card.CardSuit.Clubs, 3);

            flush_test_1[0].SetCard(Card.CardSuit.Diamonds, Card.Ace  );
            flush_test_1[1].SetCard(Card.CardSuit.Diamonds, Card.King );
            flush_test_1[2].SetCard(Card.CardSuit.Hearts,   Card.Queen);
            flush_test_1[3].SetCard(Card.CardSuit.Diamonds, Card.Jack);
            flush_test_1[4].SetCard(Card.CardSuit.Diamonds, 10);
            flush_test_1[5].SetCard(Card.CardSuit.Clubs, 4);
            flush_test_1[6].SetCard(Card.CardSuit.Hearts, 3);

            poker_test_0[0].SetCard(Card.CardSuit.Clubs, Card.Jack);
            poker_test_0[1].SetCard(Card.CardSuit.Clubs, Card.Queen);
            poker_test_0[2].SetCard(Card.CardSuit.Hearts, Card.Jack);
            poker_test_0[3].SetCard(Card.CardSuit.Clubs, 10);
            poker_test_0[4].SetCard(Card.CardSuit.Diamonds, Card.Jack);
            poker_test_0[5].SetCard(Card.CardSuit.Spades, Card.Jack);
            poker_test_0[6].SetCard(Card.CardSuit.Hearts, Card.Ace);

            full_house_test_0[0].SetCard(Card.CardSuit.Clubs, Card.King);
            full_house_test_0[1].SetCard(Card.CardSuit.Clubs, Card.Queen);
            full_house_test_0[2].SetCard(Card.CardSuit.Hearts, Card.King);
            full_house_test_0[3].SetCard(Card.CardSuit.Clubs, 10);
            full_house_test_0[4].SetCard(Card.CardSuit.Diamonds, Card.Queen);
            full_house_test_0[5].SetCard(Card.CardSuit.Spades, Card.King);
            full_house_test_0[6].SetCard(Card.CardSuit.Hearts, Card.Queen);

            full_house_test_1[0].SetCard(Card.CardSuit.Clubs, Card.King);
            full_house_test_1[1].SetCard(Card.CardSuit.Clubs, Card.Queen);
            full_house_test_1[2].SetCard(Card.CardSuit.Hearts, Card.King);
            full_house_test_1[3].SetCard(Card.CardSuit.Clubs, 10);
            full_house_test_1[4].SetCard(Card.CardSuit.Diamonds, Card.Ace);
            full_house_test_1[5].SetCard(Card.CardSuit.Spades, 10);
            full_house_test_1[6].SetCard(Card.CardSuit.Hearts, Card.Queen);

            full_house_test_2[0].SetCard(Card.CardSuit.Clubs, Card.King);
            full_house_test_2[1].SetCard(Card.CardSuit.Clubs, Card.Queen);
            full_house_test_2[2].SetCard(Card.CardSuit.Hearts, Card.King);
            full_house_test_2[3].SetCard(Card.CardSuit.Clubs, 10);
            full_house_test_2[4].SetCard(Card.CardSuit.Diamonds, Card.Ace);
            full_house_test_2[5].SetCard(Card.CardSuit.Spades, 10);
            full_house_test_2[6].SetCard(Card.CardSuit.Hearts, Card.Queen);

            pair_test_0[0].SetCard(Card.CardSuit.Clubs, Card.Jack);
            pair_test_0[1].SetCard(Card.CardSuit.Clubs, 9);
            pair_test_0[2].SetCard(Card.CardSuit.Hearts, Card.Jack);
            pair_test_0[3].SetCard(Card.CardSuit.Clubs, 2);
            pair_test_0[4].SetCard(Card.CardSuit.Diamonds, 4);
            pair_test_0[5].SetCard(Card.CardSuit.Spades, 7);
            pair_test_0[6].SetCard(Card.CardSuit.Hearts, Card.Ace);

            pair_test_1[0].SetCard(Card.CardSuit.Clubs, Card.Ace);
            pair_test_1[1].SetCard(Card.CardSuit.Clubs, Card.King);
            pair_test_1[2].SetCard(Card.CardSuit.Hearts, Card.Queen);
            pair_test_1[3].SetCard(Card.CardSuit.Clubs, Card.Jack);
            pair_test_1[4].SetCard(Card.CardSuit.Diamonds, 10);
            pair_test_1[5].SetCard(Card.CardSuit.Spades, 9);
            pair_test_1[6].SetCard(Card.CardSuit.Hearts, 8);

            two_pair_test_0[0].SetCard(Card.CardSuit.Clubs, Card.Ace);
            two_pair_test_0[1].SetCard(Card.CardSuit.Hearts, Card.Ace);
            two_pair_test_0[2].SetCard(Card.CardSuit.Hearts, 10);
            two_pair_test_0[3].SetCard(Card.CardSuit.Clubs, 10);
            two_pair_test_0[4].SetCard(Card.CardSuit.Diamonds, 8);
            two_pair_test_0[5].SetCard(Card.CardSuit.Spades, 7);
            two_pair_test_0[6].SetCard(Card.CardSuit.Hearts, 6);

            two_pair_test_1[0].SetCard(Card.CardSuit.Clubs, Card.Jack);
            two_pair_test_1[1].SetCard(Card.CardSuit.Clubs, Card.Queen);
            two_pair_test_1[2].SetCard(Card.CardSuit.Hearts, Card.Jack);
            two_pair_test_1[3].SetCard(Card.CardSuit.Clubs, 10);
            two_pair_test_1[4].SetCard(Card.CardSuit.Diamonds, Card.Jack);
            two_pair_test_1[5].SetCard(Card.CardSuit.Spades, Card.Jack);
            two_pair_test_1[6].SetCard(Card.CardSuit.Hearts, Card.Ace);

            straight_flush_test_0[0].SetCard(Card.CardSuit.Clubs, Card.Jack);
            straight_flush_test_0[1].SetCard(Card.CardSuit.Clubs, 10);
            straight_flush_test_0[2].SetCard(Card.CardSuit.Clubs, 9);
            straight_flush_test_0[3].SetCard(Card.CardSuit.Hearts, 9);
            straight_flush_test_0[4].SetCard(Card.CardSuit.Clubs, 8);
            straight_flush_test_0[5].SetCard(Card.CardSuit.Diamonds, 8);
            straight_flush_test_0[6].SetCard(Card.CardSuit.Clubs, 7);

            straight_flush_test_1[0].SetCard(Card.CardSuit.Clubs, Card.King);
            straight_flush_test_1[1].SetCard(Card.CardSuit.Clubs, Card.Queen);
            straight_flush_test_1[2].SetCard(Card.CardSuit.Clubs, Card.Jack);
            straight_flush_test_1[3].SetCard(Card.CardSuit.Diamonds, 10);
            straight_flush_test_1[4].SetCard(Card.CardSuit.Diamonds, 9);
            straight_flush_test_1[5].SetCard(Card.CardSuit.Clubs, 8);
            straight_flush_test_1[6].SetCard(Card.CardSuit.Clubs, 7);
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
            Program.playerHand.SortCardValues(straight_test_0, fullHandSize);
            Program.playerHand.SortCardValues(straight_test_1, fullHandSize);
            Program.playerHand.SortCardValues(straight_test_2, fullHandSize);
            if (Program.playerHand.IsHandAStraight(straight_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Straight - basic detection failed.");
            }

            if (Program.playerHand.IsHandAStraight(straight_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Straight - false positive (duplication).");
            }

            if(Program.playerHand.IsHandAStraight(straight_test_2, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Straight - Low Ace not found.");
            }
        }

        public void DoFlushTests()
        {
            Program.playerHand.SortCardValues(flush_test_0, fullHandSize);
            Program.playerHand.SortCardValues(flush_test_1, fullHandSize);

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
        public void DoPairTests()
        {
            Program.playerHand.SortCardValues(pair_test_0, fullHandSize);
            Program.playerHand.SortCardValues(pair_test_1, fullHandSize);
            if (Program.playerHand.IsHandAPair(pair_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Pair - basic detection failed");
            }
            if (Program.playerHand.IsHandAPair(pair_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Pair - false positive");
            }
        }
        public void DoTwoPairTests()
        {
            Program.playerHand.SortCardValues(two_pair_test_0, fullHandSize);
            Program.playerHand.SortCardValues(two_pair_test_1, fullHandSize);
            if (Program.playerHand.IsHandATwoPair(two_pair_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Two Pair - basic detection failed");
            }
            if (Program.playerHand.IsHandATwoPair(two_pair_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Two Pair - false positive");
            }
        }
        public void DoStraightFlushTests()
        {
            Program.playerHand.SortCardValues(straight_flush_test_0,fullHandSize);
            Program.playerHand.SortCardValues(straight_flush_test_1, fullHandSize);

            if (Program.playerHand.IsHandAStraightFlush(straight_flush_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Straight Flush - basic detection failed");
            }

            if (Program.playerHand.IsHandAStraightFlush(straight_flush_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Straight Flush - false positive");
            }
        }
        public void DoTests()
        {
            DoStraightTests();
            DoFlushTests();
            DoPokerTests();
            DoFullHouseTests();
            DoPairTests();
            DoStraightFlushTests();
            DoTwoPairTests();

            //Program.playerHand.GetBestHand(two_pair_test_0, 7);

        }
    }
}
