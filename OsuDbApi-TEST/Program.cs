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
            string osudb = Console.ReadLine();
            OsuDbReader reader = new OsuDbReader(osudb);
            reader.NextBeatmap();
        }
    }
}
