using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class TeamStats
    {
        [DataMember]
        public TeamSkaterStats TeamSkaterStats { get; set; }
    }
}