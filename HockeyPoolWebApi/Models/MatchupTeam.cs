using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class MatchupTeam
    {
    
        [DataMember]
        public Team Team { get; set; }

        [DataMember]
        public SerieRecord SeriesRecord { get; set; }
    }
}