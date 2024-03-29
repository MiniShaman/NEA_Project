﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    /// <summary>
    /// Does Testing for Hand Types
    /// and checks that HandEvaluation works
    /// </summary>
    class HandTest
    {
        Card[] straight_test_0 = new Card[fullHandSize];
        Card[] straight_test_1 = new Card[fullHandSize];
        Card[] straight_test_2 = new Card[fullHandSize];

        Card[] flush_test_0 = new Card[fullHandSize];
        Card[] flush_test_1 = new Card[fullHandSize];

        Card[] poker_test_0 = new Card[fullHandSize];
        Card[] poker_test_1 = new Card[fullHandSize];

        Card[] full_house_test_0 = new Card[fullHandSize];
        Card[] full_house_test_1 = new Card[fullHandSize];
        Card[] full_house_test_2 = new Card[fullHandSize];

        Card[] straight_flush_test_0 = new Card[fullHandSize];
        Card[] straight_flush_test_1 = new Card[fullHandSize];


        Card[] pair_test_0 = new Card[fullHandSize];
        Card[] pair_test_1 = new Card[fullHandSize];

        Card[] two_pair_test_0 = new Card[fullHandSize];
        Card[] two_pair_test_1 = new Card[fullHandSize];

        Card[] three_of_a_kind_test_0 = new Card[fullHandSize];
        Card[] three_of_a_kind_test_1 = new Card[fullHandSize];


        public static int fullHandSize = 7;
        public HandTest()
        {
            Hand.InitialiseHand(straight_test_0);
            Hand.InitialiseHand(straight_test_1);
            Hand.InitialiseHand(straight_test_2);

            Hand.InitialiseHand(flush_test_0);
            Hand.InitialiseHand(flush_test_1);

            Hand.InitialiseHand(poker_test_0);
            Hand.InitialiseHand(poker_test_1);

            Hand.InitialiseHand(full_house_test_0);
            Hand.InitialiseHand(full_house_test_1);
            Hand.InitialiseHand(full_house_test_2);

            Hand.InitialiseHand(pair_test_0);
            Hand.InitialiseHand(pair_test_1);

            Hand.InitialiseHand(two_pair_test_0);
            Hand.InitialiseHand(two_pair_test_1);

            Hand.InitialiseHand(straight_flush_test_0);
            Hand.InitialiseHand(straight_flush_test_1);

            Hand.InitialiseHand(three_of_a_kind_test_0);
            Hand.InitialiseHand(three_of_a_kind_test_1);

            straight_test_0[0].SetCard(Card.CardSuit.Hearts, 7);
            straight_test_0[1].SetCard(Card.CardSuit.Hearts, 6);
            straight_test_0[2].SetCard(Card.CardSuit.Hearts, 6);
            straight_test_0[3].SetCard(Card.CardSuit.Hearts, 5);
            straight_test_0[4].SetCard(Card.CardSuit.Hearts, 4);
            straight_test_0[5].SetCard(Card.CardSuit.Hearts, 3);
            straight_test_0[6].SetCard(Card.CardSuit.Diamonds, 2);

            straight_test_1[0].SetCard(Card.CardSuit.Hearts, 7);
            straight_test_1[1].SetCard(Card.CardSuit.Hearts, 6);
            straight_test_1[2].SetCard(Card.CardSuit.Hearts, 6);
            straight_test_1[3].SetCard(Card.CardSuit.Hearts, 5);
            straight_test_1[4].SetCard(Card.CardSuit.Hearts, 5);
            straight_test_1[5].SetCard(Card.CardSuit.Clubs, 4);
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

            poker_test_1[0].SetCard(Card.CardSuit.Clubs, 2);
            poker_test_1[1].SetCard(Card.CardSuit.Clubs, Card.Queen);
            poker_test_1[2].SetCard(Card.CardSuit.Hearts,10);
            poker_test_1[3].SetCard(Card.CardSuit.Clubs, 10);
            poker_test_1[4].SetCard(Card.CardSuit.Diamonds,10);
            poker_test_1[5].SetCard(Card.CardSuit.Spades, Card.Jack);
            poker_test_1[6].SetCard(Card.CardSuit.Hearts, Card.Ace);

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
        /// <summary>
        ///  A parameter of the player 
        ///  and tests a variety of straight/close to straight hands
        ///  printing a message specific to the error type if the desired result is not returned
        /// </summary>
        public void DoStraightTests(Player player)
        {
            player.myBestHand.SortCardValues(straight_test_0, fullHandSize);
            player.myBestHand.SortCardValues(straight_test_1, fullHandSize);
            player.myBestHand.SortCardValues(straight_test_2, fullHandSize);
            if (player.myBestHand.IsHandAStraight(straight_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Straight - basic detection failed.");
            }
            else
            {
                //Console.WriteLine("Success - basic straight found, functions works correctly");
                //for (int i = 0; i < fullHandSize; ++i)
                //{
                //    Console.Write(straight_test_0[i].GetDisplayString());
                //    Console.Write("  ");
                //}
            }
            if (player.myBestHand.IsHandAStraight(straight_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Straight - false positive (duplication).");
            }
            else
            {
                //Console.WriteLine("Success - false positive wasn't detected (duplication)");
                //for (int i = 0; i < fullHandSize; ++i)
                //{
                //    Console.Write(straight_test_1[i].GetDisplayString());
                //    Console.Write("  ");
                //}
            }
            if(player.myBestHand.IsHandAStraight(straight_test_2, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Straight - Low Ace not found.");
            }
            else
            {
                //Console.WriteLine("Success : straight - Low Ace found");
                //for (int i = 0; i < fullHandSize; ++i)
                //{
                //    Console.Write(straight_test_2[i].GetDisplayString());
                //    Console.Write("  ");
                //}
            }
        }
        /// <summary>
        ///  A parameter of the player 
        ///  and tests a variety of flush/close to flush hands
        ///   printing a message specific to the error type if the desired result is not returned
        /// </summary>

        public void DoFlushTests(Player player)
        {
            player.myBestHand.SortCardValues(flush_test_0, fullHandSize);
            player.myBestHand.SortCardValues(flush_test_1, fullHandSize);

            if (player.myBestHand.IsHandAFlush(flush_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Flush - basic detection failed.");
            }
            else
            {
                //Console.WriteLine("Success: Flush - basic detection passed");
                //for (int i = 0; i < fullHandSize; ++i)
                //{
                //    Console.Write(flush_test_0[i].GetDisplayString());
                //    Console.Write("  ");
                //}
            }
            if (player.myBestHand.IsHandAFlush(flush_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Flush - false positive.");
            }
            else
            {
                //Console.WriteLine("Success: Flush  - false positive wasn't detected");
                //for (int i = 0; i < fullHandSize; ++i)
                //{
                //    Console.Write(flush_test_1[i].GetDisplayString());
                //    Console.Write("  ");
                //}
            }
        }
        /// <summary>
        ///  A parameter of the player 
        ///  and tests a variety of poker/close to poker hands
        ///   printing a message specific to the error type if the desired result is not returned
        /// </summary>
        public void DoPokerTests(Player player)
        { 
            player.myBestHand.SortCardValues(poker_test_0, fullHandSize);
            player.myBestHand.SortCardValues(poker_test_1, fullHandSize);
            if (player.myBestHand.IsHandAPoker(poker_test_0,fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Poker - basic detection failed");
            }
            else
            {
                //Console.WriteLine("Success: Poker - basic detection passed");
                //for (int i = 0; i < fullHandSize; ++i)
                //{
                //    Console.Write(poker_test_0[i].GetDisplayString());
                //    Console.Write("  ");
                //}
            }
            if(player.myBestHand.IsHandAPoker(poker_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Poker - false positive.");
            }
            else
            {
                //Console.WriteLine("Success: Poker - false postive not detected");
            }
        }
        /// <summary>
        ///  A parameter of the player 
        ///  and tests a variety of FullHouse/close to FullHouse hands
        ///   printing a message specific to the error type if the desired result is not returned
        /// </summary>
        public void DoFullHouseTests(Player player)
        {
            player.myBestHand.SortCardValues(full_house_test_0, fullHandSize);
            player.myBestHand.SortCardValues(full_house_test_1, fullHandSize);
            if (player.myBestHand.IsHandAFullHouse(full_house_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Full House - basic detection failed");
            }

            if (player.myBestHand.IsHandAFullHouse(full_house_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Full House - false positive");
            }
        }
        /// <summary>
        ///  A parameter of the player 
        ///  and tests a variety of Pair/close to Pair hands
        ///   printing a message specific to the error type if the desired result is not returned
        /// </summary>
        public void DoPairTests(Player player)
        {
            player.myBestHand.SortCardValues(pair_test_0, fullHandSize);
            player.myBestHand.SortCardValues(pair_test_1, fullHandSize);
            if (player.myBestHand.IsHandAPair(pair_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Pair - basic detection failed");
            }
            if (player.myBestHand.IsHandAPair(pair_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Pair - false positive");
            }
        }
        /// <summary>
        ///  A parameter of the player 
        ///  and tests a variety of Two Pair/close to Two Pair hands
        ///   printing a message specific to the error type if the desired result is not returned
        /// </summary>
        public void DoTwoPairTests(Player player)
        {
            player.myBestHand.SortCardValues(two_pair_test_0, fullHandSize);
            player.myBestHand.SortCardValues(two_pair_test_1, fullHandSize);
            if (player.myBestHand.IsHandATwoPair(two_pair_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Two Pair - basic detection failed");
            }
            if (player.myBestHand.IsHandATwoPair(two_pair_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Two Pair - false positive");
            }
        }
        /// <summary>
        ///  A parameter of the player 
        ///  and tests a variety of Straight Flush/close to Straight Flush hands
        ///   printing a message specific to the error type if the desired result is not returned
        /// </summary>
        public void DoStraightFlushTests(Player player)
        {
            player.myBestHand.SortCardValues(straight_flush_test_0,fullHandSize);
            player.myBestHand.SortCardValues(straight_flush_test_1, fullHandSize);

            if (player.myBestHand.IsHandAStraightFlush(straight_flush_test_0, fullHandSize) == false)
            {
                Console.WriteLine("ERROR: Straight Flush - basic detection failed");
            }

            if (player.myBestHand.IsHandAStraightFlush(straight_flush_test_1, fullHandSize))
            {
                Console.WriteLine("ERROR: Straight Flush - false positive");
            }
        }
        /// <summary>
        /// A parameter of the player 
        /// Runs through all hand tests
        ///  printing a message specific to the error type if the desired result is not returned
        /// </summary>
        public void DoHandTests(Player player)
        {
            DoStraightTests(player);
            DoFlushTests(player);
            DoPokerTests(player);
            DoFullHouseTests(player);
            DoPairTests(player);
            DoStraightFlushTests(player);
            DoTwoPairTests(player);

            //player.myHand.GetBestHand(two_pair_test_0, 7);

        }
    }
}
