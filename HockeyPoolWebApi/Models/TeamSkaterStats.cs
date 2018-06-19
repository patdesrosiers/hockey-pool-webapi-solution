using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class TeamSkaterStats
    {
        [DataMember]
        public int Goals { get; set; }

    }
}