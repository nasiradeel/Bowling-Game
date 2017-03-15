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
        private int[] _rolls = new int[21];
        private int _currentRollIndex = 0;

        public Score CalculateScore(List<Frame> frames)
        {
            List<int> rollsPins = GetRollsPins(frames);

            foreach (var rollPins in rollsPins)
            {
                Roll(rollPins);
            }

            var scoreResult = Calculate(frames);

            return new Score { totalScore = scoreResult };
        }

        public int Calculate(List<Frame> frames)
        {
            int score = 0;
            int frameIndex = 0;
            foreach (Frame frame in frames)
            {
                int frameScore;
                if (frame.isStrike())
                {
                    frameScore = 10 + GetStrikeBonus(frameIndex);
                    frameIndex++;
                }
                else
                {
                    frameScore = FrameTotal(frameIndex);
                    if (frame.isSpare())
                    {
                        frameScore += GetSpareBonus(frameIndex);
                    }

                    frameIndex += 2;
                }

                score += frameScore;
            }

            return score;
        }

        public void Roll(int numPins)
        {
            if (_currentRollIndex > 20)
                throw new InvalidOperationException("Game over!");

            _rolls[_currentRollIndex] = numPins;
            _currentRollIndex++;
        }

        private int FrameTotal(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int GetSpareBonus(int frameIndex)
        {
            int spareBonus = _rolls[frameIndex + 2];
            return spareBonus;
        }

        private int GetStrikeBonus(int frameIndex)
        {
            var strikeBonus = _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
            return strikeBonus;
        }

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
