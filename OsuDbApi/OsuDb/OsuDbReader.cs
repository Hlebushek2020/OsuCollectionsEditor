using OsuDbApi.OsuDb.Enums;
using OsuDbApi.OsuDb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb
{
    public class OsuDbReader : IDisposable
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

        private FileStream osuDbFileStream;
        private BinaryReader osuDbBinaryReader;
        private Beatmap beatmap;

        /// <summary>
        /// Инициализует класс для работы с файлом
        /// </summary>
        /// <param name="osuDbFile">Файл</param>
        public OsuDbReader(string osuDbFile)
        {
            osuDbFileStream = new FileStream(osuDbFile, FileMode.Open, FileAccess.Read);
            osuDbBinaryReader = new BinaryReader(osuDbFileStream);
            OsuVersion = osuDbBinaryReader.ReadInt32();
            FolderCount = osuDbBinaryReader.ReadInt32();
            AccountUnlocked = osuDbBinaryReader.ReadBoolean();
            DateAccountUnlocked = new DateTime(osuDbBinaryReader.ReadInt64());
            PlayerName = osuDbBinaryReader.ReadString();
            BeatmapsCount = osuDbBinaryReader.ReadInt32();
            long currentPosition = osuDbFileStream.Position;
            osuDbFileStream.Position = osuDbFileStream.Length - 5;
            UserPermissions = (UserPermissions)osuDbBinaryReader.ReadInt32();
            osuDbFileStream.Position = currentPosition;
        }

        /// <summary>
        /// Читает следующую карту и возвращает true при успешном чтении
        /// </summary>
        public bool NextBeatmap()
        {
            if (BeatmapReadCount == BeatmapsCount)
                return false;
            try
            {
                // logik
                return true;
            }
            catch { return false; }
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