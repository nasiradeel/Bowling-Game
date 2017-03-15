using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.BusinessLogic.Interface
{
    public interface IFrame
    {
        int FirstRoll { get; set; }
        int SecondRoll { get; set; }
        int ThirdRoll { get; set; }
        int Position { get; set; }

        int Score();
        bool isStrike();
        bool isSpare();
        bool isLast();

    }
}
