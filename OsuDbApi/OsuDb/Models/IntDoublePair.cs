using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb.Models
{
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
