using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HockeyPoolWebApi.Models
{
    public class Pooler
    {
        public long Id { get; set; }
        public string Email { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [NotMapped]
        public IEnumerable<Prediction> Predictions { get; set; }

        [NotMapped]
        public int Score
        {
            get
            {
                return Predictions.Sum(p => p.Score);
            }
        }

    }
}