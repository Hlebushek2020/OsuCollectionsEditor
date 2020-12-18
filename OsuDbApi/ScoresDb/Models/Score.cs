using OsuDbApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.ScoresDb.Models
{
    public class Score
    {
        public GameplayMode GameplayMode { get; set; }
        public int ScoreVersion { get; set; }
        public string BeatmapHash { get; set; }
        public string PlayerName { get; set; }
        public string Md5Hash { get; set; }
        public short Count300 { get; set; }
        public short Count100 { get; set; }
        public short Count50 { get; set; }
        public short GekiCount { get; set; }
        public short KatuCount { get; set; }
        public short MissCount { get; set; }
        public int ReplayScore { get; set; }
        public short MaxCombo { get; set; }
        public bool PerfectCombo { get; set; }
        public int CombinationModsUsed { get; set; }
        public DateTime TimestampReplay { get; set; }
        public long OnlineScoreId { get; set; }
        //public double AdditionalModInformation { get; set; }
    }
}
