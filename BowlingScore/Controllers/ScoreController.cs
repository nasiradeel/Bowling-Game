using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Guards;
using BowlingScore.BusinessLogic;
using System.Web.Http.Description;
using System.Net.Http.Formatting;

namespace BowlingScore.Controllers
{
    public class ScoreController : ApiController
    {
        private readonly IGameManager gameManager;
        
        public ScoreController(IGameManager gameManager)
        {
            Guard.ArgumentNotNull(() => gameManager);
            this.gameManager = gameManager;
        }

        [HttpPost]
        [HttpOptions]
        public IHttpActionResult CalculateScore(List<Frame> frames)
        {
            var score = this.gameManager.CalculateScore(frames);
            return this.Ok(score);
        }
    }
}
