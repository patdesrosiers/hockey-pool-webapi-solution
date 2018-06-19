using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class Round
    {
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public RoundNames Names { get; set; }
        [DataMember]
        public List<Serie> Series { get; set; }
    }
}