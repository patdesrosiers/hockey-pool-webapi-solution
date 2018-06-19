using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class Team
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }

    }
}