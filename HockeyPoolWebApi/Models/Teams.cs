using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class Teams
    {
        [DataMember]
        public Away Away { get; set; }
        [DataMember]
        public Home Home { get; set; }
    }
}