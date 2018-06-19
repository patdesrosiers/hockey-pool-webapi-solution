using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class Away
    {
        [DataMember]
        public Team Team { get; set; }
        [DataMember]
        public TeamStats TeamStats { get; set; }
    }
}