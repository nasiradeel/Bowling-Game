﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.BusinessLogic
{
    public interface IGameManager
    {
        Score CalculateScore(List<Frame> frames);
    }
}
