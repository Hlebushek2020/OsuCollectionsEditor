using OsuDbApi.CollectionDb;
using OsuDbApi.Enums;
using OsuDbApi.OsuDb;
using OsuDbApi.ScoresDb;
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
            //string osudb = Console.ReadLine();
            //OsuDbReader reader = new OsuDbReader(osudb);
            //reader.Next();
            //reader.Next();

            //string collectionDb = Console.ReadLine();
            //CollectionDbReader collectionDbReader = new CollectionDbReader(collectionDb);
            //collectionDbReader.Next();
            //collectionDbReader.Next();

            string scoreDb = Console.ReadLine();
            ScoresDbReader scoresDbReader = new ScoresDbReader(scoreDb);

            while (scoresDbReader.Next())
            {
                BeatmapScores scores = scoresDbReader.GetValue();
                if (scores.Scores.Count != 0 && scores.Scores.First().CombinationModsUsed == Mods.TargetPractice)
                {
                    Console.WriteLine("Found target practice map");
                    Console.WriteLine($"Additional value: {scores.Scores.First().AdditionalModInformation}");
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
