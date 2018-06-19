using System;
using System.Runtime.Serialization;

namespace HockeyPoolWebApi.Models
{
    [DataContract]
    public class CurrentGame
    {
        [DataMember]
        public SerieSummary SeriesSummary { get; set; }

        [DataMember]
        public BoxScore BoxScore { get; set; }

        public bool CouldBeInProgess()
        {
            DateTime nextGame = Convert.ToDateTime(this.SeriesSummary.GameTime);
            return nextGame.Date == DateTime.Now.Date && nextGame.TimeOfDay < DateTime.Now.TimeOfDay;            
        }
        
    }
}