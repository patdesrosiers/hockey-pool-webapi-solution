using HockeyPoolWebApi.API;
using HockeyPoolWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HockeyPoolWebApi.Controllers
{
    [Route("[controller]")]
    public class GamesController : Controller
    {

        private INHLApiClient _nhlApi;

        public GamesController(INHLApiClient nhlApi)
        {
            _nhlApi = nhlApi;
        }
    
        // GET /games/gamePk
        [HttpGet("{gamePk}")]
        public JsonResult Get(int gamePk)
        {
            return new JsonResult(JsonConvert.DeserializeObject<BoxScore>(_nhlApi.GetBoxScore(gamePk).Result));
        }
    }
}