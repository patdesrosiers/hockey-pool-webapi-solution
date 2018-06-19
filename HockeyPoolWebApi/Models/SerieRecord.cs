using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class SerieRecord
    {
        [DataMember]
        public int Wins { get; set; }
        [DataMember]
        public int Losses { get; set; }
    }
}