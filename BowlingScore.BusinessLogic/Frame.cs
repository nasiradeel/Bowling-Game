using BowlingScore.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.BusinessLogic
{
    public class Frame 
    {
        private const int totalPins = 10;
        private const int totalFarmes = 10;

        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public int ThirdRoll { get; set; }
        public int Position { get; set; }

        public int Score
        {
            get { return FirstRoll + SecondRoll + ThirdRoll;}
            set { Score = value; }
        }

        public bool isStrike()
        {
            return FirstRoll == totalPins;
        }

        public bool isSpare()
        {
            return FirstRoll + SecondRoll == totalPins;
        }

        public bool isLast()
        {
            return Position == totalFarmes - 1;
        }



    }
}
