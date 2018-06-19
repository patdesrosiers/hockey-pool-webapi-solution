using System;
using System.Collections.Generic;

namespace HockeyPoolWebApi.Models
{
    public class Serie
    {
        public int SeriesNumber { get; set; }
        public SerieNames Names { get; set; }
        public CurrentGame CurrentGame { get; set; }        
        public List<MatchupTeam> MatchupTeams { get; set; }
       
    }
}