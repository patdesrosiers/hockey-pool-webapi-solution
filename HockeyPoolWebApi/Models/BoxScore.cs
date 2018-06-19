using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class BoxScore
    {

        [DataMember]
        public Teams Teams { get; set; }

    }
}