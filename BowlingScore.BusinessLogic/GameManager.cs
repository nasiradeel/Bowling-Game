using BowlingScore.BusinessLogic.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.BusinessLogic
{
    public class GameManager : IGameManager
    {
        // variable declation
        private int[] _rolls = new int[21];
        private int _currentRollIndex = 0;

        /// <summary>
        /// Accepts a list of frames and returns the total score
        /// </summary>
        /// <param name="frames">list of frames</param>
        /// <returns>return score</returns>
        public Score CalculateScore(List<Frame> frames)
        {
            // make a list of all roll knoched for all frames
            List<int> rollsPins = GetRollsPins(frames);

            foreach (var rollPins in rollsPins)
            {
                Roll(rollPins);
            }

            var scoreResult = Calculate(frames);

            return new Score { totalScore = scoreResult };
        }

        /// <summary>
        /// Calculates score by adding the open, strike and spare balls
        /// </summary>
        /// <param name="frames">a list of frames</param>
        /// <returns>return bowling score</returns>
        public int Calculate(List<Frame> frames)
        {
            int score = 0;
            int frameIndex = 0;
            foreach (Frame frame in frames)
            {
                int frameScore;
                //grant strike bonus
                if (frame.isStrike())
                {
                    frameScore = 10 + GetStrikeBonus(frameIndex);
                    frameIndex++;
                }
                // grant spare bonus
                else
                {
                    frameScore = FrameTotal(frameIndex);
                    if (frame.isSpare())
                    {
                        frameScore += GetSpareBonus(frameIndex);
                    }

                    frameIndex += 2;
                }
                //add score resulting frame scores
                score += frameScore;
            }

            return score;
        }

        /// <summary>
        /// keep track of all roles in the frames
        /// </summary>
        /// <param name="frames">pins</param>
        public void Roll(int numPins)
        {
            if (_currentRollIndex > 20)
                throw new InvalidOperationException("Game over!");

            _rolls[_currentRollIndex] = numPins;
            _currentRollIndex++;
        }

        /// <summary>
        /// calculates the frame total score
        /// </summary>
        private int FrameTotal(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        /// <summary>
        /// calculates the score of strike ball and grant bonus
        /// </summary>
        private int GetSpareBonus(int frameIndex)
        {
            int spareBonus = _rolls[frameIndex + 2];
            return spareBonus;
        }

        /// <summary>
        /// calculates the score of spare ball and grant bonus
        /// </summary>
        private int GetStrikeBonus(int frameIndex)
        {
            var strikeBonus = _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
            return strikeBonus;
        }

        /// <summary>
        /// list of pins knochec out in each frame
        /// </summary>
        private List<int> GetRollsPins(List<Frame> frames)
        {
            List<int> rollsPins = new List<int>();
            foreach (var frame in frames)
            {
                if (frame.FirstRoll != 0)
                    rollsPins.Add(frame.FirstRoll);

                if (frame.SecondRoll != 0)
                    rollsPins.Add(frame.SecondRoll);
            }

            return rollsPins;
        }

        
    }
}
