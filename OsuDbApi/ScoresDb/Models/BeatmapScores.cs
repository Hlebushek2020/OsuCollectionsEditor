using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.ScoresDb.Models
{
    public class BeatmapScores
    {
        public string BeatmapHash { get; set; }
        public List<Score> Scores { get; set; }
    }
}
