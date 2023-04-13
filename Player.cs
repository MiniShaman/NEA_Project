using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    public class Player
    {
        public Chips myChips = new Chips();
        public HandEvaluation myBestHand = new HandEvaluation(); // This is the best possible hand you can make from all the cards
        public Hand myHand = new Hand();
        public HandStrength handStrength = new HandStrength();
        public bool playerFolded = false;
        public bool playerAllIn = false;
        public int cardValUpperLimit = 14;
        public int cardValLowerLimit = 10;
        //public HandStrength myBestHand = new HandStrength();

        public Player()
        {
        }
        public int AIBetAmount(Player AI, Player player, Table.RoundPhases currentPhase)
        {
            int betAmount = 0;
            HandEvaluatorSystem(AI);
            handStrength.AssignHandStrengthVals(AI);
            if(player.playerAllIn)
            {
                switch (CheckOpposingBet(player, AI, AI.myBestHand.playerBestCardVals))
                {
                    case 1:
                    case 2:
                        AI.playerAllIn = true;
                        return AI.myChips.PlayerChipCount;
                    case 3:
                        AI.playerFolded = true;
                        return 0;
                }
            }
            betAmount = AIPhaseBets(betAmount, AI.myBestHand.playerBestCardVals, currentPhase, player, AI);
            if (AI.playerAllIn == true)
                return AI.myChips.PlayerChipCount;
            else if(betAmount + AI.myChips.roundBetTotal < player.myChips.roundBetTotal)
            {
                return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
            }
            else
            {
                return betAmount;
            }
        }
        /*public int AIHandCheck(int betAmount)
        {
            bool firstCardCheck = true;
            for(int i = 0; i<myHand.playerHand.Length;++i)
            {
                if(myHand.playerHand[i].Value <=cardValUpperLimit && myHand.playerHand[i].Value >=cardValLowerLimit)
                {
                    if (firstCardCheck)
                    {
                        betAmount += 3;
                    }
                    betAmount += 2;
                }
                else if(myHand.playerHand[i].Value <= (cardValUpperLimit - 5) && myHand.playerHand[i].Value >= (cardValLowerLimit-5))
                {
                    if (firstCardCheck)
                    {
                        betAmount += 2;
                    }
                    ++betAmount;
                }
                else
                {
                    if (firstCardCheck)
                    {
                        ++betAmount;
                    }

                }
                firstCardCheck = false;
            }
            return betAmount;
        }*/

        public int AIPhaseBets(int betAmount, int [] handStrengthVals, Table.RoundPhases currentPhase, Player player, Player AI)
        {
            if(currentPhase == Table.RoundPhases.Pre_Flop)
            {
                betAmount = AIPreFlopPhase(currentPhase,betAmount, handStrengthVals, player, AI);
            }
            else if (currentPhase == Table.RoundPhases.Flop)
            {
                betAmount = AIFlopPhase(currentPhase, betAmount, handStrengthVals, player, AI);
            }
            else if (currentPhase == Table.RoundPhases.Turn)
            {
                betAmount = AITurnPhase(currentPhase, betAmount, handStrengthVals, player, AI);
            }
            else if (currentPhase == Table.RoundPhases.River)
            {
                betAmount = AIRiverPhase(currentPhase, betAmount, handStrengthVals, player, AI);
            }
            return betAmount;
        }


        public int AIPreFlopPhase(Table.RoundPhases roundPhase,int betAmount, int[] handStrengthVals, Player player, Player AI)
        {
            if (handStrengthVals[0] == (int)HandEvaluation.PokerHand.Pair)
            {
                if (handStrengthVals[1] >= cardValLowerLimit)
                {
                    betAmount += AI.myChips.PlayerChipCount / 6;
                }
                else
                {
                    betAmount += AI.myChips.PlayerChipCount / 7;
                }
            }
            else if (DoesAICall(player, AI, handStrengthVals))
            {
                return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
            }
            else
            {
                betAmount += AI.myChips.PlayerChipCount / 12;
            }
            return betAmount;
        }
        public int AIFlopPhase(Table.RoundPhases roundPhase, int betAmount, int[] handStrengthVals, Player player, Player AI)
        {
            if (handStrengthVals[0] < (int)HandEvaluation.PokerHand.TwoPair)
            {
                if (DoesAIFold(player,AI,handStrengthVals))
                {
                    return 0;
                }
                else if (DoesAICheck(player,AI,handStrengthVals,roundPhase))
                {
                    return 0;
                }
                else
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                }
            }
            else if (handStrengthVals[0] > (int)HandEvaluation.PokerHand.TwoPair && handStrengthVals[0] < (int)HandEvaluation.PokerHand.Flush)
            {
                if(IsAIAllIn(player,AI,handStrengthVals,roundPhase))
                {
                    return AI.myChips.PlayerChipCount;
                }
                else if (DoesAICheck(player, AI, handStrengthVals, roundPhase))
                {
                    return 0;
                }
                else if (DoesAICall(player, AI, handStrengthVals))
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                }
                betAmount = +AI.myChips.PlayerChipCount / 12;
            }
            else
            {
                if (IsAIAllIn(player, AI, handStrengthVals, roundPhase))
                {
                    return AI.myChips.PlayerChipCount;
                }
                else if (DoesAICheck(player, AI, handStrengthVals, roundPhase))
                {
                    return 0;
                }
                else if (DoesAICall(player, AI, handStrengthVals))
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                }
                betAmount = +AI.myChips.PlayerChipCount / 10;
            }
            return betAmount;
        }
        public int AITurnPhase(Table.RoundPhases roundPhase, int betAmount, int[] handStrengthVals, Player player, Player AI)
        {
            if (handStrengthVals[0] < (int)HandEvaluation.PokerHand.TwoPair)
            {
                if (DoesAIFold(player, AI, handStrengthVals))
                {
                    return 0;
                }
                else if (DoesAICheck(player, AI, handStrengthVals, roundPhase))
                {
                    return 0;
                }
                else
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                }
            }
            else if (handStrengthVals[0] > (int)HandEvaluation.PokerHand.TwoPair && handStrengthVals[0] < (int)HandEvaluation.PokerHand.Flush)
            {
                if (IsAIAllIn(player, AI, handStrengthVals, roundPhase))
                {
                    return AI.myChips.PlayerChipCount;
                }
                else if (DoesAICheck(player, AI, handStrengthVals, roundPhase))
                {
                    return 0;
                }
                else if (DoesAICall(player, AI, handStrengthVals))
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                }
                betAmount += AI.myChips.PlayerChipCount / 12;
            }
            else
            {
                if (IsAIAllIn(player, AI, handStrengthVals, roundPhase))
                {
                    return AI.myChips.PlayerChipCount;
                }
                else if (DoesAICheck(player, AI, handStrengthVals, roundPhase))
                {
                    return 0;
                }
                else if (DoesAICall(player, AI, handStrengthVals))
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                } 
                betAmount += AI.myChips.PlayerChipCount / 10;
            }
            return betAmount;
        }
        public int AIRiverPhase(Table.RoundPhases roundPhase, int betAmount, int[] handStrengthVals, Player player, Player AI)
        {
            if (handStrengthVals[0] < (int)HandEvaluation.PokerHand.TwoPair)
            {
                if (DoesAIFold(player, AI, handStrengthVals))
                {
                    return 0;
                }
                else if (DoesAICheck(player, AI, handStrengthVals, roundPhase))
                {
                    return 0;
                }
                else 
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                }
            }
            else if (handStrengthVals[0] > (int)HandEvaluation.PokerHand.TwoPair && handStrengthVals[0] < (int)HandEvaluation.PokerHand.Flush)
            {
                if (IsAIAllIn(player, AI, handStrengthVals, roundPhase))
                {
                    return AI.myChips.PlayerChipCount;
                }
                else if (DoesAICheck(player, AI, handStrengthVals, roundPhase))
                {
                    return 0;
                }
                else if (DoesAICall(player, AI, handStrengthVals))
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                }
                betAmount += AI.myChips.PlayerChipCount / 12;
            }
            else
            {
                if (IsAIAllIn(player, AI, handStrengthVals, roundPhase))
                {
                    return AI.myChips.PlayerChipCount;
                }
                else if (DoesAICheck(player, AI, handStrengthVals, roundPhase))
                {
                    return 0;
                }
                else if (DoesAICall(player, AI, handStrengthVals))
                {
                    return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                }
                betAmount += AI.myChips.PlayerChipCount/10;
            }
            return betAmount;
        }
        public bool DoesAIFold(Player player, Player AI, int[] handStrengthVals)
        {
            int foldingBar = 5;
            int minFoldingAmount = 3;
            if(player.myChips.roundBetTotal > (AI.myChips.roundBetTotal)*1.5 && player.myChips.roundBetTotal >= 15)
            {
                --foldingBar;
            }
            if (AI.myChips.PlayerChipCount < 10)
            {
                --foldingBar;
            }
            if(handStrengthVals[0] < (int)HandEvaluation.PokerHand.TwoPair)
            {
                --foldingBar;
            }
            if(foldingBar <= minFoldingAmount)
            {
                playerFolded = true;
                return true;
            }
            else if(DoesAIBluff())
            {
                playerFolded = true;
                return true;
            }
            return false;
        }
        public bool DoesAICall(Player player, Player AI, int[] handStrengthVals, bool IsitFirstBet = true)
        {
            if (IsitFirstBet)
            {
                if (handStrengthVals[0] < (int)HandEvaluation.PokerHand.Straight)
                {
                    if ((AI.myChips.PlayerChipCount + AI.myChips.roundBetTotal) >= (player.myChips.PlayerChipCount + player.myChips.roundBetTotal))
                    {
                        if (AI.myChips.roundBetTotal < player.myChips.roundBetTotal)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        playerAllIn = true;
                        return false;
                    }

                }
            }
            
            return false;
        }
        public bool DoesAICheck(Player player, Player AI, int[] handStrengthVals, Table.RoundPhases roundPhases, bool firstBetNotValid = false)
        {
            int CheckBar = 5;
            int minCheckAmount = 3;
            if (AI.myChips.roundBetTotal == player.myChips.roundBetTotal && !Program.firstBet)
            {
                if (AI.myChips.PlayerChipCount <= 50)
                {
                    --CheckBar;
                }
                if (player.myChips.roundBetTotal > (AI.myChips.roundBetTotal) * 1.5 && player.myChips.roundBetTotal >= 10)
                {
                    --CheckBar;
                }
                if (handStrengthVals[0] <= (int)HandEvaluation.PokerHand.TwoPair)
                {
                    --CheckBar;
                }
                if ((int)roundPhases <= (int)Table.RoundPhases.Flop)
                {
                    --CheckBar;
                }
                if (CheckBar <= minCheckAmount)
                {
                    return true;
                }
                else if (DoesAIBluff())
                {
                    return true;
                }
            }            
            return false;
        }
         public bool IsAIAllIn(Player player, Player AI, int[] handStrengthVals, Table.RoundPhases roundPhases, bool firstBetNotValid = false)
         {
            if(handStrengthVals[0] >= (int)HandEvaluation.PokerHand.Straight && roundPhases >= Table.RoundPhases.Flop)
            {
                playerAllIn = true;
                return true;
            }
            if(DoesAIBluff())
            {
                playerAllIn = true;
                return true;
            }
            return false;
      
         }
        public bool DoesAIBluff()
        {
            Random AIBluff = new Random();
            int AIbluffChance = AIBluff.Next(0, 5);
            return AIbluffChance == 4;
        }
        public bool IsAIBetInvalid(Player player, Player AI ,int betAmount)
        {
            int totalRoundBet = betAmount + AI.myChips.roundBetTotal;
            if(totalRoundBet < player.myChips.roundBetTotal)
            {
                return false;
            }
            return true;
        }

        public int MakeAIBetValid(Player player, Player AI, int betAmount, int[] handStrengthVals, Table.RoundPhases roundPhases)
        {
            int AITotalBet = betAmount + AI.myChips.roundBetTotal;
            int AIGameDecision = 0;
            bool AIValidchoice = false;
            while (!AIValidchoice)
            {
                switch (AIGameDecision)
                {
                    case 0:
                        if (AITotalBet == player.myChips.roundBetTotal)
                            return 0;
                        else
                            ++AIGameDecision;
                        break;
                    case 1:

                        if (AITotalBet < player.myChips.roundBetTotal)
                        {
                            betAmount = player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                            if (IsBetAmountInBoundary(player, AI, betAmount))
                            {
                                return betAmount;
                            }
                            else if (AITotalBet < player.myChips.roundBetTotal)
                            {
                                AI.playerAllIn = true;
                                return AI.myChips.PlayerChipCount;
                            }
                        }
                        break;
                }
            }
            return betAmount;
        }
        public int CheckOpposingBet(Player player, Player AI, int[] handStrengthVals)
        {
            int minBetDifBoundary = 15;
            int MaxBetDifBoundary = 30;
            int betDifference = player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
            if (betDifference > MaxBetDifBoundary)
            {
                if (handStrengthVals[0] >= (int)HandEvaluation.PokerHand.Straight)
                {
                    return 1;
                }
            }
            else if (betDifference <= MaxBetDifBoundary && betDifference >= minBetDifBoundary)
            {
                if (handStrengthVals[0] >= (int)HandEvaluation.PokerHand.ThreeOfAKind)
                {
                    return 2;
                }
            }
            else if (betDifference <= MaxBetDifBoundary - 15 && betDifference >= minBetDifBoundary - 7)
            {
                if (handStrengthVals[0] >= (int)HandEvaluation.PokerHand.Pair)
                {
                    return 3;
                }
            }
            else
            {
                return 0;
            }

            return 0;
        }
        public bool IsBetAmountInBoundary(Player player, Player AI, int betAmount)
        {
            int AITotalBet = betAmount + AI.myChips.roundBetTotal;
            if (AITotalBet >= player.myChips.roundBetTotal)
            {
                if(betAmount < AI.myChips.PlayerChipCount)
                {
                    return true;
                }
            }
            return false;
        }
        public HandEvaluation.PokerHand HandEvaluatorSystem(Player player) // Combines a players hand with the table cards, sorts the values and then gets the best hand
        {
            CombineHandAndTableCards();
            myBestHand.SortCardValues(handStrength.combinedHand, myBestHand.GetNumberOfValidCards(handStrength.combinedHand));
            HandEvaluation.PokerHand pokerHand = myBestHand.GetBestHand(player, handStrength.combinedHand, myBestHand.GetNumberOfValidCards(handStrength.combinedHand));
            Debug.Assert(player.handStrength.CheckCardsExistInCombinedHand(player.myBestHand.playersBestHand));
            return pokerHand;

        }
        public void CombineHandAndTableCards()
        {
            int handcounter = 0;
            for (int j = 0; j < myHand.playerHand.Length; ++j)
            {
                handStrength.combinedHand[handcounter] = myHand.playerHand[j];
                ++handcounter;
            }
            for (int i = 0; i < Table.tableCards.Length; ++i)
            {
                handStrength.combinedHand[handcounter] = Table.tableCards[i];
                ++handcounter;
            }
            
        }
    }
}
