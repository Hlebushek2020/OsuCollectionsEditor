using OsuDbApi.OsuDb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb.Models
{
    public class Beatmap
    {
        public int? SizeInBytes { get; set; }
        public string ArtistName { get; set; }
        public string ArtistNameUnicode { get; set; }
        public string SongTitle { get; set; }
        public string SongTitleUnicode { get; set; }
        public string CreatorName { get; set; }
        public string Difficulty { get; set; }
        public string AudioFileName { get; set; }
        public string MD5Hash { get; set; }
        public string OsuFileName { get; set; }
        // TODO: convert from byte
        public RankedStatus RankedStatus { get; set; }
        public short HitcirclesCount { get; set; }
        public short SlidersCount { get; set; }
        public short SpinnersCount { get; set; }
        // TODO: convert from long (long is tick)
        public TimeSpan ModificationTime { get; set; }
        // TODO: convert from byte if the version is less than 20140609 else float (single)
        public float ApproachRate { get; set; }
        // TODO: convert from byte if the version is less than 20140609 else float (single)
        public float CircleSize { get; set; }
        // TODO: convert from byte if the version is less than 20140609 else float (single)
        public float HPDrain { get; set; }
        // TODO: convert from byte if the version is less than 20140609 else float (single)
        public float OverallDifficulty { get; set; }
        public double SliderVelocity { get; set; }
        // TODO: only present if version is greater than or equal to 20140609
        public List<IntDoublePair> StarRatingStandart { get; set; }
        // TODO: only present if version is greater than or equal to 20140609
        public List<IntDoublePair> StarRatingTakio { get; set; }
        // TODO: only present if version is greater than or equal to 20140609
        public List<IntDoublePair> StarRatingCTB { get; set; }
        // TODO: only present if version is greater than or equal to 20140609
        public List<IntDoublePair> StarRatingMania { get; set; }
        // TODO: convert from int (int in seconds)
        public TimeSpan DrainTime { get; set; }
        // TODO: convert from int (int in milliseconds)
        public TimeSpan TotalTime { get; set; }
        // TODO: convert from int (int in milliseconds)
        public TimeSpan AudioPreview { get; set; }

    }
}