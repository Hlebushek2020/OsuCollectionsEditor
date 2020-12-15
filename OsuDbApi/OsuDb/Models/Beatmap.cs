using OsuDbApi.Enums;
using OsuDbApi.OsuDb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb.Models
{

    // DOCS: https://osu.ppy.sh/wiki/ru/osu%21_File_Formats/Db_%28file_format%29#osu!.db-format

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
        public string Md5Hash { get; set; }
        public string OsuFileName { get; set; }
        // TODO L: convert from byte
        public RankedStatus RankedStatus { get; set; }
        public short HitcirclesCount { get; set; }
        public short SlidersCount { get; set; }
        public short SpinnersCount { get; set; }
        // TODO L: convert from long (long is tick)
        public DateTime LastModificationTime { get; set; }
        // TODO L: convert from byte if the version is less than 20140609 else float (single)
        public float ApproachRate { get; set; }
        // TODO L: convert from byte if the version is less than 20140609 else float (single)
        public float CircleSize { get; set; }
        // TODO L: convert from byte if the version is less than 20140609 else float (single)
        public float HpDrain { get; set; }
        // TODO L: convert from byte if the version is less than 20140609 else float (single)
        public float OverallDifficulty { get; set; }
        public double SliderVelocity { get; set; }
        // TODO L: only present if version is greater than or equal to 20140609
        public List<IntDoublePair> StarRatingStandart { get; set; }
        // TODO L: only present if version is greater than or equal to 20140609
        public List<IntDoublePair> StarRatingTaiko { get; set; }
        // TODO L: only present if version is greater than or equal to 20140609
        public List<IntDoublePair> StarRatingCtb { get; set; }
        // TODO L: only present if version is greater than or equal to 20140609
        public List<IntDoublePair> StarRatingMania { get; set; }
        // TODO L: convert from int (int in seconds)
        public TimeSpan DrainTime { get; set; }
        // TODO L: convert from int (int in milliseconds)
        public TimeSpan TotalTime { get; set; }
        // TODO L: convert from int (int in milliseconds)
        public TimeSpan AudioPreviewTime { get; set; }
        public List<TimingPoint> TimingPoints { get; set; }
        public int Id { get; set; }
        public int SetId { get; set; }
        public int ThreadId { get; set; }
        public byte GradeAchievedStandart { get; set; }
        public byte GradeAchievedTaiko { get; set; }
        public byte GradeAchievedCtb { get; set; }
        public byte GradeAchievedMania { get; set; }
        public short LocalOffset { get; set; }
        public float StackLeniency { get; set; }
        // TODO L: convert from byte
        public GameplayMode GameplayMode { get; set; }
        public string SongSource { get; set; }
        public string SongTags { get; set; }
        public short OnlineOffset { get; set; }
        public string FontTitleSong { get; set; }
        public bool IsUnplayed { get; set; }
        // TODO L: convert from long (long is millisecond ??)
        public DateTime LastTimePlay { get; set; }
        public bool IsOsz2 { get; set; }
        public string FolderName { get; set; }
        // TODO L: convert from long (long is millisecond ??)
        public DateTime LastTimeCheckedRepository { get; set; }
        public bool IgnoreSound { get; set; }
        public bool IgnoreSkin { get; set; }
        public bool DisableStoryboard { get; set; }
        public bool DisableVideo { get; set; }
        public bool VisualOverride { get; set; }
        //public short? Unknown { get; set; }
        //public TimeSpan LastModificationTime { get; set; }
        public byte ManiaScrollSpeed { get; set; }
    }
}