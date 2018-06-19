using System.Collections.Generic;
using HockeyPoolWebApi.API;
using HockeyPoolWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HockeyPoolWebApi.Controllers
{
    [Route("[controller]")]
    public class PlayoffController : Controller
    {

        private INHLApiClient _nhlApi;

        public PlayoffController(INHLApiClient nhlApi)
        {
            _nhlApi = nhlApi;
        }

        // GET /playoff/
        [HttpGet()]
        public JsonResult Get()
        {
            var playoff = JsonConvert.DeserializeObject<Playoff>(_nhlApi.GetPlayoff("20172018").Result);
            foreach (Round round in playoff.Rounds)
            {
                if (round.Number == playoff.DefaultRound)
                {
                    SearchForBoxScoreIfInProgress(round);                
                }

            }
            return new JsonResult(playoff);
        }

        private void SearchForBoxScoreIfInProgress(Round round)
        {
            foreach (Serie serie in round.Series)
            {
                if (serie.CurrentGame.CouldBeInProgess())
                {
                    AssignBoxScoreToCurrentGame(serie);
                }
            }
        }

        private void AssignBoxScoreToCurrentGame(Serie serie)
        {
            var gamePk = serie.CurrentGame.SeriesSummary.GamePk;
            var liveFeed = JsonConvert.DeserializeObject<LiveFeed>(_nhlApi.GetLiveFeed(gamePk).Result);
            if (liveFeed.GameData.Status.CodedGameState == 3)
            {
                serie.CurrentGame.BoxScore = JsonConvert.DeserializeObject<BoxScore>(_nhlApi.GetBoxScore(gamePk).Result);
            }
        }
    }
}