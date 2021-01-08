using OsuDbApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace OsuDbApi.CollectionDb
{

    // DOCS: https://osu.ppy.sh/wiki/ru/osu%21_File_Formats/Db_%28file_format%29#collection.db-format

    public class CollectionDbReader : IDisposable, IDbReader<KeyValuePair<string, List<string>>>
    {
        public bool IsDisposed { get; private set; } = false;
        public int BeatmapCollectionReadCount { get; private set; } = 0;

        public int OsuVersion { get; }
        public int BeatmapCollectionsCount { get; }
        public string CollectionDbFile { get; }

        private const byte StringIndicator = 0x0b; // (DEC 11)

        private readonly FileStream osuDbFileStream;
        private readonly BinaryReader osuDbBinaryReader;
        private KeyValuePair<string, List<string>> beatmapCollection;

        /// <summary>
        /// Инициализует класс для чтения файла collection.db
        /// </summary>
        /// <param name="collectionDbFile">Файл</param>
        public CollectionDbReader(string collectionDbFile)
        {
            CollectionDbFile = collectionDbFile;
            osuDbFileStream = new FileStream(collectionDbFile, FileMode.Open, FileAccess.Read);
            osuDbBinaryReader = new BinaryReader(osuDbFileStream);
            OsuVersion = osuDbBinaryReader.ReadInt32();
            BeatmapCollectionsCount = osuDbBinaryReader.ReadInt32();
        }

        /// <summary>
        /// Читает следующую коллекцию и возвращает true при успешном чтении
        /// </summary>
        public bool Next()
        {
            if (BeatmapCollectionReadCount == BeatmapCollectionsCount)
                return false;

            string key = string.Empty;
            // Name of the collection
            if (osuDbBinaryReader.ReadByte() == StringIndicator)
                key = osuDbBinaryReader.ReadString();

            List<string> mapsMd5 = new List<string>();
            // MD5 hash Beatmaps 
            int countMaps = osuDbBinaryReader.ReadInt32();
            for (int i = 0; i < countMaps; i++)
            {
                if (osuDbBinaryReader.ReadByte() == StringIndicator)
                    mapsMd5.Add(osuDbBinaryReader.ReadString());
            }

            beatmapCollection = new KeyValuePair<string, List<string>>(key, mapsMd5);

            BeatmapCollectionReadCount++;

            return true;
        }

        public KeyValuePair<string, List<string>> GetValue() => beatmapCollection;

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