using OsuDbApi.Enums;
using OsuDbApi.Interfaces;
using OsuDbApi.ScoresDb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.ScoresDb
{
    public class ScoresDbReader : IDisposable, IDbReader<BeatmapScores>
    {
        public bool IsDisposed { get; private set; } = false;
        public int BeatmapScoresReadCount { get; private set; } = 0;

        public int OsuVersion { get; }
        public int BeatmapScoresCount { get; }
        public string ScoresDbFile { get; }

        private const byte StringIndicator = 0x0b; // (DEC 11)

        private readonly FileStream scoresDbFileStream;
        private readonly BinaryReader scoresDbBinaryReader;
        private BeatmapScores beatmapScores;

        public ScoresDbReader(string scoresDbFile)
        {
            ScoresDbFile = scoresDbFile;
            scoresDbFileStream = new FileStream(scoresDbFile, FileMode.Open, FileAccess.Read);
            scoresDbBinaryReader = new BinaryReader(scoresDbFileStream);
            OsuVersion = scoresDbBinaryReader.ReadInt32();
            BeatmapScoresCount = scoresDbBinaryReader.ReadInt32();
        }

        public bool Next()
        {
            if (BeatmapScoresCount == BeatmapScoresReadCount)
                return false;
            beatmapScores = new BeatmapScores();
            if (scoresDbBinaryReader.ReadByte() == StringIndicator)
                beatmapScores.BeatmapHash = scoresDbBinaryReader.ReadString();
            int intValue = scoresDbBinaryReader.ReadInt32();
            beatmapScores.Scores = new List<Score>();
            for (int i = 0; i < intValue; i++)
            {
                Score score = new Score();
                score.GameplayMode = (GameplayMode)scoresDbBinaryReader.ReadByte();
                score.ScoreVersion = scoresDbBinaryReader.ReadInt32();
                if (scoresDbBinaryReader.ReadByte() == StringIndicator)
                    score.BeatmapHash = scoresDbBinaryReader.ReadString(); 
                if (scoresDbBinaryReader.ReadByte() == StringIndicator)
                    score.PlayerName = scoresDbBinaryReader.ReadString();
                if (scoresDbBinaryReader.ReadByte() == StringIndicator)
                    score.Md5Hash = scoresDbBinaryReader.ReadString();
                score.Count300 = scoresDbBinaryReader.ReadInt16();
                score.Count100 = scoresDbBinaryReader.ReadInt16();
                score.Count50 = scoresDbBinaryReader.ReadInt16();
                score.GekiCount = scoresDbBinaryReader.ReadInt16();
                score.KatuCount = scoresDbBinaryReader.ReadInt16();
                score.MissCount = scoresDbBinaryReader.ReadInt16();
                score.ReplayScore = scoresDbBinaryReader.ReadInt32();
                score.MaxCombo = scoresDbBinaryReader.ReadInt16();
                score.PerfectCombo = scoresDbBinaryReader.ReadBoolean();
                score.CombinationModsUsed = scoresDbBinaryReader.ReadInt32();
                if (scoresDbBinaryReader.ReadByte() == StringIndicator)
                    scoresDbBinaryReader.ReadString();
                score.TimestampReplay = new DateTime(scoresDbBinaryReader.ReadInt64());
                scoresDbFileStream.Position += 4;
                score.OnlineScoreId = scoresDbBinaryReader.ReadInt64();
                //GameplayMode gameplayMode = (GameplayMode)scoresDbBinaryReader.ReadByte();
                //if (gameplayMode != GameplayMode.CTB || gameplayMode != GameplayMode.Mania 
                //  || gameplayMode != GameplayMode.Standart || gameplayMode != GameplayMode.Taiko)
                //{
                //    scoresDbFileStream.Position -= 1;
                //    score.AdditionalModInformation = scoresDbBinaryReader.ReadDouble();
                //}
                //else
                //    scoresDbFileStream.Position -= 1;
                beatmapScores.Scores.Add(score);
            }
            return true;
        }

        public BeatmapScores GetValue() => beatmapScores;

        public void Dispose()
        {
            if (scoresDbBinaryReader != null)
                scoresDbBinaryReader.Dispose();
            if (scoresDbFileStream != null)
                scoresDbFileStream.Dispose();
            IsDisposed = true;
        }

    }
}