using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace NEA_PROJECT
{
    /// <summary>
    /// Contain all all player values and instances of chips, evaluation hand, hand strength and hand
    /// Also responsible for all AI decisions
    /// </summary>
    public class Player
    {
        public Chips myChips = new Chips();
        public HandEvaluation myBestHand = new HandEvaluation(); // This is the best possible hand you can make from all the cards
        public Hand myHand = new Hand();
        public HandStrength handStrength = new HandStrength();
        public bool playerFolded = false;
        
        private bool playerAllIn = false;
        public bool playerAllInState // add this getter and setter to break it easier to set a break point when searcing for bugs.
        {
            get
            {
                return playerAllIn;
            }
            set
            {
                playerAllIn = value;
            }
        }


        public int cardValUpperLimit = 14;
        public int cardValLowerLimit = 10;
        public Random randomGenerator = new Random();

        //public HandStrength myBestHand = new HandStrength();

        public enum AIBetDecision
        {
            Fold,
            BetLow,
            BetHigh,
            AllIn
        };
        public Player()
        {
        }
        /// <summary>
        /// Takes three parameters - both players and the round phase
        /// Evaluates the AI's Hand and assigns all values to hand strength vals
        /// the function then checks to see if the players all in
        /// then if its true it checks the players bet and makes a decision
        /// Otherwise goes through Phase bets and gets a bet amount and returns this value 
        /// </summary>
        /// <param name="AI"></param>
        /// <param name="player"></param>
        /// <param name="currentPhase"></param>
        /// <returns></returns>
        public int AIBetAmount(Player AI, Player player, Table.RoundPhases currentPhase)
        {
            int betAmount = 0;
            HandEvaluatorSystem(AI, Table.tableCards);
            HandStrength.AssignHandStrengthVals(AI);
            AIBetDecision aiBetDecision = MakeAIBetDecision(player, AI, AI.myBestHand.playerBestCardVals, currentPhase);
            switch (aiBetDecision)
            {
                case AIBetDecision.Fold:
                    if(DoesAIBluff())
                    {
                        if (AI.myChips.roundBetTotal + AI.myChips.PlayerChipCount > player.myChips.roundBetTotal)
                        {
                            AI.playerAllInState = true;
                            return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                        }
                        else
                        {
                            AI.playerAllInState = true;
                            return AI.myChips.PlayerChipCount;
                        }
                    }
                    AI.playerFolded = true;
                    return 0;
                case AIBetDecision.BetLow: break;
                case AIBetDecision.BetHigh: break;
                case AIBetDecision.AllIn:
                    if (AI.myChips.roundBetTotal + AI.myChips.PlayerChipCount > player.myChips.roundBetTotal)
                    {
                        AI.playerAllInState = true;
                        return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
                    }
                    else
                    {
                        AI.playerAllInState = true;
                        return AI.myChips.PlayerChipCount;
                    }
            }

            betAmount = AIPhaseBets(betAmount, aiBetDecision, AI.myBestHand.playerBestCardVals, currentPhase, player, AI);
            if (AI.playerAllInState == true)
                return AI.myChips.PlayerChipCount;
            else if(AI.playerFolded == false && betAmount + AI.myChips.roundBetTotal < player.myChips.roundBetTotal)
            {
                return player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
            }
            else
            {
                return betAmount;
            }
        }
        /// <summary>
        /// Takes 6 Parameters - bet amount, bet decision, hand strength vals, RoundPhases and both players
        /// takes the current game phase then enters the functions
        /// returning a bet amount value, this can be modified by the ai bet decision 
        /// <returns> betAmount</returns>
        public int AIPhaseBets(int betAmount, AIBetDecision aiBetDecision, int [] handStrengthVals, Table.RoundPhases currentPhase, Player player, Player AI)
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

            betAmount = AdjustBetForDecision(aiBetDecision, betAmount, currentPhase, AI);

            if(betAmount == AI.myChips.PlayerChipCount)
            {
                AI.playerAllInState = true;
            }

            return betAmount;
        }

        public int AdjustBetForDecision(AIBetDecision aiBetDecision, int betAmount, Table.RoundPhases currentPhase, Player AI)
        {
            if(AI.playerFolded)
            {
                return 0;
            }

            Debug.Assert(aiBetDecision == AIBetDecision.BetLow || aiBetDecision == AIBetDecision.BetHigh);

            switch(currentPhase)
            {
                case Table.RoundPhases.Pre_Flop:
                    if(aiBetDecision == AIBetDecision.BetLow)
                    {
                        betAmount += randomGenerator.Next(-10, 2);
                    }
                    else
                    {
                        betAmount += randomGenerator.Next(0, 5);
                    }
                    break;
                case Table.RoundPhases.Flop:
                    if (aiBetDecision == AIBetDecision.BetLow)
                    {
                        betAmount += randomGenerator.Next(-6, 3);
                    }
                    else
                    {
                        betAmount += randomGenerator.Next(0, 10);
                    }
                    break;
                case Table.RoundPhases.Turn:
                    if (aiBetDecision == AIBetDecision.BetLow)
                    {
                        betAmount += randomGenerator.Next(-3, 3);
                    }
                    else
                    {
                        betAmount += randomGenerator.Next(0, 15);
                    }
                    break;
                case Table.RoundPhases.River:
                    if (aiBetDecision == AIBetDecision.BetLow)
                    {
                        betAmount += randomGenerator.Next(-1, 5);
                    }
                    else
                    {
                        betAmount += randomGenerator.Next(0, 30);
                    }
                    break;
            }

            if (betAmount < 0)
                betAmount = 0;
            else if (betAmount > AI.myChips.PlayerChipCount)
                betAmount = AI.myChips.PlayerChipCount;

            return betAmount;
        }

        /// <summary>
        /// Takes 5 parameters -  bet amount, hand strength vals, RoundPhases and both players
        /// if the players starting hand is a pair of 10s or higher they will return a 6th of there starting chips
        /// if its lower than a ten it will return a 7th
        /// else it will see if it wants to call 
        /// otherwise it will return a 12th 
        /// </summary>
        /// <param name="roundPhase"></param>
        /// <param name="betAmount"></param>
        /// <param name="handStrengthVals"></param>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <returns></returns>
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
        /// <summary>
        ///  Takes 5 parameters -  bet amount, hand strength vals, RoundPhases and both players
        ///  In the Flop Phase
        ///  Checks the hand type of the player then goes and checks if they AI will fold, call, raise or check given its hand strength values 
        ///  and return the appropriate bet amount
        /// </summary>

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
        /// <summary>
        /// Takes 5 parameters -  bet amount, hand strength vals, RoundPhases and both players
        /// In the turn Phase
        ///  Checks the hand type of the player then goes and checks if they AI will fold, call, raise or check given its hand strength values 
        ///  and return the appropriate bet amount
        /// </summary>
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
        /// <summary>
        ///  /// <summary>
        /// Takes 5 parameters -  bet amount, hand strength vals, RoundPhases and both players
        /// In the River Phase
        ///  Checks the hand type of the player then goes and checks if they AI will fold, call, raise or check given its hand strength values 
        ///  and return the appropriate bet amount
        /// </summary>
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
        /// <summary>
        /// Takes 3 parameters - boths players and handStrength Valss
        /// It runs through a checklist and if at least 3/4 criteria are met the AI folds by returning true 
        /// else it will return false
        /// <returns></returns>
        public bool DoesAIFold(Player player, Player AI, int[] handStrengthVals)
        {
            int foldingBar = 5;
            int minFoldingAmount = 3;
            if(player.myChips.roundBetTotal > (AI.myChips.roundBetTotal)*2 && player.myChips.roundBetTotal >= 25)
            {
                --foldingBar;
            }
            if (AI.myChips.PlayerChipCount < 10)
            {
                --foldingBar;
            }
            if (AI.myChips.PlayerChipCount < (player.myChips.PlayerChipCount/4))
            {
                --foldingBar;
            }
            if (handStrengthVals[0] < (int)HandEvaluation.PokerHand.TwoPair)
            {
                --foldingBar;
            }
            if(foldingBar < minFoldingAmount)
            {
                playerFolded = true;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Takes 4 parameters  - both players, hand strength values and if it is the first bet in the phase
        /// if it's the first bet it will return false otherwise
        /// will check that the AI's hand is less than a straight 
        /// it will also check to see if enough chips are available
        /// if the AI has less chips than the players bet it may go all in if it has less than 25 chips
        /// </summary>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <param name="handStrengthVals"></param>
        /// <param name="IsitFirstBet"></param>
        /// <returns></returns>
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
                    else if (AI.myChips.PlayerChipCount < 25)
                    {
                        playerAllInState = true;
                        return false;
                    }

                }
            }
            
            return false;
        }

    /// <summary>
    /// takes 4 parameters - both players, hand strength vals and the roundphase
    /// as long as the AI's bet total is the same as the players it will
    /// run through a check list and if atleast 2/5 of the conditions are met will return true 
    /// it will also have a random 1/5 chance of checking despite the checklist
    /// else it returns false
    /// </summary>
        public bool DoesAICheck(Player player, Player AI, int[] handStrengthVals, Table.RoundPhases roundPhases)
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
        /// <summary>
        /// takes 4 parameters - both players, hand strength vals and the roundphase
        /// and checks if the hand type is greater or equal to a straight and the round phase it atleast a flop it will return true 
        /// also has a random chance of 'bluffing' and going all in anyway
        /// else it returns false
        /// </summary>

        public bool IsAIAllIn(Player player, Player AI, int[] handStrengthVals, Table.RoundPhases roundPhases)
         {
            if(handStrengthVals[0] >= (int)HandEvaluation.PokerHand.Straight && roundPhases >= Table.RoundPhases.Flop)
            {
                playerAllInState = true;
                return true;
            }
            if(DoesAIBluff())
            {
                playerAllInState = true;
                return true;
            }
            return false;
      
         }
        /// <summary>
        /// Just randomly picks a number from 0-4 
        /// if it picks 4 it returns true otherwise it returns false
        /// </summary>
        /// <returns></returns>
        public bool DoesAIBluff()
        {
            int AIbluffChance = randomGenerator.Next(0, 5);
            return AIbluffChance == 4;
        }
        /// <summary>
        /// Takes 3 parameters -  bet amount and both players
        /// If at the end of the bet phase bets the bet is invalid this function will make the bet valid 
        /// and return a newbet amount
        /// 
        /// </summary>
        public int MakeAIBetValid(Player player, Player AI, int betAmount)
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
                                AI.playerAllInState = true;
                                return AI.myChips.PlayerChipCount;
                            }
                        }
                        Debug.Fail("MakeAIBetValid : Infinite Loop");
                        break;
                }
            }
            return betAmount;
        }

        /// <summary>
        /// Looks at AI hand: 
        /// If a very strong hand goes all in
        /// If a good hand bets high
        /// Otherwise might fold if player bets high
        /// If none of these then bets low.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="AI"></param>
        /// <param name="handStrengthVals"></param>
        /// <param name="currentPhase"></param>
        /// <returns></returns>
        public AIBetDecision MakeAIBetDecision(Player player, Player AI, int[] handStrengthVals, Table.RoundPhases currentPhase)
        {
            int allInHand = (int)HandEvaluation.PokerHand.ThreeOfAKind;
            allInHand += randomGenerator.Next(0, 4); // between 3 of a kind and a fullhouse

            if (handStrengthVals[0] >= allInHand) // randomly go all in to surprise people
                return AIBetDecision.AllIn;

            int betHighHand = (int)HandEvaluation.PokerHand.TwoPair;
            betHighHand += randomGenerator.Next(0, 4); // between two pair and a flush

            if (handStrengthVals[0] >= betHighHand) // if the hand is good bet high, random to not be predictable.
                return AIBetDecision.BetHigh;

            int maybeFoldBet = (handStrengthVals[0] <= (int)HandEvaluation.PokerHand.HighCard
                ? randomGenerator.Next(0, 31)
                : randomGenerator.Next(10, 41));

            int betDifference = player.myChips.roundBetTotal - AI.myChips.roundBetTotal;
            Debug.Assert(betDifference >= 0);

            if (currentPhase != Table.RoundPhases.Pre_Flop && betDifference >= maybeFoldBet) // if the bet was big then we have a chance of folding
            {
                int foldCheck = randomGenerator.Next(0, betDifference);
                if (foldCheck == 0) // always fold on a zero
                    return AIBetDecision.Fold;
                if (foldCheck == betDifference - 1) // never fold if the check was the maximum
                    return AIBetDecision.BetLow;

                int randomForFoldCheck = betDifference - (betDifference / randomGenerator.Next(2, 6));

                if (foldCheck >= randomForFoldCheck) // otherwise fold if the check was equal to or greater than a random fraction
                {
                    return AIBetDecision.Fold;
                }
            }

            return AIBetDecision.BetLow;
        }

        /// <summary>
        ///  takes  3 parameters - both players and the bet amount
        ///  checks if the AI's bet  is greater than or equal to the players bet and if there bet is not greater than there chip count
        ///  if both true returns true 
        ///  else it returns false
        /// </summary>
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
        /// <summary>
        /// A parameter - the player 
        /// Combines the current table cards and the players hand and sorts them in descending order
        ///  and sets poker hand to the best hand type
        ///  and asserts if the cards passed in to players bets hand aren't in the combined hand
        ///  then returns pokerHand
        /// </summary>
        static public HandEvaluation.PokerHand HandEvaluatorSystem(Player player, Card[] tableCards) // Combines a players hand with the table cards, sorts the values and then gets the best hand
        {
            CombineHandAndTableCards(player.myHand.playerHand, tableCards, ref player.handStrength.combinedHand);

            player.myBestHand.SortCardValues(player.handStrength.combinedHand, player.myBestHand.GetNumberOfValidCards(player.handStrength.combinedHand));

            HandEvaluation.PokerHand pokerHand = player.myBestHand.GetBestHand(
                player, 
                player.handStrength.combinedHand, 
                player.myBestHand.GetNumberOfValidCards(player.handStrength.combinedHand));
            
            Debug.Assert(player.handStrength.CheckCardsExistInCombinedHand(player.myBestHand.playersBestHand));
            
            return pokerHand;

        }
        /// <summary>
        /// Combines Table and player cards
        /// </summary>
        //static public void CombineHandAndTableCards()
        //{
        //    CombineHandAndTableCards(myHand.playerHand, Table.tableCards);
        //}

        static public void CombineHandAndTableCards(Card[] playerHand, Card[] tableCards, ref Card[] combinedCards)
        {
            int handcounter = 0;
            for (int j = 0; j < playerHand.Length; ++j)
            {
                combinedCards[handcounter] = playerHand[j];
                ++handcounter;
            }
            for (int i = 0; i < Table.tableCards.Length; ++i)
            {
                combinedCards[handcounter] = tableCards[i];
                ++handcounter;
            }

        }
    }
}
