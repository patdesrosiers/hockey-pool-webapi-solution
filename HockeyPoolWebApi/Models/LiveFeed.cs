using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class LiveFeed
    {
        [DataMember]
        public GameData GameData { get; set; }
    }
}