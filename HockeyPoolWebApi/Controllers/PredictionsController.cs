using System.Linq;
using HockeyPoolWebApi.API;
using HockeyPoolWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HockeyPoolWebApi.Controllers
{
    [Route("[controller]")]
    public class PredictionsController : Controller
    {
        private readonly PredictionsContext _context;
        private INHLApiClient _nhlApi;


        public PredictionsController(PredictionsContext context, INHLApiClient nhlApi)
        {
            _context = context;
            _nhlApi = nhlApi;
        }

        // GET predictions/1 (id is the user ID)
        [HttpGet("{id}")]
        public JsonResult GetPredictions(int id)
        {
            var playoff = JsonConvert.DeserializeObject<Playoff>(_nhlApi.GetPlayoff("20172018").Result);

            return new JsonResult(_context.GetPredictionsWithScore(playoff, id));
        }

        // POST predictions
        [HttpPost]
        public void Post([FromBody]Prediction value)
        {
            _context.Predictions.Add(value);
            _context.SaveChanges();
        }

        // PUT predictions/1 where id is the prediction id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Prediction value)
        {
            var predictionFromDataBase = _context.Predictions.First(p => p.Id == id);            
            predictionFromDataBase.TeamId = value.TeamId;
            predictionFromDataBase.NumberOfGames = value.NumberOfGames;
            _context.SaveChanges();
        }
    }
}