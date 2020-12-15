using OsuDbApi.CollectionDb;
using OsuDbApi.OsuDb;
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

            string collectionDb = Console.ReadLine();
            CollectionDbReader collectionDbReader = new CollectionDbReader(collectionDb);
            collectionDbReader.Next();
            collectionDbReader.Next();
        }
    }
}
