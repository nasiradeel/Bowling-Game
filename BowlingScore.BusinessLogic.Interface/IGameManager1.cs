using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.BusinessLogic.Interface
{
    public interface IGameManager1
    {
        int CalculateScore(List<IFrame> frames);
    }
}
