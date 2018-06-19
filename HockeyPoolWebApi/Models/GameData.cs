using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class GameData
    {
        [DataMember]
        public GameStatus Status { get; set; }
    }
}