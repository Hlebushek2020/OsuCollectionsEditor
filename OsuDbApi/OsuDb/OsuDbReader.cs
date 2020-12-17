using OsuDbApi.Enums;
using OsuDbApi.Interfaces;
using OsuDbApi.OsuDb.Enums;
using OsuDbApi.OsuDb.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace OsuDbApi.OsuDb
{

    // DOCS: https://osu.ppy.sh/wiki/ru/osu%21_File_Formats/Db_%28file_format%29#osu!.db-format

    public class OsuDbReader : IDisposable, IDbReader<Beatmap>
    {
        public bool IsDisposed { get; private set; } = false;
        public int BeatmapReadCount { get; private set; } = 0;

        public int OsuVersion { get; }
        public int FolderCount { get; }
        public bool AccountUnlocked { get; }
        public DateTime DateAccountUnlocked { get; }
        public string PlayerName { get; }
        public int BeatmapsCount { get; }
        public UserPermissions UserPermissions { get; }
        public string OsuDbFile { get; }

        private const byte StringIndicator = 0x0b; // (DEC 11)

        private readonly FileStream osuDbFileStream;
        private readonly BinaryReader osuDbBinaryReader;
        private Beatmap beatmap;

        /// <summary>
        /// Инициализует класс для чтения файла osu!.db
        /// </summary>
        /// <param name="osuDbFile">Файл</param>
        public OsuDbReader(string osuDbFile)
        {
            OsuDbFile = osuDbFile;
            osuDbFileStream = new FileStream(osuDbFile, FileMode.Open, FileAccess.Read);
            osuDbBinaryReader = new BinaryReader(osuDbFileStream);
            OsuVersion = osuDbBinaryReader.ReadInt32();
            FolderCount = osuDbBinaryReader.ReadInt32();
            AccountUnlocked = osuDbBinaryReader.ReadBoolean();
            DateAccountUnlocked = new DateTime(osuDbBinaryReader.ReadInt64());
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                PlayerName = osuDbBinaryReader.ReadString();
            BeatmapsCount = osuDbBinaryReader.ReadInt32();
            long currentPosition = osuDbFileStream.Position;
            osuDbFileStream.Position = osuDbFileStream.Length - 4;

            UserPermissions = (UserPermissions)osuDbBinaryReader.ReadInt32(); //!!!!!

            osuDbFileStream.Position = currentPosition;
        }

        /// <summary>
        /// Читает следующую карту и возвращает true при успешном чтении
        /// </summary>
        public bool Next()
        {
            if (BeatmapReadCount == BeatmapsCount)
                return false;
            //try
            //{
            beatmap = new Beatmap();
            int intValue0, intValue1;
            double doubleValue0, doubleValue1;
            bool boolValue;
            // Size in bytes of the beatmap entry
            if (OsuVersion < 20191106)
                beatmap.SizeInBytes = osuDbBinaryReader.ReadInt32();
            // Artist name
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.ArtistName = osuDbBinaryReader.ReadString();
            // Artist name, in Unicode
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.ArtistNameUnicode = osuDbBinaryReader.ReadString();
            // Song title
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.SongTitle = osuDbBinaryReader.ReadString();
            // Song title, in Unicode
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.SongTitleUnicode = osuDbBinaryReader.ReadString();
            // Creator name
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.CreatorName = osuDbBinaryReader.ReadString();
            // Difficulty
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.Difficulty = osuDbBinaryReader.ReadString();
            // Audio file name
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.AudioFileName = osuDbBinaryReader.ReadString();
            // MD5 hash of the beatmap
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.Md5Hash = osuDbBinaryReader.ReadString();
            // Name of the .osu file corresponding to this beatmap
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.OsuFileName = osuDbBinaryReader.ReadString();
            // Ranked status
            beatmap.RankedStatus = (RankedStatus)osuDbBinaryReader.ReadByte();
            // Number of hitcircles
            beatmap.HitcirclesCount = osuDbBinaryReader.ReadInt16();
            // Number of sliders
            beatmap.SlidersCount = osuDbBinaryReader.ReadInt16();
            // Number of spinners
            beatmap.SpinnersCount = osuDbBinaryReader.ReadInt16();
            // Last modification time
            beatmap.LastModificationTime = new DateTime(osuDbBinaryReader.ReadInt64());
            // Approach rate
            // Circle size
            // HP drain
            // Overall difficulty
            if (OsuVersion < 20140609)
            {
                beatmap.ApproachRate = osuDbBinaryReader.ReadByte();
                beatmap.CircleSize = osuDbBinaryReader.ReadByte();
                beatmap.HpDrain = osuDbBinaryReader.ReadByte();
                beatmap.OverallDifficulty = osuDbBinaryReader.ReadByte();
            }
            else
            {
                beatmap.ApproachRate = osuDbBinaryReader.ReadSingle();
                beatmap.CircleSize = osuDbBinaryReader.ReadSingle();
                beatmap.HpDrain = osuDbBinaryReader.ReadSingle();
                beatmap.OverallDifficulty = osuDbBinaryReader.ReadSingle();
            }
            // Slider velocity
            beatmap.SliderVelocity = osuDbBinaryReader.ReadDouble();
            // Star Rating info
            if (OsuVersion >= 20140609)
            {
                // Star Rating info for osu! standard
                intValue0 = osuDbBinaryReader.ReadInt32();
                beatmap.StarRatingStandart = new List<IntDoublePair>();
                for (int i = 0; i < intValue0; i++)
                {
                    osuDbFileStream.Position += 1;
                    intValue1 = osuDbBinaryReader.ReadInt32();
                    osuDbFileStream.Position += 1;
                    doubleValue0 = osuDbBinaryReader.ReadDouble();
                    beatmap.StarRatingStandart.Add(new IntDoublePair(intValue1, doubleValue0));
                }
                // Star Rating info for Taiko
                intValue0 = osuDbBinaryReader.ReadInt32();
                beatmap.StarRatingTaiko = new List<IntDoublePair>();
                for (int i = 0; i < intValue0; i++)
                {
                    osuDbFileStream.Position += 1;
                    intValue1 = osuDbBinaryReader.ReadInt32();
                    osuDbFileStream.Position += 1;
                    doubleValue0 = osuDbBinaryReader.ReadDouble();
                    beatmap.StarRatingTaiko.Add(new IntDoublePair(intValue1, doubleValue0));
                }
                // Star Rating info for CTB
                intValue0 = osuDbBinaryReader.ReadInt32();
                beatmap.StarRatingCtb = new List<IntDoublePair>();
                for (int i = 0; i < intValue0; i++)
                {
                    osuDbFileStream.Position += 1;
                    intValue1 = osuDbBinaryReader.ReadInt32();
                    osuDbFileStream.Position += 1;
                    doubleValue0 = osuDbBinaryReader.ReadDouble();
                    beatmap.StarRatingCtb.Add(new IntDoublePair(intValue1, doubleValue0));
                }
                // Star Rating info for osu!mania
                intValue0 = osuDbBinaryReader.ReadInt32();
                beatmap.StarRatingMania = new List<IntDoublePair>();
                for (int i = 0; i < intValue0; i++)
                {
                    osuDbFileStream.Position += 1;
                    intValue1 = osuDbBinaryReader.ReadInt32();
                    osuDbFileStream.Position += 1;
                    doubleValue0 = osuDbBinaryReader.ReadDouble();
                    beatmap.StarRatingMania.Add(new IntDoublePair(intValue1, doubleValue0));
                }
            }
            // Drain time
            beatmap.DrainTime = new TimeSpan(0, 0, osuDbBinaryReader.ReadInt32());
            // Total time
            beatmap.TotalTime = new TimeSpan(0, 0, 0, 0, osuDbBinaryReader.ReadInt32());
            // Time when the audio preview when hovering over a beatmap in beatmap select starts
            beatmap.AudioPreviewTime = new TimeSpan(0, 0, 0, 0, osuDbBinaryReader.ReadInt32());
            // Timing points
            intValue0 = osuDbBinaryReader.ReadInt32();
            beatmap.TimingPoints = new List<TimingPoint>();
            for (int i = 0; i < intValue0; i++)
            {
                doubleValue0 = osuDbBinaryReader.ReadDouble();
                doubleValue1 = osuDbBinaryReader.ReadDouble();
                boolValue = !osuDbBinaryReader.ReadBoolean();
                beatmap.TimingPoints.Add(new TimingPoint(doubleValue0, doubleValue1, boolValue));
            }
            // Beatmap ID
            beatmap.Id = osuDbBinaryReader.ReadInt32();
            // Beatmap set ID
            beatmap.SetId = osuDbBinaryReader.ReadInt32();
            // Thread ID
            beatmap.ThreadId = osuDbBinaryReader.ReadInt32();
            // Grade achieved in osu! standard.
            beatmap.GradeAchievedStandart = osuDbBinaryReader.ReadByte();
            // Grade achieved in Taiko
            beatmap.GradeAchievedTaiko = osuDbBinaryReader.ReadByte();
            // Grade achieved in CTB
            beatmap.GradeAchievedCtb = osuDbBinaryReader.ReadByte();
            // Grade achieved in osu!mania
            beatmap.GradeAchievedMania = osuDbBinaryReader.ReadByte();
            // Local beatmap offset
            beatmap.LocalOffset = osuDbBinaryReader.ReadInt16();
            // Stack leniency
            beatmap.StackLeniency = osuDbBinaryReader.ReadSingle();
            // Osu gameplay mode
            beatmap.GameplayMode = (GameplayMode)osuDbBinaryReader.ReadByte();
            // Song source
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.SongSource = osuDbBinaryReader.ReadString();
            // Song tags
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.SongTags = osuDbBinaryReader.ReadString();
            // Online offset
            beatmap.OnlineOffset = osuDbBinaryReader.ReadInt16();
            // Font used for the title of the song
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.FontTitleSong = osuDbBinaryReader.ReadString();
            // Is beatmap unplayed
            beatmap.IsUnplayed = osuDbBinaryReader.ReadBoolean();
            // Last time when beatmap was played
            beatmap.LastTimePlay = new DateTime(osuDbBinaryReader.ReadInt64());
            // Is the beatmap osz2
            beatmap.IsOsz2 = osuDbBinaryReader.ReadBoolean();
            // Folder name of the beatmap, relative to Songs folder
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmap.FolderName = osuDbBinaryReader.ReadString();
            // Last time when beatmap was checked against osu! repository
            beatmap.LastTimeCheckedRepository = new DateTime(osuDbBinaryReader.ReadInt64());
            // Ignore beatmap sound
            beatmap.IgnoreSound = osuDbBinaryReader.ReadBoolean();
            // Ignore beatmap skin
            beatmap.IgnoreSkin = osuDbBinaryReader.ReadBoolean();
            // Disable storyboard
            beatmap.DisableStoryboard = osuDbBinaryReader.ReadBoolean();
            // Disable video
            beatmap.DisableVideo = osuDbBinaryReader.ReadBoolean();
            // Visual override
            beatmap.VisualOverride = osuDbBinaryReader.ReadBoolean();
            // IGNORED BLOCKS
            if (OsuVersion < 20140609)
                osuDbFileStream.Position += 2;
            osuDbFileStream.Position += 4;
            // Mania scroll speed
            beatmap.ManiaScrollSpeed = osuDbBinaryReader.ReadByte();
            BeatmapReadCount++;
            return true;
            //}
            //    catch { return false; }
        }

        public Beatmap GetValue() => beatmap;

        public void Dispose()
        {
            if (osuDbBinaryReader != null)
                osuDbBinaryReader.Dispose();
            if (osuDbFileStream != null)
                osuDbFileStream.Dispose();
            IsDisposed = true;
        }
    }
}