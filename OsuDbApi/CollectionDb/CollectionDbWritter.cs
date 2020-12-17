﻿using OsuDbApi.CollectionDb.Models;
using System.Collections.Generic;
using System.IO;

namespace OsuDbApi.CollectionDb
{

    // TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST

    public class CollectionDbWritter
    {
        public List<BeatmapCollection> BeatmapCollections { get; } = new List<BeatmapCollection>();

        public int OsuVersion { get; }
        public string CollectionDbFile { get; }

        private const byte StringIndicator = 0x0b; // (DEC 11)

        /// <summary>
        /// Инициализует класс для записи данных в файл collection.db
        /// </summary>
        /// <param name="collectionDbFile">Имя файла, включая путь к нему</param>
        /// <param name="osuVersion">Osu Version (Default: 20201210)</param>
        public CollectionDbWritter(string collectionDbFile, int osuVersion = 20201210)
        {
            OsuVersion = osuVersion;
            CollectionDbFile = collectionDbFile;
        }

        public void Save()
        {
            using (FileStream collectionDbFileStream = new FileStream(CollectionDbFile, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter collectionDbBinaryWriter = new BinaryWriter(collectionDbFileStream))
                {
                    collectionDbBinaryWriter.Write(OsuVersion);
                    collectionDbBinaryWriter.Write(BeatmapCollections.Count);
                    foreach (BeatmapCollection beatmapCollection in BeatmapCollections)
                    {
                        collectionDbBinaryWriter.Write(StringIndicator);
                        collectionDbBinaryWriter.Write(beatmapCollection.Name);
                        collectionDbBinaryWriter.Write(beatmapCollection.Beatmaps.Count);
                        foreach (string item in beatmapCollection.Beatmaps)
                        {
                            collectionDbBinaryWriter.Write(StringIndicator);
                            collectionDbBinaryWriter.Write(item);
                        }
                    }
                }
            }
        }
    }
}