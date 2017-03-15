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

        /// <summary>
        /// Constructor for dependies of game manager
        /// dependies are injected using Autofac nuget package
        /// configurations are in WebApi config
        /// <param name="frames"> a list of frames</param>
        /// </summary>
        public ScoreController(IGameManager gameManager)
        {
            Guard.ArgumentNotNull(() => gameManager);
            this.gameManager = gameManager;
        }

        // POST: api/Score/CalculateScore
        /// <summary>
        /// Calculate the total scroes.
        /// <param name="frames"> a list of frames</param>
        /// </summary>
        [HttpPost]
        [HttpOptions]
        public IHttpActionResult CalculateScore(List<Frame> frames)
        {
            var score = this.gameManager.CalculateScore(frames);
            return this.Ok(score);
        }
    }
}
