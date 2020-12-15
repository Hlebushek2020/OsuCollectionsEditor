using OsuDbApi.CollectionDb.Models;
using OsuDbApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.CollectionDb
{

    // TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST TEST

    public class CollectionDbWritter : IDbWritter
    {
        public Dictionary<string, BeatmapCollection> BeatmapCollections { get; } = new Dictionary<string, BeatmapCollection>();

        public int OsuVersion { get; }
        public string FullFileName { get; }

        private const byte StringIndicator = 0x0b; // (DEC 11)

        /// <summary>
        /// Инициализует класс для записи в файл collection.db
        /// </summary>
        /// <param name="fullFileName">Путь с именем файла</param>
        /// <param name="osuVersion">Osu Version (Default: 20201210)</param>
        public CollectionDbWritter(string fullFileName, int osuVersion = 20201210)
        {
            OsuVersion = osuVersion;
            FullFileName = fullFileName;
        }

        public void Save()
        {
            using (FileStream collectionDbFileStream = new FileStream(FullFileName, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter collectionDbBinaryWriter = new BinaryWriter(collectionDbFileStream))
                {
                    collectionDbBinaryWriter.Write(OsuVersion);
                    collectionDbBinaryWriter.Write(BeatmapCollections.Count);
                    foreach (string name in BeatmapCollections.Keys)
                    {
                        BeatmapCollection beatmapCollection = BeatmapCollections[name];
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