using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    static class Day2
    {
        private const string _strategyPrompt = "Enter the strategy below";

        private static int GetRoundPoints(char opponentMove, char playerMove)
        {
            // get numeric values of each move
            int opponentValue = opponentMove - '0' - 16;  // A = 1, B = 2, C = 3
            int playerValue = playerMove - '0' - 39;      // X = 1, Y = 2, Z = 3 
            
            int diff = playerValue - opponentValue;

            switch (diff)
            {
                case 0: 
                    return playerValue + 3;   // draw: same shape
                case 1:
                case -2: 
                    return playerValue + 6;  // win: better shape
                default: 
                    return playerValue;      // lose: worse shape
            }
        }

        /// <summary>
        /// Part 1: Calculate total score from input, where player moves correspond to X = Rock, Y = Paper, Z = Scissors
        /// </summary>
        public static int GetScoreFromAssumedStrategy()
        {
            string[] input = Helpers.ReadMultipleLines(_strategyPrompt);
            int score = 0;

            foreach (string movePair in input)
            {
                string[] moves = movePair.Trim('\r').Split(' ');
                score += GetRoundPoints(char.Parse(moves[0]), char.Parse(moves[1]));
            }

            return score;
        }

        private static char getMoveFromOutcome(char opponentMove, char outcome)
        {
            switch (outcome)
            {
                case 'X':
                    return opponentMove == 'A' ? 'Z' : (char)(opponentMove - '0' + 70);  // lose, play lower move (or highest if opponent plays lowest)
                case 'Y':
                    return (char)(opponentMove - '0' + 71);                              // draw, return same equivalent shape
                default:
                    return opponentMove == 'C' ? 'X' : (char)(opponentMove - '0' + 72);  // win, play higher move (or lowest if opponent plays highest)
            }
        }

        /// <summary>
        /// Part 2: Calculate total score from input, with X = Lose, Y = Tie, Z = Win
        /// </summary>
        public static int GetScoreFromElfStrategy()
        {
            string[] input = Helpers.ReadMultipleLines(_strategyPrompt);

            int score = 0;

            foreach (string movePair in input)
            {
                string[] moves = movePair.Trim('\r').Split(' ');

                if (moves.Length != 2) break;  // TODO: strip last empty string from input

                char opponentMove = char.Parse(moves[0]);

                char playerMove = getMoveFromOutcome(opponentMove, char.Parse(moves[1]));
                score += GetRoundPoints(opponentMove, playerMove);
            }

            return score;
        }
    }
}
