using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb.Models
{

    // DOCS: https://osu.ppy.sh/wiki/ru/osu%21_File_Formats/Db_%28file_format%29#format

    public struct IntDoublePair
    {
        public int IntValue { get; }
        public double DoubleValue { get; }
        
        public IntDoublePair(int intValue, double doubleValue)
        {
            IntValue = intValue;
            DoubleValue = doubleValue;
        }
    }
}
