using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HockeyPoolWebApi.Models
{
    public class Prediction
    {
        public long Id { get; set; }
        public string Season { get; set; }
        public int RoundNumber { get; set; }
        public int SerieNumber { get; set; }
        public int TeamId { get; set; }
        public int IdUser { get; set; }

        public int NumberOfGames { get; set; }

        [NotMapped]
        public int Score { get; private set; }

        public void CalculateScore(Serie serie)
        {
            MatchupTeam selectedTeam = serie.MatchupTeams.First(m => m.Team.Id == TeamId);
            if (selectedTeam != null && selectedTeam.SeriesRecord.Wins == 4)
            {
                int numberOfActualGamesNeeded = selectedTeam.SeriesRecord.Wins + selectedTeam.SeriesRecord.Losses;
                if (NumberOfGames == numberOfActualGamesNeeded)
                {
                    Score = 5;
                }
                else
                {
                    Score = 3;
                }
            }
        }
    }
}