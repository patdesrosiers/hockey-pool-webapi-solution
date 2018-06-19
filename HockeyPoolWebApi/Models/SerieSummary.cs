using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class SerieSummary
    {
        [DataMember]
        public int GamePk { get; set; }
        [DataMember]
        public string GameTime { get; set; }
        [DataMember]
        public string SeriesStatus { get; set; }
        [DataMember]
        public bool Necessary { get; set; }
    }
}