using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HockeyPoolWebApi.API;
using HockeyPoolWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HockeyPoolWebApi.Controllers
{
    [Route("[controller]")]
    public class PoolersController : Controller
    {

        private readonly PoolersContext _context;
        private readonly PredictionsContext _predictionsContext;
        private INHLApiClient _nhlApi;

        public PoolersController(PoolersContext context, PredictionsContext predictionsContext, INHLApiClient nhlApi)
        {
            _context = context;
            _predictionsContext = predictionsContext;
            _nhlApi = nhlApi;
        }

        [HttpGet()]
        public JsonResult GetAllPoolers()
        {
            var playoff = JsonConvert.DeserializeObject<Playoff>(_nhlApi.GetPlayoff("20172018").Result);
            var poolers = _context.Poolers;
            foreach (Pooler p in poolers)
            {
                p.Predictions = _predictionsContext.GetPredictionsWithScore(playoff, p.Id);
            }
            return new JsonResult(poolers);
        }   

        // GET poolers/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_context.Poolers.First(m => m.Id == id));
        }

        // POST poolers
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT poolers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
