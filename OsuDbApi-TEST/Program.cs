﻿using OsuDbApi.CollectionDb;
using OsuDbApi.Enums;
using OsuDbApi.OsuDb;
using OsuDbApi.OsuDb.Models;
using OsuDbApi.ScoresDb;
using OsuDbApi.ScoresDb.Enums;
using OsuDbApi.ScoresDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ScoreDbReader
            //string scoreDb = Console.ReadLine();
            //ScoresDbReader scoresDbReader = new ScoresDbReader(scoreDb);

            //while (scoresDbReader.Next())
            //{
            //    BeatmapScores scores = scoresDbReader.GetValue();
            //    if (scores.Scores.Count != 0 && scores.Scores.First().CombinationModsUsed == Mods.TargetPractice)
            //    {
            //        Console.WriteLine("Found target practice map");
            //        Console.WriteLine($"Additional value: {scores.Scores.First().AdditionalModInformation}");
            //    }
            //}
            #endregion

            #region CollectionDbWriter & OsuDbReader
            //string osuDir = "G:\\Osu";

            //Dictionary<string, List<string>> all = new Dictionary<string, List<string>>();

            //OsuDbReader osuDbReader = new OsuDbReader($"{osuDir}\\osu!.db");

            //while (osuDbReader.Next())
            //{
            //    Beatmap beatmap = osuDbReader.GetValue();
            //    string sid = beatmap.ArtistNameUnicode + beatmap.SongTitleUnicode + beatmap.CreatorName;
            //    if (!all.ContainsKey(sid))
            //        all.Add(sid, new List<string>());
            //    all[sid].Add(beatmap.Md5Hash);
            //}

            //CollectionDbWriter collectionDbWriter = new CollectionDbWriter($"{osuDir}\\collection.db", osuDbReader.OsuVersion);

            //collectionDbWriter.BeatmapCollections.Add("test", all.Values.ElementAt(0));
            //collectionDbWriter.BeatmapCollections["test"].AddRange(all.Values.ElementAt(1));

            //collectionDbWriter.BeatmapCollections.Add("test1", all.Values.ElementAt(2));

            //collectionDbWriter.Save();
            #endregion

            #region CollectionDbReader
            //string osuDir = "G:\\Osu";

            //CollectionDbReader collectionDbReader = new CollectionDbReader($"{osuDir}\\collection.db");

            //while (collectionDbReader.Next())
            //{
            //    KeyValuePair<string, List<string>> item = collectionDbReader.GetValue();
            //    Console.WriteLine($"{item.Key}\t{item.Value.Count}");
            //}
            #endregion

            #region OsuDbReader & CollectionDbReader
            //string osuDir = "G:\\Osu";

            //OsuDbReader osuDbReader = new OsuDbReader($"{osuDir}\\osu!.db");
            //CollectionDbReader collectionDbReader = new CollectionDbReader($"{osuDir}\\collection.db");

            //HashSet<string> md5HashAll = new HashSet<string>();

            //while (osuDbReader.Next())
            //{
            //    Beatmap beatmap = osuDbReader.GetValue();
            //    md5HashAll.Add(beatmap.Md5Hash);
            //}

            //while (collectionDbReader.Next())
            //{
            //    KeyValuePair<string, List<string>> item = collectionDbReader.GetValue();
            //    Console.WriteLine($"{item.Key}\t{item.Value.Count}");
            //    Console.WriteLine("\tNo map: ");
            //    foreach (string itemMd5 in item.Value)
            //        if (!md5HashAll.Contains(itemMd5))
            //            Console.WriteLine($"\t{itemMd5}");
            //}
            #endregion

            #region OsuDbReader & CollectionDbReader & CollectionDbWriter
            //string osuDir = "G:\\Osu";

            //OsuDbReader osuDbReader = new OsuDbReader($"{osuDir}\\osu!.db");
            //CollectionDbReader collectionDbReader = new CollectionDbReader($"{osuDir}\\collection.db");
            //CollectionDbWriter collectionDbWriter = new CollectionDbWriter($"{osuDir}\\collection.db");

            //HashSet<string> md5HashAll = new HashSet<string>();

            //while (osuDbReader.Next())
            //{
            //    Beatmap beatmap = osuDbReader.GetValue();
            //    md5HashAll.Add(beatmap.Md5Hash);
            //}

            //while (collectionDbReader.Next())
            //{
            //    KeyValuePair<string, List<string>> item = collectionDbReader.GetValue();
            //    Console.WriteLine($"{item.Key}\t{item.Value.Count}");

            //    collectionDbWriter.BeatmapCollections.Add(item.Key, new List<string>());

            //    Console.WriteLine("\tNo map: ");
            //    foreach (string itemMd5 in item.Value)
            //        if (!md5HashAll.Contains(itemMd5))
            //            Console.WriteLine($"\t{itemMd5}");
            //        else
            //            collectionDbWriter.BeatmapCollections[item.Key].Add(itemMd5);
            //}

            //collectionDbReader.Dispose();

            //collectionDbWriter.Save();
            #endregion

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
