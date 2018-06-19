using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class SerieNames
    {
        [DataMember]
        public string MatchupName { get; set; }
        [DataMember]
        public string MatchupShortName { get; set; }

    }
}