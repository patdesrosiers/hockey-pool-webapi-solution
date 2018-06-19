using System.Collections.Generic;
using System.Linq;
using HockeyPoolWebApi.API;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HockeyPoolWebApi.Models
{
    public class PredictionsContext : DbContext
    {
        public DbSet<Prediction> Predictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hockey-pool.db");
        }

        public IEnumerable<Prediction> GetPredictionsWithScore(Playoff actualPlayoff, long userId)
        {
            var predictions = this.Predictions.Where(p => p.IdUser == userId).OrderBy(p => p.RoundNumber);

            foreach (Round round in actualPlayoff.Rounds)
            {
                IEnumerable<Prediction> predictionsForTheActualRound = predictions.Where(p => p.RoundNumber == round.Number);
                if (predictionsForTheActualRound != null)
                {
                    foreach (Prediction prediction in predictionsForTheActualRound)
                    {
                        Serie currentSerie = round.Series.First(m => m.SeriesNumber == prediction.SerieNumber);
                        prediction.CalculateScore(currentSerie);
                    }
                }
            }
            return predictions;
        }
    }
}