using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class GameStatus
    {
        [DataMember]
        public int CodedGameState { get; set; }
    }
}