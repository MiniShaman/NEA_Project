using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    class HandComparisonTest
    {
        Player player1;
        Player player2;

        Card[] tableCards = new Card[5];

        public HandComparisonTest()
        {
            player1 = new Player();
            player2 = new Player();

            Hand.InitialiseHand(tableCards);
        }

        public void DoTests()
        {
            tableCards[0].SetCard(Card.CardSuit.Spades, 8);
            tableCards[1].SetCard(Card.CardSuit.Spades, 7);
            tableCards[2].SetCard(Card.CardSuit.Hearts, 6);
            tableCards[3].SetCard(Card.CardSuit.Clubs, 2);
            tableCards[4].SetCard(Card.CardSuit.Hearts, 4);

            DoTests_0();
            DoTests_1();

            tableCards[0].SetCard(Card.CardSuit.Hearts, Card.Ace);
            tableCards[1].SetCard(Card.CardSuit.Spades, Card.Jack);
            tableCards[2].SetCard(Card.CardSuit.Clubs,6);
            tableCards[3].SetCard(Card.CardSuit.Clubs, 5);
            tableCards[4].SetCard(Card.CardSuit.Clubs, 4);

            DoTests_2();
        }

        public void DoTests_0()
        {
            player1.myHand.playerHand[0].SetCard(Card.CardSuit.Hearts, 7);
            player1.myHand.playerHand[1].SetCard(Card.CardSuit.Hearts, 5);

            player2.myHand.playerHand[0].SetCard(Card.CardSuit.Diamonds, 7);
            player2.myHand.playerHand[1].SetCard(Card.CardSuit.Clubs, 7);

            Player.HandEvaluatorSystem(player1, tableCards);
            Player.HandEvaluatorSystem(player2, tableCards);

            int result = HandStrength.CompareHands(player1, player2);

            if (result == 1)
            {
                Console.WriteLine("Success: Correct player won (player 1)");
            }
            else if (result == -1)
            {
                Console.WriteLine("ERROR: Incorrect player won (player 2) ");
            }
            else
            {
                Console.WriteLine("ERROR: Incorrect result players were drawn ");
            }
        }

        public void DoTests_1()
        {
            player1.myHand.playerHand[0].SetCard(Card.CardSuit.Diamonds, 6);
            player1.myHand.playerHand[1].SetCard(Card.CardSuit.Spades, 6);

            player2.myHand.playerHand[0].SetCard(Card.CardSuit.Diamonds, 7);
            player2.myHand.playerHand[1].SetCard(Card.CardSuit.Clubs, 7);

            Player.HandEvaluatorSystem(player1, tableCards);
            Player.HandEvaluatorSystem(player2, tableCards);

            int result = HandStrength.CompareHands(player1, player2);
            if (result == 1)
            {
                Console.WriteLine("ERROR: Incorrect player won (player 1) ");
            }
            else if (result == -1)
            {
                Console.WriteLine("Success: Correct player won (player 2)");
            }
            else
            {
                Console.WriteLine("ERROR: Incorrect result players were drawn ");
            }
        }
        public void DoTests_2()
        {
            player1.myHand.playerHand[0].SetCard(Card.CardSuit.Spades, Card.Jack);
            player1.myHand.playerHand[1].SetCard(Card.CardSuit.Diamonds, 2);
                                                               
            player2.myHand.playerHand[0].SetCard(Card.CardSuit.Diamonds, Card.Jack);
            player2.myHand.playerHand[1].SetCard(Card.CardSuit.Spades, 2);

            Player.HandEvaluatorSystem(player1, tableCards);
            Player.HandEvaluatorSystem(player2, tableCards);

            int result = HandStrength.CompareHands(player1, player2);

            if (result == 1)
            {
                Console.WriteLine("ERROR: Incorrect player won (player 1) ");
            }
            else if (result == -1)
            {
                Console.WriteLine("ERROR: Incorrect player won (player 2)");
            }
            else
            {
                Console.WriteLine("Success: Correct result players were drawn ");
            }

        }
    }
}
