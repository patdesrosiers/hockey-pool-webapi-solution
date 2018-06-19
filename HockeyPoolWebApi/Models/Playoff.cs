using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class Playoff
    {
        [DataMember]
        public List<Round> Rounds { get; set; }
        [DataMember]
        public int DefaultRound { get; set; }
    }
}