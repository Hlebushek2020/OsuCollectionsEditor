using OsuDbApi.CollectionDb.Models;
using OsuDbApi.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.CollectionDb
{

    // DOCS: https://osu.ppy.sh/wiki/ru/osu%21_File_Formats/Db_%28file_format%29#collection.db-format

    public class CollectionDbReader : IDisposable, IDbReader<BeatmapCollection>
    {
        public bool IsDisposed { get; private set; } = false;
        public int BeatmapCollectionReadCount { get; private set; } = 0;

        public int OsuVersion { get; }
        public int BeatmapCollectionsCount { get; }

        private const byte StringIndicator = 0x0b; // (DEC 11)

        private readonly FileStream osuDbFileStream;
        private readonly BinaryReader osuDbBinaryReader;
        private BeatmapCollection beatmapCollection;

        /// <summary>
        /// Инициализует класс для чтения файла collection.db
        /// </summary>
        /// <param name="osuDbFile">Файл</param>
        public CollectionDbReader(string osuDbFile)
        {
            osuDbFileStream = new FileStream(osuDbFile, FileMode.Open, FileAccess.Read);
            osuDbBinaryReader = new BinaryReader(osuDbFileStream);
            OsuVersion = osuDbBinaryReader.ReadInt32();
            BeatmapCollectionsCount = osuDbBinaryReader.ReadInt32();
        }

        /// <summary>
        /// Читает следующую карту и возвращает true при успешном чтении
        /// </summary>
        public bool Next()
        {
            if (BeatmapCollectionReadCount == BeatmapCollectionsCount)
                return false;
            beatmapCollection = new BeatmapCollection();
            int intValue;
            // Name of the collection
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                beatmapCollection.Name = osuDbBinaryReader.ReadString();
            // MD5 hash Beatmaps 
            intValue = osuDbBinaryReader.ReadInt32();
            beatmapCollection.Beatmaps = new List<string>();
            for (int i = 0; i < intValue; i++)
            {
                if (osuDbBinaryReader.ReadByte() == StringIndicator)
                    beatmapCollection.Beatmaps.Add(osuDbBinaryReader.ReadString());
            }
            BeatmapCollectionReadCount++;
            return true;
        }

        public BeatmapCollection GetValue() => beatmapCollection;

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